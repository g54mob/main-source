using System.Collections.Generic;

namespace UI.Xml.CustomAttributes
{
	public abstract class TransitionBaseAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override bool RestrictToPermittedElementsOnly => true;

		public override List<string> PermittedElements => new List<string> { "Button", "InputField", "Slider", "Toggle", "ToggleButton", "Dropdown" };
	}
}
