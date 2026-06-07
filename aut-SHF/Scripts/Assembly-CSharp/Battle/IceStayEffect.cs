using System.Collections.Generic;

namespace Battle
{
	public class IceStayEffect : StayStatusEffectBase
	{
		public UnitCollider collider;

		protected float icePoint;

		private List<int> _effectedInstance;

		public void IceInit(float icePoint, double stayTime, int? IcedInstance = null)
		{
		}

		protected void IceEffect(BaseEnemy enemy)
		{
		}

		private void Update()
		{
		}
	}
}
