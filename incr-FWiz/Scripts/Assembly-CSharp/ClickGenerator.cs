using UnityEngine;

public class ClickGenerator : ClickHitDummy
{
	[SerializeField]
	private ItemType _itemType;

	[SerializeField]
	private float _outputRadius;

	[SerializeField]
	private float _outputAngleRange;

	[SerializeField]
	private float _outputAngleCenter;

	public override void OnFinishingHit()
	{
	}

	public void CreateItem()
	{
	}

	public void CreateItem(ItemType itemType)
	{
	}
}
