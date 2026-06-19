using System;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine.Networking;

namespace Loxodon.Framework.Net.Http
{
	public class DownloadFileHandler : DownloadHandlerScript
	{
		private class DownloadInfo
		{
			public const int DOWNLOAD_INFO_OFFSET = 128;

			private byte[] buffer = new byte[256];

			public long FileSize { get; set; }

			public long DownloadedSize { get; set; }

			public string LastModified { get; set; }

			public string ETag { get; set; }

			public static DownloadInfo Read(FileInfo fileInfo)
			{
				if (!fileInfo.Exists || fileInfo.Length <= 128)
				{
					return null;
				}
				using Stream stream = fileInfo.OpenRead();
				stream.Position = fileInfo.Length - 128;
				return new DownloadInfo().ReadFrom(stream);
			}

			public float GetProgress()
			{
				if (FileSize <= 0)
				{
					return 0f;
				}
				return (float)DownloadedSize / (float)FileSize;
			}

			public DownloadInfo ReadFrom(Stream stream)
			{
				DownloadedSize = ReadLong(stream, buffer);
				FileSize = ReadLong(stream, buffer);
				LastModified = ReadString(stream, buffer);
				ETag = ReadString(stream, buffer);
				return this;
			}

			public DownloadInfo WriteTo(Stream stream)
			{
				Write(stream, buffer, DownloadedSize);
				Write(stream, buffer, FileSize);
				Write(stream, buffer, LastModified);
				Write(stream, buffer, ETag);
				return this;
			}

			public DownloadInfo WriteDownloadedTo(Stream stream)
			{
				Write(stream, buffer, DownloadedSize);
				return this;
			}

			public static void Write(Stream stream, byte[] buffer, int value)
			{
				buffer[0] = (byte)value;
				buffer[1] = (byte)(value >> 8);
				buffer[2] = (byte)(value >> 16);
				buffer[3] = (byte)(value >> 24);
				stream.Write(buffer, 0, 4);
			}

			public static void Write(Stream stream, byte[] buffer, long value)
			{
				buffer[0] = (byte)value;
				buffer[1] = (byte)(value >> 8);
				buffer[2] = (byte)(value >> 16);
				buffer[3] = (byte)(value >> 24);
				buffer[4] = (byte)(value >> 32);
				buffer[5] = (byte)(value >> 40);
				buffer[6] = (byte)(value >> 48);
				buffer[7] = (byte)(value >> 56);
				stream.Write(buffer, 0, 8);
			}

			public static void Write(Stream stream, byte[] buffer, string value)
			{
				int num = ((!string.IsNullOrEmpty(value)) ? Encoding.UTF8.GetBytes(value, 0, value.Length, buffer, 2) : 0);
				buffer[0] = (byte)num;
				buffer[1] = (byte)(num >> 8);
				stream.Write(buffer, 0, num + 2);
			}

			public static long ReadLong(Stream stream, byte[] buffer)
			{
				stream.Read(buffer, 0, 8);
				uint num = (uint)(buffer[0] | (buffer[1] << 8) | (buffer[2] << 16) | (buffer[3] << 24));
				return (long)(((ulong)(uint)(buffer[4] | (buffer[5] << 8) | (buffer[6] << 16) | (buffer[7] << 24)) << 32) | num);
			}

			public static int ReadInt(Stream stream, byte[] buffer)
			{
				stream.Read(buffer, 0, 4);
				return buffer[0] | (buffer[1] << 8) | (buffer[2] << 16) | (buffer[3] << 24);
			}

			public static string ReadString(Stream stream, byte[] buffer)
			{
				stream.Read(buffer, 0, 2);
				int num = buffer[0] | (buffer[1] << 8);
				if (num <= 0)
				{
					return null;
				}
				stream.Read(buffer, 0, num);
				return Encoding.UTF8.GetString(buffer, 0, num);
			}
		}

		private readonly FileInfo fileInfo;

		private readonly UnityWebRequest www;

		private readonly FileInfo downloadFileInfo;

		private readonly bool supportBreakpointResume;

		private FileStream downloadFileStream;

		private DownloadInfo downloadInfo;

		private int initialized;

		public long TotalSize
		{
			get
			{
				if (downloadInfo == null)
				{
					return 0L;
				}
				return downloadInfo.FileSize;
			}
		}

		public long DownloadedSize
		{
			get
			{
				if (downloadInfo == null)
				{
					return 0L;
				}
				return downloadInfo.DownloadedSize;
			}
		}

		public float DownloadProgress => GetProgress();

		public DownloadFileHandler(string fileName)
			: this(null, new FileInfo(fileName))
		{
		}

		public DownloadFileHandler(UnityWebRequest www, string fileName)
			: this(www, new FileInfo(fileName))
		{
		}

		public DownloadFileHandler(FileInfo fileInfo)
			: this(null, fileInfo)
		{
		}

		public DownloadFileHandler(UnityWebRequest www, FileInfo fileInfo)
			: base(new byte[8192])
		{
			this.fileInfo = fileInfo;
			downloadFileInfo = new FileInfo(this.fileInfo.FullName + ".download");
			this.www = www;
			supportBreakpointResume = www != null;
			if (supportBreakpointResume && downloadFileInfo.Exists)
			{
				try
				{
					downloadInfo = DownloadInfo.Read(downloadFileInfo);
					if (downloadInfo != null)
					{
						if (!string.IsNullOrEmpty(downloadInfo.LastModified))
						{
							www.SetRequestHeader("If-Range", downloadInfo.LastModified);
						}
						if (!string.IsNullOrEmpty(downloadInfo.ETag))
						{
							www.SetRequestHeader("If-Range", downloadInfo.ETag);
						}
						www.SetRequestHeader("Range", "bytes=" + downloadInfo.DownloadedSize + "-");
					}
				}
				catch (Exception)
				{
					downloadFileInfo.Delete();
				}
			}
			if (downloadInfo == null && downloadFileInfo.Exists)
			{
				downloadFileInfo.Delete();
			}
			if (!downloadFileInfo.Directory.Exists)
			{
				downloadFileInfo.Directory.Create();
			}
		}

		private void CreateDownloadFile(DownloadInfo downloadInfo)
		{
			try
			{
				if (downloadFileInfo.Exists)
				{
					downloadFileInfo.Delete();
				}
				if (!downloadFileInfo.Directory.Exists)
				{
					downloadFileInfo.Directory.Create();
				}
				using Stream stream = downloadFileInfo.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None);
				stream.SetLength(downloadInfo.FileSize + 128);
				stream.Position = downloadInfo.FileSize;
				downloadInfo.WriteTo(stream);
			}
			catch (Exception ex)
			{
				if (downloadFileInfo.Exists)
				{
					downloadFileInfo.Delete();
				}
				if (www != null)
				{
					www.Abort();
				}
				throw ex;
			}
		}

		protected override float GetProgress()
		{
			if (downloadInfo == null)
			{
				return 0f;
			}
			return downloadInfo.GetProgress();
		}

		protected override byte[] GetData()
		{
			return null;
		}

		protected override bool ReceiveData(byte[] data, int dataLength)
		{
			if (data == null || data.Length < 1)
			{
				return false;
			}
			InitializeDownloadFileStream(0L);
			if (supportBreakpointResume)
			{
				downloadFileStream.Position = downloadInfo.DownloadedSize;
				downloadFileStream.Write(data, 0, dataLength);
				downloadFileStream.Flush();
				downloadInfo.DownloadedSize += dataLength;
				downloadFileStream.Position = downloadInfo.FileSize;
				downloadInfo.WriteDownloadedTo(downloadFileStream);
				downloadFileStream.Flush();
			}
			else
			{
				downloadFileStream.Write(data, 0, dataLength);
				downloadFileStream.Flush();
				downloadInfo.DownloadedSize += dataLength;
			}
			return true;
		}

		protected override void CompleteContent()
		{
			FileInfo fileInfo = null;
			try
			{
				if (downloadFileStream != null)
				{
					downloadFileStream.Dispose();
					downloadFileStream = null;
				}
				if (supportBreakpointResume)
				{
					fileInfo = new FileInfo(this.fileInfo.FullName + ".tmp");
					if (fileInfo.Exists)
					{
						fileInfo.Delete();
					}
					File.Move(downloadFileInfo.FullName, fileInfo.FullName);
					using (Stream stream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
					{
						stream.SetLength(downloadInfo.FileSize);
					}
					if (this.fileInfo.Exists)
					{
						this.fileInfo.Delete();
					}
					File.Move(fileInfo.FullName, this.fileInfo.FullName);
				}
				else
				{
					if (this.fileInfo.Exists)
					{
						this.fileInfo.Delete();
					}
					File.Move(downloadFileInfo.FullName, this.fileInfo.FullName);
				}
			}
			catch (Exception ex)
			{
				SafeDelete(downloadFileInfo);
				SafeDelete(fileInfo);
				SafeDelete(this.fileInfo);
				throw ex;
			}
		}

		private void SafeDelete(FileInfo file)
		{
			try
			{
				if (file != null && file.Exists)
				{
					file.Delete();
				}
			}
			catch (Exception)
			{
			}
		}

		protected override void ReceiveContentLengthHeader(ulong contentLength)
		{
			if (!InitializeDownloadFileStream((long)contentLength) && downloadInfo != null && downloadInfo.FileSize <= 0)
			{
				downloadInfo.FileSize = (long)contentLength;
			}
		}

		private bool InitializeDownloadFileStream(long contentLength)
		{
			if (Interlocked.CompareExchange(ref initialized, 1, 0) == 0)
			{
				if (!supportBreakpointResume)
				{
					downloadInfo = new DownloadInfo();
					downloadInfo.DownloadedSize = 0L;
					downloadInfo.FileSize = contentLength;
					downloadFileStream = downloadFileInfo.Create();
					return true;
				}
				if (www.responseCode == 200)
				{
					if (contentLength <= 0)
					{
						long.TryParse(www.GetResponseHeader("Content-Length"), out contentLength);
					}
					downloadInfo = new DownloadInfo();
					downloadInfo.DownloadedSize = 0L;
					downloadInfo.FileSize = contentLength;
					downloadInfo.ETag = www.GetResponseHeader("ETag");
					downloadInfo.LastModified = www.GetResponseHeader("Last-Modified");
					CreateDownloadFile(downloadInfo);
				}
				downloadFileStream = downloadFileInfo.OpenWrite();
				return true;
			}
			return false;
		}

		public override void Dispose()
		{
			if (downloadFileStream != null)
			{
				downloadFileStream.Dispose();
				downloadFileStream = null;
			}
			base.Dispose();
		}
	}
}
