using UnityEngine;

public class TestFile : MonoBehaviour
{
	public DirectoryManager directoryManager;

	[Header("Path")]
	public string path;

	[Header("File")]
	public string filename;

	public string extension;

	public string contentFile;

	[Header("Dir")]
	public string dirname;

	[Header("Debug")]
	public string debug;

	[ContextMenu("File.Exists(path)")]
	public void FileExists()
	{
	}

	[ContextMenu("File.AddFile(path, filename, extension)")]
	public void AddFile()
	{
	}

	[ContextMenu("File.AddDirectory(path, dirname)")]
	public void AddDir()
	{
	}

	[ContextMenu("File.Delete(path)")]
	public void Delete()
	{
	}
}
