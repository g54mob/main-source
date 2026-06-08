using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class AssignmentStatement : Statement
	{
		private List<IVariable> m_LValues;

		private List<Expression> m_RValues;

		private SourceRef m_Ref;

		public AssignmentStatement(ScriptLoadingContext lcontext, Token startToken)
			: base(null)
		{
		}

		public AssignmentStatement(ScriptLoadingContext lcontext, Expression firstExpression, Token first)
			: base(null)
		{
		}

		private IVariable CheckVar(ScriptLoadingContext lcontext, Expression firstExpression)
		{
			return null;
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
