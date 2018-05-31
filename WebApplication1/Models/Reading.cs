using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class Reading
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public IEnumerable<string> measurments { get; set; }
    }
}