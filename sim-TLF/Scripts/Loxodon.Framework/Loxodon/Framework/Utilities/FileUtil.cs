using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Loxodon.Log;

namespace Loxodon.Framework.Utilities
{
	public static class FileUtil
	{
		public interface IZipAccessor
		{
			int Priority { get; }

			bool Support(string path);

			Stream OpenRead(string path);

			bool Exists(string path);
		}

		private static readonly ILog log = LogManager.GetLogger(typeof(FileUtil));

		private static List<IZipAccessor> list = new List<IZipAccessor>();

		public static void Register(IZipAccessor zipAccessor)
		{
			if (!list.Contains(zipAccessor))
			{
				list.Add(zipAccessor);
				list.Sort((IZipAccessor x, IZipAccessor y) => y.Priority.CompareTo(x.Priority));
			}
		}

		public static void Unregister(IZipAccessor zipAccessor)
		{
			if (list.Contains(zipAccessor))
			{
				list.Remove(zipAccessor);
			}
		}

		public static string[] ReadAllLines(string path)
		{
			return ReadAllLines(path, Encoding.UTF8);
		}

		public static string[] ReadAllLines(string path, Encoding encoding)
		{
			if (!IsZipArchive(path))
			{
				return File.ReadAllLines(path, encoding);
			}
			List<string> list = new List<string>();
			using (Stream stream = OpenReadInZip(path))
			{
				using StreamReader streamReader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks: true);
				string item;
				while ((item = streamReader.ReadLine()) != null)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static string ReadAllText(string path)
		{
			return ReadAllText(path, Encoding.UTF8);
		}

		public static string ReadAllText(string path, Encoding encoding)
		{
			if (!IsZipArchive(path))
			{
				return File.ReadAllText(path, encoding);
			}
			byte[] array = ReadAllBytes(path);
			if (!HasBOMFlag(array))
			{
				return encoding.GetString(array);
			}
			return encoding.GetString(array, 3, array.Length - 3);
		}

		public static byte[] ReadAllBytes(string path)
		{
			if (!IsZipArchive(path))
			{
				return File.ReadAllBytes(path);
			}
			using Stream stream = OpenReadInZip(path);
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		public static Stream OpenRead(string path)
		{
			if (!IsZipArchive(path))
			{
				return File.OpenRead(path);
			}
			return OpenReadInZip(path);
		}

		public static bool Exists(string path)
		{
			if (!IsZipArchive(path))
			{
				return File.Exists(path);
			}
			return ExistsInZip(path);
		}

		private static Stream OpenReadInZip(string path)
		{
			for (int i = 0; i < list.Count; i++)
			{
				IZipAccessor zipAccessor = list[i];
				if (zipAccessor.Support(path))
				{
					return zipAccessor.OpenRead(path);
				}
			}
			throw new NotSupportedException(path);
		}

		private static bool ExistsInZip(string path)
		{
			for (int i = 0; i < list.Count; i++)
			{
				IZipAccessor zipAccessor = list[i];
				if (zipAccessor.Support(path))
				{
					return zipAccessor.Exists(path);
				}
			}
			throw new NotSupportedException(path);
		}

		public static bool IsZipArchive(string path)
		{
			if (Regex.IsMatch(path, "(jar:file:///)|(\\.jar)|(\\.apk)|(\\.obb)|(\\.zip)", RegexOptions.IgnoreCase))
			{
				return true;
			}
			return false;
		}

		private static bool HasBOMFlag(byte[] data)
		{
			if (data == null || data.Length < 3)
			{
				return false;
			}
			if (data[0] == 239 && data[1] == 187 && data[2] == 191)
			{
				return true;
			}
			return false;
		}
	}
}
