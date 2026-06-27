using Helpers.Initializaton;
using Restory.Data.SaveLoad.Interfaces;

namespace Restory.Data.SaveLoad.Interface
{
	public interface IDependentDataService<T> : IInit<T>, IInitAsync<T>, ISaveLoadDataService, ISaveDataService, IWorkDirectory, IGlobalSubscriber, ILoadDataService, IDamagable where T : ISaveLoadDataService
	{
		T Owner { get; }
	}
}
