using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.FloatingOverlaySystem
{
	public class CircularProgressBarFloatingElement : ProgressBarFloatingElement
	{
		[SerializeField]
		private Image sliderImage;

		[SerializeField]
		private Image fillImage;

		private List<Image> allImages;

		public Image FillImage => fillImage;

		protected override void Start()
		{
			base.Start();
			allImages = GetComponentsInChildren<Image>().ToList();
		}

		protected override void OnValueUpdated()
		{
			if (!(sliderImage == null) && !sliderImage.IsDestroyed())
			{
				sliderImage.fillAmount = base.Value;
			}
		}
	}
}
