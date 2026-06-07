using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorHoverUIs
{
	public class OverclockInfoView : MonoBehaviour
	{
		[SerializeField]
		private Transform _overclockContainer;

		[SerializeField]
		private TextMeshProUGUI _overclockText;

		[SerializeField]
		private Image _overclockProgressBar;

		[SerializeField]
		[LocaKey]
		private string _overclockTextLocaKey;

		[SerializeField]
		[LocaKey]
		private string _inactiveTextLocaKey;

		[SerializeField]
		private GameObject _overclockIcon;

		[SerializeField]
		private GameObject _upArrowsIcon;

		[SerializeField]
		private Color _activeColor;

		[SerializeField]
		private Color _inactiveColor;

		[SerializeField]
		private List<Image> _imagesToRecolor;

		[SerializeField]
		private List<Image> _imagesToDisableOnInActive;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _inactiveAlpha = 0.5f;

		private bool _isActive;

		private int _overclockPercentage;

		private OverclockStationBehaviour _overclockStationBehaviour;

		private string _isActiveTextLocalized;

		private string _isInActiveTextLocalized;

		private void OnEnable()
		{
			LocalizationUtility.OnLanguageUpdate += UpdateText;
			UpdateText();
		}

		private void OnDisable()
		{
			LocalizationUtility.OnLanguageUpdate -= UpdateText;
		}

		private void UpdateText()
		{
			_isActiveTextLocalized = string.Format(LocalizationUtility.GetLocalizedText(_overclockTextLocaKey), _overclockPercentage);
			_isInActiveTextLocalized = LocalizationUtility.GetLocalizedText(_inactiveTextLocaKey);
		}

		public void UpdateOverclockInfo(BuildingBehaviour buildingBehaviour)
		{
			_overclockIcon.gameObject.SetActive(buildingBehaviour.IsOverClocked);
			_upArrowsIcon.gameObject.SetActive(buildingBehaviour.IsOverClocked);
			if (buildingBehaviour.FactoryObject.TryGetFactoryObjectBehaviour<OverclockStationBehaviour>(out var behaviour) && buildingBehaviour.CurrentBuildingStage > 0)
			{
				_overclockStationBehaviour = behaviour;
				_overclockContainer.gameObject.SetActive(value: true);
				_isActive = true;
				_overclockProgressBar.fillAmount = 0f;
				_overclockPercentage = Mathf.RoundToInt((behaviour.GetOverclockMultiplier() - 1f) * 100f);
				UpdateText();
				_overclockText.SetText(_overclockStationBehaviour.IsOverclockActive ? _isActiveTextLocalized : _isInActiveTextLocalized);
			}
			else
			{
				CloseOverclockInfo();
			}
		}

		private void Update()
		{
			if (_isActive)
			{
				_overclockProgressBar.fillAmount = _overclockStationBehaviour.OverclockTimePercentage;
				string text = (_overclockStationBehaviour.IsOverclockActive ? _isActiveTextLocalized : _isInActiveTextLocalized);
				_overclockText.SetText(text);
				_canvasGroup.alpha = (_overclockStationBehaviour.IsOverclockActive ? 1f : _inactiveAlpha);
				RecolorImages();
			}
		}

		public void CloseOverclockInfo()
		{
			_overclockContainer.gameObject.SetActive(value: false);
			_isActive = false;
		}

		private void RecolorImages()
		{
			foreach (Image item in _imagesToRecolor)
			{
				float a = item.color.a;
				Color color = (_overclockStationBehaviour.IsOverclockActive ? new Color(_activeColor.r, _activeColor.g, _activeColor.b, a) : new Color(_inactiveColor.r, _inactiveColor.g, _inactiveColor.b, a));
				item.color = color;
			}
			foreach (Image item2 in _imagesToDisableOnInActive)
			{
				item2.enabled = _overclockStationBehaviour.IsOverclockActive;
			}
		}
	}
}
