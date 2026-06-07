using CTS;
using CTS.Core;
using CTS.Furnitures;

public class CanvasFurniturePlacementCondition : CanvasSimpleExitCondition
{
	public override bool CanBeExitedWithEscape()
	{
		if (!base.CanBeExitedWithEscape())
		{
			return false;
		}
		if (FurnitureShop.IsOpen && MonoSingleton<FurniturePlacer>.Instance.TryCancelPlacement())
		{
			return false;
		}
		if (CTSSingleton<FurnitureFastSell>.Instance.IsActive)
		{
			CTSSingleton<FurnitureFastSell>.Instance.SetActive(value: false);
			return false;
		}
		return true;
	}

	public override bool CanBeExitedWithMouse()
	{
		if (!base.CanBeExitedWithMouse())
		{
			return false;
		}
		if ((bool)MonoSingleton<FurniturePlacer>.Instance.CurrentPickedUpFurniture)
		{
			return false;
		}
		if (FurniturePlacer.PlacedSomethingThisFrame)
		{
			return false;
		}
		if (CTSSingleton<FurnitureFastSell>.Instance.IsActive)
		{
			return false;
		}
		return true;
	}
}
