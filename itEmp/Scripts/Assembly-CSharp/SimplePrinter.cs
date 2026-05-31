using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SimplePrinter : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CButtonWaiting_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimplePrinter _003C_003E4__this;

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
		public _003CButtonWaiting_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CCoroutine_ShutdownPrintet_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimplePrinter _003C_003E4__this;

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
		public _003CCoroutine_ShutdownPrintet_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CCoroutine_StartingPrintet_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimplePrinter _003C_003E4__this;

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
		public _003CCoroutine_StartingPrintet_003Ed__45(int _003C_003E1__state)
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
	private sealed class _003CEmptyUSBCoroutine_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimplePrinter _003C_003E4__this;

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
		public _003CEmptyUSBCoroutine_003Ed__52(int _003C_003E1__state)
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

	public TaskDataOrderData orderData;

	public View_Device view_device;

	public NetworkCard networkCard;

	public ButtonInformationByDevice buttonInformationByDevice;

	[SerializeField]
	private GameObject View_Main;

	[SerializeField]
	private GameObject View_Job;

	[SerializeField]
	private GameObject View_ShutdownInfo;

	[SerializeField]
	private GameObject View_StartingInfo;

	[SerializeField]
	private GameObject View_Device;

	[SerializeField]
	private GameObject View_PrintfromUSB;

	[SerializeField]
	private GameObject View_EmptyUSB;

	[SerializeField]
	private GameObject View_Network;

	[SerializeField]
	private GameObject View_Information;

	private Coroutine shutdownprintet_coroutine;

	private Coroutine startingprintet_coroutine;

	private Coroutine emptyUSB_coroutine;

	public Coroutine buttonwaitingCoroutine;

	[SerializeField]
	private TextMeshProUGUI Shutdown_progres;

	[SerializeField]
	private TextMeshProUGUI Starting_progres;

	[HideInInspector]
	public bool isOn;

	public string Version_Software;

	[HideInInspector]
	public bool usingPrinter;

	[HideInInspector]
	public int usingPrinterCounter;

	[Header("Value")]
	public float StatusToner;

	[Header("Value")]
	public float StatusDrum;

	[Header("Value")]
	public float StatusBelt;

	[Header("Value")]
	public float StatusWasteToner;

	public int StatusTemperature;

	public int StatusHumidity;

	[Header("Info")]
	public TextMeshProUGUI informationText;

	public int connection_speed;

	public int working_mode;

	public int OnOffIPSec;

	public int encryption_method;

	public int operationMode;

	public int keyManagement;

	public int OnOffBonjour;

	public int sccopeOfSharing;

	public int OnOffIPP;

	public int ippOverHttps;

	public void TurnOff()
	{
	}

	public void InstantTurnOff()
	{
	}

	[IteratorStateMachine(typeof(_003CButtonWaiting_003Ed__42))]
	public IEnumerator ButtonWaiting()
	{
		return null;
	}

	private void ResetAllLayersView()
	{
	}

	[IteratorStateMachine(typeof(_003CCoroutine_ShutdownPrintet_003Ed__44))]
	private IEnumerator Coroutine_ShutdownPrintet()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCoroutine_StartingPrintet_003Ed__45))]
	private IEnumerator Coroutine_StartingPrintet()
	{
		return null;
	}

	public void BackToMainView()
	{
	}

	public void ShowDeviceProperty()
	{
	}

	public void ShowPrintFromUSB()
	{
	}

	public void EmptyUSB()
	{
	}

	public void ShowJob()
	{
	}

	public void ShowNetwork()
	{
	}

	[IteratorStateMachine(typeof(_003CEmptyUSBCoroutine_003Ed__52))]
	private IEnumerator EmptyUSBCoroutine()
	{
		return null;
	}

	public void ShowInformation(string info)
	{
	}

	public void CloseInformation()
	{
	}
}
