using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ComputerChangingCanvasPosition : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTransitionCanvas_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerChangingCanvasPosition _003C_003E4__this;

		public ComputerChangingCanvasPositionData targetData;

		private Vector3 _003CstartPosition_003E5__2;

		private Quaternion _003CstartRotation_003E5__3;

		private Vector3 _003CstartScale_003E5__4;

		private Vector3 _003CtargetPosition_003E5__5;

		private Quaternion _003CtargetRotation_003E5__6;

		private Vector3 _003CtargetScale_003E5__7;

		private float _003CelapsedTime_003E5__8;

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
		public _003CTransitionCanvas_003Ed__6(int _003C_003E1__state)
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

	public RectTransform canvas;

	public List<ComputerChangingCanvasPositionData> CanvasDisplayPositionData;

	public float transitionDuration;

	private Coroutine transitionCoroutine;

	private int nowID;

	public void ChangedCanvas(int id)
	{
	}

	[IteratorStateMachine(typeof(_003CTransitionCanvas_003Ed__6))]
	private IEnumerator TransitionCanvas(ComputerChangingCanvasPositionData targetData)
	{
		return null;
	}

	private void Update()
	{
	}

	private bool IsPointerMouse()
	{
		return false;
	}
}
