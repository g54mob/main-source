using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gilzoide.CloudSave.Providers
{
	public class DummyCloudSaveProvider : ICloudSaveProvider
	{
		public bool IsCloudSaveEnabled => false;

		public Task<List<ICloudSaveGameMetadata>> FetchAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public Task<ICloudSaveGameMetadata> FindAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public Task<byte[]> LoadBytesAsync(ICloudSaveGameMetadata metadata, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public Task<ICloudSaveGameMetadata> SaveBytesAsync(string name, byte[] bytes, CloudSaveGameMetadataUpdate metadata = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public Task<bool> DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
