using System;
using System.Collections.Generic;
using FishNet.Serializing;
using Jundroo.Common.DataTypes;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners
{
	[Serializable]
	public class TrainSpawnData
	{
		[SerializeField]
		private string _id;

		[SerializeField]
		private MinMaxValue<byte> _velocityRange;

		[SerializeField]
		private TrainLocomotiveSpawnData _locomotive;

		[SerializeField]
		private List<TrainCarSetSpawnData> _trainCars;

		[SerializeField]
		[Tooltip("The higher this value, the less likely the train is to derail for being too far away from its expected orientation (on the X-axis).")]
		private float _derailmentOrientationAngleXThreshold = 2f;

		[SerializeField]
		[Tooltip("The higher this value, the less likely the train is to derail for being too far away from its expected orientation (on the Y-axis).")]
		private float _derailmentOrientationAngleYThreshold = 5f;

		[SerializeField]
		[Tooltip("The higher this value, the less likely the train is to derail for being too far away from its expected position.")]
		private float _derailmentPositionThreshold = 0.25f;

		public float DerailmentOrientationAngleXThreshold
		{
			get
			{
				return _derailmentOrientationAngleXThreshold;
			}
			set
			{
				_derailmentOrientationAngleXThreshold = value;
			}
		}

		public float DerailmentOrientationAngleYThreshold
		{
			get
			{
				return _derailmentOrientationAngleYThreshold;
			}
			set
			{
				_derailmentOrientationAngleYThreshold = value;
			}
		}

		public float DerailmentPositionThreshold
		{
			get
			{
				return _derailmentPositionThreshold;
			}
			set
			{
				_derailmentPositionThreshold = value;
			}
		}

		public string Id => _id;

		public TrainLocomotiveSpawnData Locomotive => _locomotive;

		public IReadOnlyList<TrainCarSetSpawnData> TrainCars => _trainCars;

		public MinMaxValue<byte> VelocityRange => _velocityRange;

		public static TrainSpawnData Read(PooledReader reader)
		{
			TrainSpawnData trainSpawnData = new TrainSpawnData();
			trainSpawnData._id = reader.ReadStringAllocated();
			trainSpawnData._velocityRange.MinValue = reader.ReadUInt8Unpacked();
			trainSpawnData._velocityRange.MaxValue = reader.ReadUInt8Unpacked();
			trainSpawnData._locomotive = TrainLocomotiveSpawnData.Read(reader);
			int num = reader.ReadUInt8Unpacked();
			trainSpawnData._trainCars = new List<TrainCarSetSpawnData>(num);
			for (int i = 0; i < num; i++)
			{
				trainSpawnData._trainCars.Add(TrainCarSetSpawnData.Read(reader));
			}
			trainSpawnData._derailmentOrientationAngleXThreshold = reader.ReadSingle();
			trainSpawnData._derailmentOrientationAngleYThreshold = reader.ReadSingle();
			trainSpawnData._derailmentPositionThreshold = reader.ReadSingle();
			return trainSpawnData;
		}

		public TrainDefinition BuildTrain()
		{
			TrainDefinition trainDefinition = new TrainDefinition();
			trainDefinition.TargetSpeed = UnityEngine.Random.Range(VelocityRange.MinValue, VelocityRange.MaxValue + 1);
			trainDefinition.Locomotive = _locomotive.Types[UnityEngine.Random.Range(0, _locomotive.Types.Count)];
			for (int i = 0; i < TrainCars.Count; i++)
			{
				TrainCarSetSpawnData trainCarSetSpawnData = TrainCars[i];
				int num = UnityEngine.Random.Range(trainCarSetSpawnData.NumberOfCars.MinValue, trainCarSetSpawnData.NumberOfCars.MaxValue + 1);
				for (int j = 0; j < num; j++)
				{
					TrainCarType item = trainCarSetSpawnData.Types[UnityEngine.Random.Range(0, trainCarSetSpawnData.Types.Count)];
					trainDefinition.TrainCars.Add(item);
				}
			}
			trainDefinition.DerailmentOrientationAngleXThreshold = DerailmentOrientationAngleXThreshold;
			trainDefinition.DerailmentOrientationAngleYThreshold = DerailmentOrientationAngleYThreshold;
			trainDefinition.DerailmentPositionThreshold = DerailmentPositionThreshold;
			return trainDefinition;
		}

		public void Write(PooledWriter writer)
		{
			writer.WriteString(_id);
			writer.WriteUInt8Unpacked(_velocityRange.MinValue);
			writer.WriteUInt8Unpacked(_velocityRange.MaxValue);
			_locomotive.Write(writer);
			writer.WriteUInt8Unpacked((byte)_trainCars.Count);
			foreach (TrainCarSetSpawnData trainCar in _trainCars)
			{
				trainCar.Write(writer);
			}
			writer.WriteSingle(_derailmentOrientationAngleXThreshold);
			writer.WriteSingle(_derailmentOrientationAngleYThreshold);
			writer.WriteSingle(_derailmentPositionThreshold);
		}
	}
}
