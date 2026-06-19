using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct MoverCD : IComponentData, IQueryTypeParameter
	{
		public int2 start;

		public int2 stop;

		public int moveTime;

		public int cooldownTime;

		public Entity inventoryEntity;

		public Entity moverOrchestratorEntity;

		public int splitsIntoOnMove;

		public bool cycleEnabledMoverAfterActivation;

		public bool enableAllMoversAfterActivation;

		public bool allowPickupFromInventories;

		public int indexInOrchestrator;
	}
}
