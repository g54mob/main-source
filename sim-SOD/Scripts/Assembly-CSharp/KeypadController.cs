using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CInputCode_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public KeypadController _003C_003E4__this;

		public List<int> code;

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
		public _003CInputCode_003Ed__21(int _003C_003E1__state)
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

	public InfoWindow parentWindow;

	public Evidence evidence;

	public WindowContentController windowContent;

	public TextMeshProUGUI inputText;

	public List<int> input;

	public Color defaultTextColour;

	public bool checking;

	public bool correct;

	public float checkCounter;

	public bool inputCodeActive;

	public bool isTelephone;

	public int digits;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void PressNumberButton(int newInt)
	{
	}

	public void OnKeypadButtonDown()
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

	public void OnInputCode(List<int> code)
	{
	}

	[IteratorStateMachine(typeof(_003CInputCode_003Ed__21))]
	private IEnumerator InputCode(List<int> code)
	{
		return null;
	}
}
