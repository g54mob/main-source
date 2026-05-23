using UnityEngine;

public class Coin : MonoBehaviour
{
	public Transform mesh;

	public float maxSpeed = 20f;

	public float accelerationTime = 1f;

	public AnimationCurve accelerationCurve;

	public float spawnAnimationDuration = 1f;

	public float spawnAnimationScale = 10f;

	public AnimationCurve spawnAnimationCurve;

	public bool groundOnSpawn;

	public LayerMask groundLayer;

	public Vector3 groundingOffset;

	public bool registerInTagManager;

	public GameObject onPickUpParticles;

	private PlayerInteraction target;

	private Vector3 targetOffset = Vector3.up * 2f;

	private float pickupRange = 0.1f;

	private float spawnAnimationClock;

	private Vector3 initialPosition;

	private float accelerationClock;

	private bool grounded;

	private Vector3 groundingPos;

	private float groundingVelocity;

	private bool particlesSpawned;

	public bool IsFree => target == null;

	private void Start()
	{
		mesh.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		initialPosition = base.transform.position;
		if (groundOnSpawn)
		{
			if (Physics.Raycast(new Ray(base.transform.position, Vector3.down), out var hitInfo, float.PositiveInfinity, groundLayer))
			{
				groundingPos = hitInfo.point + groundingOffset;
				initialPosition = groundingPos;
			}
			else
			{
				grounded = true;
			}
		}
		if (registerInTagManager && (bool)TagManager.instance)
		{
			TagManager.instance.freeCoins.Add(this);
		}
		if ((bool)TagManager.instance)
		{
			TagManager.instance.coins.Add(this);
		}
	}

	private void Update()
	{
		mesh.Rotate(45f * Time.deltaTime, 120f * Time.deltaTime, 0f, Space.World);
		if (groundOnSpawn && !grounded)
		{
			groundingVelocity += 9.81f * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, groundingPos, groundingVelocity);
			if (Vector3.Distance(base.transform.position, groundingPos) < 0.05f)
			{
				base.transform.position = groundingPos;
				grounded = true;
			}
		}
		else if (spawnAnimationClock < spawnAnimationDuration)
		{
			spawnAnimationClock += Time.deltaTime;
			base.transform.position = initialPosition + Vector3.up * spawnAnimationScale * spawnAnimationCurve.Evaluate(spawnAnimationClock / spawnAnimationDuration);
		}
		else
		{
			if (!target)
			{
				return;
			}
			accelerationClock += Time.deltaTime;
			Vector3 vector = target.transform.position + targetOffset;
			base.transform.position = Vector3.MoveTowards(base.transform.position, vector, maxSpeed * Time.deltaTime * accelerationCurve.Evaluate(accelerationClock / accelerationTime));
			if (!particlesSpawned && Vector3.Distance(vector, base.transform.position) < 3f)
			{
				if (onPickUpParticles != null)
				{
					Object.Instantiate(onPickUpParticles, vector, Quaternion.identity, target.transform);
				}
				particlesSpawned = true;
			}
			if (Vector3.Distance(vector, base.transform.position) < pickupRange)
			{
				target.AddCoin();
				if (PerkManager.instance.HealingGoldEquipped)
				{
					PlayerMovement.instance.Hp.Heal(PerkManager.instance.healingGoldHealAmount * PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer);
				}
				ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.CoinCollect);
				Object.Destroy(base.gameObject);
			}
		}
	}

	public void SetTarget(PlayerInteraction target)
	{
		this.target = target;
	}

	private void OnDestroy()
	{
		if (registerInTagManager && (bool)TagManager.instance)
		{
			TagManager.instance.freeCoins.Remove(this);
		}
		if ((bool)TagManager.instance)
		{
			TagManager.instance.coins.Remove(this);
		}
	}
}
