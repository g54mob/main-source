using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace Pug.Automation
{
	public struct PugAutomationEnabledMoverSyncedCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public int2 moveVector;

		[GhostField]
		public sbyte moverIndex;

		public int nextMoverCycleIncrement;
	}
}
