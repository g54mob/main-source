using NSMedieval.Enums;
using NSMedieval.Structs;

namespace NSMedieval.Extensions
{
	public static class GridInfoExtension
	{
		public static bool Taken(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Taken) == BuildingProperty.Taken;
		}

		public static bool Delete(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Delete) == BuildingProperty.Delete;
		}

		public static bool Buildable(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Buildable) == BuildingProperty.Buildable;
		}

		public static bool NextToWall(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.NextToWall) == BuildingProperty.NextToWall;
		}

		public static bool Built(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Built) == BuildingProperty.Built;
		}

		public static bool Window(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Window) == BuildingProperty.Window;
		}

		public static bool Door(this GridInfo buildingInfo)
		{
			return (buildingInfo.BuildingProperty & BuildingProperty.Door) == BuildingProperty.Door;
		}

		public static bool IsSameFunctionality(this GridInfo buildingInfo, BuildingFunction function)
		{
			switch (function)
			{
			case BuildingFunction.Door:
				return (buildingInfo.BuildingProperty & BuildingProperty.Door) == BuildingProperty.Door;
			case BuildingFunction.Window:
				return (buildingInfo.BuildingProperty & BuildingProperty.Window) == BuildingProperty.Window;
			case BuildingFunction.None:
				if (buildingInfo.BuildingProperty == BuildingProperty.None)
				{
					return true;
				}
				break;
			}
			return false;
		}

		public static GridInfo SetBuildingPropertyFlag(this GridInfo buildingInfo, BuildingFunction function)
		{
			if (function == BuildingFunction.Door)
			{
				buildingInfo.SetDoor(option: true);
			}
			if (function == BuildingFunction.Window)
			{
				buildingInfo.SetWindow(option: true);
			}
			return buildingInfo;
		}
	}
}
