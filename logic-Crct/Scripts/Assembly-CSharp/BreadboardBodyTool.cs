using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BreadboardBodyTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorAwaitRefresh_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int frames;

		public BreadboardBodyTool _003C_003E4__this;

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
		public _003CEnumeratorAwaitRefresh_003Ed__20(int _003C_003E1__state)
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
	public Button cre_addButton;

	public Button cre_okButton;

	public Button cre_cancelButton;

	public InputField cre_xPosInput;

	public InputField cre_yPosInput;

	public InputField cre_rotInput;

	[Header("Editor Box")]
	public InputField edit_xPosInput;

	public InputField edit_yPosInput;

	public InputField edit_rotInput;

	public override void OnClick()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	public override void RefreshEdit()
	{
	}

	public void RefreshCreator()
	{
	}

	public void UpdateEditorTransformValues()
	{
	}

	public void UpdateCreatorTransformValues()
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

	[IteratorStateMachine(typeof(_003CEnumeratorAwaitRefresh_003Ed__20))]
	public override IEnumerator EnumeratorAwaitRefresh(int frames)
	{
		return null;
	}
}
