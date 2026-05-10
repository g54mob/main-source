using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyBox
{
	public static class TransformShakeExtension
	{
		[CompilerGenerated]
		private sealed class _003CTransformShakeCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform transform;

			public float bounds;

			public bool useUnscaledTime;

			public float shakeTime;

			public bool fadeBounds;

			private Vector3 _003CinitialPosition_003E5__2;

			private float _003CinitialBounds_003E5__3;

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
			public _003CTransformShakeCoroutine_003Ed__3(int _003C_003E1__state)
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

		private static Dictionary<Transform, Tuple<Coroutine, Vector3>> _activeShakingTransforms;

		public static void StartShake(this Transform transform, float time = 0.1f, float shakeBounds = 0.1f, bool useUnscaledTime = true, bool fadeBounds = false)
		{
		}

		public static void StopShake(this Transform transform)
		{
		}

		[IteratorStateMachine(typeof(_003CTransformShakeCoroutine_003Ed__3))]
		private static IEnumerator TransformShakeCoroutine(Transform transform, float shakeTime, float bounds, bool useUnscaledTime, bool fadeBounds)
		{
			return null;
		}

		private static void BreakShakeIfAny(Transform transform)
		{
		}
	}
}
