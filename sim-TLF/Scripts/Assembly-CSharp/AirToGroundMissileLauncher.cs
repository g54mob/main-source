using System.Collections;
using MyBox;
using UnityEngine;

public class AirToGroundMissileLauncher : MonoBehaviour
{
	[Header("Shoot Audio")]
	[SerializeField]
	private AudioSource _shootSource;

	[SerializeField]
	private AudioClip[] _shots;

	[Header("Ракета")]
	public GameObject missilePrefab;

	public Transform launchPoint;

	[Header("Серія")]
	public int missilesPerSalvo = 4;

	public float salvoMissileInterval = 0.3f;

	public float salvoCooldown = 8f;

	[Header("Розкид серії")]
	[Tooltip("Серія накриває зону від -spread/2 до +spread/2 вздовж курсу гравця")]
	public float salvoSpread = 20f;

	[Tooltip("Випадковий розкид на кожну ракету (метри)")]
	public float randomSpread = 8f;

	[Header("Умови пуску")]
	public float fireTriggerRadius = 25f;

	public float minFireAltitude = 50f;

	[Header("Діагностика")]
	public bool showDebugLog = true;

	[SerializeField]
	private bool _showDebugGUI;

	private Rigidbody rb;

	private Transform playerTransform;

	private Rigidbody playerRb;

	private float cooldownTimer;

	private bool salvoRunning;

	private float lastHorizDist = -1f;

	private float lastAlt = -1f;

	private bool lastHasPoint;

	public Vector3 LaunchOrigin
	{
		get
		{
			if (!(launchPoint != null))
			{
				return base.transform.position;
			}
			return launchPoint.position;
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		if (gameObject != null)
		{
			playerTransform = gameObject.transform;
			playerRb = gameObject.GetComponent<Rigidbody>();
		}
		else
		{
			Debug.LogError("[MissileLauncher] Player не знайдено!");
		}
		if (missilePrefab == null)
		{
			Debug.LogError("[MissileLauncher] missilePrefab не призначено!");
		}
	}

	private void Update()
	{
		if (cooldownTimer > 0f)
		{
			cooldownTimer -= Time.deltaTime;
		}
	}

	public void TryFire(Vector3 firePoint, bool hasPoint)
	{
		TryFireAndReport(firePoint, hasPoint);
	}

	public bool TryFireAndReport(Vector3 firePoint, bool hasPoint)
	{
		lastHasPoint = hasPoint;
		if (!hasPoint || cooldownTimer > 0f || salvoRunning || playerTransform == null)
		{
			return false;
		}
		Vector3 vector = LaunchOrigin - firePoint;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float num = LaunchOrigin.y - playerTransform.position.y;
		lastHorizDist = magnitude;
		lastAlt = num;
		if (showDebugLog)
		{
			Debug.Log($"[MissileLauncher] horizDist={magnitude:F1}m  alt={num:F1}m");
		}
		if (magnitude < fireTriggerRadius && num > minFireAltitude)
		{
			StartCoroutine(FireSalvo());
			cooldownTimer = salvoCooldown;
			return true;
		}
		return false;
	}

	private IEnumerator FireSalvo()
	{
		salvoRunning = true;
		for (int i = 0; i < missilesPerSalvo; i++)
		{
			LaunchMissile(i);
			if (i < missilesPerSalvo - 1)
			{
				yield return new WaitForSeconds(salvoMissileInterval);
			}
		}
		salvoRunning = false;
	}

	private void LaunchMissile(int index)
	{
		if (missilePrefab == null || playerTransform == null)
		{
			return;
		}
		float t = ((missilesPerSalvo > 1) ? ((float)index / (float)(missilesPerSalvo - 1)) : 0.5f);
		float num = Mathf.Lerp((0f - salvoSpread) * 0.5f, salvoSpread * 0.5f, t);
		Vector3 vector = ((playerRb != null) ? playerRb.linearVelocity : Vector3.zero);
		Vector3 vector2 = ((vector.sqrMagnitude > 0.1f) ? vector.normalized : base.transform.forward);
		Vector3 vector3 = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * Random.Range(0f, randomSpread);
		Vector3 vector4 = playerTransform.position + vector2 * num + vector3;
		vector4.y = playerTransform.position.y;
		if (CalculateLaunchVelocity(LaunchOrigin, vector4, out var velocity))
		{
			_shootSource.pitch += 1f + Random.Range(-0.15f, 0.15f);
			_shootSource.PlayOneShot(_shots.GetRandom());
			Rigidbody component = Object.Instantiate(missilePrefab, LaunchOrigin, Quaternion.identity).GetComponent<Rigidbody>();
			if (component != null)
			{
				component.linearVelocity = velocity;
			}
			Debug.Log($"[MissileLauncher] Ракета #{index + 1}  target={vector4}  speed={velocity.magnitude:F1}m/s");
		}
	}

	private bool CalculateLaunchVelocity(Vector3 origin, Vector3 target, out Vector3 velocity)
	{
		velocity = rb.linearVelocity;
		float num = Mathf.Abs(Physics.gravity.y);
		float num2 = target.y - origin.y;
		Vector3 vector = target - origin;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		if (magnitude < 0.1f)
		{
			return false;
		}
		float num3 = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).magnitude;
		if (num3 < 1f)
		{
			num3 = 50f;
		}
		float num4 = magnitude / num3;
		if (num4 < 0.05f)
		{
			return false;
		}
		float num5 = (num2 + 0.5f * num * num4 * num4) / num4;
		Vector3 vector2 = vector / magnitude;
		velocity = vector2 * num3 + Vector3.up * num5;
		return true;
	}

	public void ResetTimer()
	{
		cooldownTimer = 0f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(LaunchOrigin, 1.5f);
	}
}
