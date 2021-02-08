using FlutterTest.ViewModels.Stat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.Interface
{
    public interface IMovieService
    {
        List<StatVM> GetMovieStats();
    }
}
