using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class BossChest : Chest
{
	private bool _canBePlacedOnWater;

	private bool _canBePlacedOnLava;

	public override void OnOccupied()
	{
		base.OnOccupied();
		_canBePlacedOnWater = EntityUtility.HasComponentData<ObjectPropertiesCD>(base.entity, base.world) && EntityUtility.GetComponentData<ObjectPropertiesCD>(base.entity, base.world).Has(-1324171664);
		_canBePlacedOnLava = EntityUtility.HasComponentData<ObjectPropertiesCD>(base.entity, base.world) && EntityUtility.GetComponentData<ObjectPropertiesCD>(base.entity, base.world).Has(-1535225238);
		bool flag = ShouldAdjustToWaterLevel();
		Vector3 localPosition = XScaler.localPosition;
		localPosition.y = (flag ? (-0.375f) : 0f);
		XScaler.localPosition = localPosition;
		shadow.SetActive(!flag);
	}

	private bool ShouldAdjustToWaterLevel()
	{
		if (!_canBePlacedOnWater && !_canBePlacedOnLava)
		{
			return false;
		}
		PugQuerySystem existingSystemManaged = base.world.GetExistingSystemManaged<PugQuerySystem>();
		if (existingSystemManaged == null)
		{
			return false;
		}
		TileCD top = new TileAccessor(existingSystemManaged).GetTop(base.WorldPosition.RoundToInt2());
		if (_canBePlacedOnWater && top.tileType == TileType.water && top.tileset != 3)
		{
			return true;
		}
		if (_canBePlacedOnLava && top.tileType == TileType.water && top.tileset == 3)
		{
			return true;
		}
		return false;
	}
}
