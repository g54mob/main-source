using Unity.Entities;

public struct MeleeWeaponCD : IComponentData, IQueryTypeParameter
{
	public float baseHitColliderSize;

	public float extraHitColliderReachSize;

	public int overrideAnimation;

	public bool quickHit;

	public bool isBigSpearWeapon;

	public bool isBigSwingWeapon;

	public bool skipAnticipationAnimation;

	public float lungeForce;

	public bool tileDamageAOE;

	public AttackFXType attackFXType;

	public ArcAngle arcAngle;

	public bool colliderCenteredOnWindup;
}
