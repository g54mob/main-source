using System.Runtime.InteropServices;

namespace Pathfinding.Ionic.Zip
{
	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000F")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ComHelper
	{
		public bool IsZipFile(string filename)
		{
			return false;
		}

		public bool IsZipFileWithExtract(string filename)
		{
			return false;
		}

		public bool CheckZip(string filename)
		{
			return false;
		}

		public bool CheckZipPassword(string filename, string password)
		{
			return false;
		}

		public void FixZipDirectory(string filename)
		{
		}

		public string GetZipLibraryVersion()
		{
			return null;
		}
	}
}
