using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public class BinReadWriteDataService : IFileTypeReadWriteDataService
	{
		public const string FileExtension = ".bin";

		public bool IsSupported(string fullPath)
		{
			return string.Equals(Path.GetExtension(fullPath), ".bin", StringComparison.OrdinalIgnoreCase);
		}

		public void Write(string data, string fullPath)
		{
			using FileStream fileStream = File.Open(fullPath, FileMode.Create);
			using GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Compress);
			using BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.UTF8);
			try
			{
				binaryWriter.Write(data);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				binaryWriter.Close();
				gZipStream.Close();
				fileStream.Close();
			}
		}

		public async Task WriteAsync(string data, string fullPath)
		{
			await using FileStream stream = File.Open(fullPath, FileMode.Create);
			await using GZipStream gzip = new GZipStream(stream, CompressionMode.Compress);
			await using BinaryWriter binaryWriter = new BinaryWriter(gzip, Encoding.UTF8);
			try
			{
				binaryWriter.Write(data);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				binaryWriter.Close();
				gzip.Close();
				stream.Close();
			}
		}

		public string Read(string fullPath)
		{
			string result = string.Empty;
			using FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			using GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress);
			using BinaryReader binaryReader = new BinaryReader(gZipStream, Encoding.UTF8, leaveOpen: false);
			try
			{
				result = binaryReader.ReadString();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				binaryReader.Close();
				gZipStream.Close();
				fileStream.Close();
			}
			return result;
		}

		public async Task<string> ReadAsync(string fullPath)
		{
			string text = string.Empty;
			string result;
			await using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				string text2;
				await using (GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress))
				{
					using BinaryReader binaryReader = new BinaryReader(gZipStream, Encoding.UTF8, leaveOpen: false);
					try
					{
						text = binaryReader.ReadString();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					finally
					{
						binaryReader.Close();
						gZipStream.Close();
						fileStream.Close();
					}
					text2 = text;
				}
				result = text2;
			}
			return result;
		}
	}
}
