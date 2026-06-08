using System.Collections.Generic;

namespace MoonSharp.Interpreter.Loaders
{
	public class UnityAssetsScriptLoader : ScriptLoaderBase
	{
		private Dictionary<string, string> m_Resources;

		public const string DEFAULT_PATH = "MoonSharp/Scripts";

		public UnityAssetsScriptLoader(string assetsPath = null)
		{
		}

		public UnityAssetsScriptLoader(Dictionary<string, string> scriptToCodeMap)
		{
		}

		private void LoadResourcesWithReflection(string assetsPath)
		{
		}

		private string GetFileName(string filename)
		{
			return null;
		}

		public override object LoadFile(string file, Table globalContext)
		{
			return null;
		}

		public override bool ScriptFileExists(string file)
		{
			return false;
		}

		public string[] GetLoadedScripts()
		{
			return null;
		}
	}
}
