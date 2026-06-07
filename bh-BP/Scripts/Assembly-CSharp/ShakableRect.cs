using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ShakableRect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Shake_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ShakableRect _003C_003E4__this;

		public float amt;

		public float len;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Shake_003Ed__9(int _003C_003E1__state)
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

	[NonSerialized]
	public RectTransform Xfm;

	private Vector2 _defaultOffsetMin;

	private Vector2 _defaultOffsetMax;

	private bool _isShaking;

	private CoroutineHandle _shake;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void RefreshDefaultOffset()
	{
	}

	public void Shake(float amt, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_Shake_003Ed__9))]
	private IEnumerator<float> _Shake(float amt, float len)
	{
		return null;
	}

	public bool IsShaking()
	{
		return false;
	}
}
