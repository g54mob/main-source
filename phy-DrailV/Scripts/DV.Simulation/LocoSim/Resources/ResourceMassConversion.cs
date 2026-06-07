using UnityEngine;

namespace LocoSim.Resources
{
	public static class ResourceMassConversion
	{
		public static float GetResourceMassMultiplier(this ResourceContainerType resourceContainerType)
		{
			switch (resourceContainerType)
			{
			case ResourceContainerType.FUEL:
				return 0.85f;
			case ResourceContainerType.OIL:
				return 0.9f;
			case ResourceContainerType.WATER:
				return 1f;
			case ResourceContainerType.SAND:
			case ResourceContainerType.COAL:
				return 1f;
			case ResourceContainerType.ELECTRIC_CHARGE:
				return 0f;
			default:
				Debug.LogError($"Unexpected state: Missing entry for container type {resourceContainerType}, using 1 for multiplier");
				return 1f;
			}
		}
	}
}
