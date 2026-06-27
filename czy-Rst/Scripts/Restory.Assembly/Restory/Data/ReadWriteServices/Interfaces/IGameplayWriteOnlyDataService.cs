using System.Threading;
using System.Threading.Tasks;
using Restory.Data.ReadWriteServices.Interface;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IGameplayWriteOnlyDataService : IWriteDataService
	{
		Task WriteGameProgressAsync(SaveFileNameParameters parameters, GameplayProgressSaveData capturedGameplayProgress, CancellationToken cancellationToken);
	}
}
