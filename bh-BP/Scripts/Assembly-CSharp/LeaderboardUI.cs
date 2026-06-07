using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_WaitAndFakeTop_003Ed__82 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LeaderboardUI _003C_003E4__this;

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
		public _003C_WaitAndFakeTop_003Ed__82(int _003C_003E1__state)
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

	public static LeaderboardUI I;

	public LBPage CurPage;

	[NamedArray(typeof(LBPage))]
	public GameObject[] WrapperPages;

	public LBType TgtLB;

	public LBFilter TgtFilter;

	public LBFilter TgtFilterVisible;

	public LBLoadState CurLoadState;

	private float _lbLoadStateChangeTime;

	public CharType TgtChar;

	public LevelType TgtLvl;

	public int TgtNGPlus;

	public LBParams TgtParams;

	public int RangeStart;

	public int RangeEnd;

	public ScrollRect ScrlSelect;

	public Image ImgSelectLBIcon;

	public Localize LocSelectLBTitle;

	public LocalizationParamsManager ParamsSelectLBTitle;

	public SerializedObjectPool<LeaderboardSelectItem> SelectItemPool;

	public CoolSelectableWrapper SelectWrapper;

	public CoolSelectableWrapper LBItemWrapper;

	public Localize LocLBTitle;

	public LocalizationParamsManager ParamsLBTitle;

	public CoolButton BtnClose;

	public Image ImgIcon;

	public Image ImgLBCharIcon;

	public BtnPromptImg BtnPromptLB;

	public BtnPromptImg BtnPromptRB;

	public MultiVizCoolButton[] BtnFilter;

	public CoolButtonViz VizFilterLoading;

	public CoolButtonViz VizFilterLoaded;

	public CoolButtonViz VizFilterTxtLoading;

	public CoolButtonViz VizFilterTxtLoaded;

	public LeaderboardUIItem[] Items;

	public GameObject WrapperLoading;

	public GameObject WrapperNoResults;

	public GameObject WrapperPrevPage;

	public CoolButton BtnPrevPage;

	public GameObject WrapperNextPage;

	public CoolButton BtnNextPage;

	public ScrollRect ScrlDetails;

	public GameObject WrapperDetails;

	public TextMeshProUGUI TxtDetailsName;

	public GameObject WrapperViewProfilePrompt;

	public TextMeshProUGUI TxtDetailsScore;

	public Image ImgDetailsChar1;

	public Image ImgDetailsChar2;

	public GameObject DetailsStatsWrapper;

	public Localize LocDetailsDifficulty;

	public LocalizationParamsManager ParamsDetailsDifficulty;

	public Localize LocDetailsChar1Name;

	public Localize LocDetailsChar2Name;

	public LocalizationParamsManager ParamsDetailsChar1Lvl;

	public LocalizationParamsManager ParamsDetailsChar2Lvl;

	public LocalizationParamsManager ParamsDetailsKills;

	public TextMeshProUGUI[] TxtDetailsStats;

	public GameObject[] BallRows;

	public LeaderboardEquipmentItem[] ImgBalls;

	public GameObject[] PassiveRows;

	public LeaderboardEquipmentItem[] ImgPassives;

	public const int kPageSize = 8;

	public const int kGlobalRangeStart = -4;

	private int _rankStart;

	private int _rankEnd;

	private List<LBEntry> _scores;

	private CharType _detailsChar1;

	private CharType _detailsChar2;

	private const float kTimeoutLen = 30f;

	private int _hoverLBEntryVersion;

	private void Awake()
	{
	}

	public void Activate(LBType lb)
	{
	}

	public void Activate(LevelType lvl, int ngPlus)
	{
	}

	public void Activate(CharType c)
	{
	}

	private void SetPage(LBPage pg)
	{
	}

	public void SetLoadState(LBLoadState st)
	{
	}

	protected override void MyUpdate()
	{
	}

	private void OnLoadTimeout()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void ResetRange()
	{
	}

	private void OnScoresRetrieved(List<LBEntry> scores, LBType lbType)
	{
	}

	private void OnScoresRetrieved(List<LBEntry> scores, string lbID)
	{
	}

	private void OnScoresRetrieved(List<LBEntry> scores)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndFakeTop_003Ed__82))]
	private IEnumerator<float> _WaitAndFakeTop()
	{
		return null;
	}

	private void FillLeaderboards()
	{
	}

	public void SetLB(LBType lb)
	{
	}

	public void SetLB(LBParams prams)
	{
	}

	public void SetFilter(LBFilter f)
	{
	}

	private void OnFriendsClicked()
	{
	}

	private void OnGlobalClicked()
	{
	}

	private void OnTopClicked()
	{
	}

	private bool ShouldShowPrev()
	{
		return false;
	}

	private bool ShouldShowNext()
	{
		return false;
	}

	private void OnPrevClicked()
	{
	}

	private void OnNextClicked()
	{
	}

	private void RefreshBtns()
	{
	}

	public void FetchLeaderboards()
	{
	}

	public void HoverItem(LeaderboardUIItem item)
	{
	}

	public void CreateItem(LBParams prams)
	{
	}

	public void CreateItem(LevelType lt)
	{
	}

	public void SelectItem(LeaderboardSelectItem item)
	{
	}
}
