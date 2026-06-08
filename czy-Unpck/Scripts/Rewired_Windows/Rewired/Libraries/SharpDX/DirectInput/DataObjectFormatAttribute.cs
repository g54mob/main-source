using System;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class DataObjectFormatAttribute : Attribute
	{
		public string Name;

		public string Guid;

		public int ArrayCount;

		public lXAXFkMOntMikfBMvxfdIESZBAu TypeFlags;

		public RFYZdQnILpPjOBVPMgunqXvTxuC Flags;

		public int InstanceNumber;

		public DataObjectFormatAttribute()
		{
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
			InstanceNumber = 0;
			Guid = "";
			TypeFlags = lXAXFkMOntMikfBMvxfdIESZBAu.ePJfrrDTvzTxHjRlLDJUwDDFEdY;
		}

		public DataObjectFormatAttribute(string guid, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(string guid, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags, int instanceNumber)
		{
			Guid = guid;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(string guid, int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags)
		{
			Guid = guid;
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
		}

		public DataObjectFormatAttribute(lXAXFkMOntMikfBMvxfdIESZBAu typeFlags)
		{
			TypeFlags = typeFlags;
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
			InstanceNumber = 0;
			ArrayCount = 0;
		}

		public DataObjectFormatAttribute(lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags)
		{
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags, int instanceNumber)
		{
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
		}

		public DataObjectFormatAttribute(int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
		}

		public DataObjectFormatAttribute(int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, RFYZdQnILpPjOBVPMgunqXvTxuC flags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = flags;
			InstanceNumber = instanceNumber;
		}

		public DataObjectFormatAttribute(int arrayCount, lXAXFkMOntMikfBMvxfdIESZBAu typeFlags, int instanceNumber)
		{
			ArrayCount = arrayCount;
			TypeFlags = typeFlags;
			Flags = RFYZdQnILpPjOBVPMgunqXvTxuC.UyGwCSXAdlJCSRSfHscRvehUkwi;
			InstanceNumber = instanceNumber;
		}
	}
}
