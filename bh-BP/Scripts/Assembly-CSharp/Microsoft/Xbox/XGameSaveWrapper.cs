using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.Xbox
{
	public class XGameSaveWrapper
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		public struct XUserHandle
		{
		}

		public delegate void InitializeCallback(int hresult);

		public delegate void GetQuotaCallback(int hresult, long remainingQuota);

		public delegate void QueryContainersCallback(int hresult, string[] containerNames);

		public delegate void QueryBlobsCallback(int hresult, Dictionary<string, uint> blobInfos);

		public delegate void LoadCallback(int hresult, byte[] blobData);

		public delegate void SaveCallback(int hresult);

		public delegate void DeleteCallback(int hresult);

		private delegate void UpdateCallback(int hresult);

		~XGameSaveWrapper()
		{
		}

		public void InitializeAsync(XUserHandle userHandle, string scid, InitializeCallback callback)
		{
		}

		public void GetQuotaAsync(GetQuotaCallback callback)
		{
		}

		public void QueryContainers(string containerNamePrefix, QueryContainersCallback callback)
		{
		}

		public void QueryContainerBlobs(string containerName, QueryBlobsCallback callback)
		{
		}

		public void Load(string containerName, string blobName, LoadCallback callback)
		{
		}

		public void Save(string containerName, string blobName, byte[] blobData, SaveCallback callback)
		{
		}

		public void Delete(string containerName, DeleteCallback callback)
		{
		}

		public void Delete(string containerName, string blobName, DeleteCallback callback)
		{
		}

		public void Delete(string containerName, string[] blobNames, DeleteCallback callback)
		{
		}

		private void Update(string containerName, IDictionary<string, byte[]> blobsToSave, IList<string> blobsToDelete, UpdateCallback callback)
		{
		}
	}
}
