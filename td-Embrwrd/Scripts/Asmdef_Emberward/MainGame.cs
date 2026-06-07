using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainGame : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public bool isWaveFinished;

		public Action _003C_003E9__4;

		internal void _003CCR_GameProc_003Eb__4()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public bool isQuestSelected;

		internal void _003CCR_GameProc_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_2
	{
		public bool isTutorialFinished;

		public bool isQueuedTutorialFinished;

		internal void _003CCR_GameProc_003Eb__1()
		{
		}

		internal void _003CCR_GameProc_003Eb__2()
		{
		}

		internal void _003CCR_GameProc_003Eb__3()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_3
	{
		public UI_MiniShop_Popup ui_MiniShop_Popup;

		internal bool _003CCR_GameEndProc_RogueliteMode_003Eb__3()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CBeforeWaveStartProcess_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

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
		public _003CBeforeWaveStartProcess_003Ed__45(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_Debug_BackToMapScene_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_Debug_BackToMapScene_003Ed__33(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_DrawCardAtRoundStart_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

		private int _003CdrawCardCount_003E5__2;

		private int _003Ci_003E5__3;

		private List<CardData> _003Clist_royalRuneCards_003E5__4;

		private List<CardData>.Enumerator _003C_003E7__wrap4;

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
		public _003CCR_DrawCardAtRoundStart_003Ed__44(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_GameEndProc_Endless_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

		private UI_Defeat_Popup _003Cwindow_003E5__2;

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
		public _003CCR_GameEndProc_Endless_003Ed__37(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_GameEndProc_RogueliteMode_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

		private _003C_003Ec__DisplayClass35_3 _003C_003E8__1;

		private bool _003CisBossLevel_003E5__2;

		private float _003Ctimeout_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private bool _003CisAllExpCollected_003E5__5;

		private UI_ThankYouForPlayDemo_Popup _003Cwindow_003E5__6;

		private StageRewardData _003Creward_003E5__7;

		private PanelSettingData _003CtetrisSettingData_003E5__8;

		private TetrisCardData _003CnewTetrisCardData_003E5__9;

		private SingleEventCapturer _003Csc_UI_VictoryUICompleted_003E5__10;

		private List<AItemSettingData> _003CtowerList_003E5__11;

		private List<AItemSettingData> _003CrelicsList_003E5__12;

		private SingleEventCapturer _003Csc_UI_VictoryUIContinue_003E5__13;

		private UI_AltarEffectReward_Popup _003CaltarRewardUIPopup_003E5__14;

		private UI_QuestReward_Popup _003CquestRewardUIPopup_003E5__15;

		private int _003CgiveTowerCount_003E5__16;

		private int _003Ci_003E5__17;

		private UI_Defeat_Popup _003Cwindow_003E5__18;

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
		public _003CCR_GameEndProc_RogueliteMode_003Ed__35(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_GameEndProc_ScoreAttack_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

		private SingleEventCapturer _003Csc_UI_VictoryUICompleted_003E5__2;

		private SingleEventCapturer _003Csc_UI_VictoryUIContinue_003E5__3;

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
		public _003CCR_GameEndProc_ScoreAttack_003Ed__36(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_GameProc_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGame _003C_003E4__this;

		private _003C_003Ec__DisplayClass34_1 _003C_003E8__1;

		private _003C_003Ec__DisplayClass34_0 _003C_003E8__2;

		private _003C_003Ec__DisplayClass34_2 _003C_003E8__3;

		private bool _003CisRandomPlacementDone_003E5__2;

		private int _003CrandomPlacementRetryCount_003E5__3;

		private bool _003CisBossDeadInBossStage_003E5__4;

		private UI_BossExtraSkill_Popup _003Cwindow_003E5__5;

		private eItemType _003CfirstAnomalyType_003E5__6;

		private eItemType _003CsecondAnomalyType_003E5__7;

		private eItemType _003CbuffAnomalyType_003E5__8;

		private PerkSettingData _003CanomalyData_003E5__9;

		private PerkSettingData _003CsecondAnomalyData_003E5__10;

		private PerkSettingData _003CbuffAnomalyData_003E5__11;

		private List<AltarPactData> _003Clist_altarPactData_003E5__12;

		private List<PerkSettingData> _003Clist_perkSettingData_003E5__13;

		private UI_QuestAnnounce_Popup _003CquestAnnouncePopup_003E5__14;

		private SingleEventCapturer _003Csc_RequestStartNextWave_003E5__15;

		private eEndlessModeRoundRewardType _003CendlessModeRoundRewardType_003E5__16;

		private UI_WaveClear _003Cwindow_003E5__17;

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
		public _003CCR_GameProc_003Ed__34(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_PlayWorldBGM_Delay_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public MainGame _003C_003E4__this;

		public float offset;

		public float fadetime;

		public float pitch;

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
		public _003CCR_PlayWorldBGM_Delay_003Ed__42(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_SlowMotion_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_SlowMotion_003Ed__39(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_UnlockProcess_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_UnlockProcess_003Ed__38(int _003C_003E1__state)
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

	[SerializeField]
	private IngameData ingameData;

	[SerializeField]
	private ObjectPlacementHandler objectPlacementHandler;

	[SerializeField]
	private Obj_GridInputControl gridInputControl;

	private string musicKey;

	private static MainGame instance;

	private StageDataReader stageDataReader;

	private int round;

	private int maxRound;

	private readonly float ROUND_PREPARE_TIME;

	private EnvSceneCollectionData.EnvSceneDataEntry sceneEntry;

	private float roundCountdown;

	private int[] roundClearReward;

	private int coinsSavedForNextLevel;

	private int debug_TowerOverchargeTestIndex;

	public IngameData IngameData => null;

	public ObjectPlacementHandler ObjectPlacementHandler => null;

	public Obj_GridInputControl GridInputControl => null;

	public static MainGame Instance => null;

	public int Round => 0;

	public int MaxRound => 0;

	public float RoundCountdown => 0f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void PauseGame()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Debug_BackToMapScene_003Ed__33))]
	private IEnumerator CR_Debug_BackToMapScene()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameProc_003Ed__34))]
	private IEnumerator CR_GameProc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameEndProc_RogueliteMode_003Ed__35))]
	private IEnumerator CR_GameEndProc_RogueliteMode()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameEndProc_ScoreAttack_003Ed__36))]
	private IEnumerator CR_GameEndProc_ScoreAttack()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameEndProc_Endless_003Ed__37))]
	private IEnumerator CR_GameEndProc_Endless()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_UnlockProcess_003Ed__38))]
	private IEnumerator CR_UnlockProcess(bool checkCharacter, bool checkEmber)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_SlowMotion_003Ed__39))]
	private IEnumerator CR_SlowMotion()
	{
		return null;
	}

	private void PlayWorldBGM(float offset, float fadetime = 1f, float pitch = 1f)
	{
	}

	private void PlayWorldBGM_Delay(float offset, float delay, float fadetime = 1f, float pitch = 1f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlayWorldBGM_Delay_003Ed__42))]
	private IEnumerator CR_PlayWorldBGM_Delay(float offset, float delay, float fadetime = 1f, float pitch = 1f)
	{
		return null;
	}

	public Coroutine DrawCardAtRoundStart()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_DrawCardAtRoundStart_003Ed__44))]
	private IEnumerator CR_DrawCardAtRoundStart()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CBeforeWaveStartProcess_003Ed__45))]
	private IEnumerator BeforeWaveStartProcess()
	{
		return null;
	}

	private float GetRoundFullPrepareTime()
	{
		return 0f;
	}

	private List<AItemSettingData> GetStageRewardSettingData(eCardType cardType)
	{
		return null;
	}
}
