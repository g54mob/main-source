using System.IO;
using System.Text;

namespace UniGLTF.Zip
{
	internal class EOCD
	{
		public ushort NumberOfThisDisk;

		public ushort DiskWhereCentralDirectoryStarts;

		public ushort NumberOfCentralDirectoryRecordsOnThisDisk;

		public ushort TotalNumberOfCentralDirectoryRecords;

		public int SizeOfCentralDirectoryBytes;

		public int OffsetOfStartOfCentralDirectory;

		public string Comment;

		public override string ToString()
		{
			return $"<EOCD records: {NumberOfCentralDirectoryRecordsOnThisDisk}, offset: {OffsetOfStartOfCentralDirectory}, '{Comment}'>";
		}

		private static int FindEOCD(byte[] bytes)
		{
			for (int num = bytes.Length - 22; num >= 0; num--)
			{
				if (bytes[num] == 80 && bytes[num + 1] == 75 && bytes[num + 2] == 5 && bytes[num + 3] == 6)
				{
					return num;
				}
			}
			throw new ZipParseException("EOCD is not found");
		}

		public static EOCD Parse(byte[] bytes)
		{
			int num = FindEOCD(bytes);
			using MemoryStream input = new MemoryStream(bytes, num, bytes.Length - num, writable: false);
			using BinaryReader binaryReader = new BinaryReader(input);
			int num2 = binaryReader.ReadInt32();
			if (num2 != 101010256)
			{
				throw new ZipParseException("invalid eocd signature: " + num2);
			}
			EOCD obj = new EOCD
			{
				NumberOfThisDisk = binaryReader.ReadUInt16(),
				DiskWhereCentralDirectoryStarts = binaryReader.ReadUInt16(),
				NumberOfCentralDirectoryRecordsOnThisDisk = binaryReader.ReadUInt16(),
				TotalNumberOfCentralDirectoryRecords = binaryReader.ReadUInt16(),
				SizeOfCentralDirectoryBytes = binaryReader.ReadInt32(),
				OffsetOfStartOfCentralDirectory = binaryReader.ReadInt32()
			};
			ushort count = binaryReader.ReadUInt16();
			byte[] bytes2 = binaryReader.ReadBytes(count);
			obj.Comment = Encoding.ASCII.GetString(bytes2);
			return obj;
		}
	}
}
