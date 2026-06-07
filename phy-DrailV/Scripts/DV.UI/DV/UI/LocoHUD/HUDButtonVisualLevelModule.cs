using System;
using UnityEngine.UI;

namespace DV.UI.LocoHUD
{
	public class HUDButtonVisualLevelModule : HUDVisualLevelModule
	{
		public Image[] onImages;

		public Image[] offImages;

		[NonSerialized]
		public bool on;

		public void ToggleImages(bool on)
		{
			Image[] array = onImages;
			foreach (Image image in array)
			{
				if (image.gameObject.activeSelf != on)
				{
					image.gameObject.SetActive(on);
				}
			}
			array = offImages;
			foreach (Image image2 in array)
			{
				if (image2.gameObject.activeSelf == on)
				{
					image2.gameObject.SetActive(!on);
				}
			}
		}

		public override void SetVisualLevel(float level)
		{
			on = level > 0.5f;
			ToggleImages(on);
		}

		public override float GetVisualLevel()
		{
			if (!on)
			{
				return 0f;
			}
			return 1f;
		}
	}
}
