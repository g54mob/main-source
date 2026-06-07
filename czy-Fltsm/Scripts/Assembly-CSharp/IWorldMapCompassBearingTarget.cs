using UnityEngine;

public interface IWorldMapCompassBearingTarget
{
	Vector3 WorldPosition { get; }

	Sprite BearingIcon { get; }

	BearingFeatures BearingFeatures { get; }

	bool IsBearingActive();

	bool IsBearingTo(WorldMapScoutingId scoutingId);

	bool IsBearingTo(ISpawner spawner);
}
