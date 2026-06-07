using System;
using System.Runtime.CompilerServices;
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
		public int linePoints;

		[Tooltip("Value highly dependent on use case, a metal cable would have high stiffness, a rubber rope would have a low one")]
		public float stiffness;

		[Tooltip("0 is no damping, 50 is a lot")]
		public float damping;

		[Tooltip("How long is the rope, it will hang more or less from starting point to end point depending on this value")]
		public float ropeLength;

		[Tooltip("The Rope width set at start (changing this value during run time will produce no effect)")]
		public float ropeWidth;

		[Header("Rational Bezier Weight Control")]
		[Tooltip("Adjust the middle control point weight for the Rational Bezier curve")]
		[Range(1f, 15f)]
		public float midPointWeight;

		private const float StartPointWeight = 1f;

		private const float EndPointWeight = 1f;

		[Header("Midpoint Position")]
		[Tooltip("Position of the midpoint along the line between start and end points")]
		[Range(0.25f, 0.75f)]
		public float midPointPosition;

		private Vector3 currentValue;

		private Vector3 currentVelocity;

		private Vector3 targetValue;

		private const float valueThreshold = 0.01f;

		private const float velocityThreshold = 0.01f;

		private LineRenderer lineRenderer;

		private bool isFirstFrame;

		private Vector3 prevStartPointPosition;

		private Vector3 prevEndPointPosition;

		private float prevMidPointPosition;

		private float prevMidPointWeight;

		private float prevLineQuality;

		private float prevRopeWidth;

		private float prevstiffness;

		private float prevDampness;

		private float prevRopeLength;

		public Transform StartPoint => null;

		public Transform MidPoint => null;

		public Transform EndPoint => null;

		public Vector3 otherPhysicsFactors { get; set; }

		public bool IsPrefab => false;

		public event Action OnPointsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void OnValidate()
		{
		}

		private void InitializeLineRenderer()
		{
		}

		private void Update()
		{
		}

		private bool AreEndPointsValid()
		{
			return false;
		}

		private void SetSplinePoint()
		{
		}

		private float CalculateYFactorAdjustment(float weight)
		{
			return 0f;
		}

		private Vector3 GetMidPoint()
		{
			return default(Vector3);
		}

		private Vector3 GetRationalBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t, float w0, float w1, float w2)
		{
			return default(Vector3);
		}

		public Vector3 GetPointAt(float t)
		{
			return default(Vector3);
		}

		private void FixedUpdate()
		{
		}

		private void SimulatePhysics()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void SetStartPoint(Transform newStartPoint, bool instantAssign = false)
		{
		}

		public void SetMidPoint(Transform newMidPoint, bool instantAssign = false)
		{
		}

		public void SetEndPoint(Transform newEndPoint, bool instantAssign = false)
		{
		}

		public void RecalculateRope()
		{
		}

		private void NotifyPointsChanged()
		{
		}

		private bool IsPointsMoved()
		{
			return false;
		}

		private bool IsRopeSettingsChanged()
		{
			return false;
		}
	}
}
