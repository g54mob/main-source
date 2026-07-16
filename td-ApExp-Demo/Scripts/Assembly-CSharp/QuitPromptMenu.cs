using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class QuitPromptMenu : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI promptText;

	[SerializeField]
	private LocalizedString progressMadeText;

	[SerializeField]
	private LocalizedString noProgressMadeText;

	private void OnEnable()
	{
		if (SaveManager.Instance.JourneyExists())
		{
			promptText.text = progressMadeText.GetLocalizedString();
		}
		else
		{
			promptText.text = noProgressMadeText.GetLocalizedString();
		}
	}
}
