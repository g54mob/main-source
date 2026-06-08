using UnityEngine;

public class PulseCosmetic : Cosmetic
{
	public string weaponNameTemplate;

	public float pulseVelocity = 25f;

	public Color shinyBaseColor;

	public Color labelColor;

	public override string GetName()
	{
		string arg = base.GetName();
		return string.Format(Te.xt(weaponNameTemplate), arg);
	}

	public override AsciiSprite GetCosmeticIcon(Item weapon)
	{
		AsciiSprite sharedIcon = IconLoader.Singleton.GetSharedIcon(weapon.iconPath, 'o', ItemData.CharForElement(weapon.element), ItemData.Rarity.Type.Common, isShiny: true, base.cosmeticCollection.collectionId);
		if (sharedIcon == null)
		{
			Utils.LogError("couldn't load icon for weapon " + weapon.id);
		}
		AsciiSpritePPShiny component = sharedIcon.GetComponent<AsciiSpritePPShiny>();
		ModifyShinyComponent(component);
		return sharedIcon;
	}

	public override Color GetCosmeticLabelColor(Item weapon)
	{
		return labelColor;
	}

	public override Color GetLabelColor()
	{
		return labelColor;
	}

	public override bool AllowsRarityColor(Weapon w)
	{
		return false;
	}

	public override bool AllowsShiny(Weapon w)
	{
		return true;
	}

	public override bool ForcesShiny(Weapon w)
	{
		return true;
	}

	public override void ModifyShinyComponent(AsciiSpritePPShiny shinyComponent)
	{
		shinyComponent.tint = shinyBaseColor;
		shinyComponent.velocity = pulseVelocity;
		shinyComponent.power = 3.15f;
		shinyComponent.amplitude = 2f;
		shinyComponent.darken = 0f;
		shinyComponent.shineWhiteness = 0f;
	}

	protected override void Awake()
	{
		base.Awake();
		base.cosmeticCollection = CosmeticController.singleton.GetCollection(id);
	}
}
