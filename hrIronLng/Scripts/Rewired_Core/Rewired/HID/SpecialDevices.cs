namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SpecialDevices
	{
		private class sRGgZjsCSiDOYfdGIACAGKEpABf
		{
			public readonly ushort xWIfnycVeScryAKfrRyhksBsyEww;

			public readonly ushort RlmaoXaMoKUZWqFptaxMnKyGgXWx;

			public readonly string ayHNddMRplOPUACTbdErptyBFcQ;

			public readonly bool smiUaOVhePSbSkTkcdbgCFEMXX;

			public readonly int BkxWPZybWrEcjjWUUsruKDKzbXkC;

			public readonly int WaWmAQSjzZptutkJCoSXBGQTjvN;

			public readonly int AYKGUeGuYDmHOPsqiAncIhHihBik;

			public readonly float QCFJfQyodSxOPYiPeOJvuUpreaj;

			public sRGgZjsCSiDOYfdGIACAGKEpABf(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
				xWIfnycVeScryAKfrRyhksBsyEww = vendorId;
				RlmaoXaMoKUZWqFptaxMnKyGgXWx = productId;
				if (string.IsNullOrEmpty(productName))
				{
					productName = string.Empty;
				}
				ayHNddMRplOPUACTbdErptyBFcQ = productName;
				smiUaOVhePSbSkTkcdbgCFEMXX = hasRelativeAxes;
				BkxWPZybWrEcjjWUUsruKDKzbXkC = axisMin;
				WaWmAQSjzZptutkJCoSXBGQTjvN = axisMax;
				AYKGUeGuYDmHOPsqiAncIhHihBik = axisZero;
				QCFJfQyodSxOPYiPeOJvuUpreaj = relToAbsAxisConversionTimeout;
			}

			public bool zSUwZcEfZtCbPbSzERXSEnlJlfzZ(ushort P_0, ushort P_1)
			{
				if (xWIfnycVeScryAKfrRyhksBsyEww == P_0)
				{
					return RlmaoXaMoKUZWqFptaxMnKyGgXWx == P_1;
				}
				return false;
			}

			public bool zSUwZcEfZtCbPbSzERXSEnlJlfzZ(ushort P_0, ushort P_1, string P_2)
			{
				if (xWIfnycVeScryAKfrRyhksBsyEww != P_0 || RlmaoXaMoKUZWqFptaxMnKyGgXWx != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return ayHNddMRplOPUACTbdErptyBFcQ == P_2;
					}
					return false;
				}
				return true;
			}

			public bool zSUwZcEfZtCbPbSzERXSEnlJlfzZ(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return ayHNddMRplOPUACTbdErptyBFcQ == P_0;
				}
				return false;
			}
		}

		private const float yoCdjSPvzhWpntMHCsEDxFXmCQN = 0.034f;

		private static sRGgZjsCSiDOYfdGIACAGKEpABf[] VzxGbiSBvcyXKweXItYHtzZAOxs = new sRGgZjsCSiDOYfdGIACAGKEpABf[3]
		{
			new sRGgZjsCSiDOYfdGIACAGKEpABf(1133, 50726, "SpaceNavigator", hasRelativeAxes: true, -350, 350, 0, 0.034f),
			new sRGgZjsCSiDOYfdGIACAGKEpABf(1133, 50728, "SpaceNavigator for Notebooks", hasRelativeAxes: true, -350, 350, 0, 0.034f),
			new sRGgZjsCSiDOYfdGIACAGKEpABf(1133, 50727, "Space Explorer", hasRelativeAxes: true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return fgDOsvVHEBCntjrQRBJzDROqxjNA(vendorId, productId, productName)?.smiUaOVhePSbSkTkcdbgCFEMXX ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return fgDOsvVHEBCntjrQRBJzDROqxjNA(vendorId, productId, productName)?.QCFJfQyodSxOPYiPeOJvuUpreaj ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			for (int i = 0; i < VzxGbiSBvcyXKweXItYHtzZAOxs.Length; i++)
			{
				if (VzxGbiSBvcyXKweXItYHtzZAOxs[i].zSUwZcEfZtCbPbSzERXSEnlJlfzZ(vendorId, productId) && VzxGbiSBvcyXKweXItYHtzZAOxs[i].smiUaOVhePSbSkTkcdbgCFEMXX)
				{
					min = VzxGbiSBvcyXKweXItYHtzZAOxs[i].BkxWPZybWrEcjjWUUsruKDKzbXkC;
					max = VzxGbiSBvcyXKweXItYHtzZAOxs[i].WaWmAQSjzZptutkJCoSXBGQTjvN;
					zero = VzxGbiSBvcyXKweXItYHtzZAOxs[i].AYKGUeGuYDmHOPsqiAncIhHihBik;
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
			return rpcBnaQkBeUPWwOLPxpKaVpMgXK(vendorId, productId, productName);
		}

		private static bool rpcBnaQkBeUPWwOLPxpKaVpMgXK(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < VzxGbiSBvcyXKweXItYHtzZAOxs.Length; i++)
			{
				if (VzxGbiSBvcyXKweXItYHtzZAOxs[i].zSUwZcEfZtCbPbSzERXSEnlJlfzZ(P_0, P_1, P_2))
				{
					return true;
				}
			}
			return false;
		}

		private static sRGgZjsCSiDOYfdGIACAGKEpABf fgDOsvVHEBCntjrQRBJzDROqxjNA(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < VzxGbiSBvcyXKweXItYHtzZAOxs.Length; i++)
			{
				if (VzxGbiSBvcyXKweXItYHtzZAOxs[i].zSUwZcEfZtCbPbSzERXSEnlJlfzZ(P_0, P_1, P_2))
				{
					return VzxGbiSBvcyXKweXItYHtzZAOxs[i];
				}
			}
			return null;
		}
	}
}
