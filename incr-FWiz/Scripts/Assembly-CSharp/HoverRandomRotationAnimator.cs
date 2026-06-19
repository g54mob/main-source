using DG.Tweening;
using UnityEngine;

public class HoverRandomRotationAnimator : PressListenerAnimator
{
	public Transform Transform;

	public float RotationRange;

	public float TransitionTime;

	public Ease Ease;

	private Tween _tween;

	public override void AfterStateUpdate()
	{
	}
}
