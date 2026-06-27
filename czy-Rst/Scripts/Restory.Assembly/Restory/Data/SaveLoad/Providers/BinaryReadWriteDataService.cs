using System;
using System.IO;
using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Providers
{
	public class BinaryReadWriteDataService : IFileReadWriteBinaryDataService
	{
		public const string FileExtension = ".restory";

		public const string TempFileExtension = ".tmp";

		private const int BufferSize = 1048576;

		public bool IsSupported(string fullPath)
		{
			string extension = Path.GetExtension(fullPath);
			if (!string.Equals(extension, ".restory", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(extension, ".tmp", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		public async Task WriteAsync(byte[] binaryData, string fullPath)
		{
			await using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1048576, FileOptions.WriteThrough | FileOptions.SequentialScan);
			await fileStream.WriteAsync(binaryData, 0, binaryData.Length);
			await fileStream.FlushAsync();
		}

		public async Task<byte[]> ReadAsync(string fullPath)
		{
			FileInfo fileInfo = new FileInfo(fullPath);
			int fileSize = (int)fileInfo.Length;
			byte[] buffer = new byte[fileSize];
			byte[] result;
			await using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576, FileOptions.SequentialScan))
			{
				int num;
				for (int totalBytesRead = 0; totalBytesRead < fileSize; totalBytesRead += num)
				{
					num = await fileStream.ReadAsync(buffer, totalBytesRead, fileSize - totalBytesRead);
					if (num == 0)
					{
						throw new EndOfStreamException($"Unexpected end of file. Expected {fileSize} bytes, but only read {totalBytesRead} bytes.");
					}
				}
				result = buffer;
			}
			return result;
		}
	}
}
