using System.Threading.Tasks;
using Restory.Data.SaveLoad;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IRemoveDataService
	{
		void DeleteAll(SaveFileNameParameters parameters);

		void DeleteAll();

		void DeleteFile(string filePath);

		Task CheckCorruptedSaveFilesAsync(SaveFileNameParameters parameters);
	}
}
