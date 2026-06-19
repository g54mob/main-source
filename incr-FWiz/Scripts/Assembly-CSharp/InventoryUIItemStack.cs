using DG.Tweening;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class InventoryUIItemStack : ItemStackUI
{
	[SerializeField]
	private float _growAnimationScale;

	[SerializeField]
	private float _growAnimationTime;

	[SerializeField]
	private float _shrinkAnimationRotation;

	[SerializeField]
	private float _shrinkAnimationTime;

	private Tween _currentTween;

	[SerializeField]
	private float _primaryBumpScale;

	[SerializeField]
	private float _primaryBumpDuration;

	private bool _primary;

	public void SetPrimary()
	{
	}

	public void SetSecondary()
	{
	}

	protected override void OnUpdateCount(ValueUpdateData<int> update)
	{
	}

	public void OnEndTween()
	{
	}

	protected override void OnDestroy()
	{
	}
}
