using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class WagonBurnManager : NetworkBehaviour
	{
		private static WagonBurnManager _instance;

		[Header("Configuration")]
		[Tooltip("Wagon burn configuration asset")]
		[SerializeField]
		private WagonBurnConfig config;

		[Header("Camp Visuals")]
		[Tooltip("The root GameObject containing all camp visuals (wagons, tents, campfire, etc). This will be disabled/enabled when camp is suppressed/respawned. IMPORTANT: WagonBurnManager should be at scene root level, NOT a child of this.")]
		[SerializeField]
		private Transform campVisualsRoot;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<double> burnTimerStartTime;

		private NetworkVariable<int> fullyIgnitedCount;

		private NetworkVariable<bool> isCampSuppressed;

		private NetworkVariable<bool> campVisualsHiddenNet;

		private NetworkVariable<int> suppressionEndDayIndex;

		private readonly Dictionary<int, WagonBurnTarget> registeredWagons;

		private bool respawnPending;

		private float lastRespawnCheckTime;

		private const float RESPAWN_CHECK_INTERVAL = 2f;

		private bool timerActive;

		private float lastProximityCheckTime;

		private bool allPlayersOutsideRadius;

		private AudioSource burningSoundSource;

		private bool campVisualsHidden;

		public static WagonBurnManager Instance => null;

		public WagonBurnConfig Config => null;

		public bool IsTimerActive => false;

		public float RemainingBurnTime => 0f;

		public int FullyIgnitedCount => 0;

		public bool AllWagonsIgnited => false;

		public bool IsCampSuppressed => false;

		public bool AreCampVisualsHidden => false;

		public event Action OnAllWagonsIgnited
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

		public event Action OnBurnTimerExpired
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

		public event Action<int> OnCampSuppressed
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

		public event Action OnCampSuppressionEnded
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

		public void RegisterWagon(WagonBurnTarget wagon)
		{
		}

		public void UnregisterWagon(WagonBurnTarget wagon)
		{
		}

		public void RegisterMolotovHit(WagonBurnTarget wagon)
		{
		}

		private void StartBurnTimer()
		{
		}

		private void CheckTimerExpiry()
		{
		}

		private void HandleTimerExpired()
		{
		}

		private void HandleAllWagonsIgnited()
		{
		}

		private void SuppressCamp()
		{
		}

		public void EndSuppression()
		{
		}

		private void CheckSuppressionEndAndRespawn()
		{
		}

		private void CheckPendingRespawn()
		{
		}

		private bool TryRespawnCamp()
		{
			return false;
		}

		private void StartBurningSound()
		{
		}

		private void StopBurningSound()
		{
		}

		private void CheckPlayerProximity()
		{
		}

		public bool AreAllPlayersOutsideRadius()
		{
			return false;
		}

		public void HideCampVisuals()
		{
		}

		public void ShowCampVisuals()
		{
		}

		private void OnBurnTimerChanged(double previousValue, double newValue)
		{
		}

		private void OnIgnitedCountChanged(int previousValue, int newValue)
		{
		}

		private void OnSuppressionStateChanged(bool previousValue, bool newValue)
		{
		}

		private void OnCampVisualsHiddenChanged(bool previousValue, bool newValue)
		{
		}

		private void ApplyCampVisualsState(bool hidden)
		{
		}

		public int GetWagonHits(int wagonIndex)
		{
			return 0;
		}

		public void RestoreState(double timerStart, int[] wagonHits, bool suppressed, int endDayIndex = 0, bool visualsHidden = false)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		[ContextMenu("Burn All Wagons (Test)")]
		private void DebugBurnAllWagons()
		{
		}

		[ContextMenu("Reset All Wagons (Test)")]
		private void DebugResetAllWagons()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
