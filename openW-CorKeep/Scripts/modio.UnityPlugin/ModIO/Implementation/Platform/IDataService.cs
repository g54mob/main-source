using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModIO.Implementation.Platform
{
	internal interface IDataService
	{
		string RootDirectory { get; }

		ModIOFileStream OpenReadStream(string filePath, out Result result);

		ModIOFileStream OpenWriteStream(string filePath, out Result result);

		Task<ResultAnd<byte[]>> ReadFileAsync(string filePath);

		ResultAnd<byte[]> ReadFile(string filePath);

		Task<Result> WriteFileAsync(string filePath, byte[] data);

		Result WriteFile(string filePath, byte[] data);

		Result DeleteDirectory(string directoryPath);

		Result DeleteFile(string filePath);

		Result MoveDirectory(string directoryPath, string newDirectoryPath);

		bool TryCreateParentDirectory(string directoryPath);

		bool FileExists(string filePath);

		Result GetFileSizeAndHash(string filePath, out long fileWithSize, out string fileHash);

		bool DirectoryExists(string directoryPath);

		ResultAnd<List<string>> ListAllFiles(string directoryPath);

		Task<bool> IsThereEnoughDiskSpaceFor(long numberOfBytes);
	}
}
