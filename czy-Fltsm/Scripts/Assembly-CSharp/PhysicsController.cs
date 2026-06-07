using System.Collections;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using UnityEngine;

[AddComponentMenu("Flotsam/Physics/Physics Controller")]
public class PhysicsController : MonoBehaviour, IUpdateManagerFixedUpdateTarget
{
	[Tooltip("Physical properties of this object.")]
	public PhysicsProperties Properties;

	[SerializeField]
	[Tooltip("Should the primary collider always be enabled (even if it is disabled on instantiation)?")]
	private bool _alwaysEnablePrimaryCollider = true;

	[SerializeField]
	[Tooltip("Secondary collider for switching to in certain cases. Mainly used for drifters when out of the water.")]
	private Collider _secondaryCollider;

	[HideInInspector]
	public bool ShouldApplyCurrent = true;

	private bool _initialized;

	private RigidbodyConstraints _originalConstraints;

	private Vector3 _mainForce;

	private Rigidbody _rigidBody;

	private Buoyancy _buoyancy;

	private Transform _transform;

	private PhysicsManager _physicsManager;

	private Vector3 _originalRotation;

	public Collider PrimaryCollider { get; private set; }

	private void Start()
	{
		Initialize(Properties);
	}

	private void OnEnable()
	{
		if ((bool)PrimaryCollider)
		{
			PrimaryCollider.enabled = true;
		}
		if ((bool)_buoyancy)
		{
			_buoyancy.enabled = true;
		}
	}

	private void OnDisable()
	{
		if ((bool)PrimaryCollider)
		{
			PrimaryCollider.enabled = false;
		}
		if ((bool)_buoyancy)
		{
			_buoyancy.enabled = false;
		}
	}

	public void Initialize(PhysicsProperties physicsProperties = null, float spawnHeight = 0f)
	{
		if (_initialized)
		{
			return;
		}
		if (physicsProperties != null)
		{
			Properties = physicsProperties;
		}
		InitializeReferences();
		_originalRotation = _transform.eulerAngles;
		if (PrimaryCollider != null)
		{
			PrimaryCollider.isTrigger = Properties.IsTrigger;
			if (_alwaysEnablePrimaryCollider)
			{
				PrimaryCollider.enabled = true;
			}
		}
		if (Properties == null)
		{
			Debugger.Warning($"No physics properties set for {base.gameObject.name}.", this);
		}
		if (Properties.Buoyant)
		{
			_buoyancy = GetComponent<Buoyancy>();
			if (_buoyancy == null)
			{
				_buoyancy = base.gameObject.AddComponent<Buoyancy>();
			}
			_buoyancy.Initialize(this, spawnHeight);
		}
		else
		{
			SetKinematic(isKinematic: true, isTrigger: false);
			if (Properties.AttachToWorld)
			{
				base.transform.SetParent(GameManager.WorldManager.WorldParent);
			}
		}
		_initialized = true;
	}

	public void Initialize(GameObject visualPrefab, PhysicsProperties physicsProperties, float spawnHeight = 0f)
	{
		if (physicsProperties.CopyVisualPrefabCollider)
		{
			PrimaryCollider = FlotsamGame.CopyCollider(visualPrefab, base.gameObject);
		}
		else
		{
			PrimaryCollider = visualPrefab.GetComponent<Collider>();
			PrimaryCollider.gameObject.layer = base.gameObject.layer;
		}
		Initialize(physicsProperties, spawnHeight);
	}

	private void InitializeReferences()
	{
		_transform = base.transform;
		_physicsManager = GameManager.PhysicsManager;
		_rigidBody = InitializeRigidbody();
		if ((bool)_rigidBody)
		{
			ApplyPhysicsPropertiesToRigidbody(_rigidBody, Properties);
		}
		if (PrimaryCollider == null)
		{
			PrimaryCollider = GetComponent<Collider>();
		}
	}

	public void UpdateManager_FixedUpdate()
	{
		Vector3 eulerAngles = _transform.eulerAngles;
		if (Properties.FreezeRotationX)
		{
			eulerAngles.x = _originalRotation.x;
		}
		if (Properties.FreezeRotationY)
		{
			eulerAngles.y = _originalRotation.y;
		}
		if (Properties.FreezeRotationZ)
		{
			eulerAngles.z = _originalRotation.z;
		}
		_transform.rotation = Quaternion.Euler(eulerAngles);
	}

	private void OnDestroy()
	{
		GameManager.UpdateManager.UnregisterFixedUpdateTarget(this);
	}

	private void ApplyCurrent()
	{
		if (_physicsManager.MovingFlotsamForce == 0f)
		{
			return;
		}
		_mainForce = _physicsManager.MainForce;
		if (Properties.SlowDownNearTownheart)
		{
			float num = _transform.position.FastSquaredMagnitudeLeveled();
			float slowdownThreshold = GameManager.Settings.GameplaySettings.SlowdownThreshold;
			if (num < slowdownThreshold * slowdownThreshold)
			{
				float t = Mathf.Sqrt(num) / slowdownThreshold;
				t = Mathf.Lerp(GameManager.Settings.GameplaySettings.SlowedDownMultiplier, 1f, t);
				_mainForce *= t;
			}
		}
		_rigidBody.AddForce(_mainForce);
	}

	public void AddLocalForce(Vector3 localForce, float maxVelocity)
	{
		localForce *= Time.fixedDeltaTime;
		if (_rigidBody.linearVelocity.magnitude <= maxVelocity)
		{
			_rigidBody.AddRelativeForce(localForce);
		}
		else
		{
			_rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * maxVelocity;
		}
	}

	public void AddForce(Vector3 force, float maxVelocity = 9999f)
	{
		float magnitude = _rigidBody.linearVelocity.magnitude;
		if (magnitude <= maxVelocity)
		{
			_rigidBody.AddForce(force);
		}
		else
		{
			_rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * (maxVelocity / magnitude);
		}
	}

	public void AddTorque(Vector3 torque)
	{
		_rigidBody.AddTorque(torque);
	}

	public void SetKinematic(bool isKinematic, bool isTrigger)
	{
		if ((bool)_rigidBody)
		{
			_rigidBody.isKinematic = isKinematic;
			_rigidBody.useGravity = !isKinematic;
		}
		if ((bool)PrimaryCollider)
		{
			PrimaryCollider.isTrigger = isTrigger;
		}
		if ((bool)_secondaryCollider)
		{
			_secondaryCollider.isTrigger = isTrigger;
		}
	}

	public void SetKinematic(bool isKinematic)
	{
		SetKinematic(isKinematic, isKinematic);
	}

	public void PhysicsActive(bool active)
	{
		if ((bool)_rigidBody)
		{
			if (active)
			{
				_rigidBody.constraints = _originalConstraints;
			}
			else
			{
				_originalConstraints = _rigidBody.constraints;
				_rigidBody.constraints = RigidbodyConstraints.FreezeAll;
			}
		}
		if (Properties.Buoyant)
		{
			_buoyancy._buoyancyEnabled = active;
		}
		SetKinematic(!active);
	}

	public void EnableCollider(bool primaryEnabled)
	{
		PrimaryCollider.enabled = primaryEnabled;
	}

	public void EnableCollider(bool primaryEnabled, bool secondaryEnabled)
	{
		PrimaryCollider.enabled = primaryEnabled;
		_secondaryCollider.enabled = secondaryEnabled;
	}

	public void Sink(GameObject parent = null)
	{
		PhysicsActive(active: true);
		_rigidBody.useGravity = true;
		_rigidBody.isKinematic = false;
		_rigidBody.mass *= GameManager.Settings.GameplaySettings.WorldPhysics.MassMultiplier;
		_rigidBody.linearDamping = GameManager.Settings.GameplaySettings.WorldPhysics.NewDrag;
		PrimaryCollider.enabled = false;
		StartCoroutine(DestructionCoroutine(GameManager.Settings.GameplaySettings.WorldPhysics.DestructionHeight, parent));
	}

	private IEnumerator DestructionCoroutine(float destructionDepth, GameObject parent)
	{
		while (base.transform.position.y > destructionDepth)
		{
			yield return null;
		}
		if ((bool)parent)
		{
			Object.Destroy(parent);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Teleport(Vector3 target)
	{
		_rigidBody.position = target;
	}

	public void TeleportToWaterLevel()
	{
		float y = WorldManager.WaterHeight(_rigidBody.transform.position.x, _rigidBody.transform.position.z);
		_rigidBody.position = new Vector3(_rigidBody.transform.position.x, y, _rigidBody.transform.position.z);
	}

	public Rigidbody InitializeRigidbody(bool attachedComponentOnly = false)
	{
		if ((bool)_rigidBody)
		{
			return _rigidBody;
		}
		_rigidBody = GetComponent<Rigidbody>();
		if (_rigidBody == null)
		{
			if (attachedComponentOnly)
			{
				return null;
			}
			_rigidBody = base.gameObject.AddComponent<Rigidbody>();
		}
		ApplyPhysicsPropertiesToRigidbody(_rigidBody, Properties);
		return _rigidBody;
	}

	private void ApplyPhysicsPropertiesToRigidbody(Rigidbody rigidbody, PhysicsProperties properties)
	{
		RigidbodyConstraints rigidbodyConstraints = RigidbodyConstraints.None;
		rigidbody.mass = Properties.Mass;
		rigidbody.linearDamping = Properties.Drag;
		rigidbody.angularDamping = Properties.AngularDrag;
		rigidbody.useGravity = Properties.UseGravity;
		rigidbody.isKinematic = Properties.IsKinematic;
		if (Properties.FreezePositionX)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezePositionX;
		}
		if (Properties.FreezePositionY)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezePositionY;
		}
		if (Properties.FreezePositionZ)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezePositionZ;
		}
		if (Properties.FreezeRotationX)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezeRotationX;
		}
		if (Properties.FreezeRotationY)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezeRotationY;
		}
		if (Properties.FreezeRotationZ)
		{
			rigidbodyConstraints |= RigidbodyConstraints.FreezeRotationZ;
		}
		rigidbody.constraints = (_originalConstraints = rigidbodyConstraints);
	}

	public void DestroyRigidbody()
	{
		if ((bool)_rigidBody)
		{
			Object.Destroy(_rigidBody);
			GameManager.UpdateManager.UnregisterFixedUpdateTarget(this);
		}
	}
}
