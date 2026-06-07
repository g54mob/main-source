using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Attributes;
using Jundroo.Common.Utils;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Extensions
{
	public static class TrainEnumExtensions
	{
		public static string GetPrefabPath(this TrainLocomotiveType type)
		{
			return EnumUtility<TrainLocomotiveType>.GetAttribute<PrefabPathAttribute>(type)?.PrefabPath ?? type.ToString();
		}

		public static string GetPrefabPath(this TrainCarType type)
		{
			return EnumUtility<TrainCarType>.GetAttribute<PrefabPathAttribute>(type)?.PrefabPath ?? type.ToString();
		}
	}
}
