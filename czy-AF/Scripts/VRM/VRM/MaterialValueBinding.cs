using System;
using UnityEngine;

namespace VRM
{
	[Serializable]
	public struct MaterialValueBinding : IEquatable<MaterialValueBinding>
	{
		public string MaterialName;

		public string ValueName;

		public Vector4 TargetValue;

		public Vector4 BaseValue;

		public bool Equals(MaterialValueBinding other)
		{
			if (string.Equals(MaterialName, other.MaterialName) && string.Equals(ValueName, other.ValueName) && TargetValue.Equals(other.TargetValue))
			{
				return BaseValue.Equals(other.BaseValue);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is MaterialValueBinding)
			{
				return Equals((MaterialValueBinding)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((((MaterialName != null) ? MaterialName.GetHashCode() : 0) * 397) ^ ((ValueName != null) ? ValueName.GetHashCode() : 0)) * 397) ^ TargetValue.GetHashCode()) * 397) ^ BaseValue.GetHashCode();
		}
	}
}
