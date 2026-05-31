using System;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_SandboxFeature_ProfileData : UI_SandboxFeature
	{
		[SerializeField]
		private Image _imageContainer;

		[SerializeField]
		private TMP_Text _titleContainer;

		[SerializeField]
		private TMP_Text _saveTimeContainer;

		[SerializeField]
		private TMP_Text _playTimeContainer;

		[SerializeField]
		private TMP_Text _moneyText;

		protected override void OnRepaint()
		{
			if (_profile.CurrentProfile == null)
			{
				return;
			}
			FreemodeProfile profile = _profile.CurrentProfile.Profile;
			if (profile != null)
			{
				if ((bool)profile.Screenshot)
				{
					_imageContainer.overrideSprite = profile.Screenshot;
				}
				else
				{
					_imageContainer.overrideSprite = profile.MapInfo.MapIcon;
				}
				_titleContainer.text = profile.MapInfo.LevelNameLocalizationString.GetLocalizedStringSafe();
				_saveTimeContainer.text = profile.SaveTime.ToShortDateString();
				_playTimeContainer.text = new DateTime(TimeSpan.FromSeconds(profile.PlayTime).Ticks).ToString("HH'h'mm");
				_moneyText.text = $"${profile.Money}";
			}
		}
	}
}
