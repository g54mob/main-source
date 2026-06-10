using System;
using NSMedieval.Serialization;
using Unity.Mathematics;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	[FVSerializableKey("IntRange", "")]
	public class IntRange : Range<int>, IFVSerializable
	{
		public IntRange(int min, int max)
			: base(min, max)
		{
		}

		public IntRange(IntRange range)
			: base(range.Min, range.Max)
		{
		}

		public bool IsZero()
		{
			if (base.Min.Equals(0))
			{
				return base.Max.Equals(0);
			}
			return false;
		}

		public int RandomMaxInclusive()
		{
			return UnityEngine.Random.Range(base.Min, base.Max + 1);
		}

		public override int Random()
		{
			return UnityEngine.Random.Range(base.Min, base.Max);
		}

		public int Random(System.Random random)
		{
			return random.Next(base.Min, base.Max);
		}

		public int Random(Unity.Mathematics.Random random)
		{
			return random.NextInt(base.Min, base.Max);
		}

		public float Average()
		{
			return (base.Min + base.Max) / 2;
		}

		public bool IsEquals(IntRange other)
		{
			if (base.Min == other.Min)
			{
				return base.Max == other.Max;
			}
			return false;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("Min", base.Min);
			serializer.Write("Max", base.Max);
		}

		public IntRange(FVDeserializer deserializer)
			: base(0, 0)
		{
			base.Min = deserializer.ReadInt("Min");
			base.Max = deserializer.ReadInt("Max");
		}
	}
}
