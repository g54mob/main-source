using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BuzzerTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorCompleteMove_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CEnumeratorCompleteMove_003Ed__27(int _003C_003E1__state)
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
	public Dropdown cre_typeDrop;

	public Button cre_addButton;

	public Button cre_cancelButton;

	public InputField cre_freqInput;

	public InputField cre_maxCurrentInput;

	public InputField cre_capacitanceInput;

	[Header("Editor Box")]
	public Dropdown edit_typeDrop;

	public Button edit_MoveButton;

	public InputField edit_freqInput;

	public InputField edit_maxCurrentInput;

	public InputField edit_capacitanceInput;

	private float freq;

	private float maxCurrent;

	private float capacitance;

	private readonly int compMask;

	private readonly int defMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

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

	public override void UpdateCreateParams()
	{
	}

	public override void UpdateEditParams()
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

	[IteratorStateMachine(typeof(_003CEnumeratorCompleteMove_003Ed__27))]
	private IEnumerator EnumeratorCompleteMove()
	{
		return null;
	}

	public override void Update()
	{
	}
}
