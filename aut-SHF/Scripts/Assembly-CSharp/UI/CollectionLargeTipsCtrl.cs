using System.Collections.Generic;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class CollectionLargeTipsCtrl : MonoBehaviour
	{
		private class TipsPageData
		{
			public MstLargeTipsEntities largeTipsEntities;

			public GameObject tipsObj;
		}

		[SerializeField]
		private GameObject singlePageObj;

		[SerializeField]
		private RectTransform singlePageContensParent;

		[SerializeField]
		private GameObject pagingObj;

		[SerializeField]
		private RectTransform pagingContentsParent;

		[SerializeField]
		private GameObject buttonGroup;

		[SerializeField]
		private EmphasisObj prevPageButton;

		[SerializeField]
		private EmphasisObj nextPageButton;

		[SerializeField]
		[Label("次のTipsに移動する時間")]
		private float turnDuration;

		[SerializeField]
		private TMP_Text pageText;

		private int _openIndex;

		private List<TipsPageData> _openTipsList;

		public UnityAction<MstLargeTipsEntities> changePageAction;

		public bool ReadAllPageJustOnce { get; private set; }

		public void Init()
		{
		}

		public void Open(eLargeTips largeTips)
		{
		}

		public void Open(eLargeTips[] targetIds)
		{
		}

		private void CreateTipsContent(RectTransform parent, eLargeTips largeTips)
		{
		}

		private void ClearTips()
		{
		}

		public void PushToPrevPage()
		{
		}

		public void PushToNextPage()
		{
		}

		private void UpdatePageUI()
		{
		}
	}
}
