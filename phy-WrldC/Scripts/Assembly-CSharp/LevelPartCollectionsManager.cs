public class LevelPartCollectionsManager
{
	public GenericCollectionModel<CustomLevelObjectsModel> PrefabLevelPartsCollection { get; private set; }

	public GenericCollectionModel<CustomLevelObjectsModel> UserLevelPartsCollection { get; private set; }

	public LevelPartCollectionsManager()
	{
		PrefabLevelPartsCollection = new GenericCollectionModel<CustomLevelObjectsModel>();
		UserLevelPartsCollection = new GenericCollectionModel<CustomLevelObjectsModel>();
	}

	public CustomLevelObjectsModel GetCustomLevelObjectsModel(string id)
	{
		CustomLevelObjectsModel item = PrefabLevelPartsCollection.GetItem(id);
		if (item == null)
		{
			item = UserLevelPartsCollection.GetItem(id);
		}
		return item;
	}
}
