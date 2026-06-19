using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]
public class MeleeWeaponAuthoring : MonoBehaviour
{
	public bool disable;

	public float baseHitColliderSize = 1.5f;

	public float extraHitColliderReachSize;

	public string overrideAnimation;

	public bool quickHit;

	[FormerlySerializedAs("isBigWeapon")]
	public bool isBigSpearWeapon;

	public bool isBigSwingWeapon;

	public bool skipAnticipationAnimation;

	public float lungeForce;

	public bool tileDamageAOE;

	public AttackFXType attackFXType;

	[ShowIf("attackFXType", AttackFXType.Arc)]
	public ArcAngle arcAngle = ArcAngle.arc90;
}
