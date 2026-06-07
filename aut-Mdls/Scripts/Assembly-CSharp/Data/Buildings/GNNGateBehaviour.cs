using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Data.Variables;
using Events.UI.Overlays;
using Logic.Threading.Events;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.UI.Overlays.Notifications;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/GNNGateBehaviour", fileName = "GNNGateBehaviour", order = 0)]
	public class GNNGateBehaviour : BuildingBehaviour
	{
		[Serializable]
		public struct UpgradeOverwrite
		{
			public int Phase;

			public int FloorAmount;

			public DioramaEditorSave DioramaSave;

			public List<BuildingObjectData.BuildingResourceData> AdditionalInputs;

			public BuildingCompletionEffect PolishedPrefab;
		}

		[SerializeField]
		private List<MainThreadBoolVariableSO> _monumentIsChargedBoolSOs = new List<MainThreadBoolVariableSO>();

		[SerializeField]
		private List<UpgradeOverwrite> _upgradeOverwrites = new List<UpgradeOverwrite>();

		[SerializeField]
		private IntVariableSO _gnnGateCurrentPhaseSO;

		[SerializeField]
		private IntVariableSO _gnnGateCurrentFloorSO;

		[SerializeField]
		private IntVariableSO _gnnGateCurrentMaxFloorSO;

		[SerializeField]
		private IntVariableSO _gnnGateCurrentPhaseFloorSO;

		[SerializeField]
		private ShowIngameNotificationEvent _showIngameNotificationEvent;

		private List<UpgradeOverwrite> _unpackedUpgradeOverwrites;

		public MainThreadEvent OnGNNGateCompleted = new MainThreadEvent();

		public override void Init(FactoryObject factoryObject)
		{
			UnpackUpgradeOverwrites();
			base.Init(factoryObject);
			GNNGateBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<GNNGateBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto.BuildingBehaviourSaveStateDto);
			}
			foreach (MainThreadBoolVariableSO monumentIsChargedBoolSO in _monumentIsChargedBoolSOs)
			{
				monumentIsChargedBoolSO.ValueChanged.RegisterInline(OnMonumentChargedBoolChanged);
			}
		}

		public override void UnInit()
		{
			foreach (MainThreadBoolVariableSO monumentIsChargedBoolSO in _monumentIsChargedBoolSOs)
			{
				monumentIsChargedBoolSO.ValueChanged.UnRegisterInline(OnMonumentChargedBoolChanged);
			}
			base.UnInit();
		}

		private void UnpackUpgradeOverwrites()
		{
			_unpackedUpgradeOverwrites = new List<UpgradeOverwrite>();
			foreach (UpgradeOverwrite upgradeOverwrite in _upgradeOverwrites)
			{
				for (int i = 0; i < upgradeOverwrite.FloorAmount; i++)
				{
					_unpackedUpgradeOverwrites.Add(new UpgradeOverwrite
					{
						Phase = upgradeOverwrite.Phase,
						FloorAmount = 1,
						DioramaSave = upgradeOverwrite.DioramaSave,
						AdditionalInputs = upgradeOverwrite.AdditionalInputs,
						PolishedPrefab = upgradeOverwrite.PolishedPrefab
					});
				}
			}
		}

		public bool TryGetCurrentUpgradeOverwrite(out UpgradeOverwrite upgradeOverwrite)
		{
			if (base.CurrentBuildingStage >= _unpackedUpgradeOverwrites.Count)
			{
				upgradeOverwrite = _unpackedUpgradeOverwrites[0];
				return false;
			}
			upgradeOverwrite = _unpackedUpgradeOverwrites[base.CurrentBuildingStage];
			return true;
		}

		public void GetCurrentPhaseAndFloor(out int phase, out int floor, out int maxFloor)
		{
			phase = 0;
			maxFloor = 0;
			floor = base.CurrentBuildingStage + (_isUpgrading ? 1 : 0);
			if (!TryGetCurrentUpgradeOverwrite(out var upgradeOverwrite))
			{
				List<UpgradeOverwrite> upgradeOverwrites = _upgradeOverwrites;
				phase = upgradeOverwrites[upgradeOverwrites.Count - 1].Phase;
				List<UpgradeOverwrite> upgradeOverwrites2 = _upgradeOverwrites;
				floor = upgradeOverwrites2[upgradeOverwrites2.Count - 1].FloorAmount;
				List<UpgradeOverwrite> upgradeOverwrites3 = _upgradeOverwrites;
				maxFloor = upgradeOverwrites3[upgradeOverwrites3.Count - 1].FloorAmount;
				return;
			}
			for (int i = 0; i < _upgradeOverwrites.Count; i++)
			{
				if (_upgradeOverwrites[i].Phase == upgradeOverwrite.Phase)
				{
					maxFloor = _upgradeOverwrites[i].FloorAmount;
					break;
				}
				floor -= _upgradeOverwrites[i].FloorAmount;
			}
			phase = upgradeOverwrite.Phase;
		}

		private void OnMonumentChargedBoolChanged(bool _)
		{
			if (AllMonumentsAreCharged())
			{
				CallCanReceiveNewResources();
			}
		}

		private bool AllMonumentsAreCharged()
		{
			foreach (MainThreadBoolVariableSO monumentIsChargedBoolSO in _monumentIsChargedBoolSOs)
			{
				if (!monumentIsChargedBoolSO.Value)
				{
					return false;
				}
			}
			return true;
		}

		public override bool RequiresAdditionalResourceInputs()
		{
			if (base.CurrentBuildingStage >= _unpackedUpgradeOverwrites.Count)
			{
				return base.RequiresAdditionalResourceInputs();
			}
			return _unpackedUpgradeOverwrites[base.CurrentBuildingStage].AdditionalInputs.Count > 0;
		}

		protected override IReadOnlyDictionary<ShapeHashPair, DioramaEditorSave.DioramaShapeCollection> GetCurrentShapesDictionary()
		{
			if (base.CurrentBuildingStage >= _unpackedUpgradeOverwrites.Count)
			{
				return base.GetCurrentShapesDictionary();
			}
			return _unpackedUpgradeOverwrites[base.CurrentBuildingStage].DioramaSave.DioramaShapesDictionary;
		}

		protected override List<BuildingObjectData.BuildingResourceData> GetAdditionalInputs()
		{
			if (base.CurrentBuildingStage >= _unpackedUpgradeOverwrites.Count)
			{
				return base.GetAdditionalInputs();
			}
			return _unpackedUpgradeOverwrites[base.CurrentBuildingStage].AdditionalInputs;
		}

		protected override bool BuildingCompletedCanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return false;
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!AllMonumentsAreCharged() || (!_isUpgrading && !_buildingCompleted))
			{
				return false;
			}
			return base.CanReceiveResource(resource, inputData, position);
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new GNNGateBehaviourSaveStateDto
			{
				BuildingBehaviourSaveStateDto = (base.GetSaveState() as BuildingBehaviourSaveStateDto)
			};
		}

		public override void StartUpgrading()
		{
			base.StartUpgrading();
			CallCanReceiveNewResources();
		}

		protected override void Upgrade(bool newUpgrade = false)
		{
			if (newUpgrade)
			{
				_showIngameNotificationEvent.Fire(new InGameNotificationDto(InGameNotificationType.GnnGateProgress));
			}
			base.Upgrade(newUpgrade);
			GetCurrentPhaseAndFloor(out var phase, out var floor, out var _);
			_gnnGateCurrentPhaseSO.SetValue(phase);
			_gnnGateCurrentFloorSO.SetValue(base.CurrentBuildingStage);
			_gnnGateCurrentMaxFloorSO.SetValue(_unpackedUpgradeOverwrites.Count);
			_gnnGateCurrentPhaseFloorSO.SetValue(floor);
		}

		protected override void HandleBuildingCompleted()
		{
			base.HandleBuildingCompleted();
			OnGNNGateCompleted.Fire();
		}
	}
}
