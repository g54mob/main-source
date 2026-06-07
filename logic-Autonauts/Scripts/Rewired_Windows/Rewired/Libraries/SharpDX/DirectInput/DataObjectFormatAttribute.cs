using System;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class DataObjectFormatAttribute : Attribute
	{
		public string Name;

		public string Guid;

		public int ArrayCount;

		public gxhgVrOliVamAhmjXjgnPKfDmZY TypeFlags;

		public KGdhxBzzvBLbuRCvsFfplWIPDvu Flags;

		public int InstanceNumber;

		public DataObjectFormatAttribute()
		{
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
			InstanceNumber = 0;
			Guid = "";
			TypeFlags = gxhgVrOliVamAhmjXjgnPKfDmZY.vvyijmZOzRFtTdippDQZhtsZhGJC;
		}

		public DataObjectFormatAttribute(string guid, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(string guid, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags, int instanceNumber)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
		}

		public DataObjectFormatAttribute(gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags)
		{
			TypeFlags = typeFlags;
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags)
		{
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags, int instanceNumber)
		{
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
		}

		public DataObjectFormatAttribute(int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, KGdhxBzzvBLbuRCvsFfplWIPDvu flags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, gxhgVrOliVamAhmjXjgnPKfDmZY typeFlags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = KGdhxBzzvBLbuRCvsFfplWIPDvu.PkbJcFPqmFczuJhwlfomqbZGagG;
			InstanceNumber = instanceNumber;
		}
	}
}
