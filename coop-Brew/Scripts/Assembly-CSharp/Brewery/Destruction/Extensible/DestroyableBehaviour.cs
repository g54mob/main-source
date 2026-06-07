using System;
using UnityEngine;

namespace Brewery.Destruction.Extensible
{
	public class DestroyableBehaviour : MonoBehaviour
	{
		[Header("Destruction Configuration")]
		[Tooltip("The action to execute when destroyed. Assign a ScriptableObject asset.")]
		[SerializeField]
		private DestructionActionBase destructionAction;

		[Tooltip("Target transform for the action. Leave null to use this transform.")]
		[SerializeField]
		private Transform actionTarget;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("State (Runtime - Read Only)")]
		[SerializeField]
		private bool isDestroyed;

		private TransformSnapshot originalState;

		private DestroyableStructure parentStructure;

		private bool isInitialized;

		public DestructionActionBase Action => null;

		public Transform ActionTarget => null;

		public bool IsDestroyed => false;

		public TransformSnapshot OriginalState => default(TransformSnapshot);

		public DestroyableStructure ParentStructure => null;

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void TriggerDestruction(Vector3 impactForce, Vector3 impactPoint, DestroyableSettings settings)
		{
		}

		public void TriggerRepair(float animationDuration, Action onComplete = null)
		{
		}

		public void ResetState()
		{
		}

		public void SetParentStructure(DestroyableStructure structure)
		{
		}
	}
}
