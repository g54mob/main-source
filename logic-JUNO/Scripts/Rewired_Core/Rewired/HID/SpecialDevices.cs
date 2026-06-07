namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SpecialDevices
	{
		private class SOQhGTeSSTbRJEKnbgLUFjuFVevAA
		{
			public readonly ushort lzpfdMACJrScPwzmzSkhsmaFBcTEb;

			public readonly ushort hnpAtaHwobEQOKAkwfOXrdzNwRcx;

			public readonly string zEXagIuStnANljxqQNXSnGeApOZJ;

			public readonly bool LPRTISMqLfxLjJMrhJYgvIEGJINH;

			public readonly int aEdJLYCUTYEGSNvyPfxWweXwPTkn;

			public readonly int LiLzipvNLBEuwGmkCYOUjsZJlSHwA;

			public readonly int zISTQisGLyttgkPBZovDevCsNjdX;

			public readonly float qVfJuZHKadIJbeaZoptjfePdLoaob;

			public SOQhGTeSSTbRJEKnbgLUFjuFVevAA(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
			{
				lzpfdMACJrScPwzmzSkhsmaFBcTEb = P_0;
				hnpAtaHwobEQOKAkwfOXrdzNwRcx = P_1;
				if (string.IsNullOrEmpty(P_2))
				{
					P_2 = string.Empty;
				}
				zEXagIuStnANljxqQNXSnGeApOZJ = P_2;
				LPRTISMqLfxLjJMrhJYgvIEGJINH = P_3;
				aEdJLYCUTYEGSNvyPfxWweXwPTkn = P_4;
				LiLzipvNLBEuwGmkCYOUjsZJlSHwA = P_5;
				zISTQisGLyttgkPBZovDevCsNjdX = P_6;
				qVfJuZHKadIJbeaZoptjfePdLoaob = P_7;
			}

			public bool bvDwZzVdYWNTpQWCUvFDUYnmTFMB(ushort P_0, ushort P_1)
			{
				if (lzpfdMACJrScPwzmzSkhsmaFBcTEb == P_0)
				{
					return hnpAtaHwobEQOKAkwfOXrdzNwRcx == P_1;
				}
				return false;
			}

			public bool eZMJvLpKonPJFowLqhgFgGEbVlaI(ushort P_0, ushort P_1, string P_2)
			{
				if (lzpfdMACJrScPwzmzSkhsmaFBcTEb != P_0 || hnpAtaHwobEQOKAkwfOXrdzNwRcx != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return zEXagIuStnANljxqQNXSnGeApOZJ == P_2;
					}
					return false;
				}
				return true;
			}

			public bool iKFVmCKypffuwuarSOWKBlUIRLnB(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return zEXagIuStnANljxqQNXSnGeApOZJ == P_0;
				}
				return false;
			}
		}

		private const float RgtxZZRdKtbdcfMAWXJFtOSIBcfIA = 0.034f;

		private static SOQhGTeSSTbRJEKnbgLUFjuFVevAA[] VBwxSYTbphAgKNPmLZMnzKyNROTm = new SOQhGTeSSTbRJEKnbgLUFjuFVevAA[3]
		{
			new SOQhGTeSSTbRJEKnbgLUFjuFVevAA(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
			new SOQhGTeSSTbRJEKnbgLUFjuFVevAA(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
			new SOQhGTeSSTbRJEKnbgLUFjuFVevAA(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return NzZXzSSOQrGOssGDeUpmaYiXEdKX(vendorId, productId, productName)?.LPRTISMqLfxLjJMrhJYgvIEGJINH ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return NzZXzSSOQrGOssGDeUpmaYiXEdKX(vendorId, productId, productName)?.qVfJuZHKadIJbeaZoptjfePdLoaob ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			for (int i = 0; i < VBwxSYTbphAgKNPmLZMnzKyNROTm.Length; i++)
			{
				if (VBwxSYTbphAgKNPmLZMnzKyNROTm[i].bvDwZzVdYWNTpQWCUvFDUYnmTFMB(vendorId, productId) && VBwxSYTbphAgKNPmLZMnzKyNROTm[i].LPRTISMqLfxLjJMrhJYgvIEGJINH)
				{
					min = VBwxSYTbphAgKNPmLZMnzKyNROTm[i].aEdJLYCUTYEGSNvyPfxWweXwPTkn;
					max = VBwxSYTbphAgKNPmLZMnzKyNROTm[i].LiLzipvNLBEuwGmkCYOUjsZJlSHwA;
					zero = VBwxSYTbphAgKNPmLZMnzKyNROTm[i].zISTQisGLyttgkPBZovDevCsNjdX;
					return true;
				}
			}
			min = 0;
			max = 0;
			zero = 0;
			return false;
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return oWBaZXEKlamhynSfkUnIcaGKNydl(vendorId, productId, productName);
		}

		private static bool oWBaZXEKlamhynSfkUnIcaGKNydl(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < VBwxSYTbphAgKNPmLZMnzKyNROTm.Length; i++)
			{
				if (VBwxSYTbphAgKNPmLZMnzKyNROTm[i].eZMJvLpKonPJFowLqhgFgGEbVlaI(P_0, P_1, P_2))
				{
					return true;
				}
			}
			return false;
		}

		private static SOQhGTeSSTbRJEKnbgLUFjuFVevAA NzZXzSSOQrGOssGDeUpmaYiXEdKX(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < VBwxSYTbphAgKNPmLZMnzKyNROTm.Length; i++)
			{
				if (VBwxSYTbphAgKNPmLZMnzKyNROTm[i].eZMJvLpKonPJFowLqhgFgGEbVlaI(P_0, P_1, P_2))
				{
					return VBwxSYTbphAgKNPmLZMnzKyNROTm[i];
				}
			}
			return null;
		}
	}
}
