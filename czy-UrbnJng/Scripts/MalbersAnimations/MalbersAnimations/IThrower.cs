using System;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IThrower
	{
		Vector3 Gravity { get; }

		float AfterDistance { get; set; }

		Vector3 AimOriginPos { get; }

		Transform AimOrigin { get; }

		Vector3 Velocity { get; }

		Action<bool> Predict { get; set; }

		LayerMask Layer { get; set; }

		QueryTriggerInteraction TriggerInteraction { get; set; }

		GameObject Owner { get; }

		void Fire();

		void SetProjectile(GameObject newProjectile);
	}
}
