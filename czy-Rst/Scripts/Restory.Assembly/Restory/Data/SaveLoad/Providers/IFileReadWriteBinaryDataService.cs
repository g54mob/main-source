using System.Threading.Tasks;

namespace Restory.Data.SaveLoad.Providers
{
	public interface IFileReadWriteBinaryDataService
	{
		bool IsSupported(string fullPath);

		Task WriteAsync(byte[] binaryData, string fullPath);

		Task<byte[]> ReadAsync(string fullPath);
	}
}
