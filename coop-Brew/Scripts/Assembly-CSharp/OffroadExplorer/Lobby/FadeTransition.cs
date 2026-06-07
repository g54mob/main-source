using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class FadeTransition : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FadeTransition _003C_003E4__this;

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
			public _003CFadeCoroutine_003Ed__13(int _003C_003E1__state)
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

		[Header("UI Toolkit")]
		[SerializeField]
		private UIDocument uiDocument;

		private VisualElement fadeOverlay;

		[Header("Canvas Group (Legacy)")]
		[SerializeField]
		private CanvasGroup canvasGroup;

		private Coroutine currentFade;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void FindFadeOverlay()
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

		[IteratorStateMachine(typeof(_003CFadeCoroutine_003Ed__13))]
		private IEnumerator FadeCoroutine(float targetAlpha, Action onComplete)
		{
			return null;
		}

		private float GetCurrentAlpha()
		{
			return 0f;
		}

		private void SetAlpha(float alpha)
		{
		}
	}
}
