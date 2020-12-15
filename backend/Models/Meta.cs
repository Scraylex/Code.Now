using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Meta
    {
        public string Name { get; set; }
        public string License { get; set; }
        public string Website { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Found { get; set; }

        public Meta(string name, string license, string website, int page, int limit, int found)
        {
            Name = name;
            License = license;
            Website = website;
            Page = page;
            Limit = limit;
            Found = found;
        }
    }
}
