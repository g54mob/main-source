using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisconnectOverlay : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private float fadeDuration = 1f;

	[SerializeField]
	private float delayBeforeSceneLoad = 0.5f;

	private Action onComplete;

	private void Awake()
	{
		canvasGroup.alpha = 0f;
		canvasGroup.gameObject.SetActive(value: false);
	}

	public void Show(Action onComplete = null)
	{
		this.onComplete = onComplete;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		if (EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.enabled = false;
		}
		base.transform.SetAsLastSibling();
		canvasGroup.gameObject.SetActive(value: true);
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = true;
		canvasGroup.interactable = false;
		canvasGroup.DOFade(1f, fadeDuration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			DOVirtual.DelayedCall(delayBeforeSceneLoad, delegate
			{
				this.onComplete?.Invoke();
			}).SetUpdate(isIndependentUpdate: true);
		});
	}
}
