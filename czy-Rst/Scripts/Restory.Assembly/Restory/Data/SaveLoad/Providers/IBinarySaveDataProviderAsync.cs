using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Providers
{
	public interface IBinarySaveDataProviderAsync : ISaveDataProvider
	{
		Task SaveBinaryAsync(byte[] binaryData, string subFolderFileName);

		Task<byte[]> LoadBinaryAsync(string subFolderFileName);
	}
}
