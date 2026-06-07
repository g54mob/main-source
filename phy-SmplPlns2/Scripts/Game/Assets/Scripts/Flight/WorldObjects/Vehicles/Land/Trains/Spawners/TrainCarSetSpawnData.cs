using System;
using System.Collections.Generic;
using FishNet.Serializing;
using Jundroo.Common.DataTypes;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners
{
	[Serializable]
	public class TrainCarSetSpawnData
	{
		[SerializeField]
		private MinMaxValue<byte> _numberOfCars;

		[SerializeField]
		private List<TrainCarType> _types;

		public MinMaxValue<byte> NumberOfCars => _numberOfCars;

		public IReadOnlyList<TrainCarType> Types => _types;

		public static TrainCarSetSpawnData Read(PooledReader reader)
		{
			TrainCarSetSpawnData trainCarSetSpawnData = new TrainCarSetSpawnData();
			trainCarSetSpawnData._numberOfCars.MinValue = reader.ReadUInt8Unpacked();
			trainCarSetSpawnData._numberOfCars.MaxValue = reader.ReadUInt8Unpacked();
			int num = reader.ReadUInt8Unpacked();
			trainCarSetSpawnData._types = new List<TrainCarType>(num);
			for (int i = 0; i < num; i++)
			{
				trainCarSetSpawnData._types.Add((TrainCarType)reader.ReadUInt8Unpacked());
			}
			return trainCarSetSpawnData;
		}

		public void Write(PooledWriter writer)
		{
			writer.WriteUInt8Unpacked(_numberOfCars.MinValue);
			writer.WriteUInt8Unpacked(_numberOfCars.MaxValue);
			writer.WriteUInt8Unpacked((byte)_types.Count);
			foreach (TrainCarType type in _types)
			{
				writer.WriteUInt8Unpacked((byte)type);
			}
		}
	}
}
