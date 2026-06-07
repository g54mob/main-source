using System;

namespace MagicaCloth2
{
	public readonly struct MagicaObjectId : IEquatable<MagicaObjectId>
	{
		private readonly int _value;

		public static readonly MagicaObjectId Invalid;

		public MagicaObjectId(int id)
		{
			_value = 0;
		}

		public bool IsValid()
		{
			return false;
		}

		public bool Equals(MagicaObjectId other)
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

		public static bool operator ==(MagicaObjectId left, MagicaObjectId right)
		{
			return false;
		}

		public static bool operator !=(MagicaObjectId left, MagicaObjectId right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
