using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppHamster : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCheckDeviceInPort_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppHamster _003C_003E4__this;

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
		public _003CCheckDeviceInPort_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003CQuickStep_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppHamster _003C_003E4__this;

		public float targetProgress;

		public float duration;

		public string message;

		private float _003CstartProgress_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CQuickStep_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003CRun_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppHamster _003C_003E4__this;

		private float _003CstepDuration_003E5__2;

		private float _003CnextTargetProgress_003E5__3;

		private float _003CtotalCopyTime_003E5__4;

		private float _003CelapsedTimeCopy_003E5__5;

		private int _003Ci_003E5__6;

		private float _003CtargetProgress_003E5__7;

		private float _003CstartProgress_003E5__8;

		private float _003CelapsedTime_003E5__9;

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
		public _003CRun_003Ed__40(int _003C_003E1__state)
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

	public CheckInput checkInput;

	public NotifiSystemManager notifiSystemManager;

	[Header("Component")]
	public DirectoryManager directoryManager;

	[Header("UI")]
	public TMP_Dropdown UI_DeviceList;

	public TMP_Text UI_SelectDeviceText;

	public TMP_Text UI_SelectFileText;

	public Button UI_SelectButton;

	public TMP_InputField UI_VolumeName;

	public Button UI_StartButton;

	public TMP_Text UI_StartButtonText;

	public Image UI_BarStatusFill;

	public TMP_Text UI_BarStatusTextValue_1;

	public TMP_Text UI_BarStatusTextValue_2;

	public RectTransform UI_Mask;

	[Header("App Explorer Selector")]
	public appExplorerSelector appExplorerSelectorPrefab;

	public Transform appExplorerSelectorPrefabParent;

	[HideInInspector]
	public bool isOpen;

	[HideInInspector]
	public bool firstOpen;

	[Header("Device")]
	public FileSystemObject SelectDevice;

	[Header("File")]
	public FileSystemObject SelectFile;

	public FileSystemObject SelectFileOnDisk;

	public appExplorerSelector appExplorerSelector;

	private List<FileSystemObject> devices;

	private bool isRun;

	private Coroutine TaskRun;

	private Coroutine checkDeviceInPort;

	public void TerminatedProcesses()
	{
	}

	public void ButtonSelectFile()
	{
	}

	public void ActionSelectFile(FileSystemObject file, FileSystemObject disk)
	{
	}

	public void CloseAppExplorerSelector()
	{
	}

	public void OpenApp()
	{
	}

	public void MinimalizeAppExplorerSelector()
	{
	}

	public void CloseApp()
	{
	}

	public void OpenListDevice()
	{
	}

	private void UpdateListDevice()
	{
	}

	public void SetDeviceList(int value)
	{
	}

	public void ButtonStart()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckDeviceInPort_003Ed__39))]
	private IEnumerator CheckDeviceInPort()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRun_003Ed__40))]
	private IEnumerator Run()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CQuickStep_003Ed__41))]
	private IEnumerator QuickStep(string message, float duration, float targetProgress)
	{
		return null;
	}

	public void UpdateStartButtonUI()
	{
	}

	private void SendFileToDevice(FileSystemObject device, FileSystemObject fileISO)
	{
	}

	[ContextMenu("Check")]
	public void Check()
	{
	}

	public static bool IsCorrectIsoDevice(FileSystemObject originalDevice, bool debug = false)
	{
		return false;
	}

	private static bool CompareObjects(FileSystemObject obj1, FileSystemObject obj2, bool debug)
	{
		return false;
	}

	private static bool CompareLists(List<FileSystemObject> originalList, List<FileSystemObject> loadList, bool debug)
	{
		return false;
	}

	private static bool CompareContentFiles(FileSystemObjectContentFile file1, FileSystemObjectContentFile file2, bool debug)
	{
		return false;
	}

	private static string NormalizeText(string text)
	{
		return null;
	}

	private static bool ComparePermissions(List<FileSystemObject.Permission> list1, List<FileSystemObject.Permission> list2, bool debug)
	{
		return false;
	}
}
