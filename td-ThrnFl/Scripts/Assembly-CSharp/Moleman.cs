using System;
using System.Collections;
using UnityEngine;

public class Moleman : MonoBehaviour
{
	private PathfindMovementEnemy enemyMovement;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float nextTeleportIn = 3f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float teleportIntervalMin = 6f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float teleportIntervalMax = 6f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	[Range(0f, 1f)]
	private float teleportTowardsTargetAmount = 0.5f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float targetDistanceMin = 0.5f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float targetDistanceMax = 20f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float maxTunnelingDistance = 20f;

	[SerializeField]
	private Transform aliveParent;

	[SerializeField]
	private GameObject meshParent;

	[SerializeField]
	private AutoAttack autoAttack;

	[SerializeField]
	private float digDepth = 2.5f;

	[SerializeField]
	private GameObject spawnOnDigDown;

	[SerializeField]
	private GameObject spawnOnDigUp;

	[SerializeField]
	private ParticleSystem digDownFX;

	[SerializeField]
	private ParticleSystem digUpFX;

	[SerializeField]
	private AudioSource digAudioSource;

	[SerializeField]
	private Vector2 digAudioPitchRange = new Vector2(1f, 1f);

	[SerializeField]
	private float animationSpeed = 2f;

	[SerializeField]
	private float digTrevelingSpeed = 2f;

	private bool lastInAnim;

	private bool teleportAnimRunning;

	private void Start()
	{
		enemyMovement = GetComponent<PathfindMovementEnemy>();
	}

	private void Update()
	{
		if (!teleportAnimRunning)
		{
			nextTeleportIn -= Time.deltaTime;
			if (nextTeleportIn <= 0f)
			{
				nextTeleportIn = Mathf.Lerp(teleportIntervalMin, teleportIntervalMax, UnityEngine.Random.value);
				StartCoroutine(TeleportAnimation());
			}
		}
	}

	private IEnumerator TeleportAnimation()
	{
		teleportAnimRunning = true;
		autoAttack.enabled = false;
		InstantiateHere(spawnOnDigDown);
		if ((bool)digDownFX)
		{
			digDownFX.Play();
		}
		for (float t = 1f; t > 0f; t -= Time.deltaTime * animationSpeed)
		{
			DigAnimation(t);
			yield return null;
		}
		Vector3 targetPos = Vector3.Lerp(base.transform.position, enemyMovement.SeekToTargetPosSnappedtoNavmesh, teleportTowardsTargetAmount);
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		float num = UnityEngine.Random.Range(targetDistanceMin, targetDistanceMax);
		Vector3 vector = new Vector3(Mathf.Cos(f) * num, 0f, Mathf.Sin(f) * num);
		targetPos += vector;
		targetPos = base.transform.position + (targetPos - base.transform.position).normalized * Mathf.Min((targetPos - base.transform.position).magnitude, maxTunnelingDistance);
		meshParent.SetActive(value: false);
		Vector3 startPos = base.transform.position;
		targetPos = enemyMovement.GetNearestGroundPosition(targetPos);
		float distance = (startPos - targetPos).magnitude;
		for (float t = 0f; t < 1f; t += Time.deltaTime * digTrevelingSpeed / distance)
		{
			base.transform.position = Vector3.Lerp(startPos, targetPos, t);
			yield return null;
		}
		base.transform.position = targetPos;
		meshParent.SetActive(value: true);
		InstantiateHere(spawnOnDigUp);
		if ((bool)digUpFX)
		{
			digUpFX.Play();
		}
		if ((bool)digAudioSource)
		{
			digAudioSource.pitch = UnityEngine.Random.Range(digAudioPitchRange.x, digAudioPitchRange.y);
			digAudioSource.PlayOneShot(digAudioSource.clip);
		}
		for (float t = 0f; t < 1f; t += Time.deltaTime * animationSpeed)
		{
			DigAnimation(t);
			yield return null;
		}
		enemyMovement.OriginalPathRequest();
		aliveParent.localRotation = Quaternion.identity;
		aliveParent.localPosition = Vector3.zero;
		teleportAnimRunning = false;
		autoAttack.enabled = true;
	}

	private void DigAnimation(float _t)
	{
		enemyMovement.ClearCurrentPath();
		aliveParent.localRotation = Quaternion.Euler(0f, _t * 1000f, 0f);
		float num = (1f - _t) * (_t - 0.3f) * 3.333f;
		aliveParent.localPosition = new Vector3(0f, num * digDepth, 0f);
	}

	private void InstantiateHere(GameObject _go)
	{
		if ((bool)_go)
		{
			FireArcherBurn component = UnityEngine.Object.Instantiate(_go, base.transform.position, Quaternion.identity).GetComponent<FireArcherBurn>();
			if ((bool)component)
			{
				component.DamageMultiplyer = GetComponent<AutoAttack>().DamageMultiplyer;
			}
		}
	}
}
