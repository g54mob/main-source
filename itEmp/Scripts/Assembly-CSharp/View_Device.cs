using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Device : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CQuickStep_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public View_Device _003C_003E4__this;

		public string message;

		public float targetProgress;

		public float duration;

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
		public _003CQuickStep_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003Cstart_Update_Software_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public View_Device _003C_003E4__this;

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
		public _003Cstart_Update_Software_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003Cverification_VersionSoftware_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public View_Device _003C_003E4__this;

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
		public _003Cverification_VersionSoftware_003Ed__38(int _003C_003E1__state)
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

	[Header("Different Script")]
	public SimplePrinter printer;

	public VersionGlobalCheck versionGlobalCheck;

	[SerializeField]
	private GameObject View_connectedModules;

	[SerializeField]
	private GameObject View_Status;

	[SerializeField]
	private GameObject View_Update;

	[SerializeField]
	private GameObject Updates;

	[SerializeField]
	private GameObject NoUpdate;

	[SerializeField]
	private GameObject CheckingUpdate;

	[SerializeField]
	private GameObject StatusUpdate;

	[SerializeField]
	private GameObject Button_Update;

	[Header("Update")]
	[HideInInspector]
	public Coroutine verification_VersionSoftware_Coroutine;

	[Header("Update")]
	[HideInInspector]
	public Coroutine start_softwareUpdate_corotuine;

	[SerializeField]
	private TextMeshProUGUI Version_Software_Text;

	[SerializeField]
	private TextMeshProUGUI new_Version_Numer;

	[SerializeField]
	private TextMeshProUGUI new_Version_Description;

	[SerializeField]
	private TextMeshProUGUI new_Version_Weight;

	[SerializeField]
	private TextMeshProUGUI Temperature_TEXT;

	[SerializeField]
	private TextMeshProUGUI Humidity_TEXT;

	public Image UI_BarStatusFill;

	public TMP_Text UI_BarStatusTextValue_1;

	public TMP_Text UI_BarStatusTextValue_2;

	public TMP_Text UI_What_do_update;

	[Header("Statusy")]
	public Image UI_BarStatusToner;

	[Header("Statusy")]
	public Image UI_BarStatusDrum;

	[Header("Statusy")]
	public Image UI_BarStatusBelt;

	[Header("Statusy")]
	public Image UI_BarStatusWasteToner;

	public TMP_Text UI_BarStatusTonerTextValue_1;

	public TMP_Text UI_BarStatusTonerTextValue_2;

	public TMP_Text UI_BarStatusDrumTextValue_1;

	public TMP_Text UI_BarStatusDrumTextValue_2;

	public TMP_Text UI_BarStatusBeltTextValue_1;

	public TMP_Text UI_BarStatusBeltTextValue_2;

	public TMP_Text UI_BarStatusWasteTonerTextValue_1;

	public TMP_Text UI_BarStatusWasteTonerTextValue_2;

	private float progres;

	public void ResetView()
	{
	}

	public void View_Show_Connectedmodules()
	{
	}

	public void View_Show_Status()
	{
	}

	public void View_Show_Update()
	{
	}

	[IteratorStateMachine(typeof(_003Cverification_VersionSoftware_003Ed__38))]
	private IEnumerator verification_VersionSoftware()
	{
		return null;
	}

	public void Start_UpdateSoftware()
	{
	}

	[IteratorStateMachine(typeof(_003Cstart_Update_Software_003Ed__41))]
	private IEnumerator start_Update_Software()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CQuickStep_003Ed__42))]
	private IEnumerator QuickStep(string message, float duration, float targetProgress)
	{
		return null;
	}
}
