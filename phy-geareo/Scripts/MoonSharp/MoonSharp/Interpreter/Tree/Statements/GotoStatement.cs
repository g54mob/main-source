using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class GotoStatement : Statement
	{
		private Instruction m_Jump;

		private int m_LabelAddress;

		internal SourceRef SourceRef { get; private set; }

		internal Token GotoToken { get; private set; }

		public string Label { get; private set; }

		internal int DefinedVarsCount { get; private set; }

		internal string LastDefinedVarName { get; private set; }

		public GotoStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		internal void SetDefinedVars(int definedVarsCount, string lastDefinedVarsName)
		{
		}

		internal void SetAddress(int labelAddress)
		{
		}
	}
}
