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
using Windows.UI.Xaml.Controls;

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
           
            //var timestamp = DateTime.Now.Ticks.ToString();
            //var hash = CreatHash(timestamp);
            //构建我的url
            string url = String.Format("http://route.showapi.com/255-1?showapi_appid=38562&type=41&title=&page=&showapi_sign=bd6f94f1133d4055936934ba4e21ea76");

            try { 
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            //进行反序列化
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var result=(RootObject)serializer.ReadObject(ms);
            return result;
            }
            catch
            {
                displayNoWifiDialog();
                return null;
            }
        }
        //建立哈希表
        //private static string CreatHash(string timestamp)
        //{
            
        //    var tobehashed = timestamp;
        //    var hashedmassage = ComputeMD5(tobehashed);
        //    return hashedmassage;
                 
        //}
        ////这个是。。。不太清楚
        //private static string ComputeMD5(string str)
        //{
        //    var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
        //    IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
        //    var hashed = alg.HashData(buff);
        //    var res = CryptographicBuffer.EncodeToHexString(hashed);
        //    return res;       
        //}
        //无网络测试
        private static async void displayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "网络异常",
                Content = "请检查网络是否连接",
                PrimaryButtonText = "确定"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }
    }
    
}
