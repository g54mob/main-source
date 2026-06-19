using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ScreenFade : MonoBehaviour
	{
		[SerializeField]
		private Image _fadePanelImage;

		public void SetFadeOpacity(float amount)
		{
			if (amount <= 0f)
			{
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			Color color = _fadePanelImage.color;
			float a = Mathf.Pow(Mathf.Sin((amount - 0.5f) * (float)Math.PI) / 2f + 0.5f, 0.5f);
			color.a = a;
			_fadePanelImage.color = color;
		}

		public void SetFadeColor(Color color)
		{
			_fadePanelImage.color = color;
		}
	}
}
