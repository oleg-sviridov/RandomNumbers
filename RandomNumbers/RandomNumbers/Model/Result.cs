using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RandomNumbers.Model
{
    public class Result
    {
        public Guid ResultId { get; set; }
        public long Number { get; set; }

        public Guid MatchId { get; set; }

        public Guid UserId { get; set; }

        [JsonIgnore]
        public virtual Match Match { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
