using System;
using System.Collections.Generic;
using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class CrossCircuit : EntityMonoBehaviour
{
	[Serializable]
	public class Sprites
	{
		public Sprite sprite;

		public Sprite emissiveSprite1;

		public Sprite emissiveSprite2;
	}

	public SpriteRenderer sr;

	public SpriteRenderer emissiveSR1;

	public SpriteRenderer emissiveSR2;

	public List<Sprites> spriteVariants;

	private static readonly int Power = Shader.PropertyToID("_power");

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		int num = base.variation;
		sr.sprite = spriteVariants[num].sprite;
		emissiveSR1.sprite = spriteVariants[num].emissiveSprite1;
		emissiveSR2.sprite = spriteVariants[num].emissiveSprite2;
		ElectricityCD componentData = EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world);
		switch (num)
		{
		case 0:
			SetEmissivePower(math.max(componentData.electricityAmountLeft, componentData.electricityAmountRight), math.max(componentData.electricityAmountUp, componentData.electricityAmountDown));
			break;
		case 1:
			SetEmissivePower(math.max(componentData.electricityAmountLeft, componentData.electricityAmountDown), math.max(componentData.electricityAmountUp, componentData.electricityAmountRight));
			break;
		case 2:
			SetEmissivePower(math.max(componentData.electricityAmountDown, componentData.electricityAmountRight), math.max(componentData.electricityAmountLeft, componentData.electricityAmountUp));
			break;
		}
	}

	private void SetEmissivePower(int electricity1, int electricity2)
	{
		float value = ScaleElectricityToEmissivePower(electricity1);
		float value2 = ScaleElectricityToEmissivePower(electricity2);
		emissiveSR1.material.SetFloat(Power, value);
		emissiveSR2.material.SetFloat(Power, value2);
	}

	private float ScaleElectricityToEmissivePower(int electricity)
	{
		electricity -= 2;
		if (electricity <= 0)
		{
			return 0f;
		}
		return math.min(1f, (float)(electricity + 2) / 10f);
	}
}
