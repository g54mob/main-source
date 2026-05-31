using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIAnimRectTransform : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMoveRect_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public float timeAnim;

		public EasingType easing;

		public RectTransform rect;

		public Vector2 from;

		public Vector2 to;

		private float _003Celapsed_003E5__2;

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
		public _003CMoveRect_003Ed__0(int _003C_003E1__state)
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

	[IteratorStateMachine(typeof(_003CMoveRect_003Ed__0))]
	public static IEnumerator MoveRect(RectTransform rect, Vector2 from, Vector2 to, float timeAnim, float delay, EasingType easing)
	{
		return null;
	}

	private static float ApplyEasing(float t, EasingType type)
	{
		return 0f;
	}
}
