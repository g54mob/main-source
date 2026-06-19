using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace Pug.Automation
{
	[GhostComponent(PrefabType = GhostPrefabType.All)]
	public struct ElectricityCD : IComponentData, IQueryTypeParameter
	{
		public const int ElectricityMaxSpreadLength = 25;

		public CircuitType circuitType;

		[GhostField]
		public int electricityAmountLeft;

		[GhostField]
		public int electricityAmountRight;

		[GhostField]
		public int electricityAmountUp;

		[GhostField]
		public int electricityAmountDown;

		[GhostField]
		public int sourceEnergy;

		[GhostField]
		public bool blocksElectricity;

		public bool hasDirection;

		public bool blocksElectricityWhenVariationIsZero;

		public CircuitConnectionMode circuitConnectionMode;

		public bool deprioritize;

		public int electricityAmount => math.cmax(new int4(electricityAmountLeft, electricityAmountRight, electricityAmountUp, electricityAmountDown));

		public bool hasEnoughElectricityToPowerStuff => electricityAmount > 1;

		public readonly bool ShouldDisplayedRequireElectricity()
		{
			if (circuitType == CircuitType.None && circuitConnectionMode == CircuitConnectionMode.None && sourceEnergy == 0)
			{
				return !deprioritize;
			}
			return false;
		}
	}
}
