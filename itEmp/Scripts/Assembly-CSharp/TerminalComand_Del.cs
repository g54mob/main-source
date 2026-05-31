using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TerminalComand_Del : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDeleteFiles_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool Q;

		public FileSystemObject currentDir;

		public TerminalComand_Del _003C_003E4__this;

		public List<FileSystemObject> files;

		public bool P;

		private bool _003Crun_003E5__2;

		private string _003Cquestion_003E5__3;

		private int _003Ca_003E5__4;

		private FileSystemObject _003Ccontent_003E5__5;

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
		public _003CDeleteFiles_003Ed__14(int _003C_003E1__state)
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

	public appExplorer appExplorer;

	public AppTerminal appTerminal;

	public TerminalComand_Cd terminalComand_Cd;

	public DirectoryManager directoryManager;

	private bool paramP;

	private bool paramS;

	private bool paramQ;

	private string returnAnswerMsg;

	private bool returnAnswer;

	private List<FileSystemObject> files;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	private List<FileSystemObject> GetFiles(FileSystemObject directory, bool subfolder)
	{
		return null;
	}

	private void GetFilesRecursively(FileSystemObject directory, bool subfolder)
	{
	}

	[IteratorStateMachine(typeof(_003CDeleteFiles_003Ed__14))]
	private IEnumerator DeleteFiles(List<FileSystemObject> files, bool Q, bool P, FileSystemObject currentDir)
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
