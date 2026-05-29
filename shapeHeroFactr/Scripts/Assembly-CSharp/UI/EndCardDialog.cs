using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class EndCardDialog : BaseDialog
	{
		[SerializeField]
		private GameObject returnTitleButton;

		[SerializeField]
		private CanvasGroup endCard;

		[SerializeField]
		private Image emphasisImage;

		public override void Init()
		{
		}

		public void OnClickReturnFactory()
		{
		}

		public void OnClickReturnTitle()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PushEscape()
		{
		}
	}
}
