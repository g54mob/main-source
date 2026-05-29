using UnityEngine;

public class GunShoot : MonoBehaviour
{
	public float fireRate;

	public float weaponRange;

	public Transform gunEnd;

	public ParticleSystem muzzleFlash;

	public ParticleSystem cartridgeEjection;

	public GameObject metalHitEffect;

	public GameObject sandHitEffect;

	public GameObject stoneHitEffect;

	public GameObject waterLeakEffect;

	public GameObject waterLeakExtinguishEffect;

	public GameObject[] fleshHitEffects;

	public GameObject woodHitEffect;

	private float nextFire;

	private Animator anim;

	private GunAim gunAim;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void HandleHit(RaycastHit hit)
	{
	}

	private void SpawnDecal(RaycastHit hit, GameObject prefab)
	{
	}
}
