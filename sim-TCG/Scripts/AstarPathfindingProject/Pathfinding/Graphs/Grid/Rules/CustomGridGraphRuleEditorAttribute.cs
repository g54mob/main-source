using System;

namespace Pathfinding.Graphs.Grid.Rules
{
	public class CustomGridGraphRuleEditorAttribute : Attribute
	{
		public Type type;

		public string name;

		public CustomGridGraphRuleEditorAttribute(Type type, string name)
		{
			this.type = type;
			this.name = name;
		}
	}
}
