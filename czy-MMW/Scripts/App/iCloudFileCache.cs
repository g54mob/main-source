using System;
using System.Collections.Generic;
using System.IO;
using Factory;

public class iCloudFileCache : IiCloudCache
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("iCloudFileCache");

	public bool HasFile(string filepath)
	{
		return File.Exists(GetAbsolutePath(filepath));
	}

	public byte[] ReadFile(string filepath)
	{
		try
		{
			return File.ReadAllBytes(GetAbsolutePath(filepath));
		}
		catch (Exception ex)
		{
			Log.Error("Unable to read from {0}.\n{1}", filepath, ex);
			return null;
		}
	}

	public bool WriteFile(string filepath, byte[] data)
	{
		string absolutePath = GetAbsolutePath(filepath);
		string directoryName = Path.GetDirectoryName(absolutePath);
		if (!string.IsNullOrEmpty(directoryName))
		{
			try
			{
				Directory.CreateDirectory(directoryName);
			}
			catch (Exception ex)
			{
				Log.Error("Unable to create directory {0}.\n{1}", directoryName, ex);
			}
		}
		try
		{
			File.WriteAllBytes(absolutePath, data);
		}
		catch (Exception ex2)
		{
			Log.Error("Unable to write to {0}.\n{1}", absolutePath, ex2);
			return false;
		}
		return true;
	}

	public bool HasSpaceToWriteFile(string filepath, int dataLength, out int bytesNeededToDelete)
	{
		bytesNeededToDelete = 0;
		return true;
	}

	public IEnumerable<string> GetFilenamesInDirectory(string directory)
	{
		List<string> list = new List<string>();
		try
		{
			string absolutePath = GetAbsolutePath(directory);
			if (!Directory.Exists(absolutePath))
			{
				Log.Info("Directory {0} does not exist yet.", absolutePath);
				return list;
			}
			Log.Info("Enumerating files in directory {0}.", absolutePath);
			foreach (string item in Directory.EnumerateFiles(absolutePath))
			{
				string fileName = Path.GetFileName(item);
				Log.Info("Found file {0}.", fileName);
				list.Add(Path.GetFileName(item));
			}
		}
		catch (Exception ex)
		{
			Log.Error("Unable to enumerate files in {0}.\n{1}", directory, ex);
		}
		return list;
	}

	public IEnumerable<string> GetDirectoriesInDirectory(string directory)
	{
		List<string> list = new List<string>();
		try
		{
			foreach (string item in Directory.EnumerateDirectories(GetAbsolutePath(directory)))
			{
				string fileName = Path.GetFileName(item);
				if (!string.IsNullOrEmpty(fileName) && !list.Contains(fileName))
				{
					list.Add(fileName);
				}
			}
		}
		catch (Exception ex)
		{
			Log.Error("Unable to enumerate directories in {0}.\n{1}", directory, ex);
		}
		return list;
	}

	public int GetFileSize(string filepath)
	{
		try
		{
			long length = new FileInfo(GetAbsolutePath(filepath)).Length;
			return (int)((length > int.MaxValue) ? int.MaxValue : length);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public bool MoveFile(string filepath, string directory)
	{
		string absolutePath = GetAbsolutePath(directory);
		if (string.IsNullOrEmpty(absolutePath))
		{
			Log.Error("Could not move file at {0} to {1}.", filepath, directory);
			return false;
		}
		try
		{
			Directory.CreateDirectory(absolutePath);
		}
		catch (Exception ex)
		{
			Log.Error("Unable to create directory {0}.\n{1}", absolutePath, ex);
		}
		string fileName = Path.GetFileName(filepath);
		if (string.IsNullOrEmpty(fileName))
		{
			Log.Error("Could not extract filename from filepath {0}.", filepath);
			return false;
		}
		string absolutePath2 = GetAbsolutePath(filepath);
		try
		{
			string text = Path.Combine(absolutePath, fileName);
			File.Move(absolutePath2, text);
			Log.Info("Moved file {0} to {1}.", absolutePath2, text);
			return true;
		}
		catch (Exception ex2)
		{
			Log.Error("Unable to move file {0} to {1}.\n{2}", absolutePath2, directory, ex2);
		}
		return false;
	}

	public bool DeleteFile(string filepath)
	{
		string absolutePath = GetAbsolutePath(filepath);
		try
		{
			File.Delete(absolutePath);
			Log.Info("Deleted file at {0}.", absolutePath);
			return true;
		}
		catch (Exception ex)
		{
			Log.Error("Unable to delete file at {0}.\n{1}", absolutePath, ex);
		}
		return false;
	}

	public void CopyNewFilesInDirectory(string sourceDirectory, string destinationDirectory)
	{
		string absolutePath = GetAbsolutePath(sourceDirectory);
		string absolutePath2 = GetAbsolutePath(destinationDirectory);
		Log.Info("Copying all files from {0} to {1}.", absolutePath, absolutePath2);
		if (!Directory.Exists(absolutePath))
		{
			return;
		}
		try
		{
			bool flag = false;
			foreach (string sourceFilepath in Directory.EnumerateFiles(absolutePath))
			{
				string fileName = Path.GetFileName(sourceFilepath);
				string destinationFilepath = Path.Combine(absolutePath2, fileName);
				if (File.Exists(destinationFilepath))
				{
					Log.Info("Skipping {0}, because it already exists in the destination directory.", fileName);
					continue;
				}
				if (!flag)
				{
					flag = true;
					Directory.CreateDirectory(absolutePath2);
				}
				File.Copy(sourceFilepath, destinationFilepath, overwrite: false);
				Log.Info("Copied file {0} to {1}.", sourceFilepath, destinationFilepath);
				_auditTrail.RecordEvent("iCloudFileCache.CopyFile", delegate(Dictionary<string, string> metadata)
				{
					metadata["fromFilepath"] = sourceFilepath;
					metadata["toFilepath"] = destinationFilepath;
				});
			}
		}
		catch (Exception ex)
		{
			Log.Error("Failed to copy files.\n{0}", ex);
		}
	}

	public DateTime GetFileModifiedTime(string filepath)
	{
		return File.GetLastWriteTimeUtc(GetAbsolutePath(filepath));
	}

	private string GetAbsolutePath(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return _hardwareCapabilities.PersistentStoragePath;
		}
		return Path.Combine(_hardwareCapabilities.PersistentStoragePath, path);
	}
}
