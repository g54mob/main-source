using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.CurveEditor
{
	[ExecuteAlways]
	public class RotatedUIItemSizeSetter : UIBehaviour
	{
		private Vector2? _lastSize;

		private void Update()
		{
			RectTransform rectTransform = base.transform as RectTransform;
			if (!(rectTransform == null))
			{
				RectTransform rectTransform2 = rectTransform.parent as RectTransform;
				if (!(rectTransform2 == null) && _lastSize != rectTransform2.rect.size)
				{
					_lastSize = rectTransform2.rect.size;
					Vector2 anchorMin = (rectTransform.anchorMax = rectTransform.pivot);
					rectTransform.anchorMin = anchorMin;
					rectTransform.sizeDelta = new Vector2(rectTransform2.rect.height, rectTransform2.rect.width);
				}
			}
		}
	}
}
