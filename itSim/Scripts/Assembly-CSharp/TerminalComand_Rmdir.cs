using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TerminalComand_Rmdir : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDeleteFiles_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TerminalComand_Rmdir _003C_003E4__this;

		public FileSystemObject dirRoot;

		public bool Q;

		public bool S;

		private FileSystemObject _003Cparent_003E5__2;

		private List<FileSystemObject> _003CblockAccess_003E5__3;

		private string _003Cquestion_003E5__4;

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
		public _003CDeleteFiles_003Ed__10(int _003C_003E1__state)
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

	public appExplorer appExplorer;

	public TerminalComand_Cd terminalComand_Cd;

	public DirectoryManager directoryManager;

	private bool paramS;

	private bool paramQ;

	private string returnAnswerMsg;

	private bool returnAnswer;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	[IteratorStateMachine(typeof(_003CDeleteFiles_003Ed__10))]
	private IEnumerator DeleteFiles(FileSystemObject dirRoot, bool Q, bool S)
	{
		return null;
	}

	private void UpdateRenderExplorer()
	{
	}

	private void AnswerCmd(string msg)
	{
	}

	public void HelpComandDestription()
	{
	}

	public void Help()
	{
	}
}
