using System;
using System.IO;

namespace UltimateReplay.Storage
{
	public struct ReplayFileHeader
	{
		public const int replayIdentifier = 11586;

		public int headerSize;

		public int memorySize;

		public int dataOffset;

		public int chunkTableOffset;

		public int stateBufferOffset;

		public float duration;

		public string sceneName;

		public ReplayFileHeader(string sceneName)
		{
			headerSize = 0;
			memorySize = 0;
			dataOffset = 0;
			chunkTableOffset = 0;
			stateBufferOffset = 0;
			duration = 0f;
			this.sceneName = sceneName;
		}

		public void OnReplayDataSerialize(BinaryWriter writer)
		{
			writer.Write(11586);
			writer.Write(headerSize);
			writer.Write(memorySize);
			writer.Write(dataOffset);
			writer.Write(chunkTableOffset);
			writer.Write(stateBufferOffset);
			writer.Write(duration);
			writer.Write(sceneName);
		}

		public void OnReplayDataDeserialize(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			if (11586 != num)
			{
				throw new FormatException("The specified file target is not a valid UltimateReplay file");
			}
			headerSize = reader.ReadInt32();
			memorySize = reader.ReadInt32();
			dataOffset = reader.ReadInt32();
			chunkTableOffset = reader.ReadInt32();
			stateBufferOffset = reader.ReadInt32();
			duration = reader.ReadSingle();
			sceneName = reader.ReadString();
		}
	}
}
