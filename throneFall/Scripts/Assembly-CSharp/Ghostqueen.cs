using System.Collections;
using Pathfinding;
using UnityEngine;

public class Ghostqueen : MonoBehaviour
{
	[SerializeField]
	private NightLight nightLight;

	[SerializeField]
	private Color nichtLightColor;

	[SerializeField]
	private Color directionalLightColor;

	private Light nightLightCache;

	[SerializeField]
	private Spawn waveToSpawn;

	[SerializeField]
	private Light directionalLight;

	[SerializeField]
	private float directionalLightFlickerSpeed = 0.25f;

	private NNConstraint nearestConstraint = new NNConstraint();

	private Seeker seeker;

	[SerializeField]
	private GameObject fireBolt;

	[SerializeField]
	private AutoAttack autoAttack;

	[SerializeField]
	private MovementFollowPath followPath;

	[SerializeField]
	private AudioSource specialAttackAudio;

	[SerializeField]
	private ParticleSystem specialAttackParticles;

	[SerializeField]
	private AutoAttack aaFireStorm;

	[SerializeField]
	private Transform transFireStorm;

	[SerializeField]
	private Transform transFireStormParticles;

	[SerializeField]
	private AutoAttack aaFireSpray;

	[SerializeField]
	private AudioSource fireStormAudio;

	[Header("Balancing")]
	[SerializeField]
	private float fireStormDuration = 10f;

	[SerializeField]
	private float fireBoltPreDelay = 3f;

	[SerializeField]
	private float fireBoltInterval = 0.33f;

	[SerializeField]
	private int fireBoltCount = 14;

	[SerializeField]
	private float fireBoltAfterDelay = 2f;

	[SerializeField]
	private float fireSprayDuration = 10f;

	private float nightLightIntensity;

	private float fireTargetVolume;

	private void Start()
	{
		waveToSpawn.Reset();
		seeker = GetComponent<Seeker>();
		nearestConstraint.graphMask = seeker.graphMask;
		aaFireStorm.enabled = false;
		aaFireSpray.enabled = false;
		fireTargetVolume = fireStormAudio.volume;
		StartCoroutine(FullBossBehaviour());
	}

	private void Update()
	{
		if (nightLightCache == null)
		{
			nightLightCache = nightLight.GetComponent<Light>();
		}
		nightLightCache.color = nichtLightColor;
		nightLight.targetIntensity = nightLightIntensity;
		nightLightIntensity = Mathf.Lerp(1.5f, nightLightIntensity, Mathf.Pow(0.2f, Time.deltaTime));
		nightLight.transform.position = base.transform.position;
		nightLightCache.range = 150f;
		directionalLight.color = Color.Lerp(directionalLightColor, directionalLight.color, Mathf.Pow(0.5f, Time.deltaTime));
	}

	private IEnumerator FullBossBehaviour()
	{
		yield return null;
		aaFireStorm.enabled = false;
		aaFireSpray.enabled = false;
		while (true)
		{
			yield return FireStorm(fireStormDuration);
			yield return SpawnFireBolts(fireBoltInterval, fireBoltAfterDelay);
			yield return SpawnGhosts();
			yield return new WaitForSeconds(fireSprayDuration);
		}
	}

	private IEnumerator FireStorm(float duration)
	{
		aaFireSpray.enabled = false;
		transFireStorm.gameObject.SetActive(value: true);
		for (float scale = 0f; scale < 1f; scale += Time.deltaTime)
		{
			transFireStorm.localScale = scale * Vector3.one;
			transFireStormParticles.localScale = scale * Vector3.one;
			fireStormAudio.volume = fireTargetVolume * scale;
			yield return null;
		}
		transFireStorm.localScale = Vector3.one;
		fireStormAudio.volume = fireTargetVolume;
		aaFireStorm.enabled = true;
		yield return new WaitForSeconds(duration);
		aaFireStorm.enabled = false;
		for (float scale = 1f; scale > 0f; scale -= Time.deltaTime)
		{
			transFireStorm.localScale = scale * Vector3.one;
			transFireStormParticles.localScale = scale * Vector3.one;
			fireStormAudio.volume = fireTargetVolume * scale;
			yield return null;
		}
		transFireStorm.localScale = Vector3.zero;
		fireStormAudio.volume = 0f;
		transFireStorm.gameObject.SetActive(value: false);
		aaFireSpray.enabled = true;
	}

	private IEnumerator SpawnGhosts()
	{
		waveToSpawn.Reset();
		while (!waveToSpawn.Finished)
		{
			waveToSpawn.Update();
			yield return null;
		}
	}

	private IEnumerator SpawnFireBolts(float interval, float waitafter)
	{
		aaFireSpray.enabled = false;
		float rememberSpeed = followPath.speed;
		followPath.speed = 0f;
		specialAttackAudio.Play();
		specialAttackParticles.Play();
		yield return new WaitForSeconds(fireBoltPreDelay);
		followPath.speed = rememberSpeed;
		aaFireSpray.enabled = true;
		for (int i = 0; i < fireBoltCount; i++)
		{
			SpawnFireBolt(PlayerMovement.instance.transform.position + new Vector3(Random.value - 0.5f, 0f, Random.value - 0.5f) * 15f);
			yield return new WaitForSeconds(interval);
		}
		yield return new WaitForSeconds(waitafter);
	}

	private void SpawnFireBolt(Vector3 _position)
	{
		Vector3 position = AstarPath.active.GetNearest(_position, nearestConstraint).position;
		Object.Instantiate(fireBolt, position, Quaternion.identity).GetComponent<SpawnAttackAfter>().damageMultiplyer *= autoAttack.DamageMultiplyer;
	}
}
