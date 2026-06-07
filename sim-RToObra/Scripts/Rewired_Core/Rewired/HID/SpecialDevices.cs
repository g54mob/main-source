namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SpecialDevices
	{
		private class YihhqmRUvNaaOMUsLbSJPzNOTya
		{
			public readonly ushort NdbvKbBBJrSYqhcLkswavvMBjSd;

			public readonly ushort dUFmmEnRQtqCUuTnapnLPxMpqTR;

			public readonly string ElqFHgfeUUYnOxTfelQmyaxwbDRH;

			public readonly bool WZLuWjtcITrbfbfffMpyrOMjGqYE;

			public readonly int hAMpIKTsnADLjYzyTRfnHpNUfuv;

			public readonly int aFfAoLGdYiGQyrSnDncKGWToFMEE;

			public readonly int kejQupRfjceGIPNEdnJfeHCGwsv;

			public readonly float uDuhXPHeMvuOLpolrfQodKuKBJqI;

			public YihhqmRUvNaaOMUsLbSJPzNOTya(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
				NdbvKbBBJrSYqhcLkswavvMBjSd = vendorId;
				dUFmmEnRQtqCUuTnapnLPxMpqTR = productId;
				if (string.IsNullOrEmpty(productName))
				{
					productName = string.Empty;
				}
				ElqFHgfeUUYnOxTfelQmyaxwbDRH = productName;
				WZLuWjtcITrbfbfffMpyrOMjGqYE = hasRelativeAxes;
				hAMpIKTsnADLjYzyTRfnHpNUfuv = axisMin;
				aFfAoLGdYiGQyrSnDncKGWToFMEE = axisMax;
				kejQupRfjceGIPNEdnJfeHCGwsv = axisZero;
				uDuhXPHeMvuOLpolrfQodKuKBJqI = relToAbsAxisConversionTimeout;
			}

			public bool DmlNEhzmzUCVUnDgXReTiclcUGs(ushort P_0, ushort P_1)
			{
				if (NdbvKbBBJrSYqhcLkswavvMBjSd == P_0)
				{
					return dUFmmEnRQtqCUuTnapnLPxMpqTR == P_1;
				}
				return false;
			}

			public bool DmlNEhzmzUCVUnDgXReTiclcUGs(ushort P_0, ushort P_1, string P_2)
			{
				if (NdbvKbBBJrSYqhcLkswavvMBjSd == P_0)
				{
					while (true)
					{
						int num = -627055955;
						while (true)
						{
							switch (num ^ -627055956)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								goto end_IL_0009;
							}
							break;
							IL_0027:
							if (dUFmmEnRQtqCUuTnapnLPxMpqTR != P_1)
							{
								num = -627055956;
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
					return ElqFHgfeUUYnOxTfelQmyaxwbDRH == P_2;
				}
				return false;
			}

			public bool DmlNEhzmzUCVUnDgXReTiclcUGs(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return ElqFHgfeUUYnOxTfelQmyaxwbDRH == P_0;
				}
				return false;
			}
		}

		private const float UvfxtTwLQQSttCwcXLaKaFCRbtQg = 0.034f;

		private static YihhqmRUvNaaOMUsLbSJPzNOTya[] xMWfUfpqOFuHOFbzPEWMoXUvInx = new YihhqmRUvNaaOMUsLbSJPzNOTya[3]
		{
			new YihhqmRUvNaaOMUsLbSJPzNOTya(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
			new YihhqmRUvNaaOMUsLbSJPzNOTya(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
			new YihhqmRUvNaaOMUsLbSJPzNOTya(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			YihhqmRUvNaaOMUsLbSJPzNOTya yihhqmRUvNaaOMUsLbSJPzNOTya = BfyeHowHhyBGbCryYEFcdGRNbKSI(vendorId, productId, productName);
			if (yihhqmRUvNaaOMUsLbSJPzNOTya == null)
			{
				return false;
			}
			return yihhqmRUvNaaOMUsLbSJPzNOTya.WZLuWjtcITrbfbfffMpyrOMjGqYE;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			YihhqmRUvNaaOMUsLbSJPzNOTya yihhqmRUvNaaOMUsLbSJPzNOTya = BfyeHowHhyBGbCryYEFcdGRNbKSI(vendorId, productId, productName);
			if (yihhqmRUvNaaOMUsLbSJPzNOTya == null)
			{
				return 0f;
			}
			return yihhqmRUvNaaOMUsLbSJPzNOTya.uDuhXPHeMvuOLpolrfQodKuKBJqI;
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
				IL_00aa:
				int num2;
				if (num >= xMWfUfpqOFuHOFbzPEWMoXUvInx.Length)
				{
					min = 0;
					num2 = -1164074142;
					goto IL_000c;
				}
				goto IL_0090;
				IL_0049:
				num++;
				num2 = -1164074144;
				goto IL_000c;
				IL_0090:
				if (xMWfUfpqOFuHOFbzPEWMoXUvInx[num].DmlNEhzmzUCVUnDgXReTiclcUGs(vendorId, productId))
				{
					num2 = -1164074140;
					goto IL_000c;
				}
				goto IL_0049;
				IL_000c:
				while (true)
				{
					switch (num2 ^ -1164074143)
					{
					case 0:
						num2 = -1164074137;
						continue;
					case 4:
						zero = xMWfUfpqOFuHOFbzPEWMoXUvInx[num].kejQupRfjceGIPNEdnJfeHCGwsv;
						return true;
					case 2:
						max = xMWfUfpqOFuHOFbzPEWMoXUvInx[num].aFfAoLGdYiGQyrSnDncKGWToFMEE;
						num2 = -1164074139;
						continue;
					case 5:
						break;
					case 6:
						goto end_IL_000c;
					case 1:
						goto IL_00aa;
					default:
						max = 0;
						zero = 0;
						return false;
					}
					if (xMWfUfpqOFuHOFbzPEWMoXUvInx[num].WZLuWjtcITrbfbfffMpyrOMjGqYE)
					{
						min = xMWfUfpqOFuHOFbzPEWMoXUvInx[num].hAMpIKTsnADLjYzyTRfnHpNUfuv;
						num2 = -1164074141;
						continue;
					}
					goto IL_0049;
					continue;
					end_IL_000c:
					break;
				}
				goto IL_0090;
			}
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return TlQsLyrkJJepXBBeCHdcFrAgvHAQ(vendorId, productId, productName);
		}

		private static bool TlQsLyrkJJepXBBeCHdcFrAgvHAQ(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (num < xMWfUfpqOFuHOFbzPEWMoXUvInx.Length)
			{
				while (true)
				{
					int num2;
					if (xMWfUfpqOFuHOFbzPEWMoXUvInx[num].DmlNEhzmzUCVUnDgXReTiclcUGs(P_0, P_1, P_2))
					{
						num2 = -529222986;
					}
					else
					{
						num++;
						num2 = -529222987;
					}
					while (true)
					{
						switch (num2 ^ -529222988)
						{
						case 0:
							num2 = -529222985;
							continue;
						case 3:
							break;
						case 2:
							return true;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
			return false;
		}

		private static YihhqmRUvNaaOMUsLbSJPzNOTya BfyeHowHhyBGbCryYEFcdGRNbKSI(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (num < xMWfUfpqOFuHOFbzPEWMoXUvInx.Length)
			{
				while (true)
				{
					if (xMWfUfpqOFuHOFbzPEWMoXUvInx[num].DmlNEhzmzUCVUnDgXReTiclcUGs(P_0, P_1, P_2))
					{
						return xMWfUfpqOFuHOFbzPEWMoXUvInx[num];
					}
					num++;
					int num2 = -733897937;
					while (true)
					{
						switch (num2 ^ -733897937)
						{
						case 2:
							num2 = -733897938;
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
	}
}
