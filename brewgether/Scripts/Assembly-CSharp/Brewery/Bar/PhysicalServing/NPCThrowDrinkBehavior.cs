using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Items;
using Brewery.NPC;
using Brewery.NPC.Simple;
using ParticleEffects;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar.PhysicalServing
{
	[RequireComponent(typeof(SimpleNPCController))]
	public class NPCThrowDrinkBehavior : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDespawnAfterDelay_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public NetworkObject netObj;

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
			public _003CDespawnAfterDelay_003Ed__42(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		private SimpleNPCController npcController;

		[SerializeField]
		private SimpleNPCAnimator npcAnimator;

		[SerializeField]
		private NPCSpeechBubbleController speechBubble;

		[SerializeField]
		private Transform throwOrigin;

		[Header("Configuration")]
		[Tooltip("If true, uses PhysicalServingConfig for all settings. If false, uses local values below.")]
		[SerializeField]
		private bool useGlobalConfig;

		[Header("Local Overrides (only used if useGlobalConfig = false)")]
		[Tooltip("Force applied forward when throwing")]
		[SerializeField]
		private float throwForce;

		[Tooltip("Upward force added when throwing")]
		[SerializeField]
		private float throwUpwardForce;

		[Tooltip("Random spin torque applied on throw")]
		[SerializeField]
		private float throwSpinTorque;

		[Tooltip("Spawn offset from NPC position (local space) if no throwOrigin set")]
		[SerializeField]
		private Vector3 throwOriginOffset;

		[Tooltip("How long the thrown drink exists before despawning")]
		[SerializeField]
		private float projectileLifetime;

		[Tooltip("Total throw animation duration (fallback if animation event doesn't fire)")]
		[SerializeField]
		private float throwAnimationDuration;

		[Tooltip("Duration angry dialogue is shown")]
		[SerializeField]
		private float dialogueDuration;

		[Header("Projectile Settings (Not in Config)")]
		[Tooltip("Particle effect for bottle impact")]
		[SerializeField]
		private ParticleEffectManager.ParticleType impactParticle;

		[Tooltip("Default prefab to use if beverage has no world prefab")]
		[SerializeField]
		private GameObject defaultBottlePrefab;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isThrowing;

		private BeverageItem pendingBeverage;

		private string pendingDrinkName;

		private ulong targetPlayerId;

		private GameObject heldBottleVisual;

		private bool hasReleasedBottle;

		private float ThrowForceValue => 0f;

		private float ThrowUpwardForceValue => 0f;

		private float ThrowSpinTorqueValue => 0f;

		private Vector3 ThrowOriginOffsetValue => default(Vector3);

		private float ProjectileLifetimeValue => 0f;

		private float ThrowAnimationDurationValue => 0f;

		private float DialogueDurationValue => 0f;

		private void Awake()
		{
		}

		public void ThrowDrink(BeverageItem beverage, string drinkName, ulong servingPlayerId = 0uL)
		{
		}

		public void ThrowDrink(BeverageItem beverage, string drinkName)
		{
		}

		[ClientRpc]
		private void StartThrowAnimationClientRpc()
		{
		}

		[ClientRpc]
		private void SpawnBottleInHandClientRpc(string itemId)
		{
		}

		[ClientRpc]
		private void DestroyHeldBottleClientRpc()
		{
		}

		private void ReleaseBottle()
		{
		}

		[IteratorStateMachine(typeof(_003CDespawnAfterDelay_003Ed__42))]
		private IEnumerator DespawnAfterDelay(NetworkObject netObj, float delay)
		{
			return null;
		}

		private void EndThrowServer()
		{
		}

		[ClientRpc]
		private void EndThrowAnimationClientRpc()
		{
		}

		[ClientRpc]
		private void TriggerAngryDialogueClientRpc(string wrongDrinkName)
		{
		}

		private Transform FindPlayerByClientId(ulong clientId)
		{
			return null;
		}

		public void OnThrowRelease()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1972438652(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1802590390(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2576384626(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_313898539(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_631144414(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
