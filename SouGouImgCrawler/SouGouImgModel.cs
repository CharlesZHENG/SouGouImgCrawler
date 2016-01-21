using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SouGouImgCrawler
{
    public class Item
    {
        public int type { get; set; }
        public int cacheIndex { get; set; }
        public string title { get; set; }
        public string markedTitle { get; set; }
        public object url { get; set; }
        public object summary { get; set; }
        public object markedSummary { get; set; }
        public string size { get; set; }
        public object date { get; set; }
        public object encoding { get; set; }
        public int time { get; set; }
        public string docid { get; set; }
        public object debugInfo { get; set; }
        public string thumbUrl { get; set; }
        public string smallThumbUrl { get; set; }
        public string page_url { get; set; }
        public string pic_url { get; set; }
        public object similarUrlFirst { get; set; }
        public object similarUrlSecond { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public object speedrank { get; set; }
        public string summarytype { get; set; }
        public string imgkey1 { get; set; }
        public string imgkey2 { get; set; }
        public string imgcolor { get; set; }
        public string hittag { get; set; }
        public string thumb_width { get; set; }
        public string thumb_height { get; set; }
        public object anchor { get; set; }
        public object alt { get; set; }
        public object title2 { get; set; }
        public string title1 { get; set; }
        public object surr1 { get; set; }
        public string surr2 { get; set; }
        public string summarypc { get; set; }
        public string mf_id { get; set; }
        public string sohu_image { get; set; }
        public string lastmodified { get; set; }
        public object grpdocs { get; set; }
        public object grpdata { get; set; }
        public IList<IList<string>> simdata { get; set; }
        public string pic_url_noredirect { get; set; }
        public string base_url { get; set; }
        public object groupid { get; set; }
        public int groupsize { get; set; }
        public bool easter { get; set; }
        public object easterUrl { get; set; }
        public object keywords { get; set; }
        public string oriTitle { get; set; }
        public string formattedSummary { get; set; }
        public bool showSnapShot { get; set; }
        public bool normalSummary { get; set; }
        public bool fastSummary { get; set; }
        public bool allSummary { get; set; }
        public string uri { get; set; }
    }

    public class SouGouImgModel
    {
        public object isForbiden { get; set; }
        public string uuid { get; set; }
        public string query { get; set; }
        public bool isClusterfilter { get; set; }
        public bool isTinyQcNull { get; set; }
        public object globalQC { get; set; }
        public string refineQuery { get; set; }
        public string refineQueryEncode { get; set; }
        public int maxEnd { get; set; }
        public string tc { get; set; }
        public string ts { get; set; }
        public bool showFiltered { get; set; }
        public int isPornQuery { get; set; }
        public string isQcResult { get; set; }
        public int startIndex { get; set; }
        public int itemsOnPage { get; set; }
        public IList<Item> items { get; set; }
        public string totalItems { get; set; }
    }
}
