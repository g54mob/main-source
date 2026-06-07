using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

namespace NBT.Tags
{
	public abstract class Tag : ICloneable, IEquatable<Tag>
	{
		public abstract object Value { get; set; }

		public abstract byte tagID { get; }

		public virtual Tag Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Tag Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract string toString();

		internal abstract void readTag(Stream stream);

		internal abstract void writeTag(Stream stream);

		public abstract object Clone();

		public abstract Type getType();

		public abstract bool Equals(Tag other);

		internal static Tag ReadTag(Stream stream, byte id)
		{
			return null;
		}

		public static string GetNamedTypeFromId(byte id)
		{
			return null;
		}

		public static explicit operator byte(Tag value)
		{
			return 0;
		}

		public static explicit operator bool(Tag value)
		{
			return false;
		}

		public static explicit operator bool[](Tag value)
		{
			return null;
		}

		public static explicit operator short(Tag value)
		{
			return 0;
		}

		public static explicit operator int(Tag value)
		{
			return 0;
		}

		public static explicit operator long(Tag value)
		{
			return 0L;
		}

		public static explicit operator float(Tag value)
		{
			return 0f;
		}

		public static explicit operator double(Tag value)
		{
			return 0.0;
		}

		public static explicit operator byte[](Tag value)
		{
			return null;
		}

		public static explicit operator string(Tag value)
		{
			return null;
		}

		public static explicit operator List<Tag>(Tag value)
		{
			return null;
		}

		public static explicit operator Dictionary<string, Tag>(Tag value)
		{
			return null;
		}

		public static explicit operator int[](Tag value)
		{
			return null;
		}

		public static explicit operator sbyte(Tag value)
		{
			return 0;
		}

		public static explicit operator ushort(Tag value)
		{
			return 0;
		}

		public static explicit operator uint(Tag value)
		{
			return 0u;
		}

		public static explicit operator ulong(Tag value)
		{
			return 0uL;
		}

		public static explicit operator IPAddress(Tag value)
		{
			return null;
		}

		public static explicit operator Vector2(Tag value)
		{
			return default(Vector2);
		}

		public static explicit operator Vector3(Tag value)
		{
			return default(Vector3);
		}

		public static explicit operator Vector4(Tag value)
		{
			return default(Vector4);
		}

		public static explicit operator Quaternion(Tag value)
		{
			return default(Quaternion);
		}

		public static explicit operator PhysicalAddress(Tag value)
		{
			return null;
		}

		public static explicit operator short[](Tag value)
		{
			return null;
		}

		public static explicit operator DateTime(Tag value)
		{
			return default(DateTime);
		}

		public static explicit operator TimeSpan(Tag value)
		{
			return default(TimeSpan);
		}

		public static explicit operator long[](Tag value)
		{
			return null;
		}

		public static explicit operator float[](Tag value)
		{
			return null;
		}

		public static explicit operator double[](Tag value)
		{
			return null;
		}

		public static explicit operator sbyte[](Tag value)
		{
			return null;
		}

		public static explicit operator ushort[](Tag value)
		{
			return null;
		}

		public static explicit operator uint[](Tag value)
		{
			return null;
		}

		public static explicit operator ulong[](Tag value)
		{
			return null;
		}

		public static explicit operator Vector3[](Tag value)
		{
			return null;
		}

		public static explicit operator Vector4[](Tag value)
		{
			return null;
		}

		public static explicit operator Vector2[](Tag value)
		{
			return null;
		}

		public static explicit operator string[](Tag value)
		{
			return null;
		}
	}
}
