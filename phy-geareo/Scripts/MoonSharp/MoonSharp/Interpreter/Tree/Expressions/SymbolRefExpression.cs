using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class SymbolRefExpression : Expression, IVariable
	{
		private SymbolRef m_Ref;

		private string m_VarName;

		public SymbolRefExpression(Token T, ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public SymbolRefExpression(ScriptLoadingContext lcontext, SymbolRef refr)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		public void CompileAssignment(ByteCode bc, int stackofs, int tupleidx)
		{
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}

		public override SymbolRef FindDynamic(ScriptExecutionContext context)
		{
			return null;
		}
	}
}
