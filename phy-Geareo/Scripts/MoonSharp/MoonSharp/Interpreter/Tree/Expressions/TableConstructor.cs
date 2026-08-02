using System.Collections.Generic;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class TableConstructor : Expression
	{
		private bool m_Shared;

		private List<Expression> m_PositionalValues;

		private List<KeyValuePair<Expression, Expression>> m_CtorArgs;

		public TableConstructor(ScriptLoadingContext lcontext, bool shared)
			: base(null)
		{
		}

		private void MapField(ScriptLoadingContext lcontext)
		{
		}

		private void StructField(ScriptLoadingContext lcontext)
		{
		}

		private void ArrayField(ScriptLoadingContext lcontext)
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
