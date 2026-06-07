using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IMDamage
	{
		Vector3 HitDirection { get; set; }

		Vector3 HitPosition { get; }

		Transform Transform { get; }

		SurfaceID Surface { get; }

		GameObject Damager { get; set; }

		GameObject Damagee { get; }

		Collider HitCollider { get; set; }

		ForceMode LastForceMode { get; set; }

		void ReceiveDamage(Vector3 Direction, Vector3 Position, GameObject Damager, StatModifier stat, bool IsCritical, bool Default_react, Reaction custom, bool ignoreDamageeM, StatElement element);

		void ReceiveDamage(StatID stat, float amount);

		void Profile_Set(string name);

		void Profile_Restore();
	}
}
