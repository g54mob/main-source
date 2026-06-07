using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__56 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameOverUI _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003CnumXPGained_003E5__3;

		private CharMetaInst _003Cch_003E5__4;

		private CharInfoPanel _003CtgtPanel_003E5__5;

		private float _003ClastTickTime_003E5__6;

		private float _003CstartTime_003E5__7;

		private int _003CtgtXP_003E5__8;

		private int _003CnextXP_003E5__9;

		private int _003CcurBarXPGain_003E5__10;

		private float _003CxpGainLen_003E5__11;

		private BuildingType _003CidolType_003E5__12;

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
		public _003C_Run_003Ed__56(int _003C_003E1__state)
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

	public static GameOverUI I;

	public Localize LocTitle;

	public SlidingPanel PanelMain;

	public ScrollRect ScrlMain;

	public GameObject WrapperTime;

	public Localize LocLabelTime;

	public TextMeshProUGUI TxtFinalTime;

	public Localize LocFinalTime;

	public LocalizationParamsManager ParamsFinalTime;

	public RectTransform WrapperBest;

	public Localize LocLabelBest;

	public TextMeshProUGUI TxtBest;

	public Localize LocBest;

	public LocalizationParamsManager ParamsBest;

	public GameObject WrapperResources;

	public Localize LocLabelResources;

	public TextMeshProUGUI TxtResources;

	public GameObject WrapperKills;

	public Localize LocLabelKills;

	public TextMeshProUGUI TxtNumKills;

	public GameObject WrapperXP;

	public Localize LocLabelXP;

	public TextMeshProUGUI TxtNumXP;

	public CharInfoPanel CharInfPanel;

	public CharInfoPanel[] CharComboInfPanels;

	public PetDisplayItem[] PetInfPanels;

	public GameObject WrapperBlueprintsFound;

	public LocalizationParamsManager ParamsBlueprintsFound;

	public Image[] ImgBlueprintsFound;

	public GameObject WrapperTrophyBonus;

	public Image ImgTrophyIcon;

	public Localize LocTrophyName;

	public Localize LocTrophyBonus;

	public LocalizationParamsManager ParamsTrophyBonus;

	public GameObject WrapperGears;

	public Image ImgGear1;

	public Image ImgGear2;

	public LocalizationParamsManager ParamsGearsFound;

	public Localize LocHowToEarnGears;

	public GameObject WrapperBtns;

	public CoolButton BtnBase;

	public Localize LocBtnBase;

	public CoolButton BtnRestart;

	public Localize LocBtnRestart;

	public CoolButton BtnEndless;

	public SlidingPanel PanelStats;

	public ScrollRect ScrlStats;

	public SerializedObjectPool<GameOverBallStatItem> BallStatItemPool;

	private bool _isRunning;

	private const float kPanelYMargin = 80f;

	private void Awake()
	{
	}

	private void AddChildStats(HeroInst h, int childLvl)
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	public override void Shake(float amt, float len)
	{
	}

	private int CalculateXPEarned()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__56))]
	private IEnumerator<float> _Run()
	{
		return null;
	}

	public bool IsRunning()
	{
		return false;
	}

	public override void Deactivate()
	{
	}

	protected override void OnEntryComplete()
	{
	}

	private void OnBaseClicked()
	{
	}

	private void OnRestartClicked()
	{
	}

	private void OnExitDemoClicked()
	{
	}

	private void OnEndlessClicked()
	{
	}
}
