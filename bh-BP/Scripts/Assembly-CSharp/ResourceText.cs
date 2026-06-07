using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using TMPro;
using UnityEngine;

public class ResourceText : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateChange_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ResourceText _003C_003E4__this;

		public int newNum;

		private int _003CstartNum_003E5__2;

		private int _003Cdif_003E5__3;

		private float _003CpulseLen_003E5__4;

		private float _003CstartTime_003E5__5;

		private float _003Clen_003E5__6;

		private int _003CnFrames_003E5__7;

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
		public _003C_AnimateChange_003Ed__14(int _003C_003E1__state)
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

	public ResourceType TgtType;

	public TextMeshProUGUI Txt;

	public TextMeshProUGUI TxtChange;

	private CoroutineHandle _curAnim;

	private bool _isAnimating;

	private int _displayedNum;

	private int _displayedChange;

	private const float kFadeInChangeLen = 0.2f;

	private const float kMaxChangeLen = 1f;

	private const float kMaxChangeVal = 100f;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResourceChanged()
	{
	}

	private void SetDisplayedNum(int num, int change)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateChange_003Ed__14))]
	private IEnumerator<float> _AnimateChange(int newNum)
	{
		return null;
	}
}
