using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;

namespace Restory.UI.Views
{
	[Serializable]
	public struct ToggleButtonGroupState : IEquatable<ToggleButtonGroupState>, IComparable<ToggleButtonGroupState>
	{
		public const int MAX_LENGTH = 64;

		[SerializeField]
		private ulong data;

		[SerializeField]
		private int length;

		public readonly ulong Data => data;

		public int Length
		{
			get
			{
				return length;
			}
			set
			{
				length = value;
			}
		}

		public bool this[int index]
		{
			get
			{
				if (index < 0 || index >= length)
				{
					throw new ArgumentOutOfRangeException("index", $"index of {index} should be in the range of 0 and {length - 1} inclusively.");
				}
				ulong num = (ulong)(1L << index);
				return (data & num) == num;
			}
			set
			{
				if (index < 0 || index >= length)
				{
					throw new ArgumentOutOfRangeException("index", $"index of {index} should be in the range of 0 and {length - 1} inclusively.");
				}
				ulong num = (ulong)(1L << index);
				if (value)
				{
					data |= num;
				}
				else
				{
					data &= ~num;
				}
			}
		}

		public ToggleButtonGroupState(ulong optionsBitMask, int length)
		{
			if (length < 0 || length > 64)
			{
				throw new ArgumentOutOfRangeException("length", $"length of {length} should be greater than or equal to 0 and less than or equal to {64}.");
			}
			data = optionsBitMask;
			this.length = length;
			ResetOptions(this.length);
		}

		public Span<int> GetActiveOptions(Span<int> activeOptionsIndices)
		{
			if (activeOptionsIndices.Length < length)
			{
				throw new ArgumentException($"indices' length ({activeOptionsIndices.Length}) should be equal to or greater than the ToggleButtonGroupState's length ({length}).");
			}
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				if (this[i])
				{
					activeOptionsIndices[num] = i;
					num++;
				}
			}
			return activeOptionsIndices.Slice(0, num);
		}

		public Span<int> GetInactiveOptions(Span<int> inactiveOptionsIndices)
		{
			if (inactiveOptionsIndices.Length < length)
			{
				throw new ArgumentException($"indices' length ({inactiveOptionsIndices.Length}) should be equal to or greater than the ToggleButtonGroupState's length ({length}).");
			}
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				if (!this[i])
				{
					inactiveOptionsIndices[num] = i;
					num++;
				}
			}
			return inactiveOptionsIndices.Slice(0, num);
		}

		public void SetAllOptions()
		{
			data = ulong.MaxValue;
			ResetOptions(length);
		}

		public void ResetAllOptions()
		{
			data = 0uL;
		}

		public void ToggleAllOptions()
		{
			data = ~data;
			ResetOptions(length);
		}

		public static ToggleButtonGroupState CreateFromOptions(IList<bool> options)
		{
			int count = options.Count;
			ToggleButtonGroupState result = new ToggleButtonGroupState(0uL, count);
			for (int i = 0; i < count; i++)
			{
				result[i] = options[i];
			}
			return result;
		}

		public static ToggleButtonGroupState FromEnumFlags<T>(T options, int length = -1) where T : Enum
		{
			if (!TypeTraits<T>.IsEnumFlags)
			{
				throw new ArgumentException("Enum type T is not a flag enum type.");
			}
			Type underlyingType = Enum.GetUnderlyingType(typeof(T));
			if (length == -1)
			{
				length = Type.GetTypeCode(underlyingType) switch
				{
					TypeCode.Byte => 8, 
					TypeCode.SByte => 8, 
					TypeCode.UInt16 => 16, 
					TypeCode.Int16 => 16, 
					TypeCode.UInt32 => 32, 
					TypeCode.Int32 => 32, 
					TypeCode.Int64 => 64, 
					TypeCode.UInt64 => 64, 
					_ => 0, 
				};
			}
			return new ToggleButtonGroupState((ulong)UnsafeUtility.As<T, int>(ref options), length);
		}

		public static T ToEnumFlags<T>(ToggleButtonGroupState options, bool acceptsLengthMismatch = true) where T : Enum
		{
			if (!TypeTraits<T>.IsEnumFlags)
			{
				throw new ArgumentException("Enum type T is not a flag enum type.");
			}
			int num = Type.GetTypeCode(Enum.GetUnderlyingType(typeof(T))) switch
			{
				TypeCode.Byte => 8, 
				TypeCode.SByte => 8, 
				TypeCode.UInt16 => 16, 
				TypeCode.Int16 => 16, 
				TypeCode.UInt32 => 32, 
				TypeCode.Int32 => 32, 
				TypeCode.Int64 => 64, 
				TypeCode.UInt64 => 64, 
				_ => -1, 
			};
			if (!acceptsLengthMismatch && options.length != num)
			{
				throw new ArgumentException("Cannot sync to enum flag since the ToggleButtonGroupState has a different amount of options.");
			}
			return (T)Enum.Parse(typeof(T), options.data.ToString());
		}

		public readonly int CompareTo(ToggleButtonGroupState other)
		{
			if (!(other == this))
			{
				return -1;
			}
			return 1;
		}

		public static bool Compare<T>(ToggleButtonGroupState options, T value) where T : Enum
		{
			if (!TypeTraits<T>.IsEnumFlags)
			{
				throw new ArgumentException("Enum type T is not a flag enum type.");
			}
			ulong num = (ulong)UnsafeUtility.As<T, int>(ref value);
			return options.data == num;
		}

		private void ResetOptions(int startingIndex)
		{
			for (int i = startingIndex; i < 64; i++)
			{
				ulong num = (ulong)(1L << i);
				data &= ~num;
			}
		}

		public static bool operator ==(ToggleButtonGroupState lhs, ToggleButtonGroupState rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ToggleButtonGroupState lhs, ToggleButtonGroupState rhs)
		{
			return !(lhs == rhs);
		}

		public readonly bool Equals(ToggleButtonGroupState other)
		{
			if (data == other.data)
			{
				return length == other.length;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj is ToggleButtonGroupState other)
			{
				return Equals(other);
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(data, length);
		}

		public override string ToString()
		{
			return Convert.ToString((long)data, 2).PadLeft(Length, '0');
		}
	}
}
