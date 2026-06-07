using System;

namespace BCnEncoder.Shared.ImageFiles
{
	public struct DdsHeader
	{
		public uint dwSize;

		public HeaderFlags dwFlags;

		public uint dwHeight;

		public uint dwWidth;

		public uint dwPitchOrLinearSize;

		public uint dwDepth;

		public uint dwMipMapCount;

		public unsafe fixed uint dwReserved1[11];

		public DdsPixelFormat ddsPixelFormat;

		public HeaderCaps dwCaps;

		public HeaderCaps2 dwCaps2;

		public uint dwCaps3;

		public uint dwCaps4;

		public uint dwReserved2;

		public static (DdsHeader, DdsHeaderDx10) InitializeCompressed(int width, int height, DxgiFormat format, bool preferDxt10Header)
		{
			DdsHeader item = default(DdsHeader);
			DdsHeaderDx10 item2 = default(DdsHeaderDx10);
			item.dwSize = 124u;
			item.dwFlags = HeaderFlags.Required;
			item.dwWidth = (uint)width;
			item.dwHeight = (uint)height;
			item.dwDepth = 1u;
			item.dwMipMapCount = 1u;
			item.dwCaps = HeaderCaps.DdscapsTexture;
			if (preferDxt10Header)
			{
				switch (format)
				{
				case DxgiFormat.DxgiFormatAtcExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atc
					};
					break;
				case DxgiFormat.DxgiFormatAtcExplicitAlphaExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atci
					};
					break;
				case DxgiFormat.DxgiFormatAtcInterpolatedAlphaExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atca
					};
					break;
				default:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Dx10
					};
					item2.arraySize = 1u;
					item2.dxgiFormat = format;
					item2.resourceDimension = D3D10ResourceDimension.D3D10ResourceDimensionTexture2D;
					break;
				}
			}
			else
			{
				switch (format)
				{
				case DxgiFormat.DxgiFormatBc1Unorm:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Dxt1
					};
					break;
				case DxgiFormat.DxgiFormatBc2Unorm:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Dxt3
					};
					break;
				case DxgiFormat.DxgiFormatBc3Unorm:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Dxt5
					};
					break;
				case DxgiFormat.DxgiFormatBc4Unorm:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Bc4U
					};
					break;
				case DxgiFormat.DxgiFormatBc5Unorm:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Ati2
					};
					break;
				case DxgiFormat.DxgiFormatAtcExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atc
					};
					break;
				case DxgiFormat.DxgiFormatAtcExplicitAlphaExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atci
					};
					break;
				case DxgiFormat.DxgiFormatAtcInterpolatedAlphaExt:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Atca
					};
					break;
				default:
					item.ddsPixelFormat = new DdsPixelFormat
					{
						dwSize = 32u,
						dwFlags = PixelFormatFlags.DdpfFourcc,
						dwFourCc = DdsPixelFormat.Dx10
					};
					item2.arraySize = 1u;
					item2.dxgiFormat = format;
					item2.resourceDimension = D3D10ResourceDimension.D3D10ResourceDimensionTexture2D;
					break;
				}
			}
			return (item, item2);
		}

		public static DdsHeader InitializeUncompressed(int width, int height, DxgiFormat format)
		{
			DdsHeader result = new DdsHeader
			{
				dwSize = 124u,
				dwFlags = (HeaderFlags.Required | HeaderFlags.DdsdPitch),
				dwWidth = (uint)width,
				dwHeight = (uint)height,
				dwDepth = 1u,
				dwMipMapCount = 1u,
				dwCaps = HeaderCaps.DdscapsTexture
			};
			switch (format)
			{
			case DxgiFormat.DxgiFormatR8Unorm:
				result.ddsPixelFormat = new DdsPixelFormat
				{
					dwSize = 32u,
					dwFlags = PixelFormatFlags.DdpfLuminance,
					dwRgbBitCount = 8u,
					dwRBitMask = 255u
				};
				result.dwPitchOrLinearSize = (uint)((width * 8 + 7) / 8);
				break;
			case DxgiFormat.DxgiFormatR8G8Unorm:
				result.ddsPixelFormat = new DdsPixelFormat
				{
					dwSize = 32u,
					dwFlags = (PixelFormatFlags.DdpfAlphaPixels | PixelFormatFlags.DdpfLuminance),
					dwRgbBitCount = 16u,
					dwRBitMask = 255u,
					dwGBitMask = 65280u
				};
				result.dwPitchOrLinearSize = (uint)((width * 16 + 7) / 8);
				break;
			case DxgiFormat.DxgiFormatR8G8B8A8Unorm:
				result.ddsPixelFormat = new DdsPixelFormat
				{
					dwSize = 32u,
					dwFlags = (PixelFormatFlags.DdpfAlphaPixels | PixelFormatFlags.DdpfRgb),
					dwRgbBitCount = 32u,
					dwRBitMask = 255u,
					dwGBitMask = 65280u,
					dwBBitMask = 16711680u,
					dwABitMask = 4278190080u
				};
				result.dwPitchOrLinearSize = (uint)((width * 32 + 7) / 8);
				break;
			case DxgiFormat.DxgiFormatB8G8R8A8Unorm:
				result.ddsPixelFormat = new DdsPixelFormat
				{
					dwSize = 32u,
					dwFlags = (PixelFormatFlags.DdpfAlphaPixels | PixelFormatFlags.DdpfRgb),
					dwRgbBitCount = 32u,
					dwRBitMask = 16711680u,
					dwGBitMask = 65280u,
					dwBBitMask = 255u,
					dwABitMask = 4278190080u
				};
				result.dwPitchOrLinearSize = (uint)((width * 32 + 7) / 8);
				break;
			default:
				throw new NotImplementedException("This Format is not implemented in this method");
			}
			return result;
		}
	}
}
