using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class HostPlayerOptions : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitForPlayerOptions_003Ed__145 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HostPlayerOptions _003C_003E4__this;

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
			public _003CWaitForPlayerOptions_003Ed__145(int _003C_003E1__state)
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

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private CoherenceSync _coherenceSync;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		private byte[] _openedCoffins;

		private byte[] _unlockedArcanas;

		private byte[] _boughtPowerUps;

		private byte[] _disabledPowerUps;

		private byte[] _collectedItems;

		private List<byte[]> _unlockedWeaponsChunks;

		private List<byte[]> _collectedWeaponsChunks;

		private List<byte[]> _sealedWeaponsChunks;

		private List<byte[]> _onlineMultiplayerSelectionsChunks;

		private byte[] _sealedItems;

		private byte[] _unlockedStages;

		private List<byte[]> _hostPickupCountChunks;

		private List<byte[]> _hostAchievementsChunks;

		private byte[] _ascensionData;

		private int _currentAdventureType;

		private bool _openedCoffinsReady;

		private bool _unlockedArcanasReady;

		private bool _boughtPowerUpsReady;

		private bool _disabledPowerUpsReady;

		private bool _collectedItemsReady;

		private bool _unlockedWeaponsReady;

		private bool _collectedWeaponsReady;

		private bool _sealedWeaponsReady;

		private bool _sealedItemsReady;

		private bool _unlockedStagesReady;

		private bool _hostPickupCountReady;

		private bool _hostAchievementsReady;

		private bool _ascensionDataReady;

		private bool _adventureReady;

		private bool _onlineMultiplerSelectionsReady;

		public static HostPlayerOptions Instance { get; private set; }

		public bool IsReady { get; set; }

		[Sync]
		[OnValueSynced("OnStageSelectedRemotely")]
		public int SelectedStage { get; set; }

		[Sync]
		[OnValueSynced("OnBGMSelectedRemotely")]
		public int SelectedBGM { get; set; }

		public byte[] HostOpenedCoffins => null;

		public byte[] AvailableHostArcanas => null;

		public byte[] AvailableHostBoughtPowerUps => null;

		public byte[] HostDisabledPowerUps => null;

		public byte[] HostCollectedItems => null;

		public List<byte[]> HostUnlockedWeapons => null;

		public List<byte[]> HostCollectedWeapons => null;

		public List<byte[]> HostSealedWeapons => null;

		public List<byte[]> OnlineMultiplayerSelections => null;

		public byte[] HostSealedItems => null;

		public byte[] HostUnlockedStages => null;

		public List<byte[]> HostPickupCount => null;

		public List<byte[]> HostAchievements => null;

		public byte[] AscensionData => null;

		[Sync]
		public bool SelectedHyper
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedHurry
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedInverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool VisuallyInvert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedReapers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedMazzo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedRandomEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool HasKilledTheFinalBoss
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool HasSeenFinalFireworks
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedSharePassives
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public bool HasSeenDarkanaTransition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public int SelectedArcana
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public bool SelectedOnlineFreeRoam
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public int EME_NextBossBiome
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CurrentAdventureType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, AdventureManager adventureManager, DataManager dataManager)
		{
		}

		[Command]
		public void SendOpenedCoffins(byte[] openedCoffins)
		{
		}

		[Command]
		public void SendUnlockedArcanas(byte[] unlockedArcanas)
		{
		}

		[Command]
		public void SendBoughtPowerUps(byte[] boughtPowerUps)
		{
		}

		[Command]
		public void SendDisabledPowerUps(byte[] disabledPowerUps)
		{
		}

		[Command]
		public void SendCollectedItems(byte[] collectedItems)
		{
		}

		[Command]
		public void SendUnlockedWeaponsChunk(byte[] unlockedWeaponsChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendOnlineMultiplayerSelectionsChunk(byte[] onlineMultiplayerSelectionsChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendCollectedWeaponsChunk(byte[] collectedWeaponsChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendSealedWeaponsChunk(byte[] sealedWeaponsChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendSealedItems(byte[] sealedItems)
		{
		}

		[Command]
		public void SendUnlockedStages(byte[] unlockedStages)
		{
		}

		[Command]
		public void SendHostPickupCountChunk(byte[] hostPickupCountChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendHostAchievementsChunk(byte[] hostAchievementsChunk, int expectedChunks)
		{
		}

		[Command]
		public void SendAdventureType(int adventureType)
		{
		}

		[Command]
		public void SendAscensionData(byte[] ascensionData)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestSaveData()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnStageSelectedRemotely(int oldStage, int newStage)
		{
		}

		private void OnBGMSelectedRemotely(int oldBGM, int newBGM)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForPlayerOptions_003Ed__145))]
		private IEnumerator WaitForPlayerOptions()
		{
			return null;
		}

		private void SendHostSaveData()
		{
		}

		public void RefundGuestsPowerUps()
		{
		}

		[Command]
		public void SendRefundPowerUps()
		{
		}

		private void SendChunks(List<byte[]> chunks, Action<byte[], int> sendChunkCommand)
		{
		}

		private bool ReceivedAllData()
		{
			return false;
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}
	}
}
