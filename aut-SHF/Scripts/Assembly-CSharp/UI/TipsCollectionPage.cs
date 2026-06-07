using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TipsCollectionPage : BaseCollectionPage
	{
		[SerializeField]
		private CollectionTipsListItem listItemPrefab;

		[SerializeField]
		private RectTransform listParent;

		[SerializeField]
		private TMP_Text pageTitleText;

		[SerializeField]
		private TMP_Text tipsTitleText;

		[SerializeField]
		private CollectionLargeTipsCtrl largeTipsCtrl;

		[SerializeField]
		private Button okButton;

		[SerializeField]
		private GameObject backButton;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private CursorUIGroup tipsGroup;

		[Header("Pager")]
		[SerializeField]
		private Button prevButton;

		[SerializeField]
		private Button nextButton;

		[SerializeField]
		private float onePageWidth;

		[SerializeField]
		private float pageMoveDuration;

		private List<CollectionTipsListItem> _listItemList;

		private bool finishInit;

		private bool isAnimation;

		private int page;

		private int pageMax;

		private int oldListCount;

		private const int listRowMax = 11;

		private const int listColumnMax = 2;

		private bool tipsViewMode;

		private int pageItemMax => 0;

		public override void Init()
		{
		}

		protected override void InitCollectionCountMax()
		{
		}

		public override int GetCollectionCount()
		{
			return 0;
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public CollectionTipsListItem CreateLargeTipsListElement(eLargeTips largeTips)
		{
			return null;
		}

		public void SelectItem(eLargeTips largeTips)
		{
		}

		public override void SelectItem(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		public void OpenTipsList(eLargeTips[] targetIds)
		{
		}

		public void OnClickOKButton()
		{
		}

		public void OnClickBackButton()
		{
		}

		private void ShowListView()
		{
		}

		private void ShowTipsView(bool fromCollection = true)
		{
		}

		private void UpdatePager()
		{
		}

		private void SetCursorItemList(int dir)
		{
		}

		public void MovePage(int dir)
		{
		}

		private void SetActiveListPager(bool active)
		{
		}

		public override void SortElements()
		{
		}

		public virtual void SortElements(List<CollectionTipsListItem> list)
		{
		}

		protected override int GetSortNum(CollectionListElement item)
		{
			return 0;
		}

		private int GetSortNum(CollectionTipsListItem item)
		{
			return 0;
		}
	}
}
