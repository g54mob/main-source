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

public class EvoSelectBtn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBar_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float tgtFill;

		public EvoSelectBtn _003C_003E4__this;

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
		public _003C_AnimateBar_003Ed__20(int _003C_003E1__state)
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

	public CoolButton Btn;

	public Image ImgIcon;

	public GameObject WrapperComboElements;

	public GameObject WrapperTwitchVotes;

	public Localize LocNumVotes;

	public LocalizationParamsManager ParamsNumVotes;

	public TextMeshProUGUI TxtNumVotes;

	public Image[] ImgCombo;

	public PixelRectSizer[] SizerCombo;

	public int ChoiceIdx;

	public SlidingPanel Panel;

	private bool _isVisible;

	private UpgradeInfo _tgtInf;

	private CoroutineHandle _curAnim;

	private float _curFill;

	private void Awake()
	{
	}

	private void OnStateChanged()
	{
	}

	public void AnimateBarFilled()
	{
	}

	public void AnimateBarUnfilled()
	{
	}

	public void SetFill(float fill)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateBar_003Ed__20))]
	private IEnumerator<float> _AnimateBar(float tgtFill)
	{
		return null;
	}

	private void SetComboSize(int size)
	{
	}

	public void SetEvo(int idx, UpgradeChoice choice)
	{
	}

	public UpgradeInfo GetInfo()
	{
		return null;
	}

	private void OnClicked()
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	public bool IsVisible()
	{
		return false;
	}

	public void SetNumVotes(int votes, int totalVotes)
	{
	}
}
