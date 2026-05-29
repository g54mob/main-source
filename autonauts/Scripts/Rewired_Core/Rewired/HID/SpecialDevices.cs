namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SpecialDevices
	{
		private class txxLtjzOjVFtzmyzhWqDcgPIbod
		{
			public readonly ushort aTbsowlFdtdDNHGQGyHgAISJkkq;

			public readonly ushort MBlnXHlBnwRpMqEKOvVoilzgzEB;

			public readonly string fYmnAzFaACyKxFIaQOUmJybepQY;

			public readonly bool doPBXmdBYXpWEBRyHXtmAIKfjtBc;

			public readonly int CjIFLDxrhEDqQqRlfVbjmNLUHbe;

			public readonly int BgvvxMZwSwmhXqDszzaGjsFiJHL;

			public readonly int BvjBJuvnfcLyhpNsBdjrLARYvej;

			public readonly float NiomYQldGfvleHJwFGUwSMmMBIhA;

			public txxLtjzOjVFtzmyzhWqDcgPIbod(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
				aTbsowlFdtdDNHGQGyHgAISJkkq = vendorId;
				MBlnXHlBnwRpMqEKOvVoilzgzEB = productId;
				if (string.IsNullOrEmpty(productName))
				{
					productName = string.Empty;
				}
				fYmnAzFaACyKxFIaQOUmJybepQY = productName;
				doPBXmdBYXpWEBRyHXtmAIKfjtBc = hasRelativeAxes;
				CjIFLDxrhEDqQqRlfVbjmNLUHbe = axisMin;
				BgvvxMZwSwmhXqDszzaGjsFiJHL = axisMax;
				BvjBJuvnfcLyhpNsBdjrLARYvej = axisZero;
				NiomYQldGfvleHJwFGUwSMmMBIhA = relToAbsAxisConversionTimeout;
			}

			public bool arrMdwNAiKxdqFvQxTSVVmqyTnz(ushort P_0, ushort P_1)
			{
				if (aTbsowlFdtdDNHGQGyHgAISJkkq == P_0)
				{
					return MBlnXHlBnwRpMqEKOvVoilzgzEB == P_1;
				}
				return false;
			}

			public bool arrMdwNAiKxdqFvQxTSVVmqyTnz(ushort P_0, ushort P_1, string P_2)
			{
				if (aTbsowlFdtdDNHGQGyHgAISJkkq != P_0 || MBlnXHlBnwRpMqEKOvVoilzgzEB != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return fYmnAzFaACyKxFIaQOUmJybepQY == P_2;
					}
					return false;
				}
				return true;
			}

			public bool arrMdwNAiKxdqFvQxTSVVmqyTnz(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return fYmnAzFaACyKxFIaQOUmJybepQY == P_0;
				}
				return false;
			}
		}

		private const float hsvGwEDSYUSSAIexhycUkRUPmwZM = 0.034f;

		private static txxLtjzOjVFtzmyzhWqDcgPIbod[] UWUetyHwCLVOjtyqlKgUPDUbkua = new txxLtjzOjVFtzmyzhWqDcgPIbod[3]
		{
			new txxLtjzOjVFtzmyzhWqDcgPIbod(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
			new txxLtjzOjVFtzmyzhWqDcgPIbod(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
			new txxLtjzOjVFtzmyzhWqDcgPIbod(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			txxLtjzOjVFtzmyzhWqDcgPIbod txxLtjzOjVFtzmyzhWqDcgPIbod2 = iAwbjnMsvstCGmupoRNutjXHFPH(vendorId, productId, productName);
			if (txxLtjzOjVFtzmyzhWqDcgPIbod2 == null)
			{
				return false;
			}
			return txxLtjzOjVFtzmyzhWqDcgPIbod2.doPBXmdBYXpWEBRyHXtmAIKfjtBc;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			txxLtjzOjVFtzmyzhWqDcgPIbod txxLtjzOjVFtzmyzhWqDcgPIbod2 = iAwbjnMsvstCGmupoRNutjXHFPH(vendorId, productId, productName);
			if (txxLtjzOjVFtzmyzhWqDcgPIbod2 == null)
			{
				return 0f;
			}
			return txxLtjzOjVFtzmyzhWqDcgPIbod2.NiomYQldGfvleHJwFGUwSMmMBIhA;
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
				int num2 = -1102403005;
				while (true)
				{
					switch (num2 ^ -1102403001)
					{
					case 3:
						break;
					case 6:
						max = 0;
						num2 = -1102403008;
						continue;
					case 1:
						if (UWUetyHwCLVOjtyqlKgUPDUbkua[num].arrMdwNAiKxdqFvQxTSVVmqyTnz(vendorId, productId) && UWUetyHwCLVOjtyqlKgUPDUbkua[num].doPBXmdBYXpWEBRyHXtmAIKfjtBc)
						{
							min = UWUetyHwCLVOjtyqlKgUPDUbkua[num].CjIFLDxrhEDqQqRlfVbjmNLUHbe;
							num2 = -1102403001;
						}
						else
						{
							num++;
							num2 = -1102403006;
						}
						continue;
					case 4:
						num2 = -1102403006;
						continue;
					case 0:
						max = UWUetyHwCLVOjtyqlKgUPDUbkua[num].BgvvxMZwSwmhXqDszzaGjsFiJHL;
						zero = UWUetyHwCLVOjtyqlKgUPDUbkua[num].BvjBJuvnfcLyhpNsBdjrLARYvej;
						return true;
					case 5:
					{
						int num3;
						if (num >= UWUetyHwCLVOjtyqlKgUPDUbkua.Length)
						{
							num2 = -1102403003;
							num3 = num2;
						}
						else
						{
							num2 = -1102403002;
							num3 = num2;
						}
						continue;
					}
					case 2:
						min = 0;
						num2 = -1102403007;
						continue;
					default:
						zero = 0;
						return false;
					}
					break;
				}
			}
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return wCWcGtKZNPZQgNxzcoliHYOxKWBa(vendorId, productId, productName);
		}

		private static bool wCWcGtKZNPZQgNxzcoliHYOxKWBa(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (num < UWUetyHwCLVOjtyqlKgUPDUbkua.Length)
			{
				while (true)
				{
					int num2;
					if (UWUetyHwCLVOjtyqlKgUPDUbkua[num].arrMdwNAiKxdqFvQxTSVVmqyTnz(P_0, P_1, P_2))
					{
						num2 = 464855607;
					}
					else
					{
						num++;
						num2 = 464855604;
					}
					while (true)
					{
						switch (num2 ^ 0x1BB52237)
						{
						case 2:
							num2 = 464855606;
							continue;
						case 1:
							break;
						case 0:
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

		private static txxLtjzOjVFtzmyzhWqDcgPIbod iAwbjnMsvstCGmupoRNutjXHFPH(ushort P_0, ushort P_1, string P_2 = null)
		{
			int num = 0;
			while (num < UWUetyHwCLVOjtyqlKgUPDUbkua.Length)
			{
				while (true)
				{
					if (UWUetyHwCLVOjtyqlKgUPDUbkua[num].arrMdwNAiKxdqFvQxTSVVmqyTnz(P_0, P_1, P_2))
					{
						return UWUetyHwCLVOjtyqlKgUPDUbkua[num];
					}
					num++;
					int num2 = -951138872;
					while (true)
					{
						switch (num2 ^ -951138870)
						{
						case 0:
							num2 = -951138869;
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
