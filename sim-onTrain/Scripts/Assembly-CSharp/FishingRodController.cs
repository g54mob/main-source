using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class FishingRodController : MonoBehaviour
{
	public enum RodState
	{
		Idle = 0,
		Throwing = 1,
		Landed = 2,
		Reeling = 3
	}

	[Header("References")]
	[SerializeField]
	private LineRenderer line;

	[SerializeField]
	private Transform rodTip;

	[SerializeField]
	private Transform baitModel;

	[SerializeField]
	private Transform holdingPlayer;

	[Header("Line")]
	[SerializeField]
	[Range(8f, 96f)]
	private int lineSegments = 48;

	[SerializeField]
	private float idleSag = 0.08f;

	[SerializeField]
	private float landedSag = 0.4f;

	[SerializeField]
	private float idleFollowSpeed = 12f;

	[Header("Throw")]
	[SerializeField]
	private LayerMask groundLayers;

	[SerializeField]
	[Tooltip("Kısa tıklamada minimum atış mesafesi (metre).")]
	private float minThrowDistance = 4f;

	[SerializeField]
	[Tooltip("Tam basılı tutulduğunda maksimum atış mesafesi (metre).")]
	private float maxThrowDistance = 10f;

	[SerializeField]
	private float throwDuration = 1.3f;

	[SerializeField]
	[Tooltip("Minimum arc yüksekliği (metre). Mesafeye göre otomatik artar.")]
	private float throwArcHeight = 5f;

	[SerializeField]
	[Tooltip("Arc yüksekliğinin mesafeye oranı (0.55 = mesafenin %55'i kadar).")]
	private float arcHeightDistanceRatio = 0.55f;

	[SerializeField]
	[Tooltip("Yan bombenin minimum genişliği (metre). Sağa doğru kıvrılma.")]
	private float sideArcMin = 2f;

	[SerializeField]
	[Tooltip("Yan bombenin mesafeye oranı.")]
	private float sideArcDistanceRatio = 0.22f;

	[SerializeField]
	[Tooltip("Bombenin tepe noktası (0.5=orta, 0.35=erken/yakın).")]
	private float arcPeakBias = 0.4f;

	[Header("Particles")]
	[SerializeField]
	[Tooltip("Bait suya değdiğinde spawn edilen sıçrama particle prefab'ı.")]
	private ParticleSystem waterSplashPrefab;

	[SerializeField]
	[Tooltip("Balık geldiğinde spawn edilecek particle prefab (henüz mekanik yok, referans dursun).")]
	private ParticleSystem fishBitePrefab;

	[SerializeField]
	[Tooltip("Splash particle'ının ömrü (otomatik destroy).")]
	private float splashLifetime = 3f;

	[SerializeField]
	private BaitWaterDetector baitWaterDetector;

	[SerializeField]
	private bool debugLog = true;

	[Header("Reel & Break")]
	[SerializeField]
	private float reelSpeed = 14f;

	[SerializeField]
	[Tooltip("Bait suya bu mesafeden yakınlaşınca rod tip'e doğru yükselmeye başlar.")]
	private float reelLiftRange = 1.5f;

	[SerializeField]
	[Tooltip("Bait su yüzeyindeyken sallanma genliği (metre).")]
	private float reelWobbleAmplitude = 0.08f;

	[SerializeField]
	[Tooltip("Sallanma frekansı.")]
	private float reelWobbleFrequency = 12f;

	[SerializeField]
	[Tooltip("Rod tip ile bait arası bu mesafeyi aşarsa ip kopar.")]
	private float maxLineLength = 20f;

	public UnityEvent OnLineBreak = new UnityEvent();

	private Vector3 baitWorldPos;

	private Tween throwTween;

	private Animator armsAnimator;

	private float pendingThrowPower = 1f;

	private Camera _cachedCamera;

	private float reelSurfaceY;

	private float reelStartTime;

	public RodState State { get; private set; }

	public void SetHoldingPlayer(Transform t)
	{
		holdingPlayer = t;
	}

	public void SetArmsAnimator(Animator a)
	{
		armsAnimator = a;
	}

	private void Awake()
	{
		if (line != null)
		{
			line.useWorldSpace = true;
			line.positionCount = lineSegments;
		}
	}

	private void OnEnable()
	{
		State = RodState.Idle;
		KillTween();
		baitWorldPos = GetIdleBaitPos();
	}

	private void OnDisable()
	{
		KillTween();
	}

	private void LateUpdate()
	{
		if (line == null || rodTip == null)
		{
			return;
		}
		switch (State)
		{
		case RodState.Idle:
			baitWorldPos = Vector3.Lerp(baitWorldPos, GetIdleBaitPos(), Time.deltaTime * idleFollowSpeed);
			break;
		case RodState.Throwing:
			if (throwTween == null)
			{
				baitWorldPos = Vector3.Lerp(baitWorldPos, GetIdleBaitPos(), Time.deltaTime * idleFollowSpeed);
			}
			break;
		case RodState.Landed:
			if (Vector3.Distance(rodTip.position, baitWorldPos) > maxLineLength)
			{
				BreakLine();
			}
			break;
		case RodState.Reeling:
		{
			Vector3 idleBaitPos = GetIdleBaitPos();
			Vector3 current = new Vector3(baitWorldPos.x, 0f, baitWorldPos.z);
			Vector3 vector = new Vector3(idleBaitPos.x, 0f, idleBaitPos.z);
			Vector3 a = Vector3.MoveTowards(current, vector, reelSpeed * Time.deltaTime);
			float num = Vector3.Distance(a, vector);
			float num2 = Mathf.Max(0.1f, reelLiftRange);
			float num3 = 1f - Mathf.Clamp01(num / num2);
			float num4 = Mathf.Sin((Time.time - reelStartTime) * reelWobbleFrequency) * reelWobbleAmplitude * (1f - num3);
			float y = Mathf.Lerp(reelSurfaceY + num4, idleBaitPos.y, num3);
			baitWorldPos = new Vector3(a.x, y, a.z);
			if (Vector3.Distance(baitWorldPos, idleBaitPos) < 0.05f)
			{
				baitWorldPos = idleBaitPos;
				State = RodState.Idle;
			}
			break;
		}
		}
		if (baitModel != null)
		{
			baitModel.position = baitWorldPos;
		}
		DrawLine();
	}

	private void BreakLine()
	{
		KillTween();
		State = RodState.Idle;
		baitWorldPos = GetIdleBaitPos();
		OnLineBreak.Invoke();
	}

	private Vector3 GetIdleBaitPos()
	{
		return rodTip.position + Vector3.down * idleSag;
	}

	private void DrawLine()
	{
		if (line.positionCount != lineSegments)
		{
			line.positionCount = lineSegments;
		}
		Vector3 position = rodTip.position;
		Vector3 b = baitWorldPos;
		float currentSag = GetCurrentSag();
		for (int i = 0; i < lineSegments; i++)
		{
			float num = (float)i / (float)(lineSegments - 1);
			Vector3 position2 = Vector3.Lerp(position, b, num);
			float num2 = 4f * num * (1f - num) * currentSag;
			position2.y -= num2;
			line.SetPosition(i, position2);
		}
	}

	private float GetCurrentSag()
	{
		switch (State)
		{
		case RodState.Landed:
			return landedSag;
		case RodState.Reeling:
		{
			float num = Vector3.Distance(rodTip.position, baitWorldPos);
			float num2 = Mathf.Max(0.1f, maxLineLength * 0.5f);
			return Mathf.Lerp(idleSag * 0.5f, landedSag, Mathf.Clamp01(num / num2));
		}
		default:
			return idleSag * 0.5f;
		}
	}

	public void PlayThrowAnimation(float power = 1f)
	{
		if (!(rodTip == null))
		{
			pendingThrowPower = Mathf.Clamp01(power);
			KillTween();
			State = RodState.Throwing;
			if (baitWaterDetector != null)
			{
				baitWaterDetector.ResetSplash();
			}
			if (armsAnimator != null)
			{
				armsAnimator.SetTrigger(AnimationKeys.FishingThrow);
			}
		}
	}

	public void ExecuteThrow()
	{
		if (rodTip == null || State != RodState.Throwing)
		{
			return;
		}
		KillTween();
		Vector3 target = ComputeLandingTarget(pendingThrowPower);
		Vector3 startPos = rodTip.position;
		baitWorldPos = startPos;
		Camera activeCamera = GetActiveCamera();
		Vector3 upDir = ((activeCamera != null) ? activeCamera.transform.up : Vector3.up);
		Vector3 sideDir = ((activeCamera != null) ? (-activeCamera.transform.right) : Vector3.left);
		float num = Vector3.Distance(new Vector3(startPos.x, 0f, startPos.z), new Vector3(target.x, 0f, target.z));
		float b = num * arcHeightDistanceRatio;
		float arcHeight = Mathf.Max(throwArcHeight, b);
		float sideArcWidth = Mathf.Max(sideArcMin, num * sideArcDistanceRatio);
		float bias = Mathf.Clamp(arcPeakBias, 0.05f, 0.95f);
		float t = 0f;
		throwTween = DOTween.To(() => t, delegate(float x)
		{
			t = x;
		}, 1f, throwDuration).SetEase(Ease.Linear).OnUpdate(delegate
		{
			Vector3 vector = Vector3.Lerp(startPos, target, t);
			float num2 = ((t < bias) ? (0.5f * (t / bias)) : (0.5f + 0.5f * ((t - bias) / (1f - bias))));
			float num3 = 4f * arcHeight * num2 * (1f - num2);
			float num4 = 4f * sideArcWidth * t * (1f - t);
			baitWorldPos = vector + upDir * num3 + sideDir * num4;
		})
			.OnComplete(delegate
			{
				baitWorldPos = target;
				State = RodState.Landed;
				throwTween = null;
				if (debugLog)
				{
					Debug.Log($"[FishingRod] Tween complete, target={target}, hasDetector={baitWaterDetector != null}");
				}
				if (baitWaterDetector == null)
				{
					TryPlayWaterSplashFallback(target);
				}
			});
	}

	private void TryPlayWaterSplashFallback(Vector3 landingPoint)
	{
		if (waterSplashPrefab == null)
		{
			if (debugLog)
			{
				Debug.LogWarning("[FishingRod] waterSplashPrefab null, splash atlanıyor.", this);
			}
			return;
		}
		RaycastHit[] array = Physics.RaycastAll(landingPoint + Vector3.up * 3f, Vector3.down, 6f, -1, QueryTriggerInteraction.Collide);
		if (debugLog)
		{
			Debug.Log($"[FishingRod] Fallback raycast hit count: {array.Length}");
		}
		for (int i = 0; i < array.Length; i++)
		{
			WaterInteractable componentInParent = array[i].collider.GetComponentInParent<WaterInteractable>();
			if (debugLog)
			{
				Debug.Log($"[FishingRod]  - hit {array[i].collider.name} water={componentInParent != null}");
			}
			if (componentInParent != null)
			{
				PlayWaterSplashAt(array[i].point);
				return;
			}
		}
		if (debugLog)
		{
			Debug.Log("[FishingRod] Fallback: no WaterInteractable found, no splash.");
		}
	}

	public void PlayWaterSplashAt(Vector3 worldPos)
	{
		if (waterSplashPrefab == null)
		{
			if (debugLog)
			{
				Debug.LogWarning("[FishingRod] waterSplashPrefab null", this);
			}
			return;
		}
		ParticleSystem particleSystem = Object.Instantiate(waterSplashPrefab, worldPos, Quaternion.identity);
		particleSystem.gameObject.SetActive(value: true);
		particleSystem.Play(withChildren: true);
		if (debugLog)
		{
			Debug.Log($"[FishingRod] Spawned splash '{particleSystem.name}' at {worldPos}", particleSystem);
		}
		Object.Destroy(particleSystem.gameObject, splashLifetime);
	}

	public void Reel()
	{
		if (State != RodState.Idle && State != RodState.Reeling)
		{
			KillTween();
			reelSurfaceY = baitWorldPos.y;
			reelStartTime = Time.time;
			State = RodState.Reeling;
			if (armsAnimator != null)
			{
				armsAnimator.SetTrigger(AnimationKeys.FishingReel);
			}
		}
	}

	private Camera GetActiveCamera()
	{
		if (_cachedCamera != null && _cachedCamera.isActiveAndEnabled)
		{
			return _cachedCamera;
		}
		Transform transform = ((rodTip != null) ? rodTip : base.transform);
		while (transform != null)
		{
			Camera componentInChildren = transform.GetComponentInChildren<Camera>(includeInactive: false);
			if (componentInChildren != null && componentInChildren.isActiveAndEnabled)
			{
				_cachedCamera = componentInChildren;
				return componentInChildren;
			}
			transform = transform.parent;
		}
		Camera[] allCameras = Camera.allCameras;
		for (int i = 0; i < allCameras.Length; i++)
		{
			if (allCameras[i] != null && allCameras[i].isActiveAndEnabled && allCameras[i].CompareTag("MainCamera"))
			{
				_cachedCamera = allCameras[i];
				return allCameras[i];
			}
		}
		return Camera.main;
	}

	private Vector3 ComputeLandingTarget(float power)
	{
		Camera activeCamera = GetActiveCamera();
		Vector3 vector = ((rodTip != null) ? rodTip.position : base.transform.position);
		if (activeCamera == null)
		{
			return vector + Vector3.forward * minThrowDistance;
		}
		float num = Mathf.Lerp(minThrowDistance, maxThrowDistance, Mathf.Clamp01(power));
		Vector3 position = activeCamera.transform.position;
		Vector3 forward = activeCamera.transform.forward;
		forward.y = 0f;
		if (forward.sqrMagnitude < 0.001f)
		{
			forward = Vector3.forward;
		}
		forward.Normalize();
		Vector3 vector2 = new Vector3(position.x, position.y, position.z) + forward * num;
		if (Physics.Raycast(vector2 + Vector3.up * 25f, Vector3.down, out var hitInfo, 60f, groundLayers))
		{
			return hitInfo.point;
		}
		vector2.y = vector.y;
		return vector2;
	}

	private void KillTween()
	{
		throwTween?.Kill();
		throwTween = null;
	}
}
