using System.Collections.Generic;
using TMPro;

namespace UI.Xml.Tags
{
	[ElementTagHandler("TMP_Option")]
	public class TextMeshProDropdownOption : ElementTagHandler
	{
		public override bool isCustomElement => true;

		public override string prefabPath => null;

		public override string elementGroup => "TextMeshProDropdown";

		public override bool renderElement => false;

		public override string extension => "blank";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "selected", "xs:boolean" },
			{ "text", "xs:string" }
		};

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (TextMeshProDropdownTagHandler.CurrentHandler != null)
			{
				string text = (ElementHasAttribute("text", attributesToApply) ? attributesToApply.GetValue("text") : string.Empty);
				bool num = ElementHasAttribute("selected", attributesToApply) && base.currentXmlElement.GetAttribute("selected").ToBoolean();
				TMP_Dropdown currentDropdown = TextMeshProDropdownTagHandler.CurrentHandler.CurrentDropdown;
				TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData
				{
					text = text
				};
				currentDropdown.options.Add(item);
				if (num)
				{
					currentDropdown.value = currentDropdown.options.IndexOf(item);
				}
			}
		}
	}
}
