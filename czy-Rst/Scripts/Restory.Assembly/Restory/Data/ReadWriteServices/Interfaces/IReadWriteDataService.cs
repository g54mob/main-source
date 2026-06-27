using Restory.Data.ReadWriteServices.Interface;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IReadWriteDataService : IReadDataService, IWriteDataService, IRemoveDataService
	{
		void BackupSaveDataDirectory();
	}
}
