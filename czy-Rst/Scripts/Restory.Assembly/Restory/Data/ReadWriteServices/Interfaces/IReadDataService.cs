using System;
using System.Threading.Tasks;
using Restory.Data.Locations;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IReadDataService
	{
		event Action<FileType> OnReadBegin;

		event Action<FileType> OnReadCompleted;

		event Action<FileType> OnReadFailed;

		Task<int> GetCorruptedSaveFileProfileAsync(GameMode gameMode);

		bool IsFileExists(string path);

		Task<T> ReadDataAsync<T>(string filePath, FileType fileType) where T : class;

		T ReadData<T>(string filePath, FileType fileType) where T : class;
	}
}
