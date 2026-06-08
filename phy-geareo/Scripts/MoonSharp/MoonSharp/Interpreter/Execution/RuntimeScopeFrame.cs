using System.Collections.Generic;

namespace MoonSharp.Interpreter.Execution
{
	internal class RuntimeScopeFrame
	{
		public List<SymbolRef> DebugSymbols { get; private set; }

		public int Count => 0;

		public int ToFirstBlock { get; internal set; }

		public override string ToString()
		{
			return null;
		}
	}
}
