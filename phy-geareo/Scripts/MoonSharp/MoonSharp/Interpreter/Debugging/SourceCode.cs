using System.Collections.Generic;

namespace MoonSharp.Interpreter.Debugging
{
	public class SourceCode : IScriptPrivateResource
	{
		public string Name { get; private set; }

		public string Code { get; private set; }

		public string[] Lines { get; private set; }

		public Script OwnerScript { get; private set; }

		public int SourceID { get; private set; }

		internal List<SourceRef> Refs { get; private set; }

		internal SourceCode(string name, string code, int sourceID, Script ownerScript)
		{
		}

		public string GetCodeSnippet(SourceRef sourceCodeRef)
		{
			return null;
		}

		private int AdjustStrIndex(string str, int loc)
		{
			return 0;
		}
	}
}
