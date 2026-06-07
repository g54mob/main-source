using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class PopupInformation : MonoBehaviour, IGive<MapInfoSO>
	{
		private MapInfoSO _mapInfo;

		[SerializeField]
		private TextMeshProUGUI _name;

		[SerializeField]
		private TextMeshProUGUI _description;

		[SerializeField]
		private Image _icon;

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		}

		private void OnLocaleChanged(Locale obj)
		{
			ChangeInformation(_mapInfo);
		}

		public void ChangeInformation(MapInfoSO mapInfo)
		{
			_mapInfo = mapInfo;
			if (_mapInfo != null)
			{
				_name.text = _mapInfo.LevelNameLocalizationString.GetLocalizedString();
				_description.text = _mapInfo.LevelDescriptionLocalizationString.GetLocalizedString();
				if (!_icon)
				{
					return;
				}
				if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile { LevelProgress: var levelProgress })
				{
					if (levelProgress.TryGetValue(_mapInfo, out var value) && value.Screenshot != null)
					{
						_icon.sprite = value.Screenshot;
					}
					else
					{
						_icon.sprite = mapInfo.MapIcon;
					}
				}
				else
				{
					_icon.sprite = mapInfo.MapIcon;
				}
			}
			else
			{
				_name.text = "";
				_description.text = "";
			}
		}

		MapInfoSO IGive<MapInfoSO>.Get()
		{
			return _mapInfo;
		}
	}
}
