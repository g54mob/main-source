using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public class JsonReadWriteDataService : IFileTypeReadWriteDataService
	{
		public const string FileExtension = ".json";

		public bool IsSupported(string fullPath)
		{
			return string.Equals(Path.GetExtension(fullPath), ".json", StringComparison.OrdinalIgnoreCase);
		}

		public void Write(string data, string fullPath)
		{
			try
			{
				using StreamWriter streamWriter = new StreamWriter(fullPath);
				streamWriter.Write(data);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public async Task WriteAsync(string jsonValue, string fullPath)
		{
			_ = 1;
			try
			{
				await using StreamWriter streamWriter = new StreamWriter(fullPath);
				await streamWriter.WriteAsync(jsonValue);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public string Read(string fullPath)
		{
			string result = string.Empty;
			try
			{
				using FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using StreamReader streamReader = new StreamReader(stream);
				result = streamReader.ReadToEnd();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return result;
		}

		public async Task<string> ReadAsync(string fullPath)
		{
			string result = string.Empty;
			try
			{
				await using FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				using StreamReader streamReader = new StreamReader(fileStream);
				result = await streamReader.ReadToEndAsync();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return result;
		}
	}
}
