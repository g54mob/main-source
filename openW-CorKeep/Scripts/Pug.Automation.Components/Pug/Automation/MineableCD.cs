using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct MineableCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;
	}
}
