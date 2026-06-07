using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class SelectOnLeftAttribute : SelectableAttribute
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
					navigation.selectOnLeft = FindElement(xmlElement, value);
					selectable.navigation = navigation;
				}, xmlElement, forceEvenIfObjectIsInactive: true);
			}
		}
	}
}
