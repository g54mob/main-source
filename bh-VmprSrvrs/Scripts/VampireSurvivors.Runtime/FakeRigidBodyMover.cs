using UnityEngine;

public class FakeRigidBodyMover : MonoBehaviour
{
	[Header("Physics Settings")]
	[SerializeField]
	public float mass;

	[SerializeField]
	public float drag;

	[SerializeField]
	public float angularDrag;

	[SerializeField]
	public bool useGravity;

	[SerializeField]
	public Vector3 customGravity;

	[Header("Debug")]
	[SerializeField]
	private bool showDebugInfo;

	private Vector3 velocity;

	public Vector3 angularVelocity;

	public bool isKinematic;

	private Vector3 effectiveGravity;

	public Vector3 Velocity
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 AngularVelocity
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public bool IsKinematic
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float Mass
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Drag
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float AngularDrag
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool UseGravity
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
	{
	}

	public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f, ForceMode mode = ForceMode.Force)
	{
	}

	public void AddTorque(Vector3 torque, ForceMode mode = ForceMode.Force)
	{
	}

	public void ResetPhysics()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
