using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct MinerCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public int damage;

		public int cooldown;

		public int timer;
	}
}
