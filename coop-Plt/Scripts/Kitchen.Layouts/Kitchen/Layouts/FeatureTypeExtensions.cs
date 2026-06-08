namespace Kitchen.Layouts
{
	public static class FeatureTypeExtensions
	{
		public static bool IsDoor(this FeatureType type)
		{
			if (type != FeatureType.Door && type != FeatureType.FrontDoor && type != FeatureType.DoorReversed && type != FeatureType.LightDoor && type != FeatureType.MissingDoor)
			{
				return type == FeatureType.EmployeesOnlyDoor;
			}
			return true;
		}

		public static bool IsReaching(this FeatureType type)
		{
			if (!type.IsDoor())
			{
				return type == FeatureType.Hatch;
			}
			return true;
		}
	}
}
