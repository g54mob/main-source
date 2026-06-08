using System.Collections.Generic;
using UnityEngine;

public interface ICombatTarget : IDamagableObject, IHasHitpoints, ITargetLocation
{
	Collider ObjectCollider { get; }

	bool CanCollide { get; }

	List<ICombatTarget> SubordinateTargets { get; set; }

	bool IsHidden { get; }

	bool IsStunned { get; }

	float TimeStunned { get; }

	Vector3 StunPosition { get; }

	void MissedTarget(ICombatTarget target, float attackDamage);

	void Stun(float durationMin, float durationMax);

	void ClearStun();

	void RegisterDirectionalHit(Vector3 force);
}
