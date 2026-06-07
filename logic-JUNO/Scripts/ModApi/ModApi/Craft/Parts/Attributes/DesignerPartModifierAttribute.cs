using System;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class DesignerPartModifierAttribute : Attribute
	{
		public Type DesignerPartPropertiesType { get; set; }

		public bool HeaderCollapsed { get; set; }

		public string HeaderText { get; private set; }

		public int PanelOrder { get; set; }

		public DesignerPartModifierAttribute(string headerText)
		{
			HeaderText = headerText;
			PanelOrder = 1000;
		}

		public DesignerPartModifierAttribute(string headerText, Type designerPartPropertiesType)
		{
			HeaderText = headerText;
			DesignerPartPropertiesType = designerPartPropertiesType;
			PanelOrder = 1000;
		}
	}
}
