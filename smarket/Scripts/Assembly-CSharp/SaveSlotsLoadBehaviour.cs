using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveSlotsLoadBehaviour : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitForDelete_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveSlotsLoadBehaviour _003C_003E4__this;

		public SaveInfo info;

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
		public _003CWaitForDelete_003Ed__9(int _003C_003E1__state)
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

	private SaveSlotsPanel m_Panel;

	[SerializeField]
	private QuestionPopup m_DeletePopup;

	[SerializeField]
	private bool m_IsMultiplayer;

	private bool m_IsLoadButtonPressed;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEntryLoaded(SaveEntry entry)
	{
	}

	private void OnDeleteRequested(SaveInfo info)
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForDelete_003Ed__9))]
	private IEnumerator WaitForDelete(SaveInfo info)
	{
		return null;
	}

	private void OnSlotPressed(SaveInfo info)
	{
	}

	public void OnSlotPressed_MP(SaveInfo info)
	{
	}
}
