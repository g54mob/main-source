using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class AppStoreNowSetupApp
{
	[CompilerGenerated]
	private sealed class _003CProgress_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppStoreNowSetupApp _003C_003E4__this;

		private float _003CinstallTime_003E5__2;

		private float _003Celapsed_003E5__3;

		private List<FileSystemObject> _003CfilesToInstall_003E5__4;

		private int _003CtotalFiles_003E5__5;

		private int _003CinstalledFiles_003E5__6;

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
		public _003CProgress_003Ed__14(int _003C_003E1__state)
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

	public string name;

	public int progressStep;

	public float downloadMB;

	public long totalMB;

	public float progressSetup;

	public AppStoreBaseData application;

	public AppStoreSetupManager appStoreSetupManager;

	public AppStoreApplicationPage appStoreApplicationPage;

	public DirectoryManager directoryManager;

	public appExplorer appExplorer;

	public AppBase appBase;

	public FileSystemObject downloadFile;

	public FileSystemObject instalDir;

	public Coroutine coroutineProgress;

	[IteratorStateMachine(typeof(_003CProgress_003Ed__14))]
	public IEnumerator Progress()
	{
		return null;
	}

	public void CopyFileInEditorMode()
	{
	}

	public void CreateFileDownload(string ownPath = "", bool fastmode = false)
	{
	}

	public void DeleteFileDownload(string ownPath = "", bool fastmode = false)
	{
	}

	public void SetPath(string ownPath = "")
	{
	}

	public void SetupDone(string ownPath = "", bool fastmode = false)
	{
	}
}
