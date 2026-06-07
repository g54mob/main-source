using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class PowerRailMobileTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorAwaitRefresh_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int frames;

		public PowerRailMobileTool _003C_003E4__this;

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
		public _003CEnumeratorAwaitRefresh_003Ed__17(int _003C_003E1__state)
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

	private static PowerRailMobileTool inst;

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

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void RedoValueChanges(params object[] args)
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

	[IteratorStateMachine(typeof(_003CEnumeratorAwaitRefresh_003Ed__17))]
	public override IEnumerator EnumeratorAwaitRefresh(int frames)
	{
		return null;
	}
}
