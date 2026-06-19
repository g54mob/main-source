using UnityEngine;

public class FishCreature : ClickHitDummy
{
	[SerializeField]
	private Creature _creature;

	[SerializeField]
	private ItemType _itemType;

	[SerializeField]
	private FishCreatureAnimator _animator;

	public override void Hit()
	{
	}

	public override void OnFinishingHit()
	{
	}
}
