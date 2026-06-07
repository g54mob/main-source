using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Events;
using Events.UI;
using Presentation.FactoryFloor.Toolbar;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class UpgradeInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private ShowUpgradeInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		private CurrencyPersistentSO _currentCurrency;

		[SerializeField]
		private GameObject _costPanel;

		[SerializeField]
		private TextMeshProUGUI _costText;

		[SerializeField]
		private TextMeshProUGUI _productionLevelCurrentText;

		[SerializeField]
		private TextMeshProUGUI _productionLevelNewText;

		[SerializeField]
		private TextMeshProUGUI _rewardDescriptionText;

		[SerializeField]
		private Image _rewardImage;

		[SerializeField]
		private GameObject _upgradeIcon;

		[SerializeField]
		private ResourceUI _dataShardUI;

		[SerializeField]
		private Color _affordableColor;

		[SerializeField]
		private Color _notAffordableColor;

		[SerializeField]
		private BuildingFamilyDatabase _buildingFamilyDatabase;

		[SerializeField]
		private GameObject _productionLevelParent;

		[SerializeField]
		private GameObject _rewardParent;

		private UpgradeInfoPanelDto _upgradeInfoPanelDto;

		private ResourceCost _currentCost;

		private Color _currentColor;

		protected override void Awake()
		{
			base.gameObject.SetActive(value: false);
			_showInfoPanelEvent.Register(base.Show);
			_hideInfoPanelEvent.Register(Hide);
		}

		protected override void OnDestroy()
		{
			_showInfoPanelEvent.UnRegister(base.Show);
			_hideInfoPanelEvent.UnRegister(Hide);
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			_upgradeInfoPanelDto = dto as UpgradeInfoPanelDto;
			SetCost(_upgradeInfoPanelDto.UpgradeCost);
			_productionLevelCurrentText.SetText(_upgradeInfoPanelDto.UpgradeLevelCurrent);
			_productionLevelNewText.SetText(_upgradeInfoPanelDto.UpgradeLevelNew);
			_rewardImage.sprite = _upgradeInfoPanelDto.RewardSprite;
			_rewardDescriptionText.SetText(_upgradeInfoPanelDto.RewardDescription);
			_upgradeIcon.SetActive(_upgradeInfoPanelDto.ShowLevelUpIcon);
			_productionLevelParent.SetActive(_upgradeInfoPanelDto.UpgradeLevelCurrent != _upgradeInfoPanelDto.UpgradeLevelNew);
			_rewardParent.SetActive(_upgradeInfoPanelDto.HasOutput);
		}

		private void Update()
		{
			UpdateAffordableStyle();
		}

		private void SetCost(ResourceCost cost)
		{
			_currentCost = cost;
			if (cost.IsFree())
			{
				_costPanel.SetActive(value: false);
				return;
			}
			_costPanel.SetActive(value: true);
			foreach (KeyValuePair<ResourceDataSO, int> allCost in cost.GetAllCosts())
			{
				if (allCost.Value > 0)
				{
					NonShapeResourceDataSO nonShapeResourceDataSO = allCost.Key as NonShapeResourceDataSO;
					int value = allCost.Value;
					_dataShardUI.SetResource(nonShapeResourceDataSO, $"x{value}");
					_dataShardUI.SetColor(_buildingFamilyDatabase.GetFamilyColorById(nonShapeResourceDataSO.FamilyID));
					UpdateAffordableStyle();
					break;
				}
			}
		}

		private void UpdateAffordableStyle()
		{
			Color color = (_currentCurrency.HasEnoughResources(_currentCost) ? _affordableColor : _notAffordableColor);
			if (color != _currentColor)
			{
				_dataShardUI.SetAmountColor(color);
			}
			_currentColor = color;
		}
	}
}
