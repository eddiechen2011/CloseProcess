using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctMonitor
{
    class TxtFiles
    {
        public string path;

        public TxtFiles(string epath)
        {
            path = epath;
        }
        public TxtFiles()
        {

        }
        /// <summary>
        /// 读txt文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>txt文件内容</returns>
        public List<string> Read(string epath)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(epath, Encoding.Default);
                List<string> fileBuf = new List<string>();
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    fileBuf.Add(line);
                    Console.WriteLine(line.ToString());
                }
                sr.Close();//关闭读取流文件
                return fileBuf;
            }
            catch (Exception e)
            {
                //sr.Close();//关闭读取流文件
                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+"读取"+path+"文件出错：\r\n"+e.ToString());
                //return null;
                throw e;
            }
        }
        public List<string> Read()
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(path, Encoding.UTF8);
                List<string> fileBuf = new List<string>();
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    fileBuf.Add(line);
                    Console.WriteLine(line.ToString());
                }
                sr.Close();//关闭读取流文件
                return fileBuf;
            }
            catch (Exception e)
            {
                //sr.Close();//关闭读取流文件
                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+"读取"+path+"文件出错：\r\n"+e.ToString());
                //return null;
                throw e;
            }
        }
        /// <summary>
        /// 写数据到txt
        /// </summary>
        /// <param name="path">写入的文件路劲</param>
        /// <param name="buff">写入的内容</param>
        public void Write(string epath, List<string> buff)
        {
            try
            {
                FileStream fs = new FileStream(epath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string line in buff)
                {
                    //开始写入
                    sw.WriteLine(line);
                }
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Write(List<string> buff)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Append,FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string line in buff)
                {
                    //开始写入
                    sw.WriteLine(line);
                }
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
