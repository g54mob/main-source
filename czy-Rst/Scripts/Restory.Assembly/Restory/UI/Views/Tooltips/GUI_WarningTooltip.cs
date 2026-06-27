using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class GUI_WarningTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text text;

		public void SetUp(string text, Transform followTransform)
		{
			this.text.text = text;
			SetFollowTransform(followTransform);
		}
	}
}
