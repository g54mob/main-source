using Unity.Entities;
using Unity.NetCode;

public struct PingPongProjectileCD : IComponentData, IQueryTypeParameter
{
	public float pingPongDuration;

	public float speedCurveBlendValue;

	public int maxBounceCount;

	[GhostField]
	public bool shotFromReinforcedWeapon;

	public bool useSpeedCurve;

	public bool damagesTiles;

	public bool isDamageable;

	public bool hasLimitedLifespan;

	public bool mayExplodeWithWindup;

	public bool isMagic;

	public bool treatDodgeAsHit;

	public bool zigZag;

	public bool surviveCollision;

	public bool shatterOnCollision;

	public bool explodeOnEnemyCollision;
}
