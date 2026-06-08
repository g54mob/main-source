namespace MoonSharp.Interpreter.Loaders
{
	internal class InvalidScriptLoader : IScriptLoader
	{
		private string m_Error;

		internal InvalidScriptLoader(string frameworkname)
		{
		}

		public object LoadFile(string file, Table globalContext)
		{
			return null;
		}

		public string ResolveFileName(string filename, Table globalContext)
		{
			return null;
		}

		public string ResolveModuleName(string modname, Table globalContext)
		{
			return null;
		}
	}
}
