using System;
using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public class ExportFilesModal : UIModal<UIExportFileModalInitParameters>
	{
		private ElementListContainer fileListContainer;

		private string selectedAssetPath;

		private List<string> path;

		[NonSerialized]
		[HideInInspector]
		private AssetType assetType;

		private string referenceFolder;

		private string currentFolderPath;

		private string currentImportName;

		[SerializeField]
		private FileDirectoryBar dirBar;

		private Action<string> OnElementSaved;

		private Action OnModalClosed;

		private List<string> existingAssetNames;

		[SerializeField]
		private UIButton saveButton;

		[SerializeField]
		private UIButton closeButton;

		[SerializeField]
		private UIInputField nameBar;

		private TableReference tableRef;

		private TableEntryReference placeholder;

		private LocalizedString localizedString;

		private List<AssetType> assetsTypes;

		private AssetType selectedAssetType;

		public override void Init(UIModalManager modalManager, UIExportFileModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void OnOpen()
		{
		}

		public void OnSave()
		{
		}

		private void CheckSameNameDesired(bool confirm)
		{
		}

		private void OpenExportConfirmModal()
		{
		}

		private void OpenExportFolder()
		{
		}

		private void Save()
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

		private void FillFileList()
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

		private void OnElementDoubleClicked(int fileIndex)
		{
		}

		public override void Set()
		{
		}

		private void Clear()
		{
		}

		private void OnSaveNameChange()
		{
		}
	}
}
