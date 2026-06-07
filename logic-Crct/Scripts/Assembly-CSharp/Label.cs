using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Label : BaseComponent
{
	[CompilerGenerated]
	private sealed class _003C_ResizeBackground_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Label _003C_003E4__this;

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
		public _003C_ResizeBackground_003Ed__10(int _003C_003E1__state)
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

	public TextMeshProUGUI labelTextMesh;

	public Transform backingTransform;

	public string labelString;

	public override void FinishPlacement()
	{
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public void ResizeBackground()
	{
	}

	[IteratorStateMachine(typeof(_003C_ResizeBackground_003Ed__10))]
	private IEnumerator _ResizeBackground()
	{
		return null;
	}
}
