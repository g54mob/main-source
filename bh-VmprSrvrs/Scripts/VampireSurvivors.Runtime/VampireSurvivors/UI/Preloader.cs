using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class Preloader : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public Preloader _003C_003E4__this;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

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
		private sealed class _003CWait_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AsyncOperation s;

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
			public _003CWait_003Ed__18(int _003C_003E1__state)
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
		private sealed class _003CWaitAFrame_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action callback;

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
			public _003CWaitAFrame_003Ed__15(int _003C_003E1__state)
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

		[SerializeField]
		private List<GameObject> _Sprites;

		[SerializeField]
		private TextMeshProUGUI _StatusInfoText;

		[SerializeField]
		private TextMeshProUGUI _ExtraInfoText;

		[SerializeField]
		private Canvas _Canvas;

		private UnityServicesManager _unityServicesManager;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private AchievementManager _achievementManager;

		public static bool HideGraphics;

		[Inject]
		private void Construct(UnityServicesManager unityServicesManager)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[AsyncStateMachine(typeof(_003CInitAsync_003Ed__11))]
		private UniTaskVoid InitAsync()
		{
			return default(UniTaskVoid);
		}

		private void InitPlatform()
		{
		}

		private void UpdateText(string newText)
		{
		}

		private void UpdateExtraText(string newText)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAFrame_003Ed__15))]
		private IEnumerator WaitAFrame(Action callback)
		{
			return null;
		}

		private void LoadNextScene()
		{
		}

		private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
		}

		[IteratorStateMachine(typeof(_003CWait_003Ed__18))]
		private static IEnumerator Wait(AsyncOperation s)
		{
			return null;
		}
	}
}
