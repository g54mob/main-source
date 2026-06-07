using UnityEngine;

namespace Battle
{
	public abstract class BaseBattleEffect : MonoBehaviour
	{
		public ParticleSystem effect;

		protected double debugTimer;

		protected double gearCache;

		public bool IsPlaying => false;

		protected virtual void Update()
		{
		}

		public virtual void ChangeSpeed()
		{
		}

		public float GetDegreeByStateName(string animationName, Vector2 dirVec)
		{
			return 0f;
		}

		public void PlayEffect()
		{
		}

		public void PauseEffect()
		{
		}

		public virtual void StopEffect(bool withChildren = true, ParticleSystemStopBehavior behavior = ParticleSystemStopBehavior.StopEmitting)
		{
		}
	}
}
