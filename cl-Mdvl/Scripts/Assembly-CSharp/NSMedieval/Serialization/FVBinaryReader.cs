using System.Collections.Generic;
using System.IO;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Serialization
{
	public class FVBinaryReader
	{
		private readonly string id;

		private readonly MemoryStream memoryStream;

		private Stack<Dictionary<int, Vec3Long>> byteMaps;

		public BinaryReader Reader { get; }

		public Dictionary<int, Vec3Long> CurrentMap { get; private set; }

		public FVBinaryReader(string id, byte[] data)
		{
			this.id = id;
			memoryStream = new MemoryStream(data);
			Reader = new BinaryReader(memoryStream);
			byteMaps = new Stack<Dictionary<int, Vec3Long>>();
			CreateMap(0L, data.LongLength);
			SeekBuffer(0L);
		}

		~FVBinaryReader()
		{
			ReleaseMap();
			memoryStream?.Dispose();
		}

		public bool CreateMap(string key)
		{
			int hashCode = key.GetHashCode();
			if (!CurrentMap.ContainsKey(hashCode))
			{
				return false;
			}
			long x = CurrentMap[hashCode].x;
			long y = CurrentMap[hashCode].y;
			long z = CurrentMap[hashCode].z;
			if (x == y)
			{
				return false;
			}
			byteMaps.Push(CurrentMap);
			CreateMap(y, z);
			return true;
		}

		public void CreateMapForReference(long bufferPosition)
		{
			long num = 22L;
			SeekBuffer(bufferPosition - num);
			long dataStartByte = Reader.ReadInt64();
			long endByte = Reader.ReadInt64();
			byteMaps.Push(CurrentMap);
			CreateMap(dataStartByte, endByte);
		}

		private void CreateMap(long dataStartByte, long endByte)
		{
			CurrentMap = DictionaryPool<int, Vec3Long>.Get();
			long bufferPosition = GetBufferPosition();
			SeekBuffer(dataStartByte);
			long num = dataStartByte;
			int num2 = 0;
			while (num < endByte)
			{
				int key = Reader.ReadInt32();
				long x = Reader.ReadInt64();
				long y = Reader.ReadInt64();
				long num3 = Reader.ReadInt64();
				CurrentMap.Add(key, new Vec3Long(x, y, num3));
				SeekBuffer(num3);
				num = num3;
				num2++;
			}
			SeekBuffer(bufferPosition);
		}

		public void ReleaseMap()
		{
			if (CurrentMap != null)
			{
				DictionaryPool<int, Vec3Long>.Return(CurrentMap);
				if (byteMaps.Count > 0)
				{
					CurrentMap = byteMaps.Pop();
				}
				else
				{
					CurrentMap = null;
				}
			}
		}

		public string GetId()
		{
			return id;
		}

		public long GetBufferPosition()
		{
			return memoryStream.Position;
		}

		public void SeekBuffer(long index)
		{
			Reader.BaseStream.Seek(index, SeekOrigin.Begin);
		}

		public bool SeekBufferToKey(string key)
		{
			int hashCode = key.GetHashCode();
			if (!CurrentMap.ContainsKey(hashCode))
			{
				return false;
			}
			long num = 24L;
			SeekBuffer(CurrentMap[hashCode].x + num);
			return true;
		}
	}
}
