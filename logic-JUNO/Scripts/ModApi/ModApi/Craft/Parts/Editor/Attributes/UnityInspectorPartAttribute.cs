using System;

namespace ModApi.Craft.Parts.Editor.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class UnityInspectorPartAttribute : Attribute
	{
		public string Header { get; set; }

		public string HeaderTooltip { get; set; }

		public string Label { get; set; }

		public int Order { get; }

		public int Space { get; set; }

		public UnityInspectorPartAttribute(int order)
		{
			Order = order;
		}
	}
}
