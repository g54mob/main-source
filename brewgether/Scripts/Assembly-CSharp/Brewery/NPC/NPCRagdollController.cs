using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Simple;
using Pathfinding;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC
{
	[RequireComponent(typeof(NetworkObject))]
	public class NPCRagdollController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedMotorRelease_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCRagdollController _003C_003E4__this;

			public Vector3 position;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedMotorRelease_003Ed__38(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRecoveryCoroutine_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float recoveryTime;

			public NPCRagdollController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRecoveryCoroutine_003Ed__37(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Component References")]
		[Tooltip("Animator component - will be disabled when ragdolling")]
		[SerializeField]
		private Animator animator;

		[Tooltip("Motor component for ownership-based A* control")]
		private INPCMotor motor;

		private RichAI richAI;

		[Tooltip("Capsule collider - will be disabled when ragdolling to avoid interference")]
		[SerializeField]
		private CapsuleCollider capsuleCollider;

		[Tooltip("Parent GameObject containing all ragdoll bones with Rigidbodies")]
		[SerializeField]
		private GameObject ragdollRoot;

		[Header("Ragdoll Settings")]
		[SerializeField]
		private bool showDebugLogs;

		private float ragdollMass;

		private float minForceThreshold;

		private float maxForce;

		private float maxUpwardForce;

		private float maxBoneVelocity;

		[Header("Recovery Settings (for Bar Brawl KO)")]
		[Tooltip("Hips/pelvis bone for capturing landing position on recovery")]
		[SerializeField]
		private Transform hipsBone;

		private NetworkVariable<bool> isRagdolled;

		private Rigidbody[] ragdollRigidbodies;

		private Collider[] ragdollColliders;

		private bool componentsInitialized;

		private bool originalAnimatorState;

		private Coroutine recoveryCoroutine;

		private NetworkVariable<Vector3> landingPosition;

		public bool IsRagdolled => false;

		public event Action OnRagdollRecovered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void CancelRecovery()
		{
		}

		private void Awake()
		{
		}

		private GameObject FindRootGameObject()
		{
			return null;
		}

		private Transform FindRootTransform()
		{
			return null;
		}

		private static Transform FindChildByName(Transform parent, string targetName)
		{
			return null;
		}

		private void InitializeRagdollComponents()
		{
		}

		private void FixedUpdate()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnRagdollStateChanged(bool previousValue, bool newValue)
		{
		}

		public void ActivateRagdoll(Vector3 impactForce, Vector3 impactPoint)
		{
		}

		public void DeactivateRagdollImmediate(Vector3 respawnPosition)
		{
		}

		public void ActivateRagdollWithRecovery(Vector3 impactForce, Vector3 impactPoint, float recoveryTime)
		{
		}

		[IteratorStateMachine(typeof(_003CRecoveryCoroutine_003Ed__37))]
		private IEnumerator RecoveryCoroutine(float recoveryTime)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedMotorRelease_003Ed__38))]
		private IEnumerator DelayedMotorRelease(Vector3 position)
		{
			return null;
		}

		[ClientRpc]
		private void DeactivateRagdollClientRpc()
		{
		}

		private void EnableNPCComponents()
		{
		}

		[ClientRpc]
		private void ActivateRagdollClientRpc(Vector3 impactForce, Vector3 impactPoint)
		{
		}

		private void StoreOriginalComponentStates()
		{
		}

		private void DisableNPCComponents()
		{
		}

		private void EnableRagdollPhysics()
		{
		}

		private void DisableRagdollPhysics()
		{
		}

		private void ApplyImpactForce(Vector3 impactForce, Vector3 impactPoint)
		{
		}

		[ContextMenu("Test Ragdoll")]
		private void TestRagdollActivation()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2181936030(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1156005836(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
