using System;
using System.Collections.Generic;

public class CustomizableTurnableSpriteRendererAnimator : CustomizableRenderer
{
	public class CustomizationDictionaryKeyAttribute : Attribute
	{
	}

	[CustomizationDictionaryKey]
	public Dictionary<int, TurnableSpriteRendererAnimator.Frame[]> customizations;

	private TurnableSpriteRendererAnimator turnableSpriteRenderer;

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
