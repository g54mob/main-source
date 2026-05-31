using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class appExplorerSelector : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckSettingsBios_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public appExplorerSelector _003C_003E4__this;

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
		public _003CCheckSettingsBios_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003CWaitAndDestroy_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public appExplorerSelector _003C_003E4__this;

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
		public _003CWaitAndDestroy_003Ed__29(int _003C_003E1__state)
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
	public ComputerStation computerStation;

	public DirectoryManager thisDisc;

	public appExplorer appExplorer;

	[Header("Explorer Content")]
	public Transform ParentExplorerContent;

	public GameObject ItemExplorerContent;

	public Transform ParentExplorerPath;

	public GameObject ItemExplorerPath;

	[Header("UI")]
	public Image UiButtonBack;

	public Image UiButtonNext;

	public TMP_Dropdown dropdownFilesType;

	public TMP_InputField nameFile;

	[Header("Bios Check")]
	public ComputerVariables computerVariables;

	public BiosCheckVariables biosCheckVariables;

	public bool isOpen;

	public FileSystemObject currentDirectory;

	public List<FileSystemObject> backList;

	public List<FileSystemObject> nextList;

	public FileSystemObject FileSelected;

	private Action<FileSystemObject, FileSystemObject> actOpen;

	private Action actClose;

	public string renderFileType;

	private string allFilesText;

	private Coroutine checkBiosError;

	public void OpenExplorerSelector(string[] filesType, Action<FileSystemObject, FileSystemObject> actOpen, Action actClose, int setDefOption = -1)
	{
	}

	private void OpenApp()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckSettingsBios_003Ed__27))]
	private IEnumerator CheckSettingsBios()
	{
		return null;
	}

	public void CloseApp()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitAndDestroy_003Ed__29))]
	private IEnumerator WaitAndDestroy()
	{
		return null;
	}

	private void ClearExplorerContent()
	{
	}

	public void RenderExplorerContent(FileSystemObject directory)
	{
	}

	private void ClearExplorerPath()
	{
	}

	public void RenderExplorerPath()
	{
	}

	public void ButtonBack()
	{
	}

	public void ButtonNext()
	{
	}

	public void ButtonOpen()
	{
	}

	public void SelectOptionDropdown(int idOption)
	{
	}

	public void RefreshButtonBackNext()
	{
	}

	public void OpenDirectoryFromPathBar(FileSystemObject dir)
	{
	}

	public void OpenDirectoryFromPath(string path)
	{
	}
}
