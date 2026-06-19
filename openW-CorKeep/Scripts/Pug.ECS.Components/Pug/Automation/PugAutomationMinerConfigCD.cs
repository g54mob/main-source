using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct PugAutomationMinerConfigCD : IComponentData, IQueryTypeParameter
	{
		public int2 offset;

		public int damage;

		public int cooldown;
	}
}
