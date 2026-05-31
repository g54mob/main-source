using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Scale))]
public class ScaleHelpIndicatorActivator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWarningDelayCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ScaleHelpIndicatorActivator _003C_003E4__this;

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
		public _003CWarningDelayCoroutine_003Ed__9(int _003C_003E1__state)
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

	private Scale m_Scale;

	private Coroutine m_WarningDelayCoroutine;

	[SerializeField]
	private GameObject m_WarningDisplay;

	[SerializeField]
	private GameObject m_TutorialWarningDisplay;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnQueueUpdatedNetwork(bool value)
	{
	}

	private void OnQueueUpdated()
	{
	}

	[IteratorStateMachine(typeof(_003CWarningDelayCoroutine_003Ed__9))]
	private IEnumerator WarningDelayCoroutine()
	{
		return null;
	}

	private void ToggleDisplay(bool value)
	{
	}

	private GameObject SelectDisplay()
	{
		return null;
	}
}
