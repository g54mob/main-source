using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class DynamicOverlayLibrary : OverlayLibrary
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

		public void UpdateDynamicOverlayLibrary(int? nameHash = null)
		{
		}

		public void UpdateDynamicOverlayLibrary(string overlayName)
		{
		}

		private void AddOverlayAssets(OverlayDataAsset[] overlays)
		{
		}

		public override OverlayData InstantiateOverlay(string name)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(int nameHash)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(string name, Color color)
		{
			return null;
		}

		public override OverlayData InstantiateOverlay(int nameHash, Color color)
		{
			return null;
		}

		public string GetOriginatingAssetBundle(string overlayName)
		{
			return null;
		}
	}
}
