using UnityEngine;

namespace Battle
{
	public abstract class StayStatusEffectBase : MonoBehaviour
	{
		protected double lifeTime;

		protected bool finishInit;

		public void Init(double stayTime)
		{
		}

		protected void CheckLifeTime()
		{
		}

		protected void DestroyEffect()
		{
		}
	}
}
