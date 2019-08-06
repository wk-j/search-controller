

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SearchFile.Controllers
{
    public class SearchOptions
    {
        public string Path { set; get; }
        public string Pattern { set; get; }
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpPost]
        public List<string> SearchFile2(SearchOptions options) =>
            new DirectoryInfo(options.Path).GetFiles(options.Pattern).Select(x => x.FullName).ToList();

        public List<string> searchFile(string path, string pattern)
        {
            // Process the list of files found in the directory.
            List<string> result = new List<string>();
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                string[] words = pattern.Split('*');
                words = words[1].Split('"');
                int lenfile = path.Length;
                string fnCheck = fileName.Substring(fileName.Length - (words[0].Length), words[0].Length);
                if (words[0].Equals(fnCheck))
                {
                    result.Add(fileName);
                }
            }
            return result;
        }



    }
}