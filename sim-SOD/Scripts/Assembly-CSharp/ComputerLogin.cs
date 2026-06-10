using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ComputerLogin : CruncherAppContent
{
	[CompilerGenerated]
	private sealed class _003CInputCode_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerLogin _003C_003E4__this;

		public List<int> code;

		public float keyDelay;

		private int _003CcodeCursor_003E5__2;

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
		public _003CInputCode_003Ed__18(int _003C_003E1__state)
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

	public ComputerOSMultiSelect loginSelection;

	public TextMeshProUGUI inputText;

	public TextMeshProUGUI instructionText;

	public List<int> input;

	public Color defaultTextColour;

	public GameObject numPadParent;

	public bool checking;

	public bool correct;

	public float checkCounter;

	public bool inputCodeActive;

	public override void OnSetup()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnNewUserSelected()
	{
	}

	public void PressNumberButton(int newInt)
	{
	}

	public void ClearCode(bool press = true)
	{
	}

	public void SubmitCode()
	{
	}

	private void Update()
	{
	}

	public void OnInputCode(List<int> code, float keyDelay = 0.15f)
	{
	}

	[IteratorStateMachine(typeof(_003CInputCode_003Ed__18))]
	private IEnumerator InputCode(List<int> code, float keyDelay = 0.15f)
	{
		return null;
	}
}
