using System;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct PidVid : IEquatable<PidVid>
	{
		private const string SDPiOIFiNlgCifjoQSrfbVJwSSW = "[^a-fA-F0-9]";

		public ushort productId;

		public ushort vendorId;

		public bool isZero => false;

		public PidVid(ushort productId, ushort vendorId)
		{
			this.productId = 0;
			this.vendorId = 0;
		}

		public PidVid(string pidVid)
		{
			productId = 0;
			vendorId = 0;
		}

		public PidVid(Guid productGuid)
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

		private bool fHOYOgwNUThSBImGGBAnClSFnuOQ(string P_0)
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

		private static string GdaEsvjLYvPQKFkjbxYCBSaKmHi(string P_0)
		{
			return null;
		}
	}
}
