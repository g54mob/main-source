using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public class GZipReadWriteDataService : IFileTypeReadWriteDataService
	{
		public const string FileExtension = ".restory";

		public const string TempFileExtension = ".tmp";

		public bool IsSupported(string fullPath)
		{
			string extension = Path.GetExtension(fullPath);
			if (!string.Equals(extension, ".restory", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(extension, ".tmp", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		public void Write(string data, string fullPath)
		{
			using FileStream fileStream = File.Open(fullPath, FileMode.Create);
			using GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Compress);
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				gZipStream.Write(bytes);
				gZipStream.Flush();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				gZipStream.Close();
				fileStream.Close();
			}
		}

		public async Task WriteAsync(string data, string fullPath)
		{
			await using FileStream stream = File.Open(fullPath, FileMode.Create);
			await using GZipStream gzip = new GZipStream(stream, CompressionMode.Compress);
			_ = 2;
			try
			{
				await gzip.WriteAsync(await ConvertToBytes(data));
				await gzip.FlushAsync();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				gzip.Close();
				stream.Close();
			}
		}

		private Task<byte[]> ConvertToBytes(string value)
		{
			return Task.Run(() => Encoding.UTF8.GetBytes(value));
		}

		public string Read(string fullPath)
		{
			string result = string.Empty;
			using FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress);
			using StreamReader streamReader = new StreamReader(gZipStream);
			try
			{
				result = streamReader.ReadToEnd();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				gZipStream.Close();
				fileStream.Close();
			}
			return result;
		}

		public async Task<string> ReadAsync(string fullPath)
		{
			string result = string.Empty;
			string result2;
			await using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				string text;
				await using (GZipStream gzip = new GZipStream(fileStream, CompressionMode.Decompress))
				{
					using StreamReader reader = new StreamReader(gzip);
					try
					{
						result = await reader.ReadToEndAsync();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					finally
					{
						gzip.Close();
						fileStream.Close();
					}
					text = result;
				}
				result2 = text;
			}
			return result2;
		}
	}
}
