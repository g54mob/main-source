using System.Collections.Generic;

namespace Battle
{
	public class SlowStayEffect : StayStatusEffectBase
	{
		public UnitCollider collider;

		protected float slowPoint;

		private List<int> _effectedInstance;

		public void SlowInit(float slowPoint, double stayTime, int? slowedInstance = null)
		{
		}

		protected void SlowEffect(BaseEnemy enemy)
		{
		}

		private void Update()
		{
		}
	}
}
