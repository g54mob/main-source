using Unity.Entities;
using Unity.Mathematics;

namespace EnvironmentEvents.Components
{
	public struct EnvironmentEventTriggerCD : IComponentData, IQueryTypeParameter
	{
		public EnvironmentEventType environmentEvent;

		public float3 position;
	}
}
