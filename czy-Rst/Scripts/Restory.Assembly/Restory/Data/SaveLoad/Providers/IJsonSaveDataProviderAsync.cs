using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Providers
{
	public interface IJsonSaveDataProviderAsync : ISaveDataProvider
	{
		Task SaveAsync(string jsonValue, string subFolderFileName);

		Task<string> LoadAsync(string subFolderFileName);
	}
}
