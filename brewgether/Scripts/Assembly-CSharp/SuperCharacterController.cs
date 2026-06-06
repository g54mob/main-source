using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SuperCharacterController : MonoBehaviour
{
	protected struct IgnoredCollider
	{
		public Collider collider;

		public int layer;

		public IgnoredCollider(Collider collider, int layer)
		{
			this.collider = null;
			this.layer = 0;
		}
	}

	public delegate void UpdateDelegate();

	public class SuperGround
	{
		private class GroundHit
		{
			public Vector3 point { get; private set; }

			public Vector3 normal { get; private set; }

			public float distance { get; private set; }

			public GroundHit(Vector3 point, Vector3 normal, float distance)
			{
			}
		}

		private LayerMask walkable;

		private SuperCharacterController controller;

		private readonly QueryTriggerInteraction triggerInteraction;

		private GroundHit primaryGround;

		private GroundHit nearGround;

		private GroundHit farGround;

		private GroundHit stepGround;

		private GroundHit flushGround;

		private const float groundingUpperBoundAngle = 60f;

		private const float groundingMaxPercentFromCenter = 0.85f;

		private const float groundingMinPercentFromcenter = 0.5f;

		public SuperCollisionType superCollisionType { get; private set; }

		public Transform transform { get; private set; }

		public SuperGround(LayerMask walkable, SuperCharacterController controller, QueryTriggerInteraction triggerInteraction)
		{
		}

		public void ProbeGround(Vector3 origin, int iter)
		{
		}

		private void ResetGrounds()
		{
		}

		public bool IsGrounded(bool currentlyGrounded, float distance)
		{
			return false;
		}

		public bool IsGrounded(bool currentlyGrounded, float distance, out Vector3 groundNormal)
		{
			groundNormal = default(Vector3);
			return false;
		}

		private bool OnSteadyGround(Vector3 normal, Vector3 point)
		{
			return false;
		}

		public Vector3 PrimaryNormal()
		{
			return default(Vector3);
		}

		public float Distance()
		{
			return 0f;
		}

		public void DebugGround(bool primary, bool near, bool far, bool flush, bool step)
		{
		}

		private bool SimulateSphereCast(Vector3 groundNormal, out RaycastHit hit)
		{
			hit = default(RaycastHit);
			return false;
		}
	}

	[SerializeField]
	private Vector3 debugMove;

	[SerializeField]
	private QueryTriggerInteraction triggerInteraction;

	[SerializeField]
	private bool fixedTimeStep;

	[SerializeField]
	private int fixedUpdatesPerSecond;

	[SerializeField]
	private bool clampToMovingGround;

	[SerializeField]
	private bool debugSpheres;

	[SerializeField]
	private bool debugGrounding;

	[SerializeField]
	private bool debugPushbackMesssages;

	[SerializeField]
	private CollisionSphere[] spheres;

	public LayerMask Walkable;

	[SerializeField]
	private Collider ownCollider;

	[SerializeField]
	public float radius;

	private Vector3 initialPosition;

	private Vector3 groundOffset;

	private Vector3 lastGroundPosition;

	private bool clamping;

	private bool slopeLimiting;

	private List<Collider> ignoredColliders;

	private List<IgnoredCollider> ignoredColliderStack;

	private const float Tolerance = 0.1f;

	private const float TinyTolerance = 0.02f;

	private const string TemporaryLayer = "TempCast";

	private const int MaxPushbackIterations = 2;

	private int TemporaryLayerIndex;

	private float fixedDeltaTime;

	private static SuperCollisionType defaultCollisionType;

	public float deltaTime { get; private set; }

	public SuperGround currentGround { get; private set; }

	public CollisionSphere feet { get; private set; }

	public CollisionSphere head { get; private set; }

	public float height => 0f;

	public Vector3 up => default(Vector3);

	public Vector3 down => default(Vector3);

	public List<SuperCollision> collisionData { get; private set; }

	public Transform currentlyClampedTo { get; set; }

	public float heightScale { get; set; }

	public float radiusScale { get; set; }

	public bool manualUpdateOnly { get; set; }

	public event UpdateDelegate AfterSingleUpdate
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

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void ManualUpdate(float deltaTime)
	{
	}

	private void SingleUpdate()
	{
	}

	private void ProbeGround(int iter)
	{
	}

	private bool SlopeLimit()
	{
		return false;
	}

	private void ClampToGround()
	{
	}

	public void EnableClamping()
	{
	}

	public void DisableClamping()
	{
	}

	public void EnableSlopeLimit()
	{
	}

	public void DisableSlopeLimit()
	{
	}

	public bool IsClamping()
	{
		return false;
	}

	private void RecursivePushback(int depth, int maxDepth)
	{
	}

	private void PushIgnoredColliders()
	{
	}

	private void PopIgnoredColliders()
	{
	}

	private void OnDrawGizmos()
	{
	}

	public Vector3 SpherePosition(CollisionSphere sphere)
	{
		return default(Vector3);
	}

	public bool PointBelowHead(Vector3 point)
	{
		return false;
	}

	public bool PointAboveFeet(Vector3 point)
	{
		return false;
	}

	public void IgnoreCollider(Collider col)
	{
	}

	public void RemoveIgnoredCollider(Collider col)
	{
	}

	public void ClearIgnoredColliders()
	{
	}
}
