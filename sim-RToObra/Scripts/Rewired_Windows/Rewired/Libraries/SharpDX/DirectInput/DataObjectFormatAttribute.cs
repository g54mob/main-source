using System;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class DataObjectFormatAttribute : Attribute
	{
		public string Name;

		public string Guid;

		public int ArrayCount;

		public kwDQWJxJqLfGHqZNmyNdWGtdcVI TypeFlags;

		public QhXQmhCqlNXKdUDVRqbxwPKjhxua Flags;

		public int InstanceNumber;

		public DataObjectFormatAttribute()
		{
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
			InstanceNumber = 0;
			Guid = "";
			TypeFlags = kwDQWJxJqLfGHqZNmyNdWGtdcVI.xQWouGqblDuyKscTMUlBgNchQZH;
		}

		public DataObjectFormatAttribute(string guid, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(string guid, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags, int instanceNumber)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
		}

		public DataObjectFormatAttribute(kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags)
		{
			TypeFlags = typeFlags;
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags)
		{
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags, int instanceNumber)
		{
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
		}

		public DataObjectFormatAttribute(int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, QhXQmhCqlNXKdUDVRqbxwPKjhxua flags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = QhXQmhCqlNXKdUDVRqbxwPKjhxua.FIZxYpycmNmDbQxAMdnkneLgidG;
			InstanceNumber = instanceNumber;
		}
	}
}
