using System;
using System.Collections.Generic;
using UnityEngine;

public class DummyFileSystem : FilesystemInterface
{
	public bool IsInitialized => true;

	public void Init(string partition, PlatformInterface platformInterface)
	{
		Debug.LogWarning("DummyFileSystem.Init not implemented");
	}

	public void Deinit()
	{
		Debug.LogWarning("DummyFileSystem.Deinit not implemented");
	}

	public bool DirectoryExists(string path)
	{
		Debug.LogWarning("DummyFileSystem.DirectoryExists not implemented");
		return false;
	}

	public void CreateDirectory(string path)
	{
		Debug.LogWarning("DummyFileSystem.CreateDirectory not implemented");
	}

	public void DeleteDirectory(string path)
	{
		Debug.LogWarning("DummyFileSystem.DeleteDirectory not implemented");
	}

	public void CopyDirectory(string from, string to)
	{
		Debug.LogWarning("DummyFileSystem.CopyDirectory not implemented");
	}

	public bool FileExists(string path)
	{
		Debug.LogWarning("DummyFileSystem.FileExists not implemented");
		return false;
	}

	public byte[] Read(string path)
	{
		Debug.LogWarning("DummyFileSystem.Read not implemented");
		return null;
	}

	public void BeginWrite()
	{
		Debug.LogWarning("DummyFileSystem.BeginWrite not implemented");
	}

	public void EndWrite()
	{
		Debug.LogWarning("DummyFileSystem.EndWrite not implemented");
	}

	public void Write(string name, string path, byte[] data)
	{
		Debug.LogWarning("DummyFileSystem.Write not implemented");
	}

	public void Delete(string path)
	{
		Debug.LogWarning("DummyFileSystem.Delete not implemented");
	}

	public IEnumerable<string> GetAllFiles()
	{
		Debug.LogWarning("DummyFileSystem.GetAllFiles not implemented");
		return null;
	}

	public IEnumerable<string> GetFiles(string path)
	{
		Debug.LogWarning("DummyFileSystem.CreateDirectory not implemented");
		return null;
	}

	public DateTime GetFileTime(string path)
	{
		Debug.LogWarning("DummyFileSystem.GetFileTime not implemented");
		return DateTime.Now;
	}

	public ulong GetRemainingBytes()
	{
		Debug.LogWarning("DummyFileSystem.GetRemainingBytes not implemented");
		return 16777216uL;
	}
}
