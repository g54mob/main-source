using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Battery9VTool : GroundTool
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorAwaitRefresh_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int frames;

		public Battery9VTool _003C_003E4__this;

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
		public _003CEnumeratorAwaitRefresh_003Ed__18(int _003C_003E1__state)
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

	[Header("Creator Box")]
	public Dropdown cre_orientDrop;

	public Text cre_addButtonText;

	public string cre_addButtonAddString;

	public string cre_addButtonConnectString;

	[Header("Editor Box")]
	public Dropdown edit_orientDrop;

	public Button edit_ConnectButton;

	public Text edit_voltage;

	public Text edit_current;

	public Text edit_voltageUnit;

	public Text edit_currentUnit;

	private PowerSupply b;

	private bool connecting;

	private int step;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public override void OnClick()
	{
	}

	public override void BeginCreate()
	{
	}

	private void StepCreate(TiePoint tp)
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void CancelCreation()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumeratorAwaitRefresh_003Ed__18))]
	public override IEnumerator EnumeratorAwaitRefresh(int frames)
	{
		return null;
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void Update()
	{
	}

	public override void UpdateCreateParams()
	{
	}

	public override void UpdateEditParams()
	{
	}
}
