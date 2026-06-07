using System;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal struct PidVid : IEquatable<PidVid>
	{
		private const string KPLhHBVJLDKGPzAtRLcAfachjIBD = "[^a-fA-F0-9]";

		public ushort productId;

		public ushort vendorId;

		public bool isZero => false;

		public PidVid(ushort P_0, ushort P_1)
		{
			productId = 0;
			vendorId = 0;
		}

		public PidVid(string P_0)
		{
			productId = 0;
			vendorId = 0;
		}

		public PidVid(Guid P_0)
		{
			productId = 0;
			vendorId = 0;
		}

		public bool Equals(string pidVid)
		{
			return false;
		}

		public Guid ToProductGuid()
		{
			return default(Guid);
		}

		private bool jSUlXjwtYjnGvEcaTvuknhdSwBPv(string P_0)
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

		public bool Equals(PidVid other)
		{
			return false;
		}

		public static bool operator ==(PidVid x, PidVid y)
		{
			return false;
		}

		public static bool operator !=(PidVid x, PidVid y)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool ArrayContains(string[] pidVids, ref PidVid vidPid)
		{
			return false;
		}

		private static string ETaErgAxGXMUqLRPyZqNFZDLNutm(string P_0)
		{
			return null;
		}
	}
}
