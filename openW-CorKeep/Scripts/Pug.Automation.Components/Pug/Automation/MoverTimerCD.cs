using Unity.Entities;

namespace Pug.Automation
{
	public struct MoverTimerCD : IComponentData, IQueryTypeParameter
	{
		public int timer;
	}
}
