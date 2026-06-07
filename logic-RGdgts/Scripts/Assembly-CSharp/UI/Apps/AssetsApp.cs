using System.Collections.Generic;
using UI.Elements;
using UI.ListContainer;
using UI.SmallCanvas;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Apps
{
	public class AssetsApp : MultiToolApp, AssetContainer.IListener
	{
		private AssetContainer currentContainer;

		[SerializeField]
		private AssetSmallPanel assetPanelPrefab;

		private AssetSmallPanel assetSmallPanel;

		[SerializeField]
		private GameObject noAssetsInGadgetMessage;

		[SerializeField]
		private GameObject noAssetSelectedMessage;

		[SerializeField]
		private GameObject protectedAssetSelectedMessage;

		[SerializeField]
		private Transform inspectorArea;

		private GameObject currentActiveInspector;

		[SerializeField]
		private Transform creationButtonBar;

		private List<UIButton> assetCretionButtonsList;

		[SerializeField]
		private GameObject assetCreationButton;

		[SerializeField]
		private Sprite leftSprite;

		[SerializeField]
		private Sprite leftIcon;

		[SerializeField]
		private GameObject leftButton;

		[SerializeField]
		private UIButton importAssetButton;

		[SerializeField]
		private UIButton importLibraryButton;

		[SerializeField]
		private Sprite lockIcon;

		private Color redColor;

		[SerializeField]
		private Sprite greenEyeIcon;

		private Color greenColor;

		private ElementListContainer assetListContainer;

		private List<UIButton> assetLockButtonsList;

		public Transform containerLockButtons;

		public GameObject lockButton;

		public ScrollRect assetScrollRect;

		private Asset currentActiveAsset;

		private Asset lastAssetSelected;

		private List<string> existingAssetNames;

		private AssetType[] appAssetTypes;

		private AssetListConverter converter;

		public override void Init()
		{
		}

		private void InitAssetListButtons()
		{
		}

		public override void AppStart()
		{
		}

		private void RefreshAssetCreationButtons()
		{
		}

		private void CheckLastAssetSelected()
		{
		}

		public override void AppStop()
		{
		}

		public override void OnSetGadget(Gadget gadget)
		{
		}

		private void OnAssetChange(Asset asset)
		{
		}

		public void ImportAsset(Asset asset)
		{
		}

		public void AddNewAsset(Asset asset)
		{
		}

		private void SelectAsset(Asset asset, bool instantiate = false)
		{
		}

		private void DeselectAsset()
		{
		}

		public void CreateNewAsset(AssetType assetType, UIButton openModalButton)
		{
		}

		public void OnCreationNameFound(AssetType assetType, string name)
		{
		}

		private void OnElementSelected(int assetIndex)
		{
		}

		private void OnElementDoubleClicked(int assetIndex)
		{
		}

		private void RefreshAssets()
		{
		}

		private void OnFileModalClosed()
		{
		}

		private void LoadAssets()
		{
		}

		private void ResetAssets()
		{
		}

		private void ClearAssetList()
		{
		}

		private void AddAssetButtons(Dictionary<uint, Asset> assets)
		{
		}

		private void OnScrollRectValueChanged(Vector2 normalizedPosition)
		{
		}

		private void SetRemoteGadgetLocks(UIButton button)
		{
		}

		private void SetLocalGadgetLocks(UIButton button)
		{
		}

		private void OnLockButtonClicked(UIButton button)
		{
		}

		private void InstantiateAssetInspectors(AssetType type)
		{
		}

		public void EditAsset()
		{
		}

		public void DeleteAsset()
		{
		}

		public void RenameAsset(string newName)
		{
		}

		public void Duplicate(string newName)
		{
		}

		public void Export(string name)
		{
		}

		private void DestroyCurrentAssetInspector()
		{
		}

		public void ImportAsset()
		{
		}

		public void ImportLibrary()
		{
		}

		public void RefreshExistingNamesList()
		{
		}

		private void OnAssetSelected(AssetType assetType, string path, string originalFileName, string assetChosenName)
		{
		}

		private void OnAssetImportComplete(AssetType assetType, string path, string originalFileName, string assetChosenName, Asset[] additionalInitAssets = null)
		{
		}

		private void OnLibraryImported(LibsController.Lib library)
		{
		}

		private void OnDuplicateConfirm(bool confirm, List<Asset> libAssets)
		{
		}

		private void ResetAssetButtons()
		{
		}

		public string GetId(Asset asset)
		{
			return null;
		}

		public void OnAssetAddedToContainer(AssetContainer container, AssetSelector assetSelector)
		{
		}

		public void OnAssetRemovedFromContainer(AssetContainer container, AssetSelector assetSelector)
		{
		}

		public override void OnSolderModule(Module module)
		{
		}

		public override void OnUnsolderModule(Module module)
		{
		}

		private void OnSecurityChipMoved(bool addSecurityChip)
		{
		}
	}
}
