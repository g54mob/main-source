using Unity.Entities;

namespace Pug.Automation
{
	public struct BigEntityRefCD : IComponentData, IQueryTypeParameter
	{
		public Entity Value;
	}
}
