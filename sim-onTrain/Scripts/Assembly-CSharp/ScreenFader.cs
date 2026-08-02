using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
	[SerializeField]
	private Image fadeImage;

	public static ScreenFader Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		SetBlack();
	}

	public void SetBlack()
	{
		fadeImage.enabled = true;
		fadeImage.color = Color.black;
	}

	public void SetClear()
	{
		fadeImage.color = new Color(0f, 0f, 0f, 0f);
		fadeImage.enabled = false;
	}

	public void FadeIn(float duration = 1f, Action onComplete = null)
	{
		fadeImage.enabled = true;
		fadeImage.DOKill();
		fadeImage.DOFade(0f, duration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			fadeImage.enabled = false;
			onComplete?.Invoke();
		});
	}

	public void FadeOut(float duration = 1f, Action onComplete = null)
	{
		fadeImage.enabled = true;
		fadeImage.DOKill();
		fadeImage.color = new Color(0f, 0f, 0f, 0f);
		fadeImage.DOFade(1f, duration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			onComplete?.Invoke();
		});
	}
}
