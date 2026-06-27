using System;
using System.Threading.Tasks;
using Restory.Data.SaveLoad;

namespace Restory.Data.ReadWriteServices.Interface
{
	public interface IWriteDataService
	{
		event Action<FileType> OnWriteBegin;

		event Action<FileType> OnWriteCompleted;

		event Action<FileType> OnWriteFailed;

		bool SaveFileExists(SaveFileNameParameters parameters);

		Task WriteDataAsync<T>(string filePath, T data, FileType fileType) where T : class;
	}
}
