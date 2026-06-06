using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.CombatSystem;
using HighlightPlus;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Player
{
	[RequireComponent(typeof(NetworkObject))]
	public class PlayerHealthController : NetworkBehaviour, IDamageable
	{
		[CompilerGenerated]
		private sealed class _003CHealthRegenOverTimeCoroutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerHealthController _003C_003E4__this;

			public float hpPerSecond;

			public float duration;

			private float _003Celapsed_003E5__2;

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
			public _003CHealthRegenOverTimeCoroutine_003Ed__47(int _003C_003E1__state)
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
		private sealed class _003CRespawnAfterDelay_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerHealthController _003C_003E4__this;

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
			public _003CRespawnAfterDelay_003Ed__57(int _003C_003E1__state)
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

		[Header("Health Configuration")]
		[Tooltip("Maximum health value")]
		[SerializeField]
		private float maxHealth;

		[Tooltip("Health regeneration rate per second (0 = disabled)")]
		[SerializeField]
		private float healthRegenRate;

		[Tooltip("Seconds after damage before regen starts")]
		[SerializeField]
		private float healthRegenDelay;

		[Header("Hit Flash Effect (HighlightPlus)")]
		[Tooltip("Enable hit flash effect when taking damage")]
		[SerializeField]
		private bool enableHitFlash;

		[Tooltip("Hit flash color")]
		[SerializeField]
		private Color hitFlashColor;

		[Tooltip("Hit flash intensity")]
		[SerializeField]
		private float hitFlashIntensity;

		[Tooltip("Hit flash fade out duration")]
		[SerializeField]
		private float hitFlashFadeOutDuration;

		[Header("Death & Respawn")]
		[Tooltip("Time in seconds before player respawns after death")]
		[SerializeField]
		private float respawnDelay;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private SimpleCombatController combatController;

		private NetworkVariable<float> currentHealth;

		private NetworkVariable<bool> isDead;

		private float lastDamageTime;

		private HighlightEffect highlightEffect;

		private Vector3 _lastAttackerPosition;

		private static readonly int DeathTriggerHash;

		private static readonly int DeathDirectionHash;

		private static readonly int IsAliveHash;

		public float CurrentHealth => 0f;

		public float MaxHealth => 0f;

		public bool IsDead => false;

		public float HealthPercentage => 0f;

		public event Action<float, float> OnHealthChanged
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

		public event Action<float, float, float> OnHealthDamaged
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

		public event Action OnRecovered
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

		public event Action OnDeath
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

		public void SetBaseMaxHealth(float value)
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void ConfigureHitFlashEffect()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void TakeDamageServerRpc(float damage, Vector3 attackerPosition, ulong attackerNetworkId)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void HealServerRpc(float healAmount)
		{
		}

		public void TakeEnvironmentalDamage(float damage)
		{
		}

		public void TakeImpactDamage(float damage, Vector3 impactPoint)
		{
		}

		[ServerRpc]
		public void TakeImpactDamageServerRpc(float damage, Vector3 impactPoint)
		{
		}

		public void HealDirect(float healAmount)
		{
		}

		public void StartHealthRegenOverTime(float hpPerSecond, float duration)
		{
		}

		[IteratorStateMachine(typeof(_003CHealthRegenOverTimeCoroutine_003Ed__47))]
		private IEnumerator HealthRegenOverTimeCoroutine(float hpPerSecond, float duration)
		{
			return null;
		}

		public void RestoreHealthToMax()
		{
		}

		public void Revive()
		{
		}

		private void TriggerDeath()
		{
		}

		private int CalculateDeathDirection(Vector3 attackerPosition)
		{
			return 0;
		}

		[ClientRpc]
		private void TriggerDeathAnimationClientRpc(int deathDirection)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnAfterDelay_003Ed__57))]
		private IEnumerator RespawnAfterDelay()
		{
			return null;
		}

		private void RespawnPlayer()
		{
		}

		[ContextMenu("Debug: Kill Player (Random Direction)")]
		private void DebugKillPlayer()
		{
		}

		[ClientRpc]
		private void ClearDeathAnimationClientRpc()
		{
		}

		[ClientRpc]
		private void ForceRestorePlayerControlClientRpc()
		{
		}

		[ClientRpc]
		private void RespawnPlayerClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		private void HandleHealthChanged(float previousValue, float newValue)
		{
		}

		private void HandleDeathChanged(bool previousValue, bool newValue)
		{
		}

		[ClientRpc]
		private void NotifyDamageClientRpc(float oldHealth, float newHealth, float damage, Vector3 attackerPosition)
		{
		}

		[ClientRpc]
		private void NotifyBlockSuccessClientRpc(float blockedDamage, ulong attackerNetworkId, Vector3 attackerPosition)
		{
		}

		private void TriggerHitFlash()
		{
		}

		public void TriggerHitFlashManual()
		{
		}

		private void SpawnHitParticles(Vector3 attackerPosition)
		{
		}

		public void TakeDamage(float damage, Vector3 attackerPosition, ulong attackerNetworkId)
		{
		}

		public NetworkObject GetNetworkObject()
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_808675509(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_841432570(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4158935027(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3274651517(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4014677715(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1198519436(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2758948577(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4143394588(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1886511371(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
