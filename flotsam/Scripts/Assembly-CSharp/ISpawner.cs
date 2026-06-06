using PajamaLlama.Flotsam.World;
using UnityEngine;

public interface ISpawner
{
	ISpawnerType Type { get; }

	Sprite Icon { get; }

	WorldTile WorldTile { get; }

	Vector3 WorldPosition { get; }

	Vector2 WorldPosition2D { get; }

	Vector2 TilePosition { get; }

	WorldRegionType RegionType { get; }

	ScoutingState ScoutingState { get; }

	Sprite BearingIcon => null;

	WorldMapScoutingId ScoutingId => WorldMapScoutingId.None;

	string Name { get; }

	ISpawnerEvent UpdatedEvent { get; }

	void Initialize();

	bool Despawn(bool destroyInstance);

	void Move(Vector3 movement);

	void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation);

	void CountItems(InventoryAuditor auditor);

	void SetScoutingState(ScoutingState scoutingState)
	{
	}

	void ClearFogOfWar()
	{
		WorldManager.ClearFogOfWar(this);
	}
}
