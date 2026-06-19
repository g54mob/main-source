using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public struct Vector3Override
	{
		private bool _override;

		private Vector3 _overrideValue;

		public static Vector3Override Default = new Vector3Override(null);

		public Vector3 OverrideValue => _overrideValue;

		public bool Override => _override;

		public static Vector3Override GetDefault => Default;

		public Vector3Override(Vector3? overrideValue = null)
		{
			if (overrideValue.HasValue)
			{
				_overrideValue = overrideValue.Value;
				_override = true;
			}
			else
			{
				_overrideValue = Vector3.zero;
				_override = false;
			}
		}

		public Vector3 GetValue(Vector3 fallback)
		{
			if (Override)
			{
				return OverrideValue;
			}
			return fallback;
		}

		public static bool operator ==(Vector3Override a, Vector3Override b)
		{
			if (a.Override == b.Override)
			{
				return a.OverrideValue == b.OverrideValue;
			}
			return false;
		}

		public static bool operator !=(Vector3Override a, Vector3Override b)
		{
			if (a.Override == b.Override)
			{
				return a.OverrideValue != b.OverrideValue;
			}
			return true;
		}

		public static Vector3Override operator +(Vector3Override a, Vector3Override b)
		{
			if (b.Override)
			{
				return b;
			}
			if (a.Override)
			{
				return a;
			}
			return GetDefault;
		}

		public bool Equals(Vector3Override other)
		{
			if (!other._override)
			{
				return !_override;
			}
			if (!_override)
			{
				return false;
			}
			return _overrideValue == other._overrideValue;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3Override other)
			{
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Override, OverrideValue);
		}
	}
}
