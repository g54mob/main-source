using MoonSharp.Interpreter.Loaders;

namespace MoonSharp.Interpreter.REPL
{
	public class ReplInterpreterScriptLoader : FileSystemScriptLoader
	{
		public override string ResolveModuleName(string modname, Table globalContext)
		{
			return null;
		}
	}
}
