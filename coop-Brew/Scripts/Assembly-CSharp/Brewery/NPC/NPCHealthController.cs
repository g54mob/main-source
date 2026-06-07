using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.CombatSystem;
using Brewery.NPC.Simple;
using HighlightPlus;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.NPC
{
	[RequireComponent(typeof(NetworkObject))]
	public class NPCHealthController : NetworkBehaviour, IDamageable
	{
		[CompilerGenerated]
		private sealed class _003CAnimateHealthBarScale_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public LeanTweenType easeType;

			public Vector3 from;

			public Vector3 to;

			public NPCHealthController _003C_003E4__this;

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
			public _003CAnimateHealthBarScale_003Ed__89(int _003C_003E1__state)
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
		private sealed class _003CApplyHitStunCoroutine_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCHealthController _003C_003E4__this;

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
			public _003CApplyHitStunCoroutine_003Ed__108(int _003C_003E1__state)
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
		private sealed class _003CDespawnCoroutine_003Ed__100 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCHealthController _003C_003E4__this;

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
			public _003CDespawnCoroutine_003Ed__100(int _003C_003E1__state)
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
		private sealed class _003CGetMaxWidthAfterLayout_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public Action<float> callback;

			public NPCHealthController _003C_003E4__this;

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
			public _003CGetMaxWidthAfterLayout_003Ed__84(int _003C_003E1__state)
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

		[Header("NPC Configuration")]
		[Tooltip("NPC profile (must implement INPCProfile interface)")]
		[SerializeField]
		private ScriptableObject npcProfileAsset;

		[Tooltip("Enemy type identifier for quest events (e.g., 'Scarecrow', 'Thug'). Defaults to 'NPC' if empty.")]
		[SerializeField]
		private string enemyTypeId;

		[Tooltip("Seconds before despawning after death")]
		[SerializeField]
		private float despawnDelay;

		[Tooltip("If true, NPC gets knocked out instead of dying. They ragdoll, get back up, and run home.")]
		[SerializeField]
		private bool knockoutInsteadOfDeath;

		[Tooltip("If true, NPC always permanently dies (bypasses resurrection death chance roll). Use for training dummies, scarecrows, etc.")]
		[SerializeField]
		private bool guaranteedPermanentDeath;

		[Tooltip("If true, NPC death is not registered with the resurrection system (no grave, no death quest). Use for scarecrows, thieves, etc.")]
		[SerializeField]
		private bool excludeFromResurrection;

		[Tooltip("Recovery time in seconds before NPC gets back up after knockout")]
		[SerializeField]
		private float knockoutRecoveryTime;

		[Header("Hit Reaction")]
		[Tooltip("Briefly freeze NPC when hit (for impact feedback)")]
		[SerializeField]
		private bool enableHitStun;

		[Tooltip("How long to freeze when hit (seconds)")]
		[SerializeField]
		private float hitStunDuration;

		[Tooltip("Play hit reaction animations when damaged (flinch)")]
		[SerializeField]
		private bool enableHitReactionAnimations;

		[Tooltip("Chance to play hit reaction on each hit (0-1). Lower = less flinching")]
		[Range(0f, 1f)]
		[SerializeField]
		private float hitReactionChance;

		[Header("Worldspace UI")]
		[Tooltip("UIDocument for worldspace health bar")]
		[SerializeField]
		private UIDocument healthUIDocument;

		[Tooltip("Billboard transform (will rotate to face camera)")]
		[SerializeField]
		private Transform billboardTransform;

		[Header("UI Animation")]
		[Tooltip("Speed of health bar animation")]
		[SerializeField]
		private float healthBarSpeed;

		[Tooltip("Delay before trail bar catches up")]
		[SerializeField]
		private float trailDelay;

		[Tooltip("Speed of trail bar animation")]
		[SerializeField]
		private float trailBarSpeed;

		[Tooltip("Low health warning threshold (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float lowHealthThreshold;

		[Header("Health Bar Pop Animation")]
		[Tooltip("Seconds before auto-hiding health bar after damage")]
		[Range(5f, 30f)]
		[SerializeField]
		private float hideHealthBarAfterSeconds;

		[Tooltip("Duration of health bar pop-in animation (seconds)")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float healthBarPopInDuration;

		[Tooltip("Duration of health bar pop-out animation (seconds)")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float healthBarPopOutDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<float> currentHealth;

		private NetworkVariable<bool> isDead;

		private float maxHealth;

		private float maxPoise;

		private float poiseDamagePerHit;

		private float staggerCooldown;

		private float poiseRegenRate;

		private float poiseRegenDelay;

		private float staggerDuration;

		private float currentPoise;

		private float lastStaggerTime;

		private float lastPoiseHitTime;

		private INPCProfile npcProfile;

		private INPCAnimator npcAnimator;

		private INPCBrain npcBrain;

		private INPCMotor motor;

		private HighlightEffect highlightEffect;

		private VisualElement healthRoot;

		private VisualElement healthBarCurrent;

		private VisualElement healthBarTrail;

		private Label healthTextLabel;

		private float currentHealthWidth;

		private float targetHealthWidth;

		private float trailHealthWidth;

		private float targetTrailHealthWidth;

		private float trailDelayTimer;

		private float healthBarMaxWidth;

		private Camera localPlayerCamera;

		private float cameraSearchCooldown;

		private const float CAMERA_SEARCH_INTERVAL = 1f;

		private float lastDamageTime;

		private ulong lastAttackerClientId;

		private ulong lastAttackerNetworkId;

		private float healthBarHideTimer;

		private bool isHealthBarVisible;

		private bool isAnimatingHealthBar;

		private float predictedHealthValue;

		private float healthRegenRate;

		private float healthRegenDelay;

		public Action<float, float> OnHealthChanged;

		public Action<float, float, float> OnHealthDamaged;

		public Action<ulong, Vector3, float> OnDamagedByAttacker;

		public Action OnDeath;

		public Action OnStagger;

		public Action OnKnockedOut;

		public INPCProfile Profile => null;

		public float CurrentHealth => 0f;

		public float MaxHealth => 0f;

		public bool IsDead => false;

		public float HealthPercentage => 0f;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void ConfigureHitFlashEffect()
		{
		}

		private void FindLocalPlayerCamera()
		{
		}

		private void SetupWorldspaceUI()
		{
		}

		[IteratorStateMachine(typeof(_003CGetMaxWidthAfterLayout_003Ed__84))]
		private IEnumerator GetMaxWidthAfterLayout(VisualElement element, Action<float> callback)
		{
			return null;
		}

		private void UpdateHealthBarDisplay(float currentHP, float maxHP)
		{
		}

		private void UpdateHealthBarAnimations()
		{
		}

		private void ShowHealthBarAnimated()
		{
		}

		private void HideHealthBarAnimated()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateHealthBarScale_003Ed__89))]
		private IEnumerator AnimateHealthBarScale(Vector3 from, Vector3 to, float duration, LeanTweenType easeType)
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		public void TakeDamageServerRpc(float damageAmount, Vector3 attackerPosition, ulong attackerNetworkId)
		{
		}

		public void PredictDamage(float damageAmount, ulong attackerClientId)
		{
		}

		public void ApplyPoiseDamage(float poiseDamage)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ApplyPoiseDamageServerRpc(float poiseDamage)
		{
		}

		[ClientRpc]
		private void TriggerHitReactionClientRpc(int hitDirection)
		{
		}

		[ClientRpc]
		private void NotifyHealthDamagedClientRpc(float oldHealth, float newHealth, float damageTaken)
		{
		}

		private void TriggerDeath()
		{
		}

		internal static bool ShouldDiePermanently(bool knockoutInsteadOfDeath, bool guaranteedPermanentDeath, float permanentDeathChance, float roll)
		{
			return false;
		}

		private void TriggerKnockoutInsteadOfDeath()
		{
		}

		private void CheckBrawlWinAchievement()
		{
		}

		[IteratorStateMachine(typeof(_003CDespawnCoroutine_003Ed__100))]
		private IEnumerator DespawnCoroutine()
		{
			return null;
		}

		private void RegisterDeathWithResurrectionManager()
		{
		}

		void IDamageable.TakeDamage(float damage, Vector3 attackerPosition, ulong attackerNetworkId)
		{
		}

		public NetworkObject GetNetworkObject()
		{
			return null;
		}

		private void OnHealthValueChanged(float previousValue, float newValue)
		{
		}

		private void OnDeathStateChanged(bool previousValue, bool newValue)
		{
		}

		private void OnNPCDeath()
		{
		}

		[ClientRpc]
		private void TriggerStaggerClientRpc()
		{
		}

		[IteratorStateMachine(typeof(_003CApplyHitStunCoroutine_003Ed__108))]
		private IEnumerator ApplyHitStunCoroutine()
		{
			return null;
		}

		[ClientRpc]
		private void TurnOffStaggerClientRpc()
		{
		}

		public void RestoreHealthToMax()
		{
		}

		public void ResetHealth()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void HealServerRpc(float healAmount)
		{
		}

		public bool ProcessVehicleKill()
		{
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		public void KillInstantlyServerRpc()
		{
		}

		public void TriggerKnockout(float recoveryTime = 3f)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void TriggerKnockoutServerRpc(float recoveryTime = 3f)
		{
		}

		private void HandleRagdollRecovered()
		{
		}

		[ContextMenu("Test Hit Flash Effect")]
		private void TestHitFlashEffect()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_782841676(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2823154483(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_38412225(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_83930919(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2413687930(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3035535537(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3730627167(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_484517191(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2820726569(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
