using UnityEngine;

public class PrismaticCosmetic : Cosmetic
{
	private Color _color = Color.black;

	private AsciiSpritePPPrismatic iconPrismaticComponent;

	public Color customColor
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			UpdateIcon();
		}
	}

	public override string GetName()
	{
		string arg = base.GetName();
		return string.Format(Te.xt("Prismatic {0}"), arg);
	}

	public override string GetDescription()
	{
		return string.Format(Te.xt("tid_cosmetic_prism_progress"), base.cosmeticCollection.collectedItems.Count, base.cosmeticCollection.totalCollectionSize) + "\n\n" + Te.xt("tid_cosmetic_creations");
	}

	public override AsciiSprite GetCosmeticIcon(Item weapon)
	{
		AsciiSprite sharedIcon = IconLoader.Singleton.GetSharedIcon(weapon.iconPath, 'o', ItemData.CharForElement(weapon.element), ItemData.Rarity.Type.Common, weapon.isShiny, base.cosmeticCollection.collectionId);
		if (sharedIcon == null)
		{
			Utils.LogError("couldn't load icon for weapon " + weapon.id);
		}
		else
		{
			iconPrismaticComponent = sharedIcon.GetComponent<AsciiSpritePPPrismatic>();
			if (iconPrismaticComponent == null)
			{
				iconPrismaticComponent = sharedIcon.gameObject.AddComponent<AsciiSpritePPPrismatic>();
			}
			iconPrismaticComponent.tint = customColor;
			AsciiSpritePPShiny component = sharedIcon.gameObject.GetComponent<AsciiSpritePPShiny>();
			if (component != null)
			{
				component.ToggleEventConnection();
			}
		}
		return sharedIcon;
	}

	private void UpdateIcon()
	{
		if (iconPrismaticComponent != null)
		{
			iconPrismaticComponent.tint = customColor;
		}
	}

	public override Color GetCosmeticLabelColor(Item weapon)
	{
		if (customColor == Color.black)
		{
			return base.GetCosmeticLabelColor(weapon);
		}
		return customColor;
	}

	public override Color GetLabelColor()
	{
		if (customColor == Color.black)
		{
			return ColorConstants.thirdGrey;
		}
		return customColor;
	}

	public override bool AllowsRarityColor(Weapon w)
	{
		return false;
	}

	public override void ApplyCustomEffects(AsciiSprite sprite)
	{
		AsciiSpritePPPrismatic asciiSpritePPPrismatic = sprite.GetComponent<AsciiSpritePPPrismatic>();
		if (asciiSpritePPPrismatic == null)
		{
			asciiSpritePPPrismatic = sprite.gameObject.AddComponent<AsciiSpritePPPrismatic>();
		}
		asciiSpritePPPrismatic.tint = customColor;
	}

	public override void RemoveCustomEffects(AsciiSprite sprite)
	{
		AsciiSpritePPPrismatic component = sprite.GetComponent<AsciiSpritePPPrismatic>();
		if (component != null)
		{
			Object.Destroy(component);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.cosmeticCollection = CosmeticController.singleton.GetCollection(id);
	}

	public override bool HasSerializationData()
	{
		return true;
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		customColor = SlimJson.ParseColor(sjson, "c", Color.black);
	}

	public override void SerializeMore()
	{
		base.SerializeMore();
		SlimJson.AddProperty("c", customColor);
	}
}
