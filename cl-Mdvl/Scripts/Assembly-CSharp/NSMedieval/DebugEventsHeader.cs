using System.IO;

namespace NSMedieval
{
	public struct DebugEventsHeader
	{
		public string GameVersion;

		public byte TickIntervalMinutes;

		public long StartTimeMinutes;

		public int MapSizeX;

		public int MapSizeY;

		public int MapSizeZ;

		public void WriteBytes(BinaryWriter fileWriter)
		{
			fileWriter.Write(GameVersion);
			fileWriter.Write(TickIntervalMinutes);
			fileWriter.Write(StartTimeMinutes);
			fileWriter.Write(MapSizeX);
			fileWriter.Write(MapSizeY);
			fileWriter.Write(MapSizeZ);
		}

		public static DebugEventsHeader ReadBytes(BinaryReader fileReader)
		{
			return new DebugEventsHeader
			{
				GameVersion = fileReader.ReadString(),
				TickIntervalMinutes = fileReader.ReadByte(),
				StartTimeMinutes = fileReader.ReadInt64(),
				MapSizeX = fileReader.ReadInt32(),
				MapSizeY = fileReader.ReadInt32(),
				MapSizeZ = fileReader.ReadInt32()
			};
		}
	}
}
