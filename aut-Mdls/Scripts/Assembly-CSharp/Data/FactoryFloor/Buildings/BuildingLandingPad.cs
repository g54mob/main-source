using System;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	public class BuildingLandingPad
	{
		public MainThreadEvent OnLandingPadDestroyed = new MainThreadEvent();

		public MainThreadEvent<Vector3Int> OnShowLandingPadPreview = new MainThreadEvent<Vector3Int>();

		public MainThreadEvent OnHideLandingPadPreview = new MainThreadEvent();

		private readonly FactoryObject _factoryObject;

		private readonly BuildingBehaviour _buildingBehaviour;

		private readonly OperatorStateBehaviour _operatorStateBehaviour;

		private bool _exists;

		private Vector3Int _position;

		private bool _isShowingPreview;

		private HarvesterPadBehaviour _harvesterPadBehaviour;

		private bool _hasHarvesterPadBehaviour;

		public bool Exists => _exists;

		public Vector3Int Position => _position;

		public bool HasHarvesterPadBehaviour => _hasHarvesterPadBehaviour;

		public HarvesterPadBehaviour HarvesterPadBehaviour => _harvesterPadBehaviour;

		public event Action<Vector3Int> OnLandingPadGenerated = delegate
		{
		};

		public BuildingLandingPad(FactoryObject factoryObject, BuildingBehaviour buildingBehaviour)
		{
			_factoryObject = factoryObject;
			_buildingBehaviour = buildingBehaviour;
			factoryObject.TryGetFactoryObjectBehaviour<OperatorStateBehaviour>(out _operatorStateBehaviour);
			_buildingBehaviour.OnStageCompleted.RegisterInline(UpdateBuildingErrorState);
			_buildingBehaviour.OnUpgradeStateChanged.RegisterInline(UpdateBuildingErrorState);
			_buildingBehaviour.OnCreatedResources.RegisterInline(UpdateBuildingErrorState);
			_buildingBehaviour.OnOutputResource.RegisterInline(UpdateBuildingErrorState);
			UpdateBuildingErrorState();
		}

		public void Dispose()
		{
			if (_buildingBehaviour != null)
			{
				_buildingBehaviour.OnStageCompleted.UnRegisterInline(UpdateBuildingErrorState);
				_buildingBehaviour.OnUpgradeStateChanged.UnRegisterInline(UpdateBuildingErrorState);
				_buildingBehaviour.OnCreatedResources.UnRegisterInline(UpdateBuildingErrorState);
				_buildingBehaviour.OnOutputResource.UnRegisterInline(UpdateBuildingErrorState);
			}
			DestroyLandingPad();
		}

		public Vector3Int GetLandingPadPosition(Vector3 harvestPadPos)
		{
			Vector3Int result = _factoryObject.Position;
			float num = float.MaxValue;
			foreach (Vector3Int occupiedPosition in _factoryObject.OccupiedPositions)
			{
				if (IsCornerPos(_factoryObject, occupiedPosition))
				{
					float num2 = Vector3.Distance(occupiedPosition, harvestPadPos);
					if (num2 < num)
					{
						result = occupiedPosition;
						num = num2;
					}
				}
			}
			return result;
		}

		public void GenerateLandingPad(FactoryObject harvesterPad)
		{
			if (!_exists)
			{
				_hasHarvesterPadBehaviour = harvesterPad.TryGetFactoryObjectBehaviour<HarvesterPadBehaviour>(out _harvesterPadBehaviour);
				HideLandingPadPreview();
				_position = GetLandingPadPosition(harvesterPad.Position);
				this.OnLandingPadGenerated(_position);
				_exists = true;
				UpdateBuildingErrorState();
			}
		}

		private bool IsCornerPos(FactoryObject factoryObject, Vector3Int occupiedPos)
		{
			return 0 + (factoryObject.OccupiedPositions.Contains(occupiedPos + new Vector3Int(-1, 0, 0)) ? 1 : 0) + (factoryObject.OccupiedPositions.Contains(occupiedPos + new Vector3Int(1, 0, 0)) ? 1 : 0) + (factoryObject.OccupiedPositions.Contains(occupiedPos + new Vector3Int(0, 0, 1)) ? 1 : 0) + (factoryObject.OccupiedPositions.Contains(occupiedPos + new Vector3Int(0, 0, -1)) ? 1 : 0) <= 2;
		}

		public void DestroyLandingPad()
		{
			if (_exists)
			{
				_exists = false;
				_hasHarvesterPadBehaviour = false;
				_harvesterPadBehaviour = null;
				OnLandingPadDestroyed.Fire();
				UpdateBuildingErrorState();
			}
		}

		private void UpdateBuildingErrorState(int _)
		{
			UpdateBuildingErrorState();
		}

		private void UpdateBuildingErrorState(bool _)
		{
			UpdateBuildingErrorState();
		}

		private void UpdateBuildingErrorState(BuildingBehaviour _)
		{
			UpdateBuildingErrorState();
		}

		private void UpdateBuildingErrorState(Resource _, int __)
		{
			UpdateBuildingErrorState();
		}

		private void UpdateBuildingErrorState()
		{
			if (!(_operatorStateBehaviour == null))
			{
				if (!_exists && _buildingBehaviour.CurrentBuildingStage > 0 && !_buildingBehaviour.IsUpgrading && _buildingBehaviour.NeedsDroneToTakeOutput)
				{
					_operatorStateBehaviour.SetStateNoDroneLinked();
				}
				else
				{
					_operatorStateBehaviour.ResetState();
				}
			}
		}

		public void ShowLandingPadPreview(Vector3 harvestPadPos)
		{
			if (_isShowingPreview)
			{
				HideLandingPadPreview();
			}
			_position = GetLandingPadPosition(harvestPadPos);
			_isShowingPreview = true;
			OnShowLandingPadPreview.Fire(_position);
		}

		public void HideLandingPadPreview()
		{
			_isShowingPreview = false;
			OnHideLandingPadPreview.Fire();
		}
	}
}
