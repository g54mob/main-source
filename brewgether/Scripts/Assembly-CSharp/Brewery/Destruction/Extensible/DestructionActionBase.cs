using System;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	public abstract class DestructionActionBase : ScriptableObject, IDestructionAction
	{
		[Header("Base Settings")]
		[SerializeField]
		protected bool showDebugLogs;

		public abstract string ActionName { get; }

		public abstract void ExecuteDestruction(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint, DestroyableSettings settings);

		public abstract void ExecuteRepair(DestroyableBehaviour behaviour, float animationDuration, Action onComplete = null);

		public abstract bool IsDestroyed(DestroyableBehaviour behaviour);

		public virtual void ApplyAdditionalForce(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint)
		{
		}

		protected void Log(string message)
		{
		}

		protected void LogWarning(string message)
		{
		}
	}
}
