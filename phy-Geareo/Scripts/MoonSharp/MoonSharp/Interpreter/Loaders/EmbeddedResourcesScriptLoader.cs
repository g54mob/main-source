using System.Collections.Generic;
using System.Reflection;

namespace MoonSharp.Interpreter.Loaders
{
	public class EmbeddedResourcesScriptLoader : ScriptLoaderBase
	{
		private Assembly m_ResourceAssembly;

		private HashSet<string> m_ResourceNames;

		private string m_Namespace;

		public EmbeddedResourcesScriptLoader(Assembly resourceAssembly = null)
		{
		}

		private string FileNameToResource(string file)
		{
			return null;
		}

		public override bool ScriptFileExists(string name)
		{
			return false;
		}

		public override object LoadFile(string file, Table globalContext)
		{
			return null;
		}
	}
}
