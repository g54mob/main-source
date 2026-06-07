using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TerminalComand_Ping : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPing_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TerminalComand_Ping _003C_003E4__this;

		public string ip;

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
		public _003CPing_003Ed__12(int _003C_003E1__state)
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
	private sealed class _003CPingLoop_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TerminalComand_Ping _003C_003E4__this;

		public string ip;

		public string myIp;

		private int _003Ca_003E5__2;

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
		public _003CPingLoop_003Ed__11(int _003C_003E1__state)
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

	public AppTerminal appTerminal;

	public ComputerNetwork computerNetwork;

	public TerminaPingHistory lastResult;

	private bool paramT;

	private List<TerminaPingResult> msList;

	private string pingIp;

	private Coroutine pingCoroutine;

	private int sentCount;

	private int receivedCount;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	[IteratorStateMachine(typeof(_003CPingLoop_003Ed__11))]
	private IEnumerator PingLoop(string myIp, string ip)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CPing_003Ed__12))]
	private IEnumerator Ping(string myIp, string ip)
	{
		return null;
	}

	private void StopComand()
	{
	}

	public bool CheckResult(string address)
	{
		return false;
	}

	public void HelpComandDestription()
	{
	}

	public void Help()
	{
	}
}
