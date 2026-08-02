using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
	public List<CollectableItemData> collectableDatas = new List<CollectableItemData>();

	public List<ResearchableItemData> researchItemDatas = new List<ResearchableItemData>();

	private void Start()
	{
		LoadCollectableItems();
		LoadResearcheableItems();
	}

	private void LoadCollectableItems()
	{
		collectableDatas.Clear();
		collectableDatas = Resources.LoadAll<CollectableItemData>(FilePaths.RESEOURCES_COLLECTABLE_ITEMS_DATA).ToList();
	}

	private void LoadResearcheableItems()
	{
		researchItemDatas.Clear();
		researchItemDatas = Resources.LoadAll<ResearchableItemData>(FilePaths.RESEOURCES_RESEARCHEABLE_ITEMS_DATA).ToList();
	}
}
