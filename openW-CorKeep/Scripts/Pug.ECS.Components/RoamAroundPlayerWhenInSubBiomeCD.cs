using PugTilemap;
using Unity.Entities;

public struct RoamAroundPlayerWhenInSubBiomeCD : IComponentData, IQueryTypeParameter
{
	public Tileset subBiomeTileset;

	public TickTimer newPathCooldown;

	public bool wasRaomingAroundPlayer;
}
