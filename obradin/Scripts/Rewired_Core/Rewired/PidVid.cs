using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct PidVid : IEquatable<PidVid>
	{
		private const string mKDGanGLGBstxTehKErOhbGEYCG = "[^a-fA-F0-9]";

		public ushort productId;

		public ushort vendorId;

		public bool isZero
		{
			get
			{
				if (vendorId == 0)
				{
					return productId == 0;
				}
				return false;
			}
		}

		public PidVid(ushort productId, ushort vendorId)
		{
			this.productId = productId;
			this.vendorId = vendorId;
		}

		public PidVid(string pidVid)
		{
			if (string.IsNullOrEmpty(cIbBJXbDSIhuTcRzfCbOcwGNsZgC(pidVid)))
			{
				productId = 0;
				vendorId = 0;
				return;
			}
			try
			{
				productId = ushort.Parse(pidVid.Substring(0, 4), NumberStyles.AllowHexSpecifier);
				vendorId = ushort.Parse(pidVid.Substring(4, 4), NumberStyles.AllowHexSpecifier);
			}
			catch
			{
				productId = 0;
				vendorId = 0;
			}
		}

		public PidVid(Guid productGuid)
			: this(productGuid.ToString().Substring(0, 8))
		{
		}

		public bool Equals(string pidVid)
		{
			return LIBrvMAFIoYaOKMYzZpjAtmhGuE(cIbBJXbDSIhuTcRzfCbOcwGNsZgC(pidVid));
		}

		public Guid ToProductGuid()
		{
			return MiscTools.CreateHIDProductGuid(vendorId, productId);
		}

		private bool LIBrvMAFIoYaOKMYzZpjAtmhGuE(string P_0)
		{
			if (string.IsNullOrEmpty(P_0) || P_0.Length < 8)
			{
				return false;
			}
			try
			{
				if (productId != ushort.Parse(P_0.Substring(0, 4), NumberStyles.AllowHexSpecifier))
				{
					return false;
				}
				return vendorId == ushort.Parse(P_0.Substring(4, 4), NumberStyles.AllowHexSpecifier);
			}
			catch
			{
				return false;
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is PidVid))
			{
				return false;
			}
			PidVid pidVid = (PidVid)obj;
			if (pidVid.vendorId == vendorId)
			{
				return pidVid.productId == productId;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + vendorId.GetHashCode();
			return num * 29 + productId.GetHashCode();
		}

		public bool Equals(PidVid other)
		{
			if (vendorId == other.vendorId)
			{
				return productId == other.productId;
			}
			return false;
		}

		public static bool operator ==(PidVid x, PidVid y)
		{
			if (x.vendorId == y.vendorId)
			{
				return x.productId == y.productId;
			}
			return false;
		}

		public static bool operator !=(PidVid x, PidVid y)
		{
			return !(x == y);
		}

		public override string ToString()
		{
			return productId.ToString("x4") + vendorId.ToString("x4");
		}

		public static bool ArrayContains(string[] pidVids, ref PidVid vidPid)
		{
			if (pidVids == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = 1801714536;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x6B63FB69)
				{
				case 0:
					break;
				case 3:
					if (vidPid.Equals(pidVids[num]))
					{
						return true;
					}
					num++;
					num2 = 1801714541;
					continue;
				case 1:
					num2 = 1801714541;
					continue;
				case 5:
					return false;
				case 4:
				{
					int num3;
					if (num >= pidVids.Length)
					{
						num2 = 1801714539;
						num3 = num2;
					}
					else
					{
						num2 = 1801714538;
						num3 = num2;
					}
					continue;
				}
				default:
					return false;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 1801714540;
			goto IL_0008;
		}

		private static string cIbBJXbDSIhuTcRzfCbOcwGNsZgC(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (Regex.IsMatch(P_0, "[^a-fA-F0-9]"))
			{
				num = 1351362039;
				num2 = num;
			}
			else
			{
				num = 1351362037;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 1351362038;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x508C25F7)
				{
				case 3:
					break;
				case 2:
					if (string.IsNullOrEmpty(P_0))
					{
						return null;
					}
					if (P_0.Length < 8)
					{
						num = 1351362035;
						continue;
					}
					return P_0;
				case 0:
					P_0 = Regex.Replace(P_0, "[^a-fA-F0-9]", "");
					num = 1351362037;
					continue;
				case 1:
					return null;
				default:
					return null;
				}
				break;
			}
			goto IL_0008;
		}
	}
}
