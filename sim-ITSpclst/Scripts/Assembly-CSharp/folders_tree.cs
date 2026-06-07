using System;
using System.Collections.Generic;
using UnityEngine;

public class folders_tree : MonoBehaviour
{
	[Serializable]
	public class Folder
	{
		public string folderName;

		public List<Folder> subfolders;

		public List<File> files;
	}

	[Serializable]
	public class File
	{
		public string fileName;

		public string extension;
	}

	[Serializable]
	public class FileIcon
	{
		public string extension;

		public Sprite icon;
	}

	public GameObject folderItemPrefab;

	public GameObject fileItemPrefab;

	public Transform treeViewContent;

	public Sprite defaultFolderIcon;

	public List<FileIcon> fileIcons;

	public Folder rootFolder;

	private void Start()
	{
	}

	private void GenerateFolderTree(Folder folder, Transform parent)
	{
	}

	private void GenerateFileItem(File file, Transform parent)
	{
	}

	private Sprite GetIconByExtension(string extension)
	{
		return null;
	}
}
