using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem.Examples
{
	public class WardrobeCollectionLibrary : MonoBehaviour
	{
		public static WardrobeCollectionLibrary Instance;

		public Dictionary<string, UMAWardrobeCollection> collectionIndex;

		public List<UMAWardrobeCollection> collectionList;

		public bool initializeOnAwake;

		public bool makePersistent;

		[NonSerialized]
		[HideInInspector]
		public bool initialized;

		private bool updating;

		public bool dynamicallyAddFromResources;

		[Tooltip("Limit the Resources search to the following folders (no starting slash and seperate multiple entries with a comma)")]
		public string resourcesCollectionsFolder;

		public bool dynamicallyAddFromAssetBundles;

		[Tooltip("Limit the AssetBundles search to the following bundles (no starting slash and seperate multiple entries with a comma)")]
		public string assetBundlesForCollectionsToSearch;

		[Space]
		[Tooltip("If true will store the download status of any collections in playerPrefs. Downloaded collections are immediately added to DynamicCharacterSystem libraries and remain available to your characters across sessions.")]
		public bool storeDownloadedStatus;

		[HideInInspector]
		public UMAContextBase context;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Init()
		{
		}

		public void AddCollectionsFromDAL(UMAWardrobeCollection[] uwcs)
		{
		}

		public void AddCollections(UMAWardrobeCollection[] uwcs, string filename = "")
		{
		}
	}
}
