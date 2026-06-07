using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Synty.SidekickCharacters.API;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using Unity.Netcode;
using UnityEngine;

namespace Player.Customization.Sidekick
{
	public class SidekickCharacterCustomizer : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CBuildCharacterAsync_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCharacterCustomizer _003C_003E4__this;

			private string _003CsavedJson_003E5__2;

			private SidekickSaveData _003CsaveData_003E5__3;

			private float _003Ctimeout_003E5__4;

			private float _003Celapsed_003E5__5;

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
			public _003CBuildCharacterAsync_003Ed__33(int _003C_003E1__state)
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
		private sealed class _003CPreWarmNeededParts_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickSaveData saveData;

			public SidekickCharacterCustomizer _003C_003E4__this;

			private List<ResourceRequest> _003CasyncOps_003E5__2;

			private bool _003CallDone_003E5__3;

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
			public _003CPreWarmNeededParts_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CRebuildCharacterAsync_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCharacterCustomizer _003C_003E4__this;

			public SidekickSaveData saveData;

			private SidekickSaveData _003Ccurrent_003E5__2;

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
			public _003CRebuildCharacterAsync_003Ed__39(int _003C_003E1__state)
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
		private sealed class _003CRebuildCharacterSteppedCoroutine_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCharacterCustomizer _003C_003E4__this;

			public SidekickSaveData saveData;

			private Stopwatch _003CphaseTimer_003E5__2;

			private List<SkinnedMeshRenderer> _003CpartsToUse_003E5__3;

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
			public _003CRebuildCharacterSteppedCoroutine_003Ed__41(int _003C_003E1__state)
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
		private sealed class _003CRunRebuildWithGlobalMutex_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCharacterCustomizer _003C_003E4__this;

			public SidekickSaveData saveData;

			private Stopwatch _003Cstopwatch_003E5__2;

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
			public _003CRunRebuildWithGlobalMutex_003Ed__42(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const string PREFS_KEY = "SidekickCharacterJson";

		private const string MODEL_NAME = "SidekickModel";

		[Header("Sidekick Setup")]
		[Tooltip("Animator controller to apply to the built character")]
		[SerializeField]
		private RuntimeAnimatorController animatorController;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("When true, builds a default character if no save data exists. Use this when testing by loading MainScene directly.")]
		[SerializeField]
		private bool buildDefaultIfEmpty;

		private NetworkVariable<CharacterJsonPayload> characterDataJson;

		private SidekickSaveData _cachedSaveData;

		private SidekickRuntime _runtime;

		private DatabaseManager _dbManager;

		private bool _isInitialized;

		private GameObject _currentModel;

		private bool _initialBuildInProgress;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _partLibrary;

		private Coroutine _pendingAsyncRebuild;

		private SidekickSaveData _queuedRebuildSaveData;

		private bool _isRebuilding;

		private static bool s_rebuildInProgressGlobal;

		private static int s_rebuildQueueDepth;

		public SidekickRuntime Runtime => null;

		public DatabaseManager DBManager => null;

		public bool IsInitialized => false;

		public Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> PartLibrary => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action OnCharacterRebuilt
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

		public SidekickSaveData GetSaveData()
		{
			return null;
		}

		public string GetSelectedPart(CharacterPartType partType)
		{
			return null;
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CBuildCharacterAsync_003Ed__33))]
		private IEnumerator BuildCharacterAsync()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPreWarmNeededParts_003Ed__34))]
		private IEnumerator PreWarmNeededParts(SidekickSaveData saveData)
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		public static void CloneTexturesStatic(Material mat)
		{
		}

		private static void CloneTextures(Material mat)
		{
		}

		public void InitializeRuntime()
		{
		}

		[IteratorStateMachine(typeof(_003CRebuildCharacterAsync_003Ed__39))]
		private IEnumerator RebuildCharacterAsync(SidekickSaveData saveData)
		{
			return null;
		}

		private void StartAsyncRebuild(SidekickSaveData saveData)
		{
		}

		[IteratorStateMachine(typeof(_003CRebuildCharacterSteppedCoroutine_003Ed__41))]
		private IEnumerator RebuildCharacterSteppedCoroutine(SidekickSaveData saveData)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRunRebuildWithGlobalMutex_003Ed__42))]
		private IEnumerator RunRebuildWithGlobalMutex(SidekickSaveData saveData)
		{
			return null;
		}

		public void RebuildCharacter(SidekickSaveData saveData)
		{
		}

		private void FullRebuild(List<SkinnedMeshRenderer> partsToUse)
		{
		}

		private void SetupRootAnimator()
		{
		}

		private List<SkinnedMeshRenderer> GetDefaultParts()
		{
			return null;
		}

		private void ApplyColors(SidekickSaveData saveData)
		{
		}

		private static void EnsureDefaultEyeIris(List<SidekickSaveData.ColorEntry> colors, List<SidekickColorProperty> allProperties)
		{
		}

		public void ApplyAndSync(SidekickSaveData saveData)
		{
		}

		[ServerRpc]
		private void ApplyDataServerRpc(string json)
		{
		}

		private void OnCharacterDataJsonChanged(CharacterJsonPayload previous, CharacterJsonPayload current)
		{
		}

		public void PreviewCharacter(SidekickSaveData saveData)
		{
		}

		public void SaveToPlayerPrefs(SidekickSaveData saveData)
		{
		}

		public void LoadFromPlayerPrefs()
		{
		}

		public static SidekickSaveData LoadSaveDataFromPlayerPrefs()
		{
			return null;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private static bool HasMeaningfulData(SidekickSaveData data)
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1762934858(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
