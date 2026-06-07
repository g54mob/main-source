using DV.ThingTypes;
using UnityEngine;

namespace LocoSim.Resources
{
	public static class ResourcesConversion
	{
		public static ResourceType ConvertToDVResource(this ResourceContainerType resourceContainer)
		{
			switch (resourceContainer)
			{
			case ResourceContainerType.FUEL:
				return ResourceType.Fuel;
			case ResourceContainerType.SAND:
				return ResourceType.Sand;
			case ResourceContainerType.OIL:
				return ResourceType.Oil;
			case ResourceContainerType.WATER:
				return ResourceType.Water;
			case ResourceContainerType.COAL:
				return ResourceType.Coal;
			case ResourceContainerType.ELECTRIC_CHARGE:
				return ResourceType.ElectricCharge;
			default:
				Debug.LogError($"Conversion doesn't exist for {resourceContainer} (add conversion). Until then returning fuel in attempt to recover.");
				return ResourceType.Fuel;
			}
		}
	}
}
