using System;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Meta
{
	[StructLayout(LayoutKind.Auto)]
	public readonly struct EnumMember : IEquatable<EnumMember>, IComparable<EnumMember>
	{
		public string Name { get; }

		public object Value { get; }

		internal bool HasValue
		{
			get
			{
				if (Value != null)
				{
					return !string.IsNullOrWhiteSpace(Name);
				}
				return false;
			}
		}

		public EnumMember(object value, string name)
		{
			Name = name;
			Value = value;
		}

		internal int? TryGetInt32()
		{
			return TryGetInt32(Value);
		}

		internal static int? TryGetInt32(object value)
		{
			if (value != null)
			{
				Type type = value.GetType();
				if (type.IsEnum)
				{
					type = Enum.GetUnderlyingType(type);
				}
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.SByte:
					return (sbyte)value;
				case TypeCode.Int16:
					return (short)value;
				case TypeCode.Int32:
					return (int)value;
				case TypeCode.Byte:
					return (byte)value;
				case TypeCode.UInt16:
					return (ushort)value;
				case TypeCode.UInt32:
				{
					uint num3 = (uint)value;
					if (num3 <= int.MaxValue)
					{
						return (int)num3;
					}
					break;
				}
				case TypeCode.UInt64:
				{
					ulong num2 = (ulong)value;
					if (num2 <= int.MaxValue)
					{
						return (int)num2;
					}
					break;
				}
				case TypeCode.Int64:
				{
					long num = (long)value;
					if (num >= int.MinValue && num <= int.MaxValue)
					{
						return (int)num;
					}
					break;
				}
				}
			}
			return null;
		}

		public EnumMember WithName(string name)
		{
			return new EnumMember(Value, name);
		}

		public EnumMember WithValue(object value)
		{
			return new EnumMember(value, Name);
		}

		public EnumMember Normalize(Type type)
		{
			return WithValue(Normalize(Value, type));
		}

		public bool Equals<T>(T value) where T : unmanaged
		{
			return object.Equals(Normalize(Value, typeof(T)), Normalize(value, typeof(T)));
		}

		public override string ToString()
		{
			return $"{Name}={Value}";
		}

		public override int GetHashCode()
		{
			return (Name?.GetHashCode() ?? 0) ^ (Value?.GetHashCode() ?? 0);
		}

		public override bool Equals(object obj)
		{
			if (obj is EnumMember other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(EnumMember other)
		{
			if (string.Equals(Name, other.Name))
			{
				return object.Equals(Value, other.Value);
			}
			return false;
		}

		public static bool operator ==(EnumMember x, EnumMember y)
		{
			return x.Equals(y);
		}

		public static bool operator !=(EnumMember x, EnumMember y)
		{
			return !x.Equals(y);
		}

		private static object Normalize(object value, Type type)
		{
			return Convert.ChangeType(value, type.IsEnum ? Enum.GetUnderlyingType(type) : type);
		}

		public static EnumMember Create<T>(T value) where T : unmanaged
		{
			return new EnumMember(value, value.ToString()).Normalize(typeof(T));
		}

		internal void Validate()
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				ThrowHelper.ThrowInvalidOperationException("All enum declarations must have valid names");
			}
		}

		public int CompareTo(EnumMember other)
		{
			int? num = TryGetInt32();
			int? num2 = other.TryGetInt32();
			if (!num.HasValue && !num2.HasValue)
			{
				return 0;
			}
			if (!num.HasValue)
			{
				return 1;
			}
			if (!num2.HasValue)
			{
				return -1;
			}
			if (num.Value < 0 && num2.Value >= 0)
			{
				return 1;
			}
			if (num2.Value < 0 && num.Value >= 0)
			{
				return -1;
			}
			return num.Value.CompareTo(num2.Value);
		}
	}
}
