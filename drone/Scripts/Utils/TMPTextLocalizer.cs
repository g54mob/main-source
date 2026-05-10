using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPTextLocalizer : MonoBehaviour
{
	private TextMeshProUGUI textComp;

	private string textKey;

	private string localizedText;

	private void Start()
	{
		textComp = GetComponent<TextMeshProUGUI>();
		textKey = textComp.text;
		LocalizeText();
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
		OptionHolder.OnOptionChanged += OnSettingChanged;
	}

	private void OnDestroy()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
		OptionHolder.OnOptionChanged -= OnSettingChanged;
	}

	public void LocalizeText()
	{
		if (textComp.text != localizedText)
		{
			textKey = textComp.text;
		}
		localizedText = Localizer.Localize(textKey);
		if (textComp.text != localizedText)
		{
			textComp.text = localizedText;
			textComp.ForceMeshUpdate();
		}
	}

	private void OnTextChanged(Object obj)
	{
		if (obj == textComp)
		{
			LocalizeText();
		}
	}

	private void OnSettingChanged(string setting)
	{
		if (setting == "language")
		{
			LocalizeText();
		}
	}
}
