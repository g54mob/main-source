using Unity.Entities;
using Unity.NetCode;

namespace Pug.Automation
{
	public struct MineableDamageDecreaseCD : IComponentData, IQueryTypeParameter
	{
		public int totalDamage;

		public NetworkTick lastTotalDamageUpdateTick;

		public float damageFactor;

		public float damageDecreaseFactor;

		public float damageDecreaseExp;
	}
}
