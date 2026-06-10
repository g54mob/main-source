using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class DiskArchiveStorage : BaseArchiveStorage
	{
		private Stream temporaryStream_;

		private readonly string fileName_;

		private string temporaryName_;

		public DiskArchiveStorage(ZipFile file, FileUpdateMode updateMode)
			: base(default(FileUpdateMode))
		{
		}

		public DiskArchiveStorage(ZipFile file)
			: base(default(FileUpdateMode))
		{
		}

		public override Stream GetTemporaryOutput()
		{
			return null;
		}

		public override Stream ConvertTemporaryToFinal()
		{
			return null;
		}

		public override Stream MakeTemporaryCopy(Stream stream)
		{
			return null;
		}

		public override Stream OpenForDirectUpdate(Stream stream)
		{
			return null;
		}

		public override void Dispose()
		{
		}
	}
}
