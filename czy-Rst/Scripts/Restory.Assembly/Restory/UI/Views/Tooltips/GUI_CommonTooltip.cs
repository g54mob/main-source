using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public class GUI_CommonTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text mainText;

		public void Init(string text, Transform followTransform)
		{
			mainText.text = text;
			SetFollowTransform(followTransform);
		}
	}
}
