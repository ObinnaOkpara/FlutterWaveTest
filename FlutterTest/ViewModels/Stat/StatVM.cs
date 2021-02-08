using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.ViewModels.Stat
{
    public class StatVM
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int averageWatchDurationS { get; set; }
        public int watches { get; set; }
        public int releaseYear { get; set; }
    }

}
