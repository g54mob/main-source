using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class MainMenuLoadingPage : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoLoad_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuLoadingPage _003C_003E4__this;

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
		public _003CDoLoad_003Ed__7(int _003C_003E1__state)
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

	public UnityEvent OnLoadComplete;

	[SerializeField]
	private LocalizeStringEvent _textEvent;

	public LocalizedString _loggedOutMessage;

	public LocalizedString _noOwnershipMessage;

	public LocalizedString _steamClosedMessage;

	public LocalizedString _connectedMessage;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CDoLoad_003Ed__7))]
	private IEnumerator DoLoad()
	{
		return null;
	}
}
