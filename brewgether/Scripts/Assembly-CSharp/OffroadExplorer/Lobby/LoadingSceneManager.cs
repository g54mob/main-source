using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class LoadingSceneManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass36_0
		{
			public bool fadeOutComplete;

			internal void _003CLoadSceneWithTransition_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass36_1
		{
			public bool fadeInComplete;

			internal void _003CLoadSceneWithTransition_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass36_2
		{
			public bool fadeOutComplete;

			internal void _003CLoadSceneWithTransition_003Eb__2()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadSceneDirectWithFade_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoadingSceneManager _003C_003E4__this;

			public string sceneName;

			private AsyncOperation _003CsceneLoadOp_003E5__2;

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
			public _003CLoadSceneDirectWithFade_003Ed__37(int _003C_003E1__state)
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
		private sealed class _003CLoadSceneWithTransition_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoadingSceneManager _003C_003E4__this;

			public string sceneName;

			public bool useNetworkManager;

			private _003C_003Ec__DisplayClass36_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass36_1 _003C_003E8__2;

			private _003C_003Ec__DisplayClass36_2 _003C_003E8__3;

			private float _003CstartTime_003E5__2;

			private float _003CfadeElapsed_003E5__3;

			private float _003CserverLoadElapsed_003E5__4;

			private AsyncOperation _003CloadingSceneOp_003E5__5;

			private float _003CnetworkTimeout_003E5__6;

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
			public _003CLoadSceneWithTransition_003Ed__36(int _003C_003E1__state)
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
		private sealed class _003CSimulateClientLoadingProgress_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoadingSceneManager _003C_003E4__this;

			private float _003Cprogress_003E5__2;

			private float _003Ctimeout_003E5__3;

			private float _003Celapsed_003E5__4;

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
			public _003CSimulateClientLoadingProgress_003Ed__27(int _003C_003E1__state)
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

		[Header("Scene Names")]
		[SerializeField]
		private string loadingSceneName;

		[SerializeField]
		private string introSceneName;

		[SerializeField]
		private string customizerSceneName;

		[SerializeField]
		private string gameSceneName;

		[SerializeField]
		private string lobbySceneName;

		[Header("Timing")]
		[SerializeField]
		private float minimumLoadTime;

		[SerializeField]
		private float fadeInDelay;

		[Header("Loading Tips")]
		[Tooltip("Localization table containing the tip keys")]
		[SerializeField]
		private string tipTable;

		[Tooltip("Prefix for tip keys (e.g. TIP_ → TIP_01, TIP_02, ...)")]
		[SerializeField]
		private string tipKeyPrefix;

		[Tooltip("Total number of tips available")]
		[SerializeField]
		private int tipCount;

		[Header("UI References")]
		[SerializeField]
		private UIDocument uiDocument;

		private VisualElement root;

		private Label loadingText;

		private Label tipLabel;

		private Label progressLabel;

		private VisualElement progressBarFill;

		private Label progressPercentage;

		private bool isLoading;

		private string targetSceneName;

		private Coroutine currentLoadingCoroutine;

		public static LoadingSceneManager Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		[IteratorStateMachine(typeof(_003CSimulateClientLoadingProgress_003Ed__27))]
		private IEnumerator SimulateClientLoadingProgress()
		{
			return null;
		}

		private void SetupUI()
		{
		}

		public void LoadGameScene(bool useNetworkManager = false)
		{
		}

		public void LoadLobbyScene(bool useNetworkManager = false, bool skipLoadingScreen = false)
		{
		}

		public void LoadIntroScene(bool useNetworkManager = false)
		{
		}

		public void LoadGameSceneFromIntro()
		{
		}

		public void LoadCustomizerScene(bool useNetworkManager = false)
		{
		}

		public void LoadGameSceneFromCustomizer()
		{
		}

		public void LoadWithSaveCheck(bool useNetworkManager = false)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadSceneWithTransition_003Ed__36))]
		private IEnumerator LoadSceneWithTransition(string sceneName, bool useNetworkManager)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CLoadSceneDirectWithFade_003Ed__37))]
		private IEnumerator LoadSceneDirectWithFade(string sceneName)
		{
			return null;
		}

		private void ShowLoadingUI()
		{
		}

		private void HideLoadingUI()
		{
		}

		private void UpdateProgress(float progress)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
