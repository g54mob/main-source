using System;
using DG.Tweening;
using UnityEngine;

public class CycleTimeUI_floatingBubble : MonoBehaviour
{
	[SerializeField]
	private Transform centerTransform;

	[SerializeField]
	private Transform bubbleTransform;

	private Tween rotationTween;

	private void OnDisable()
	{
		if (rotationTween != null)
		{
			rotationTween.Complete(withCallbacks: true);
			rotationTween.Kill();
		}
	}

	public void SetBubbleRotation(float percentage, float time)
	{
		SetBubbleRotationDegrees(percentage * 360f, time);
	}

	public void SetBubbleRotationDegrees(float degrees, float time)
	{
		if (rotationTween != null)
		{
			rotationTween.Kill();
		}
		rotationTween = centerTransform.DORotateQuaternion(Quaternion.Euler(0f, 0f, 0f - degrees), time).SetEase(Ease.OutSine);
		Tween tween = rotationTween;
		tween.onUpdate = (TweenCallback)Delegate.Combine(tween.onUpdate, (TweenCallback)delegate
		{
			bubbleTransform.rotation = Quaternion.identity;
		});
	}
}
