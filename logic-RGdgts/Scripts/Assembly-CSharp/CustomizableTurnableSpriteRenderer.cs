using System;
using System.Collections.Generic;

public class CustomizableTurnableSpriteRenderer : CustomizableRenderer
{
	public class CustomizationDictionaryKeyAttribute : Attribute
	{
	}

	[CustomizationDictionaryKey]
	public Dictionary<int, TurnableSprite> customizations;

	private TurnableSpriteRenderer turnableSpriteRenderer;

	private void Init()
	{
	}

	public override void SetCustomization(int id)
	{
	}

	public override List<int> GetCustomizationKeys()
	{
		return null;
	}

	public override SpriteRotationInfo GetPixelShapeRotationInfo(int customizationKey, int rotationI)
	{
		return default(SpriteRotationInfo);
	}
}
