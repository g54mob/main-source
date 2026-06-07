using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Player.Customization.Sidekick;
using Synty.SidekickCharacters.API;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyStuff.CharacterCustomizer.Sidekick
{
	public class SidekickCustomizerSceneController : MonoBehaviour
	{
		public enum CustomizerState
		{
			Loading = 0,
			CameraZoomIn = 1,
			Customizing = 2,
			WaitingForPlayers = 3,
			CameraZoomOut = 4,
			Transitioning = 5
		}

		public enum CameraView
		{
			Body = 0,
			Head = 1,
			Feet = 2,
			Back = 3
		}

		[CompilerGenerated]
		private sealed class _003CAutoReadyAndWaitForOthers_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

			private float _003CwaitElapsed_003E5__2;

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
			public _003CAutoReadyAndWaitForOthers_003Ed__84(int _003C_003E1__state)
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
		private sealed class _003CCustomizationFlow_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

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
			public _003CCustomizationFlow_003Ed__58(int _003C_003E1__state)
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
		private sealed class _003CExitSequence_003Ed__78 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

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
			public _003CExitSequence_003Ed__78(int _003C_003E1__state)
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
		private sealed class _003CIdleCycleRoutine_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

			public Animator animator;

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
			public _003CIdleCycleRoutine_003Ed__72(int _003C_003E1__state)
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
		private sealed class _003CInitializeSidekickAsync_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

			private Stopwatch _003Csw_003E5__2;

			private GameObject _003CbaseModel_003E5__3;

			private Material _003CbaseMaterialAsset_003E5__4;

			private Material _003CbaseMaterial_003E5__5;

			private Task _003Ctask_003E5__6;

			private float _003CtaskTimeout_003E5__7;

			private float _003CtaskElapsed_003E5__8;

			private List<(SidekickPart part, ResourceRequest request)> _003CasyncOps_003E5__9;

			private int _003Ccompleted_003E5__10;

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
			public _003CInitializeSidekickAsync_003Ed__52(int _003C_003E1__state)
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
		private sealed class _003CLateJoinConnectionTimeout_003Ed__85 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CLateJoinConnectionTimeout_003Ed__85(int _003C_003E1__state)
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
		private sealed class _003CPlayGlowEffect_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject model;

			public SidekickCustomizerSceneController _003C_003E4__this;

			private Material _003CglowMat_003E5__2;

			private Color _003CglowColor_003E5__3;

			private List<(Renderer r, Material[] mats)> _003CoriginalMaterials_003E5__4;

			private float _003Celapsed_003E5__5;

			private float _003Cduration_003E5__6;

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
			public _003CPlayGlowEffect_003Ed__70(int _003C_003E1__state)
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
		private sealed class _003CStart_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickCustomizerSceneController _003C_003E4__this;

			private float _003CmetadataWaitTimeout_003E5__2;

			private float _003CmetadataWaitElapsed_003E5__3;

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
			public _003CStart_003Ed__49(int _003C_003E1__state)
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

		[Header("Character Setup")]
		[Tooltip("Transform where character will be spawned")]
		[SerializeField]
		private Transform characterSpawnPoint;

		[Tooltip("Animator controller for idle pose (use Custimizer_Idle.controller). Both rigs are Humanoid so Unity retargets automatically. The Sidekick avatar is copied from SK_BaseModel by the API.")]
		[SerializeField]
		private RuntimeAnimatorController characterAnimatorController;

		[Header("Idle Animation")]
		[Tooltip("Integer parameter name in the animator for idle variant")]
		[SerializeField]
		private string idleIndexParam;

		[Tooltip("Number of idle variants (excluding base idle)")]
		[SerializeField]
		private int idleVariantCount;

		[Tooltip("Seconds between idle variants (min)")]
		[SerializeField]
		private float idleIntervalMin;

		[Tooltip("Seconds between idle variants (max)")]
		[SerializeField]
		private float idleIntervalMax;

		[Tooltip("How long the variant plays before resetting")]
		[SerializeField]
		private float idleResetDelay;

		[Header("Appear Effect")]
		[Tooltip("Duration of the subtle scale pop when outfit parts change")]
		[SerializeField]
		private float appearScaleDuration;

		[Header("Drag to Rotate")]
		[Tooltip("Speed of character rotation when dragging")]
		[SerializeField]
		private float rotateSpeed;

		[Header("Camera Close-Ups")]
		[Tooltip("Offset from character position for the head close-up camera")]
		[SerializeField]
		private Vector3 headCameraOffset;

		[Tooltip("Where the head camera looks at")]
		[SerializeField]
		private Vector3 headLookAtOffset;

		[Tooltip("Offset from character for feet close-up")]
		[SerializeField]
		private Vector3 feetCameraOffset;

		[Tooltip("Where the feet camera looks at")]
		[SerializeField]
		private Vector3 feetLookAtOffset;

		[Tooltip("Duration of the camera transition")]
		[SerializeField]
		private float cameraTransitionDuration;

		[Tooltip("Rotation duration when turning character to show back")]
		[SerializeField]
		private float backRotationDuration;

		[Header("Controllers")]
		[SerializeField]
		private CustomizerCameraController cameraController;

		[SerializeField]
		private SidekickCustomizerWardrobeUI wardrobeUI;

		[SerializeField]
		private CustomizerReadyBarUI readyBarUI;

		[Header("Timing")]
		[SerializeField]
		private float startDelay;

		[Range(0.5f, 0.95f)]
		[SerializeField]
		private float exitFadeStartProgress;

		[Header("Multiplayer")]
		[SerializeField]
		private float minimumWaitTime;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private CustomizerState currentState;

		private GameObject _characterModel;

		private SidekickRuntime _runtime;

		private DatabaseManager _dbManager;

		private SidekickSaveData _currentSaveData;

		private bool hasStartedTransition;

		private bool _didCustomize;

		private HashSet<ulong> clientsLoadedIntoScene;

		private float sceneLoadedTime;

		private bool _isDragging;

		private float _lastMouseX;

		private Vector3 _bodyViewPosition;

		private Quaternion _bodyViewRotation;

		private int _cameraTweenId;

		private Coroutine _appearEffectCoroutine;

		private bool _playAppearEffect;

		private List<string> _changedPartNames;

		private Coroutine _idleCycleCoroutine;

		private CameraView _currentView;

		private Quaternion _savedCharacterRotation;

		private int _characterRotTweenId;

		public CustomizerState CurrentState => default(CustomizerState);

		public SidekickRuntime Runtime => null;

		public DatabaseManager DBManager => null;

		public SidekickSaveData CurrentSaveData => null;

		[IteratorStateMachine(typeof(_003CStart_003Ed__49))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CInitializeSidekickAsync_003Ed__52))]
		private IEnumerator InitializeSidekickAsync()
		{
			return null;
		}

		private void BuildCharacter()
		{
		}

		private List<SkinnedMeshRenderer> GetDefaultParts(Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> partLibrary)
		{
			return null;
		}

		private void SaveCurrentPartsToSaveData(List<SkinnedMeshRenderer> partsToUse, Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> partLibrary)
		{
		}

		private void ApplyColors()
		{
		}

		private static void EnsureDefaultEyeIris(List<SidekickSaveData.ColorEntry> colors, List<SidekickColorProperty> allProperties)
		{
		}

		[IteratorStateMachine(typeof(_003CCustomizationFlow_003Ed__58))]
		private IEnumerator CustomizationFlow()
		{
			return null;
		}

		public void OnCustomizationChanged(SidekickSaveData saveData, bool playEffect = false, List<string> changedPartNames = null, bool colorOnly = false)
		{
		}

		public GameObject GetCharacterModel()
		{
			return null;
		}

		public void SetCameraView(CameraView view)
		{
		}

		public void SetHeadCloseUp(bool closeUp)
		{
		}

		private void RotateCharacter(Quaternion targetRot)
		{
		}

		private void AnimateCamera(Camera cam, Vector3 targetPos, Quaternion targetRot)
		{
		}

		private void PlayAppearEffect(GameObject model)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayGlowEffect_003Ed__70))]
		private IEnumerator PlayGlowEffect(GameObject model)
		{
			return null;
		}

		private void StartIdleCycle(Animator animator)
		{
		}

		[IteratorStateMachine(typeof(_003CIdleCycleRoutine_003Ed__72))]
		private IEnumerator IdleCycleRoutine(Animator animator)
		{
			return null;
		}

		public void OnLateJoinConfirm()
		{
		}

		private void ShowUI()
		{
		}

		private void HideUI()
		{
		}

		private void SaveCustomization()
		{
		}

		private void OnAllPlayersReady()
		{
		}

		[IteratorStateMachine(typeof(_003CExitSequence_003Ed__78))]
		private IEnumerator ExitSequence()
		{
			return null;
		}

		private bool ShouldSkipCustomization()
		{
			return false;
		}

		private void TransitionToMainScene()
		{
		}

		private void SetupNetworkEvents()
		{
		}

		private void CleanupNetworkEvents()
		{
		}

		private void OnNetworkSceneLoadCompleted(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
		{
		}

		[IteratorStateMachine(typeof(_003CAutoReadyAndWaitForOthers_003Ed__84))]
		private IEnumerator AutoReadyAndWaitForOthers()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLateJoinConnectionTimeout_003Ed__85))]
		private IEnumerator LateJoinConnectionTimeout()
		{
			return null;
		}
	}
}
