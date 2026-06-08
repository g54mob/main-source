using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class LabelStatement : Statement
	{
		private List<GotoStatement> m_Gotos;

		private RuntimeScopeBlock m_StackFrame;

		public string Label { get; private set; }

		public int Address { get; private set; }

		public SourceRef SourceRef { get; private set; }

		public Token NameToken { get; private set; }

		internal int DefinedVarsCount { get; private set; }

		internal string LastDefinedVarName { get; private set; }

		public LabelStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		internal void SetDefinedVars(int definedVarsCount, string lastDefinedVarsName)
		{
		}

		internal void RegisterGoto(GotoStatement gotostat)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		internal void SetScope(RuntimeScopeBlock runtimeScopeBlock)
		{
		}
	}
}
