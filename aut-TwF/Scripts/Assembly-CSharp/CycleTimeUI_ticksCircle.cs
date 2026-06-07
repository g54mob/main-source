using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CycleTimeUI_ticksCircle : MonoBehaviour
{
	public enum ECircleState
	{
		Day = 0,
		Night = 1
	}

	[SerializeField]
	private Image ticksCircleImage;

	[SerializeField]
	private Color dayTicksCircleColor;

	[SerializeField]
	private Color nightTicksCircleColor;

	private Tween colorTween;

	private bool isResetting;

	private void OnDisable()
	{
		if (colorTween != null)
		{
			colorTween.Kill(complete: true);
		}
		isResetting = false;
	}

	public void ResetTicksCircle(float resetTime)
	{
		Color color = ticksCircleImage.color;
		color.a = 0f;
		colorTween = ticksCircleImage.DOColor(color, resetTime);
		Tween tween = colorTween;
		tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, (TweenCallback)delegate
		{
			SetCircleState(ECircleState.Day, 0f);
			ticksCircleImage.fillAmount = 0f;
			isResetting = false;
		});
		isResetting = true;
	}

	public void SetTicksCircleTime(float dayPercentage)
	{
		if (!isResetting)
		{
			ticksCircleImage.fillAmount = dayPercentage;
		}
	}

	public void SetCircleState(ECircleState state, float transitionDuration)
	{
		if (colorTween != null)
		{
			colorTween.Kill();
		}
		switch (state)
		{
		case ECircleState.Day:
			colorTween = ticksCircleImage.DOColor(dayTicksCircleColor, transitionDuration);
			break;
		case ECircleState.Night:
			colorTween = ticksCircleImage.DOColor(nightTicksCircleColor, transitionDuration);
			break;
		}
	}
}
