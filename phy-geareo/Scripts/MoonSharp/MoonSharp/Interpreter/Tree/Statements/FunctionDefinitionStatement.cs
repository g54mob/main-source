using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;
using MoonSharp.Interpreter.Tree.Expressions;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class FunctionDefinitionStatement : Statement
	{
		private SymbolRef m_FuncSymbol;

		private SourceRef m_SourceRef;

		private bool m_Local;

		private bool m_IsMethodCallingConvention;

		private string m_MethodName;

		private string m_FriendlyName;

		private List<string> m_TableAccessors;

		private FunctionDefinitionExpression m_FuncDef;

		public FunctionDefinitionStatement(ScriptLoadingContext lcontext, bool local, Token localToken)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		private int SetMethod(ByteCode bc)
		{
			return 0;
		}

		private int SetFunction(ByteCode bc, int numPop)
		{
			return 0;
		}
	}
}
