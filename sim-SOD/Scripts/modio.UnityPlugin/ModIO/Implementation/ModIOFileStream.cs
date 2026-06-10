using System.IO;
using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal abstract class ModIOFileStream : Stream
	{
		public abstract string FilePath { get; }

		public abstract Task<ResultAnd<byte[]>> ReadAllBytesAsync();

		public abstract ResultAnd<byte[]> ReadAllBytes();

		public abstract Task<Result> WriteAllBytesAsync(byte[] buffer);

		public abstract Result WriteAllBytes(byte[] buffer);
	}
}
