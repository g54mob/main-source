using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class StaticDiskDataSource : IStaticDataSource
	{
		private readonly string fileName_;

		public StaticDiskDataSource(string fileName)
		{
		}

		public Stream GetSource()
		{
			return null;
		}
	}
}
