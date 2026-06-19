using System;
using System.IO;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal abstract class CompressOperationBase : IModIOZipOperation, IDisposable
	{
		private const bool sizeLimitReached = false;

		protected bool cancel;

		protected ProgressHandle progressHandle;

		protected Task<ResultAnd<MemoryStream>> _operation;

		protected CompressOperationBase(ProgressHandle progressHandle)
		{
			this.progressHandle = progressHandle;
		}

		public Task GetOperation()
		{
			return _operation;
		}

		public virtual void Cancel()
		{
		}

		public void Dispose()
		{
			_operation?.Dispose();
		}

		public virtual Task<ResultAnd<MemoryStream>> Compress()
		{
			throw new NotImplementedException();
		}

		protected async Task CompressStream(string entryName, Stream fileStream, ZipOutputStream zipStream)
		{
			ZipEntry entry = new ZipEntry(entryName);
			zipStream.PutNextEntry(entry);
			long max = fileStream.Length;
			byte[] data = new byte[4096];
			fileStream.Position = 0L;
			while (fileStream.Position < fileStream.Length)
			{
				int num = await fileStream.ReadAsync(data, 0, data.Length);
				if (num <= 0)
				{
					break;
				}
				await zipStream.WriteAsync(data, 0, num);
				if (progressHandle != null)
				{
					progressHandle.Progress = (float)zipStream.Position / (float)max;
				}
			}
			zipStream.CloseEntry();
		}

		protected ResultAnd<MemoryStream> Abort(ResultAnd<MemoryStream> resultAnd, string details)
		{
			Logger.Log(LogLevel.Verbose, $"FAILED COMPRESSION [{resultAnd.result.code}] {details}");
			resultAnd.result = ResultBuilder.Create(20506u);
			return resultAnd;
		}
	}
}
