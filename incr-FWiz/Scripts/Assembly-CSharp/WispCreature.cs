using UnityEngine;

public class WispCreature : CreatureBehaviour
{
	[SerializeField]
	private DamageableCreature _damageableCreature;

	[SerializeField]
	private WispCreatureAnimator _wispCreatureAnimator;

	[Header("Drop")]
	[SerializeField]
	private float _dropRadius;

	[SerializeField]
	private float _itemDropDuration;

	public ItemType DropItemType;

	public int DropCount;

	[Header("Movement")]
	[SerializeField]
	private WispMovement _wispMovement;

	protected override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHit(bool finished)
	{
	}

	public void Kill()
	{
	}

	public void CreateItem()
	{
	}
}
