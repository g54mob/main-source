using System;
using System.Collections.Generic;
using Audio;
using InputControl;
using TMPro;
using UnityEngine;

namespace UI
{
	public class CollectionDialog : BaseDialog
	{
		public enum eCollectionPage
		{
			None = 0,
			Luggage = 1,
			Tool = 2,
			Enemy = 3,
			Reric = 4,
			Research = 5,
			Tips = 6
		}

		[Serializable]
		public struct PageCategory
		{
			public eCollectionPage page;

			public ToggleButtonGroup toggleButtonGroup;

			public TMP_Text progressText;

			public int progressCountMax;
		}

		[Serializable]
		public struct PageContent
		{
			public eCollectionPage page;

			public BaseCollectionPage detailPage;
		}

		public List<PageCategory> categoryButtons;

		public List<PageContent> pageContents;

		[SerializeField]
		private GameObject categoryButtonGroup;

		[SerializeField]
		private GameObject closeButton;

		[SerializeField]
		private List<GameObject> trialDisableObjects;

		[SerializeField]
		private PlaySEElement playSEElement;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private PadInputConfigure tabInputConfigure;

		[SerializeField]
		private CursorUIGroup tabCursorUIGroup;

		[SerializeField]
		private List<CursorUIGroup> allTargetGroups;

		private bool _disableClose;

		private bool _beforeSceneSwitchButtonEnable;

		private eCollectionPage _openPage;

		private List<eCollectionPage> _collectionPageOrder;

		public override void Back()
		{
		}

		public void OnPadBack()
		{
		}

		private void OnDisable()
		{
		}

		public override void Init()
		{
		}

		public override void Init<T>(T args)
		{
		}

		private void UpdateProgressCount(bool withInit = false)
		{
		}

		public override void Open()
		{
		}

		public override void Open<T>(T args)
		{
		}

		public override void OnBackOpen()
		{
		}

		private PageContent SelectPage(eCollectionPage page)
		{
			return default(PageContent);
		}

		private (PageCategory, PageContent) GetPage(eCollectionPage page)
		{
			return default((PageCategory, PageContent));
		}

		public void OpenPage(eCollectionPage page, int enumNumber)
		{
		}

		public void OpenTipsListPage(eLargeTips[] targetIds)
		{
		}

		public void AddCollection(eCollectionPage page, int enumNumber)
		{
		}

		public void UpdateUI(eCollectionPage page)
		{
		}

		public void SetDisableClose(bool disable)
		{
		}

		public void SetCurrentGroup()
		{
		}

		private void SetCurrentGroupOnly()
		{
		}

		public void PadTabSelect()
		{
		}

		public void OnClickUnitPage()
		{
		}

		public void OnClickToolPage()
		{
		}

		public void OnClickEnemyPage()
		{
		}

		public void OnClickRelicPage()
		{
		}

		public void OnClickResearchPage()
		{
		}

		public void OnClickTipsPage()
		{
		}

		public static void OpenTips(eLargeTips largeTips = eLargeTips.None)
		{
		}

		public static void OpenTipsList(eLargeTips[] targetIds, bool enableCloseButton = true, bool enablePushEscape = true)
		{
		}

		public override void PushEscape()
		{
		}
	}
}
