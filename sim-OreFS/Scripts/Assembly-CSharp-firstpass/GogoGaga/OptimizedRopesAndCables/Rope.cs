using System;
using UnityEngine;

namespace GogoGaga.OptimizedRopesAndCables
{
	[ExecuteAlways]
	[RequireComponent(typeof(LineRenderer))]
	public class Rope : MonoBehaviour
	{
		[Header("Rope Transforms")]
		[Tooltip("The rope will start at this point")]
		[SerializeField]
		private Transform startPoint;

		[Tooltip("This will move at the center hanging from the rope, like a necklace, for example")]
		[SerializeField]
		private Transform midPoint;

		[Tooltip("The rope will end at this point")]
		[SerializeField]
		private Transform endPoint;

		[Header("Rope Settings")]
		[Tooltip("How many points should the rope have, 2 would be a triangle with straight lines, 100 would be a very flexible rope with many parts")]
		[Range(2f, 100f)]
		public int linePoints = 10;

		[Tooltip("Value highly dependent on use case, a metal cable would have high stiffness, a rubber rope would have a low one")]
		public float stiffness = 350f;

		[Tooltip("0 is no damping, 50 is a lot")]
		public float damping = 15f;

		[Tooltip("How long is the rope, it will hang more or less from starting point to end point depending on this value")]
		public float ropeLength = 15f;

		[Tooltip("The Rope width set at start (changing this value during run time will produce no effect)")]
		public float ropeWidth = 0.1f;

		[Header("Rational Bezier Weight Control")]
		[Tooltip("Adjust the middle control point weight for the Rational Bezier curve")]
		[Range(1f, 15f)]
		public float midPointWeight = 1f;

		private const float StartPointWeight = 1f;

		private const float EndPointWeight = 1f;

		[Header("Midpoint Position")]
		[Tooltip("Position of the midpoint along the line between start and end points")]
		[Range(0.25f, 0.75f)]
		public float midPointPosition = 0.5f;

		private Vector3 currentValue;

		private Vector3 currentVelocity;

		private Vector3 targetValue;

		private const float valueThreshold = 0.01f;

		private const float velocityThreshold = 0.01f;

		private LineRenderer lineRenderer;

		private bool isFirstFrame = true;

		private Vector3 prevStartPointPosition;

		private Vector3 prevEndPointPosition;

		private float prevMidPointPosition;

		private float prevMidPointWeight;

		private float prevLineQuality;

		private float prevRopeWidth;

		private float prevstiffness;

		private float prevDampness;

		private float prevRopeLength;

		public Transform StartPoint => startPoint;

		public Transform MidPoint => midPoint;

		public Transform EndPoint => endPoint;

		public Vector3 otherPhysicsFactors { get; set; }

		public bool IsPrefab => base.gameObject.scene.rootCount == 0;

		public event Action OnPointsChanged;

		private void Start()
		{
			InitializeLineRenderer();
			if (AreEndPointsValid())
			{
				currentValue = GetMidPoint();
				targetValue = currentValue;
				currentVelocity = Vector3.zero;
				SetSplinePoint();
			}
		}

		private void OnValidate()
		{
			if (!Application.isPlaying)
			{
				InitializeLineRenderer();
				if (AreEndPointsValid())
				{
					RecalculateRope();
					SimulatePhysics();
				}
				else
				{
					lineRenderer.positionCount = 0;
				}
			}
		}

		private void InitializeLineRenderer()
		{
			if (!lineRenderer)
			{
				lineRenderer = GetComponent<LineRenderer>();
			}
			lineRenderer.startWidth = ropeWidth;
			lineRenderer.endWidth = ropeWidth;
		}

		private void Update()
		{
			if (!IsPrefab && AreEndPointsValid())
			{
				SetSplinePoint();
				if (!Application.isPlaying && (IsPointsMoved() || IsRopeSettingsChanged()))
				{
					SimulatePhysics();
					NotifyPointsChanged();
				}
				prevStartPointPosition = startPoint.position;
				prevEndPointPosition = endPoint.position;
				prevMidPointPosition = midPointPosition;
				prevMidPointWeight = midPointWeight;
				prevLineQuality = linePoints;
				prevRopeWidth = ropeWidth;
				prevstiffness = stiffness;
				prevDampness = damping;
				prevRopeLength = ropeLength;
			}
		}

		private bool AreEndPointsValid()
		{
			if (startPoint != null)
			{
				return endPoint != null;
			}
			return false;
		}

		private void SetSplinePoint()
		{
			if (lineRenderer.positionCount != linePoints + 1)
			{
				lineRenderer.positionCount = linePoints + 1;
			}
			Vector3 vector = GetMidPoint();
			targetValue = vector;
			vector = currentValue;
			if (midPoint != null)
			{
				midPoint.position = GetRationalBezierPoint(startPoint.position, vector, endPoint.position, midPointPosition, 1f, midPointWeight, 1f);
			}
			for (int i = 0; i < linePoints; i++)
			{
				Vector3 rationalBezierPoint = GetRationalBezierPoint(startPoint.position, vector, endPoint.position, (float)i / (float)linePoints, 1f, midPointWeight, 1f);
				lineRenderer.SetPosition(i, rationalBezierPoint);
			}
			lineRenderer.SetPosition(linePoints, endPoint.position);
		}

		private float CalculateYFactorAdjustment(float weight)
		{
			float num = Mathf.Lerp(0.493f, 0.323f, Mathf.InverseLerp(1f, 15f, weight));
			return 1f + num * Mathf.Log(weight);
		}

		private Vector3 GetMidPoint()
		{
			Vector3 position = startPoint.position;
			Vector3 position2 = endPoint.position;
			Vector3 result = Vector3.Lerp(position, position2, midPointPosition);
			float num = (ropeLength - Mathf.Min(Vector3.Distance(position, position2), ropeLength)) / CalculateYFactorAdjustment(midPointWeight);
			result.y -= num;
			return result;
		}

		private Vector3 GetRationalBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t, float w0, float w1, float w2)
		{
			Vector3 vector = w0 * p0;
			Vector3 vector2 = w1 * p1;
			Vector3 vector3 = w2 * p2;
			float num = w0 * Mathf.Pow(1f - t, 2f) + 2f * w1 * (1f - t) * t + w2 * Mathf.Pow(t, 2f);
			return (vector * Mathf.Pow(1f - t, 2f) + vector2 * 2f * (1f - t) * t + vector3 * Mathf.Pow(t, 2f)) / num;
		}

		public Vector3 GetPointAt(float t)
		{
			if (!AreEndPointsValid())
			{
				Debug.LogError("StartPoint or EndPoint is not assigned.", base.gameObject);
				return Vector3.zero;
			}
			return GetRationalBezierPoint(startPoint.position, currentValue, endPoint.position, t, 1f, midPointWeight, 1f);
		}

		private void FixedUpdate()
		{
			if (!IsPrefab && AreEndPointsValid())
			{
				if (!isFirstFrame)
				{
					SimulatePhysics();
				}
				isFirstFrame = false;
			}
		}

		private void SimulatePhysics()
		{
			float num = Mathf.Max(0f, 1f - damping * Time.fixedDeltaTime);
			Vector3 vector = (targetValue - currentValue) * stiffness * Time.fixedDeltaTime;
			currentVelocity = currentVelocity * num + vector + otherPhysicsFactors;
			currentValue += currentVelocity * Time.fixedDeltaTime;
			if (Vector3.Distance(currentValue, targetValue) < 0.01f && currentVelocity.magnitude < 0.01f)
			{
				currentValue = targetValue;
				currentVelocity = Vector3.zero;
			}
		}

		private void OnDrawGizmos()
		{
			if (AreEndPointsValid())
			{
				GetMidPoint();
			}
		}

		public void SetStartPoint(Transform newStartPoint, bool instantAssign = false)
		{
			startPoint = newStartPoint;
			prevStartPointPosition = ((startPoint == null) ? Vector3.zero : startPoint.position);
			if (instantAssign || newStartPoint == null)
			{
				RecalculateRope();
			}
			NotifyPointsChanged();
		}

		public void SetMidPoint(Transform newMidPoint, bool instantAssign = false)
		{
			midPoint = newMidPoint;
			prevMidPointPosition = ((midPoint == null) ? 0.5f : midPointPosition);
			if (instantAssign || newMidPoint == null)
			{
				RecalculateRope();
			}
			NotifyPointsChanged();
		}

		public void SetEndPoint(Transform newEndPoint, bool instantAssign = false)
		{
			endPoint = newEndPoint;
			prevEndPointPosition = ((endPoint == null) ? Vector3.zero : endPoint.position);
			if (instantAssign || newEndPoint == null)
			{
				RecalculateRope();
			}
			NotifyPointsChanged();
		}

		public void RecalculateRope()
		{
			if (!AreEndPointsValid())
			{
				lineRenderer.positionCount = 0;
				return;
			}
			currentValue = GetMidPoint();
			targetValue = currentValue;
			currentVelocity = Vector3.zero;
			SetSplinePoint();
		}

		private void NotifyPointsChanged()
		{
			this.OnPointsChanged?.Invoke();
		}

		private bool IsPointsMoved()
		{
			bool num = startPoint.position != prevStartPointPosition;
			bool flag = endPoint.position != prevEndPointPosition;
			return num || flag;
		}

		private bool IsRopeSettingsChanged()
		{
			bool num = !Mathf.Approximately(linePoints, prevLineQuality);
			bool flag = !Mathf.Approximately(ropeWidth, prevRopeWidth);
			bool flag2 = !Mathf.Approximately(stiffness, prevstiffness);
			bool flag3 = !Mathf.Approximately(damping, prevDampness);
			bool flag4 = !Mathf.Approximately(ropeLength, prevRopeLength);
			bool flag5 = !Mathf.Approximately(midPointPosition, prevMidPointPosition);
			bool flag6 = !Mathf.Approximately(midPointWeight, prevMidPointWeight);
			return num || flag || flag2 || flag3 || flag4 || flag5 || flag6;
		}
	}
}
