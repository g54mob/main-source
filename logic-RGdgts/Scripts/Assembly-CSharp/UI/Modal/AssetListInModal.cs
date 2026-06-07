using System;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;

namespace UI.Modal
{
	public class AssetListInModal : MonoBehaviour
	{
		private ElementListContainer fileListContainer;

		private List<AssetType> assetsTypes;

		private string selectedAssetPath;

		private List<string> path;

		[NonSerialized]
		[HideInInspector]
		private AssetType selectedAssetType;

		private string selectedAssetOriginalName;

		private string currentFolderPath;

		private bool folders;

		private bool files;

		[SerializeField]
		private FileDirectoryBar dirBar;

		[SerializeField]
		private GameObject NoAssetMessageBox;

		private List<string> extensionFilter;

		private List<string> existingAssetNames;

		private bool inportSameNameAllowed;

		[SerializeField]
		private UIButton openButton;

		[SerializeField]
		private UIButton closeButton;

		private bool needFilesInList;

		public void Init()
		{
		}

		private void InitVisibleExtension(List<string> ext)
		{
		}

		private void FillFileList(string filter = null)
		{
		}

		public void FillBack(string folderPath)
		{
		}

		private void Clear()
		{
		}

		private void OnElementClicked(int assetIndex)
		{
		}

		private void OnFolderDoubleClicked(int assetIndex)
		{
		}

		private void OnFileDoubleClicked(int fileIndex)
		{
		}

		private void OnElementDoubleClicked(int fileIndex)
		{
		}
	}
}
