using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct PidVid : IEquatable<PidVid>
	{
		private const string eIUCfoJriILCFYaYCrhkUbTPJMgk = "[^a-fA-F0-9]";

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
			if (string.IsNullOrEmpty(mcrrPGJjiKKKtGVrbGPPLsndVkS(pidVid)))
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
			return RvJRWQMLloANsLouOUagpFSiiMu(mcrrPGJjiKKKtGVrbGPPLsndVkS(pidVid));
		}

		public Guid ToProductGuid()
		{
			return MiscTools.CreateHIDProductGuid(vendorId, productId);
		}

		private bool RvJRWQMLloANsLouOUagpFSiiMu(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				bool result = default(bool);
				while (true)
				{
					int num = -1564865342;
					while (true)
					{
						switch (num ^ -1564865341)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (P_0.Length < 8)
						{
							num = -1564865343;
							continue;
						}
						try
						{
							if (productId != ushort.Parse(P_0.Substring(0, 4), NumberStyles.AllowHexSpecifier))
							{
								goto IL_0052;
							}
							goto IL_008a;
							IL_0052:
							int num2 = -1564865342;
							goto IL_0057;
							IL_0057:
							while (true)
							{
								switch (num2 ^ -1564865341)
								{
								case 3:
									break;
								default:
									goto end_IL_0038;
								case 1:
									result = false;
									num2 = -1564865343;
									continue;
								case 2:
									goto end_IL_0038;
								case 4:
									goto IL_008a;
								case 0:
									goto end_IL_0038;
								}
								break;
							}
							goto IL_0052;
							IL_008a:
							result = vendorId == ushort.Parse(P_0.Substring(4, 4), NumberStyles.AllowHexSpecifier);
							num2 = -1564865341;
							goto IL_0057;
							end_IL_0038:;
						}
						catch
						{
							result = false;
						}
						return result;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is PidVid pidVid))
			{
				return false;
			}
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
			while (true)
			{
				int num2 = 1751372953;
				while (true)
				{
					switch (num2 ^ 0x6863D49B)
					{
					case 0:
						break;
					case 2:
						goto IL_0032;
					default:
						return num;
					}
					break;
					IL_0032:
					num = num * 29 + productId.GetHashCode();
					num2 = 1751372954;
				}
			}
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
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = -524465207;
				while (true)
				{
					switch (num2 ^ -524465206)
					{
					case 0:
						break;
					case 3:
						num2 = -524465205;
						continue;
					case 2:
						if (vidPid.Equals(pidVids[num]))
						{
							return true;
						}
						num++;
						num2 = -524465205;
						continue;
					default:
						if (num >= pidVids.Length)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private static string mcrrPGJjiKKKtGVrbGPPLsndVkS(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				goto IL_0008;
			}
			int num;
			if (Regex.IsMatch(P_0, "[^a-fA-F0-9]"))
			{
				P_0 = Regex.Replace(P_0, "[^a-fA-F0-9]", "");
				num = 1445429302;
				goto IL_000d;
			}
			goto IL_0052;
			IL_000d:
			switch (num ^ 0x56278035)
			{
			case 2:
				break;
			case 1:
				return null;
			case 3:
				goto IL_0052;
			default:
				return null;
			}
			goto IL_0008;
			IL_0052:
			if (string.IsNullOrEmpty(P_0))
			{
				num = 1445429301;
				goto IL_000d;
			}
			if (P_0.Length < 8)
			{
				return null;
			}
			return P_0;
			IL_0008:
			num = 1445429300;
			goto IL_000d;
		}
	}
}
