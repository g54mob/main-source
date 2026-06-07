using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorCompleteMove_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CEnumeratorCompleteMove_003Ed__16(int _003C_003E1__state)
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
	public Vector2 overrideSize;

	public Button cre_addButton;

	public Button cre_cancelButton;

	[Header("Editor Box")]
	public Button edit_MoveButton;

	private readonly int compMask;

	private readonly int defMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public void OpenCodeEditor()
	{
	}

	public override void OnClick()
	{
	}

	public override void LoadEdit(BaseComponent comp)
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

	public override void BeginMove()
	{
	}

	public override void Delete()
	{
	}

	public override void CancelMove()
	{
	}

	public override void CompleteMove()
	{
	}

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void RedoValueChanges(params object[] args)
	{
	}

	[IteratorStateMachine(typeof(_003CEnumeratorCompleteMove_003Ed__16))]
	private IEnumerator EnumeratorCompleteMove()
	{
		return null;
	}

	public override void Update()
	{
	}
}
