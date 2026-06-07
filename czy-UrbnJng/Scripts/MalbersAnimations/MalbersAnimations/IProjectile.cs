using UnityEngine;

namespace MalbersAnimations
{
	public interface IProjectile : IMLayer
	{
		Vector3 Velocity { get; set; }

		Vector3 Gravity { get; set; }

		float AfterDistance { get; set; }

		Vector3 PosOffset { get; set; }

		Vector3 RotOffset { get; set; }

		bool HasImpacted { get; set; }

		GameObject HitEffect { get; set; }

		void Prepare(GameObject Owner, Vector3 Gravity, Vector3 ProjectileVelocity, LayerMask HitLayer, QueryTriggerInteraction triggerInteraction);

		void SetDamageMultiplier(float multiplier);

		void PrepareDamage(StatModifier modifier, float CriticalChance, float CriticalMultiplier, StatElement element);

		void Fire();

		void Fire(Vector3 Velocity);
	}
}
