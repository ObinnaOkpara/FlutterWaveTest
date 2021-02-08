using CsvHelper;
using FlutterTest.Interface;
using FlutterTest.Model;
using FlutterTest.ViewModels.Stat;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.Service
{
    public class MovieService: IMovieService
    {
        private readonly IWebHostEnvironment _environment;
        public MovieService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public List<StatVM> GetMovieStats()
        {
            var allStats = StaticMethods.GetStatFromCSV(Path.Combine(_environment.ContentRootPath, "Data/stats.csv"));
            var metaDatas = StaticMethods.GetMetaDataFromCSV(Path.Combine(_environment.ContentRootPath, "Data/metadata.csv"));


            var uniqueMovies = metaDatas.GroupBy(m => m.MovieId).Select(g => g.First());

            var result = new List<StatVM>();

            var statsGroupedByMovieId = allStats.GroupBy(m => m.movieId).ToDictionary(group => group.Key, group=>group.ToList());

            foreach (var movieMeta in uniqueMovies)
            {
                var statForMovie = new List<Stat>();

                statForMovie = statsGroupedByMovieId[movieMeta.MovieId];

                result.Add(new StatVM()
                {
                    movieId = movieMeta.MovieId,
                    releaseYear = movieMeta.ReleaseYear,
                    title = movieMeta.Title,
                    watches = statForMovie.Count,
                    averageWatchDurationS = (int)(statForMovie.Average(m=> m.watchDurationMs)/1000)
                });
            }

            return result.OrderByDescending(m => m.watches).ThenByDescending(r => r.releaseYear).ToList();
        }
    }
}
