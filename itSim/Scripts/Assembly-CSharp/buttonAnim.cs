using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class buttonAnim : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CShrinkAndReturn_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public buttonAnim _003C_003E4__this;

		private Vector3 _003CshrinkTarget_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CShrinkAndReturn_003Ed__13(int _003C_003E1__state)
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

	public RectTransform buttonTransform;

	public float hoverScale;

	public float shrinkScale;

	public float hoverSpeed;

	public float shrinkSpeed;

	public float returnSpeed;

	private Vector3 originalScale;

	private Vector3 targetScale;

	private bool isHovered;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OnPointerEnter()
	{
	}

	public void OnPointerExit()
	{
	}

	[IteratorStateMachine(typeof(_003CShrinkAndReturn_003Ed__13))]
	private IEnumerator ShrinkAndReturn()
	{
		return null;
	}
}
