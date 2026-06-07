public class LECategoriesModel : CategoriesModelBase<CustomLevelObjectsModel>
{
	protected override string GetItemFilePath(CustomLevelObjectsModel item)
	{
		return item.FilePath;
	}
}
