using System;

namespace SPACE_UTIL
{
	public static class NSJsonExtensions
	{
#if NSJson
		public static string ToNSJson(this object obj, bool pretify = false)
		{
			var fmt = pretify ? 
				Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
			var settings = new Newtonsoft.Json.JsonSerializerSettings
			{
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
				MaxDepth = 10,
			};
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj, fmt, settings);
		}
#else
		// stub — compiles fine, does nothing when Newtonsoft is removed
		public static string ToNSJson(this object obj, bool pretify = false)
		{
			UnityEngine.Debug.Log("NS Json not installed using custom .ToJson(pretify)");
			return obj.ToJson(pretify: pretify);
		}
#endif
	}
}