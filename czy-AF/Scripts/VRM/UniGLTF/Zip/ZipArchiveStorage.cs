using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace UniGLTF.Zip
{
	internal class ZipArchiveStorage : IStorage
	{
		public List<CentralDirectoryFileHeader> Entries = new List<CentralDirectoryFileHeader>();

		public override string ToString()
		{
			return string.Format("<ZIPArchive\n{0}>", string.Join("", Entries.Select((CentralDirectoryFileHeader x) => x.ToString() + "\n").ToArray()));
		}

		public static ZipArchiveStorage Parse(byte[] bytes)
		{
			EOCD eOCD = EOCD.Parse(bytes);
			ZipArchiveStorage zipArchiveStorage = new ZipArchiveStorage();
			int num = eOCD.OffsetOfStartOfCentralDirectory;
			for (int i = 0; i < eOCD.NumberOfCentralDirectoryRecordsOnThisDisk; i++)
			{
				CentralDirectoryFileHeader centralDirectoryFileHeader = new CentralDirectoryFileHeader(bytes, num);
				zipArchiveStorage.Entries.Add(centralDirectoryFileHeader);
				num += centralDirectoryFileHeader.Length;
			}
			return zipArchiveStorage;
		}

		public byte[] Extract(CentralDirectoryFileHeader header)
		{
			LocalFileHeader localFileHeader = new LocalFileHeader(header.Bytes, header.RelativeOffsetOfLocalFileHeader);
			int index = localFileHeader.Offset + localFileHeader.Length;
			byte[] array = new byte[localFileHeader.UncompressedSize];
			using MemoryStream stream = new MemoryStream(header.Bytes, index, localFileHeader.CompressedSize, writable: false);
			using DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress);
			int num = 0;
			int num2 = array.Length;
			while (num2 > 0)
			{
				int num3 = deflateStream.Read(array, num, num2);
				num += num3;
				num2 -= num3;
			}
			return array;
		}

		public string ExtractToString(CentralDirectoryFileHeader header, Encoding encoding)
		{
			LocalFileHeader localFileHeader = new LocalFileHeader(header.Bytes, header.RelativeOffsetOfLocalFileHeader);
			int index = localFileHeader.Offset + localFileHeader.Length;
			using MemoryStream stream = new MemoryStream(header.Bytes, index, localFileHeader.CompressedSize, writable: false);
			using DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
			using StreamReader streamReader = new StreamReader(stream2, encoding);
			return streamReader.ReadToEnd();
		}

		public ArraySegment<byte> Get(string url)
		{
			CentralDirectoryFileHeader centralDirectoryFileHeader = Entries.FirstOrDefault((CentralDirectoryFileHeader x) => x.FileName == url);
			if (centralDirectoryFileHeader == null)
			{
				throw new FileNotFoundException("[ZipArchive]" + url);
			}
			return centralDirectoryFileHeader.CompressionMethod switch
			{
				CompressionMethod.Deflated => new ArraySegment<byte>(Extract(centralDirectoryFileHeader)), 
				CompressionMethod.Stored => new ArraySegment<byte>(centralDirectoryFileHeader.Bytes, centralDirectoryFileHeader.RelativeOffsetOfLocalFileHeader, centralDirectoryFileHeader.CompressedSize), 
				_ => throw new NotImplementedException(centralDirectoryFileHeader.CompressionMethod.ToString()), 
			};
		}

		public string GetPath(string url)
		{
			return null;
		}
	}
}
