using UnityEngine;

[CreateAssetMenu(menuName = "Ferry/Spawn Position Providers/Activate Spawn Position Provider")]
public class ActivateSpawnPositionProvider : SpawnPositionProviderBase
{
	private GameplaySettings _settings;

	public override void Initialize(GameplaySettings settings, Vector3 current)
	{
		_settings = settings;
	}

	public override Vector3 ReturnInitialSpawnPosition(bool outsideConstructionRadius)
	{
		float range = (float)_settings.MapRadius - _settings.SpawnRadiusDeviation;
		float clearRadius = (outsideConstructionRadius ? ((float)_settings.ConstructionRadius) : 0f);
		return FlotsamGame.RandomPosition(Vector3.zero, range, useGaussian: false, clearRadius);
	}

	public override Vector3 ReturnSpawnPosition()
	{
		float range = (float)_settings.MapRadius - _settings.SpawnRadiusDeviation;
		return FlotsamGame.RandomPosition(Vector3.zero, range, useGaussian: false);
	}
}
