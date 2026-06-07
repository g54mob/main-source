using TMPro;
using UnityEngine;

public class CouldNotLoadLibrariesPopup : MonoBehaviour
{
	private const string filenameToken = "{filename}";

	public TextMeshProUGUI headerText;

	public TextMeshProUGUI bodyText;

	public BakedLocalizer _localizer;

	private void Awake()
	{
		SetTextFromLocalization(headerText, StringId.Error_MotorwaysDLL_Title);
		SetTextFromLocalization(bodyText, StringId.Error_MotorwaysDLL_Description);
	}

	public void SetTextFromLocalization(TextMeshProUGUI textMeshProUGUI, StringId stringId)
	{
		if (_localizer.GetLocalization(stringId, out var localizedString, out var fontAsset))
		{
			textMeshProUGUI.font = fontAsset;
			textMeshProUGUI.text = localizedString;
		}
	}

	public void SetMissingLibraryFilename(string filename)
	{
		if (headerText != null)
		{
			string text = headerText.text.Replace("{filename}", filename);
			headerText.text = text;
		}
		if (bodyText != null)
		{
			string text2 = bodyText.text.Replace("{filename}", filename);
			bodyText.text = text2;
		}
	}
}
