using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UltimateReplay.Storage
{
	public class ReplayFileChunk : List<ReplaySnapshot>, IEquatable<ReplayFileChunk>
	{
		public const float chunkOverlapThreshold = 1f;

		public int chunkID;

		public float ChunkStartTime
		{
			get
			{
				if (base.Count == 0)
				{
					return 0f;
				}
				return base[0].TimeStamp;
			}
		}

		public float ChunkEndTime
		{
			get
			{
				if (base.Count == 0)
				{
					return 0f;
				}
				return base[base.Count - 1].TimeStamp;
			}
		}

		public float ChunkDuration => ChunkEndTime - ChunkStartTime;

		internal ReplayFileChunk()
		{
		}

		public ReplayFileChunk(int chunkID)
		{
			this.chunkID = chunkID;
		}

		public bool Equals(ReplayFileChunk other)
		{
			return chunkID == other.chunkID;
		}

		public ReplayFileChunk Clone()
		{
			ReplayFileChunk replayFileChunk = new ReplayFileChunk(chunkID);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ReplaySnapshot current = enumerator.Current;
					replayFileChunk.Store(current);
				}
				return replayFileChunk;
			}
		}

		public void Store(ReplaySnapshot snapshot)
		{
			Add(snapshot);
			Sort((ReplaySnapshot a, ReplaySnapshot b) => a.TimeStamp.CompareTo(b.TimeStamp));
		}

		public ReplaySnapshot Restore(float timeStamp)
		{
			if (base.Count == 0)
			{
				return null;
			}
			if (timeStamp < ChunkStartTime || timeStamp > ChunkEndTime)
			{
				return null;
			}
			ReplaySnapshot result = base[0];
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext() && !((result = enumerator.Current).TimeStamp >= timeStamp))
				{
				}
			}
			return result;
		}

		public void OnReplayDataSerialize(BinaryWriter writer)
		{
			writer.Write(chunkID);
			writer.Write(ChunkStartTime);
			writer.Write(ChunkEndTime);
			writer.Write(base.Count);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnReplayDataSerialize(writer);
				}
			}
		}

		public void OnReplayDataDeserialize(BinaryReader reader)
		{
			chunkID = reader.ReadInt32();
			float num = reader.ReadSingle();
			float num2 = reader.ReadSingle();
			int num3 = reader.ReadInt32();
			for (int i = 0; i < num3; i++)
			{
				ReplaySnapshot replaySnapshot = new ReplaySnapshot(0f);
				replaySnapshot.OnReplayDataDeserialize(reader);
				Add(replaySnapshot);
			}
			if (num != ChunkStartTime || num2 != ChunkEndTime)
			{
				Debug.LogWarning("Possible corrupt replay file chunk - Expected time stamps do not match actual time stamps");
			}
		}
	}
}
