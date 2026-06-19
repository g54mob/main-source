using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;

public class LuckyCat : EntityMonoBehaviour
{
	private int state;

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
				spriteObjects[0].PlayAnimation(1260321794);
			}
			else
			{
				spriteObjects[0].PlayAnimation(-1949102368);
			}
		}
	}
}
