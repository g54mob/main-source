using Unity.Entities;

namespace Pug.Automation
{
	public struct MoverOrchestratorCD : IComponentData, IQueryTypeParameter
	{
		public const int ALL_MOVERS_ENABLED = -1;

		public int enabledMoverIndex;

		public int nextMoverCycleIncrement;
	}
}
