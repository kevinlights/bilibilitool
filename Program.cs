/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/6/21
 * 时间: 22:09
 * 
 */
using System;
using System.IO;
using System.Text;

namespace AnalysisVideo
{
	class Program
	{
		public static void Main(string[] args)
		{
			String path = AppDomain.CurrentDomain.BaseDirectory;
			DirectoryInfo root = new DirectoryInfo(path);
			String output = Path.Combine(path, "视频列表.txt");
			StringBuilder content = new StringBuilder(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"));
			foreach (DirectoryInfo group in root.GetDirectories()) {
				String videoName = "";
			
				// 获取视频名称
				foreach (FileInfo fi in group.GetFiles()) {
					if (fi.Name.Equals("info.json")) {
						InfoJson info = JSONUtils.Json2Object<InfoJson>(fi.OpenText().ReadLine());
						videoName = group.Name + "\t" + info.title;
						break;
					}
				}
				
				Appendln(content, "");
				Appendln(content, videoName);
				Appendln(content, "");
				// 获取各视频目录
				foreach (DirectoryInfo vd in group.GetDirectories()) {
					foreach (FileInfo fi in vd.GetFiles()) {
						if (fi.Name.Equals("info.json")) {
							InfoJson info = JSONUtils.Json2Object<InfoJson>(fi.OpenText().ReadLine());
							Appendln(content, vd.Name + "\t" + info.title);
							break;
						}
					}
				}
				
				Appendln(content, "=======================================================");
			}
			Console.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + "输出文件：" + output);
			WriteFile(output, content.ToString());
		}
		
		private static void Appendln(StringBuilder sb, String append)
		{
			sb.Append(append);
			sb.Append("\r\n");
		}
		
		private static void WriteFile(String filePath, String content)
		{
			using (StreamWriter sw = new StreamWriter(filePath)) {
				sw.Write(content);
			}
		}
	}
}