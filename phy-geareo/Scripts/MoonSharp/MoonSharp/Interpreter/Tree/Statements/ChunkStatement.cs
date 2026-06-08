using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class ChunkStatement : Statement, IClosureBuilder
	{
		private Statement m_Block;

		private RuntimeScopeFrame m_StackFrame;

		private SymbolRef m_Env;

		private SymbolRef m_VarArgs;

		public ChunkStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		public SymbolRef CreateUpvalue(BuildTimeScope scope, SymbolRef symbol)
		{
			return null;
		}
	}
}
