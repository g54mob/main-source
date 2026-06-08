using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class IndexExpression : Expression, IVariable
	{
		private Expression m_BaseExp;

		private Expression m_IndexExp;

		private string m_Name;

		public IndexExpression(Expression baseExp, Expression indexExp, ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public IndexExpression(Expression baseExp, string name, ScriptLoadingContext lcontext)
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
	}
}
