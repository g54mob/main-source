using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class appExplorer : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckSettingsBios_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public appExplorer _003C_003E4__this;

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
		public _003CCheckSettingsBios_003Ed__30(int _003C_003E1__state)
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

	public appExplorerOpenApps openAppsManager;

	public appExplorerMenu appExplorerMenu;

	public AppBase appBase;

	public DataCloud dataCloud;

	[Header("Icon")]
	public Sprite MyComputerIcon;

	[Header("App Object")]
	public Transform applicationLayout;

	[Header("Explorer Content")]
	public Transform ParentExplorerContent;

	public GameObject ItemExplorerContent;

	public Transform ParentExplorerPath;

	public GameObject ItemExplorerPath;

	[Header("UI")]
	public Image UiButtonBack;

	public Image UiButtonNext;

	public RectTransform WindowBlockAccess;

	[Header("icon Base")]
	public ExplorerIconByExtension[] iconBase;

	[Header("Bios Check")]
	public ComputerVariables computerVariables;

	public BiosCheckVariables biosCheckVariables;

	public bool isOpen;

	[Header("Sound Effect")]
	public AudioSource audioSource;

	public AudioClip systemFileErrorSound;

	public FileSystemObject currentDirectory;

	public List<FileSystemObject> backList;

	public List<FileSystemObject> nextList;

	private Coroutine checkBiosError;

	public void OpenApp(string path)
	{
	}

	public void OpenApp()
	{
	}

	private void InitializationDataCloud()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckSettingsBios_003Ed__30))]
	private IEnumerator CheckSettingsBios()
	{
		return null;
	}

	public void CloseApp()
	{
	}

	public bool AppIsOpen()
	{
		return false;
	}

	private void ClearExplorerContent()
	{
	}

	public void OpenWindowBlockAccess(string content)
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

	public void RefreshButtonBackNext()
	{
	}

	public void OpenDirectoryFromPathBar(FileSystemObject dir)
	{
	}

	public void RefreshFromOutside()
	{
	}

	public void OpenDirectoryFromPath(string path)
	{
	}

	public Sprite FindIcon(string extension)
	{
		return null;
	}

	public Sprite findAppIcon(FileSystemObject file)
	{
		return null;
	}
}
