using DG.Tweening;
using UnityEngine;

public class PressableRotationAnimator : PressListenerAnimator
{
	public Transform Transform;

	public float DefaultRotation;

	public float HoveredRotation;

	public float PressedRotation;

	public float TransitionTime;

	public Ease Ease;

	private Tween _tween;

	public override void AfterStateUpdate()
	{
	}
}
