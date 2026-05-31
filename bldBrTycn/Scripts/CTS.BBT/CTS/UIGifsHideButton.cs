using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UIGifsHideButton : MonoBehaviour
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _cadre;

		[SerializeField]
		private Image _arrow;

		public void HideImages()
		{
			SetImageAlpha(_background, 0f);
			SetImageAlpha(_cadre, 0f);
			SetImageAlpha(_arrow, 0f);
		}

		public void NotInteractableButton()
		{
			SetImageAlpha(_background, 0.35f);
			SetImageAlpha(_cadre, 0.35f);
			SetImageAlpha(_arrow, 0.35f);
		}

		public void ShowImages()
		{
			SetImageAlpha(_background, 1f);
			SetImageAlpha(_cadre, 1f);
			SetImageAlpha(_arrow, 1f);
		}

		private void SetImageAlpha(Image image, float alpha)
		{
			if (image != null)
			{
				Color color = image.color;
				color.a = alpha;
				image.color = color;
			}
		}
	}
}
