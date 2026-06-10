using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ZLogger.Providers
{
	internal class RollingFileStream : Stream
	{
		private static readonly Regex NumberRegex = new Regex("(\\d)+$", RegexOptions.Compiled);

		private readonly object streamLock = new object();

		private readonly Func<DateTimeOffset, DateTimeOffset> timestampPattern;

		private readonly Func<DateTimeOffset, int, string> fileNameSelector;

		private readonly long rollSizeInBytes;

		private readonly ZLoggerOptions options;

		private bool disposed;

		private int writtenLength;

		private string fileName;

		private Stream innerStream;

		private DateTimeOffset currentTimestampPattern;

		public override bool CanRead => innerStream.CanRead;

		public override bool CanSeek => innerStream.CanSeek;

		public override bool CanWrite => innerStream.CanWrite;

		public override long Length => innerStream.Length;

		public override long Position
		{
			get
			{
				return innerStream.Position;
			}
			set
			{
				innerStream.Position = value;
			}
		}

		public RollingFileStream(Func<DateTimeOffset, int, string> fileNameSelector, Func<DateTimeOffset, DateTimeOffset> timestampPattern, int rollSizeKB, ZLoggerOptions options)
		{
			this.timestampPattern = timestampPattern;
			this.fileNameSelector = fileNameSelector;
			rollSizeInBytes = rollSizeKB * 1024;
			this.options = options;
			ValidateFileNameSelector();
			TryChangeNewRollingFile();
		}

		private void ValidateFileNameSelector()
		{
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileNameSelector(utcNow, 0));
			string fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(fileNameSelector(utcNow, 1));
			if (!NumberRegex.IsMatch(fileNameWithoutExtension) || !NumberRegex.IsMatch(fileNameWithoutExtension2))
			{
				throw new ArgumentException("fileNameSelector is invalid format, must be int(sequence no) is last.");
			}
			string value = NumberRegex.Match(fileNameWithoutExtension).Groups[0].Value;
			string value2 = NumberRegex.Match(fileNameWithoutExtension2).Groups[0].Value;
			if (!int.TryParse(value, out var result) || !int.TryParse(value2, out var result2))
			{
				throw new ArgumentException("fileNameSelector is invalid format, must be int(sequence no) is last.");
			}
			if (result == result2)
			{
				throw new ArgumentException("fileNameSelector is invalid format, must be int(sequence no) is incremental.");
			}
		}

		private void TryChangeNewRollingFile()
		{
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			DateTimeOffset dateTimeOffset;
			try
			{
				dateTimeOffset = timestampPattern(utcNow);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("timestampPattern convert failed.", innerException);
			}
			if (innerStream != null && !(dateTimeOffset != currentTimestampPattern) && writtenLength < rollSizeInBytes)
			{
				return;
			}
			int num = 0;
			if (innerStream != null && dateTimeOffset == currentTimestampPattern)
			{
				num = ExtractCurrentSequence(fileName) + 1;
			}
			string text = null;
			while (true)
			{
				try
				{
					string text2 = fileNameSelector(utcNow, num);
					if (text == text2)
					{
						throw new InvalidOperationException("fileNameSelector indicate same filname");
					}
					text = text2;
				}
				catch (Exception innerException2)
				{
					throw new InvalidOperationException("fileNameSelector convert failed", innerException2);
				}
				FileInfo fileInfo = new FileInfo(text);
				if (!fileInfo.Exists || fileInfo.Length < rollSizeInBytes)
				{
					break;
				}
				num++;
			}
			lock (streamLock)
			{
				if (disposed)
				{
					return;
				}
				try
				{
					if (innerStream != null)
					{
						innerStream.Flush();
						innerStream.Dispose();
					}
				}
				catch (Exception innerException3)
				{
					throw new InvalidOperationException("Can't dispose fileStream", innerException3);
				}
				try
				{
					fileName = text;
					currentTimestampPattern = dateTimeOffset;
					if (File.Exists(fileName))
					{
						writtenLength = (int)new FileInfo(fileName).Length;
					}
					else
					{
						writtenLength = 0;
					}
					DirectoryInfo directory = new FileInfo(fileName).Directory;
					if (!directory.Exists)
					{
						directory.Create();
					}
					innerStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 1, useAsync: false);
				}
				catch (Exception innerException4)
				{
					throw new InvalidOperationException("Can't create FileStream", innerException4);
				}
			}
		}

		private static int ExtractCurrentSequence(string fileName)
		{
			fileName.LastIndexOf('.');
			fileName = Path.GetFileNameWithoutExtension(fileName);
			if (int.TryParse(NumberRegex.Match(fileName).Groups[0].Value, out var result))
			{
				return result;
			}
			return 0;
		}

		public override void Flush()
		{
			innerStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return innerStream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return innerStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			innerStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			TryChangeNewRollingFile();
			innerStream.Write(buffer, offset, count);
			writtenLength += count;
		}

		protected override void Dispose(bool disposing)
		{
			lock (streamLock)
			{
				innerStream.Dispose();
				disposed = true;
			}
		}
	}
}
