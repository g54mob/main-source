using System.Collections.Generic;

namespace MoonSharp.Interpreter.Execution
{
	internal class ClosureContext : List<DynValue>
	{
		public string[] Symbols { get; private set; }

		internal ClosureContext(SymbolRef[] symbols, IEnumerable<DynValue> values)
		{
		}

		internal ClosureContext()
		{
		}
	}
}
