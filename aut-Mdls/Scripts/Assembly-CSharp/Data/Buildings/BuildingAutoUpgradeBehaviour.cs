#define ENABLE_DEBUG_EXCEPTIONS
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.SaveData.PersistentSOs;
using Events;
using SaveData.FactoryFloor;
using UnityEngine;
using Utils;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/BuildingAutoUpgradeBehaviour", fileName = "BuildingAutoUpgradeBehaviour", order = 0)]
	public class BuildingAutoUpgradeBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private CurrencyPersistentSO _currencyPersistentSO;

		[SerializeField]
		private BaseEvent _currencyGainedEvent;

		private BuildingBehaviour _buildingBehaviour;

		private bool _autoUpgrade;

		public bool AutoUpgrade => _autoUpgrade;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			if (!factoryObject.TryGetFactoryObjectBehaviour<BuildingBehaviour>(out _buildingBehaviour))
			{
				this.DevException("Could not find " + _buildingBehaviour.GetType().Name + ".", "Init", 28);
				return;
			}
			BuildingAutoUpgradeBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<BuildingAutoUpgradeBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			_currencyGainedEvent.Register(HandleAutoUpgrading);
			_buildingBehaviour.OnStageCompleted.RegisterInline(OnBuildingStateCompleted);
		}

		public override void UnInit()
		{
			_currencyGainedEvent.UnRegister(HandleAutoUpgrading);
			if (_buildingBehaviour != null)
			{
				_buildingBehaviour.OnStageCompleted.UnRegisterInline(OnBuildingStateCompleted);
			}
			base.UnInit();
		}

		public override void Update()
		{
		}

		public void SetAutoUpgrade(bool autoUpgrade)
		{
			_autoUpgrade = autoUpgrade;
			HandleAutoUpgrading();
		}

		private void OnBuildingStateCompleted(int stage)
		{
			if (_autoUpgrade && !_buildingBehaviour.BuildingCompleted && !_buildingBehaviour.MaxLockedBuildingStageReached)
			{
				ResourceCost upgradeCost = _buildingBehaviour.BuildingObjectData.Upgrades[_buildingBehaviour.CurrentBuildingStage - 1].UpgradeCost;
				if (_currencyPersistentSO.TryBuy(upgradeCost))
				{
					HandleAutoUpgrading();
				}
			}
		}

		private void HandleAutoUpgrading()
		{
			if (_buildingBehaviour.IsUpgrading || !AutoUpgrade || _buildingBehaviour.MaxLockedBuildingStageReached)
			{
				return;
			}
			if (_buildingBehaviour.CurrentBuildingStage > 0)
			{
				if (_buildingBehaviour.CurrentBuildingStage > _buildingBehaviour.BuildingObjectData.Upgrades.Count)
				{
					_autoUpgrade = false;
					return;
				}
				ResourceCost upgradeCost = _buildingBehaviour.BuildingObjectData.Upgrades[_buildingBehaviour.CurrentBuildingStage - 1].UpgradeCost;
				if (!_currencyPersistentSO.TryBuy(upgradeCost))
				{
					return;
				}
			}
			_buildingBehaviour.StartUpgrading();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new BuildingAutoUpgradeBehaviourConfigurationDto(_autoUpgrade);
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (configDto is BuildingAutoUpgradeBehaviourConfigurationDto buildingAutoUpgradeBehaviourConfigurationDto)
			{
				SetAutoUpgrade(buildingAutoUpgradeBehaviourConfigurationDto.AutoUpgrade);
				HandleAutoUpgrading();
			}
		}
	}
}
