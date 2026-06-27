using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Providers
{
	public interface IFileTypeReadWriteDataService
	{
		bool IsSupported(string fullPath);

		void Write(string data, string fullPath);

		Task WriteAsync(string jsonValue, string fullPath);

		string Read(string fullPath);

		Task<string> ReadAsync(string fullPath);
	}
}
