using CTS.Core;

public class UI_ConstructionExitCondition : CanvasSimpleExitCondition
{
	public override bool CanBeExitedWithEscape()
	{
		EAccess allRoomHaveExteriorAccess = MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess;
		if (allRoomHaveExteriorAccess == EAccess.Inaccessible || allRoomHaveExteriorAccess == EAccess.WrongAccess)
		{
			return false;
		}
		return base.CanBeExitedWithEscape();
	}
}
