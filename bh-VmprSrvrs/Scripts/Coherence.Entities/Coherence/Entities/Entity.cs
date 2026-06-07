using System;

namespace Coherence.Entities
{
	public struct Entity : IComparable<Entity>, IEquatable<Entity>
	{
		public const ushort MaxIndex = 65535;

		public const ushort EndOfEntities = 65535;

		public const ushort MaxIndices = 65533;

		public const ushort MaxID = 65534;

		public const ushort ClientInitialIndex = 32768;

		public const int NumIndexBits = 16;

		public const byte MaxVersions = 16;

		public const int NumVersionBits = 4;

		public static readonly bool Absolute;

		public static readonly bool Relative;

		public static readonly Entity InvalidRelative;

		public static readonly Entity InvalidAbsolute;

		public static readonly EntityComparer DefaultComparer;

		public ushort Index { get; }

		public byte Version { get; }

		public bool IsValid => false;

		public bool IsAbsolute { get; }

		public byte NextVersion => 0;

		public Entity(ushort index, byte version, bool isAbsolute)
		{
			Index = 0;
			Version = 0;
			IsAbsolute = false;
		}

		public bool IsClientCreated()
		{
			return false;
		}

		public void AssertAbsolute()
		{
		}

		public void AssertRelative()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static string TypeToString(bool isAbsolute)
		{
			return null;
		}

		public static void AssertSameType(Entity a, Entity b)
		{
		}

		public static bool operator ==(Entity a, Entity b)
		{
			return false;
		}

		public static bool operator !=(Entity a, Entity b)
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

		public int CompareTo(Entity other)
		{
			return 0;
		}

		public bool Equals(Entity other)
		{
			return false;
		}
	}
}
