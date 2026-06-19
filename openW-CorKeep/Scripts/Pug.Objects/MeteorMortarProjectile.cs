using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class MeteorMortarProjectile : BasicMortarProjectile
{
	[SerializeField]
	private ParticleSystem riftFX;

	[SerializeField]
	private ParticleSystem eruptionFX;

	[SerializeField]
	private Light _light;

	[SerializeField]
	private AnimationCurve _lightIntensityCurveBySeconds;

	private TimerSimple _lightTimer;

	[SerializeField]
	private SFXTableIDField spawnSFX;

	[SerializeField]
	private SFXTableIDField impactSFX;

	[SerializeField]
	private Transform dropShadow;

	protected override bool hideDirectlyOnDeath => false;

	protected override void Awake()
	{
		base.Awake();
		_light.intensity = 0f;
	}

	protected override void OnStartGoDown()
	{
		if (Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.pit))
		{
			dropShadow.gameObject.SetActive(value: false);
		}
		else
		{
			dropShadow.gameObject.SetActive(value: true);
		}
		riftFX.Play(withChildren: true);
		AudioManager.Sfx(spawnSFX.value, base.transform.position);
		_lightTimer.Start();
	}

	protected override void OnExplode()
	{
		if (!Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.pit))
		{
			if (Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.water))
			{
				WaterSim.AddImpulse(base.transform.position, 3f, 12f);
				Manager.effects.PlayPuff(PuffID.WaterSplashMist, base.transform.position, 2);
				Manager.effects.PlayPuff(PuffID.WaterImpact, base.transform.position, 1);
				AudioManager.Sfx(impactSFX.value, base.transform.position);
			}
			else
			{
				WaterSim.AddImpulse(base.transform.position, 2f, 10f);
				eruptionFX.Play(withChildren: true);
				AudioManager.Sfx(impactSFX.value, base.transform.position);
			}
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		_light.intensity = _lightIntensityCurveBySeconds.Evaluate(_lightTimer.elapsedTime);
	}
}
