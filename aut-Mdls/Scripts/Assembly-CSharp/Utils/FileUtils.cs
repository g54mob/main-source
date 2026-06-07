#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.IO;

namespace Utils
{
	public static class FileUtils
	{
		public static bool TryReadText(string file, out string text)
		{
			text = null;
			if (string.IsNullOrEmpty(file))
			{
				return false;
			}
			if (!File.Exists(file))
			{
				return false;
			}
			try
			{
				text = File.ReadAllText(file);
				return true;
			}
			catch (Exception ex)
			{
				typeof(FileUtils).LogAssertion($"ReadAllText failed to load file '{file}', {ex.Message}", "TryReadText", 26);
				return false;
			}
		}

		public static bool TryWriteText(string file, string content)
		{
			if (string.IsNullOrEmpty(file))
			{
				return false;
			}
			try
			{
				File.WriteAllText(file, content);
				return true;
			}
			catch (Exception ex)
			{
				typeof(FileUtils).LogAssertion($"WriteAllText failed to file '{file}', {ex.Message}", "TryWriteText", 44);
				return false;
			}
		}

		public static bool TryReadData(string file, out byte[] data)
		{
			data = null;
			if (string.IsNullOrEmpty(file))
			{
				return false;
			}
			try
			{
				data = File.ReadAllBytes(file);
				return true;
			}
			catch (Exception ex)
			{
				typeof(FileUtils).LogAssertion($"ReadAllBytes failed to file '{file}', {ex.Message}", "TryReadData", 63);
				return false;
			}
		}

		public static bool TryWriteData(string file, byte[] content)
		{
			if (string.IsNullOrEmpty(file))
			{
				return false;
			}
			try
			{
				File.WriteAllBytes(file, content);
				return true;
			}
			catch (Exception ex)
			{
				typeof(FileUtils).LogAssertion($"WriteAllText failed to file '{file}', {ex.Message}", "TryWriteData", 81);
				return false;
			}
		}

		public static bool Delete(string file)
		{
			if (string.IsNullOrEmpty(file))
			{
				return false;
			}
			if (!File.Exists(file))
			{
				return true;
			}
			try
			{
				File.Delete(file);
				return true;
			}
			catch (Exception ex)
			{
				typeof(FileUtils).LogAssertion($"DeleteFile '{file}' failed, {ex.Message}", "Delete", 105);
				return false;
			}
		}

		public static void GetDirectoryAsBackupPath(string sourceDirectory, out string destinationDirectory, out int displayCount)
		{
			string arg = sourceDirectory;
			string[] array = sourceDirectory.Split('_');
			if (int.TryParse(array[^1], out displayCount))
			{
				int num = array[^1].Length + 1;
				arg = sourceDirectory.Substring(0, sourceDirectory.Length - num);
			}
			else
			{
				displayCount = 0;
			}
			do
			{
				destinationDirectory = $"{arg}_{++displayCount}";
			}
			while (Directory.Exists(destinationDirectory));
		}

		public static void CopyDirectoryTo(string sourceDirectory, string destinationDirectory, bool recursive)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectory);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory not found: " + directoryInfo.FullName);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			Directory.CreateDirectory(destinationDirectory);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destinationDirectory, fileInfo.Name);
				fileInfo.CopyTo(destFileName);
			}
			if (recursive)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destinationDirectory2 = Path.Combine(destinationDirectory, directoryInfo2.Name);
					CopyDirectoryTo(directoryInfo2.FullName, destinationDirectory2, recursive: true);
				}
			}
		}
	}
}
