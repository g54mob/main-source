using System.Xml.Linq;

public static class LECategoriesBuilder
{
	private const string TAG_CATEGORIES = "categories";

	private const string TAG_CATEGORY = "category";

	private const string ATTR_NAME = "name";

	public static LECategoriesModel CreateCategories(string path, LevelPartCollectionsManager collections)
	{
		LECategoriesModel lECategoriesModel = new LECategoriesModel();
		foreach (XElement item in XDocument.Load(path).Element("categories").Elements("category"))
		{
			string value = item.Attribute("name").Value;
			foreach (XElement item2 in item.Elements())
			{
				LevelObjectModel levelObjectModel = LevelEditorUtil.LoadLevelObjectModelFromPrefab(item2.Value);
				CustomLevelObjectsModel customLevelObjectsModel = new CustomLevelObjectsModel
				{
					Id = levelObjectModel.ResourceName,
					Name = levelObjectModel.ResourceName,
					Origin = CustomLevelObjectsModel.OriginEnum.Part
				};
				customLevelObjectsModel.AddLevelObjectModel(levelObjectModel);
				lECategoriesModel.AddCategory(value, customLevelObjectsModel);
				collections.PrefabLevelPartsCollection.AddItem(customLevelObjectsModel);
			}
		}
		LoadUserParts(lECategoriesModel, collections);
		return lECategoriesModel;
	}

	private static void LoadUserParts(LECategoriesModel categories, LevelPartCollectionsManager collections)
	{
		foreach (CustomLevelObjectsModel allItem in collections.UserLevelPartsCollection.GetAllItems())
		{
			categories.AddCategory("User", allItem);
		}
	}
}
