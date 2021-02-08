using FlutterTest.ViewModels.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.Interface
{
    public interface IMetaDataService
    {
        bool PostMetaData(MetaDataVM model);
        List<MetaDataVM> GetMetaDataByMovieId(int movieId);
    }
}
