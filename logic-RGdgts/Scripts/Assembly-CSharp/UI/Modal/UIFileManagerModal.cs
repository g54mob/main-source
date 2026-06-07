using System;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIFileManagerModal : UIModal<UIFileMModalInitParameters>
	{
		private ElementListContainer fileListContainer;

		private List<AssetType> assetsTypes;

		private string selectedAssetPath;

		private List<string> path;

		[HideInInspector]
		private AssetType selectedAssetType;

		private string referenceFolder;

		private string selectedAssetOriginalName;

		private string currentFolderPath;

		private string currentImportName;

		private bool folders;

		private bool files;

		[SerializeField]
		private FileDirectoryBar dirBar;

		[SerializeField]
		private UIButton searchButton;

		[SerializeField]
		private GameObject NoAssetMessageBox;

		[SerializeField]
		private UIInputField searchBar;

		private bool searchOpen;

		private List<string> extensionFilter;

		private Action<AssetType, string, string, string> OnElementSelected;

		private Action OnModalClosed;

		private LocalizedString localizedStringTitle;

		private List<string> existingAssetNames;

		private bool importSameNameAllowed;

		[SerializeField]
		private UIButton openButton;

		[SerializeField]
		private UIButton closeButton;

		public GameObject renameDialogPrefab;

		public override void Init(UIModalManager modalManager, UIFileMModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		private void InitVisibleExtension(List<string> ext)
		{
		}

		public override void OnOpen()
		{
		}

		public void OnConfirmButton()
		{
		}

		public void OpenRenameModal()
		{
		}

		public void OnImportNameChosen(string name)
		{
		}

		public override void OnClose()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		private void FillFileList(string filter = null)
		{
		}

		public void SearchButton()
		{
		}

		public void SearchValueChange()
		{
		}

		public void FillBack(string folderPath)
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

		public override void Set()
		{
		}

		private void Clear()
		{
		}
	}
}
