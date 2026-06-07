using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.SaveSystem.Data;
using BrewGame.SaveSystem.Serialization;
using BrewGame.SaveSystem.Storage;
using InventorySystem;
using UnityEngine;

namespace BrewGame.SaveSystem.Core
{
	public class SaveGameManager : MonoBehaviour
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CCheckAndMarkIntroCompleted_003Ed__95 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CDeleteSlotAsync_003Ed__92 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int slotIndex;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CEarlySaveAfterPlayersSpawn_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SaveGameManager _003C_003E4__this;

			private float _003CmaxWait_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CEarlySaveAfterPlayersSpawn_003Ed__63(int _003C_003E1__state)
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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CForceSteamSyncAsync_003Ed__105 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CGetAllSlotMetadataAsync_003Ed__74 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveSlotMetadata[]> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<SaveSlotMetadata[]> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLoadGameDataAsync_003Ed__87 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveGameData> _003C_003Et__builder;

			public int slotIndex;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLoadGameDataInternalAsync_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SaveGameData> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			public string profileId;

			public int slotIndex;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLoadTestSaveAsync_003Ed__65 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<SaveGameData> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CRestoreFromBackupAsync_003Ed__103 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private bool _003Csuccess_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<SaveGameData> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRestoreWorldStateDelayed_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SaveGameManager _003C_003E4__this;

			private float _003CmaxWait_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CRestoreWorldStateDelayed_003Ed__62(int _003C_003E1__state)
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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CSaveGameAsync_003Ed__76 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			public bool isAutoSave;

			private float _003CindicatorStartTime_003E5__2;

			private bool _003Csuccess_003E5__3;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CSetActiveSlotAsync_003Ed__72 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public int slotIndex;

			public SaveGameManager _003C_003E4__this;

			public bool isNewGame;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<SaveGameData> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CStart_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public SaveGameManager _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Header("Auto-Save Settings")]
		[SerializeField]
		private float autoSaveIntervalMinutes;

		[SerializeField]
		private bool enableAutoSave;

		[Header("Debug / Testing")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("Use a separate test save slot (doesn't affect player's 3 save slots)")]
		[SerializeField]
		private bool useTestSave;

		private const string TEST_PROFILE_ID = "__TEST_SAVE__";

		private const int TEST_SLOT_INDEX = 0;

		private string _activeProfileId;

		private int _activeSlotIndex;

		private SaveGameData _currentSaveData;

		private CompositeStorageProvider _storageProvider;

		private float _autoSaveTimer;

		private float _sessionPlaytimeAccumulator;

		private bool _isSaving;

		private bool _isLoading;

		private bool _saveQueued;

		private bool _isLoadingSlot;

		private bool _hasRestoredFromSlot;

		private bool _worldStateRestored;

		public static SaveGameManager Instance { get; private set; }

		public string ActiveProfileId => null;

		public int ActiveSlotIndex => 0;

		public bool HasActiveSlot => false;

		public bool IsSaving => false;

		public bool IsLoading => false;

		public bool WorldStateRestored => false;

		public float AutoSaveIntervalMinutes
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool EnableAutoSave
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action OnSaveStarted
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

		public event Action OnSaveCompleted
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

		public event Action<string> OnSaveFailed
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

		public event Action OnLoadStarted
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

		public event Action OnLoadCompleted
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

		public event Action<string> OnLoadFailed
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

		public event Action<int> OnSlotChanged
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

		[IteratorStateMachine(typeof(_003CRestoreWorldStateDelayed_003Ed__62))]
		private IEnumerator RestoreWorldStateDelayed()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEarlySaveAfterPlayersSpawn_003Ed__63))]
		private IEnumerator EarlySaveAfterPlayersSpawn()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CStart_003Ed__64))]
		private void Start()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadTestSaveAsync_003Ed__65))]
		public Task<bool> LoadTestSaveAsync()
		{
			return null;
		}

		private void SetPendingStatesFromSaveData()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadGameDataInternalAsync_003Ed__67))]
		private Task<SaveGameData> LoadGameDataInternalAsync(string profileId, int slotIndex)
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public string GetProfileId()
		{
			return null;
		}

		public bool IsHostOrSolo()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CSetActiveSlotAsync_003Ed__72))]
		public Task<bool> SetActiveSlotAsync(int slotIndex, bool isNewGame = false)
		{
			return null;
		}

		public void ClearActiveSlot()
		{
		}

		[AsyncStateMachine(typeof(_003CGetAllSlotMetadataAsync_003Ed__74))]
		public Task<SaveSlotMetadata[]> GetAllSlotMetadataAsync()
		{
			return null;
		}

		public bool SlotExists(int slotIndex)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CSaveGameAsync_003Ed__76))]
		public Task<bool> SaveGameAsync(bool isAutoSave = false)
		{
			return null;
		}

		private void CollectGameState()
		{
		}

		private void UpdateHostPlayerData()
		{
		}

		private void UpdateClientPlayerData()
		{
		}

		private string GetClientSteamId(ulong clientId)
		{
			return null;
		}

		private void RefreshLobbyKnownPlayers()
		{
		}

		private void CaptureInventoryToPlayerData(GameObject playerObject, InventoryManager inventoryManager, PlayerSaveData playerData)
		{
		}

		private void UpdateWorldData()
		{
		}

		private void UpdateManagerData()
		{
		}

		private void PopulateCatalystDiscoveryFromComponentState()
		{
		}

		private void PopulateQuestDataFromComponentState()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadGameDataAsync_003Ed__87))]
		public Task<SaveGameData> LoadGameDataAsync(int slotIndex)
		{
			return null;
		}

		public void ApplyLoadedData()
		{
		}

		private void ApplyPlayerData()
		{
		}

		private void ApplyWorldData()
		{
		}

		private void ApplyManagerData()
		{
		}

		[AsyncStateMachine(typeof(_003CDeleteSlotAsync_003Ed__92))]
		public Task<bool> DeleteSlotAsync(int slotIndex)
		{
			return null;
		}

		public bool HasIntroPlayed()
		{
			return false;
		}

		public void MarkIntroPlayed()
		{
		}

		[AsyncStateMachine(typeof(_003CCheckAndMarkIntroCompleted_003Ed__95))]
		private Task CheckAndMarkIntroCompleted()
		{
			return null;
		}

		public SaveGameData GetCurrentSaveData()
		{
			return null;
		}

		public PlayerSaveData GetOrCreatePlayerData(string steamId, string playerName)
		{
			return null;
		}

		public PlayerSaveData GetPlayerData(string steamId)
		{
			return null;
		}

		private object ConvertJTokenToNative(object value)
		{
			return null;
		}

		private Dictionary<string, Dictionary<string, object>> ConvertStatesToNative(SerializableDictionary<string, SerializableDictionary<string, object>> componentStates)
		{
			return null;
		}

		private string GetPlayerName()
		{
			return null;
		}

		public CompositeStorageProvider GetStorageProvider()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRestoreFromBackupAsync_003Ed__103))]
		public Task<bool> RestoreFromBackupAsync()
		{
			return null;
		}

		public bool BackupExists()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CForceSteamSyncAsync_003Ed__105))]
		public Task<bool> ForceSteamSyncAsync()
		{
			return null;
		}

		public void SetDebugLogging(bool enabled)
		{
		}
	}
}
