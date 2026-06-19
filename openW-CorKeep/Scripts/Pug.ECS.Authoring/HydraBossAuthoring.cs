using UnityEngine;

[DisallowMultipleComponent]
public class HydraBossAuthoring : MonoBehaviour
{
	public HydraBossType hydraType;

	public GameObject vulnerableEntityPrefab;

	[Header("Buried state")]
	public float buryDuration;

	public float unearthDuration;

	public float buriedMinCooldown;

	public float buriedMaxCooldown;

	public int buriedAppearDamage;

	public float buriedAppearDamageMultiplier;

	[Header("Damage")]
	public int beamDamage;

	public float beamDamageMultiplier;

	public int stalactiteMortarDamage;

	public float stalactiteMortarDamageMultiplier;

	public int shockwaveDamage;

	public float shockwaveDamageMultiplier;

	public int iceShardMortarDamage;

	public float iceShardMortarDamageMultiplier;

	public int lavaMortarDamage;

	public float lavaMortarDamageMultiplier;

	public int nilipedeMortarDamage;

	public float nilipedeMortarDamageMultiplier;
}
