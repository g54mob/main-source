using I2.Loc;
using TMPro;
using UnityEngine;

public class RewiredActionInfoBarAction : IconWithLocalize
{
	[SerializeField]
	private TextMeshProUGUI _iconText;

	[SerializeField]
	private Localize _prefixLocalize;

	public void Initialize(Sprite sprite, LocalizedString main, LocalizedString prefix)
	{
		Initialize(sprite, main.mTerm);
		InitializePrefix(prefix);
		_iconText.gameObject.SetActive(value: false);
	}

	public void Initialize(KeyCode keycode, LocalizedString main, LocalizedString prefix)
	{
		Initialize(null, main.mTerm);
		InitializePrefix(prefix);
		_iconText.gameObject.SetActive(value: true);
		_iconText.text = keycode.ToString();
	}

	private void InitializePrefix(LocalizedString prefix)
	{
		if (string.IsNullOrEmpty(prefix.mTerm))
		{
			_prefixLocalize.gameObject.SetActive(value: false);
			return;
		}
		_prefixLocalize.gameObject.SetActive(value: true);
		_prefixLocalize.SetTerm(prefix.mTerm);
	}
}
