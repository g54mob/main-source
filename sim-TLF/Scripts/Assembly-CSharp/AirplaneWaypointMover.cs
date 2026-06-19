using System;
using UnityEngine;

[RequireComponent(typeof(AircraftPhysics))]
[RequireComponent(typeof(AirplaneController))]
public class AirplaneWaypointMover : MonoBehaviour
{
	[Header("Waypoints")]
	public Transform[] waypoints;

	public float waypointReachDistance = 150f;

	public bool loopWaypoints;

	public bool destroyOnFinish = true;

	[Header("Тяга (динамічна)")]
	public float targetSpeed = 80f;

	[Range(0f, 1f)]
	public float minThrust = 0.5f;

	[Range(0f, 1f)]
	public float maxThrust = 1f;

	public float thrustResponseSpeed = 1.5f;

	[Header("Керування")]
	public float pitchSensitivity = 0.3f;

	public float rollSensitivity = 0.5f;

	[Tooltip("Максимальний крен при звичайному польоті")]
	public float maxBankAngle = 30f;

	[Tooltip("Максимальний крен при розвороті назад. Менше = плавніший розворот, менший ризик штопора")]
	public float maxBankAngleTurn = 20f;

	[Header("Мінімальна безпечна висота")]
	[Tooltip("Мінімальна висота над землею (метри). 0 = вимкнено")]
	public float minAltitude = 80f;

	[Tooltip("Шар в якому літак починає набирати висоту (метри над minAltitude)")]
	public float altitudeWarningZone = 40f;

	[Tooltip("Як знайти землю: Raycast вниз. Якщо нічого не знайшло — використовує Y=0")]
	public LayerMask groundLayerMask = -1;

	[Header("Фаза розгону")]
	public float minSafeSpeed = 40f;

	public float takeoffPitchInput = -0.05f;

	[Header("Debug")]
	[SerializeField]
	private bool _showDebugGUI;

	private AircraftPhysics physics;

	private AirplaneController controller;

	private Rigidbody rb;

	private int currentWaypoint;

	private float currentThrust = 1f;

	private bool approachConfirmed;

	[HideInInspector]
	public Vector3? OverrideTarget;

	public bool IsFinished
	{
		get
		{
			if (!loopWaypoints)
			{
				return currentWaypoint >= ((waypoints != null) ? waypoints.Length : 0);
			}
			return false;
		}
	}

	public int CurrentWaypointIndex => currentWaypoint;

	private void Start()
	{
		physics = GetComponent<AircraftPhysics>();
		controller = GetComponent<AirplaneController>();
		rb = GetComponent<Rigidbody>();
		currentThrust = maxThrust;
		physics.SetThrustPercent(currentThrust);
		approachConfirmed = false;
	}

	private void Update()
	{
		Vector3 target;
		if (OverrideTarget.HasValue)
		{
			target = OverrideTarget.Value;
		}
		else
		{
			if (waypoints == null || waypoints.Length == 0)
			{
				return;
			}
			if (currentWaypoint >= waypoints.Length)
			{
				if (!loopWaypoints)
				{
					if (destroyOnFinish)
					{
						controller.Pitch = 0f;
						controller.Roll = 0f;
						controller.Yaw = 0f;
						UnityEngine.Object.Destroy(base.gameObject);
					}
					else
					{
						FlyLevel();
					}
					return;
				}
				currentWaypoint = 0;
				approachConfirmed = false;
			}
			target = waypoints[currentWaypoint].position;
			TryAdvanceWaypoint(target);
			if (currentWaypoint < waypoints.Length)
			{
				target = waypoints[currentWaypoint].position;
			}
		}
		target = ApplyTurnOffset(target);
		UpdateThrust(target);
		FlyTowards(target);
	}

	private Vector3 ApplyTurnOffset(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		vector.y = 0f;
		if (Vector3.Dot(base.transform.forward, vector.normalized) > 0.1f)
		{
			return target;
		}
		Vector3 vector2 = ((Vector3.Cross(base.transform.forward, vector.normalized).y >= 0f) ? base.transform.right : (-base.transform.right));
		float magnitude = rb.linearVelocity.magnitude;
		float value = magnitude * magnitude / (Physics.gravity.magnitude * Mathf.Tan(maxBankAngleTurn * (MathF.PI / 180f)));
		value = Mathf.Clamp(value, 100f, 1000f);
		Vector3 result = base.transform.position + vector2 * value;
		result.y = target.y;
		return result;
	}

	private void TryAdvanceWaypoint(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		float num = Vector3.Dot(base.transform.forward, vector.normalized);
		if (!approachConfirmed)
		{
			if (!(num > 0.3f))
			{
				return;
			}
			approachConfirmed = true;
		}
		bool num2 = vector.magnitude < waypointReachDistance;
		bool flag = num < 0f;
		if (num2 || flag)
		{
			currentWaypoint++;
			approachConfirmed = false;
		}
	}

	private void UpdateThrust(Vector3 target)
	{
		float magnitude = rb.linearVelocity.magnitude;
		float num = targetSpeed - magnitude;
		float num2 = Mathf.Clamp(rb.linearVelocity.y * 0.01f, -0.2f, 0.2f);
		Vector3 normalized = Vector3.ProjectOnPlane(Vector3.up, base.transform.forward).normalized;
		float num3 = Mathf.Abs(Vector3.SignedAngle(base.transform.up, normalized, base.transform.forward));
		float num4 = Mathf.Lerp(0f, 0.15f, num3 / maxBankAngle);
		float target2 = Mathf.Clamp(0.5f + num * 0.01f + num2 + num4, minThrust, maxThrust);
		currentThrust = Mathf.MoveTowards(currentThrust, target2, thrustResponseSpeed * Time.deltaTime);
		physics.SetThrustPercent(currentThrust);
	}

	private void FlyTowards(Vector3 target)
	{
		float magnitude = rb.linearVelocity.magnitude;
		if (magnitude < minSafeSpeed)
		{
			controller.Pitch = takeoffPitchInput;
			controller.Roll = 0f;
			controller.Yaw = 0f;
			return;
		}
		float altitudeAboveGround = GetAltitudeAboveGround();
		float num = 0f;
		if (minAltitude > 0f)
		{
			float num2 = minAltitude - altitudeAboveGround;
			if (num2 > 0f)
			{
				num = 0f - Mathf.Clamp01(num2 / 20f);
			}
			else if (num2 > 0f - altitudeWarningZone)
			{
				num = (0f - (1f - Mathf.Clamp01((0f - num2) / altitudeWarningZone))) * 0.3f;
			}
		}
		Vector3 vector = base.transform.InverseTransformDirection((target - base.transform.position).normalized);
		float num3 = Mathf.Clamp01((magnitude - minSafeSpeed) / 30f);
		float num4 = Mathf.Clamp((0f - vector.y) * pitchSensitivity * 3f * num3, -1f, 1f);
		float pitch = ((num != 0f) ? Mathf.Min(num4, num) : num4);
		float num5 = ((Vector3.Dot(base.transform.forward, (target - base.transform.position).normalized) < 0.1f) ? maxBankAngleTurn : maxBankAngle);
		float num6 = Mathf.Clamp(vector.x * 90f, 0f - num5, num5);
		float num7 = Vector3.SignedAngle(to: Vector3.ProjectOnPlane(Vector3.up, base.transform.forward).normalized, from: base.transform.up, axis: base.transform.forward);
		float roll = Mathf.Clamp((num6 - num7) / 45f * rollSensitivity * num3, -1f, 1f);
		controller.Pitch = pitch;
		controller.Roll = roll;
		controller.Yaw = 0f;
	}

	private float GetAltitudeAboveGround()
	{
		if (Physics.Raycast(base.transform.position, Vector3.down, out var hitInfo, 2000f, groundLayerMask))
		{
			return hitInfo.distance;
		}
		return base.transform.position.y;
	}

	private void FlyLevel()
	{
		if (rb.linearVelocity.magnitude < minSafeSpeed)
		{
			controller.Pitch = takeoffPitchInput;
			controller.Roll = 0f;
			controller.Yaw = 0f;
			UpdateThrust(base.transform.position + base.transform.forward * 100f);
			return;
		}
		float pitch = Mathf.Clamp(rb.linearVelocity.y * 0.05f, -0.3f, 0.3f);
		float altitudeAboveGround = GetAltitudeAboveGround();
		if (minAltitude > 0f && altitudeAboveGround < minAltitude)
		{
			pitch = -0.3f;
		}
		Vector3 normalized = Vector3.ProjectOnPlane(Vector3.up, base.transform.forward).normalized;
		float roll = Mathf.Clamp((0f - Vector3.SignedAngle(base.transform.up, normalized, base.transform.forward)) / 30f, -1f, 1f);
		controller.Pitch = pitch;
		controller.Roll = roll;
		controller.Yaw = 0f;
		UpdateThrust(base.transform.position + base.transform.forward * 100f);
	}

	public void ResetPIDs()
	{
	}

	private void OnDrawGizmos()
	{
		if (waypoints == null)
		{
			return;
		}
		for (int i = 0; i < waypoints.Length; i++)
		{
			if (!(waypoints[i] == null))
			{
				Gizmos.color = ((Application.isPlaying && i == currentWaypoint) ? Color.yellow : Color.cyan);
				Gizmos.DrawWireSphere(waypoints[i].position, 12f);
				int num = (i + 1) % waypoints.Length;
				if ((loopWaypoints || i < waypoints.Length - 1) && waypoints[num] != null)
				{
					Gizmos.DrawLine(waypoints[i].position, waypoints[num].position);
				}
			}
		}
		if (Application.isPlaying)
		{
			if (OverrideTarget.HasValue)
			{
				Gizmos.color = Color.magenta;
				Gizmos.DrawWireSphere(OverrideTarget.Value, 25f);
				Gizmos.DrawLine(base.transform.position, OverrideTarget.Value);
			}
			if (minAltitude > 0f)
			{
				RaycastHit hitInfo;
				float num2 = (Physics.Raycast(base.transform.position, Vector3.down, out hitInfo, 2000f, groundLayerMask) ? (base.transform.position.y - hitInfo.distance) : 0f);
				Gizmos.color = new Color(1f, 0.3f, 0f, 0.15f);
				Gizmos.DrawWireCube(new Vector3(base.transform.position.x, num2 + minAltitude, base.transform.position.z), new Vector3(200f, 0.5f, 200f));
			}
		}
	}
}
