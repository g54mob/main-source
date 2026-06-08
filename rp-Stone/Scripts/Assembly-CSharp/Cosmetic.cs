using UnityEngine;

public class Cosmetic : Item
{
	public CosmeticController.Collection cosmeticCollection { get; set; }

	public CosmeticController.ItemEntry targetItem { get; set; }

	public override void SetHasInteracted(bool value)
	{
		base.SetHasInteracted(value);
		targetItem.isNew = !value;
	}

	public override string GetName()
	{
		Item prefabForId = ItemFactory.singleton.GetPrefabForId(targetItem.itemId);
		ItemData.Element element = prefabForId.element;
		prefabForId.element = targetItem.element;
		string result = prefabForId.GetName();
		prefabForId.element = element;
		return result;
	}

	public override string GetDescription()
	{
		return string.Format(Te.xt("tid_cosmetic_golden_progress"), cosmeticCollection.collectedItems.Count, cosmeticCollection.totalCollectionSize) + "\n\n" + Te.xt("tid_cosmetic_creations");
	}

	public override AsciiSprite GetIcon()
	{
		Item prefabForId = ItemFactory.singleton.GetPrefabForId(targetItem.itemId);
		ItemData.Element element = prefabForId.element;
		prefabForId.element = targetItem.element;
		Weapon weapon = prefabForId as Weapon;
		AsciiSprite cosmeticIcon = GetCosmeticIcon(weapon);
		prefabForId.element = element;
		return cosmeticIcon;
	}

	public virtual AsciiSprite GetCosmeticIcon(Item weapon)
	{
		ItemData.Rarity.Type rarityType = weapon.GetRarityType();
		AsciiSprite sharedIcon = IconLoader.Singleton.GetSharedIcon(weapon.iconPath, 'o', ItemData.CharForElement(weapon.element), rarityType, weapon.isShiny);
		if (sharedIcon == null)
		{
			Utils.LogError("couldn't load icon for weapon " + weapon.id);
		}
		return sharedIcon;
	}

	public virtual Color GetCosmeticLabelColor(Item weapon)
	{
		if (weapon != null)
		{
			return ItemData.Rarity.GetColorForRarity(weapon.GetRarityType());
		}
		return Color.white;
	}

	public bool IsFinalCollectionItem()
	{
		return cosmeticCollection.finalItemId == targetItem.itemId;
	}

	public virtual bool AllowsRarityColor(Weapon w)
	{
		return true;
	}

	public virtual bool AllowsShiny(Weapon w)
	{
		return true;
	}

	public virtual bool ForcesShiny(Weapon w)
	{
		return false;
	}

	public virtual void ApplyCustomEffects(AsciiSprite sprite)
	{
	}

	public virtual void RemoveCustomEffects(AsciiSprite sprite)
	{
	}

	public virtual void ModifyShinyComponent(AsciiSpritePPShiny shinyComponent)
	{
	}

	public virtual bool HasSerializationData()
	{
		return false;
	}
}
