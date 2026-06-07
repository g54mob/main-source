using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class DynamicSlotLibrary : SlotLibrary
	{
		public bool dynamicallyAddFromResources;

		[Tooltip("Limit the Resources search to the following folders (no starting slash and seperate multiple entries with a comma)")]
		public string resourcesFolderPath;

		public bool dynamicallyAddFromAssetBundles;

		[Tooltip("Limit the AssetBundles search to the following bundles (no starting slash and seperate multiple entries with a comma)")]
		public string assetBundleNamesToSearch;

		public Dictionary<string, List<string>> assetBundlesUsedDict;

		[NonSerialized]
		[HideInInspector]
		public bool downloadAssetsEnabled;

		public void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void ClearEditorAddedAssets()
		{
		}

		public void UpdateDynamicSlotLibrary(int? nameHash = null)
		{
		}

		public void UpdateDynamicSlotLibrary(string slotName)
		{
		}

		private void AddSlotAssets(SlotDataAsset[] slots)
		{
		}

		public override SlotData InstantiateSlot(string name)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash)
		{
			return null;
		}

		public override SlotData InstantiateSlot(string name, List<OverlayData> overlayList)
		{
			return null;
		}

		public override SlotData InstantiateSlot(int nameHash, List<OverlayData> overlayList)
		{
			return null;
		}

		public string GetOriginatingAssetBundle(string slotName)
		{
			return null;
		}
	}
}
