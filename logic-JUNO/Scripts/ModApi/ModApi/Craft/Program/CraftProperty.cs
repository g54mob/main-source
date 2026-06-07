using System;

namespace ModApi.Craft.Program
{
	public class CraftProperty
	{
		public string Category { get; set; }

		public string DisplayName { get; set; }

		public Action<IThreadContext, ExpressionResult, ProgramNode> Getter { get; set; }

		public Action<IThreadContext, ProgramNode> Setter { get; set; }

		public ListItemInfoType ItemType { get; set; }

		public string Tooltip { get; set; }

		public string XmlName { get; set; }
	}
}
