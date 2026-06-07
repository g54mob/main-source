using System.Collections.Generic;
using Battle;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
	public class LargeTipsDialog : BaseDialog
	{
		[SerializeField]
		private RectTransform okButton;

		[SerializeField]
		private GameObject singlePageObj;

		[SerializeField]
		private RectTransform singlePageContetnt;

		[SerializeField]
		private GameObject allPageObj;

		[SerializeField]
		private RectTransform allPageContent;

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

		private Stack<GameObject> _openTips;

		private int _openIndex;

		private Sequence _displaySequence;

		private Dictionary<eLargeTips, int> _tipsPage;

		private bool _allViewMode;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		public void OpenTips(eLargeTips[] largeTips)
		{
		}

		private void OpenAllTips()
		{
		}

		private void ClearTips()
		{
		}

		public void OnOkButton()
		{
		}

		public override void Back()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PushEscape()
		{
		}

		private void OpenAnimationSequence()
		{
		}

		public void PushToPrevPage()
		{
		}

		public void PushToNextPage()
		{
		}

		private void UpdatePageButtons()
		{
		}
	}
}
