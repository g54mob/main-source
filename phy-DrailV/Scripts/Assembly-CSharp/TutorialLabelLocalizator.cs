using I2.Loc;
using TMPro;
using UnityEngine;

public class TutorialLabelLocalizator : MonoBehaviour
{
	public string key;

	private void Start()
	{
		if (string.IsNullOrEmpty(key))
		{
			Debug.LogError(base.gameObject.name + " TutorialLabelLocalizator has no localization key!", this);
			return;
		}
		TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
		string Translation;
		if (!component)
		{
			Debug.LogError(base.gameObject.name + " TutorialLabelLocalizator has no TextMeshProUGUI) component!", this);
		}
		else if (LocalizationManager.TryGetTranslation(key, out Translation))
		{
			component.text = TutorialHelper.LocalizeAndFormatMarkups(Translation, doLocalization: false);
			component.color = Color.white;
		}
		else
		{
			component.text = key;
			component.color = Color.red;
		}
	}
}
