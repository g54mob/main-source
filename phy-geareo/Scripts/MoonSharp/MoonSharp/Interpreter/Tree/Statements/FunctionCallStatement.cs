using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;
using MoonSharp.Interpreter.Tree.Expressions;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class FunctionCallStatement : Statement
	{
		private FunctionCallExpression m_FunctionCallExpression;

		public FunctionCallStatement(ScriptLoadingContext lcontext, FunctionCallExpression functionCallExpression)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		private void RemoveBreakpointStop(Instruction instruction)
		{
		}
	}
}
