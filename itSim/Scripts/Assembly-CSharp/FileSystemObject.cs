using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FileSystemObject
{
	[Serializable]
	public class Permission
	{
		public string name;

		public bool value;

		[Space(10f)]
		public bool InheritanceFieldAllow;

		public bool allow;

		[Space(4f)]
		public bool notPublicAllow;

		[Space(10f)]
		public bool InheritanceFieldDeny;

		public bool deny;

		public Permission()
		{
		}

		public Permission(string name, bool value, bool inheritanceFieldAllow, bool allow, bool inheritanceFieldDeny, bool deny)
		{
		}

		public static List<Permission> GetDefaultPermissions()
		{
			return null;
		}

		public static List<Permission> ClonePermissions(List<Permission> source)
		{
			return null;
		}
	}

	public class PermissionChange
	{
		public string name;

		public bool toggleAllow;

		public bool toggleDeny;

		public bool? setAllow;

		public bool? setDeny;

		public PermissionChange(string name, bool toggleAllow = false, bool toggleDeny = false, bool? setAllow = null, bool? setDeny = null)
		{
		}
	}

	[SerializeField]
	[Header("Name")]
	public string Name;

	[SerializeField]
	public string NameOfDisk;

	[SerializeField]
	public string FileExtension;

	[SerializeField]
	[Header("Type")]
	public bool isFile;

	[SerializeField]
	public bool isDir;

	[Header("Preferences")]
	[SerializeField]
	public string deviceID;

	[SerializeField]
	public string deviceType;

	[SerializeField]
	public bool isDesktop;

	[SerializeField]
	public bool isHidden;

	[SerializeField]
	public bool alwaysHidden;

	[Header("Permissions")]
	[SerializeField]
	public bool permissionsInheritance;

	[SerializeField]
	public List<Permission> Permissions;

	[Header("size")]
	public long SizeBytes;

	[Header("Data")]
	public FileSystemObjectContentFile File;

	[Header("Contents")]
	public List<FileSystemObject> content;

	public FileSystemObject()
	{
	}

	public FileSystemObject(string name, bool isFile = false, bool isDir = false)
	{
	}

	public static FileSystemObject DeepCopy(FileSystemObject obj)
	{
		return null;
	}

	private static FileSystemObjectContentFile DeepCopyFile(FileSystemObjectContentFile file)
	{
		return null;
	}

	private static PDFPage DeepCopyPage(PDFPage page)
	{
		return null;
	}

	private static PDFElement DeepCopyElement(PDFElement element)
	{
		return null;
	}

	public void SetInheritance(bool value, DirectoryManager directoryManager, bool updatePermissions = true)
	{
	}

	public void RefreshPermissions(DirectoryManager directoryManager)
	{
	}

	private void SetPermissionInChildWithInheritance(List<Permission> parentPermissions)
	{
	}

	private void UpdatePrivateAllow(List<Permission> permissions)
	{
	}

	public void ClickModifyAllow(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickModifyDeny(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickReadAndExecuteAllow(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickReadAndExecuteDeny(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickDisplayingFolderContentsAllow(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickDisplayingFolderContentsDeny(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickReadAllow(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickReadDeny(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickWriteAllow(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public void ClickWriteDeny(DirectoryManager directoryManager, bool updatePermissions = true, Action<List<PermissionChange>> ExternalFunction = null)
	{
	}

	public Permission GetPermission(string name)
	{
		return null;
	}

	private void UpdatePermissions(List<PermissionChange> permsToUpdate, DirectoryManager directoryManager, bool updatePermissions = true)
	{
	}

	public bool Permission_Modify()
	{
		return false;
	}

	public bool Permission_ReadAndExecute()
	{
		return false;
	}

	public bool Permission_DisplayingFolderContents()
	{
		return false;
	}

	public bool Permission_Read()
	{
		return false;
	}

	public bool Permission_Write()
	{
		return false;
	}

	public bool IsAncestorOf(FileSystemObject possibleDescendant, DirectoryManager directoryManager)
	{
		return false;
	}

	public static string SaveToString(FileSystemObject content)
	{
		return null;
	}

	public static FileSystemObject LoadFromString(string json)
	{
		return null;
	}

	public void AddToContentCopy(FileSystemObject fileSystemObject)
	{
	}

	public void AddToContent(FileSystemObject fileSystemObject, DirectoryManager directoryManager)
	{
	}

	public void AddFile(string fileName, string extension, DirectoryManager directoryManager, bool FileContent = false)
	{
	}

	public void Delete(FileSystemObject obj, bool FileContent = false, DirectoryManager directoryManager = null)
	{
	}

	public void AddDirectory(string dirName, DirectoryManager directoryManager, bool FileContent = false)
	{
	}

	public string Rename(string newName, FileSystemObject parentDirectory)
	{
		return null;
	}

	public void DeleteThisDir(DirectoryManager manager, bool FileContent = false)
	{
	}

	public void DeleteThisFile(DirectoryManager manager)
	{
	}

	public void CheckSystemFile(DirectoryManager manager)
	{
	}

	public string GetFileExtension()
	{
		return null;
	}

	public string GetFileExtensionWithDot()
	{
		return null;
	}

	public int countDir()
	{
		return 0;
	}

	public int countDirWithAccessAndHidden(DirectoryManager directoryManager)
	{
		return 0;
	}

	public FileSystemObject FindDirByName(string name)
	{
		return null;
	}

	public void Paste(FileSystemObject copyItem, appExplorerMenu appExplorerMenu, appExplorer appExplorer, bool isCut)
	{
	}

	public bool canCopyCut(FileSystemObject item, appExplorer appExplorer, appExplorerMenu appExplorerMenu)
	{
		return false;
	}

	public FileSystemObject CreateFile(string name, string extension)
	{
		return null;
	}

	public FileSystemObject CreateDirectory(string name)
	{
		return null;
	}

	public static long EstimateFileSize_txt(string content)
	{
		return 0L;
	}

	public string FormatFileSize(long bytes)
	{
		return null;
	}

	public string GetFormatBytesWithSpaces(long bytes)
	{
		return null;
	}

	public long GetAlignToClusterSize(long bytes, int clusterSize)
	{
		return 0L;
	}
}
