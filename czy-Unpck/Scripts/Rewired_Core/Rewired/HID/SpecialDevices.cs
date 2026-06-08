namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SpecialDevices
	{
		private class UtnKhwXgAJGWgNeWichOmDjXAoU
		{
			public readonly ushort LVhyNzNFybpcQeqlBtHhAycOnvD;

			public readonly ushort fkLtKGzJsvTUqlGdRyYQcjTaPmb;

			public readonly string CZmpngxIxIDLkiDLJjxhTXJrDnn;

			public readonly bool IhNuQldlbLPAZuANQUsjKcmmyEu;

			public readonly int bkEcbCFWAOfKJRLGsSamsynVktJ;

			public readonly int kptOJFpvbaqOcDJdeFBXzvXvWid;

			public readonly int oxdzyvJcYoNIsGsyQgSeTyuPDwH;

			public readonly float semlpLLirnIytafNMRzjQrOLWXU;

			public UtnKhwXgAJGWgNeWichOmDjXAoU(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
				while (true)
				{
					int num = -1311461037;
					while (true)
					{
						switch (num ^ -1311461039)
						{
						case 3:
							break;
						case 2:
						{
							LVhyNzNFybpcQeqlBtHhAycOnvD = vendorId;
							fkLtKGzJsvTUqlGdRyYQcjTaPmb = productId;
							int num2;
							if (!string.IsNullOrEmpty(productName))
							{
								num = -1311461039;
								num2 = num;
							}
							else
							{
								num = -1311461040;
								num2 = num;
							}
							continue;
						}
						case 1:
							productName = string.Empty;
							num = -1311461039;
							continue;
						default:
							CZmpngxIxIDLkiDLJjxhTXJrDnn = productName;
							IhNuQldlbLPAZuANQUsjKcmmyEu = hasRelativeAxes;
							bkEcbCFWAOfKJRLGsSamsynVktJ = axisMin;
							kptOJFpvbaqOcDJdeFBXzvXvWid = axisMax;
							oxdzyvJcYoNIsGsyQgSeTyuPDwH = axisZero;
							semlpLLirnIytafNMRzjQrOLWXU = relToAbsAxisConversionTimeout;
							return;
						}
						break;
					}
				}
			}

			public bool PthedzepHIAsxNsnmpwELRIzxSUG(ushort P_0, ushort P_1)
			{
				if (LVhyNzNFybpcQeqlBtHhAycOnvD == P_0)
				{
					return fkLtKGzJsvTUqlGdRyYQcjTaPmb == P_1;
				}
				return false;
			}

			public bool PthedzepHIAsxNsnmpwELRIzxSUG(ushort P_0, ushort P_1, string P_2)
			{
				if (LVhyNzNFybpcQeqlBtHhAycOnvD == P_0)
				{
					while (true)
					{
						int num = 188428505;
						while (true)
						{
							switch (num ^ 0xB3B30DB)
							{
							case 0:
								break;
							case 2:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (fkLtKGzJsvTUqlGdRyYQcjTaPmb != P_1)
							{
								num = 188428506;
								continue;
							}
							return true;
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				if (!string.IsNullOrEmpty(P_2))
				{
					return CZmpngxIxIDLkiDLJjxhTXJrDnn == P_2;
				}
				return false;
			}

			public bool PthedzepHIAsxNsnmpwELRIzxSUG(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return CZmpngxIxIDLkiDLJjxhTXJrDnn == P_0;
				}
				return false;
			}
		}

		private const float AqfVsLgCpYBPLXGIqXsHTfcIknu = 0.034f;

		private static UtnKhwXgAJGWgNeWichOmDjXAoU[] xAUPBjdmtNiCyGfBmUdLTCoiCzHE;

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return DEogSsqeYsOePFyWjtuvbNbIdYg(vendorId, productId, productName)?.IhNuQldlbLPAZuANQUsjKcmmyEu ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return DEogSsqeYsOePFyWjtuvbNbIdYg(vendorId, productId, productName)?.semlpLLirnIytafNMRzjQrOLWXU ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			int num = 0;
			while (true)
			{
				int num2 = 1587118731;
				while (true)
				{
					switch (num2 ^ 0x5E998288)
					{
					case 2:
						break;
					case 3:
						num2 = 1587118729;
						continue;
					case 4:
						return true;
					case 1:
						if (num >= xAUPBjdmtNiCyGfBmUdLTCoiCzHE.Length)
						{
							min = 0;
							max = 0;
							zero = 0;
							num2 = 1587118733;
							continue;
						}
						goto case 0;
					case 0:
						if (!xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].PthedzepHIAsxNsnmpwELRIzxSUG(vendorId, productId) || !xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].IhNuQldlbLPAZuANQUsjKcmmyEu)
						{
							num++;
							num2 = 1587118729;
							continue;
						}
						min = xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].bkEcbCFWAOfKJRLGsSamsynVktJ;
						max = xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].kptOJFpvbaqOcDJdeFBXzvXvWid;
						zero = xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].oxdzyvJcYoNIsGsyQgSeTyuPDwH;
						num2 = 1587118732;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return RVEdPgdgYFFlfUEJpQzfAcskRem(vendorId, productId, productName);
		}

		private static bool RVEdPgdgYFFlfUEJpQzfAcskRem(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (true)
			{
				int num2 = 473646923;
				while (true)
				{
					switch (num2 ^ 0x1C3B4748)
					{
					case 0:
						break;
					case 3:
						num2 = 473646921;
						continue;
					case 4:
						if (xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].PthedzepHIAsxNsnmpwELRIzxSUG(P_0, P_1, P_2))
						{
							return true;
						}
						num++;
						num2 = 473646921;
						continue;
					case 1:
					{
						int num3;
						if (num < xAUPBjdmtNiCyGfBmUdLTCoiCzHE.Length)
						{
							num2 = 473646924;
							num3 = num2;
						}
						else
						{
							num2 = 473646922;
							num3 = num2;
						}
						continue;
					}
					default:
						return false;
					}
					break;
				}
			}
		}

		private static UtnKhwXgAJGWgNeWichOmDjXAoU DEogSsqeYsOePFyWjtuvbNbIdYg(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (num < xAUPBjdmtNiCyGfBmUdLTCoiCzHE.Length)
			{
				while (true)
				{
					if (xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num].PthedzepHIAsxNsnmpwELRIzxSUG(P_0, P_1, P_2))
					{
						return xAUPBjdmtNiCyGfBmUdLTCoiCzHE[num];
					}
					num++;
					int num2 = -328841700;
					while (true)
					{
						switch (num2 ^ -328841698)
						{
						case 0:
							num2 = -328841697;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return null;
		}

		static SpecialDevices()
		{
			UtnKhwXgAJGWgNeWichOmDjXAoU[] array = new UtnKhwXgAJGWgNeWichOmDjXAoU[3];
			while (true)
			{
				int num = 397308428;
				while (true)
				{
					switch (num ^ 0x17AE720E)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						array[1] = new UtnKhwXgAJGWgNeWichOmDjXAoU(1133, 50728, "SpaceNavigator for Notebooks", hasRelativeAxes: true, -350, 350, 0, 0.034f);
						array[2] = new UtnKhwXgAJGWgNeWichOmDjXAoU(1133, 50727, "Space Explorer", hasRelativeAxes: true, -350, 350, 0, 0.034f);
						xAUPBjdmtNiCyGfBmUdLTCoiCzHE = array;
						return;
					}
					break;
					IL_0025:
					array[0] = new UtnKhwXgAJGWgNeWichOmDjXAoU(1133, 50726, "SpaceNavigator", hasRelativeAxes: true, -350, 350, 0, 0.034f);
					num = 397308431;
				}
			}
		}
	}
}
