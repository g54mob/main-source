using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class SceneTransitionOrchestrator : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public bool fadeDone;

			internal void _003CRunTransition_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRunTransition_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneTransitionOrchestrator _003C_003E4__this;

			public string sceneName;

			public SceneTransitionOptions opts;

			private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

			public Action onComplete;

			private bool _003Cerrored_003E5__2;

			private float _003Cwaited_003E5__3;

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
			public _003CRunTransition_003Ed__14(int _003C_003E1__state)
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

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static SceneTransitionOrchestrator Instance { get; private set; }

		public bool IsTransitioning { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public static SceneTransitionOrchestrator EnsureInstance()
		{
			return null;
		}

		public void TransitionTo(string sceneName, SceneTransitionOptions opts = default(SceneTransitionOptions), Action onComplete = null)
		{
		}

		public void ForceAbort()
		{
		}

		[IteratorStateMachine(typeof(_003CRunTransition_003Ed__14))]
		private IEnumerator RunTransition(string sceneName, SceneTransitionOptions opts, Action onComplete)
		{
			return null;
		}

		private static void ForceCleanup()
		{
		}
	}
}
