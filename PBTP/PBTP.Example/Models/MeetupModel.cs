using System;

namespace PBTP.Example.Models
{
    public class MeetupModel
    {
        public string Name { get; set; }

        public DateTime StartsOn { get; set; }

        public MeetupLocationModel Location { get; set; }
    }
}
