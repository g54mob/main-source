using Restory.Data.SaveLoad.Interfaces;

namespace Restory.Data.SaveLoad.Interface
{
	public interface ISaveLoadDataService : ISaveDataService, IWorkDirectory, IGlobalSubscriber, ILoadDataService, IDamagable
	{
	}
}
