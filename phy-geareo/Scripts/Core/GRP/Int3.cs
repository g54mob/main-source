using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;
using UnityEngine;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct Int3 : IMemoryPackable<Int3>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class Int3Formatter : MemoryPackFormatter<Int3>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Int3 value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref Int3 value)
			{
			}
		}

		public int x;

		public int y;

		public int z;

		public Int3(int x, int y, int z)
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}

		public Int3(int x, int y)
		{
			this.x = 0;
			this.y = 0;
			z = 0;
		}

		public Int3(Vector3Int v)
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public Vector3Int ToVector3Int()
		{
			return default(Vector3Int);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Int3 l, Int3 r)
		{
			return false;
		}

		public static bool operator !=(Int3 l, Int3 r)
		{
			return false;
		}

		static Int3()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Int3 value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref Int3 value)
		{
		}
	}
}
