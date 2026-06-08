using UnityEngine;

[RequireComponent(typeof(Item))]
public class ConsumableItem : MonoBehaviour
{
	public enum VfxType
	{
		EachComsumption = 0,
		ConsumableRunsOut = 1
	}

	public int numExecutesToConsume = 1;

	public VfxType playDiscardVfxWhen;

	public Decoration discardLeftAnimationPrefab;

	public Decoration discardRightAnimationPrefab;

	private Item myItem;

	private int executeCount;

	private void HandleOnExecute(Item item)
	{
		executeCount++;
		if (executeCount < numExecutesToConsume)
		{
			return;
		}
		executeCount = 0;
		item.count--;
		if ((playDiscardVfxWhen == VfxType.EachComsumption || item.count <= 0) && item.Owner != null)
		{
			Decoration decoration = discardLeftAnimationPrefab;
			Weapon weapon = item as Weapon;
			if (weapon != null && weapon.IsOnRightHand)
			{
				decoration = discardRightAnimationPrefab;
			}
			if (decoration != null)
			{
				Decoration decoration2 = Object.Instantiate(decoration);
				decoration2.PositionX = item.Owner.PositionX;
				decoration2.PositionY = item.Owner.PositionY;
				decoration2.PositionZ = item.Owner.PositionZ;
				GameStates.Singleton.level.AddCharacter(decoration2);
			}
		}
		if (item.count <= 0)
		{
			Inventory.Singleton.RemoveItem(item);
		}
	}

	private void Awake()
	{
		myItem = GetComponent<Item>();
		myItem.OnExecute += HandleOnExecute;
	}

	private void OnDestroy()
	{
		myItem.OnExecute -= HandleOnExecute;
		myItem = null;
	}
}
