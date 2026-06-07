using System.IO;
using System.Threading.Tasks;

namespace FuryStudios.FurySDK.Internal
{
	public abstract class DotNetStorageRequest : BaseStorageRequest
	{
		protected FileStream stream;

		protected Task task;

		protected DotNetStorageRequest(string filePath, StorageAccessMode access)
			: base(null, default(StorageAccessMode))
		{
		}

		protected override void OnUpdate()
		{
		}

		protected virtual void OnTaskFinish()
		{
		}
	}
}
