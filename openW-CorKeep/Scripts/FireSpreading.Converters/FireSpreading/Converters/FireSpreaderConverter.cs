using FireSpreading.Authoring;
using Pug.Conversion;
using Unity.Mathematics;

namespace FireSpreading.Converters
{
	public class FireSpreaderConverter : SingleAuthoringComponentConverter<FireSpreaderAuthoring>
	{
		protected override void Convert(FireSpreaderAuthoring authoring)
		{
			ObjectInfo objectInfo;
			if (authoring.TryGetComponent<EntityMonoBehaviourData>(out var component))
			{
				objectInfo = component.ObjectInfo;
			}
			else
			{
				if (!authoring.TryGetComponent<ObjectAuthoring>(out var component2))
				{
					return;
				}
				objectInfo = component2.ObjectInfo;
			}
			((Converter)this).EnsureHasComponent<FireSpreaderCD>();
			((Converter)this).AddComponentData<PrefabTileSizeOptionalCD>(new PrefabTileSizeOptionalCD
			{
				prefabCornerOffset = new int2(objectInfo.prefabCornerOffset.x, objectInfo.prefabCornerOffset.y),
				prefabTileSize = new int2(objectInfo.prefabTileSize.x, objectInfo.prefabTileSize.y)
			});
		}
	}
}
