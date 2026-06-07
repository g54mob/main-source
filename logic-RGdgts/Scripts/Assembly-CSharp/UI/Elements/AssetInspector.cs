using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Elements
{
	public class AssetInspector : MonoBehaviour
	{
		public UIText assetTitle;

		public UIButton editButton;

		public UIButton openButton;

		public UIButton renameButton;

		public UIButton duplicateButton;

		public UIButton deleteButton;

		public UIButton exportButton;

		public GameObject renameDialogPrefab;

		public GameObject confirmDialogPrefab;

		private Action OnAssetDelete;

		private Action<string> OnAssetRename;

		private Action<string> OnAssetDuplicate;

		private Action<string> OnAssetExport;

		protected AssetType assetType;

		private List<string> existingAssetNames;

		public virtual void Init(Action OnAssetDelete, Action OnAssetEdit, Action<string> OnAssetRename, Action<string> OnAssetDuplicate, List<string> existingNames, Action<string> OnAssetExport, AssetType assetType)
		{
		}

		public void OnDelete()
		{
		}

		private void OnDeleteConfirm(bool confirm)
		{
		}

		public void OpenRenameDialog()
		{
		}

		public void OnRename(string name)
		{
		}

		public void OpenDuplicateDialog()
		{
		}

		public void OnDuplicate(string name)
		{
		}

		public virtual void OpenExportDialog()
		{
		}

		public virtual void OnExport(string name)
		{
		}

		public virtual void ActivateAssetInspector(Asset asset)
		{
		}

		public virtual void ChangeLocalRemoteButtons(Gadget gadget)
		{
		}
	}
}
