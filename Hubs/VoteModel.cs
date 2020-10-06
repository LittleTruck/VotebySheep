using System;
using System.Collections.Generic;

namespace SignalRChat.Models
{
    public class VoteModel
    {
        public int id { get; set; }
        public string voteName { get; set; }
        public string creator { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Dictionary<string, int> voteSelect { get; set; }
    }
}