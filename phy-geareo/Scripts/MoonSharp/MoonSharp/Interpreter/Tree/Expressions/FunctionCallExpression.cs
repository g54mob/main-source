using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class FunctionCallExpression : Expression
	{
		private List<Expression> m_Arguments;

		private Expression m_Function;

		private string m_Name;

		private string m_DebugErr;

		internal SourceRef SourceRef { get; private set; }

		public FunctionCallExpression(ScriptLoadingContext lcontext, Expression function, Token thisCallName)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}
	}
}
