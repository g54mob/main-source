using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam.Performance;
using PajamaLlama.Math;
using UnityEngine;

public class Buoyancy : MonoBehaviour, IUpdateManagerFixedUpdateTarget, IUpdateManagerUpdateTarget, IUpdateManagerLateUpdateTarget
{
	public enum QualityLevel
	{
		None = 0,
		Low = 1,
		Medium = 2,
		High = 3
	}

	public bool _buoyancyEnabled = true;

	public PhysicsProperties _properties;

	public bool IsFalling;

	public bool DrawGizmos;

	[Range(0f, 1f)]
	public float WaterLevelLerp = 0.75f;

	private const float DAMPFER = 0.1f;

	private const float WATER_DENSITY = 1000f;

	private float voxelHalfHeight;

	private Vector3 localArchimedesForce;

	private bool isMeshCollider;

	private List<Vector3[]> forces;

	private float _dampferXmass;

	private float _voxelHeight;

	private float _margin;

	private PhysicsController _physicsController;

	private Rigidbody _rigidBody;

	private Vector3 _centerOfMass;

	private float waterLevel;

	private float k;

	private Vector3 wp;

	private Vector3 velocity;

	private Vector3 localDampingForce;

	private Vector3 force;

	private bool _allowsLevelOfDetail;

	protected bool _isInWaterCached;

	protected bool _isFullySubmerged;

	protected float _colliderVerticalBoundsSize = 1f;

	private QualityLevel _setting;

	private WaterManager _waterManager;

	private bool _hasWaterLevels;

	private float _myWaterLevel;

	private WaterManager.WaterHeightCalculation _waterHeightCalculation;

	private float[] _voxelWaterLevels;

	private CameraController _cameraController;

	private float _levelOfDetailCameraDistance = float.MaxValue;

	private Transform _transform;

	private Renderer _renderer;

	private bool _updateBuoyancy;

	public bool IsInWater => _isInWaterCached;

	public bool IsFullySubmerged => _isFullySubmerged;

	private void Start()
	{
		InitializeReferences();
	}

	private void OnEnable()
	{
		switch (_setting)
		{
		case QualityLevel.None:
			return;
		case QualityLevel.Low:
			GameManager.UpdateManager.RegisterUpdateTarget(this);
			break;
		case QualityLevel.Medium:
		case QualityLevel.High:
			GameManager.UpdateManager.RegisterFixedUpdateTarget(this);
			break;
		}
		GameManager.UpdateManager.RegisterLateUpdateTarget(this);
	}

	private void OnDisable()
	{
		switch (_setting)
		{
		case QualityLevel.None:
			return;
		case QualityLevel.Low:
			GameManager.UpdateManager.UnregisterUpdateTarget(this);
			break;
		case QualityLevel.Medium:
		case QualityLevel.High:
			GameManager.UpdateManager.UnregisterFixedUpdateTarget(this);
			break;
		}
		GameManager.UpdateManager.UnregisterLateUpdateTarget(this);
	}

	public void Initialize(PhysicsController controller, float spawnHeight = 0f)
	{
		InitializeReferences(controller);
		if (controller == null)
		{
			Debugger.Error("No physics properties assigned", this);
		}
		else
		{
			_properties = controller.Properties;
			_allowsLevelOfDetail = _properties.AllowsBuoyancyLevelOfDetail && _renderer != null;
			_levelOfDetailCameraDistance = _properties.BuoyancyLevelOfDetailCameraDistance;
		}
		forces = new List<Vector3[]>();
		Quaternion rotation = _transform.rotation;
		Vector3 position = _transform.position;
		_transform.rotation = Quaternion.identity;
		_transform.position = Vector3.zero;
		Collider collider = controller.PrimaryCollider;
		if (collider == null)
		{
			collider = base.gameObject.AddComponent<MeshCollider>();
			isMeshCollider = false;
			Debug.LogWarning($"[Buoyancy.cs] Object \"{base.name}\" had no collider. MeshCollider has been added.");
		}
		else
		{
			isMeshCollider = collider is MeshCollider;
		}
		Bounds bounds = collider.bounds;
		Vector3 size = bounds.size;
		_colliderVerticalBoundsSize = size.y;
		if (size.x < size.y)
		{
			voxelHalfHeight = size.x;
		}
		else
		{
			voxelHalfHeight = size.y;
		}
		if (size.z < voxelHalfHeight)
		{
			voxelHalfHeight = size.z;
		}
		voxelHalfHeight /= 2f * _properties.Slices.y;
		_centerOfMass = new Vector3(0f, (0f - bounds.extents.y) * 0f, 0f) + _transform.InverseTransformPoint(bounds.center);
		List<Vector3> voxels = SliceIntoVoxels(bounds.min, size, bounds.center, isMeshCollider && _properties.IsConcave);
		_waterHeightCalculation = new WaterManager.WaterHeightCalculation(_transform, voxels, UpdateWaterLevels);
		_voxelWaterLevels = new float[_waterHeightCalculation.VoxelCount];
		_transform.rotation = rotation;
		float num = _properties.Mass / _properties.Density;
		float y = 1000f * Mathf.Abs(Physics.gravity.y) * num;
		localArchimedesForce = new Vector3(0f, y, 0f) / _waterHeightCalculation.VoxelCount;
		Vector3 zero = Vector3.zero;
		zero = ((spawnHeight != 0f) ? new Vector3(position.x, spawnHeight, position.z) : ((!_properties.SpawnBeneathWaterSurface) ? WorldManager.WaterAdjustedPosition(position) : (WorldManager.WaterAdjustedPosition(position) + Vector3.down * 10f)));
		_transform.position = zero;
		_dampferXmass = 0f - 0.1f * _properties.Mass;
		_voxelHeight = voxelHalfHeight * 2f;
		_margin = 0.2f;
		_physicsController.PhysicsActive(active: true);
		if (_allowsLevelOfDetail)
		{
			StartCoroutine(WaitForCameraCoroutine());
		}
		_waterHeightCalculation.Queue(update: true);
		GameManager.UpdateManager.RegisterLateUpdateTarget(this);
		SetQualityLevel(_properties.BuoyancySetting);
	}

	private void InitializeReferences(PhysicsController controller = null)
	{
		_transform = base.transform;
		if (_physicsController == null)
		{
			_physicsController = ((controller == null) ? GetComponent<PhysicsController>() : controller);
		}
		if (_waterManager == null)
		{
			_waterManager = WaterManager.Instance;
		}
		if (_renderer == null)
		{
			_renderer = GetComponentInChildren<Renderer>();
		}
	}

	public void UpdateManager_FixedUpdate()
	{
		if (!_updateBuoyancy)
		{
			return;
		}
		Vector3 position = _waterHeightCalculation.UpdatePosition();
		if (_waterHeightCalculation.ApplyForces)
		{
			PerformWaterTest(position.y, _myWaterLevel);
			for (int i = 0; i < _waterHeightCalculation.VoxelCount; i++)
			{
				wp = _waterHeightCalculation.UpdateVoxelPosition(i);
				waterLevel = _voxelWaterLevels[i];
				if (wp.y - voxelHalfHeight < waterLevel - _margin)
				{
					k = Mathf.Clamp((waterLevel - wp.y) / _voxelHeight + 0.5f, 0f, 1f);
					_rigidBody.AddForceAtPosition(CalculateForce(_rigidBody.GetPointVelocity(wp), Mathf.Sqrt(k)), wp);
				}
			}
			_waterHeightCalculation.Queue();
		}
		else
		{
			position.y = Mathf.Lerp(position.y, _myWaterLevel, _properties.WaterLevelLerp);
			_rigidBody.MovePosition(position);
			_waterHeightCalculation.Queue(position);
		}
	}

	public void UpdateManager_Update(float deltaTime, int frame)
	{
		if (_hasWaterLevels)
		{
			Vector3 position = _transform.position;
			position.y = Mathf.Lerp(position.y, _myWaterLevel, _properties.WaterLevelLerp);
			_transform.position = position;
			_waterHeightCalculation.Queue(position);
		}
	}

	public void UpdateManager_LateUpdate()
	{
		Vector3 position = _transform.position;
		if (_setting == QualityLevel.High && _allowsLevelOfDetail)
		{
			bool flag = position.IsInRange(_cameraController.CameraPosition, _levelOfDetailCameraDistance);
			if (_waterHeightCalculation.ApplyForces)
			{
				if (!_renderer.isVisible || !flag)
				{
					_waterHeightCalculation.ApplyForces = false;
				}
			}
			else if (flag && _renderer.isVisible)
			{
				_rigidBody.linearVelocity = -Physics.gravity * Time.deltaTime;
				_waterHeightCalculation.ApplyForces = true;
			}
		}
		if (_properties.FloatUpright && _buoyancyEnabled)
		{
			Quaternion b = Quaternion.FromToRotation(_transform.up, Vector3.up) * _transform.rotation;
			_transform.rotation = Quaternion.Slerp(_transform.rotation, b, Time.deltaTime * _properties.UprightRotationalSpeed);
		}
		_updateBuoyancy = _buoyancyEnabled && _hasWaterLevels;
	}

	private void SetQualityLevel(QualityLevel level)
	{
		if (_setting != level)
		{
			UpdateManager updateManager = GameManager.UpdateManager;
			updateManager.UnregisterFixedUpdateTarget(this);
			updateManager.UnregisterUpdateTarget(this);
			switch (level)
			{
			case QualityLevel.High:
				_rigidBody = ReturnRigidbody();
				_rigidBody.isKinematic = false;
				_rigidBody.detectCollisions = true;
				_rigidBody.useGravity = true;
				_waterHeightCalculation.ApplyForces = true;
				updateManager.RegisterFixedUpdateTarget(this);
				break;
			case QualityLevel.Medium:
				_rigidBody = ReturnRigidbody();
				_rigidBody.isKinematic = false;
				_rigidBody.detectCollisions = true;
				_rigidBody.useGravity = false;
				_waterHeightCalculation.ApplyForces = false;
				updateManager.RegisterFixedUpdateTarget(this);
				break;
			default:
				_physicsController.DestroyRigidbody();
				_waterHeightCalculation.ApplyForces = false;
				updateManager.RegisterUpdateTarget(this);
				break;
			}
			_setting = level;
		}
	}

	private Rigidbody ReturnRigidbody()
	{
		Rigidbody rigidbody = _physicsController.InitializeRigidbody();
		rigidbody.centerOfMass = _centerOfMass;
		return rigidbody;
	}

	private void OnDrawGizmos()
	{
		if (!DrawGizmos || _waterHeightCalculation == null || forces == null)
		{
			return;
		}
		Gizmos.color = Color.yellow;
		Vector3[] voxelPositions = _waterHeightCalculation.VoxelPositions;
		foreach (Vector3 position in voxelPositions)
		{
			Gizmos.DrawCube(_transform.TransformPoint(position), new Vector3(0.05f, 0.05f, 0.05f));
		}
		Gizmos.color = Color.cyan;
		foreach (Vector3[] force in forces)
		{
			Gizmos.DrawCube(force[0], new Vector3(0.05f, 0.05f, 0.05f));
			Gizmos.DrawLine(force[0], force[0] + force[1] / GetComponent<Rigidbody>().mass);
		}
	}

	private void OnMouseUp()
	{
		if (GameSpeedManager.GameSpeed != GameSpeed.Paused && GameSpeedManager.GameSpeed != GameSpeed.Zero)
		{
			Vector3 position = _transform.position.SetY(WorldManager.WaterHeight(_transform.position.x, _transform.position.z)) + Vector3.up * 0.25f;
			ParticleController.Spawn(GameManager.Settings.FXSettings.Splash, position, Quaternion.identity);
			if ((bool)_rigidBody)
			{
				_rigidBody.AddForce(Vector3.down * GameManager.Settings.PokeForce, ForceMode.Impulse);
			}
		}
	}

	private void OnDestroy()
	{
		if (_setting == QualityLevel.High || _setting == QualityLevel.Medium)
		{
			GameManager.UpdateManager.UnregisterFixedUpdateTarget(this);
		}
		else
		{
			GameManager.UpdateManager.UnregisterUpdateTarget(this);
		}
		GameManager.UpdateManager.UnregisterLateUpdateTarget(this);
	}

	private void UpdateFalling()
	{
		if (IsFalling && _isFullySubmerged)
		{
			_rigidBody.linearVelocity = Vector3.zero;
			_rigidBody.linearDamping = _properties.Drag;
			EffectsManager.ActivateEffect(EffectTrigger.Splash, null, base.transform.position);
			IsFalling = false;
		}
	}

	private IEnumerator WaitForCameraCoroutine()
	{
		_allowsLevelOfDetail = false;
		while (CameraController.Instance.Camera == null)
		{
			yield return null;
		}
		_cameraController = CameraController.Instance;
		_allowsLevelOfDetail = true;
	}

	private List<Vector3> SliceIntoVoxels(Vector3 boundsMin, Vector3 boundsSize, Vector3 boundsCenter, bool concave)
	{
		List<Vector3> list = new List<Vector3>((int)_properties.Slices.x * (int)_properties.Slices.y * (int)_properties.Slices.z);
		float x = boundsMin.x;
		float y = boundsMin.y;
		float z = boundsMin.z;
		float num = boundsSize.x / _properties.Slices.x;
		float num2 = boundsSize.y / _properties.Slices.y;
		float num3 = boundsSize.z / _properties.Slices.z;
		if (concave)
		{
			MeshCollider component = GetComponent<MeshCollider>();
			bool convex = component.convex;
			component.convex = false;
			for (int i = 0; (float)i < _properties.Slices.x; i++)
			{
				float x2 = x + num * (0.5f + (float)i);
				for (int j = 0; (float)j < _properties.Slices.y; j++)
				{
					float y2 = y + num2 * (0.5f + (float)j);
					for (int k = 0; (float)k < _properties.Slices.z; k++)
					{
						float z2 = y + num2 * (0.5f + (float)k);
						Vector3 vector = _transform.InverseTransformPoint(new Vector3(x2, y2, z2));
						if (PointIsInsideMeshCollider(component, vector))
						{
							list.Add(vector);
						}
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add(boundsCenter);
			}
			component.convex = convex;
		}
		else
		{
			for (int l = 0; (float)l < _properties.Slices.x; l++)
			{
				float x2 = x + num * (0.5f + (float)l);
				for (int m = 0; (float)m < _properties.Slices.y; m++)
				{
					float y2 = y + num2 * (0.5f + (float)m);
					for (int n = 0; (float)n < _properties.Slices.z; n++)
					{
						float z2 = z + num3 * (0.5f + (float)n);
						Vector3 item = _transform.InverseTransformPoint(new Vector3(x2, y2, z2));
						list.Add(item);
					}
				}
			}
		}
		WeldPoints(list, _properties.VoxelsLimit);
		return list;
	}

	private static bool PointIsInsideMeshCollider(Collider c, Vector3 p)
	{
		Vector3[] array = new Vector3[6]
		{
			Vector3.up,
			Vector3.down,
			Vector3.left,
			Vector3.right,
			Vector3.forward,
			Vector3.back
		};
		foreach (Vector3 vector in array)
		{
			if (!c.Raycast(new Ray(p - vector * 1000f, vector), out var _, 1000f))
			{
				return false;
			}
		}
		return true;
	}

	private static void FindClosestPoints(IList<Vector3> list, out int firstIndex, out int secondIndex)
	{
		float num = float.MaxValue;
		float num2 = float.MinValue;
		firstIndex = 0;
		secondIndex = 1;
		for (int i = 0; i < list.Count - 1; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				float num3 = Vector3.Distance(list[i], list[j]);
				if (num3 < num)
				{
					num = num3;
					firstIndex = i;
					secondIndex = j;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
		}
	}

	private static void WeldPoints(IList<Vector3> list, int targetCount)
	{
		if (list.Count > 2 && targetCount >= 2)
		{
			while (list.Count > targetCount)
			{
				FindClosestPoints(list, out var firstIndex, out var secondIndex);
				Vector3 item = (list[firstIndex] + list[secondIndex]) * 0.5f;
				list.RemoveAt(secondIndex);
				list.RemoveAt(firstIndex);
				list.Add(item);
			}
		}
	}

	public bool InWater()
	{
		if (_transform.position.y <= WorldManager.WaterHeight(_transform.position.x, _transform.position.z) + 0.1f)
		{
			return true;
		}
		return false;
	}

	private void PerformWaterTest(float testHeight, float waterLevel)
	{
		if (testHeight - _colliderVerticalBoundsSize / 2f <= waterLevel)
		{
			_isInWaterCached = true;
			if (testHeight + _colliderVerticalBoundsSize / 2f <= waterLevel)
			{
				_isFullySubmerged = true;
			}
			else
			{
				_isFullySubmerged = false;
			}
		}
		else
		{
			_isInWaterCached = false;
			_isFullySubmerged = false;
		}
	}

	private void UpdateWaterLevels(WaterManager.WaterHeightCalculation calculation)
	{
		_hasWaterLevels = true;
		_myWaterLevel = calculation.PositionWaterHeight;
		if (calculation.ApplyForces)
		{
			calculation.CopyVoxelWaterHeights(_voxelWaterLevels);
		}
	}

	public void ForceWaterLevel(float waterLevel)
	{
		_myWaterLevel = waterLevel;
	}

	private Vector3 CalculateForce(Vector3 velocity, float kSqrt, float multiplier = 1f)
	{
		velocity.x = velocity.x * _dampferXmass + localArchimedesForce.x * kSqrt;
		velocity.y = velocity.y * _dampferXmass + localArchimedesForce.y * kSqrt;
		velocity.z = velocity.z * _dampferXmass + localArchimedesForce.z * kSqrt;
		return velocity;
	}
}
