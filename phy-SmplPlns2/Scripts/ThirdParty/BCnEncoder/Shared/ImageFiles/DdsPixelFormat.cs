namespace BCnEncoder.Shared.ImageFiles
{
	public struct DdsPixelFormat
	{
		public static readonly uint Dx10 = MakeFourCc('D', 'X', '1', '0');

		public static readonly uint Dxt1 = MakeFourCc('D', 'X', 'T', '1');

		public static readonly uint Dxt2 = MakeFourCc('D', 'X', 'T', '2');

		public static readonly uint Dxt3 = MakeFourCc('D', 'X', 'T', '3');

		public static readonly uint Dxt4 = MakeFourCc('D', 'X', 'T', '4');

		public static readonly uint Dxt5 = MakeFourCc('D', 'X', 'T', '5');

		public static readonly uint Ati1 = MakeFourCc('A', 'T', 'I', '1');

		public static readonly uint Ati2 = MakeFourCc('A', 'T', 'I', '2');

		public static readonly uint Atc = MakeFourCc('A', 'T', 'C', ' ');

		public static readonly uint Atci = MakeFourCc('A', 'T', 'C', 'I');

		public static readonly uint Atca = MakeFourCc('A', 'T', 'C', 'A');

		public static readonly uint Bc4S = MakeFourCc('B', 'C', '4', 'S');

		public static readonly uint Bc4U = MakeFourCc('B', 'C', '4', 'U');

		public static readonly uint Bc5S = MakeFourCc('B', 'C', '5', 'S');

		public static readonly uint Bc5U = MakeFourCc('B', 'C', '5', 'U');

		public uint dwSize;

		public PixelFormatFlags dwFlags;

		public uint dwFourCc;

		public uint dwRgbBitCount;

		public uint dwRBitMask;

		public uint dwGBitMask;

		public uint dwBBitMask;

		public uint dwABitMask;

		public DxgiFormat DxgiFormat
		{
			get
			{
				if (dwFlags.HasFlag(PixelFormatFlags.DdpfFourcc))
				{
					if (dwFourCc == Dxt1)
					{
						return DxgiFormat.DxgiFormatBc1Unorm;
					}
					if (dwFourCc == Dxt2 || dwFourCc == Dxt3)
					{
						return DxgiFormat.DxgiFormatBc2Unorm;
					}
					if (dwFourCc == Dxt4 || dwFourCc == Dxt5)
					{
						return DxgiFormat.DxgiFormatBc3Unorm;
					}
					if (dwFourCc == Ati1 || dwFourCc == Bc4S || dwFourCc == Bc4U)
					{
						return DxgiFormat.DxgiFormatBc4Unorm;
					}
					if (dwFourCc == Ati2 || dwFourCc == Bc5S || dwFourCc == Bc5U)
					{
						return DxgiFormat.DxgiFormatBc5Unorm;
					}
					if (dwFourCc == Atc)
					{
						return DxgiFormat.DxgiFormatAtcExt;
					}
					if (dwFourCc == Atci)
					{
						return DxgiFormat.DxgiFormatAtcExplicitAlphaExt;
					}
					if (dwFourCc == Atca)
					{
						return DxgiFormat.DxgiFormatAtcInterpolatedAlphaExt;
					}
				}
				else if (dwFlags.HasFlag(PixelFormatFlags.DdpfRgb))
				{
					if (dwFlags.HasFlag(PixelFormatFlags.DdpfAlphaPixels))
					{
						if (dwRgbBitCount == 32)
						{
							if (dwRBitMask == 255 && dwGBitMask == 65280 && dwBBitMask == 16711680 && dwABitMask == 4278190080u)
							{
								return DxgiFormat.DxgiFormatR8G8B8A8Unorm;
							}
							if (dwRBitMask == 16711680 && dwGBitMask == 65280 && dwBBitMask == 255 && dwABitMask == 4278190080u)
							{
								return DxgiFormat.DxgiFormatB8G8R8A8Unorm;
							}
						}
					}
					else if (dwRgbBitCount == 32 && dwRBitMask == 16711680 && dwGBitMask == 65280 && dwBBitMask == 255)
					{
						return DxgiFormat.DxgiFormatB8G8R8X8Unorm;
					}
				}
				else if (dwFlags.HasFlag(PixelFormatFlags.DdpfLuminance))
				{
					if (dwFlags.HasFlag(PixelFormatFlags.DdpfAlphaPixels))
					{
						if (dwRgbBitCount == 16 && dwRBitMask == 255 && dwGBitMask == 65280)
						{
							return DxgiFormat.DxgiFormatR8G8Unorm;
						}
					}
					else if (dwRgbBitCount == 8 && dwRBitMask == 255)
					{
						return DxgiFormat.DxgiFormatR8Unorm;
					}
				}
				return DxgiFormat.DxgiFormatUnknown;
			}
		}

		public bool IsDxt10Format
		{
			get
			{
				if ((dwFlags & PixelFormatFlags.DdpfFourcc) == PixelFormatFlags.DdpfFourcc)
				{
					return dwFourCc == Dx10;
				}
				return false;
			}
		}

		private static uint MakeFourCc(char c0, char c1, char c2, char c3)
		{
			return c0 | ((uint)c1 << 8) | ((uint)c2 << 16) | ((uint)c3 << 24);
		}
	}
}
