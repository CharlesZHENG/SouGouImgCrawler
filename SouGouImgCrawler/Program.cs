using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SouGouImgCrawler
{
    class Program
    {
        public static string ThreadManager { get; private set; }

        static void Main(string[] args)
        {
            //List<Thread> threads = new List<Thread>();
            while (true)
            {
                Console.WriteLine("请输入关键词：");
                String keyWord = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(keyWord.Trim()))
                {
                    //           
                    Thread t = new Thread(()=> {
                        #region 抓取任务开始
                        String start = "";
                        string taskKeyWord = keyWord;
                        HttpHelper http = new HttpHelper();
                        //每一次抓取
                        //大于totalItems/48时停止
                        Int32 count = 1;
                        Random random = new Random();
                        while (true)
                        {
                            start = (48 * count).ToString();
                            HttpItem item = new HttpItem()
                            {
                                URL = "http://pic.sogou.com/pics?query=" + taskKeyWord + "&mood=0&picformat=0&mode=1&di=0&clusterfilter=off&p=40230504&dp=1&start=" + start + "&reqType=ajax&tn=0&reqFrom=result",//URL     必需项    
                                Method = "get",//URL     可选项 默认为Get   
                                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写                                   
                                Referer = "",//来源URL     可选项   
                                Postdata = "",//Post数据     可选项GET时不需要写   
                                Timeout = 100000,//连接超时时间     可选项默认为100000    
                                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                                ContentType = "text/html",//返回类型    可选项有默认值   
                                Allowautoredirect = false,//是否根据301跳转     可选项   
                                                          //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                                                          //Connectionlimit = 1024,//最大连接数     可选项 默认为1024                            
                                ResultType = ResultType.String
                            };
                            HttpResult result = http.GetHtml(item);
                            string html = result.Html;
                            string cookie = result.Cookie;
                            //Console.WriteLine("【" + Thread.CurrentThread.ManagedThreadId + "】-" + html);
                            //解析结果，得到停止条件                            
                            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                            SouGouImgModel model = js.Deserialize<SouGouImgModel>(html);
                        
                            if (Convert.ToInt32(start)>=Convert.ToInt32(model.totalItems.Replace(",","")))
                            {
                                Console.WriteLine("结束时间：【" + DateTime.Now + "】-任务关键字：" + taskKeyWord);
                                break;
                            }
                            //下一轮                
                            int span = random.Next(3000, 10000);
                            Thread.Sleep(span);
                            //Console.WriteLine(count);
                            count++;

                        } 
                        #endregion
                        
                    });
                    //threads.Add(t);
                    t.Start();
                    Console.WriteLine("开始时间：【"+DateTime.Now+"】-任务关键字："+keyWord);
                    
                }
            }
            
        }


    }
}
