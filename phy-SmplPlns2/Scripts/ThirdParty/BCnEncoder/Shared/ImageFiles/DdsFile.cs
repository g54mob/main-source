using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BCnEncoder.Shared.ImageFiles
{
	public class DdsFile
	{
		public DdsHeader header;

		public DdsHeaderDx10 dx10Header;

		public List<DdsFace> Faces { get; } = new List<DdsFace>();

		public DdsFile()
		{
		}

		public DdsFile(DdsHeader header)
		{
			this.header = header;
		}

		public DdsFile(DdsHeader header, DdsHeaderDx10 dx10Header)
		{
			this.header = header;
			this.dx10Header = dx10Header;
		}

		public static DdsFile Load(Stream s)
		{
			using BinaryReader binaryReader = new BinaryReader(s, Encoding.UTF8, leaveOpen: true);
			if (binaryReader.ReadUInt32() != 542327876)
			{
				throw new FormatException("The file does not contain a dds file.");
			}
			DdsHeader ddsHeader = binaryReader.ReadStruct<DdsHeader>();
			DdsHeaderDx10 ddsHeaderDx = default(DdsHeaderDx10);
			if (ddsHeader.dwSize != 124)
			{
				throw new FormatException("The file header contains invalid dwSize.");
			}
			bool isDxt10Format = ddsHeader.ddsPixelFormat.IsDxt10Format;
			DdsFile ddsFile;
			if (isDxt10Format)
			{
				ddsHeaderDx = binaryReader.ReadStruct<DdsHeaderDx10>();
				ddsFile = new DdsFile(ddsHeader, ddsHeaderDx);
			}
			else
			{
				ddsFile = new DdsFile(ddsHeader);
			}
			uint num = (((ddsHeader.dwCaps & HeaderCaps.DdscapsMipmap) == 0) ? 1u : ddsHeader.dwMipMapCount);
			uint num2 = (((ddsHeader.dwCaps2 & HeaderCaps2.Ddscaps2Cubemap) == 0) ? 1u : 6u);
			uint dwWidth = ddsHeader.dwWidth;
			uint dwHeight = ddsHeader.dwHeight;
			for (int i = 0; i < num2; i++)
			{
				DxgiFormat format = (isDxt10Format ? ddsHeaderDx.dxgiFormat : ddsHeader.ddsPixelFormat.DxgiFormat);
				uint sizeInBytes = GetSizeInBytes(format, dwWidth, dwHeight);
				ddsFile.Faces.Add(new DdsFace(dwWidth, dwHeight, sizeInBytes, (int)num));
				for (int j = 0; j < num; j++)
				{
					MipMapper.CalculateMipLevelSize((int)ddsHeader.dwWidth, (int)ddsHeader.dwHeight, j, out var mipWidth, out var mipHeight);
					if (j > 0)
					{
						sizeInBytes = GetSizeInBytes(format, (uint)mipWidth, (uint)mipHeight);
					}
					byte[] array = new byte[sizeInBytes];
					binaryReader.Read(array);
					ddsFile.Faces[i].MipMaps[j] = new DdsMipMap(array, (uint)mipWidth, (uint)mipHeight);
				}
			}
			return ddsFile;
		}

		public void Write(Stream outputStream)
		{
			if (Faces.Count < 1 || Faces[0].MipMaps.Length < 1)
			{
				throw new InvalidOperationException("The DDS structure should have at least 1 mipmap level and 1 Face before writing to file.");
			}
			header.dwFlags |= HeaderFlags.Required;
			header.dwMipMapCount = (uint)Faces[0].MipMaps.Length;
			if (header.dwMipMapCount > 1)
			{
				header.dwCaps |= HeaderCaps.DdscapsComplex | HeaderCaps.DdscapsMipmap;
			}
			if (Faces.Count == 6)
			{
				header.dwCaps |= HeaderCaps.DdscapsComplex;
				header.dwCaps2 |= HeaderCaps2.Ddscaps2Cubemap | HeaderCaps2.Ddscaps2CubemapPositivex | HeaderCaps2.Ddscaps2CubemapNegativex | HeaderCaps2.Ddscaps2CubemapPositivey | HeaderCaps2.Ddscaps2CubemapNegativey | HeaderCaps2.Ddscaps2CubemapPositivez | HeaderCaps2.Ddscaps2CubemapNegativez;
			}
			header.dwWidth = Faces[0].Width;
			header.dwHeight = Faces[0].Height;
			for (int i = 0; i < Faces.Count; i++)
			{
				if (Faces[i].Width != header.dwWidth || Faces[i].Height != header.dwHeight)
				{
					throw new InvalidOperationException("Faces with different sizes are not supported.");
				}
			}
			int count = Faces.Count;
			int dwMipMapCount = (int)header.dwMipMapCount;
			using BinaryWriter binaryWriter = new BinaryWriter(outputStream, Encoding.UTF8, leaveOpen: true);
			binaryWriter.Write(542327876u);
			binaryWriter.WriteStruct(header);
			if (header.ddsPixelFormat.IsDxt10Format)
			{
				binaryWriter.WriteStruct(dx10Header);
			}
			for (int j = 0; j < count; j++)
			{
				for (int k = 0; k < dwMipMapCount; k++)
				{
					binaryWriter.Write(Faces[j].MipMaps[k].Data);
				}
			}
		}

		private static uint GetSizeInBytes(DxgiFormat format, uint width, uint height)
		{
			uint num;
			if (format.IsCompressedFormat())
			{
				num = (uint)ImageToBlocks.CalculateNumOfBlocks((int)width, (int)height);
				return num * (uint)format.GetByteSize();
			}
			num = width * height;
			return (uint)(num * format.GetByteSize());
		}
	}
}
