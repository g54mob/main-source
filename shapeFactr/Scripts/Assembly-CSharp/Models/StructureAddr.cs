using System;
using System.ComponentModel;
using System.Globalization;
using UnitGenerator;
using UnityEngine;

namespace Models
{
	[UnitGenerator.UnitOf(typeof(Vector2Int), UnitGenerator.UnitGenerateOptions.None, null)]
	[TypeConverter(typeof(StructureAddrTypeConverter))]
	public readonly struct StructureAddr : IEquatable<StructureAddr>
	{
		private class StructureAddrTypeConverter : TypeConverter
		{
			private static readonly Type WrapperType;

			private static readonly Type ValueType;

			public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
			{
				return false;
			}

			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return false;
			}

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
			{
				return null;
			}

			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				return null;
			}
		}

		private readonly Vector2Int value;

		public int x => 0;

		public int y => 0;

		public StructureAddr(int x, int y)
		{
			value = default(Vector2Int);
		}

		public static StructureAddr operator +(in StructureAddr x, in StructureAddr y)
		{
			return default(StructureAddr);
		}

		public static StructureAddr operator -(in StructureAddr x, in StructureAddr y)
		{
			return default(StructureAddr);
		}

		public Vector2Int AsPrimitive()
		{
			return default(Vector2Int);
		}

		public StructureAddr(Vector2Int value)
		{
			this.value = default(Vector2Int);
		}

		public static explicit operator Vector2Int(StructureAddr value)
		{
			return default(Vector2Int);
		}

		public static explicit operator StructureAddr(Vector2Int value)
		{
			return default(StructureAddr);
		}

		public bool Equals(StructureAddr other)
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

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(in StructureAddr x, in StructureAddr y)
		{
			return false;
		}

		public static bool operator !=(in StructureAddr x, in StructureAddr y)
		{
			return false;
		}
	}
}
