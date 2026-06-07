using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class SelectOnRightAttribute : SelectableAttribute
	{
		public override bool UsesApplyMethod => true;

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			Selectable selectable = xmlElement.GetComponent<Selectable>();
			if (selectable != null)
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					Navigation navigation = selectable.navigation;
					navigation.selectOnRight = FindElement(xmlElement, value);
					selectable.navigation = navigation;
				}, xmlElement, forceEvenIfObjectIsInactive: true);
			}
		}
	}
}
