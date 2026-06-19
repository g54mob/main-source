using DG.Tweening;
using OUSystems.Basics.Effects;
using UnityEngine;

public class DefaultItemStackAnimator : ItemStackAnimator
{
	[SerializeField]
	private Transform _targetTransform;

	private Tween _currentTween;

	[SerializeField]
	private float _growAnimationScale;

	[SerializeField]
	private float _growAnimationTime;

	[SerializeField]
	private float _shrinkAnimationScale;

	[SerializeField]
	private float _shrinkAnimationTime;

	[SerializeField]
	private ShakeReceiver _shakeReceiver;

	[SerializeField]
	private float _shake;

	public override void Grow()
	{
	}

	public override void Shrink()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void OnEndTween()
	{
	}

	protected void CancelAnimations()
	{
	}
}
