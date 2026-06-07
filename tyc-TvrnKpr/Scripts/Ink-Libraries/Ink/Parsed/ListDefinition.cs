using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class ListDefinition : Object
	{
		public string name;

		public List<ListElementDefinition> itemDefinitions;

		public VariableAssignment variableAssignment;

		private Dictionary<string, ListElementDefinition> _elementsByName;

		public Ink.Runtime.ListDefinition runtimeListDefinition => null;

		public override string typeName => null;

		public ListElementDefinition ItemNamed(string itemName)
		{
			return null;
		}

		public ListDefinition(List<ListElementDefinition> elements)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
