using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Item", order = 1)]
public class ItemData : UnlockableBase
{
	public bool inItemPool;

	public EItem eItem;

	public Texture icon;

	public EItemRarity rarity;

	public MyAchievement unlockRequirement;

	public int maxAmount;

	public int maxAmountPerRun;

	public int itemTickPriority;

	private ItemBase dummyItem;

	public override string GetName()
	{
		return null;
	}

	public override string GetDescription()
	{
		return null;
	}

	public string GetShortDescription()
	{
		return null;
	}

	public ItemBase GetDummyItem()
	{
		return null;
	}

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}

	public Color GetColor()
	{
		return default(Color);
	}

	public override int CompareTo(UnlockableBase other)
	{
		return 0;
	}
}
