namespace MoonSharp.Interpreter.Loaders
{
	public class FileSystemScriptLoader : ScriptLoaderBase
	{
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
