using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace BrewGame.Intro
{
	public class AutoSaveSplashController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CLoadSceneThenFadeOut_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutoSaveSplashController _003C_003E4__this;

			private float _003CfadeElapsed_003E5__2;

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
			public _003CLoadSceneThenFadeOut_003Ed__27(int _003C_003E1__state)
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
		private sealed class _003CPulseSkipHint_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutoSaveSplashController _003C_003E4__this;

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
			public _003CPulseSkipHint_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CStart_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutoSaveSplashController _003C_003E4__this;

			private float _003CwaitTime_003E5__2;

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
			public _003CStart_003Ed__22(int _003C_003E1__state)
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
		private sealed class _003CWaitForSceneLoadedThenStartTimer_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutoSaveSplashController _003C_003E4__this;

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
			public _003CWaitForSceneLoadedThenStartTimer_003Ed__23(int _003C_003E1__state)
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

		[Header("Scene Transition")]
		[Tooltip("Name of the next scene to load after splash")]
		[SerializeField]
		private string nextSceneName;

		[Header("UI")]
		[Tooltip("UIDocument component for the splash screen")]
		[SerializeField]
		private UIDocument splashDocument;

		[Tooltip("Beer icon sprite (same PlainBeer_Icon used by GlobalLoadingIndicator)")]
		[SerializeField]
		private Sprite beerIconSprite;

		[Header("Timing")]
		[Tooltip("How long to display the splash (seconds)")]
		[SerializeField]
		private float displayDuration;

		[Tooltip("Fade out duration (seconds)")]
		[SerializeField]
		private float fadeOutDuration;

		[Tooltip("Maximum time to wait for LobbyReadyCoordinator event (fallback if event doesn't fire)")]
		[SerializeField]
		private float maxLobbyWaitTime;

		[Header("Animation Settings (EXACT match to GlobalLoadingIndicator)")]
		[Tooltip("Duration of slow start phase (0° to 90°) - easeInQuad")]
		[SerializeField]
		private float slowStartDuration;

		[Tooltip("Duration of fast middle phase (90° to 270°) - linear")]
		[SerializeField]
		private float fastMiddleDuration;

		[Tooltip("Duration of overshoot settle phase (270° to 360°) - easeOutBack")]
		[SerializeField]
		private float overshootDuration;

		[Header("Input")]
		[Tooltip("InputReader reference (auto-finds if not assigned)")]
		[SerializeField]
		private InputReader inputReader;

		[Header("Sorting")]
		[Tooltip("Sort order for the splash UI - must be higher than lobby UI to stay on top")]
		[SerializeField]
		private int sortingOrder;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement _splashContainer;

		private VisualElement _beerIcon;

		private VisualElement _progressFill;

		private Label _skipHint;

		private bool _isComplete;

		private bool _isAnimating;

		private bool _timerStarted;

		private float _elapsedTime;

		private bool _lobbyReady;

		private GameObject _rotationProxy;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__22))]
		private IEnumerator Start()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitForSceneLoadedThenStartTimer_003Ed__23))]
		private IEnumerator WaitForSceneLoadedThenStartTimer()
		{
			return null;
		}

		private void Update()
		{
		}

		private void OnEscapePressed()
		{
		}

		private void OnLobbyReady()
		{
		}

		[IteratorStateMachine(typeof(_003CLoadSceneThenFadeOut_003Ed__27))]
		private IEnumerator LoadSceneThenFadeOut()
		{
			return null;
		}

		private void LoadNextSceneImmediate()
		{
		}

		private void StartBarrelRollAnimation()
		{
		}

		private void StopBarrelRollAnimation()
		{
		}

		private void PlayBarrelRollSequence()
		{
		}

		private void UpdateIconRotation()
		{
		}

		[IteratorStateMachine(typeof(_003CPulseSkipHint_003Ed__34))]
		private IEnumerator PulseSkipHint()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
