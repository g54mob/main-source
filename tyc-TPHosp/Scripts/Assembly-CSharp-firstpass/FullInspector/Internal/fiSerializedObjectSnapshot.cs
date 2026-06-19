using System.Collections.Generic;
using UnityEngine;

namespace FullInspector.Internal
{
	public class fiSerializedObjectSnapshot
	{
		private readonly List<string> _keys;

		private readonly List<string> _values;

		private readonly List<Object> _objectReferences;

		public bool IsEmpty
		{
			get
			{
				if (_keys.Count != 0)
				{
					return _values.Count == 0;
				}
				return true;
			}
		}

		public fiSerializedObjectSnapshot(ISerializedObject obj)
		{
			_keys = new List<string>(obj.SerializedStateKeys);
			_values = new List<string>(obj.SerializedStateValues);
			_objectReferences = new List<Object>(obj.SerializedObjectReferences);
		}

		public void RestoreSnapshot(ISerializedObject target)
		{
			target.SerializedStateKeys = new List<string>(_keys);
			target.SerializedStateValues = new List<string>(_values);
			target.SerializedObjectReferences = new List<Object>(_objectReferences);
			target.RestoreState();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is fiSerializedObjectSnapshot fiSerializedObjectSnapshot2))
			{
				return false;
			}
			if (AreEqual(_keys, fiSerializedObjectSnapshot2._keys) && AreEqual(_values, fiSerializedObjectSnapshot2._values))
			{
				return AreEqual(_objectReferences, fiSerializedObjectSnapshot2._objectReferences);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((13 * 7 + _keys.GetHashCode()) * 7 + _values.GetHashCode()) * 7 + _objectReferences.GetHashCode();
		}

		public static bool operator ==(fiSerializedObjectSnapshot a, fiSerializedObjectSnapshot b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(fiSerializedObjectSnapshot a, fiSerializedObjectSnapshot b)
		{
			return !object.Equals(a, b);
		}

		private static bool AreEqual<T>(List<T> a, List<T> b)
		{
			if (a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (!EqualityComparer<T>.Default.Equals(a[i], b[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
