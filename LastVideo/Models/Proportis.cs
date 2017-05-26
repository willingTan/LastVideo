using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastVideo.Models
{
    //[DataContract]
    public class Contentlist
    {
        //public string Sex { get; set; }
        //public string ID { get; set; }
        //public string Age { get; set; }
        //public string Name { get; set; }
        
        public string text { get; set; }

        public string hate { get; set; }

        public string videotime { get; set; }

        public string voicetime { get; set; }

        public string weixin_url { get; set; }

        public string profile_image { get; set; }

        public string width { get; set; }

        public string voiceuri { get; set; }

        public string type { get; set; }

        public string id { get; set; }

        public string love { get; set; }

        public string height { get; set; }

        public string video_uri { get; set; }

        public string voicelength { get; set; }

        public string name { get; set; }

        public string create_time { get; set; }

    }
    //[DataContract]
    public class Pagebean
    {
        //[DataMember]
        public int allPages { get; set; }

        //[DataMember]
        public List<Contentlist> contentlist { get; set; }

        public Contentlist myneed { get; set; }   

        //[DataMember]
        public int currentPage { get; set; }

        //[DataMember]
        public int allNum { get; set; }

        //[DataMember]
        public int maxResult { get; set; }
    }

    //[DataContract]
    public class ShowapiResBody
    {
        //[DataMember]
        public int ret_code { get; set; }

        //[DataMember]
        public Pagebean pagebean { get; set; }
    }

    //[DataContract]
    public class RootObject
    {
        //[DataMember]
        public int showapi_res_code { get; set; }

        //[DataMember]
        public string showapi_res_error { get; set; }

        //[DataMember]
        public ShowapiResBody showapi_res_body { get; set; }
    }
}
