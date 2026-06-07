public class CategoriesModel : CategoriesModelBase<CreationModel>
{
	protected override string GetItemFilePath(CreationModel item)
	{
		return item.FilePath;
	}
}
