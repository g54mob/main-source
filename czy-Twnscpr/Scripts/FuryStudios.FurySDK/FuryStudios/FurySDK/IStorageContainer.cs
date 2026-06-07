using System.Collections.Generic;

namespace FuryStudios.FurySDK
{
	public interface IStorageContainer
	{
		ContainerID ID { get; }

		IAsyncRequest<byte[]> LoadBytes(string filename);

		IAsyncRequest<string> LoadText(string filename);

		IAsyncRequest SaveBytes(string filename, byte[] data);

		IAsyncRequest SaveText(string filename, string text);

		IAsyncRequest Delete(string filename);

		IAsyncRequest<bool> FileExists(string filename);

		IAsyncRequest<IList<string>> ListFiles();
	}
}
