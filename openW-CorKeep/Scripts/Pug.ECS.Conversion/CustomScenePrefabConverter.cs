using Pug.Conversion;

public class CustomScenePrefabConverter : SingleAuthoringComponentConverter<CustomScenePrefabAuthoring>
{
	protected override void Convert(CustomScenePrefabAuthoring authoring)
	{
		EnsureHasComponent<CustomScenePrefab>();
	}
}
