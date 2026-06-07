using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class TweenToLayoutGroup : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndDo_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TweenToLayoutGroup _003C_003E4__this;

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
			public _003CWaitAndDo_003Ed__14(int _003C_003E1__state)
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

		private Vector3 originalPos;

		private RectTransform newTarget;

		private RectTransform mRectTransform;

		private CanvasGroup cg;

		private float _delay;

		private float _duration;

		private Tween _tween;

		private Tween _cgTween;

		private Tween _scaleTween;

		private Vector3 _from;

		private bool _isWorldPos;

		private bool _autoComplete;

		public void TweenFromLocationToLayoutSpot(Transform sender, Vector3 from, float duration, float delay, bool isWorldPos = false)
		{
		}

		public void Complete()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndDo_003Ed__14))]
		private IEnumerator WaitAndDo()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
