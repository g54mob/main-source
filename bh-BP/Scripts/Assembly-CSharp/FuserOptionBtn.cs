using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuserOptionBtn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBar_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float tgtFill;

		public FuserOptionBtn _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartFill_003E5__4;

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
		public _003C_AnimateBar_003Ed__14(int _003C_003E1__state)
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

	public FuserOptionType Type;

	public Image ImgIcon;

	public CoolButton Btn;

	public TextMeshProUGUI TxtLabel;

	public TextMeshProUGUI TxtNumAvail;

	public Localize LocNumAvail;

	public LocalizationParamsManager ParamsNumAvail;

	public bool IsAvailable;

	private CoroutineHandle _curAnim;

	private float _curFill;

	private void Awake()
	{
	}

	private void OnClicked()
	{
	}

	private void OnStateChanged()
	{
	}

	private void SetFill(float fill)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateBar_003Ed__14))]
	private IEnumerator<float> _AnimateBar(float tgtFill)
	{
		return null;
	}

	public void SetInteractable(bool isInteractable)
	{
	}
}
