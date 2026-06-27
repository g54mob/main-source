using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public class GUI_TooltipIndicator : MonoBehaviour
	{
		[SerializeField]
		private RectTransform rectTransform;

		public void Init(Vector2 size, Vector2 offset)
		{
			rectTransform.sizeDelta = size;
			rectTransform.anchoredPosition = offset;
		}
	}
}
