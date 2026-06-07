using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ValveTeleportArc : MonoBehaviour
{
	public int segmentCount = 60;

	public float thickness = 0.01f;

	[Tooltip("The amount of time in seconds to predict the motion of the projectile.")]
	public float arcDuration = 3f;

	[Tooltip("The amount of time in seconds between each segment of the projectile.")]
	public float segmentBreak = 0.025f;

	[Tooltip("The speed at which the line segments of the arc move.")]
	public float arcSpeed = 0.2f;

	[Tooltip("If true, everything works the same, just line isn't rendered.")]
	public bool invisible;

	public Material material;

	public LayerMask traceLayerMask = 0;

	public QueryTriggerInteraction queryTriggerInteraction;

	private Material materialInstance;

	private LineRenderer[] lineRenderers;

	private float arcTimeOffset;

	private float prevThickness;

	private int prevSegmentCount;

	private bool showArc = true;

	private Vector3 startPos;

	private Vector3 projectileVelocity;

	private bool useGravity = true;

	private Transform arcObjectsTransform;

	private bool arcInvalid;

	private readonly HashSet<Collider> collidersToIgnore = new HashSet<Collider>();

	private RaycastHit[] raycastHits = new RaycastHit[3];

	private void Start()
	{
		arcTimeOffset = Time.time;
		materialInstance = Object.Instantiate(material);
	}

	private void Update()
	{
		UpdateRenderer();
	}

	public void UpdateRenderer()
	{
		if (thickness != prevThickness || segmentCount != prevSegmentCount)
		{
			CreateLineRendererObjects();
			prevThickness = thickness;
			prevSegmentCount = segmentCount;
		}
	}

	private void CreateLineRendererObjects()
	{
		if (arcObjectsTransform != null)
		{
			Object.Destroy(arcObjectsTransform.gameObject);
		}
		GameObject gameObject = new GameObject("ArcObjects");
		arcObjectsTransform = gameObject.transform;
		arcObjectsTransform.SetParent(base.transform);
		arcObjectsTransform.transform.localPosition = Vector3.zero;
		arcObjectsTransform.transform.localScale = Vector3.one;
		arcObjectsTransform.transform.localRotation = Quaternion.identity;
		lineRenderers = new LineRenderer[segmentCount];
		for (int i = 0; i < segmentCount; i++)
		{
			GameObject gameObject2 = new GameObject("LineRenderer_" + i);
			gameObject2.transform.SetParent(arcObjectsTransform);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.transform.localRotation = Quaternion.identity;
			lineRenderers[i] = gameObject2.AddComponent<LineRenderer>();
			lineRenderers[i].useWorldSpace = false;
			lineRenderers[i].receiveShadows = false;
			lineRenderers[i].reflectionProbeUsage = ReflectionProbeUsage.Off;
			lineRenderers[i].lightProbeUsage = LightProbeUsage.Off;
			lineRenderers[i].shadowCastingMode = ShadowCastingMode.Off;
			lineRenderers[i].material = materialInstance;
			lineRenderers[i].startWidth = thickness;
			lineRenderers[i].endWidth = thickness;
			lineRenderers[i].enabled = false;
		}
	}

	public void SetArcData(Vector3 position, Vector3 velocity, bool gravity, bool pointerAtBadAngle)
	{
		startPos = position;
		projectileVelocity = velocity;
		useGravity = gravity;
		if (arcInvalid && !pointerAtBadAngle)
		{
			arcTimeOffset = Time.time;
		}
		arcInvalid = pointerAtBadAngle;
	}

	private void OnEnable()
	{
		showArc = true;
		if (lineRenderers == null)
		{
			CreateLineRendererObjects();
		}
	}

	private void OnDisable()
	{
		if (showArc)
		{
			HideLineSegments(0, segmentCount);
		}
		showArc = false;
	}

	public bool DrawArc(out RaycastHit hitInfo)
	{
		float num = arcDuration / (float)segmentCount;
		float num2 = (Time.time - arcTimeOffset) * arcSpeed;
		if (num2 > num + segmentBreak)
		{
			arcTimeOffset = Time.time;
			num2 = 0f;
		}
		float num3 = num2;
		float num4 = FindProjectileCollision(out hitInfo);
		if (arcInvalid)
		{
			DrawArcSegment(0, 0f, (num4 < num) ? num4 : num, Quaternion.Inverse(arcObjectsTransform.rotation));
			HideLineSegments(1, segmentCount);
		}
		else
		{
			int num5 = 0;
			if (num3 > segmentBreak)
			{
				float num6 = num2 - segmentBreak;
				if (num4 < num6)
				{
					num6 = num4;
				}
				DrawArcSegment(0, 0f, num6, Quaternion.Inverse(arcObjectsTransform.rotation));
				num5 = 1;
			}
			bool flag = false;
			int num7 = 0;
			if (num3 < num4)
			{
				for (num7 = num5; num7 < segmentCount; num7++)
				{
					float num8 = num3 + num;
					if (num8 >= arcDuration)
					{
						num8 = arcDuration;
						flag = true;
					}
					if (num8 >= num4)
					{
						num8 = num4;
						flag = true;
					}
					DrawArcSegment(num7, num3, num8, Quaternion.Inverse(arcObjectsTransform.rotation));
					num3 += num + segmentBreak;
					if (flag || num3 >= arcDuration || num3 >= num4)
					{
						break;
					}
				}
			}
			else
			{
				num7--;
			}
			HideLineSegments(num7 + 1, segmentCount);
		}
		return num4 != float.MaxValue;
	}

	private void DrawArcSegment(int index, float startTime, float endTime, Quaternion inverseRotation)
	{
		lineRenderers[index].enabled = !invisible;
		lineRenderers[index].SetPosition(0, inverseRotation * (GetArcPositionAtTime(startTime) - startPos));
		lineRenderers[index].SetPosition(1, inverseRotation * (GetArcPositionAtTime(endTime) - startPos));
	}

	public void SetColor(Color color)
	{
		materialInstance.color = color;
		for (int i = 0; i < segmentCount; i++)
		{
			lineRenderers[i].startColor = color;
			lineRenderers[i].endColor = color;
		}
	}

	private float FindProjectileCollision(out RaycastHit hitInfo)
	{
		float num = arcDuration / (float)segmentCount;
		float num2 = 0f;
		hitInfo = default(RaycastHit);
		collidersToIgnore.Clear();
		Vector3 vector = GetArcPositionAtTime(num2);
		for (int i = 0; i < segmentCount; i++)
		{
			float num3 = num2 + num;
			Vector3 arcPositionAtTime = GetArcPositionAtTime(num3);
			Vector3 direction = arcPositionAtTime - vector;
			int num4 = Physics.RaycastNonAlloc(vector, direction, raycastHits, direction.magnitude, traceLayerMask, queryTriggerInteraction);
			if (num4 != 0)
			{
				RaycastUtils.SortDistanceAndExpandCache(ref raycastHits, num4);
				int num5 = -1;
				for (int j = 0; j < num4; j++)
				{
					ref RaycastHit reference = ref raycastHits[j];
					TeleportArcPassThrough component = reference.collider.GetComponent<TeleportArcPassThrough>();
					if (component != null)
					{
						if (component.ShouldIgnoreCollidersForHit(reference))
						{
							collidersToIgnore.UnionWith(component.colliders);
						}
					}
					else if (!collidersToIgnore.Contains(reference.collider) && reference.distance != 0f && (num5 == -1 || reference.distance < raycastHits[num5].distance))
					{
						num5 = j;
					}
				}
				if (num5 != -1)
				{
					hitInfo = raycastHits[num5];
					float num6 = Vector3.Distance(vector, arcPositionAtTime);
					return num2 + num * (hitInfo.distance / num6);
				}
			}
			num2 = num3;
			vector = arcPositionAtTime;
		}
		return float.MaxValue;
	}

	public Vector3 GetArcPositionAtTime(float time)
	{
		Vector3 vector = (useGravity ? Physics.gravity : Vector3.zero);
		return startPos + (projectileVelocity * time + 0.5f * time * time * vector);
	}

	private void HideLineSegments(int startSegment, int endSegment)
	{
		if (lineRenderers != null)
		{
			for (int i = startSegment; i < endSegment; i++)
			{
				lineRenderers[i].enabled = false;
			}
		}
	}

	private static void DrawCross(Vector3 position)
	{
		Vector3 start = position + Vector3.right * 0.1f;
		Vector3 end = position - Vector3.right * 0.1f;
		Debug.DrawLine(start, end, Color.red);
		Vector3 start2 = position + Vector3.up * 0.1f;
		Vector3 end2 = position - Vector3.up * 0.1f;
		Debug.DrawLine(start2, end2, Color.red);
		Vector3 start3 = position + Vector3.forward * 0.1f;
		Vector3 end3 = position - Vector3.forward * 0.1f;
		Debug.DrawLine(start3, end3, Color.red);
	}
}
