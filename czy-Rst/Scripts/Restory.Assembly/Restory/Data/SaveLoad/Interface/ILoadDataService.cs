using System.Threading.Tasks;
using Restory.Data.SaveLoad.Interfaces;

namespace Restory.Data.SaveLoad.Interface
{
	public interface ILoadDataService : IWorkDirectory, IDamagable, IGlobalSubscriber
	{
		void Load();

		Task LoadAsync();

		void ResetToDefault();
	}
}
