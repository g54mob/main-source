using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class UI_RebindError : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private float _timeBeforeFade;

	[SerializeField]
	private LocalizedString _errorText;

	private void Awake()
	{
		_text.text = _errorText.GetLocalizedString();
		LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
	}

	private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
	{
		_text.text = _errorText.GetLocalizedString();
	}

	private void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
	}

	public void StartShowText(Color textColor)
	{
		base.gameObject.SetActive(value: true);
		StartCoroutine(ShowText(textColor));
	}

	public IEnumerator ShowText(Color textColor)
	{
		_text.color = textColor;
		yield return new WaitForSecondsRealtime(_timeBeforeFade);
		while (1f - _text.color.a > 0.01f)
		{
			Color color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a - Time.deltaTime);
			_text.color = color;
		}
		base.gameObject.SetActive(value: false);
	}
}
