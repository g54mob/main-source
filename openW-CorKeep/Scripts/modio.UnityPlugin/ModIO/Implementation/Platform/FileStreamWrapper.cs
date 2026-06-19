using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ModIO.Implementation.Platform
{
	internal class FileStreamWrapper : ModIOFileStream
	{
		private FileStream fileStream;

		private Result result = ResultBuilder.Success;

		public override bool CanRead => fileStream.CanRead;

		public override bool CanSeek => fileStream.CanSeek;

		public override bool CanTimeout => fileStream.CanTimeout;

		public override bool CanWrite => fileStream.CanWrite;

		public override long Length => fileStream.Length;

		public override long Position
		{
			get
			{
				return fileStream.Position;
			}
			set
			{
				fileStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return fileStream.ReadTimeout;
			}
			set
			{
				fileStream.ReadTimeout = value;
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return fileStream.WriteTimeout;
			}
			set
			{
				fileStream.WriteTimeout = value;
			}
		}

		public override string FilePath => fileStream.Name;

		public FileStreamWrapper(FileStream internalStream)
		{
			fileStream = internalStream;
		}

		public Result GetLastResult()
		{
			return result;
		}

		public override void Close()
		{
			base.Close();
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			return fileStream.CopyToAsync(destination, bufferSize, cancellationToken);
		}

		public override void Flush()
		{
			fileStream.Flush();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return fileStream.FlushAsync(cancellationToken);
		}

		public override object InitializeLifetimeService()
		{
			return fileStream.InitializeLifetimeService();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return fileStream.Read(buffer, offset, count);
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return fileStream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override async Task<ResultAnd<byte[]>> ReadAllBytesAsync()
		{
			byte[] data = null;
			if (SystemIOWrapper.IsPathValid(fileStream.Name, out var result) && SystemIOWrapper.DoesFileExist(fileStream.Name, out result))
			{
				try
				{
					data = new byte[fileStream.Length];
					await fileStream.ReadAsync(data, 0, (int)fileStream.Length);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to read the file.\n.path=" + fileStream.Name + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20405u);
				}
			}
			return ResultAnd.Create(result, data);
		}

		public override ResultAnd<byte[]> ReadAllBytes()
		{
			byte[] array = null;
			if (SystemIOWrapper.IsPathValid(fileStream.Name, out var result) && SystemIOWrapper.DoesFileExist(fileStream.Name, out result))
			{
				try
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, (int)fileStream.Length);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to read the file.\n.path=" + fileStream.Name + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20405u);
				}
			}
			return ResultAnd.Create(result, array);
		}

		public override int ReadByte()
		{
			return fileStream.ReadByte();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return fileStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			fileStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			fileStream.Write(buffer, offset, count);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return fileStream.WriteAsync(buffer, offset, count, cancellationToken);
		}

		public override async Task<Result> WriteAllBytesAsync(byte[] buffer)
		{
			if (SystemIOWrapper.IsPathValid(fileStream.Name, out var result) && SystemIOWrapper.TryCreateParentDirectory(fileStream.Name, out result))
			{
				try
				{
					fileStream.Position = 0L;
					await fileStream.WriteAsync(buffer, 0, buffer.Length);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to write the file.\n.path=" + fileStream.Name + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20406u);
				}
			}
			Logger.Log(LogLevel.Verbose, $"Write file: {fileStream.Name} - Result: [{result.code}]");
			return result;
		}

		public override Result WriteAllBytes(byte[] buffer)
		{
			if (SystemIOWrapper.IsPathValid(fileStream.Name, out var result) && SystemIOWrapper.TryCreateParentDirectory(fileStream.Name, out result))
			{
				try
				{
					fileStream.Position = 0L;
					fileStream.Write(buffer, 0, buffer.Length);
					result = ResultBuilder.Success;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "Unhandled error when attempting to write the file.\n.path=" + fileStream.Name + "\n.Exception:" + ex.Message);
					result = ResultBuilder.Create(20406u);
				}
			}
			Logger.Log(LogLevel.Verbose, $"Write file: {fileStream.Name} - Result: [{result.code}]");
			return result;
		}

		public override void WriteByte(byte value)
		{
			fileStream.WriteByte(value);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				fileStream?.Dispose();
			}
			base.Dispose(disposing);
		}

		public override bool Equals(object obj)
		{
			return fileStream.Equals(obj);
		}

		public override int GetHashCode()
		{
			return fileStream.GetHashCode();
		}

		public override string ToString()
		{
			return fileStream.ToString();
		}

		[Obsolete("Use ReadAsync instead.")]
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return fileStream.BeginRead(buffer, offset, count, callback, state);
		}

		[Obsolete("Use WriteAsync instead.")]
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return fileStream.BeginWrite(buffer, offset, count, callback, state);
		}

		[Obsolete]
		public override int EndRead(IAsyncResult asyncResult)
		{
			return fileStream.EndRead(asyncResult);
		}

		[Obsolete]
		public override void EndWrite(IAsyncResult asyncResult)
		{
			fileStream.EndWrite(asyncResult);
		}

		[Obsolete("CreateWaitHandle will be removed eventually.  Please use \"new ManualResetEvent(false)\" instead.")]
		protected override WaitHandle CreateWaitHandle()
		{
			return base.CreateWaitHandle();
		}
	}
}
