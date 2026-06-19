using System;
using System.Collections.Generic;
using PugWorldGen;
using UnityEngine;

[Serializable]
public class WorldInfo : ISerializationCallbackReceiver
{
	public const int CURRENT_VERSION = 1;

	public int version;

	public string name = "";

	public string guid = "";

	public string seedString = "";

	public uint seed;

	public List<ObjectID> activatedCrystals = new List<ObjectID>();

	public CreationDate creationDate;

	public int iconIndex;

	public WorldMode mode;

	public int bossesKilled;

	public WorldGenerationType worldGenerationType;

	public List<LevelWorldGenerationSetting> worldGenerationSettings = new List<LevelWorldGenerationSetting>();

	public List<DataBlockAddress> viewedContentBundles = new List<DataBlockAddress>();

	[SerializeField]
	[Obsolete]
	private int nextNewContentBundle;

	[SerializeField]
	private List<DataBlockAddress> activatedContentBundleAddresses = new List<DataBlockAddress>();

	[SerializeField]
	[Obsolete]
	private List<int> activatedContentBundles = new List<int>();

	public List<DataBlockAddress> ActivatedContentBundles => activatedContentBundleAddresses;

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		if (version >= 1)
		{
			return;
		}
		Debug.Log("Convert activated content bundles for world " + name + " to new format.");
		activatedContentBundleAddresses.Clear();
		foreach (int activatedContentBundle in activatedContentBundles)
		{
			if (ContentBundleDataBlock.TryMapLegacyIDToDataBlockAddress(activatedContentBundle, out var address))
			{
				activatedContentBundleAddresses.Add(address);
			}
		}
		viewedContentBundles.Clear();
		for (int i = 0; i < nextNewContentBundle; i++)
		{
			if (ContentBundleDataBlock.TryMapLegacyIDToDataBlockAddress(i, out var address2))
			{
				viewedContentBundles.Add(address2);
			}
		}
		version = 1;
	}

	public void CopyValuesFrom(WorldInfo other)
	{
		version = other.version;
		name = other.name;
		guid = other.guid;
		seedString = other.seedString;
		seed = other.seed;
		activatedCrystals = new List<ObjectID>(other.activatedCrystals);
		creationDate = other.creationDate;
		iconIndex = other.iconIndex;
		mode = other.mode;
		bossesKilled = other.bossesKilled;
		worldGenerationType = other.worldGenerationType;
		worldGenerationSettings = new List<LevelWorldGenerationSetting>(other.worldGenerationSettings);
		viewedContentBundles = new List<DataBlockAddress>(other.viewedContentBundles);
		activatedContentBundleAddresses = new List<DataBlockAddress>(other.activatedContentBundleAddresses);
	}

	public bool HasViewedAllContentBundles()
	{
		foreach (ContentBundleDataBlock dataBlock in ScriptableData.GetDataBlocks<ContentBundleDataBlock>())
		{
			if (dataBlock.canBeActivatedByPlayer && !viewedContentBundles.Contains(dataBlock.address))
			{
				return false;
			}
		}
		return true;
	}

	public void MarkAllContentBundlesAsViewed()
	{
		foreach (ContentBundleDataBlock dataBlock in ScriptableData.GetDataBlocks<ContentBundleDataBlock>())
		{
			if (dataBlock.canBeActivatedByPlayer)
			{
				viewedContentBundles.Add(dataBlock.address);
			}
		}
	}
}
