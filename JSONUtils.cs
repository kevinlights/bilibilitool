/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2020/6/21
 * 时间: 21:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using Newtonsoft.Json;

namespace AnalysisVideo
{
	/// <summary>
	/// Description of JSONUtils.
	/// </summary>
	public class JSONUtils
	{
		public static String Object2Json(object obj) 
		{
			return JsonConvert.SerializeObject(obj);
		}
		
		public static T Json2Object<T>(String json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
