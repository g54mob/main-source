using UI.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class XmlLayout_Localization_Example : XmlLayoutController
{
	public string selectedLanguage = "English";

	private XmlElementReference<XmlLayoutToggleGroup> toggleGroup;

	private void Awake()
	{
		base.xmlLayout.Show();
		toggleGroup = XmlElementReference<XmlLayoutToggleGroup>("languageToggleGroup");
	}

	public override void LayoutRebuilt(ParseXmlResult parseResult)
	{
		if (toggleGroup != null)
		{
			toggleGroup.element.SetSelectedValue(selectedLanguage, fireEvent: false);
		}
	}

	private void ChangeLanguage(string language)
	{
		selectedLanguage = language;
		if (language == "No Localization")
		{
			base.xmlLayout.SetLocalizationFile(null);
			return;
		}
		XmlLayoutLocalization xmlLayoutLocalization = XmlLayoutUtilities.LoadResource<XmlLayoutLocalization>("Localization/" + language);
		if (xmlLayoutLocalization == null)
		{
			Debug.LogWarningFormat("Warning: localization file for language '{0}' not found!", language);
		}
		else
		{
			base.xmlLayout.SetLocalizationFile(xmlLayoutLocalization);
		}
	}

	private void ReturnToMainExamples()
	{
		base.xmlLayout.Hide(delegate
		{
			SceneManager.LoadSceneAsync("ExampleScene");
		});
	}
}
