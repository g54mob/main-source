using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class DynamicDiskDataSource : IDynamicDataSource
	{
		public Stream GetSource(ZipEntry entry, string name)
		{
			return null;
		}
	}
}
