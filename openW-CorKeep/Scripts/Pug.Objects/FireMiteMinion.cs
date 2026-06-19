using Pug.Sprite;
using PugTilemap;

public class FireMiteMinion : MinionBase
{
	public ParticleEffectSpawner FireTrail;

	public ParticleEffectSpawner PitWalkTrail;

	private readonly int m_FireOnEvent = SpriteAsset.StringToHash("fireOn");

	private readonly int m_FireOffEvent = SpriteAsset.StringToHash("fireOff");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		PitWalkTrail.enabled = false;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_FireOnEvent == hash)
		{
			FireTrail.enabled = true;
		}
		if (m_FireOffEvent == hash)
		{
			FireTrail.enabled = false;
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.TryGetComponentData<CurrentTileCD>(base.entity, base.world, out var value))
		{
			ParticleEffectSpawner pitWalkTrail = PitWalkTrail;
			TileType tileType = value.TileType;
			pitWalkTrail.enabled = tileType == TileType.pit || tileType == TileType.water;
		}
	}
}
