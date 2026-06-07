using TMPro;
using UnityEngine;

namespace UI.Xml.Tags
{
	[ElementTagHandler("TMP_Text")]
	public class TextMeshProInputFieldText : TextMeshProTagHandler
	{
		public override string elementGroup => "TextMeshProInputField";

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			TextMeshProUGUI component = base.currentInstanceTransform.GetComponent<TextMeshProUGUI>();
			if (!ElementHasAttribute("color", attributesToApply))
			{
				component.color = new Color(0.2f, 0.2f, 0.2f);
			}
			if (!ElementHasAttribute("fontSize", attributesToApply))
			{
				component.fontSize = 14f;
			}
			if (!ElementHasAttribute("alignment", attributesToApply))
			{
				component.alignment = TextAlignmentOptions.TopLeft;
			}
			if (!ElementHasAttribute("raycastTarget", attributesToApply))
			{
				component.raycastTarget = false;
			}
			base.currentInstanceTransform.localScale = Vector3.one;
			base.currentXmlElement.name = "Text";
		}
	}
}
