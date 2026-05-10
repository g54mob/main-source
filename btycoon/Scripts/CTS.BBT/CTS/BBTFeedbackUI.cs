using CTS.UI;
using PixelCrushers.DialogueSystem.Wrappers;
using UnityEngine;

namespace CTS
{
	public class BBTFeedbackUI : StandardUISubtitlePanel
	{
		[SerializeField]
		private CanvasGroupController _groupController;

		public override void Close()
		{
			if ((bool)_groupController)
			{
				_groupController.QuickHide();
			}
		}

		public override void Open()
		{
			if ((bool)_groupController)
			{
				_groupController.QuickShow();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (!_groupController)
			{
				_groupController = GetComponent<CanvasGroupController>();
			}
		}
	}
}
