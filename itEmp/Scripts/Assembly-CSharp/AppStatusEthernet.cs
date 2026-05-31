using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AppStatusEthernet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAddByteSendAndReceived_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppStatusEthernet _003C_003E4__this;

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
		public _003CAddByteSendAndReceived_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003CcheckingStatusEthernet_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppStatusEthernet _003C_003E4__this;

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
		public _003CcheckingStatusEthernet_003Ed__20(int _003C_003E1__state)
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

	public ComputerVariables computerVariables;

	[HideInInspector]
	public bool isOpen;

	[Header("Variables and function")]
	public Coroutine StartingDataConnected;

	public TextMeshProUGUI ipv4;

	public TextMeshProUGUI ipv6;

	public TextMeshProUGUI mediaStatus;

	public TextMeshProUGUI ssid;

	public TextMeshProUGUI speed;

	public TextMeshProUGUI signalQuality;

	public TextMeshProUGUI sendbyte;

	public TextMeshProUGUI receivedbyte;

	public Coroutine startingByte;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void AddValueByte()
	{
	}

	[IteratorStateMachine(typeof(_003CAddByteSendAndReceived_003Ed__19))]
	public IEnumerator AddByteSendAndReceived()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CcheckingStatusEthernet_003Ed__20))]
	public IEnumerator checkingStatusEthernet()
	{
		return null;
	}
}
