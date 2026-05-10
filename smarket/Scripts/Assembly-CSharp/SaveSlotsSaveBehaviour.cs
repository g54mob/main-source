using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveSlotsSaveBehaviour : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitForDelete_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveSlotsSaveBehaviour _003C_003E4__this;

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

	[CompilerGenerated]
	private sealed class _003CWaitForOverride_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveInfo info;

		public SaveSlotsSaveBehaviour _003C_003E4__this;

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
		public _003CWaitForOverride_003Ed__10(int _003C_003E1__state)
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
	private QuestionPopup m_DeletePopup;

	[SerializeField]
	private QuestionPopup m_OverridePopup;

	private SaveSlotsPanel m_Panel;

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

	[IteratorStateMachine(typeof(_003CWaitForOverride_003Ed__10))]
	private IEnumerator WaitForOverride(SaveInfo info)
	{
		return null;
	}

	private void OnSlotPressed(SaveInfo info)
	{
	}
}
