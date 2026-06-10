using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	[FVSerializableKey("FloatRange", "")]
	public class FloatRange : Range<float>, IFVSerializable
	{
		public FloatRange(float min, float max)
			: base(min, max)
		{
		}

		public override float Random()
		{
			float num = (float)new System.Random().NextDouble();
			return Mathf.Min(base.Min, base.Max) + num * Mathf.Abs(base.Max - base.Min);
		}

		public float Random(System.Random random)
		{
			float num = (float)random.NextDouble();
			return Mathf.Min(base.Min, base.Max) + num * Mathf.Abs(base.Max - base.Min);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("Min", base.Min);
			serializer.Write("Max", base.Max);
		}

		public FloatRange(FVDeserializer deserializer)
			: base(0f, 0f)
		{
			base.Min = deserializer.ReadFloat("Min");
			base.Max = deserializer.ReadFloat("Max");
		}
	}
}
