using System.IO;

namespace DV.UserManagement.Storage
{
	public interface IStreamProvider
	{
		Stream GrabStream();

		void ReleaseStream();
	}
}
