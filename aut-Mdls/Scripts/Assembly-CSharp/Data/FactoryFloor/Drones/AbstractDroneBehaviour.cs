using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.Variables.Drones;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Drones
{
	public abstract class AbstractDroneBehaviour : ScriptableObject
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		protected DroneMaxVelocityData _droneMaxVelocityData;

		[SerializeField]
		protected float _acceleration = 0.1f;

		[SerializeField]
		protected float _deceleration = 0.01f;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		protected Vector3 _startPos;

		protected Vector3 _endPos;

		protected Dictionary<ResourceDataSO, int> _resources = new Dictionary<ResourceDataSO, int>();

		protected Vector3 _position;

		protected int _currentTime;

		protected DronePath _path;

		private IslandObject _islandObject;

		protected float _currentSpeed01;

		protected float _totalTime;

		protected float _timeToMaxSpeed;

		private float _constantSpeedDistance;

		private float _constantSpeedTime;

		private float _distanceToMaxSpeed;

		private float _pathLength;

		private float _peakVelocity;

		protected Vector3 _currentVelocity;

		public MainThreadEvent OnDestroyDrone = new MainThreadEvent();

		public Vector3 StartPos => _startPos;

		public Vector3 EndPos => _endPos;

		public Vector3 Position => _position;

		public DronePath PAth => _path;

		public IslandObject IslandObject => _islandObject;

		public float CurrentSpeed01 => _currentSpeed01;

		public Vector3 CurrentVelocity => _currentVelocity;

		public int StepsUntilEnd => Mathf.RoundToInt(_totalTime) - _currentTime;

		public DroneMaxVelocityData DroneMaxVelocityData => _droneMaxVelocityData;

		protected virtual void Init(Vector3 startPos, Vector3 endPos, Vector3 islandWorldPos)
		{
			_startPos = startPos;
			_endPos = endPos;
			_position = startPos;
			_islandLayer.TryGetIslandAtWorldPosition(new Vector3Int(Mathf.RoundToInt(islandWorldPos.x), 0, Mathf.RoundToInt(islandWorldPos.z)), out _islandObject);
			_droneMaxVelocityData.ValueChanged -= OnMaxVelocityChanged;
			_droneMaxVelocityData.ValueChanged += OnMaxVelocityChanged;
			CalculateDistancesAndSpeeds();
		}

		private void CalculateDistancesAndSpeeds()
		{
			_pathLength = Vector3.Distance(_startPos, _endPos);
			_timeToMaxSpeed = _droneMaxVelocityData.Value / _acceleration;
			float num = _droneMaxVelocityData.Value / _deceleration;
			_distanceToMaxSpeed = 0.5f * _acceleration * _timeToMaxSpeed * _timeToMaxSpeed;
			float num2 = 0.5f * _deceleration * num * num;
			_totalTime = 0f;
			if (_pathLength < _distanceToMaxSpeed + num2)
			{
				float num3 = Mathf.Sqrt(2f * _pathLength * _deceleration / (_acceleration * (_acceleration + _deceleration)));
				_peakVelocity = _acceleration * num3;
				float num4 = _peakVelocity / _deceleration;
				_timeToMaxSpeed = num3;
				_totalTime = num3 + num4;
				_constantSpeedTime = 0f;
				_distanceToMaxSpeed = 0.5f * _acceleration * num3 * num3;
				_constantSpeedDistance = 0f;
			}
			else
			{
				float num5 = _pathLength - _distanceToMaxSpeed - num2;
				_constantSpeedTime = num5 / _droneMaxVelocityData.Value;
				_totalTime = num + _timeToMaxSpeed + _constantSpeedTime;
				_constantSpeedDistance = num5;
				_peakVelocity = _droneMaxVelocityData.Value;
			}
		}

		protected void UpdatePathEndWithoutSpeedChanged(Vector3 endPosition)
		{
			float percentageOnPathAtTime = GetPercentageOnPathAtTime(_currentTime);
			Vector3 vector = Vector3.Lerp(_path.StartPos, _path.TargetPos, percentageOnPathAtTime);
			Vector3 vector2 = endPosition - vector;
			float num = vector2.magnitude * (1f / (1f - percentageOnPathAtTime));
			Vector3 vector3 = endPosition + num * -vector2.normalized;
			Vector3 vector4 = Vector3.Lerp(_path.StartPos, _path.TargetPos, 0.5f);
			Vector3 vector5 = Vector3.Lerp(endPosition, vector3, 0.5f);
			Vector3 cornerPos = _path.CornerPos - vector4 + vector5;
			_path = new DronePath(vector3, endPosition, cornerPos);
		}

		protected float CalculateTotalFlyTimeBetweenStartAndEnd(Vector3 startPos, Vector3 endPos)
		{
			float num = Vector3.Distance(startPos, endPos);
			float num2 = _droneMaxVelocityData.Value / _acceleration;
			float num3 = _droneMaxVelocityData.Value / _deceleration;
			float num4 = 0.5f * _acceleration * num2 * num2;
			float num5 = 0.5f * _deceleration * num3 * num3;
			if (num < num4 + num5)
			{
				float num6 = Mathf.Sqrt(2f * num * _deceleration / (_acceleration * (_acceleration + _deceleration)));
				float num7 = _acceleration * num6 / _deceleration;
				return num6 + num7;
			}
			float num8 = (num - num4 - num5) / _droneMaxVelocityData.Value;
			return num3 + num2 + num8;
		}

		protected virtual void OnMaxVelocityChanged(float _)
		{
			CalculateDistancesAndSpeeds();
		}

		protected void UpdatePath(Vector3 startPos, Vector3 endPos)
		{
			_path = new DronePath(startPos, endPos);
			_currentTime = 0;
		}

		public abstract void Update();

		public virtual void DestroyDrone()
		{
			OnDestroyDrone.Fire();
			_droneMaxVelocityData.ValueChanged -= OnMaxVelocityChanged;
		}

		protected virtual bool MoveDroneOnPath()
		{
			Vector3 position = _position;
			float percentageOnPathAtTime = GetPercentageOnPathAtTime(_currentTime);
			_position = _path.GetPositionAtPercentage(percentageOnPathAtTime);
			_currentTime++;
			bool flag = (float)_currentTime >= _totalTime;
			_currentVelocity = position - _position;
			_currentSpeed01 = (flag ? 0f : (_currentVelocity.magnitude / _droneMaxVelocityData.Value));
			return flag;
		}

		public virtual Vector3 GetNextProcessPosition()
		{
			float percentageOnPathAtTime = GetPercentageOnPathAtTime(_currentTime);
			return _path.GetPositionAtPercentage(percentageOnPathAtTime);
		}

		protected float GetPercentageOnPathAtTime(float time)
		{
			float num;
			if (time < _timeToMaxSpeed)
			{
				num = 0.5f * _acceleration * time * time;
			}
			else if (time > _timeToMaxSpeed + _constantSpeedTime && time <= _totalTime)
			{
				float num2 = Mathf.Min(time, _totalTime) - (_timeToMaxSpeed + _constantSpeedTime);
				num = _distanceToMaxSpeed + _constantSpeedDistance + _peakVelocity * num2 - 0.5f * _deceleration * num2 * num2;
			}
			else
			{
				num = _distanceToMaxSpeed + _peakVelocity * (time - _timeToMaxSpeed);
			}
			return num / Mathf.Max(_pathLength, Mathf.Epsilon);
		}

		public BaseDroneSaveStateDto GetBaseDroneSaveState()
		{
			return new BaseDroneSaveStateDto(_currentTime, _resources);
		}

		public void ApplyBaseDroneSaveState(BaseDroneSaveStateDto baseDroneSaveStateDto)
		{
			_currentTime = baseDroneSaveStateDto.CurrentTime;
			_resources = baseDroneSaveStateDto.GetResources(_resourceDatabase);
			float percentageOnPathAtTime = GetPercentageOnPathAtTime(_currentTime);
			_position = _path.GetPositionAtPercentage(percentageOnPathAtTime);
		}
	}
}
