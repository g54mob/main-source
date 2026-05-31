using System.Collections.Generic;
using UnityEngine;

public class DirectoryManager : PTSMonoBehaviour
{
	[Header("Components")]
	public FilesVerify filesVerify;

	public yourComputerInSmallCorp yourComputerInSmallCorp;

	[Header("Files")]
	public List<FileSystemObject> fileSystemObjects;

	[ContextMenu("Set Deflaut permissions to all object")]
	public void SetInheritanceToAll()
	{
	}

	public void RemoveDeletableContent(FileSystemObject dirRoot, List<FileSystemObject> BlockAccess)
	{
	}

	public void DeleteDirectory(FileSystemObject dirToDelete, bool FileContent = false)
	{
	}

	public List<FileSystemObject> GetDesktopDirectory()
	{
		return null;
	}

	public bool IsExist(FileSystemObject findIn, FileSystemObject find)
	{
		return false;
	}

	public FileSystemObject GetParent(FileSystemObject child)
	{
		return null;
	}

	public FileSystemObject GetItemFormPath(FileSystemObject currentDirectory, string path)
	{
		return null;
	}

	public string GenerateTreeString(FileSystemObject current, string indent, bool isLast, bool viewFile, bool viewASCII, bool firstChair = true)
	{
		return null;
	}

	public string GetPath(FileSystemObject MyComputer, FileSystemObject dir, bool isRoot = true, bool removeColonChar = false, bool removeLastBackslashInDir = false)
	{
		return null;
	}

	public bool Permission_CheckCanRunExecute(FileSystemObject objectToOpen)
	{
		return false;
	}

	public bool Permission_CheckCanOpenFile(FileSystemObject objectToOpen)
	{
		return false;
	}

	public bool Permission_CheckCanOpenDir(FileSystemObject Object)
	{
		return false;
	}

	public bool Permission_CheckCanDelete(FileSystemObject objectToDelete)
	{
		return false;
	}

	public bool Permission_CheckCanCreateFile(FileSystemObject targetDir)
	{
		return false;
	}

	public bool Permission_CheckCanCreateDir(FileSystemObject targetDir)
	{
		return false;
	}

	public bool Permission_CheckCanCopyDir(FileSystemObject dirToCopy)
	{
		return false;
	}

	public bool Permission_CheckCanPasteDir(FileSystemObject folderToPaste, FileSystemObject destinationDir)
	{
		return false;
	}

	public bool Permission_CheckCanCutFile(FileSystemObject objectToCut)
	{
		return false;
	}

	public bool Permission_CheckCanCopyFile(FileSystemObject objectToCopy)
	{
		return false;
	}

	public bool Permission_CheckCanPasteFile(FileSystemObject objectToCut, FileSystemObject currentDirectory)
	{
		return false;
	}

	public bool Permission_CheckCanRename(FileSystemObject objectToRename)
	{
		return false;
	}
}
