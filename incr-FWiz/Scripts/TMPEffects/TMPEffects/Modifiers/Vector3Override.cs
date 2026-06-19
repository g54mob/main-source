using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public struct Vector3Override
	{
		private bool _override;

		private Vector3 _overrideValue;

		public static Vector3Override Default;

		public Vector3 OverrideValue => default(Vector3);

		public bool Override => false;

		public static Vector3Override GetDefault => default(Vector3Override);

		public Vector3Override(Vector3? overrideValue = null)
		{
			_override = false;
			_overrideValue = default(Vector3);
		}

		public Vector3 GetValue(Vector3 fallback)
		{
			return default(Vector3);
		}

		public static bool operator ==(Vector3Override a, Vector3Override b)
		{
			return false;
		}

		public static bool operator !=(Vector3Override a, Vector3Override b)
		{
			return false;
		}

		public static Vector3Override operator +(Vector3Override a, Vector3Override b)
		{
			return default(Vector3Override);
		}

		public bool Equals(Vector3Override other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
