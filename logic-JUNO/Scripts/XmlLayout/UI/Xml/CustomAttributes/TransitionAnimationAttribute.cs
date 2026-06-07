using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public abstract class TransitionAnimationAttribute : TransitionBaseAttribute
	{
		public override bool KeepOriginalTag => true;

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Selectable component = xmlElement.GetComponent<Selectable>();
			if (!(component == null))
			{
				component.animationTriggers = new AnimationTriggers
				{
					normalTrigger = (elementAttributes.GetValue("normalTrigger") ?? "Normal"),
					highlightedTrigger = (elementAttributes.GetValue("highlightedTrigger") ?? "Highlighted"),
					pressedTrigger = (elementAttributes.GetValue("pressedTrigger") ?? "Pressed"),
					disabledTrigger = (elementAttributes.GetValue("disabledTrigger") ?? "Disabled")
				};
			}
		}
	}
}
