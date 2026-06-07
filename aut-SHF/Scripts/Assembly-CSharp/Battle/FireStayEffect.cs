using System.Collections.Generic;

namespace Battle
{
	public class FireStayEffect : StayStatusEffectBase
	{
		public UnitCollider collider;

		protected float firePoint;

		private List<int> _effectedInstance;

		public void FireInit(float firePoint, double stayTime, int? firedInstance = null)
		{
		}

		protected void FireEffect(BaseEnemy enemy)
		{
		}

		private void Update()
		{
		}
	}
}
