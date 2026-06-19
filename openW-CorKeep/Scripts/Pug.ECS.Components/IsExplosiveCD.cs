using Unity.Entities;

public struct IsExplosiveCD : IComponentData, IQueryTypeParameter
{
	public int damage;

	public int tileDamage;

	public ObjectID explosionID;

	public int explosionVariation;

	public bool wasKilledByAnotherExplosive;

	public bool ignoreExploding;

	public bool explosionInheritsFaction;

	public bool bombInheritsFaction;

	public bool useSmallNapalmVariant;

	public ExplosionPushbackLevel explosionPushback;
}
