using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public abstract class SpriteStateAttribute : TransitionBaseAttribute
	{
		public override bool KeepOriginalTag => true;

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Selectable component = xmlElement.GetComponent<Selectable>();
			if (!(component == null))
			{
				component.spriteState = new SpriteState
				{
					disabledSprite = elementAttributes.GetValue("disabledSprite").ToSprite(),
					highlightedSprite = elementAttributes.GetValue("highlightedSprite").ToSprite(),
					pressedSprite = elementAttributes.GetValue("pressedSprite").ToSprite()
				};
			}
		}
	}
}
