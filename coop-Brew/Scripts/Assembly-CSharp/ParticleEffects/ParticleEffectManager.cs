using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace ParticleEffects
{
	public class ParticleEffectManager : NetworkBehaviour
	{
		public enum ParticleType
		{
			PlayerHitImpact = 0,
			EnemyHitImpact = 1,
			BlockImpact = 2,
			PerfectBlockImpact = 3,
			Death = 4,
			Disappear = 5,
			JumpBoost = 6,
			HammerHitSpark = 7,
			ThrownBottleImpact = 8,
			MolotovExplosion = 9,
			DestructionTree = 10,
			DestructionMetal = 11,
			DestructionWood = 12,
			DestructionFence = 13,
			DestructionGeneric = 14,
			TrashbinLand = 15,
			LightFlickerSpark = 16,
			Resurrection = 17,
			GraveAppear = 18,
			GraveDisappear = 19,
			NPCAppear = 20,
			StarCollect = 21
		}

		[CompilerGenerated]
		private sealed class _003CReturnToPoolCoroutine_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public GameObject particle;

			public ParticleEffectManager _003C_003E4__this;

			public ParticleType type;

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
			public _003CReturnToPoolCoroutine_003Ed__46(int _003C_003E1__state)
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

		private static ParticleEffectManager _instance;

		[Header("Particle Prefabs")]
		[Tooltip("Hit impact when player gets hit by enemy")]
		[SerializeField]
		private GameObject playerHitImpactPrefab;

		[Tooltip("Hit impact when enemy gets hit by player")]
		[SerializeField]
		private GameObject enemyHitImpactPrefab;

		[Tooltip("Impact particles when player successfully blocks (sparks, shield flash, etc.)")]
		[SerializeField]
		private GameObject blockImpactPrefab;

		[Tooltip("Perfect block impact particles (flashy/golden for parries)")]
		[SerializeField]
		private GameObject perfectBlockImpactPrefab;

		[Tooltip("Death particle (dramatic explosion)")]
		[SerializeField]
		private GameObject deathPrefab;

		[Tooltip("Disappear particle (magic poof)")]
		[SerializeField]
		private GameObject disappearPrefab;

		[Header("Drink Effect Prefabs")]
		[Tooltip("Jump boost effect at player feet when jumping with beer boost")]
		[SerializeField]
		private GameObject jumpBoostPrefab;

		[Header("Building Effect Prefabs")]
		[Tooltip("Electrical spark effect on hammer hit when BuildTimeReduction buff is active")]
		[SerializeField]
		private GameObject hammerHitSparkPrefab;

		[Header("Throwable Effect Prefabs")]
		[Tooltip("Impact effect when a thrown bottle shatters")]
		[SerializeField]
		private GameObject thrownBottleImpactPrefab;

		[Tooltip("Fiery explosion effect when molotov hits (fire burst)")]
		[SerializeField]
		private GameObject molotovExplosionPrefab;

		[Header("Destruction Effect Prefabs")]
		[Tooltip("Tree destruction - leaves/branches flying")]
		[SerializeField]
		private GameObject destructionTreePrefab;

		[Tooltip("Metal destruction - sparks")]
		[SerializeField]
		private GameObject destructionMetalPrefab;

		[Tooltip("Wood destruction - splinters")]
		[SerializeField]
		private GameObject destructionWoodPrefab;

		[Tooltip("Fence destruction effect")]
		[SerializeField]
		private GameObject destructionFencePrefab;

		[Tooltip("Generic destruction effect (fallback)")]
		[SerializeField]
		private GameObject destructionGenericPrefab;

		[Header("Environment Effect Prefabs")]
		[Tooltip("Dust/poof effect when garbage lands in trashbin")]
		[SerializeField]
		private GameObject trashbinLandPrefab;

		[Tooltip("Electrical spark effect when city lights flicker")]
		[SerializeField]
		private GameObject lightFlickerSparkPrefab;

		[Header("Resurrection Effect Prefabs")]
		[Tooltip("Holy/magic burst when NPC is resurrected at grave")]
		[SerializeField]
		private GameObject resurrectionPrefab;

		[Tooltip("Ground eruption/dust when grave appears")]
		[SerializeField]
		private GameObject graveAppearPrefab;

		[Tooltip("Dissolve/sparkle when grave disappears after resurrection")]
		[SerializeField]
		private GameObject graveDisappearPrefab;

		[Tooltip("Magic spawn effect when resurrected NPC appears at grave")]
		[SerializeField]
		private GameObject npcAppearPrefab;

		[Header("Collectable Effect Prefabs")]
		[Tooltip("Sparkle/burst effect when player collects a skill star")]
		[SerializeField]
		private GameObject starCollectPrefab;

		[Header("Pool Configuration")]
		[Tooltip("Initial pool size per particle type")]
		[SerializeField]
		private int initialPoolSize;

		[Tooltip("Maximum pool size per particle type (prevents unlimited growth)")]
		[SerializeField]
		private int maxPoolSize;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<ParticleType, Queue<GameObject>> particlePools;

		private Dictionary<ParticleType, GameObject> particlePrefabs;

		private Dictionary<ParticleType, Transform> poolParents;

		private Dictionary<GameObject, ParticleType> activeParticles;

		private Dictionary<ParticleType, Vector3> prefabOriginalScales;

		private Dictionary<ParticleType, Quaternion> prefabOriginalRotations;

		private Dictionary<ParticleType, bool> prefabOriginalLoop;

		public static ParticleEffectManager Instance => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void InitializePools()
		{
		}

		private void PrewarmPool(ParticleType type, int count)
		{
		}

		public void SpawnParticle(ParticleType type, Vector3 position, Quaternion rotation)
		{
		}

		public void SpawnParticleLocal(ParticleType type, Vector3 position, Quaternion rotation, float minLifetime = 0f)
		{
		}

		public void SpawnParticleNetwork(ParticleType type, Vector3 position, Quaternion rotation, float minLifetime = 0f)
		{
		}

		[ClientRpc]
		private void SpawnParticleClientRpc(ParticleType type, Vector3 position, Quaternion rotation, float minLifetime = 0f)
		{
		}

		private GameObject GetPooledParticle(ParticleType type)
		{
			return null;
		}

		private void ReturnToPool(ParticleType type, GameObject particle, float delay)
		{
		}

		[IteratorStateMachine(typeof(_003CReturnToPoolCoroutine_003Ed__46))]
		private IEnumerator ReturnToPoolCoroutine(ParticleType type, GameObject particle, float delay)
		{
			return null;
		}

		private void OnGUI()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_403108121(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
