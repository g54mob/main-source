using DG.Tweening;
using UnityEngine;

public class DraggableAirbrush : DraggablePanel
{
	public AirbrushSprite sprite;

	public float finalAngle;

	public float finalShadowOffset;

	public AnimationCurve shadowOffsetCurve;

	public Holder.TransitionDurations lidTransitionDuration;

	public Ease lidEase;

	public Transform boxLid;

	private bool lidStatus;

	private Vector3 lidLockPosition;

	private Sequence lidTween;

	private Vector3 spriteVel;

	protected override void Awake()
	{
	}

	private void Update()
	{
	}

	public void Close(Vector3 position)
	{
	}

	private void LockLid()
	{
	}

	private void UnlockLid()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}
}
