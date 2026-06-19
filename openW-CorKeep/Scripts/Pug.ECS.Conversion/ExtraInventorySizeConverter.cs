using Pug.Conversion;

public class ExtraInventorySizeConverter : SingleAuthoringComponentConverter<ExtraInventorySizeAuthoring>
{
	protected override void Convert(ExtraInventorySizeAuthoring authoring)
	{
		AreaLevelAuthoring component;
		int num = ((!TryGetActiveComponent<AreaLevelAuthoring>(authoring, out component)) ? 1 : component.level);
		int sizeFromLevel = ExtraInventorySizeAuthoring.GetSizeFromLevel(num);
		int sizeFromLevel2 = ExtraInventorySizeAuthoring.GetSizeFromLevel(num + 1);
		AddComponentData(new ExtraInventoryCD
		{
			size = authoring.sameSizeForAllLevels.GetOrDefault(sizeFromLevel),
			nextLevelSize = authoring.sameSizeForAllLevels.GetOrDefault(sizeFromLevel2),
			categoryTagsMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.canOnlyContainObjectsWithCategoryTags),
			isPouch = authoring.isPouch
		});
	}
}
