using System.Collections.Generic;
using MoonSharp.Interpreter.Execution.Scopes;
using MoonSharp.Interpreter.Tree.Statements;

namespace MoonSharp.Interpreter.Execution
{
	internal class BuildTimeScope
	{
		private List<BuildTimeScopeFrame> m_Frames;

		private List<IClosureBuilder> m_ClosureBuilders;

		public void PushFunction(IClosureBuilder closureBuilder, bool hasVarArgs)
		{
		}

		public void PushBlock()
		{
		}

		public RuntimeScopeBlock PopBlock()
		{
			return null;
		}

		public RuntimeScopeFrame PopFunction()
		{
			return null;
		}

		public SymbolRef Find(string name)
		{
			return null;
		}

		public SymbolRef CreateGlobalReference(string name)
		{
			return null;
		}

		public void ForceEnvUpValue()
		{
		}

		private SymbolRef CreateUpValue(BuildTimeScope buildTimeScope, SymbolRef symb, int closuredFrame, int currentFrame)
		{
			return null;
		}

		public SymbolRef DefineLocal(string name)
		{
			return null;
		}

		public SymbolRef TryDefineLocal(string name)
		{
			return null;
		}

		public bool CurrentFunctionHasVarArgs()
		{
			return false;
		}

		internal void DefineLabel(LabelStatement label)
		{
		}

		internal void RegisterGoto(GotoStatement gotostat)
		{
		}
	}
}
