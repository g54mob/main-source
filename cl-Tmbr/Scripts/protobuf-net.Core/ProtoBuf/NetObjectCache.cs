using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProtoBuf
{
	internal sealed class NetObjectCache
	{
		[StructLayout(LayoutKind.Auto)]
		private readonly struct ObjectKey : IEquatable<ObjectKey>
		{
			private readonly object _obj;

			private readonly Type _subTypeLevel;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ObjectKey(object obj, Type subTypeLevel)
			{
				_obj = obj;
				_subTypeLevel = subTypeLevel;
			}

			public override string ToString()
			{
				return $"{_subTypeLevel}/{_obj}";
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override int GetHashCode()
			{
				return RuntimeHelpers.GetHashCode(_obj) ^ (_subTypeLevel?.GetHashCode() ?? 0);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public override bool Equals(object obj)
			{
				if (obj is ObjectKey other)
				{
					return Equals(other);
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool Equals(ObjectKey other)
			{
				return (_obj == other._obj) & (_subTypeLevel == other._subTypeLevel);
			}
		}

		private readonly Dictionary<ObjectKey, long> _knownLengths = new Dictionary<ObjectKey, long>();

		private int _hit;

		private int _miss;

		internal int LengthHits => _hit;

		internal int LengthMisses => _miss;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryGetKnownLength(object obj, Type subTypeLevel, out long length)
		{
			if (_knownLengths.TryGetValue(new ObjectKey(obj, subTypeLevel), out length))
			{
				_hit++;
				return true;
			}
			_miss++;
			length = 0L;
			return false;
		}

		public void SetKnownLength(object obj, Type subTypeLevel, long length)
		{
			ObjectKey key = new ObjectKey(obj, subTypeLevel);
			_knownLengths[key] = length;
		}

		internal void Clear()
		{
			_knownLengths.Clear();
			_hit = (_miss = 0);
		}

		internal void InitializeFrom(NetObjectCache obj)
		{
			if (obj == null)
			{
				return;
			}
			_knownLengths.Clear();
			foreach (KeyValuePair<ObjectKey, long> knownLength in obj._knownLengths)
			{
				_knownLengths.Add(knownLength.Key, knownLength.Value);
			}
		}

		internal void CopyBack(NetObjectCache obj)
		{
			if (obj != null)
			{
				obj._hit += _hit;
				obj._miss += _miss;
			}
		}
	}
}
