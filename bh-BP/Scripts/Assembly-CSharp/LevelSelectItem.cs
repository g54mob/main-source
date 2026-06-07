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

public class LevelSelectItem : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateSetSelected_003Ed__46 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelSelectItem _003C_003E4__this;

		public bool isSelected;

		private float _003CstartTime_003E5__2;

		private CanvasGroup _003CtgtGrp_003E5__3;

		private float _003CstartAlpha_003E5__4;

		private float _003CtgtAlpha_003E5__5;

		private float _003CauraAlpha_003E5__6;

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
		public _003C_AnimateSetSelected_003Ed__46(int _003C_003E1__state)
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

	public int Idx;

	public CoolButton Btn;

	public RectTransform Xfm;

	public Image ImgIcon;

	public TextMeshProUGUI TxtLvl;

	public Localize LocName;

	public LocalizationParamsManager ParamsName;

	public TextMeshProUGUI TxtName;

	public Image ImgReadyToUnlock;

	public CanvasGroup CvsGrpUnlocked;

	public GameObject WrapperInfo;

	public Image BackingInfo;

	public Localize LocDetailsName;

	public LocalizationParamsManager ParamsDetailsName;

	public GridLayoutGroup GrpDetailsChars;

	public GameObject WrapperDifficulty;

	public CoolButton BtnDiffLeft;

	public Localize LocDifName;

	public LocalizationParamsManager ParamsDifName;

	public CoolButton BtnDiffRight;

	public LocalizationParamsManager ParamsDifLength;

	public LocalizationParamsManager ParamsDifBonuses;

	public LocalizationParamsManager ParamsBlueprintsLeft;

	public CoolButton BtnPlay;

	private int _selectedDiff;

	public CoolButton BtnLeaderboards;

	public Image ImgLeaderboards;

	public CanvasGroup CvsGrpLocked;

	public GameObject WrapperInfoLocked;

	public Image BackingInfoLocked;

	public Localize LocLockedDesc;

	public LocalizationParamsManager ParamsLockedDesc;

	public LevelInfo TgtInfo;

	public int TgtNGPlus;

	public bool IsLocked;

	public GameObject WrapperAura;

	public Image ImgAuraLeft;

	public Image ImgAuraRight;

	private CoroutineHandle _curAnim;

	private const float kAnimLen = 0.2f;

	private void Awake()
	{
	}

	public void Init(LevelInfo inf, int ngPlus)
	{
	}

	public void InitLocked(LevelInfo inf, int ngPlus)
	{
	}

	public void SetSelected(bool isSelected)
	{
	}

	public void SetSelectedDiff(int dif)
	{
	}

	private void RefreshCharPreviews(LevelData lData)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateSetSelected_003Ed__46))]
	private IEnumerator<float> _AnimateSetSelected(bool isSelected)
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

	public void OnDiffLeftClicked()
	{
	}

	public void OnDiffRightClicked()
	{
	}

	public void OnPlayClicked()
	{
	}

	private void ConfirmPlay()
	{
	}

	public void OnLBClicked()
	{
	}
}
