using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Victory_Popup : APopupWindow
{
	[Serializable]
	public class ShieldImageSprites
	{
		public eShieldImageType shieldImageType;

		public Sprite shield;

		public Sprite shield_BackTop;

		public Sprite shield_BackBottom;
	}

	public enum eShieldImageType
	{
		RED = 0,
		BLUE = 1,
		PURPLE = 2
	}

	public enum eResultDetailType
	{
		DETAIL = 0,
		LEADERBOARD = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_FinalVictoryProc_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Victory_Popup _003C_003E4__this;

		private SingleEventCapturer _003Csc_UI_VictoryUI_RequestStart2ndPart_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCR_FinalVictoryProc_003Ed__69(int _003C_003E1__state)
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
	private sealed class _003CCR_ShowLeaderboard_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Victory_Popup _003C_003E4__this;

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
		public _003CCR_ShowLeaderboard_003Ed__74(int _003C_003E1__state)
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
	private sealed class _003CCR_VictoryProc_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Victory_Popup _003C_003E4__this;

		private SingleEventCapturer _003Csc_UI_VictoryUI_RequestStart2ndPart_003E5__2;

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
		public _003CCR_VictoryProc_003Ed__68(int _003C_003E1__state)
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
	private float waitTimeAfterVictory;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private CanvasGroup canvasGroup_Buttons;

	[SerializeField]
	[Header("按鈕: 繼續下一關")]
	private Button button_Continue;

	[SerializeField]
	[Header("按鈕: 回到CoinPage")]
	private Button button_BackToMenu;

	[SerializeField]
	[Header("按鈕: 檢視地圖")]
	private Button button_ViewMap;

	[SerializeField]
	[Header("按鈕: 返回")]
	private Button button_Back;

	[SerializeField]
	private GameObject node_JoystickBack;

	[SerializeField]
	[Header("文字: 標題")]
	private TMP_Text text_Title;

	[SerializeField]
	[Header("文字: 世界名稱")]
	private TMP_Text text_WorldName;

	[SerializeField]
	[Header("文字: 世界名稱(數值頁)")]
	private TMP_Text text_WorldName_Detail;

	[SerializeField]
	[Header("文字: 困難度")]
	private TMP_Text text_Difficulty;

	[SerializeField]
	[Header("文字: 自訂遊戲")]
	private TMP_Text text_CustomGame;

	[SerializeField]
	[Header("文字: 獲得餘燼石數量")]
	private TMP_Text text_GemValue;

	[SerializeField]
	[Header("文字: 獲得經驗值數量")]
	private TMP_Text text_ExpValue;

	[SerializeField]
	[Header("文字: 獲得重骰數量")]
	private TMP_Text text_RerollCountValue;

	[SerializeField]
	[Header("文字: 總分")]
	private TMP_Text text_TotalScore;

	[SerializeField]
	[Header("文字: 總分")]
	private TMP_Text text_GameSeed;

	[SerializeField]
	[Header("圖片: 盾牌標誌_主要")]
	private Image image_ShieldIcon_Main;

	[SerializeField]
	[Header("圖片: 盾牌標誌_背景上層")]
	private Image image_ShieldIcon_BackTop;

	[SerializeField]
	[Header("圖片: 盾牌標誌_背景下層")]
	private Image image_ShieldIcon_BackBottom;

	[SerializeField]
	private GameObject node_Details;

	[SerializeField]
	private GameObject node_Reward_Card;

	[SerializeField]
	private UI_CardFace cardFace_Reward;

	[SerializeField]
	private Animator animator_Reward_Exp;

	[SerializeField]
	private Animator animator_Reward_Gem;

	[SerializeField]
	private Animator animator_Reward_Card;

	[SerializeField]
	private Animator animator_Reward_RerollCount;

	[SerializeField]
	private Transform node_VictoryMapIcons;

	[SerializeField]
	private Transform node_BlockCards;

	[SerializeField]
	private Transform node_TowerCards;

	[SerializeField]
	private MapNodePrefabData mapNodePrefabData;

	[SerializeField]
	private ParticleSystem particle_NormalClearCommon;

	[SerializeField]
	private ParticleSystem particle_FinalClearCommon;

	[SerializeField]
	private ParticleSystem particle_CasualClear;

	[SerializeField]
	private ParticleSystem particle_NormalClear;

	[SerializeField]
	private ParticleSystem particle_HeroicClear;

	[SerializeField]
	private GameObject prefab_CardFace;

	[SerializeField]
	private TMP_Text text_VictoryStats;

	[SerializeField]
	private TMP_Text text_CharacterAndFireType;

	[SerializeField]
	private UI_Obj_ElementPieChart ui_Obj_ElementPieChart;

	[SerializeField]
	private UI_Obj_SmallTalentBoard ui_Obj_SmallTalentBoard;

	[SerializeField]
	private UI_RelicList ui_RelicList;

	[SerializeField]
	private UI_LeaderBoard ui_LeaderBoard;

	[SerializeField]
	private List<ShieldImageSprites> list_ShieldImageTypes;

	private bool isButtonClicked;

	private bool isViewMapState;

	private float mouseMoveTimer;

	private Vector3 lastMousePosition;

	private bool isFinalVictory;

	public List<MapNode> list_Mapnodes;

	private void Awake()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnAddRuneToTetrisCardComplete(TetrisCardData data)
	{
	}

	public void Setup(bool isFinalBoss, eResultDetailType detailType, eShieldImageType shieldImageType)
	{
	}

	public void Setup_FinalVictory()
	{
	}

	private void Update()
	{
	}

	private void OnClickViewMap()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void OnClickBack()
	{
	}

	private void OnClickBackToMenu()
	{
	}

	private void OnClickContinue()
	{
	}

	public void StartVictoryProc(TetrisCardData tetrisCardData, bool haveStageReward)
	{
	}

	private TowerSettingData GetRandomNewTower()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_VictoryProc_003Ed__68))]
	private IEnumerator CR_VictoryProc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_FinalVictoryProc_003Ed__69))]
	private IEnumerator CR_FinalVictoryProc()
	{
		return null;
	}

	public void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void ShowLeaderboard()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowLeaderboard_003Ed__74))]
	private IEnumerator CR_ShowLeaderboard()
	{
		return null;
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
