using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	[ExecuteInEditMode]
	internal class XmlLayout_Example_Options : XmlLayoutController
	{
		public XmlLayout_Example_MessageDialog MessageDialog;

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			SetFormDefaults();
		}

		private void SetFormDefaults()
		{
			Dropdown elementById = base.xmlLayout.GetElementById<Dropdown>("resolution");
			elementById.SetOptions("1920x1080", "960x600", "1024x768", "800x600");
			elementById.SetSelectedValue("960x600");
			Dropdown elementById2 = base.xmlLayout.GetElementById<Dropdown>("quality");
			elementById2.SetOptions(QualitySettings.names);
			elementById2.value = QualitySettings.GetQualityLevel();
			ClearApplyButtonHighlight();
		}

		private void FormChanged()
		{
			base.xmlLayout.GetElementById("applyButton").RemoveClass("disabled");
		}

		private void ClearApplyButtonHighlight()
		{
			base.xmlLayout.GetElementById("applyButton").AddClass("disabled");
		}

		private void ResetForm()
		{
			base.xmlLayout.RebuildLayout(forceEvenIfXmlUnchanged: true);
		}

		private void SubmitForm()
		{
			Dictionary<string, string> formData = base.xmlLayout.GetFormData();
			string text = "<b>Form Values</b>:\n----------------------------------------\n";
			foreach (KeyValuePair<string, string> item in formData)
			{
				text += $"<b>{FormatFieldName(item.Key)}</b>: <i>{item.Value}</i>\n";
			}
			text += "\n\n";
			text += "For the purposes of this example, only the <i>Quality</i> setting will take effect.";
			MessageDialog.Show("Form Submitted", text);
			QualitySettings.SetQualityLevel(QualitySettings.names.ToList().IndexOf(formData["quality"]));
			ClearApplyButtonHighlight();
		}

		private string FormatFieldName(string fieldName)
		{
			string text = new string(fieldName.ToCharArray().SelectMany((char c, int i) => (i > 0 && char.IsUpper(c)) ? new char[2] { ' ', c } : new char[1] { c }).ToArray());
			return char.ToUpper(text[0]) + text.Substring(1);
		}
	}
}
