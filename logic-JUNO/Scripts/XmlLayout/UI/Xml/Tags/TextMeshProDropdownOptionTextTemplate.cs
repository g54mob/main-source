using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Xml.Tags
{
	[ElementTagHandler("TMP_OptionTextTemplate")]
	public class TextMeshProDropdownOptionTextTemplate : TextMeshProTagHandler
	{
		public override string elementGroup => "TextMeshProDropdown";

		public override bool renderElement => false;

		public override Dictionary<string, string> attributes
		{
			get
			{
				Dictionary<string, string> dictionary = base.attributes;
				dictionary.AddIfKeyNotExists("padding", "xmlLayout:rectOffset");
				return dictionary;
			}
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (TextMeshProDropdownTagHandler.CurrentHandler != null)
			{
				attributesToApply.AddIfKeyNotExists("alignment", "Left");
				attributesToApply.AddIfKeyNotExists("dontMatchParentDimensions", "true");
				TMP_Dropdown currentDropdown = TextMeshProDropdownTagHandler.CurrentHandler.CurrentDropdown;
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("TextMeshPro");
				xmlTagHandler.SetInstance(currentDropdown.itemText.rectTransform, base.currentXmlLayoutInstance);
				xmlTagHandler.ApplyAttributes(attributesToApply);
				if (attributesToApply.ContainsKey("padding"))
				{
					RectOffset rectOffset = attributesToApply["padding"].ToRectOffset();
					currentDropdown.itemText.rectTransform.offsetMin = new Vector2(rectOffset.left, rectOffset.bottom);
					currentDropdown.itemText.rectTransform.offsetMax = new Vector2(-rectOffset.right, -rectOffset.top);
				}
				currentDropdown.itemText.GetComponent<XmlElement>().attributes.Merge(attributesToApply);
			}
		}
	}
}
