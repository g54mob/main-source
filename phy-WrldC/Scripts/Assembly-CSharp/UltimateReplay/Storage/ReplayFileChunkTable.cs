using System.Collections.Generic;
using System.IO;
using UltimateReplay.Core;

namespace UltimateReplay.Storage
{
	public class ReplayFileChunkTable : HashSet<ReplayFileChunkTableEntry>, IReplayDataSerialize
	{
		public void CreateEntry(int chunkID, float startTimeStamp, float endTimeStamp, int filePointer)
		{
			Add(new ReplayFileChunkTableEntry
			{
				chunkID = chunkID,
				startTimeStamp = startTimeStamp,
				endTimeStamp = endTimeStamp,
				filePointer = filePointer
			});
		}

		public int GetPointerForChunk(int chunkID)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ReplayFileChunkTableEntry current = enumerator.Current;
					if (chunkID == current.chunkID)
					{
						return current.filePointer;
					}
				}
			}
			return -1;
		}

		public int GetPointerForTimeStamp(float timeStamp)
		{
			if (timeStamp < 0f)
			{
				return -1;
			}
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ReplayFileChunkTableEntry current = enumerator.Current;
					if (timeStamp >= current.startTimeStamp && timeStamp <= current.endTimeStamp)
					{
						return current.filePointer;
					}
				}
			}
			int num = 0;
			int count = base.Count;
			bool flag = false;
			float num2 = float.MaxValue;
			ReplayFileChunkTableEntry replayFileChunkTableEntry = default(ReplayFileChunkTableEntry);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ReplayFileChunkTableEntry current2 = enumerator.Current;
					if (num == count - 1)
					{
						break;
					}
					if (timeStamp < current2.startTimeStamp)
					{
						float num3 = current2.startTimeStamp - timeStamp;
						if (num3 < num2)
						{
							flag = true;
							num2 = num3;
							replayFileChunkTableEntry = current2;
						}
					}
					else if (timeStamp > current2.endTimeStamp)
					{
						float num4 = timeStamp - current2.endTimeStamp;
						if (num4 < num2)
						{
							flag = true;
							num2 = num4;
							replayFileChunkTableEntry = current2;
						}
					}
					num++;
				}
			}
			if (flag)
			{
				return replayFileChunkTableEntry.filePointer;
			}
			return -1;
		}

		public void OnReplayDataSerialize(BinaryWriter writer)
		{
			writer.Write(base.Count);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ReplayFileChunkTableEntry current = enumerator.Current;
					writer.Write(current.chunkID);
					writer.Write(current.startTimeStamp);
					writer.Write(current.endTimeStamp);
					writer.Write(current.filePointer);
				}
			}
		}

		public void OnReplayDataDeserialize(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int chunkID = reader.ReadInt32();
				float startTimeStamp = reader.ReadSingle();
				float endTimeStamp = reader.ReadSingle();
				int filePointer = reader.ReadInt32();
				Add(new ReplayFileChunkTableEntry
				{
					chunkID = chunkID,
					startTimeStamp = startTimeStamp,
					endTimeStamp = endTimeStamp,
					filePointer = filePointer
				});
			}
		}
	}
}
