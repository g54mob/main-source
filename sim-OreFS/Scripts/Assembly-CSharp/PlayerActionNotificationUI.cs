using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionNotificationUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TextMeshProUGUI playerNameText;

	[SerializeField]
	private TextMeshProUGUI actionText;

	[Header("Action Icons")]
	[SerializeField]
	private List<PlayerActionIconData> actionIcons = new List<PlayerActionIconData>();

	[Header("Animation Settings")]
	[SerializeField]
	private float displayDuration = 3f;

	[SerializeField]
	private float fadeDuration = 1f;

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

	public void Initialize(string playerName, PlayerActionNotificationType actionType)
	{
		if (playerNameText != null)
		{
			playerNameText.text = playerName;
		}
		Sprite iconForAction = GetIconForAction(actionType);
		if (iconImage != null && iconForAction != null)
		{
			iconImage.sprite = iconForAction;
			iconImage.enabled = true;
		}
		if (actionText != null)
		{
			actionText.text = LocalizationManager.GetTranslation(actionType);
		}
		_fadeCoroutine = StartCoroutine(FadeAndDestroy());
	}

	private Sprite GetIconForAction(PlayerActionNotificationType actionType)
	{
		foreach (PlayerActionIconData actionIcon in actionIcons)
		{
			if (actionIcon.actionType == actionType)
			{
				return actionIcon.icon;
			}
		}
		return null;
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
