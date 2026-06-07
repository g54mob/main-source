using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerSupplyMobileTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorAwaitRefresh_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int frames;

		public PowerSupplyMobileTool _003C_003E4__this;

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
		public _003CEnumeratorAwaitRefresh_003Ed__30(int _003C_003E1__state)
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

	private static PowerSupplyMobileTool inst;

	private PowerSupply b;

	[Header("Viewport")]
	public EventTrigger viewportTrigger;

	private int step;

	private TiePoint prevPoint;

	protected readonly int compMask;

	protected Ray ray;

	protected RaycastHit hit;

	protected TiePoint curPoint;

	protected BaseComponent hitComp;

	protected int c;

	public override void Awake()
	{
	}

	public static void IPC_BeginCreate()
	{
	}

	private new void _IPC_BeginCreate()
	{
	}

	public override void BeginCreate()
	{
	}

	public void AddEventTriggerListener(EventTriggerType eventType, Action<BaseEventData> callback)
	{
	}

	public void Confirm()
	{
	}

	private void Connect(TiePoint tp)
	{
	}

	public void ViewportClicked(BaseEventData e)
	{
	}

	public override void Update()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void CancelCreation()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private void IPC_ApplyChanges()
	{
	}

	private void IPC_CancelEdit()
	{
	}

	public override void ApplyChanges()
	{
	}

	public override void CancelEdit()
	{
	}

	public override void Delete()
	{
	}

	public void UpdateEditorTransformValues()
	{
	}

	public void UpdateCreatorTransformValues()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumeratorAwaitRefresh_003Ed__30))]
	public override IEnumerator EnumeratorAwaitRefresh(int frames)
	{
		return null;
	}
}
