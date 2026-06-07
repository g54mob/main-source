using System.Collections.Generic;
using FishNet.Serializing;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public class TrainDefinition
	{
		public float DerailmentOrientationAngleXThreshold { get; set; } = 2f;

		public float DerailmentOrientationAngleYThreshold { get; set; } = 5f;

		public float DerailmentPositionThreshold { get; set; } = 0.25f;

		public TrainLocomotiveType Locomotive { get; set; }

		public float TargetSpeed { get; set; }

		public double TrackPosition { get; set; }

		public List<TrainCarType> TrainCars { get; private set; }

		public TrainDefinition()
		{
			TrainCars = new List<TrainCarType>();
		}

		public static TrainDefinition NetworkDeserialize(PooledReader reader)
		{
			TrainDefinition trainDefinition = new TrainDefinition();
			trainDefinition.Locomotive = (TrainLocomotiveType)reader.ReadUInt8Unpacked();
			trainDefinition.TargetSpeed = reader.ReadSingle();
			trainDefinition.TrackPosition = reader.ReadDouble();
			trainDefinition.DerailmentPositionThreshold = reader.ReadSingle();
			trainDefinition.DerailmentOrientationAngleXThreshold = reader.ReadSingle();
			trainDefinition.DerailmentOrientationAngleYThreshold = reader.ReadSingle();
			byte b = reader.ReadUInt8Unpacked();
			for (int i = 0; i < b; i++)
			{
				trainDefinition.TrainCars.Add((TrainCarType)reader.ReadUInt8Unpacked());
			}
			return trainDefinition;
		}

		public void NetworkSerialize(PooledWriter writer)
		{
			writer.WriteUInt8Unpacked((byte)Locomotive);
			writer.WriteSingle(TargetSpeed);
			writer.WriteDouble(TrackPosition);
			writer.WriteSingle(DerailmentPositionThreshold);
			writer.WriteSingle(DerailmentOrientationAngleXThreshold);
			writer.WriteSingle(DerailmentOrientationAngleYThreshold);
			writer.WriteUInt8Unpacked((byte)TrainCars.Count);
			for (int i = 0; i < TrainCars.Count; i++)
			{
				writer.WriteUInt8Unpacked((byte)TrainCars[i]);
			}
		}
	}
}
