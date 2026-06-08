using System.IO;

namespace MoonSharp.Interpreter.CoreLib.IO
{
	internal class StandardIOFileUserDataBase : StreamFileUserDataBase
	{
		protected override string Close()
		{
			return null;
		}

		public static StandardIOFileUserDataBase CreateInputStream(Stream stream)
		{
			return null;
		}

		public static StandardIOFileUserDataBase CreateOutputStream(Stream stream)
		{
			return null;
		}
	}
}
