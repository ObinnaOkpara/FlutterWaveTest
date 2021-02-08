using CsvHelper;
using FlutterTest.Interface;
using FlutterTest.Model;
using FlutterTest.ViewModels.MetaData;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.Service
{
    public class MetaDataService : IMetaDataService
    {
        private readonly IWebHostEnvironment _environment;

        public List<MetaData> database = new List<MetaData>();

        public MetaDataService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public bool PostMetaData(MetaDataVM model)
        {
            if (model != null)
            {
                database.Add(new MetaData()
                {
                    MovieId = model.movieId,
                    Duration = model.duration,
                    Language = model.language,
                    ReleaseYear = model.releaseYear,
                    Title = model.title,
                });

                return true;
            }
            return false;
        }
        public List<MetaDataVM> GetMetaDataByMovieId(int movieId)
        {
            var db = StaticMethods.GetMetaDataFromCSV(Path.Combine(_environment.ContentRootPath, "Data/metadata.csv"));

            var allMetaDataForMovie = db.Where(m => 
                m.MovieId == movieId &&
                !string.IsNullOrWhiteSpace(m.Duration) &&
                !string.IsNullOrWhiteSpace(m.Language) &&
                !string.IsNullOrWhiteSpace(m.Title) &&
                m.ReleaseYear > 0
            );

            if (allMetaDataForMovie != null && allMetaDataForMovie.Any() )
            {
                var newestMoviesByLanguage = allMetaDataForMovie.GroupBy(m => m.Language).Select(g => g.OrderBy(m => m.Id).Last());

                return newestMoviesByLanguage.OrderBy(m => m.Language).Select(m => new MetaDataVM()
                {
                    duration = m.Duration,
                    language = m.Language,
                    movieId = m.MovieId,
                    releaseYear = m.ReleaseYear,
                    title = m.Title,
                }).ToList();
            }

            return null;
        }

    }
}
