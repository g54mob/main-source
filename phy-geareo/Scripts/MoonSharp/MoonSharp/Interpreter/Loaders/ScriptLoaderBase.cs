namespace MoonSharp.Interpreter.Loaders
{
	public abstract class ScriptLoaderBase : IScriptLoader
	{
		public string[] ModulePaths { get; set; }

		public bool IgnoreLuaPathGlobal { get; set; }

		public abstract bool ScriptFileExists(string name);

		public abstract object LoadFile(string file, Table globalContext);

		protected virtual string ResolveModuleName(string modname, string[] paths)
		{
			return null;
		}

		public virtual string ResolveModuleName(string modname, Table globalContext)
		{
			return null;
		}

		public static string[] UnpackStringPaths(string str)
		{
			return null;
		}

		public static string[] GetDefaultEnvironmentPaths()
		{
			return null;
		}

		public virtual string ResolveFileName(string filename, Table globalContext)
		{
			return null;
		}
	}
}
