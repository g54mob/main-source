using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemOScypek : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateTimeInComputer_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SystemOScypek _003C_003E4__this;

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
		public _003CUpdateTimeInComputer_003Ed__19(int _003C_003E1__state)
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

	[Header("Apps")]
	public AppMail mail;

	[Header("Other")]
	public ComputerStation computerStation;

	public yourComputerInSmallCorp computer_in_small_corp;

	public BiosMovement biosMovement;

	public AppSystemBarMenu appSystemBarMenu;

	public ComputerNetwork computerNetwork;

	public AppStatusEthernet appStatusEthernet;

	public AppPowerOption appPowerOption;

	[Header("Settings")]
	public SunController sunController;

	[Header("Network")]
	public Image network_status_on_pulpit;

	public Sprite[] chmurki;

	public TextMeshProUGUI nameNetwork;

	public TextMeshProUGUI statusNetwork;

	[SerializeField]
	[Header("Date")]
	private TextMeshProUGUI dateAndHoursText;

	[Header("BUG")]
	public float hour_computer_bug;

	[Header("Wallpaper Author Information")]
	public GameObject authorInformationObject;

	[Header("Close System ")]
	public GameObject closeSystemView;

	public GameObject lockSystemButton;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateTimeInComputer_003Ed__19))]
	private IEnumerator UpdateTimeInComputer()
	{
		return null;
	}

	public void Show_Message()
	{
	}

	public void CloseAppTab()
	{
	}

	public void IsAuthorWallpaper()
	{
	}

	public void CloseMenu()
	{
	}

	public void ShowOptionToCloseSystem()
	{
	}

	public void CloseOptionToCloseSystem()
	{
	}
}
