using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BootManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CkeyCode_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BootManager _003C_003E4__this;

		public Action<int> setter;

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
		public _003CkeyCode_003Ed__12(int _003C_003E1__state)
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

	[Header("Component")]
	public yourComputerInSmallCorp urComputer;

	public ComputerFrontPort computerFrontPort;

	public systeminstalation systemInstalation;

	public ButtonInformationByDevice buttonInformationByDevice;

	[Header("Objects")]
	public GameObject bootMenu;

	[Header("UI")]
	public List<TextMeshProUGUI> optionText;

	public RectTransform BootDeviceItemParent;

	public RectTransform BootDeviceItemPrefab;

	public Coroutine keyCodeCoroutine;

	private int setBootOption;

	private bool isSet;

	public bool isOpenBoot;

	[IteratorStateMachine(typeof(_003CkeyCode_003Ed__12))]
	public IEnumerator keyCode(Action<int> setter)
	{
		return null;
	}

	public void SetTextColor(TextMeshProUGUI its)
	{
	}

	public void ResetText()
	{
	}

	public void OpenBootMenu()
	{
	}

	public void CloseBootMenu()
	{
	}

	public void UpdateListDevices()
	{
	}

	private bool isBootableDevice(FileSystemObject device)
	{
		return false;
	}

	private bool IsStatusOK(string input)
	{
		return false;
	}

	private int GetNumberFromBrackets(string input)
	{
		return 0;
	}

	public bool IsDeviceStillConnected(int selectedIndex)
	{
		return false;
	}
}
