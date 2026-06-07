using System.Collections;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemNotificationUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TextMeshProUGUI valueText;

	[Header("Animation Settings")]
	[SerializeField]
	private float displayDuration = 3f;

	[SerializeField]
	private float fadeDuration = 1f;

	[Header("Value Format")]
	[SerializeField]
	private Color positiveColor = new Color(0.2f, 0.8f, 0.2f, 1f);

	[SerializeField]
	private Color negativeColor = new Color(0.8f, 0.2f, 0.2f, 1f);

	[Header("Audio")]
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip moneySound;

	private CanvasGroup _canvasGroup;

	private Coroutine _fadeCoroutine;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		if (_canvasGroup == null)
		{
			_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
	}

	public void Initialize(Sprite icon, string itemName, int value, NotificationType notificationType)
	{
		if (iconImage != null && icon != null)
		{
			iconImage.sprite = icon;
			iconImage.enabled = true;
		}
		if (nameText != null)
		{
			if (!string.IsNullOrEmpty(LocalizationManager.GetTranslation(itemName)))
			{
				nameText.text = LocalizationManager.GetTranslation(itemName);
			}
			else
			{
				nameText.text = "NL/ " + LocalizationManager.GetTranslation(itemName);
			}
		}
		UpdateValueDisplay(value, notificationType);
		_fadeCoroutine = StartCoroutine(FadeAndDestroy());
	}

	private void UpdateValueDisplay(int value, NotificationType notificationType)
	{
		if (valueText == null)
		{
			return;
		}
		if (value >= 0)
		{
			string format = "+{0}";
			switch (notificationType)
			{
			case NotificationType.Money:
				format = "+${0}";
				valueText.color = positiveColor;
				PlayMoneySound();
				break;
			case NotificationType.XP:
				format = "+{0} " + LocalizationManager.GetTranslation("XP");
				break;
			}
			valueText.text = string.Format(format, value);
			return;
		}
		string format2 = "{0}";
		switch (notificationType)
		{
		case NotificationType.Money:
			value -= value * 2;
			format2 = "-${0}";
			valueText.color = negativeColor;
			PlayMoneySound();
			break;
		case NotificationType.XP:
			format2 = "{0} " + LocalizationManager.GetTranslation("XP");
			break;
		}
		valueText.text = string.Format(format2, value);
	}

	private void PlayMoneySound()
	{
		if (audioSource != null && moneySound != null)
		{
			audioSource.PlayOneShot(moneySound);
		}
	}

	private IEnumerator FadeAndDestroy()
	{
		yield return new WaitForSeconds(displayDuration);
		float elapsed = 0f;
		float startAlpha = ((_canvasGroup != null) ? _canvasGroup.alpha : 1f);
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / fadeDuration;
			if (_canvasGroup != null)
			{
				_canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
			}
			yield return null;
		}
		Object.Destroy(base.gameObject);
	}

	public void Close()
	{
		if (_fadeCoroutine != null)
		{
			StopCoroutine(_fadeCoroutine);
		}
		Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		if (_fadeCoroutine != null)
		{
			StopCoroutine(_fadeCoroutine);
			_fadeCoroutine = null;
		}
	}
}
