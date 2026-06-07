using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SelectChallengeDialog : BaseDialog
	{
		[Header("ContentsParent")]
		[SerializeField]
		private RectTransform contentsParent;

		[SerializeField]
		private RectTransform contentsPageBase;

		[Header("ItemPrefab")]
		[SerializeField]
		private SelectChallengeItem itemPrefab;

		[Header("MovePageButtons")]
		[SerializeField]
		private Button leftButton;

		[SerializeField]
		private Button rightButton;

		[SerializeField]
		private float onePageWidth;

		[SerializeField]
		private float pageMoveDuration;

		private bool isInitialized;

		private const int OnePageItemMax = 6;

		private int page;

		private int pageMax;

		private bool isAnimation;

		private float contentsParentBasePositionX;

		private List<RectTransform> pages;

		private List<SelectChallengeItem> items;

		public override void Init()
		{
		}

		private void ClearPages()
		{
		}

		private void CreateItems()
		{
		}

		public override void Open()
		{
		}

		private void OpenInit()
		{
		}

		public override void SetInFront()
		{
		}

		public void SelectChallenge(MstChallengeDataEntities data)
		{
		}

		public void MovePage(int dir)
		{
		}
	}
}
