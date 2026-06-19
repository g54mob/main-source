using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace ModIO.Implementation
{
	internal static class IOUtil
	{
		public static bool TryParseUTF8JSONData<T>(byte[] data, out T jsonObject, out Result result)
		{
			if (data != null)
			{
				try
				{
					string value = Encoding.UTF8.GetString(data);
					jsonObject = JsonConvert.DeserializeObject<T>(value);
					result = ResultBuilder.Success;
					return true;
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Error, "Failed to deserialize: " + ex.Message);
				}
			}
			jsonObject = default(T);
			result = ResultBuilder.Create(20501u);
			return false;
		}

		public static byte[] GenerateUTF8JSONData<T>(T jsonObject)
		{
			byte[] array = null;
			try
			{
				string s = JsonConvert.SerializeObject(jsonObject);
				return Encoding.UTF8.GetBytes(s);
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Error, "Failed to serialize jsonObject. Exception: " + ex.Message);
				return null;
			}
		}

		public static bool TryParseImageData(byte[] data, out Texture2D texture, out Result result)
		{
			if (data == null || data.Length == 0)
			{
				result = ResultBuilder.Create(20507u);
				texture = null;
				Logger.Log(LogLevel.Verbose, ":INTERNAL: Attempted to parse image from NULL/0-length buffer.");
			}
			else
			{
				texture = new Texture2D(0, 0);
				if (texture.LoadImage(data, markNonReadable: false))
				{
					result = ResultBuilder.Success;
				}
				else
				{
					result = ResultBuilder.Create(20507u);
					texture = null;
					Logger.Log(LogLevel.Verbose, ":INTERNAL: Failed to parse image data.");
				}
			}
			return result.Succeeded();
		}

		public static string GenerateMD5(Stream data)
		{
			using MD5 mD = MD5.Create();
			return BitConverter.ToString(mD.ComputeHash(data)).Replace("-", "").ToLowerInvariant();
		}

		public static string GenerateMD5(byte[] data)
		{
			using MD5 mD = MD5.Create();
			return BitConverter.ToString(mD.ComputeHash(data)).Replace("-", "").ToLowerInvariant();
		}

		public static string GenerateArchiveMD5(string filepath)
		{
			string empty = string.Empty;
			Result result;
			using ModIOFileStream data = DataStorage.OpenArchiveReadStream(filepath, out result);
			if (!result.Succeeded())
			{
				return string.Empty;
			}
			return GenerateMD5(data);
		}

		public static Result GenerateMD5(Stream stream, out string MD5)
		{
			using MD5 mD = System.Security.Cryptography.MD5.Create();
			string text = BitConverter.ToString(mD.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
			MD5 = text;
			return ResultBuilder.Success;
		}

		public static string GenerateMD5(string text)
		{
			return GenerateMD5(Encoding.UTF8.GetBytes(text));
		}

		internal static async Task<string> GetFileHashFromFilePath_md5(string filepath)
		{
			return GenerateMD5(await GetRawBytesFromFile(filepath));
		}

		internal static async Task<byte[]> GetRawBytesFromFile(string filepath)
		{
			await Task.Delay(1);
			throw new NotImplementedException();
		}

		internal static string CleanFileNameForInvalidCharacters(string filename)
		{
			string text = filename.Replace(" ", "-");
			char[] trimChars = new char[2] { '-', '.' };
			text = text.Trim(trimChars);
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char c in invalidFileNameChars)
			{
				text = text.Replace(c.ToString(), "");
			}
			return text;
		}
	}
}
