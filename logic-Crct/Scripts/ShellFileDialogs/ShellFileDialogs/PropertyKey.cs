using System;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 20)]
	internal struct PropertyKey : IEquatable<PropertyKey>
	{
		private Guid formatId;

		private int propertyId;

		public Guid FormatId => default(Guid);

		public int PropertyId => 0;

		public PropertyKey(Guid formatId, int propertyId)
		{
			this.formatId = default(Guid);
			this.propertyId = 0;
		}

		public PropertyKey(string formatId, int propertyId)
		{
			this.formatId = default(Guid);
			this.propertyId = 0;
		}

		public bool Equals(PropertyKey other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(PropertyKey propKey1, PropertyKey propKey2)
		{
			return false;
		}

		public static bool operator !=(PropertyKey propKey1, PropertyKey propKey2)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
