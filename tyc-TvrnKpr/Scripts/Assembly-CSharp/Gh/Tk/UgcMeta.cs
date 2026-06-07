using System.IO;

namespace Gh.Tk
{
	public class UgcMeta : IPersistable
	{
		private const int FILE_VERSION = 1;

		public const string MANIFEST_FILENAME = "meta.json";

		public int FileVersion { get; private set; }

		public Stream ToJsonStream()
		{
			return null;
		}
	}
}
