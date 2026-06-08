using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;
using UnityEngine;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct Float4 : IMemoryPackable<Float4>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class Float4Formatter : MemoryPackFormatter<Float4>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Float4 value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref Float4 value)
			{
			}
		}

		public float x;

		public float y;

		public float z;

		public float w;

		public Float4(float x, float y, float z, float w)
		{
			this.x = 0f;
			this.y = 0f;
			this.z = 0f;
			this.w = 0f;
		}

		public Float4(float x, float y)
		{
			this.x = 0f;
			this.y = 0f;
			z = 0f;
			w = 0f;
		}

		public Float4(Quaternion v)
		{
			x = 0f;
			y = 0f;
			z = 0f;
			w = 0f;
		}

		public Quaternion ToQuaternion()
		{
			return default(Quaternion);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Float4 l, Float4 r)
		{
			return false;
		}

		public static bool operator !=(Float4 l, Float4 r)
		{
			return false;
		}

		static Float4()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Float4 value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref Float4 value)
		{
		}
	}
}
