using NSMedieval.Serialization;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("QueuedStabilityCalculationInfo", "")]
	public readonly struct QueuedStabilityCalculationInfo : IFVSerializable
	{
		public Vec3Int Position { get; }

		public bool SkipGround { get; }

		public QueuedStabilityCalculationInfo(Vec3Int position, bool skipGround)
		{
			Position = position;
			SkipGround = skipGround;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("Position", Position);
			serializer.Write("SkipGround", SkipGround);
		}

		public QueuedStabilityCalculationInfo(FVDeserializer deserializer)
		{
			Position = deserializer.ReadVec3Int("Position");
			SkipGround = deserializer.ReadBool("SkipGround");
		}
	}
}
