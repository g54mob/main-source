using System.Collections.Generic;
using MoonSharp.Interpreter.Tree.Statements;

namespace MoonSharp.Interpreter.Execution.Scopes
{
	internal class BuildTimeScopeBlock
	{
		private Dictionary<string, SymbolRef> m_DefinedNames;

		private List<GotoStatement> m_PendingGotos;

		private Dictionary<string, LabelStatement> m_LocalLabels;

		private string m_LastDefinedName;

		internal BuildTimeScopeBlock Parent { get; private set; }

		internal List<BuildTimeScopeBlock> ChildNodes { get; private set; }

		internal RuntimeScopeBlock ScopeBlock { get; private set; }

		internal void Rename(string name)
		{
		}

		internal BuildTimeScopeBlock(BuildTimeScopeBlock parent)
		{
		}

		internal BuildTimeScopeBlock AddChild()
		{
			return null;
		}

		internal SymbolRef Find(string name)
		{
			return null;
		}

		internal SymbolRef Define(string name)
		{
			return null;
		}

		internal int ResolveLRefs(BuildTimeScopeFrame buildTimeScopeFrame)
		{
			return 0;
		}

		internal void DefineLabel(LabelStatement label)
		{
		}

		internal void RegisterGoto(GotoStatement gotostat)
		{
		}

		internal void ResolveGotos()
		{
		}
	}
}
