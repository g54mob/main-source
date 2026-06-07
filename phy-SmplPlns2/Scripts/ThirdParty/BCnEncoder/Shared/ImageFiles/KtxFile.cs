using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BCnEncoder.Shared.ImageFiles
{
	public class KtxFile
	{
		public KtxHeader header;

		public List<KtxKeyValuePair> KeyValuePairs { get; } = new List<KtxKeyValuePair>();

		public List<KtxMipmap> MipMaps { get; } = new List<KtxMipmap>();

		public KtxFile()
		{
		}

		public KtxFile(KtxHeader header)
		{
			this.header = header;
		}

		public void Write(Stream s)
		{
			if (MipMaps.Count < 1 || MipMaps[0].NumberOfFaces < 1)
			{
				throw new InvalidOperationException("The KTX structure should have at least 1 mipmap level and 1 Face before writing to file.");
			}
			using BinaryWriter binaryWriter = new BinaryWriter(s, Encoding.UTF8, leaveOpen: true);
			uint bytesOfKeyValueData = (uint)KeyValuePairs.Sum((KtxKeyValuePair x) => x.GetSizeWithPadding());
			header.BytesOfKeyValueData = bytesOfKeyValueData;
			header.NumberOfFaces = MipMaps[0].NumberOfFaces;
			header.NumberOfMipmapLevels = (uint)MipMaps.Count;
			header.NumberOfArrayElements = 0u;
			if (!header.VerifyHeader())
			{
				throw new InvalidOperationException("Please verify the header validity before writing to file.");
			}
			binaryWriter.WriteStruct(header);
			foreach (KtxKeyValuePair keyValuePair in KeyValuePairs)
			{
				KtxKeyValuePair.WriteKeyValuePair(binaryWriter, keyValuePair);
			}
			for (int num = 0; num < header.NumberOfMipmapLevels; num++)
			{
				uint sizeInBytes = MipMaps[num].SizeInBytes;
				binaryWriter.Write(sizeInBytes);
				bool flag = header.NumberOfFaces == 6 && header.NumberOfArrayElements == 0;
				for (int num2 = 0; num2 < header.NumberOfFaces; num2++)
				{
					binaryWriter.Write(MipMaps[num].Faces[num2].Data);
					uint padding = 0u;
					if (flag)
					{
						padding = 3 - (sizeInBytes + 3) % 4;
					}
					binaryWriter.AddPadding(padding);
				}
				uint padding2 = 3 - (sizeInBytes + 3) % 4;
				binaryWriter.AddPadding(padding2);
			}
		}

		public static KtxFile Load(Stream s)
		{
			using BinaryReader binaryReader = new BinaryReader(s, Encoding.UTF8, leaveOpen: true);
			KtxHeader ktxHeader = binaryReader.ReadStruct<KtxHeader>();
			if (ktxHeader.NumberOfArrayElements != 0)
			{
				throw new NotSupportedException("KTX files with arrays are not supported.");
			}
			KtxFile ktxFile = new KtxFile(ktxHeader);
			int num = 0;
			while (num < ktxHeader.BytesOfKeyValueData)
			{
				int bytesRead;
				KtxKeyValuePair item = KtxKeyValuePair.ReadKeyValuePair(binaryReader, out bytesRead);
				num += bytesRead;
				ktxFile.KeyValuePairs.Add(item);
			}
			uint num2 = Math.Max(1u, ktxHeader.NumberOfFaces);
			ktxFile.MipMaps.Capacity = (int)ktxHeader.NumberOfMipmapLevels;
			for (uint num3 = 0u; num3 < ktxHeader.NumberOfMipmapLevels; num3++)
			{
				uint num4 = binaryReader.ReadUInt32();
				uint width = ktxHeader.PixelWidth / (uint)Math.Pow(2.0, num3);
				uint height = ktxHeader.PixelHeight / (uint)Math.Pow(2.0, num3);
				ktxFile.MipMaps.Add(new KtxMipmap(num4, width, height, num2));
				bool flag = ktxHeader.NumberOfFaces > 1 && ktxHeader.NumberOfArrayElements == 0;
				for (uint num5 = 0u; num5 < num2; num5++)
				{
					byte[] data = binaryReader.ReadBytes((int)num4);
					ktxFile.MipMaps[(int)num3].Faces[num5] = new KtxMipFace(data, width, height);
					if (flag)
					{
						uint num6 = 0u;
						num6 = 3 - (num4 + 3) % 4;
						binaryReader.SkipPadding(num6);
					}
				}
				uint padding = 3 - (num4 + 3) % 4;
				binaryReader.SkipPadding(padding);
			}
			return ktxFile;
		}

		public ulong GetTotalSize()
		{
			ulong num = 0uL;
			for (int i = 0; i < header.NumberOfMipmapLevels; i++)
			{
				for (int j = 0; j < header.NumberOfFaces; j++)
				{
					KtxMipFace ktxMipFace = MipMaps[i].Faces[j];
					num += ktxMipFace.SizeInBytes;
				}
			}
			return num;
		}

		public byte[] GetAllTextureDataFaceMajor()
		{
			byte[] array = new byte[GetTotalSize()];
			uint num = 0u;
			for (int i = 0; i < header.NumberOfFaces; i++)
			{
				for (int j = 0; j < header.NumberOfMipmapLevels; j++)
				{
					KtxMipFace ktxMipFace = MipMaps[j].Faces[i];
					ktxMipFace.Data.CopyTo(array, (int)num);
					num += ktxMipFace.SizeInBytes;
				}
			}
			return array;
		}

		public byte[] GetAllTextureDataMipMajor()
		{
			byte[] array = new byte[GetTotalSize()];
			uint num = 0u;
			for (int i = 0; i < header.NumberOfMipmapLevels; i++)
			{
				for (int j = 0; j < header.NumberOfFaces; j++)
				{
					KtxMipFace ktxMipFace = MipMaps[i].Faces[j];
					ktxMipFace.Data.CopyTo(array, (int)num);
					num += ktxMipFace.SizeInBytes;
				}
			}
			return array;
		}
	}
}
