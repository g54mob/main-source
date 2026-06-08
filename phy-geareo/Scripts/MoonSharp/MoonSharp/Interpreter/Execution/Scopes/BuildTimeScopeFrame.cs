using MoonSharp.Interpreter.Tree.Statements;

namespace MoonSharp.Interpreter.Execution.Scopes
{
	internal class BuildTimeScopeFrame
	{
		private BuildTimeScopeBlock m_ScopeTreeRoot;

		private BuildTimeScopeBlock m_ScopeTreeHead;

		private RuntimeScopeFrame m_ScopeFrame;

		public bool HasVarArgs { get; private set; }

		internal BuildTimeScopeFrame(bool hasVarArgs)
		{
		}

		internal void PushBlock()
		{
		}

		internal RuntimeScopeBlock PopBlock()
		{
			return null;
		}

		internal RuntimeScopeFrame GetRuntimeFrameData()
		{
			return null;
		}

		internal SymbolRef Find(string name)
		{
			return null;
		}

		internal SymbolRef DefineLocal(string name)
		{
			return null;
		}

		internal SymbolRef TryDefineLocal(string name)
		{
			return null;
		}

		internal void ResolveLRefs()
		{
		}

		internal int AllocVar(SymbolRef var)
		{
			return 0;
		}

		internal int GetPosForNextVar()
		{
			return 0;
		}

		internal void DefineLabel(LabelStatement label)
		{
		}

		internal void RegisterGoto(GotoStatement gotostat)
		{
		}
	}
}
