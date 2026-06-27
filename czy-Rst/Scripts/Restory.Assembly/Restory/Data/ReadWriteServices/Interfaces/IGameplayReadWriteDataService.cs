using Restory.Data.ReadWriteServices.Interface;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IGameplayReadWriteDataService : IGameplayReadOnlyDataService, IReadDataService, IGameplayWriteOnlyDataService, IWriteDataService, IRemoveDataService
	{
	}
}
