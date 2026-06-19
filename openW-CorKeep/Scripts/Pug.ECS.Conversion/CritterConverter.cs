using Pug.Conversion;

public class CritterConverter : SingleAuthoringComponentConverter<CritterAuthoring>
{
	protected override void Convert(CritterAuthoring authoring)
	{
		SetProperty("isCritter");
		if (authoring.isFlying)
		{
			SetProperty("Critter/isFlying");
		}
		if (authoring.spawnContinuously)
		{
			SetProperty("Critter/spawnContinuously");
		}
		if (authoring.spawnType == SpawnType.Biome && authoring.biomesToSpawnIn.Count > 0)
		{
			SetPropertyList("Critter/biomesToSpawnIn", authoring.biomesToSpawnIn.ToArray());
		}
		else
		{
			SetPropertyList("Critter/biomesToSpawnIn", new Biome[1]);
		}
		if (authoring.spawnType == SpawnType.Tileset && authoring.tilesetsToSpawnIn.Count > 0)
		{
			SetPropertyList("Critter/tilesetsToSpawnIn", authoring.tilesetsToSpawnIn.ToArray());
		}
		EnsureHasComponent<CritterCD>();
		if (authoring.isPersistent)
		{
			EnsureHasComponent<IsPersistentCritterCD>();
		}
		else
		{
			EnsureHasComponent<DontSerializeCD>();
		}
		if (authoring.allowLargerAmount)
		{
			EnsureHasComponent<AllowLargerAmount>();
		}
	}
}
