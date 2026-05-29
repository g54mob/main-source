using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class CutsceneFeature_BarScreenshot : CutsceneFeature
	{
		[SerializeField]
		private Image _image;

		protected override void OnRepaint()
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile && !(_manager.CurrentPage.Neighbourhood == null) && careerProfile.LevelProgress.TryGetValue(_manager.CurrentPage.Neighbourhood, out var value))
			{
				if ((bool)value.Screenshot)
				{
					_image.overrideSprite = value.Screenshot;
				}
				else
				{
					_image.overrideSprite = _manager.CurrentPage.Neighbourhood.MapIcon;
				}
			}
		}
	}
}
