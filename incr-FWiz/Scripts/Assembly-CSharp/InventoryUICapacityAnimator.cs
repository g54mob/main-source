using DG.Tweening;
using OUSystems.Basics.Effects;
using UnityEngine;

public class InventoryUICapacityAnimator : MonoBehaviour
{
	[SerializeField]
	private RectTransform _transform;

	[SerializeField]
	private ShakeReceiver _inventorySizeShakeReceiver;

	[SerializeField]
	private float _inventoryFullShake;

	[SerializeField]
	private float _maxCapacityBumpScale;

	[SerializeField]
	private float _maxScaleBumpDuration;

	private Tween _tween;

	public void OnInventoryTooFull()
	{
	}
}
