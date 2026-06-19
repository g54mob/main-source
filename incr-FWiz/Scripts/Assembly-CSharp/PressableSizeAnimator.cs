using DG.Tweening;
using UnityEngine;

public class PressableSizeAnimator : PressListenerAnimator
{
	public Transform Transform;

	public float DefaultSize;

	public float HoveredSize;

	public float PressedSize;

	public float TransitionTime;

	public Ease Ease;

	private Tween _tween;

	public override void AfterStateUpdate()
	{
	}
}
