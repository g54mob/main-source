using System;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class TransitionAttribute : TransitionBaseAttribute
	{
		public override string ValueDataType => "None,ColorTint,SpriteSwap,Animation";

		public override string DefaultValue => "ColorTint";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Selectable component = xmlElement.GetComponent<Selectable>();
			if (!(component == null))
			{
				component.transition = (Selectable.Transition)Enum.Parse(typeof(Selectable.Transition), value);
			}
		}
	}
}
