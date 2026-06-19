using Pug.Conversion;
using UnityEngine;

public class CrackableTileConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (TryGetActiveComponent<TileAuthoring>(authoring, out var component) && TryGetActiveComponent<CrackableTileAuthoring>(authoring, out var component2))
		{
			AddComponentData(new CrackableTileCD
			{
				crackTileType = component2.crackTileType,
				crackTileset = component2.crackTileset,
				baseTileType = component.tileType
			});
			EnsureHasComponent<ActiveCracksCD>(componentIsEnabled: false);
		}
	}
}
