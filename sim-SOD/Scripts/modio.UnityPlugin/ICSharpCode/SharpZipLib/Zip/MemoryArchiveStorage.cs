using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class MemoryArchiveStorage : BaseArchiveStorage
	{
		private MemoryStream temporaryStream_;

		private MemoryStream finalStream_;

		public MemoryStream FinalStream => null;

		public MemoryArchiveStorage()
			: base(default(FileUpdateMode))
		{
		}

		public MemoryArchiveStorage(FileUpdateMode updateMode)
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
