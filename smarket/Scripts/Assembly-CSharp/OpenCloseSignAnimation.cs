using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpenCloseSignAnimation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public OpenCloseSignAnimation _003C_003E4__this;

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
		public _003CStart_003Ed__6(int _003C_003E1__state)
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

	[Header("Signs")]
	[SerializeField]
	private Transform m_OpenSign;

	[SerializeField]
	private Transform m_CloseSign;

	[Header("Animaton")]
	[SerializeField]
	private Vector3 m_DefaultScale;

	[SerializeField]
	private float m_PunchForce;

	[SerializeField]
	private float m_PunchDuration;

	[SerializeField]
	private float m_ScaleDuration;

	[IteratorStateMachine(typeof(_003CStart_003Ed__6))]
	private IEnumerator Start()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private void LoadStoreStatusSign()
	{
	}

	private void ChangeSign(bool opened)
	{
	}
}
