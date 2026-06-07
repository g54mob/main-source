using System.Xml.Linq;
using UnityEngine;

public static class CategoriesBuilder
{
	private const string TAG_CATEGORIES = "categories";

	private const string TAG_CATEGORY = "category";

	private const string ATTR_NAME = "name";

	public static CategoriesModel CreateCategories(string path, CreationCollectionsManager collections)
	{
		CategoriesModel categoriesModel = new CategoriesModel();
		foreach (XElement item in XDocument.Load(path).Element("categories").Elements("category"))
		{
			string value = item.Attribute("name").Value;
			if (value == "Debug" && !Debug.isDebugBuild)
			{
				continue;
			}
			foreach (XElement item2 in item.Elements())
			{
				string value2 = item2.Value;
				CreationModel creationModel = collections.GetCreationModel(value2);
				categoriesModel.AddCategory(value, creationModel);
			}
		}
		LoadUserParts(categoriesModel, collections.UserCreationModelCollection);
		return categoriesModel;
	}

	private static void LoadUserParts(CategoriesModel categories, CreationModelCollection userCollection)
	{
		foreach (CreationModel allCreationModel in userCollection.GetAllCreationModels())
		{
			categories.AddCategory("User", allCreationModel);
		}
	}
}
