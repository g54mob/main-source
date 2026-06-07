using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BrewGame.UI
{
	public class GlobalFadeOverlay : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeCoroutine_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GlobalFadeOverlay _003C_003E4__this;

			public float targetAlpha;

			public Action onComplete;

			private float _003CstartAlpha_003E5__2;

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
			public _003CFadeCoroutine_003Ed__28(int _003C_003E1__state)
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
		private sealed class _003CPostSceneGraceCoroutine_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GlobalFadeOverlay _003C_003E4__this;

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
			public _003CPostSceneGraceCoroutine_003Ed__35(int _003C_003E1__state)
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
		private sealed class _003CSafetyWatchdogCoroutine_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GlobalFadeOverlay _003C_003E4__this;

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
			public _003CSafetyWatchdogCoroutine_003Ed__32(int _003C_003E1__state)
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

		[Header("Fade Settings")]
		[SerializeField]
		private float fadeDuration;

		[SerializeField]
		private AnimationCurve fadeCurve;

		[Header("Safety")]
		[Tooltip("Maximum time the overlay is allowed to stay black without a FadeIn before it force-clears itself. Safety net — should be longer than any legitimate scene load.")]
		[SerializeField]
		private float safetyTimeoutSeconds;

		[Tooltip("After a new scene finishes loading, if the overlay is still black and no fade is running, force-clear after this many seconds. Catches 'scene loaded but nobody called FadeIn'.")]
		[SerializeField]
		private float postSceneGraceSeconds;

		[Header("References (Auto-created if null)")]
		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Image fadeImage;

		private Coroutine currentFade;

		private Coroutine safetyWatchdog;

		private Coroutine postSceneWatchdog;

		public static GlobalFadeOverlay Instance { get; private set; }

		public bool IsFading => false;

		public float CurrentAlpha => 0f;

		private void Awake()
		{
		}

		private void SetupUI()
		{
		}

		private void OnDestroy()
		{
		}

		public void FadeIn(Action onComplete = null)
		{
		}

		public void FadeOut(Action onComplete = null)
		{
		}

		public void SetFadeBlack()
		{
		}

		public void SetFadeClear()
		{
		}

		public void ForceClear()
		{
		}

		private void StartFade(float targetAlpha, Action onComplete)
		{
		}

		private void StopCurrentFade()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeCoroutine_003Ed__28))]
		private IEnumerator FadeCoroutine(float targetAlpha, Action onComplete)
		{
			return null;
		}

		private void SetAlpha(float alpha)
		{
		}

		private void StartSafetyWatchdog()
		{
		}

		private void StopSafetyWatchdog()
		{
		}

		[IteratorStateMachine(typeof(_003CSafetyWatchdogCoroutine_003Ed__32))]
		private IEnumerator SafetyWatchdogCoroutine()
		{
			return null;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void StopPostSceneWatchdog()
		{
		}

		[IteratorStateMachine(typeof(_003CPostSceneGraceCoroutine_003Ed__35))]
		private IEnumerator PostSceneGraceCoroutine()
		{
			return null;
		}

		public static void DoFadeIn(Action onComplete = null)
		{
		}

		public static void DoFadeOut(Action onComplete = null)
		{
		}

		public static void DoForceClear()
		{
		}
	}
}
