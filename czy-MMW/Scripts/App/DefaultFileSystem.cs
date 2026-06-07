using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DefaultFileSystem : IFileSystem
{
	private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DefaultFileSystem");

	public List<string> GetFilesInDirectory(string directory)
	{
		List<string> list = new List<string>();
		foreach (string item in Directory.EnumerateFiles(GetAbsolutePath(directory)))
		{
			list.Add(item);
		}
		return list;
	}

	public List<string> GetDirectoriesInDirectory(string directory)
	{
		List<string> list = new List<string>();
		foreach (string item in Directory.EnumerateDirectories(GetAbsolutePath(directory)))
		{
			list.Add(item);
		}
		return list;
	}

	public byte[] ReadFile(string filepath)
	{
		string absolutePath = GetAbsolutePath(filepath);
		try
		{
			using FileStream fileStream = File.Open(absolutePath, FileMode.Open);
			long length = fileStream.Length;
			if (length > int.MaxValue)
			{
				Log.Error("ReadFile({0}) failed! File is {1} bytes, which is larger than the maximum supported length of {2} bytes.", filepath, length, int.MaxValue);
				return null;
			}
			int num = (int)length;
			byte[] array = new byte[num];
			int num2 = fileStream.Read(array, 0, num);
			if (num2 != num)
			{
				Log.Warn("ReadFile({0}) only read {1} bytes, not the expected {2} bytes.", filepath, num2, num);
				Array.Resize(ref array, num2);
			}
			return array;
		}
		catch (Exception ex)
		{
			Log.Error("ReadFile({0}) failed.\n{1}", filepath, ex);
			return null;
		}
	}

	public bool WriteFile(string filepath, byte[] data)
	{
		string absolutePath = GetAbsolutePath(filepath);
		try
		{
			using FileStream fileStream = File.OpenWrite(absolutePath);
			fileStream.Write(data, 0, data.Length);
		}
		catch (Exception ex)
		{
			Log.Error("WriteFile({0}) failed.\n{1}", filepath, ex);
			return false;
		}
		return true;
	}

	public bool DeleteFile(string filepath)
	{
		string absolutePath = GetAbsolutePath(filepath);
		try
		{
			File.Delete(absolutePath);
		}
		catch (Exception ex)
		{
			Log.Error("DeleteFile({0}) failed.\n{1}", filepath, ex);
			return false;
		}
		return true;
	}

	private static string GetAbsolutePath(string path)
	{
		return Path.Combine(Application.persistentDataPath, path);
	}
}
