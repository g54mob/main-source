using System.Buffers;
using MemoryPack;
using MemoryPack.Internal;
using UnityEngine;

namespace GRP
{
	[MemoryPackable(GenerateType.Object)]
	public struct Float3 : IMemoryPackable<Float3>, IMemoryPackFormatterRegister
	{
		[Preserve]
		private sealed class Float3Formatter : MemoryPackFormatter<Float3>
		{
			[Preserve]
			public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Float3 value)
			{
			}

			[Preserve]
			public override void Deserialize(ref MemoryPackReader reader, ref Float3 value)
			{
			}
		}

		public float x;

		public float y;

		public float z;

		public Float3(float x, float y, float z)
		{
			this.x = 0f;
			this.y = 0f;
			this.z = 0f;
		}

		public Float3(float x, float y)
		{
			this.x = 0f;
			this.y = 0f;
			z = 0f;
		}

		public Float3(Vector3 v)
		{
			x = 0f;
			y = 0f;
			z = 0f;
		}

		public Vector3 ToVector3()
		{
			return default(Vector3);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Float3 l, Float3 r)
		{
			return false;
		}

		public static bool operator !=(Float3 l, Float3 r)
		{
			return false;
		}

		static Float3()
		{
		}

		[Preserve]
		public static void RegisterFormatter()
		{
		}

		[Preserve]
		public static void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, ref Float3 value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[Preserve]
		public static void Deserialize(ref MemoryPackReader reader, ref Float3 value)
		{
		}
	}
}
