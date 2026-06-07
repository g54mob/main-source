using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class SafeFileWriter
{
	private static readonly int MaxBackups = 16;

	private static string GenerateBackupPath(string originalPath)
	{
		string directoryName = Path.GetDirectoryName(originalPath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
		string extension = Path.GetExtension(originalPath);
		string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		return Path.Combine(directoryName, fileNameWithoutExtension + "_" + text + extension);
	}

	private static void ManageBackups(string originalPath)
	{
		string directoryName = Path.GetDirectoryName(originalPath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
		string extension = Path.GetExtension(originalPath);
		List<string> list = (from f in Directory.GetFiles(directoryName, fileNameWithoutExtension + "_*" + extension)
			orderby f descending
			select f).ToList();
		if (list.Count <= MaxBackups)
		{
			return;
		}
		int num = list.Count - MaxBackups;
		for (int num2 = 0; num2 < num; num2++)
		{
			if (num2 % 2 == 0)
			{
				File.Delete(list[list.Count - 1 - num2]);
			}
		}
	}

	public static void FileWriteAllLinesSafe(string path, IEnumerable<string> content)
	{
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			File.WriteAllLines(path, content);
			string destFileName = GenerateBackupPath(path);
			File.Copy(path, destFileName, overwrite: true);
			ManageBackups(path);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error during save: " + ex.Message);
			throw;
		}
	}

	public static string[] FileReadAllLinesSafe(string path)
	{
		if (!File.Exists(path))
		{
			Console.WriteLine("Main save file not found.");
			return TryLoadFromBackups(path);
		}
		try
		{
			return File.ReadAllLines(path);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error loading main save file: " + ex.Message);
			return TryLoadFromBackups(path);
		}
	}

	private static string[] TryLoadFromBackups(string originalPath)
	{
		string directoryName = Path.GetDirectoryName(originalPath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
		string extension = Path.GetExtension(originalPath);
		foreach (string item in (from f in Directory.GetFiles(directoryName, fileNameWithoutExtension + "_*" + extension)
			orderby f descending
			select f).ToList())
		{
			try
			{
				return File.ReadAllLines(item);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error loading backup file " + item + ": " + ex.Message);
			}
		}
		throw new FileNotFoundException("No valid save file or backup found.");
	}
}
