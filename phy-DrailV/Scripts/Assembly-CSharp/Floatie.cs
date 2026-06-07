using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Floatie : MonoBehaviour
{
	public float distanceFromHead = 0.6f;

	public bool drawLine;

	[Tooltip("Maps the angle between camera forward direction and direction to current floatie position (x-axis [0, 180]) to lerp factor of floatie centering movement (y-axis [0, 1])")]
	public AnimationCurve angleToPositionLerp;

	[Tooltip("Maps the angle between camera forward direction and direction to current floatie position (x-axis [0, 180]) to lerp factor of floatie re-aligning (x & y) rotation (y-axis [0, 1])")]
	public AnimationCurve angleToRotationLerp;

	[Range(0f, 1f)]
	[Tooltip("Roll (z-rotation) lerp")]
	public float rollLerp = 0.2f;

	[Tooltip("Target percentage to reorient the floatie towards world up direction (as opposed to camera's up direction)")]
	[Range(0f, 1f)]
	public float worldUpRotationTargetPercentage = 0.2f;

	[Tooltip("Target percentage to force floatie orientation towards world-space up, regardless of head pitch")]
	[Range(0f, 1f)]
	public float straightenUpFactor;

	[Range(0f, 1f)]
	[Tooltip("Amount to move the floatie towards the attention point in order to draw attention and cause the user to rotate the head towards it")]
	public float offsetFactor = 0.25f;

	[Tooltip("How eager the floatie will be to stay within inner part of the camera's view, higher values mean it will move sooner (from the corners towards the center)")]
	[Range(0.5f, 5f)]
	public float positionCenteringMultiplier = 1f;

	public bool spawnInFrontOfCam = true;

	[Tooltip("Destroy floatie after camera had been approximately looking at attention point for this amount of time")]
	public float dismissTime = 1.2f;

	[Tooltip("Conic angle to consider that camera is looking at the attention point")]
	public float dismissAngle = 20f;

	public float lineWidth = 0.001f;

	public Color lineColor = Color.gray;

	public Material lineMaterial;

	[Tooltip("Time to wait before calling Destroy on floatie game object")]
	public float waitBeforeDestroy = 1f;

	[Header("Optional")]
	public Transform attentionPoint;

	public Transform head;

	public Transform lineStartPoint;

	[Tooltip("Fired when floatie has been destroyed as a result of looking at the attention point")]
	public UnityEvent Dismissed = new UnityEvent();

	protected LineRenderer line;

	protected float countdown;

	protected bool destroyingInProgress;

	protected virtual bool CanDrawLine => drawLine;

	public static Floatie Spawn(GameObject prefab, Transform attentionPoint = null, float distanceFromHead = 0.5f, bool spawnInFrontOfCam = true)
	{
		GameObject gameObject = Object.Instantiate(prefab);
		Floatie component = gameObject.GetComponent<Floatie>();
		if (!component)
		{
			gameObject.AddComponent<Floatie>();
		}
		if (component.attentionPoint == null)
		{
			component.attentionPoint = attentionPoint;
		}
		component.spawnInFrontOfCam = spawnInFrontOfCam;
		return component;
	}

	public void Destroy()
	{
		if (!destroyingInProgress)
		{
			destroyingInProgress = true;
			OnAboutToBeDestroyed();
			Object.Destroy(base.gameObject, waitBeforeDestroy);
		}
	}

	public virtual void OnAboutToBeDestroyed()
	{
	}

	protected virtual void Start()
	{
		if (!head && (bool)Camera.main)
		{
			head = Camera.main.transform;
		}
		if (!lineStartPoint)
		{
			lineStartPoint = base.transform.Find("line start point");
		}
		if (!lineStartPoint)
		{
			lineStartPoint = base.transform;
		}
		line = base.gameObject.AddComponent<LineRenderer>();
		line.shadowCastingMode = ShadowCastingMode.Off;
		line.receiveShadows = false;
		if ((bool)lineMaterial)
		{
			lineMaterial = new Material(lineMaterial);
		}
		else
		{
			lineMaterial = new Material(Shader.Find("Standard"));
		}
		line.material = lineMaterial;
		line.useWorldSpace = false;
		line.enabled = CanDrawLine;
		if (spawnInFrontOfCam)
		{
			base.transform.position = head.position + head.forward * distanceFromHead;
			base.transform.LookAt(base.transform.position + head.forward, Vector3.up);
		}
		countdown = dismissTime;
	}

	protected virtual void Update()
	{
		if (!head)
		{
			Debug.LogError("Floatie doesn't have a camera assigned and couldn't find main camera, disabling itself", this);
			base.enabled = false;
			return;
		}
		UpdateFloatie();
		UpdateLine();
		if ((bool)attentionPoint)
		{
			UpdateDismiss();
		}
	}

	public void ResetToOptimal()
	{
		Vector3 forward = head.forward;
		if (straightenUpFactor > 0f)
		{
			forward.y = Mathf.Lerp(forward.y, 0f, straightenUpFactor);
			forward.Normalize();
		}
		base.transform.position = head.position + forward * distanceFromHead;
		Vector3 worldUp = Vector3.Lerp(head.up, Vector3.up, worldUpRotationTargetPercentage);
		base.transform.LookAt(base.transform.position + forward, worldUp);
	}

	private void UpdateFloatie()
	{
		Vector3 vector = head.forward * distanceFromHead;
		Vector3 forward = head.forward;
		if (straightenUpFactor > 0f)
		{
			forward.y = Mathf.Lerp(forward.y, 0f, straightenUpFactor);
			forward.Normalize();
		}
		Quaternion b = Quaternion.FromToRotation(head.forward, base.transform.position - head.position);
		float num = Mathf.Clamp(Quaternion.Angle(Quaternion.identity, b), 0f, 180f);
		float t = angleToPositionLerp.Evaluate(num * positionCenteringMultiplier);
		float t2 = angleToRotationLerp.Evaluate(num * positionCenteringMultiplier);
		Vector3 toDirection = (attentionPoint ? (attentionPoint.position - head.position) : vector);
		Quaternion b2 = Quaternion.FromToRotation(head.forward, toDirection);
		Vector3 b3 = Quaternion.Lerp(Quaternion.identity, b2, offsetFactor) * vector + head.position;
		Vector3 vector2 = Vector3.Lerp(base.transform.position, b3, t);
		Vector3 vector3 = Vector3.Lerp(base.transform.forward, forward, t2);
		float num2 = Vector3.SqrMagnitude(vector2 - head.position);
		float num3 = Mathf.Clamp01(1f - num2 / (distanceFromHead * distanceFromHead));
		Vector3 b4 = vector2 + head.forward * num3;
		base.transform.position = Vector3.Lerp(vector2, b4, 0.4f);
		Vector3 b5 = Vector3.Lerp(head.up, Vector3.up, worldUpRotationTargetPercentage);
		Vector3 worldUp = Vector3.Lerp(base.transform.up, b5, rollLerp);
		base.transform.LookAt(base.transform.position + vector3, worldUp);
	}

	private void UpdateLine()
	{
		if (!CanDrawLine || !lineStartPoint || !attentionPoint)
		{
			line.enabled = false;
			return;
		}
		line.enabled = true;
		SetLineWidth();
		SetLineColor();
		SetLinePoints();
	}

	protected virtual void SetLineWidth()
	{
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
	}

	protected virtual void SetLineColor()
	{
		lineMaterial.color = lineColor;
		lineMaterial.SetColor("_EmissionColor", lineColor);
		line.startColor = lineColor;
		line.endColor = lineColor;
	}

	protected virtual void SetLinePoints()
	{
		line.SetPosition(0, base.transform.InverseTransformPoint(lineStartPoint.position));
		line.SetPosition(1, base.transform.InverseTransformPoint(attentionPoint.position));
	}

	protected virtual void UpdateDismiss()
	{
		if (!destroyingInProgress)
		{
			Quaternion b = Quaternion.FromToRotation(head.forward, attentionPoint.position - head.position);
			if (Mathf.Clamp(Quaternion.Angle(Quaternion.identity, b), 0f, 180f) <= dismissAngle)
			{
				countdown -= Time.deltaTime;
			}
			if (countdown <= 0f)
			{
				Dismissed.Invoke();
				Destroy();
			}
		}
	}
}
