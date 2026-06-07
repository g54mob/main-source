using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseUIMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunEntryPopups_003Ed__32 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseUIMgr _003C_003E4__this;

		private LevelData _003ClastPlayedLvlData_003E5__2;

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
		public _003C_RunEntryPopups_003Ed__32(int _003C_003E1__state)
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

	public static BaseUIMgr I;

	public BaseUI Base;

	public SlidingPanel PanelMainBar;

	public BuildUI Build;

	public WorkerUI Worker;

	public DialogUI Dialog;

	public CharSelectUI CharSelect;

	public LevelSelectUI LevelSelect;

	public BasePauseUI Pause;

	public CharStatsUI CharStats;

	public BaseHoverPopup HovPopup;

	public UpgradeBuildingUI Building;

	public HarvestSummaryUI HarvestSummary;

	public MarketUI Market;

	public MasseuseUI Masseuse;

	public BaseReturnUI BaseReturn;

	public AssignWorkerUI AssignWorker;

	public BaseSettingsUI Settings;

	public MaskedFTUEOverlay FTUEOverlay;

	public ControllerCursorUI ControllerCursor;

	public LoadoutUI PetSelect;

	public GameCheatUI Cheat;

	public ItemUnlockUI ItemUnlock;

	public EncyclopediaUI Encyclopedia;

	public TouchControlsUI TouchControls;

	public GameTutUI Tut;

	public LeaderboardUI LB;

	public FullScreenMessageUI FullScreenMessage;

	public TwitchVoteUI TwitchVote;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void RunEntryPopups()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEntryPopups_003Ed__32))]
	public IEnumerator<float> _RunEntryPopups()
	{
		return null;
	}

	public bool IsOverlayActive()
	{
		return false;
	}
}
