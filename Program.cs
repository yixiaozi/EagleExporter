using System;
using System.Collections;
using System.IO;

string eaglePath = args[0];//@"E:\T7\Photos\个人.library"
string targetPath = args[1];//E:\新建文件夹

//读取当前目录下的db.json文件内容，到json字符串

//遍历E:\T7\Photos\个人.library所有文件文件，不包含.json文件，文件名以_thumbnail结束的文件
List<string> files = Directory.GetFiles(eaglePath, "*.*", SearchOption.AllDirectories).Where(s => !s.EndsWith(".json") && !s.Contains("_thumbnail."));

public void GetFiles()
{
    foreach (string item in files)
    {
    }
}


public class EagleExporterDatebase
{
    public int fileCount { get { return items.Count; } }
    public Int64 fileSize { get {
            //遍历items，累加sizeKB
            Int64 size = 0;
            foreach (var item in items)
            {
                size += item.sizeKB;
            }
            return size;
        }
    }
    public List<FileItem> items { get; set; }

}

public class FileItem 
{
    //文件地址
    public string path { get; set; }
    //文件名
    public string name { get; set; }
    //文件大小（kb）
    public long sizeKB { get; set; }
}