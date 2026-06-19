using Aggro.Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NitroBarUI : EntityBehaviourBase
{
	public RectTransform rect;

	public Image fill;

	public Image outline;

	public Image shadow;

	public Image flash;

	private int SHAKE_ID = Shader.PropertyToID("_shake");

	private bool isFull;

	public Gradient colorGradient;

	public Gradient outlineGradient;

	protected override void OnInitializeBehaviour()
	{
		SetFill(0f);
	}

	public void SetFull()
	{
		SetFill(1f);
	}

	public void SetEmpty()
	{
		SetFill(0f);
	}

	private void GrowBar()
	{
		rect.DOScale(1.2f, 0.4f).SetEase(Ease.OutElastic);
	}

	private void ShrinkBar()
	{
		rect.DOScale(1f, 0.3f).SetEase(Ease.OutSine);
	}

	private void NitroShrinkBar()
	{
		flash.enabled = true;
		DOTween.Sequence().Append(rect.DOScale(1.3f, 0.1f)).AppendInterval(0.5f)
			.Append(rect.DOScale(1f, 0.3f))
			.OnComplete(DisableFlash);
	}

	private void DisableFlash()
	{
		flash.enabled = false;
	}

	public void SetFill(float fillAmount, bool nitroActive = false)
	{
		if (isFull && fillAmount < 1f)
		{
			isFull = false;
			if (nitroActive)
			{
				NitroShrinkBar();
			}
			else
			{
				ShrinkBar();
			}
		}
		else if (!isFull && fillAmount >= 1f)
		{
			isFull = true;
			GrowBar();
		}
		fill.fillAmount = fillAmount;
		if (!nitroActive)
		{
			fill.color = colorGradient.Evaluate(fillAmount);
			outline.color = outlineGradient.Evaluate(fillAmount);
		}
		else
		{
			fill.color = colorGradient.Evaluate(1f);
			outline.color = outlineGradient.Evaluate(1f);
		}
	}
}
