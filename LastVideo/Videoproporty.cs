using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using LastVideo.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;
using Windows.Foundation;

namespace LastVideo
{
    class Videoproporty: ObservableCollection<Contentlist>, ISupportIncrementalLoading

    {
        public bool HasMoreItems
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public static async Task Content(ObservableCollection<Contentlist> Contents)//异步方法
        {
            var contentlist = await GetVideoContent();
            var contentli = contentlist.showapi_res_body.pagebean.contentlist;

            foreach (var container in contentli)
            {
                if(container.profile_image!=null)
                {
                    Contents.Add(container);
                }
            }
        }

        public async static Task<RootObject> GetVideoContent()//异步方法
        {
           
            var timestamp = DateTime.Now.Ticks.ToString();
            var hash = CreatHash(timestamp);
            
            string url = String.Format("http://route.showapi.com/255-1?showapi_appid=38562&type=41&title=&page=&showapi_sign=bd6f94f1133d4055936934ba4e21ea76&ts={0}&hash={1}",timestamp,hash);

            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var result=(RootObject)serializer.ReadObject(ms);
            return result;
        }

        private static string CreatHash(string timestamp)
        {
            
            var tobehashed = timestamp;
            var hashedmassage = ComputeMD5(tobehashed);
            return hashedmassage;
                 
        }

        private static string ComputeMD5(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;       
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }
    }
    
}
