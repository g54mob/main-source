using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class BaseNotificationDialog3DUIView : BaseDialog3DUIView
	{
		protected enum ScrollMode
		{
			None = 0,
			Top = 1,
			Bottom = 2
		}

		[SerializeField]
		protected Transform _blockContent;

		[SerializeField]
		protected GameObject _titleBlockPrefab;

		[SerializeField]
		protected GameObject _subTitleBlockPrefab;

		[SerializeField]
		protected GameObject _textBlockPrefab;

		[SerializeField]
		protected GameObject _decisionTextBlockPrefab;

		[SerializeField]
		protected GameObject _decisionButtonPrefab;

		[SerializeField]
		protected Transform _decisionContainer;

		[SerializeField]
		protected ScrollRect _scrollRect;

		protected ScrollMode _scrollMode;

		protected List<BaseBlock3DUIView> _blocks;

		protected UINotificationData _uiData;

		public UINotificationData UIData => null;

		protected virtual void Start()
		{
		}

		private void Update()
		{
		}

		public virtual void SetUIData(UINotificationData data)
		{
		}

		protected virtual void ClearAll()
		{
		}

		protected void ClearContent()
		{
		}

		protected virtual void ClearDecisionButtons()
		{
		}

		protected virtual void ShowPage(int page, Transform parent)
		{
		}

		protected void AddPageElements(UIDialogPageData page, Transform parent)
		{
		}

		protected virtual void DisplayPageTitle(UIDialogPageData page, Transform parent)
		{
		}

		protected void DisplayPageSubTitle(UIDialogPageData page, Transform parent)
		{
		}

		public virtual void UpdateUIData(UINotificationData uiNotificationData)
		{
		}

		protected virtual void DisplayPageText(UIDialogPageData page, Transform parent)
		{
		}

		protected void DisplayPagePastDecisionText(UIDialogPageData page, Transform parent)
		{
		}

		protected void DisplayPageImage(UIDialogPageData page, Transform parent)
		{
		}

		protected TextBlock3DUIView AddTextBlock(GameObject blockPrefab, string text, Transform parent)
		{
			return null;
		}

		protected virtual GameObject AddDecisionButton(NotificationDecision decision, Action<NotificationDecision, GameObject> callback, Transform decisionContainer)
		{
			return null;
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		protected override void Closed()
		{
		}
	}
}
