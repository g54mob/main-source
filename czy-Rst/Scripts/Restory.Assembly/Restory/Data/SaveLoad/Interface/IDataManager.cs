using Helpers.Initializaton;
using Restory.Data.SaveLoad.Interfaces;

namespace Restory.Data.SaveLoad.Interface
{
	public interface IDataManager : IInit, IInitAsync, ISaveLoadDataService, ISaveDataService, IWorkDirectory, IGlobalSubscriber, ILoadDataService, IDamagable
	{
	}
}
