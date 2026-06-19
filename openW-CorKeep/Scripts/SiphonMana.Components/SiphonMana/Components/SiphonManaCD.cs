using Unity.Entities;
using Unity.NetCode;

namespace SiphonMana.Components
{
	public struct SiphonManaCD : IComponentData, IQueryTypeParameter
	{
		public float maxManaPerSiphonPercentage;

		public float siphonRadiusSq;

		public float maxTransferDistanceSq;

		[GhostField]
		public TickTimer siphonCooldownTimer;
	}
}
