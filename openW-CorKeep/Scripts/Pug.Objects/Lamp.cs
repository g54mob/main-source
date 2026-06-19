using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class Lamp : EntityMonoBehaviour
{
	public SpriteObject litBulbSO;

	public SpriteObject baseSprite;

	private float lightDefaultIntensity;

	private int state;

	protected override void Awake()
	{
		lightDefaultIntensity = optionalLightOptimizer.lightToOptimize.intensity;
		optionalLightOptimizer.lightToOptimize.intensity = 0f;
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		state = -1;
	}

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
		ElectricityCD componentData = EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world);
		int num = 0;
		if (componentData.hasEnoughElectricityToPowerStuff)
		{
			num = 1;
		}
		if (state != num)
		{
			state = num;
			if (state == 1)
			{
				baseSprite.emissiveColor = new Color(1f, 1f, 1f, 1f);
				litBulbSO.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				baseSprite.emissiveColor = new Color(0f, 0f, 0f, 1f);
				litBulbSO.color = new Color(1f, 1f, 1f, 0f);
			}
		}
		optionalLightOptimizer.lightToOptimize.intensity = Mathf.Clamp01((float)(componentData.electricityAmount - 1) / 10f) * lightDefaultIntensity;
	}
}
