using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class PartModifierDesignerHeaderAttribute : Attribute
	{
		public bool AllowInDemo { get; set; } = true;

		public string HeaderText { get; private set; }

		public PartModifierDesignerHeaderAttribute(string headerText)
		{
			HeaderText = headerText;
		}
	}
}
