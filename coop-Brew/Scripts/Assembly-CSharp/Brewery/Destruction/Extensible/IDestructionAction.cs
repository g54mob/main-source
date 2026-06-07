using System;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	public interface IDestructionAction
	{
		string ActionName { get; }

		void ExecuteDestruction(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint, DestroyableSettings settings);

		void ExecuteRepair(DestroyableBehaviour behaviour, float animationDuration, Action onComplete = null);

		bool IsDestroyed(DestroyableBehaviour behaviour);

		void ApplyAdditionalForce(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint);
	}
}
