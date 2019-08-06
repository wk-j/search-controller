

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SearchFile.Controllers {
    [Route("api/[controller]/[action]")]
    public class SearchController: ControllerBase {

        public string A(){
            return "A";
        }
        public List<string> searchFile(string path,string pattern){
            // Process the list of files found in the directory.
            List<string> result = new List<string>();
            string [] fileEntries = Directory.GetFiles(path);
            foreach(string fileName in fileEntries){
                string[] words = pattern.Split('*');
                words = words[1].Split('"');
                int lenfile = path.Length;
                string fnCheck = fileName.Substring(fileName.Length-(words[0].Length),words[0].Length);
                if(words[0].Equals(fnCheck)){
                    result.Add(fileName);
                }
            }
            return result;
        }

        

    }
}