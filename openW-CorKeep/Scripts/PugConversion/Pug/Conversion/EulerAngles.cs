using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.Conversion
{
	[Serializable]
	internal struct EulerAngles : IEquatable<EulerAngles>
	{
		public float3 Value;

		[HideInInspector]
		public math.RotationOrder RotationOrder;

		public static EulerAngles Default => new EulerAngles
		{
			RotationOrder = math.RotationOrder.ZXY
		};

		internal void SetValue(quaternion value)
		{
			Value = math.degrees(value.ToEulerAngles(RotationOrder));
		}

		public static implicit operator quaternion(EulerAngles euler)
		{
			return math.normalizesafe(quaternion.Euler(math.radians(euler.Value), euler.RotationOrder));
		}

		public bool Equals(EulerAngles other)
		{
			if (Value.Equals(other.Value))
			{
				return RotationOrder == other.RotationOrder;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is EulerAngles other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)math.hash(new float4(Value, (int)RotationOrder));
		}
	}
}
