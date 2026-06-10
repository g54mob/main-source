using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public abstract class BaseArchiveStorage : IArchiveStorage
	{
		private readonly FileUpdateMode updateMode_;

		public FileUpdateMode UpdateMode => default(FileUpdateMode);

		protected BaseArchiveStorage(FileUpdateMode updateMode)
		{
		}

		public abstract Stream GetTemporaryOutput();

		public abstract Stream ConvertTemporaryToFinal();

		public abstract Stream MakeTemporaryCopy(Stream stream);

		public abstract Stream OpenForDirectUpdate(Stream stream);

		public abstract void Dispose();
	}
}
