using Unity.Entities;

namespace Pug.Automation
{
	public struct DeactivateSharedMoversTriggerEntityCD : IComponentData, IQueryTypeParameter
	{
		public Entity Entity;
	}
}
