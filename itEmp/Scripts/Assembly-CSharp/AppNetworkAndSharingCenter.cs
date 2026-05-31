using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AppNetworkAndSharingCenter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CcheckInternetStatus_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppNetworkAndSharingCenter _003C_003E4__this;

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
		public _003CcheckInternetStatus_003Ed__13(int _003C_003E1__state)
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

	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public AppBase AppBase;

	public ComputerNetwork computerNetwork;

	[HideInInspector]
	public bool isOpen;

	[Header("Object to Edit")]
	public GameObject buttonConnectionEth;

	public TextMeshProUGUI nameNetwork;

	public TextMeshProUGUI statusNetwork;

	public TextMeshProUGUI accessType;

	public Coroutine checkingstatusNetwork;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void CheckingStatus()
	{
	}

	[IteratorStateMachine(typeof(_003CcheckInternetStatus_003Ed__13))]
	public IEnumerator checkInternetStatus()
	{
		return null;
	}
}
