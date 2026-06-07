using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class VariableReference : Expression
	{
		public List<string> path;

		public bool isConstantReference;

		public bool isListItemReference;

		private Ink.Runtime.VariableReference _runtimeVarRef;

		public string name => null;

		public Ink.Runtime.VariableReference runtimeVarRef => null;

		public VariableReference(List<string> path)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
