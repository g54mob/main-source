using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class systemOptionSettings : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CcheckingNetwork_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public systemOptionSettings _003C_003E4__this;

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
		public _003CcheckingNetwork_003Ed__44(int _003C_003E1__state)
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

	public GameObject main;

	public GameObject display;

	public GameObject recovery;

	public GameObject power;

	public GameObject storage;

	public GameObject systemComponetns;

	public GameObject activation;

	public foldersInfo folders_info;

	public yourComputerInSmallCorp computer_in_small_corp;

	public ComputerNetwork computerNetwork;

	[Header("Zmiana szybkości odświeżania gry")]
	public int[] sleeptimer;

	public int[] fps;

	public int currentIndexFPS;

	public int currentIndexResolution;

	private int currentIndexFullScreen;

	[SerializeField]
	private TextMeshProUGUI fps_value;

	[SerializeField]
	private TextMeshProUGUI resolution;

	[SerializeField]
	private TextMeshProUGUI aboutDisplay;

	[SerializeField]
	private TextMeshProUGUI lightingDisplay;

	[SerializeField]
	private TextMeshProUGUI sleepMode;

	[SerializeField]
	private TextMeshProUGUI sleepModeTimer;

	[SerializeField]
	private TextMeshProUGUI used_memory_text;

	[SerializeField]
	private TextMeshProUGUI free_memory_text;

	[SerializeField]
	private TextMeshProUGUI c_disk_text;

	[SerializeField]
	private TextMeshProUGUI app_instal_text;

	[SerializeField]
	private TextMeshProUGUI other_text;

	[SerializeField]
	private TextMeshProUGUI temporaryfiles_text;

	[SerializeField]
	private TextMeshProUGUI documents_text;

	public UIBlur blur;

	[Header("Status Connected")]
	public TextMeshProUGUI nameNetwork;

	public TextMeshProUGUI statusNetwork;

	public void ResetUnderCategory()
	{
	}

	private void OpenCategory(GameObject x)
	{
	}

	public void OpenActivation()
	{
	}

	public void OpenDisplay()
	{
	}

	public void OpenRecovery()
	{
	}

	public void OpenPower()
	{
	}

	public void OpenStorage()
	{
	}

	public void OpenSettingsSystem()
	{
	}

	private void UpdateAboutDisplay(int index)
	{
	}

	public void ChangeFPS()
	{
	}

	public void ChangeResolution()
	{
	}

	public void UpdateResolution(int index)
	{
	}

	public void ChangeFullScreen()
	{
	}

	[IteratorStateMachine(typeof(_003CcheckingNetwork_003Ed__44))]
	public IEnumerator checkingNetwork()
	{
		return null;
	}

	public void SetLightingUp()
	{
	}

	public void SetLightingDown()
	{
	}

	public void TurnOffOnSleepMode()
	{
	}

	public void SetTimerSleepMode()
	{
	}
}
