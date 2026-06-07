using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BrewGame.Player;
using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyStuff.UI
{
	[RequireComponent(typeof(UIDocument))]
	public class PauseMenuController : MonoBehaviour, IUIPanel
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003COnSaveClicked_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public PauseMenuController _003C_003E4__this;

			private float _003CstartTime_003E5__2;

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
		private struct _003CQuitToMainMenu_003Ed__75 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public PauseMenuController _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
		private sealed class _003CWaitForCoroutineAsync_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PauseMenuController _003C_003E4__this;

			public IEnumerator coroutine;

			public TaskCompletionSource<bool> tcs;

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
			public _003CWaitForCoroutineAsync_003Ed__76(int _003C_003E1__state)
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

		[Header("=== Settings ===")]
		[Tooltip("Main menu scene name to load on quit")]
		[SerializeField]
		private string mainMenuSceneName;

		[Tooltip("Debug logging")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("=== Input ===")]
		[Tooltip("Reference to local player's InputReader (auto-found if null)")]
		[SerializeField]
		private InputReader inputReader;

		private UIDocument _uiDocument;

		private VisualElement _root;

		private VisualElement _screenPauseMain;

		private VisualElement _screenSettings;

		private Button _btnResume;

		private Button _btnSave;

		private Button _btnInviteFriends;

		private Button _btnSettings;

		private Button _btnWishlist;

		private Button _btnStuck;

		private Button _btnQuit;

		private Button _btnApplySettings;

		private Button _btnBackToPause;

		private Button _tabGraphics;

		private Button _tabAudio;

		private Button _tabControls;

		private VisualElement _tabContentGraphics;

		private VisualElement _tabContentAudio;

		private VisualElement _tabContentControls;

		private bool _isPaused;

		private bool _isInitialized;

		private bool _isQuitting;

		private int _lastEscFrame;

		private SampleCameraController _cameraController;

		private SettingsPanelController _settingsPanelController;

		private StuckRecoveryController _stuckRecovery;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FindCameraController()
		{
		}

		private void OnDestroy()
		{
		}

		private void CleanupCursorOnShutdown()
		{
		}

		private void FindInputReader()
		{
		}

		private void OnLocalInputReaderReady(InputReader reader)
		{
		}

		private void BindToInputReader(InputReader reader)
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void OnEscapePressed()
		{
		}

		private void InitializeUI()
		{
		}

		private void RegisterEvents()
		{
		}

		private void LocalizeUI()
		{
		}

		public void ShowPauseMenu()
		{
		}

		public void HidePauseMenu()
		{
		}

		public void TogglePause()
		{
		}

		private void UpdateSaveButtonVisibility()
		{
		}

		private void UpdateInviteFriendsVisibility()
		{
		}

		private void OnInviteFriendsClicked(ClickEvent evt)
		{
		}

		private void FindStuckRecoveryController()
		{
		}

		private void UpdateStuckButton()
		{
		}

		private void ShowPauseMainScreen()
		{
		}

		private void ShowSettingsScreen()
		{
		}

		private void ShowGraphicsTab()
		{
		}

		private void ShowAudioTab()
		{
		}

		private void ShowControlsTab()
		{
		}

		private void ResetButtonScales()
		{
		}

		private void OnResumeClicked(ClickEvent evt)
		{
		}

		private void OnSettingsClicked(ClickEvent evt)
		{
		}

		[AsyncStateMachine(typeof(_003COnSaveClicked_003Ed__66))]
		private void OnSaveClicked(ClickEvent evt)
		{
		}

		private void OnStuckClicked(ClickEvent evt)
		{
		}

		private void OnQuitClicked(ClickEvent evt)
		{
		}

		private void OnApplySettingsClicked(ClickEvent evt)
		{
		}

		private void OnBackToPauseClicked(ClickEvent evt)
		{
		}

		private void OnGraphicsTabClicked(ClickEvent evt)
		{
		}

		private void OnAudioTabClicked(ClickEvent evt)
		{
		}

		private void OnControlsTabClicked(ClickEvent evt)
		{
		}

		public void ResumePause()
		{
		}

		[AsyncStateMachine(typeof(_003CQuitToMainMenu_003Ed__75))]
		public void QuitToMainMenu()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForCoroutineAsync_003Ed__76))]
		private IEnumerator WaitForCoroutineAsync(IEnumerator coroutine, TaskCompletionSource<bool> tcs)
		{
			return null;
		}

		[ContextMenu("Show Pause Menu")]
		private void ContextMenuShowPause()
		{
		}

		[ContextMenu("Hide Pause Menu")]
		private void ContextMenuHidePause()
		{
		}
	}
}
