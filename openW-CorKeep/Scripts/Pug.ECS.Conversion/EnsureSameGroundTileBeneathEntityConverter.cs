using Pug.Conversion;
using PugTilemap;

public class EnsureSameGroundTileBeneathEntityConverter : SingleAuthoringComponentConverter<EnsureSameGroundTileBeneathEntityAuthoring>
{
	protected override void Convert(EnsureSameGroundTileBeneathEntityAuthoring authoring)
	{
		AddComponentData(new EnsureSameGroundTileBeneathEntityCD
		{
			tileType = authoring.tileType,
			fallbackTileset = authoring.fallbackTileset,
			continouslyCheck = authoring.continouslyCheck,
			ignoreCheckingWhileInState = authoring.ignoreCheckingWhileInState,
			stateToIgnore = authoring.stateToIgnore
		});
		EnsureHasBuffer<SupportsGroundTilesetsBuffer>();
		foreach (Tileset onlySupportsTileset in authoring.onlySupportsTilesets)
		{
			AddToBuffer(new SupportsGroundTilesetsBuffer
			{
				tileset = onlySupportsTileset
			});
		}
	}
}
