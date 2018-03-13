using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PBTP.Core.Models;

namespace PBTP.Core.Services
{
    public class TemplateParserService
    {

        public string Parse(BaseTemplateDataModel data, string text)
        {
            if (data == null)
                return text;

            var replacables = GetReplacables(text);
            var newText = text;

            foreach (var r in replacables)
            {
                var value = GetPropertyValue(data, r.Value);
                newText = newText.Replace(r.Key, value != null ? value.ToString() : String.Empty);
            }

            return newText;
        }

        private Dictionary<string, string> GetReplacables(string text)
        {
            return Regex.Matches(text, "{{.*?}}")
                .Cast<Match>()
                .Select(m => m.Value)
                .Distinct()
                .ToDictionary(c => c, c => c.Replace("{{", "").Replace("}}", ""));
        }

        private object GetPropertyValue(object src, string propName)
        {
            if (propName.Contains(".")) //complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                var parent = GetPropertyValue(src, temp[0]);
                return GetPropertyValue(parent, temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop != null ? prop.GetValue(src, null) : null;
            }
        }
    }
}
