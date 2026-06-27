using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Interface
{
	public interface ISaveDataService : IWorkDirectory, IGlobalSubscriber
	{
		void Save();

		Task SaveAsync();
	}
}
