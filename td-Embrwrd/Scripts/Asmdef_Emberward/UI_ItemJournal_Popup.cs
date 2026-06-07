using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_ItemJournal_Popup : APopupWindow
{
	private enum ePageType
	{
		TOWER = 0,
		RELIC = 1,
		MONSTER = 2,
		TUTORIAL = 3,
		ACHIEVEMENT = 4
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShowWindowProc_003Ed__117 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ItemJournal_Popup _003C_003E4__this;

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
		public _003CCR_ShowWindowProc_003Ed__117(int _003C_003E1__state)
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
	private sealed class _003CCR_SwitchPage_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ItemJournal_Popup _003C_003E4__this;

		public ePageType pageType;

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
		public _003CCR_SwitchPage_003Ed__89(int _003C_003E1__state)
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
	private GameObject prefab_ShopCard;

	[SerializeField]
	private GameObject prefab_JournalEntry;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private Button button_TowerPage;

	[SerializeField]
	private Button button_RelicPage;

	[SerializeField]
	private Button button_MonsterPage;

	[SerializeField]
	private Button button_TutorialPage;

	[SerializeField]
	private Button button_AchievementPage;

	[SerializeField]
	private Transform node_MainPagePaper;

	[SerializeField]
	private Transform node_DecoPage1;

	[SerializeField]
	private Transform node_DecoPage3;

	[SerializeField]
	private Transform node_NotUsingPage;

	[SerializeField]
	private List<UI_ScrollView_AutoScrollToSelected> list_ScrollViewAutoScroller;

	[Header("砲塔頁node")]
	[SerializeField]
	private GameObject node_TowerPage;

	[Header("砲塔頁CanvasGroup")]
	[SerializeField]
	private CanvasGroup canvasGroup_TowerPage;

	[SerializeField]
	[Header("Scroll view")]
	private ScrollRect scrollView_TowerPage;

	[Header("GridLayout")]
	[SerializeField]
	private RectTransform layout_TowerPage;

	[Header("文字: 未發現砲塔")]
	[SerializeField]
	private TMP_Text text_UndiscoveredTowerCard;

	[SerializeField]
	[Header("文字: 砲塔描述")]
	private TMP_Text text_TowerDescription;

	[Header("文字: 砲塔升級A")]
	[SerializeField]
	private TMP_Text text_TowerUpgradeA;

	[Header("文字: 砲塔升級B")]
	[SerializeField]
	private TMP_Text text_TowerUpgradeB;

	[SerializeField]
	[Header("選擇的砲塔卡片")]
	private UI_Obj_ShopCard selectedCard_TowerPage;

	[Header("砲塔卡片清單node")]
	[SerializeField]
	private Transform anchor_TowerCards;

	[Header("砲塔filter按鈕")]
	[SerializeField]
	private List<UI_JournalTowerFilterButton> list_TowerFilterButtons;

	[SerializeField]
	[Header("砲塔已建造數量")]
	private TMP_Text text_TowerBuiltCount;

	[SerializeField]
	[Header("神器頁node")]
	private GameObject node_RelicPage;

	[SerializeField]
	[Header("神器頁CanvasGroup")]
	private CanvasGroup canvasGroup_RelicPage;

	[Header("GridLayout")]
	[SerializeField]
	private RectTransform layout_RelicPage;

	[SerializeField]
	[Header("Scroll view")]
	private ScrollRect scrollView_RelicPage;

	[SerializeField]
	[Header("選擇的神器卡片")]
	private UI_Obj_ShopCard selectedCard_RelicPage;

	[Header("神器卡片清單node")]
	[SerializeField]
	private Transform anchor_RelicCards;

	[Header("文字: 未發現神器")]
	[SerializeField]
	private TMP_Text text_UndiscoveredRelicCard;

	[SerializeField]
	[Header("文字: 神器描述")]
	private TMP_Text text_RelicDescription;

	[SerializeField]
	[Header("文字: 神器已使用數量")]
	private TMP_Text text_RelicUsedCount;

	[Header("怪物頁CanvasGroup")]
	[SerializeField]
	private CanvasGroup canvasGroup_MonsterPage;

	[Header("Scroll view")]
	[SerializeField]
	private ScrollRect scrollView_MonsterPage;

	[SerializeField]
	[Header("GridLayout")]
	private RectTransform layout_MonsterPage;

	[SerializeField]
	[Header("怪物資料清單node")]
	private Transform anchor_MonsterCards;

	[SerializeField]
	[Header("怪物圖片node")]
	private Transform node_MonsterSprite;

	[Header("怪物圖片")]
	[SerializeField]
	private Image image_MonsterSprite;

	[SerializeField]
	[Header("怪物圖片背景")]
	private Image image_MonsterSpriteBG;

	[Header("怪物名稱")]
	[SerializeField]
	private TMP_Text text_MonsterName;

	[Header("怪物數值文字")]
	[SerializeField]
	private TMP_Text text_MonsterStats;

	[Header("怪物描述文字")]
	[SerializeField]
	private TMP_Text text_MonsterDescription;

	[SerializeField]
	[Header("未發現的怪物數值文字 (???)")]
	private TMP_Text text_UndiscoveredMonsterStats;

	[SerializeField]
	[Header("未發現的怪物描述文字 (???)")]
	private TMP_Text text_UndiscoveredMonsterDescription;

	[SerializeField]
	[Header("煉獄裂片額外強化的node")]
	private GameObject node_InfernalShardDescription;

	[SerializeField]
	[Header("煉獄裂片額外強化文字")]
	private TMP_Text text_InfernalShardDescription;

	[SerializeField]
	[Header("教學設定")]
	private TutorialSettingData tutorialSettingData;

	[SerializeField]
	[Header("教學圖片")]
	private Image image_Tutorial;

	[SerializeField]
	[Header("教學頁CanvasGroup")]
	private CanvasGroup canvasGroup_TutorialPage;

	[SerializeField]
	[Header("GridLayout")]
	private RectTransform layout_TutorialPage;

	[SerializeField]
	[Header("Scroll view")]
	private ScrollRect scrollView_TutorialPage;

	[SerializeField]
	[Header("文字: 教學標題")]
	private TMP_Text text_TutorialTitle;

	[Header("文字: 教學描述")]
	[SerializeField]
	private TMP_Text text_TutorialDescription;

	[SerializeField]
	[Header("文字: 未知教學")]
	private TMP_Text text_TutorialUnknown;

	[SerializeField]
	[Header("教學卡片清單node")]
	private Transform anchor_TutorialCards;

	[SerializeField]
	[Header("教學卡片圖示: 已知")]
	private Sprite sprite_TutorialIcon_Learned;

	[Header("教學卡片圖示: 未知")]
	[SerializeField]
	private Sprite sprite_TutorialIcon_Unknown;

	[Header("教學圖片: 未知")]
	[SerializeField]
	private Sprite sprite_Tutorial_Unknown;

	[Header("成就頁CanvasGroup")]
	[SerializeField]
	private CanvasGroup canvasGroup_AchievementPage;

	[Header("Scroll view")]
	[SerializeField]
	private ScrollRect scrollView_AchievementPage;

	[SerializeField]
	[Header("GridLayout")]
	[FormerlySerializedAs("node_GridLayout")]
	private RectTransform layout_AchievementPage;

	[SerializeField]
	[Header("成就內容Prefab")]
	private GameObject prefab_AchievementJournalEntry;

	[SerializeField]
	[Header("Node: 隱藏已完成成就")]
	private GameObject node_HideCompletedAchievements;

	[SerializeField]
	[Header("Toggle: 隱藏已完成成就")]
	private Toggle toggle_HideCompletedAchievements;

	[SerializeField]
	[Header("Node: Demo版不能解鎖成就的提示")]
	private GameObject node_NoAchievementInDemoWarning;

	private bool isTowerPageInitialized;

	private bool isRelicPageInitialized;

	private bool isMonsterPageInitialized;

	private bool isTutorialPageInitialized;

	private bool isAchievementPageInitialized;

	private bool isSwitchingPage;

	private ePageType currentPage;

	public Action OnWindowCancel;

	public Action OnWindowComplete;

	private List<UI_Obj_ShopCard> list_TowerCards;

	private Tweener towerCardClickTween;

	private eItemFilterType currentTowerFilter;

	private List<UI_Obj_ShopCard> list_RelicCards;

	private Tweener relicCardClickTween;

	private List<Obj_UI_JournalEntry> list_MonsterCards;

	private Tweener monsterCardClickTween;

	private List<Obj_UI_JournalEntry> list_TutorialCards;

	private List<Obj_UI_AchievementJournalEntry> list_AchievementEntries;

	private bool doShowHideCompletedAchievementsOption;

	private bool doHideCompletedAchievements;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void Update()
	{
	}

	private void OnClickButton_TowerPage()
	{
	}

	private void OnClickButton_RelicPage()
	{
	}

	private void OnClickButton_MonsterPage()
	{
	}

	private void OnClickButton_TutorialPage()
	{
	}

	private void OnClickButton_AchievementPage()
	{
	}

	private void SwitchPage(ePageType pageType, bool doAnimation = true)
	{
	}

	private CanvasGroup GetCanvasGroupByPageType(ePageType pageType)
	{
		return null;
	}

	private void BindPageToNode(ePageType pageType, Transform node)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SwitchPage_003Ed__89))]
	private IEnumerator CR_SwitchPage(ePageType pageType)
	{
		return null;
	}

	private void OnClickButton_Leave()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	private void InitializeTowerPage()
	{
	}

	private void OnTowerCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void OnTowerFilterClicked(eItemFilterType filterType, UI_JournalTowerFilterButton selectedFilterButton)
	{
	}

	private void InitializeRelicPage()
	{
	}

	private void OnRelicCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void InitializeMonsterPage()
	{
	}

	private void OnMonsterCardClicked(eMonsterType type)
	{
	}

	private void InitializeTutorialPage()
	{
	}

	private void OnTutorialCardClicked(eTutorialType type)
	{
	}

	private void InitializeAchievementPage()
	{
	}

	private void OnToggleHideCompletedAchievementsChanged(bool doHideCompleted)
	{
	}

	private void UpdateEntryVisibilityBasedOnCompletion()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShowWindowProc_003Ed__117))]
	private IEnumerator CR_ShowWindowProc()
	{
		return null;
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void TowerPageJoystickInit()
	{
	}

	private void RelicPageJoystickInit()
	{
	}

	private void MonsterPageJoystickInit()
	{
	}

	private void TutorialPageJoystickInit()
	{
	}

	private void AchievementPageJoystickInit()
	{
	}
}
