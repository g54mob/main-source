using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_DropListAppearanceSlider : MonoBehaviour
	{
		[SerializeField]
		private RectTransform rectTransform;

		private CanvasGroup canvasGroup;

		private void Update()
		{
			if ((bool)canvasGroup || TryGetComponent<CanvasGroup>(out canvasGroup))
			{
				Vector3 localScale = new Vector3(rectTransform.localScale.x, canvasGroup.alpha, rectTransform.localScale.z);
				rectTransform.localScale = localScale;
			}
		}
	}
}
