using Data.Variables;
using Presentation.FactoryFloor.Toolbar;

public static class BreadcrumbUtilities
{
	public static string BuildBarTabToTag(BuildMode buildMode, int familyId)
	{
		if (buildMode == BuildMode.Buildings_Grey || buildMode == BuildMode.Buildings_Blue || buildMode == BuildMode.Buildings_Yellow || buildMode == BuildMode.Buildings_Red)
		{
			return BuildBarTabToTag(familyId);
		}
		return buildMode.ToString();
	}

	public static string BuildBarTabToTag(int familyId)
	{
		return "BuildingFamily_" + familyId;
	}

	public static string UnlockedMenuBreadcrumbId(BoolVariableSO menuVariable)
	{
		return menuVariable.name;
	}
}
