using TMPro;

namespace UI.Xml.Tags
{
	[ElementTagHandler("TMP_DropdownLabel")]
	public class TextMeshProDropdownLabel : TextMeshProTagHandler
	{
		public override string elementGroup => "TextMeshProDropdown";

		public override bool renderElement => false;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (TextMeshProDropdownTagHandler.CurrentHandler != null)
			{
				attributesToApply.AddIfKeyNotExists("alignment", "Left");
				attributesToApply.AddIfKeyNotExists("dontMatchParentDimensions", "true");
				TMP_Dropdown currentDropdown = TextMeshProDropdownTagHandler.CurrentHandler.CurrentDropdown;
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("TextMeshPro");
				xmlTagHandler.SetInstance(currentDropdown.captionText.rectTransform, base.currentXmlLayoutInstance);
				xmlTagHandler.ApplyAttributes(attributesToApply);
				currentDropdown.captionText.GetComponent<XmlElement>().attributes.Merge(attributesToApply);
			}
		}
	}
}
