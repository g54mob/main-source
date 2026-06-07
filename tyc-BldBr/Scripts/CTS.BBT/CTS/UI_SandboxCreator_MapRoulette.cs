using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_SandboxCreator_MapRoulette : UI_ManagerFeature<UI_SandboxProfileCreator>, ILocaleRepaint
	{
		[SerializeField]
		private Image _mapImage;

		[SerializeField]
		private TMP_Text _mapName;

		[SerializeField]
		private List<MapInfoSO> _availableMaps = new List<MapInfoSO>();

		[SerializeField]
		private CTSButton _nextButton;

		[SerializeField]
		private CTSButton _previousButton;

		protected override void OnAwake()
		{
			base.OnAwake();
			_nextButton.onClick.AddListener(OnClickNextButton);
			_previousButton.onClick.AddListener(OnClickPreviousButton);
		}

		private MapInfoSO GetCurrentMap()
		{
			if (_parent.MapInfoSO == null)
			{
				_parent.MapInfoSO = _availableMaps[0];
			}
			return _parent.MapInfoSO;
		}

		private int GetCurrentMapIndex()
		{
			MapInfoSO currentMap = GetCurrentMap();
			return _availableMaps.IndexOf(currentMap);
		}

		private void OnClickNextButton()
		{
			int currentMapIndex;
			do
			{
				currentMapIndex = GetCurrentMapIndex();
				currentMapIndex = ((currentMapIndex < _availableMaps.Count - 1) ? (currentMapIndex + 1) : 0);
				_parent.MapInfoSO = _availableMaps[currentMapIndex];
			}
			while ((object)_availableMaps[currentMapIndex].FreeModeUnlock != null && !_availableMaps[currentMapIndex].FreeModeUnlock.GetValue());
			Repaint();
		}

		private void OnClickPreviousButton()
		{
			int currentMapIndex;
			do
			{
				currentMapIndex = GetCurrentMapIndex();
				currentMapIndex = ((currentMapIndex > 0) ? (currentMapIndex - 1) : (_availableMaps.Count - 1));
				_parent.MapInfoSO = _availableMaps[currentMapIndex];
			}
			while ((object)_availableMaps[currentMapIndex].FreeModeUnlock != null && !_availableMaps[currentMapIndex].FreeModeUnlock.GetValue());
			Repaint();
		}

		protected override void OnRepaint()
		{
			MapInfoSO currentMap = GetCurrentMap();
			_mapImage.overrideSprite = currentMap.MapIcon;
			RepaintLocale();
		}

		public void RepaintLocale()
		{
			_mapName.text = GetCurrentMap().LevelNameLocalizationString.GetLocalizedStringSafe();
		}
	}
}
