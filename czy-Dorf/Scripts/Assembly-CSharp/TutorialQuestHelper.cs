using TMPro;
using UnityEngine;

public class TutorialQuestHelper : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI displayedText;

	[SerializeField]
	private string localizationKey;

	[SerializeField]
	private int targetCount;

	[SerializeField]
	private bool useHighlightColor = true;

	[SerializeField]
	private bool useHighlightFont = true;

	[SerializeField]
	private Material highlightMaterial;

	private void Start()
	{
		UpdateText();
		LocalizationManager.Instance.OnLanguageChanged += UpdateText;
	}

	private void UpdateText()
	{
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(localizationKey);
		displayedText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.SemiBold);
		localizedValue = localizedValue.Replace("[x]", targetCount.ToString());
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, targetCount);
		string text = "";
		string text2 = "";
		if (useHighlightColor)
		{
			text = text + "<color=#" + ColorUtility.ToHtmlStringRGBA(highlightMaterial.color) + ">";
			text2 += "</color>";
		}
		if (useHighlightFont)
		{
			text = text + "<font=\"" + LocalizationManager.Instance.GetFont(LocalizedFontStyle.ExtraBold).name + "\">";
			text2 += "</font>";
		}
		displayedText.text = "= " + localizedValue.Replace("[h]", text).Replace("[/h]", text2);
	}

	private void OnDestroy()
	{
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
		}
	}
}
