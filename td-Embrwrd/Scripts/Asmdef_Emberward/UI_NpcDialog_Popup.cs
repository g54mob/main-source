using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI;
using UnityEngine;

public class UI_NpcDialog_Popup : APopupWindow
{
	[CompilerGenerated]
	private sealed class _003CShowWindowForSeconds_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UI_NpcDialog_Popup _003C_003E4__this;

		public float seconds;

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
		public _003CShowWindowForSeconds_003Ed__13(int _003C_003E1__state)
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

	[SerializeField]
	private TextAnimator_TMP text_Content;

	private float duration;

	private float delay;

	private Vector3 targetPosition;

	private Vector3 offset2D;

	private Vector3 offset3D;

	private AMonsterBase targetMonster;

	private Transform targetTransform;

	protected void Update()
	{
	}

	public void SetupContent(string content, float duration, float delay, Vector3 targetPosition, Vector3 offset2D)
	{
	}

	public void BindToMonster(AMonsterBase monster, Vector3 offset3D)
	{
	}

	public void BindToTransform(Transform targetTransform, Vector3 offset3D)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	[IteratorStateMachine(typeof(_003CShowWindowForSeconds_003Ed__13))]
	private IEnumerator ShowWindowForSeconds(float seconds, float delay)
	{
		return null;
	}

	protected override void CloseWindowProc()
	{
	}

	private void UpdatePosition()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
