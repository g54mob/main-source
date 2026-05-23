using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EnhancedUI.EnhancedScroller
{
	public class Tween : MonoBehaviour
	{
		public enum TweenType
		{
			immediate = 0,
			linear = 1,
			spring = 2,
			easeInQuad = 3,
			easeOutQuad = 4,
			easeInOutQuad = 5,
			easeInCubic = 6,
			easeOutCubic = 7,
			easeInOutCubic = 8,
			easeInQuart = 9,
			easeOutQuart = 10,
			easeInOutQuart = 11,
			easeInQuint = 12,
			easeOutQuint = 13,
			easeInOutQuint = 14,
			easeInSine = 15,
			easeOutSine = 16,
			easeInOutSine = 17,
			easeInExpo = 18,
			easeOutExpo = 19,
			easeInOutExpo = 20,
			easeInCirc = 21,
			easeOutCirc = 22,
			easeInOutCirc = 23,
			easeInBounce = 24,
			easeOutBounce = 25,
			easeInOutBounce = 26,
			easeInBack = 27,
			easeOutBack = 28,
			easeInOutBack = 29,
			easeInElastic = 30,
			easeOutElastic = 31,
			easeInOutElastic = 32
		}

		[CompilerGenerated]
		private sealed class _003CTweenPosition_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TweenType tweenType;

			public float time;

			public Tween _003C_003E4__this;

			public float start;

			public float end;

			public Action<float, float> tweenUpdated;

			public Action tweenComplete;

			private float _003CnewPosition_003E5__2;

			private float _003ClastPosition_003E5__3;

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
			public _003CTweenPosition_003Ed__2(int _003C_003E1__state)
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

		private float _tweenTimeLeft;

		[IteratorStateMachine(typeof(_003CTweenPosition_003Ed__2))]
		public IEnumerator TweenPosition(TweenType tweenType, float time, float start, float end, Action<float, float> tweenUpdated, Action tweenComplete)
		{
			return null;
		}

		private float linear(float start, float end, float val)
		{
			return 0f;
		}

		private static float spring(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuad(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutCubic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuart(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutQuint(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutSine(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutExpo(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutCirc(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutBounce(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutBack(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInElastic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeOutElastic(float start, float end, float val)
		{
			return 0f;
		}

		private static float easeInOutElastic(float start, float end, float val)
		{
			return 0f;
		}
	}
}
