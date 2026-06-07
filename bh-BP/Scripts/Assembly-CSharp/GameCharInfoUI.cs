using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class GameCharInfoUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_SwitchPage_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameCharInfoUI _003C_003E4__this;

		public bool animateExit;

		public GameCharPage pg;

		private float _003CstartTime_003E5__2;

		private CanvasGroup _003CnewCvs_003E5__3;

		private CanvasGroup _003CcurCvs_003E5__4;

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
		public _003C_SwitchPage_003Ed__20(int _003C_003E1__state)
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

	public static GameCharInfoUI I;

	public GameCharPage CurPage;

	[NamedArray(typeof(GameCharPage))]
	public CanvasGroup[] CvsGrps;

	public GameObject WrapperStats;

	public CharInfoPanel InfoPanel;

	public GameObject WrapperHarvest;

	public HarvestUpgradeBtn[] HarvestBtns;

	public GameObject WrapperHousing;

	public Image ImgHousing;

	public Localize LocHousingUpgraded;

	public Localize LocHousingDesc;

	public LocalizationParamsManager ParamsHousingDesc;

	public CoolButton BtnClose;

	private List<HarvestUpgradeType> _availUpgs;

	private CharMetaInst _curChar;

	private new CoroutineHandle _curAnim;

	private bool _isSwitching;

	private void Awake()
	{
	}

	public void ActivateLevelUp(CharMetaInst cInst)
	{
	}

	public void SetPage(GameCharPage pg, bool animateExit)
	{
	}

	[IteratorStateMachine(typeof(_003C_SwitchPage_003Ed__20))]
	private IEnumerator<float> _SwitchPage(GameCharPage pg, bool animateExit)
	{
		return null;
	}

	public bool IsSwitching()
	{
		return false;
	}

	public void SelectHarvestUpgrade(HarvestUpgradeType ht)
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnCloseClicked()
	{
	}
}
