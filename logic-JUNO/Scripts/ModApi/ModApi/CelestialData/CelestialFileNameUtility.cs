using System;
using System.IO;

namespace ModApi.CelestialData
{
	public static class CelestialFileNameUtility
	{
		public static string ToDatabaseFileName(CelestialFilePath filePath, Guid fileId, CelestialFileType fileType, int counter = 0)
		{
			return ToDatabaseFileName(new FileInfo(filePath.FullPath).Name, fileId, fileType, counter);
		}

		public static string ToDatabaseFileName(string fileName, Guid fileId, CelestialFileType fileType, int counter = 0)
		{
			string text = ToFriendlyFileName(fileName, includeExtension: true);
			string text2 = string.Empty;
			int num = text.LastIndexOf('.');
			if (num >= 0)
			{
				text2 = text.Substring(num);
				text = text.Remove(num);
			}
			if (fileType == CelestialFileType.PlanetarySystem || fileType == CelestialFileType.CelestialBody)
			{
				text2 = ".xml";
			}
			string text3 = ((counter == 0) ? string.Empty : $"[{counter}]");
			string text4 = ((text.Length == 0) ? string.Empty : "-");
			return $"{text}{text4}{text3}{{{fileId}}}{text2}";
		}

		public static string ToFriendlyFileName(CelestialFilePath filePath, bool includeExtension)
		{
			if (filePath == null)
			{
				return string.Empty;
			}
			return ToFriendlyFileName(new FileInfo(filePath.FullPath).Name, includeExtension);
		}

		public static string ToFriendlyFileName(string fileName, bool includeExtension)
		{
			if (fileName == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			int num = fileName.LastIndexOf('.');
			if (num >= 0)
			{
				text = fileName.Substring(num);
				fileName = fileName.Remove(num);
			}
			bool flag = false;
			int num2 = fileName.Length - 38;
			int index = fileName.Length - 1;
			if (num2 >= 0 && fileName[num2] == '{' && fileName[index] == '}' && Guid.TryParse(fileName.Substring(num2 + 1, 36), out var _))
			{
				fileName = fileName.Remove(num2);
				flag = true;
			}
			int num3 = fileName.LastIndexOf('[');
			int num4 = fileName.Length - 1;
			if (num3 >= 0 && fileName[num4] == ']' && int.TryParse(fileName.Substring(num3 + 1, num4 - num3 - 1), out var _))
			{
				fileName = fileName.Remove(num3);
			}
			if (flag && fileName.Length > 0 && fileName[fileName.Length - 1] == '-')
			{
				fileName = fileName.Remove(fileName.Length - 1);
			}
			fileName = string.Join(string.Empty, fileName.Split(Path.GetInvalidFileNameChars()));
			if (includeExtension)
			{
				fileName += text;
			}
			return fileName;
		}
	}
}
