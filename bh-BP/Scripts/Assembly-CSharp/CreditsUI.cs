using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public CreditsUI _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Run_003Ed__9(int _003C_003E1__state)
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

	public static CreditsUI I;

	public ScrollRect Scrl;

	public GameObject WrapperSkip;

	public Image SkipFill;

	private float _skipHoldTime;

	public bool IsRunning;

	private const float kCreditsLen = 240f;

	private void Awake()
	{
	}

	public void Run()
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__9))]
	private IEnumerator<float> _Run()
	{
		return null;
	}
}
