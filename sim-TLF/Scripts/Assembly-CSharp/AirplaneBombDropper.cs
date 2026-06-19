using System.Collections;
using UnityEngine;

public class AirplaneBombDropper : MonoBehaviour
{
	[Header("Бомба")]
	public GameObject bombPrefab;

	public Transform dropPoint;

	[Header("Серія")]
	public int bombsPerSalvo = 4;

	public float salvoBombInterval = 0.3f;

	public float bombCooldown = 8f;

	[Header("Розкид серії")]
	[Tooltip("Бомби розкидані вздовж курсу (метри між крайніми)")]
	public float salvoSpread = 30f;

	[Tooltip("Випадковий бічний розкид")]
	public float randomSpread = 5f;

	[Header("Умови скидання")]
	public float dropTriggerRadius = 25f;

	public float minDropAltitude = 50f;

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

	[HideInInspector]
	public Vector3 BallisticDropWaypoint;

	[HideInInspector]
	public bool BallisticDropReady;

	public Vector3 DropOrigin
	{
		get
		{
			if (!(dropPoint != null))
			{
				return base.transform.position;
			}
			return dropPoint.position;
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
			Debug.LogError("[BombDropper] Player не знайдено!");
		}
		if (bombPrefab == null)
		{
			Debug.LogError("[BombDropper] bombPrefab не призначено!");
		}
	}

	private void Update()
	{
		if (cooldownTimer > 0f)
		{
			cooldownTimer -= Time.deltaTime;
		}
	}

	public void TryDrop(Vector3 dropWaypoint, bool hasPoint)
	{
		TryDropAndReport(dropWaypoint, hasPoint);
	}

	public bool TryDropAndReport(Vector3 dropWaypoint, bool hasPoint)
	{
		lastHasPoint = hasPoint;
		if (!hasPoint || cooldownTimer > 0f || salvoRunning || playerTransform == null)
		{
			return false;
		}
		Vector3 vector = DropOrigin - dropWaypoint;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float num = DropOrigin.y - playerTransform.position.y;
		lastHorizDist = magnitude;
		lastAlt = num;
		if (showDebugLog)
		{
			Debug.Log($"[BombDropper] horizDist={magnitude:F1}m (need<{dropTriggerRadius})  alt={num:F1}m (need>{minDropAltitude})");
		}
		if (magnitude < dropTriggerRadius && num > minDropAltitude)
		{
			StartCoroutine(DropSalvo());
			cooldownTimer = bombCooldown;
			return true;
		}
		return false;
	}

	private IEnumerator DropSalvo()
	{
		salvoRunning = true;
		for (int i = 0; i < bombsPerSalvo; i++)
		{
			SpawnBomb(i);
			if (i < bombsPerSalvo - 1)
			{
				yield return new WaitForSeconds(salvoBombInterval);
			}
		}
		salvoRunning = false;
	}

	private void SpawnBomb(int index)
	{
		if (bombPrefab == null || playerTransform == null)
		{
			return;
		}
		float t = ((bombsPerSalvo > 1) ? ((float)index / (float)(bombsPerSalvo - 1)) : 0.5f);
		float num = Mathf.Lerp((0f - salvoSpread) * 0.5f, salvoSpread * 0.5f, t);
		Vector3 vector = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
		if (!(vector.magnitude < 1f))
		{
			Vector3 vector2 = Vector3.Cross(vector.normalized, Vector3.up);
			float num2 = Random.Range(0f - randomSpread, randomSpread);
			Vector3 vector3 = ((playerRb != null) ? playerRb.linearVelocity : Vector3.zero);
			float num3 = SimulateFlightTime(DropOrigin, rb.linearVelocity);
			Vector3 vector4 = playerTransform.position + vector3 * num3 + vector.normalized * num + vector2 * num2;
			vector4.y = playerTransform.position.y;
			Vector3 vector5 = SimulateLanding(DropOrigin, rb.linearVelocity, vector4.y);
			Vector3 vector6 = vector4 - vector5;
			vector6.y = 0f;
			float num4 = Mathf.Max(num3, 0.1f);
			Vector3 vector7 = vector6 / num4;
			float num5 = vector.magnitude * 0.2f;
			if (vector7.magnitude > num5)
			{
				vector7 = vector7.normalized * num5;
			}
			Vector3 linearVelocity = rb.linearVelocity + new Vector3(vector7.x, 0f, vector7.z);
			Rigidbody component = Object.Instantiate(bombPrefab, DropOrigin, Quaternion.identity).GetComponent<Rigidbody>();
			if (component != null)
			{
				component.linearVelocity = linearVelocity;
			}
			Debug.Log($"[BombDropper] Бомба #{index + 1}  error={vector6.magnitude:F1}m  correction={vector7.magnitude:F1}m/s  target={vector4}");
		}
	}

	private Vector3 SimulateLanding(Vector3 startPos, Vector3 startVel, float targetY)
	{
		Vector3 vector = startPos;
		Vector3 vector2 = startVel;
		float num = 0.05f;
		for (int i = 0; i < 600; i++)
		{
			vector2 += Physics.gravity * num;
			vector += vector2 * num;
			if (vector.y <= targetY)
			{
				float num2 = vector.y - vector2.y * num;
				float t = (num2 - targetY) / (num2 - vector.y);
				return Vector3.Lerp(vector - vector2 * num, vector, t);
			}
		}
		return vector;
	}

	private float SimulateFlightTime(Vector3 startPos, Vector3 startVel)
	{
		Vector3 vector = startPos;
		Vector3 vector2 = startVel;
		float num = 0.05f;
		float num2 = ((playerTransform != null) ? playerTransform.position.y : 0f);
		for (int i = 0; i < 600; i++)
		{
			vector2 += Physics.gravity * num;
			vector += vector2 * num;
			if (vector.y <= num2)
			{
				return (float)i * num;
			}
		}
		return 5f;
	}

	public void ResetTimer()
	{
		cooldownTimer = 0f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(DropOrigin, 1.5f);
	}
}
