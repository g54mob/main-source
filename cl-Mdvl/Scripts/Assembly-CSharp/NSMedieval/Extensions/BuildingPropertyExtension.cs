using NSMedieval.Enums;

namespace NSMedieval.Extensions
{
	public static class BuildingPropertyExtension
	{
		public static BuildingProperty SetBuilt(this BuildingProperty buildProp, bool option)
		{
			if (!option)
			{
				buildProp &= ~BuildingProperty.Built;
				return buildProp;
			}
			buildProp |= BuildingProperty.Built;
			return buildProp;
		}

		public static bool Taken(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Taken) == BuildingProperty.Taken;
		}

		public static bool Delete(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Delete) == BuildingProperty.Delete;
		}

		public static bool Buildable(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Buildable) == BuildingProperty.Buildable;
		}

		public static bool NextToWall(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.NextToWall) == BuildingProperty.NextToWall;
		}

		public static bool Built(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Built) == BuildingProperty.Built;
		}

		public static bool Window(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Window) == BuildingProperty.Window;
		}

		public static bool Door(this BuildingProperty buildProp)
		{
			return (buildProp & BuildingProperty.Door) == BuildingProperty.Door;
		}
	}
}
