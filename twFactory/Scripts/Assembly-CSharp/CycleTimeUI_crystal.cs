using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CycleTimeUI_crystal : MonoBehaviour
{
	public enum ECrystalState
	{
		None = 0,
		Day = 1,
		Night = 2
	}

	[SerializeField]
	private Image crystalImage;

	[SerializeField]
	private Image glowImage;

	[SerializeField]
	private Color defaultCrystalColor;

	[SerializeField]
	private Color dayCrystalColor;

	[SerializeField]
	private Color nightCrystalColor;

	[SerializeField]
	private Color dayGlowColor;

	[SerializeField]
	private Color nightGlowColor;

	private Tween colorTween;

	private Tween glowTween;

	private void OnDisable()
	{
		if (colorTween != null)
		{
			colorTween.Kill(complete: true);
		}
		if (glowTween != null)
		{
			glowTween.Kill(complete: true);
		}
	}

	public void SetCrystalState(ECrystalState state, float transitionDuration, bool doGlow)
	{
		if (colorTween != null)
		{
			colorTween.Kill(complete: true);
		}
		switch (state)
		{
		case ECrystalState.None:
		{
			colorTween = crystalImage.DOColor(defaultCrystalColor, transitionDuration);
			Color color = glowImage.color;
			color.a = 0f;
			glowTween = glowImage.DOColor(color, transitionDuration);
			break;
		}
		case ECrystalState.Day:
			colorTween = crystalImage.DOColor(dayCrystalColor, transitionDuration);
			if (doGlow)
			{
				DoGlowAnimation(dayGlowColor);
			}
			break;
		case ECrystalState.Night:
			colorTween = crystalImage.DOColor(nightCrystalColor, transitionDuration);
			if (doGlow)
			{
				DoGlowAnimation(nightGlowColor);
			}
			break;
		}
	}

	private void DoGlowAnimation(Color color)
	{
		float a = color.a;
		color.a = 0f;
		glowImage.color = color;
		color.a = a;
		glowTween = glowImage.DOColor(color, 0.15f).SetEase(Ease.InSine);
		Tween tween = glowTween;
		tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, (TweenCallback)delegate
		{
			color.a = 0f;
			glowTween = glowImage.DOColor(color, 1f).SetEase(Ease.Linear);
		});
	}
}
