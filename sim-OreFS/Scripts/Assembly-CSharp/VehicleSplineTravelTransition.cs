using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

[RequireComponent(typeof(Collider))]
public class VehicleSplineTravelTransition : MonoBehaviour
{
	[Header("Auto Register")]
	public bool isFactoryMain;

	public bool isDigsiteMain;

	public bool isDigsiteExit;

	[Header("Shared Transition Spline")]
	public SplineContainer transitionSpline;

	[Header("Teleport Anchor")]
	public Transform teleportAnchor;

	[Header("Timing")]
	public float inDuration = 0.8f;

	public float outLockBuffer = 0.3f;

	[Header("Loading")]
	public LoadingType loadingType;

	[Range(0f, 1f)]
	[Tooltip("OUT spline ilerleyişinde bu yüzdeye gelince loading açılır. 0 ise anında açılır.")]
	public float openLoadingAtOutPercent;

	[Range(0.01f, 1f)]
	public float closeLoadingAtInPercent = 0.85f;

	[Header("Camera Transition Events (Local Owner Only)")]
	public UnityEvent onTransitionStarted;

	public UnityEvent onTransitionFinished;

	[Header("Spline Placement")]
	public float alignToSplineTime = 0.25f;

	[Range(32f, 512f)]
	public int nearestSamples = 128;

	[Header("Speed Control")]
	public float minCruiseKmh = 40f;

	public float maxCruiseKmh = 80f;

	public float accelKmhPerSec = 60f;

	public float maxExitKmh = 30f;

	[Header("Rotation")]
	public bool faceTangent = true;

	public Vector3 up = Vector3.up;

	[Header("Wheel Visual Override During Travel")]
	public bool overrideWheelVisuals = true;

	[Tooltip("Wheel mesh'in local spin ekseni. Modeline göre Right/Forward/Up olabilir.")]
	public Vector3 wheelSpinAxisLocal = Vector3.right;

	[Tooltip("Wheel mesh ters yöne dönüyorsa bunu aç.")]
	public bool invertWheelSpin;

	[Header("Trigger Settings")]
	public bool autoStartOnTrigger = true;

	public bool requireDriverOwned = true;

	private bool isRunning;

	private float lastSplineSpeedMS;

	private void OnEnable()
	{
		Collider component = GetComponent<Collider>();
		if (component != null)
		{
			component.isTrigger = true;
		}
		if (GameManager.Instance != null)
		{
			if (isFactoryMain)
			{
				GameManager.Instance.FactoryTransitionPoint = this;
			}
			else if (isDigsiteMain)
			{
				GameManager.Instance.DigsiteTransitionPoint = this;
			}
			else if (isDigsiteExit)
			{
				GameManager.Instance.RegisterDigsiteExitPoint(this);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (autoStartOnTrigger)
		{
			SCC_Network componentInParent = other.GetComponentInParent<SCC_Network>();
			if (!(componentInParent == null) && (!requireDriverOwned || (componentInParent.isClient && componentInParent.isOwned)) && !componentInParent.IsTravelActive)
			{
				TryStartTravel(componentInParent);
			}
		}
	}

	public void TryStartTravel(SCC_Network vehicleNet)
	{
		if (!(vehicleNet == null) && !isRunning && !(GameManager.Instance == null) && !vehicleNet.IsTravelActive)
		{
			VehicleSplineTravelTransition destinationTransitionPoint = GameManager.Instance.GetDestinationTransitionPoint(this);
			if (!(destinationTransitionPoint == null) && !(transitionSpline == null) && !(destinationTransitionPoint.transitionSpline == null))
			{
				isRunning = true;
				StartCoroutine(TravelRoutine(vehicleNet, destinationTransitionPoint));
			}
		}
	}

	private void LocalOpenLoadingInstant()
	{
		if (!(GameManager.Instance == null))
		{
			GameManager.Instance.OpenLoadingUI(loadingType);
		}
	}

	private void LocalCloseLoadingInstant()
	{
		if (!(GameManager.Instance == null))
		{
			GameManager.Instance.CloseLoadingUIImmediate(loadingType);
		}
	}

	private IEnumerator TravelRoutine(SCC_Network vehicleNet, VehicleSplineTravelTransition destination)
	{
		vehicleNet.CmdSetTravelActive(active: true);
		if (vehicleNet.isClient && vehicleNet.isOwned)
		{
			vehicleNet.ResetPostTransitionInputFlag();
		}
		if (vehicleNet.isClient && vehicleNet.isOwned)
		{
			onTransitionStarted?.Invoke();
		}
		Rigidbody rb = ((vehicleNet.rb != null) ? vehicleNet.rb : vehicleNet.GetComponent<Rigidbody>());
		if (rb == null)
		{
			vehicleNet.CmdSetTravelActive(active: false);
			isRunning = false;
			yield break;
		}
		float magnitude = rb.linearVelocity.magnitude;
		if (magnitude > 0.25f)
		{
			Vector3.Dot(vehicleNet.transform.forward, rb.linearVelocity.normalized);
		}
		float a = magnitude;
		float b = KmHToMS(minCruiseKmh);
		float max = KmHToMS(maxCruiseKmh);
		float accel = KmHToMS(accelKmhPerSec);
		float cruiseTarget = Mathf.Clamp(Mathf.Max(a, b), 0f, max);
		float num = EstimateSplineLengthWorld(transitionSpline, 128);
		float duration = ((cruiseTarget > 0.1f) ? (num / cruiseTarget) : 2f) + inDuration + outLockBuffer;
		if (vehicleNet.isOwned)
		{
			vehicleNet.BeginTravelLock(duration);
		}
		if (vehicleNet.isClient)
		{
			vehicleNet.CmdServerBeginTravelLock(duration);
		}
		if (vehicleNet.isClient && vehicleNet.isOwned)
		{
			vehicleNet.SetLocalTravelSimEnabled(enabled: true);
		}
		bool loadingOpened = false;
		if (vehicleNet.isClient && vehicleNet.isOwned && openLoadingAtOutPercent <= 0f)
		{
			loadingOpened = true;
			LocalOpenLoadingInstant();
			vehicleNet.CmdBroadcastTravelLoading(open: true, (int)loadingType);
		}
		bool oldKinematic = rb.isKinematic;
		rb.isKinematic = true;
		rb.angularVelocity = Vector3.zero;
		float startT = FindNearestT_OnSplineWorld(transitionSpline, vehicleNet.transform.position, nearestSamples);
		Vector3 tangentDirWorld = GetTangentDirWorld(transitionSpline, startT, reverseTangent: false);
		bool outReverseTangent = Vector3.Dot(vehicleNet.transform.forward, tangentDirWorld) < 0f;
		yield return AlignToSpline(vehicleNet.transform, transitionSpline, startT, alignToSplineTime, outReverseTangent);
		yield return MoveAlongSplineBySpeed(vehicleNet, transitionSpline, startT, 1f, cruiseTarget, accel, outReverseTangent, delegate(float progress01)
		{
			if (!loadingOpened && vehicleNet.isClient && vehicleNet.isOwned && progress01 >= openLoadingAtOutPercent)
			{
				loadingOpened = true;
				LocalOpenLoadingInstant();
				vehicleNet.CmdBroadcastTravelLoading(open: true, (int)loadingType);
			}
		});
		if (vehicleNet.isClient && vehicleNet.isOwned && isFactoryMain)
		{
			vehicleNet.SetIsInDigsite(value: true);
		}
		Vector3 pos = (destination.teleportAnchor ? destination.teleportAnchor.position : destination.transform.position);
		Quaternion rot = (destination.teleportAnchor ? destination.teleportAnchor.rotation : destination.transform.rotation);
		vehicleNet.CmdTeleportVehicleAll(pos, rot);
		ApplyTeleportLocal(vehicleNet.transform, rb, pos, rot);
		bool inReverseTangent = true;
		yield return AlignToSpline(vehicleNet.transform, destination.transitionSpline, 1f, 0.05f, inReverseTangent);
		float closeAtTime = Mathf.Clamp(inDuration * (1f - closeLoadingAtInPercent), 0f, inDuration);
		bool finishedEventFired = false;
		bool loadingClosed = false;
		float elapsed = 0f;
		while (elapsed < inDuration)
		{
			float num2 = Mathf.Clamp01(elapsed / inDuration);
			float num3 = 1f - num2;
			EvalAndApply(vehicleNet.transform, destination.transitionSpline, num3, inReverseTangent);
			float num4 = Mathf.Max(0.1f, lastSplineSpeedMS);
			Vector3 normalized = GetTangentDirWorld(destination.transitionSpline, num3, inReverseTangent).normalized;
			if (vehicleNet.isClient && vehicleNet.isOwned)
			{
				vehicleNet.SetLocalTravelSimVelocity(normalized * num4);
				vehicleNet.SetLocalTravelSimState(num4 * 3.6f, SimulateRPM(vehicleNet, num4));
			}
			if (overrideWheelVisuals)
			{
				UpdateWheelVisuals(vehicleNet.drivetrain, num4);
			}
			elapsed += Time.deltaTime;
			if (!finishedEventFired && elapsed >= closeAtTime)
			{
				finishedEventFired = true;
				if (vehicleNet.isClient && vehicleNet.isOwned)
				{
					onTransitionFinished?.Invoke();
				}
			}
			if (!loadingClosed && elapsed >= closeAtTime)
			{
				loadingClosed = true;
				if (vehicleNet.isClient && vehicleNet.isOwned)
				{
					LocalCloseLoadingInstant();
					vehicleNet.CmdBroadcastTravelLoading(open: false, (int)loadingType);
				}
			}
			yield return null;
		}
		EvalAndApply(vehicleNet.transform, destination.transitionSpline, 0f, inReverseTangent);
		if (vehicleNet.isOwned)
		{
			vehicleNet.EndTravelLockNow();
		}
		if (vehicleNet.isClient)
		{
			vehicleNet.CmdEndServerTravelLockNow();
		}
		if (vehicleNet.isClient && vehicleNet.isOwned)
		{
			vehicleNet.SetLocalTravelSimEnabled(enabled: false);
		}
		rb.isKinematic = oldKinematic;
		Vector3 vector = GetTangentDirWorld(destination.transitionSpline, 0f, reverseTangent: false);
		if (vector.sqrMagnitude < 0.0001f)
		{
			vector = vehicleNet.transform.forward;
		}
		float num5 = Mathf.Clamp(lastSplineSpeedMS, 0f, KmHToMS(maxExitKmh));
		rb.linearVelocity = vector.normalized * num5;
		vehicleNet.transform.rotation = Quaternion.LookRotation(vector.normalized, up);
		if (vehicleNet.isClient && vehicleNet.isOwned && (isDigsiteMain || isDigsiteExit))
		{
			vehicleNet.SetIsInDigsite(value: false);
		}
		vehicleNet.CmdSetTravelActive(active: false);
		isRunning = false;
	}

	private IEnumerator MoveAlongSplineBySpeed(SCC_Network vehicleNet, SplineContainer container, float startT, float endT, float cruiseTarget, float accel, bool reverseTangent, Action<float> onProgress01)
	{
		lastSplineSpeedMS = Mathf.Max(0f, cruiseTarget);
		BuildLUT(container, 256, out var ts, out var ds);
		float startD = DistanceAtT(ts, ds, startT);
		float endD = DistanceAtT(ts, ds, endT);
		float curD = startD;
		float speed = Mathf.Clamp(cruiseTarget * 0.35f, 0f, cruiseTarget);
		while (curD < endD - 0.001f)
		{
			speed = Mathf.MoveTowards(speed, cruiseTarget, accel * Time.deltaTime);
			curD += speed * Time.deltaTime;
			float num = TAtDistance(ts, ds, curD);
			EvalAndApply(vehicleNet.transform, container, num, reverseTangent);
			Vector3 normalized = GetTangentDirWorld(container, num, reverseTangent).normalized;
			if (vehicleNet.isClient && vehicleNet.isOwned)
			{
				vehicleNet.SetLocalTravelSimVelocity(normalized * speed);
				vehicleNet.SetLocalTravelSimState(speed * 3.6f, SimulateRPM(vehicleNet, speed));
			}
			if (overrideWheelVisuals)
			{
				UpdateWheelVisuals(vehicleNet.drivetrain, speed);
			}
			float obj = Mathf.InverseLerp(startD, endD, curD);
			onProgress01?.Invoke(obj);
			yield return null;
		}
		EvalAndApply(vehicleNet.transform, container, endT, reverseTangent);
		lastSplineSpeedMS = speed;
		onProgress01?.Invoke(1f);
	}

	private void UpdateWheelVisuals(SCC_Drivetrain drivetrain, float speedMS)
	{
		if (drivetrain == null || drivetrain.wheels == null)
		{
			return;
		}
		Vector3 right = wheelSpinAxisLocal;
		if (right.sqrMagnitude < 0.0001f)
		{
			right = Vector3.right;
		}
		right.Normalize();
		for (int i = 0; i < drivetrain.wheels.Length; i++)
		{
			SCC_Drivetrain.SCC_Wheels sCC_Wheels = drivetrain.wheels[i];
			if (sCC_Wheels == null || sCC_Wheels.wheelTransform == null || sCC_Wheels.wheelCollider == null)
			{
				continue;
			}
			WheelCollider wheelCollider = sCC_Wheels.wheelCollider.WheelCollider;
			if (!(wheelCollider == null))
			{
				float num = Mathf.Max(0.05f, wheelCollider.radius);
				float num2 = speedMS / num * 57.29578f;
				if (invertWheelSpin)
				{
					num2 = 0f - num2;
				}
				sCC_Wheels.wheelTransform.Rotate(right, num2 * Time.deltaTime, Space.Self);
			}
		}
	}

	private float SimulateRPM(SCC_Network vehicleNet, float speedMS)
	{
		if (vehicleNet == null || vehicleNet.drivetrain == null)
		{
			return 1000f;
		}
		SCC_Drivetrain drivetrain = vehicleNet.drivetrain;
		float num = Mathf.Max(1f, drivetrain.maximumSpeed / 3.6f);
		float t = Mathf.Clamp01(speedMS / num);
		return Mathf.Lerp(drivetrain.minimumEngineRPM, drivetrain.maximumEngineRPM, t);
	}

	private void BuildLUT(SplineContainer container, int samples, out float[] ts, out float[] ds)
	{
		ts = new float[samples + 1];
		ds = new float[samples + 1];
		Vector3 a = GetPosWorld(container, 0f);
		ts[0] = 0f;
		ds[0] = 0f;
		float num = 0f;
		for (int i = 1; i <= samples; i++)
		{
			float num2 = (float)i / (float)samples;
			Vector3 posWorld = GetPosWorld(container, num2);
			num += Vector3.Distance(a, posWorld);
			ts[i] = num2;
			ds[i] = num;
			a = posWorld;
		}
	}

	private float DistanceAtT(float[] ts, float[] ds, float t)
	{
		if (t <= 0f)
		{
			return 0f;
		}
		if (t >= 1f)
		{
			return ds[^1];
		}
		int num = 0;
		for (int i = 1; i < ts.Length; i++)
		{
			if (ts[i] >= t)
			{
				num = i;
				break;
			}
		}
		float a = ts[num - 1];
		float b = ts[num];
		float a2 = ds[num - 1];
		float b2 = ds[num];
		float t2 = Mathf.InverseLerp(a, b, t);
		return Mathf.Lerp(a2, b2, t2);
	}

	private float TAtDistance(float[] ts, float[] ds, float d)
	{
		if (d <= 0f)
		{
			return 0f;
		}
		float num = ds[^1];
		if (d >= num)
		{
			return 1f;
		}
		int num2 = 0;
		for (int i = 1; i < ds.Length; i++)
		{
			if (ds[i] >= d)
			{
				num2 = i;
				break;
			}
		}
		float a = ds[num2 - 1];
		float b = ds[num2];
		float a2 = ts[num2 - 1];
		float b2 = ts[num2];
		float t = Mathf.InverseLerp(a, b, d);
		return Mathf.Lerp(a2, b2, t);
	}

	private float FindNearestT_OnSplineWorld(SplineContainer container, Vector3 worldPos, int samples)
	{
		float num = 0f;
		float num2 = float.MaxValue;
		for (int i = 0; i <= samples; i++)
		{
			float num3 = (float)i / (float)samples;
			float sqrMagnitude = (GetPosWorld(container, num3) - worldPos).sqrMagnitude;
			if (sqrMagnitude < num2)
			{
				num2 = sqrMagnitude;
				num = num3;
			}
		}
		float num4 = 1f / (float)samples;
		float a = Mathf.Clamp01(num - num4);
		float b = Mathf.Clamp01(num + num4);
		float result = num;
		num2 = float.MaxValue;
		for (int j = 0; j <= 10; j++)
		{
			float num5 = Mathf.Lerp(a, b, (float)j / 10f);
			float sqrMagnitude2 = (GetPosWorld(container, num5) - worldPos).sqrMagnitude;
			if (sqrMagnitude2 < num2)
			{
				num2 = sqrMagnitude2;
				result = num5;
			}
		}
		return result;
	}

	private IEnumerator AlignToSpline(Transform target, SplineContainer container, float t01, float time, bool reverseTangent)
	{
		if (container == null || time <= 0f)
		{
			EvalAndApply(target, container, t01, reverseTangent);
			yield break;
		}
		Vector3 startPos = target.position;
		Vector3 endPos = GetPosWorld(container, t01);
		float elapsed = 0f;
		while (elapsed < time)
		{
			float num = Mathf.Clamp01(elapsed / time);
			num = num * num * (3f - 2f * num);
			target.position = Vector3.Lerp(startPos, endPos, num);
			elapsed += Time.deltaTime;
			yield return null;
		}
		target.position = endPos;
	}

	private void EvalAndApply(Transform target, SplineContainer container, float evalT, bool reverseTangent)
	{
		if (container == null)
		{
			return;
		}
		Vector3 posWorld = GetPosWorld(container, evalT);
		Quaternion rotation = target.rotation;
		if (faceTangent)
		{
			Vector3 tangentDirWorld = GetTangentDirWorld(container, evalT, reverseTangent);
			if (tangentDirWorld.sqrMagnitude > 0.0001f)
			{
				rotation = Quaternion.LookRotation(tangentDirWorld.normalized, up);
			}
		}
		target.SetPositionAndRotation(posWorld, rotation);
	}

	private void ApplyTeleportLocal(Transform target, Rigidbody rb, Vector3 pos, Quaternion rot)
	{
		if (rb != null)
		{
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		target.SetPositionAndRotation(pos, rot);
	}

	private Vector3 GetPosWorld(SplineContainer container, float t01)
	{
		float3 float5 = container.Spline.EvaluatePosition(t01);
		return container.transform.TransformPoint(float5);
	}

	private Vector3 GetTangentDirWorld(SplineContainer container, float t01, bool reverseTangent)
	{
		float3 float5 = container.Spline.EvaluateTangent(t01);
		Vector3 vector = container.transform.TransformDirection(float5);
		if (reverseTangent)
		{
			vector = -vector;
		}
		return vector;
	}

	private Quaternion GetRotWorld(SplineContainer container, float t01, bool reverseTangent)
	{
		if (!faceTangent)
		{
			return Quaternion.LookRotation(Vector3.forward, up);
		}
		Vector3 vector = GetTangentDirWorld(container, t01, reverseTangent);
		if (vector.sqrMagnitude < 0.0001f)
		{
			vector = container.transform.forward;
		}
		return Quaternion.LookRotation(vector.normalized, up);
	}

	private float EstimateSplineLengthWorld(SplineContainer container, int samples)
	{
		if (container == null || container.Spline == null)
		{
			return 0f;
		}
		Vector3 a = GetPosWorld(container, 0f);
		float num = 0f;
		for (int i = 1; i <= samples; i++)
		{
			float t = (float)i / (float)samples;
			Vector3 posWorld = GetPosWorld(container, t);
			num += Vector3.Distance(a, posWorld);
			a = posWorld;
		}
		return num;
	}

	private float KmHToMS(float kmh)
	{
		return kmh / 3.6f;
	}
}
