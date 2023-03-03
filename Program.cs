using System;
using System.Collections;
using System.Security.Cryptography;

string eaglePath = @"E:\T7\Photos\个人.library";
string targetPath = @"G:\图库";
//如果没有参数则输入
if (args.Length==0)
{
    Console.Write("请输入Eagle地址：");
    eaglePath = Console.ReadLine();
    Console.Write("请输入目标地址：");
    targetPath = Console.ReadLine();

}
else
{
    eaglePath = args[0];
    targetPath = args[1];
}
//如果目标文件夹没有则创建
if (!Directory.Exists(targetPath))
{
    Directory.CreateDirectory(targetPath);
}

//读取当前目录下的db.json文件内容，到json字符串

//遍历E:\T7\Photos\个人.library所有文件文件，不包含.json文件，文件名以_thumbnail结束的文件
var files = Directory.GetFiles(eaglePath, "*.*", SearchOption.AllDirectories);
//将文件保存到目标文件夹，重命名文件为文件所在的文件夹的名字，以文件的创建时间的年月日的结构存储
foreach (var file in files)
{
    //获取文件所在的文件夹的名字
    var dirName = Path.GetFileName(Path.GetDirectoryName(file));
    //去掉字符.info
    dirName = dirName.Replace(".info", "");
    string folder = "\\" + File.GetCreationTime(file).Year + "\\" + File.GetCreationTime(file).Month + "\\" + File.GetCreationTime(file).Day;
    if (!Directory.Exists(targetPath+folder))
    {
        //创建目录
        Directory.CreateDirectory(targetPath+folder);
    }
    var targetFile = Path.Combine(targetPath+ folder, dirName+Path.GetExtension(file));
    
    if (!File.Exists(targetFile)&& !file.EndsWith(".json")&& !file.Contains("_thumbnail."))
    {
        //复制文件并保持创建时间，修改时间属性一样
        File.Copy(file, targetFile,true);
        Console.WriteLine(targetFile);
    }
}