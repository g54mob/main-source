using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/HarvestPadDroneBehaviour", fileName = "HarvestPadDroneBehaviour", order = 0)]
	public class HarvestPadDroneBehaviour : AbstractDroneBehaviour
	{
		[Serializable]
		public enum HarvestPadDroneState
		{
			Hidden = 0,
			Spawning = 1,
			MovingToHarvesterPad = 2,
			WaitingToDropResources = 3,
			DroppingResources = 4
		}

		public int StepsToSpawn = 24;

		public int MinStepsToWaitToDrop = 6;

		public int StepsToDropToHarvestorPadPerHeight = 24;

		public int StepsOnHarvestorPad = 12;

		public int StepsToEnterHarvestorPad = 24;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private float _heightChangeSkipToDropDistance = 1f;

		[SerializeField]
		private float _heightClaimDistanceMin = 15f;

		[SerializeField]
		private float _heightClaimDistanceMax = 20f;

		[SerializeField]
		private int _speedupDropAtDroneCount = 6;

		private HarvesterPadBehaviour _harvesterPadBehaviour;

		private BuildingBehaviour _buildingBehaviour;

		private HarvestPadDroneState _state = HarvestPadDroneState.Spawning;

		private int _stepsElapsed;

		private int _heightIndex = -1;

		private int _previousHeightIndex = -1;

		private float _heightClaimDistance;

		public MainThreadEvent<HarvestPadDroneState> OnChangeState = new MainThreadEvent<HarvestPadDroneState>();

		public MainThreadEvent<int, int> OnHeightIndexChanged = new MainThreadEvent<int, int>();

		public int HeightIndex => _heightIndex;

		public BuildingBehaviour BuildingBehaviour => _buildingBehaviour;

		public HarvesterPadDroneHeights DroneHeights => _harvesterPadBehaviour.DroneHeights;

		public HarvestPadDroneState State => _state;

		public bool IsHidden => _state == HarvestPadDroneState.Hidden;

		public Dictionary<ResourceDataSO, int> Resources => _resources;

		public float EnterHarvesterPadTimeScalar()
		{
			if (_harvesterPadBehaviour.GetDroppingDroneCount() >= _speedupDropAtDroneCount)
			{
				return 0.5f;
			}
			return 1f;
		}

		public void Init(HarvesterPadBehaviour harvesterPadBehaviour, BuildingBehaviour buildingBehaviour, Vector3 pickUpPos, Vector3 dropOffPos, HarvesterPadDroneSaveStateDto saveState = null)
		{
			Init(pickUpPos, dropOffPos, dropOffPos);
			_harvesterPadBehaviour = harvesterPadBehaviour;
			_buildingBehaviour = buildingBehaviour;
			_heightIndex = -1;
			_heightClaimDistance = UnityEngine.Random.Range(_heightClaimDistanceMin, _heightClaimDistanceMax);
			if (saveState != null)
			{
				ApplySaveState(saveState);
			}
			else
			{
				SetDroneState(HarvestPadDroneState.Spawning);
			}
		}

		private void SetDroneState(HarvestPadDroneState state)
		{
			_state = state;
			_stepsElapsed = 0;
			OnChangeState.Fire(state);
		}

		public override void Update()
		{
			switch (_state)
			{
			case HarvestPadDroneState.Spawning:
				Spawning();
				break;
			case HarvestPadDroneState.MovingToHarvesterPad:
				MoveToHarvesterPad();
				break;
			case HarvestPadDroneState.WaitingToDropResources:
				WaitingToDropResources();
				break;
			case HarvestPadDroneState.DroppingResources:
				DropResources();
				break;
			}
			_stepsElapsed++;
		}

		private void Spawning()
		{
			if (_stepsElapsed < StepsToSpawn)
			{
				return;
			}
			foreach (var (key, value) in _buildingBehaviour.GetCurrentOutputs())
			{
				_resources.Add(key, value);
			}
			_buildingBehaviour.ClearBuildingResources();
			if ((_startPos - _endPos).sqrMagnitude < Mathf.Pow(_heightClaimDistanceMax, 2f))
			{
				_heightIndex = DroneHeights.ClaimNextAvailableDroneHeight(this);
			}
			Vector3 endPos = _endPos + Vector3.up * ((float)Mathf.Max(0, _heightIndex) * DroneHeights.HeightOffsetPerDrone);
			UpdatePath(_startPos, endPos);
			SetDroneState(HarvestPadDroneState.MovingToHarvesterPad);
		}

		private void MoveToHarvesterPad()
		{
			if (!MoveDroneOnPath())
			{
				if (_heightIndex == -1)
				{
					Vector3 vector = _position - _path.TargetPos;
					vector.y = 0f;
					if (vector.sqrMagnitude < Mathf.Pow(_heightClaimDistance, 2f))
					{
						_heightIndex = DroneHeights.ClaimNextAvailableDroneHeight(this);
						Vector3 endPosition = _endPos + Vector3.up * ((float)_heightIndex * DroneHeights.HeightOffsetPerDrone);
						UpdatePathEndWithoutSpeedChanged(endPosition);
					}
				}
			}
			else
			{
				SetDroneState(HarvestPadDroneState.WaitingToDropResources);
			}
		}

		private void WaitingToDropResources()
		{
			if (_stepsElapsed >= MinStepsToWaitToDrop && _heightIndex <= 0 && _harvesterPadBehaviour.CanReceiveResources())
			{
				SetDroneState(HarvestPadDroneState.DroppingResources);
			}
		}

		private void DropResources()
		{
			float num = EnterHarvesterPadTimeScalar();
			if (_heightIndex != -1)
			{
				if ((float)_stepsElapsed < (float)StepsOnHarvestorPad * num)
				{
					return;
				}
				DroneHeights.SetHeightAvailable(this);
				_heightIndex = -1;
			}
			if ((float)_stepsElapsed < (float)(StepsToEnterHarvestorPad + StepsOnHarvestorPad) * num)
			{
				return;
			}
			foreach (KeyValuePair<ResourceDataSO, int> resource2 in _resources)
			{
				for (int i = 0; i < resource2.Value; i++)
				{
					if (!_harvesterPadBehaviour.CanReceiveResources())
					{
						break;
					}
					Resource resource = _resourceFactory.CreateResource(resource2.Key);
					_harvesterPadBehaviour.AddResource(resource);
				}
			}
			_resources.Clear();
			DestroyDrone();
		}

		public override void DestroyDrone()
		{
			DroneHeights.SetHeightAvailable(this);
			_resources.Clear();
			SetDroneState(HarvestPadDroneState.Hidden);
			base.DestroyDrone();
		}

		public HarvesterPadDroneSaveStateDto GetSaveState()
		{
			return new HarvesterPadDroneSaveStateDto
			{
				DroneState = _state,
				StepsElapsed = _stepsElapsed,
				BaseDroneSaveStateDto = GetBaseDroneSaveState()
			};
		}

		public void ApplySaveState(HarvesterPadDroneSaveStateDto saveStateDto)
		{
			SetDroneState(saveStateDto.DroneState);
			_stepsElapsed = saveStateDto.StepsElapsed;
			if (_state == HarvestPadDroneState.WaitingToDropResources)
			{
				_heightIndex = DroneHeights.ClaimNextAvailableDroneHeight(this);
			}
			Vector3 vector = _endPos + Vector3.up * ((float)Mathf.Max(0, _heightIndex) * DroneHeights.HeightOffsetPerDrone);
			Vector3 startPos = _startPos;
			UpdatePath(vector, startPos);
			switch (_state)
			{
			case HarvestPadDroneState.Spawning:
				UpdatePath(startPos, startPos);
				break;
			case HarvestPadDroneState.MovingToHarvesterPad:
				UpdatePath(startPos, vector);
				break;
			case HarvestPadDroneState.WaitingToDropResources:
				UpdatePath(vector, vector);
				break;
			case HarvestPadDroneState.DroppingResources:
				UpdatePath(vector, vector);
				break;
			}
			ApplyBaseDroneSaveState(saveStateDto.BaseDroneSaveStateDto);
		}

		internal void UpdateHeightIndex(int heightIndex)
		{
			_previousHeightIndex = _heightIndex;
			_heightIndex = heightIndex;
			switch (_state)
			{
			case HarvestPadDroneState.MovingToHarvesterPad:
			{
				Vector3 vector = _position - _path.TargetPos;
				vector.y = 0f;
				if (vector.sqrMagnitude < Mathf.Pow(_heightChangeSkipToDropDistance, 2f))
				{
					SetDroneState(HarvestPadDroneState.WaitingToDropResources);
					_stepsElapsed = -Mathf.FloorToInt((float)StepsToDropToHarvestorPadPerHeight * EnterHarvesterPadTimeScalar());
				}
				else
				{
					Vector3 endPosition = _endPos + (float)Mathf.Max(0, _heightIndex) * DroneHeights.HeightOffsetPerDrone * Vector3.up;
					UpdatePathEndWithoutSpeedChanged(endPosition);
				}
				break;
			}
			case HarvestPadDroneState.WaitingToDropResources:
				_stepsElapsed = -Mathf.FloorToInt((float)StepsToDropToHarvestorPadPerHeight * EnterHarvesterPadTimeScalar());
				break;
			}
			OnHeightIndexChanged.Fire(_previousHeightIndex, heightIndex);
		}
	}
}
