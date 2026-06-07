using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	[CreateAssetMenu(fileName = "AddPhysicsAction", menuName = "Brewery/Destruction/Actions/Add Physics Action")]
	public class AddPhysicsAction : DestructionActionBase
	{
		private class ActionRuntimeData
		{
			public Rigidbody addedRigidbody;

			public Collider addedCollider;

			public bool hadRigidbodyBefore;

			public bool wasKinematicBefore;

			public bool hadColliderBefore;

			public int activeTweenId;
		}

		[Header("Physics Settings")]
		[SerializeField]
		private float mass;

		[SerializeField]
		private float drag;

		[SerializeField]
		private float angularDrag;

		[SerializeField]
		private float upwardForceMultiplier;

		[SerializeField]
		private float torqueMultiplier;

		[Header("Collider Settings")]
		[Tooltip("Add a BoxCollider if the target doesn't have one.")]
		[SerializeField]
		private bool addBoxCollider;

		[Tooltip("Override collider size. Leave at zero to auto-calculate from renderers.")]
		[SerializeField]
		private Vector3 colliderSizeOverride;

		[Header("Repair Animation")]
		[SerializeField]
		private LeanTweenType repairEaseType;

		private static Dictionary<int, ActionRuntimeData> runtimeData;

		public override string ActionName => null;

		private ActionRuntimeData GetOrCreateData(DestroyableBehaviour behaviour)
		{
			return null;
		}

		private void ClearData(DestroyableBehaviour behaviour)
		{
		}

		public override void ExecuteDestruction(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint, DestroyableSettings settings)
		{
		}

		private void SetupCollider(Transform target, ActionRuntimeData data)
		{
		}

		private void SetupRigidbody(Transform target, ActionRuntimeData data, DestroyableSettings settings)
		{
		}

		public override void ExecuteRepair(DestroyableBehaviour behaviour, float animationDuration, Action onComplete = null)
		{
		}

		private void CleanupComponents(Transform target, ActionRuntimeData data)
		{
		}

		public override bool IsDestroyed(DestroyableBehaviour behaviour)
		{
			return false;
		}

		public override void ApplyAdditionalForce(DestroyableBehaviour behaviour, Vector3 impactForce, Vector3 impactPoint)
		{
		}
	}
}
