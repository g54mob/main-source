using System;
using System.Collections.Generic;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners
{
	[Serializable]
	public class TrainLocomotiveSpawnData
	{
		[SerializeField]
		private List<TrainLocomotiveType> _types;

		public IReadOnlyList<TrainLocomotiveType> Types => _types;

		public static TrainLocomotiveSpawnData Read(PooledReader reader)
		{
			TrainLocomotiveSpawnData trainLocomotiveSpawnData = new TrainLocomotiveSpawnData();
			int num = reader.ReadUInt8Unpacked();
			trainLocomotiveSpawnData._types = new List<TrainLocomotiveType>(num);
			for (int i = 0; i < num; i++)
			{
				trainLocomotiveSpawnData._types.Add((TrainLocomotiveType)reader.ReadUInt8Unpacked());
			}
			return trainLocomotiveSpawnData;
		}

		public void Write(PooledWriter writer)
		{
			writer.WriteUInt8Unpacked((byte)_types.Count);
			foreach (TrainLocomotiveType type in _types)
			{
				writer.WriteUInt8Unpacked((byte)type);
			}
		}
	}
}
