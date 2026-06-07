using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MoonSharp.Interpreter.Loaders
{
	public class UnityAssetsScriptLoader : ScriptLoaderBase
	{
		public const string DEFAULT_PATH = "MoonSharp/Scripts";

		private Dictionary<string, string> m_Resources = new Dictionary<string, string>();

		public UnityAssetsScriptLoader(string assetsPath = null)
		{
			assetsPath = assetsPath ?? "MoonSharp/Scripts";
			LoadResourcesWithReflection(assetsPath);
		}

		private void LoadResourcesWithReflection(string assetsPath)
		{
			try
			{
				Type type = Type.GetType("UnityEngine.Resources, UnityEngine");
				Type type2 = Type.GetType("UnityEngine.TextAsset, UnityEngine");
				MethodInfo getMethod = type2.GetProperty("name").GetGetMethod();
				MethodInfo getMethod2 = type2.GetProperty("text").GetGetMethod();
				MethodInfo method = type.GetMethod("LoadAll", new Type[2]
				{
					typeof(string),
					typeof(Type)
				});
				Array array = (Array)method.Invoke(null, new object[2] { assetsPath, type2 });
				for (int i = 0; i < array.Length; i++)
				{
					object value = array.GetValue(i);
					string key = getMethod.Invoke(value, null) as string;
					string value2 = getMethod2.Invoke(value, null) as string;
					m_Resources.Add(key, value2);
				}
			}
			catch (Exception)
			{
			}
		}

		private string GetFileName(string filename)
		{
			int num = Math.Max(filename.LastIndexOf('\\'), filename.LastIndexOf('/'));
			if (num > 0)
			{
				filename = filename.Substring(num + 1);
			}
			return filename;
		}

		public override object LoadFile(string file, Table globalContext)
		{
			file = GetFileName(file);
			if (m_Resources.ContainsKey(file))
			{
				return m_Resources[file];
			}
			string message = string.Format("Cannot load script '{0}'. By default, scripts should be .txt files placed under a Assets/Resources/{1} directory.\r\nIf you want scripts to be put in another directory or another way, use a custom instance of UnityAssetsScriptLoader or implement\r\nyour own IScriptLoader (possibly extending ScriptLoaderBase).", file, "MoonSharp/Scripts");
			throw new Exception(message);
		}

		public override bool ScriptFileExists(string file)
		{
			file = GetFileName(file);
			return m_Resources.ContainsKey(file);
		}

		public string[] GetLoadedScripts()
		{
			return m_Resources.Keys.ToArray();
		}
	}
}
