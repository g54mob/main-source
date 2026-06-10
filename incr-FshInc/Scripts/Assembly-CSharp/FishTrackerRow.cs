using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FishTrackerRow : MonoBehaviour
{
	public Image fishIcon;

	public SuperTextMesh fishText;

	private CanvasGroup canvasGroup;

	private Tween glowTween;

	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;
	}

	public void Setup(Sprite icon, string text, bool shadowed, bool isHotspot)
	{
		if (fishIcon != null)
		{
			fishIcon.sprite = icon;
			fishIcon.preserveAspect = true;
			fishIcon.color = (shadowed ? Color.black : Color.white);
		}
		if (fishText != null)
		{
			string localizedString = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
			string text2 = ((!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#")) ? localizedString : "???");
			fishText.text = (shadowed ? text2 : text);
		}
		SetGlow(isHotspot);
	}

	public void Show()
	{
		base.transform.DOKill();
		canvasGroup.DOFade(1f, 0.4f);
		base.transform.localScale = Vector3.one * 0.8f;
		base.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
	}

	public void Hide(Action onComplete)
	{
		base.transform.DOKill();
		canvasGroup.DOFade(0f, 0.3f);
		base.transform.DOScale(0.8f, 0.3f).SetEase(Ease.InBack).OnComplete(delegate
		{
			onComplete?.Invoke();
		});
	}

	public void PlayUpdateAnimation()
	{
		base.transform.DOKill();
		base.transform.localScale = Vector3.one;
		base.transform.DOPunchScale(Vector3.one * 0.05f, 0.3f, 2, 0.5f);
	}

	public void SetGlow(bool active)
	{
		if (active)
		{
			if (glowTween == null)
			{
				base.transform.DOKill();
				base.transform.localScale = Vector3.one;
				glowTween = base.transform.DOScale(1.05f, 0.8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
			}
		}
		else if (glowTween != null)
		{
			glowTween.Kill();
			glowTween = null;
			base.transform.DOScale(1f, 0.3f);
		}
	}
}
