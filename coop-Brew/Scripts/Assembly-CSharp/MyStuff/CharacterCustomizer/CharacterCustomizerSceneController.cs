using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using OffroadExplorer.Lobby;
using Player.Customization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyStuff.CharacterCustomizer
{
	public class CharacterCustomizerSceneController : MonoBehaviour
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

		[CompilerGenerated]
		private sealed class _003CAutoReadyAndWaitForOthers_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerSceneController _003C_003E4__this;

			private float _003CwaitTimeout_003E5__2;

			private float _003CwaitElapsed_003E5__3;

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
			public _003CAutoReadyAndWaitForOthers_003Ed__40(int _003C_003E1__state)
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
		private sealed class _003CCustomizationFlow_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerSceneController _003C_003E4__this;

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
			public _003CCustomizationFlow_003Ed__27(int _003C_003E1__state)
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
		private sealed class _003CExitSequence_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerSceneController _003C_003E4__this;

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
			public _003CExitSequence_003Ed__29(int _003C_003E1__state)
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
		private sealed class _003CLateJoinConnectionTimeout_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerSceneController _003C_003E4__this;

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
			public _003CLateJoinConnectionTimeout_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CStart_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerSceneController _003C_003E4__this;

			private float _003CmetadataWaitTimeout_003E5__2;

			private float _003CmetadataWaitElapsed_003E5__3;

			private float _003CsyncWaitTimeout_003E5__4;

			private float _003CsyncWaitElapsed_003E5__5;

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
			public _003CStart_003Ed__25(int _003C_003E1__state)
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
		[Tooltip("The male character prefab to spawn for customization")]
		[SerializeField]
		private GameObject characterPrefab;

		[Tooltip("The female character prefab to spawn for customization (if null, uses characterPrefab with gender toggle)")]
		[SerializeField]
		private GameObject femaleCharacterPrefab;

		[Header("Gender Swap Animation")]
		[Tooltip("Duration of scale-down when hiding the old character")]
		[SerializeField]
		private float swapScaleDownDuration;

		[Tooltip("Duration of scale-up when showing the new character")]
		[SerializeField]
		private float swapScaleUpDuration;

		[Tooltip("Transform where character will be spawned")]
		[SerializeField]
		private Transform characterSpawnPoint;

		[Header("Controllers")]
		[Tooltip("Camera controller for zoom sequences")]
		[SerializeField]
		private CustomizerCameraController cameraController;

		[Tooltip("Wardrobe UI controller")]
		[SerializeField]
		private CustomizerWardrobeUI wardrobeUI;

		[Tooltip("Ready bar UI controller")]
		[SerializeField]
		private CustomizerReadyBarUI readyBarUI;

		[Tooltip("Fade transition controller (DEPRECATED - GlobalFadeOverlay handles fading now)")]
		[SerializeField]
		private FadeTransition fadeTransition;

		[Header("Timing")]
		[Tooltip("Delay before starting camera zoom after scene loads")]
		[SerializeField]
		private float startDelay;

		[Tooltip("When to start fade out during exit camera animation (0-1). Fade and scene loading start here.")]
		[Range(0.5f, 0.95f)]
		[SerializeField]
		private float exitFadeStartProgress;

		[Header("Multiplayer")]
		[Tooltip("Minimum time in scene before allowing scene skip (for network sync)")]
		[SerializeField]
		private float minimumWaitTime;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private CustomizerState currentState;

		private GameObject spawnedCharacter;

		private global::Player.Customization.CharacterCustomizer characterCustomizer;

		private bool allClientsLoadedIntoScene;

		private HashSet<ulong> clientsLoadedIntoScene;

		private float sceneLoadedTime;

		private bool hasStartedTransition;

		private bool _didCustomize;

		private bool isSwapping;

		private const float LATE_JOIN_CONNECTION_TIMEOUT = 15f;

		public CustomizerState CurrentState => default(CustomizerState);

		[IteratorStateMachine(typeof(_003CStart_003Ed__25))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CCustomizationFlow_003Ed__27))]
		private IEnumerator CustomizationFlow()
		{
			return null;
		}

		private void OnAllPlayersReady()
		{
		}

		[IteratorStateMachine(typeof(_003CExitSequence_003Ed__29))]
		private IEnumerator ExitSequence()
		{
			return null;
		}

		private void SpawnCharacter()
		{
		}

		private void DisableCharacterControls()
		{
		}

		private void ShowUI()
		{
		}

		private void HideUI()
		{
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

		private void CheckAllClientsLoaded()
		{
		}

		[IteratorStateMachine(typeof(_003CAutoReadyAndWaitForOthers_003Ed__40))]
		private IEnumerator AutoReadyAndWaitForOthers()
		{
			return null;
		}

		public void OnLateJoinConfirm()
		{
		}

		[IteratorStateMachine(typeof(_003CLateJoinConnectionTimeout_003Ed__43))]
		private IEnumerator LateJoinConnectionTimeout()
		{
			return null;
		}

		public global::Player.Customization.CharacterCustomizer GetCharacterCustomizer()
		{
			return null;
		}

		public void RefreshUI()
		{
		}

		public void SwapCharacterGender(bool isMale, Action<global::Player.Customization.CharacterCustomizer> onComplete = null)
		{
		}

		private void SpawnWithScaleUp(GameObject prefab, Transform spawnAt, Action<global::Player.Customization.CharacterCustomizer> onComplete)
		{
		}
	}
}
