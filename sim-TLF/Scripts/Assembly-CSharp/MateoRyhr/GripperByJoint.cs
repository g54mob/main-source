using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class GripperByJoint : MonoBehaviour, IGameObject, IRigidbody
	{
		[Tooltip("A gameobject with a ConfigurableJoint")]
		[SerializeField]
		private ConfigurableJoint _gripperJoint;

		[SerializeField]
		private Transform _gripperJointParent;

		[SerializeField]
		private Transform _gripperPointRayCaster;

		[SerializeField]
		private Transform _pointToInteractWithJoints;

		[SerializeField]
		private LayerMask _grippableObjectLayer;

		[Header("Interaction")]
		[SerializeField]
		private float _maxInteractionDistance = 1.7f;

		[SerializeField]
		private float _minInteractionDistance = 0.45f;

		[SerializeField]
		private float _maxForce = 8f;

		[SerializeField]
		private float _forceMassMultiplier = 50f;

		[Header("Carry Weight System")]
		[SerializeField]
		private bool _massAffectGrabCarry;

		[SerializeField]
		[Range(0f, 100f)]
		private float _howMuchMassAffectCarry = 2f;

		[Tooltip("Максимальна вага для розрахунків (100% ефектів)")]
		[SerializeField]
		private float _maxCarryWeight = 50f;

		[Tooltip("Мінімальна вага (0% ефектів, легкі предмети)")]
		[SerializeField]
		private float _minCarryWeight = 1f;

		[Header("Y-Axis Lift Limitation")]
		[SerializeField]
		private bool _enableYAxisMassLimit = true;

		[Tooltip("Наскільки сильно маса обмежує підйом (0 = не обмежує, 1 = повністю блокує)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _yAxisMassResistance = 0.7f;

		[Tooltip("Мінімальний множник гравітації (для легких об'єктів)")]
		[SerializeField]
		private float _minGravityMultiplier;

		[Tooltip("Максимальний множник гравітації (для об'єктів з maxCarryWeight)")]
		[SerializeField]
		private float _maxGravityMultiplier = 3f;

		[Tooltip("Крива впливу ваги на гравітацію")]
		[SerializeField]
		private AnimationCurve _gravityBias = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Player Speed Reduction")]
		[SerializeField]
		private bool _enablePlayerSlowdown = true;

		[Tooltip("Максимальний множник швидкості (для легких об'єктів)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _maxSpeedMultiplier = 1f;

		[Tooltip("Мінімальний множник швидкості (для максимальної ваги)")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _minSpeedMultiplier = 0.3f;

		[Tooltip("Крива впливу ваги на швидкість")]
		[SerializeField]
		private AnimationCurve _speedReductionCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		[Header("Interaction with Joints (Doors, etc.)")]
		[SerializeField]
		private bool _massAffectGrabJoint;

		[SerializeField]
		[Range(0f, 100f)]
		private float _howMuchMassAffectJoints = 10f;

		[Header("Zoom")]
		[SerializeField]
		[Range(0.01f, 0.25f)]
		private float _zoomSpeed;

		[Header("Throw")]
		[SerializeField]
		private bool _massAffectThrow;

		[SerializeField]
		private float _throwForce = 12f;

		[SerializeField]
		private int _grabbedLayer;

		private int _previousLayer;

		private List<int> _childrensPreviousLayers = new List<int>();

		public UnityEvent OnGrabObject;

		public UnityEvent OnDropObject;

		private Rigidbody _grabbingObject;

		private float _interactionDistanceOnStartGrabbing;

		private Joint _grabbingObjectJoint;

		private bool _isGrabbingObject;

		private bool _hasAngularVelocity;

		private float _grabStartHeight;

		private float _currentCarryWeight;

		private float _currentSpeedMultiplier = 1f;

		private float _currentGravityMultiplier;

		private float _zoom;

		private Rigidbody _gripperRigidbody;

		private List<Transform> _grabbingObjectChildrens = new List<Transform>();

		private JointDrive _newDrive;

		private JointDrive _yDrive;

		private const float MAX_GRAB_SPEED = 8192f;

		private const float POSITION_DAMPER = 1024f;

		private const bool USE_ACELERATION = true;

		public float Zoom
		{
			get
			{
				return _zoom;
			}
			set
			{
				_zoom = Mathf.Clamp(value, _minInteractionDistance, _maxInteractionDistance);
			}
		}

		public float CurrentCarryWeight => _currentCarryWeight;

		public float CurrentSpeedMultiplier => _currentSpeedMultiplier;

		public float CurrentGravityMultiplier => _currentGravityMultiplier;

		public float WeightRatio => CalculateWeightRatio(_currentCarryWeight);

		public GameObject GameObject
		{
			get
			{
				if (!(_grabbingObject != null))
				{
					return null;
				}
				return _grabbingObject.gameObject;
			}
		}

		public Rigidbody Rigidbody
		{
			get
			{
				if (!(_grabbingObject != null))
				{
					return null;
				}
				return _grabbingObject;
			}
		}

		private void Awake()
		{
			_newDrive = default(JointDrive);
			_yDrive = default(JointDrive);
			_gripperRigidbody = _gripperJoint.GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			_gripperJointParent.position = GetGripperPoint();
			CheckGrabbingDistance();
			ApplyMassBasedYResistance();
			if (_gripperJoint.connectedBody != null && !_hasAngularVelocity)
			{
				_gripperJoint.connectedBody.angularVelocity = Vector3.zero;
			}
			if (_isGrabbingObject && _grabbingObject == null)
			{
				Drop();
			}
		}

		public void d(Rigidbody objectToGrab)
		{
			if (objectToGrab != null)
			{
				Grab(objectToGrab, objectToGrab.worldCenterOfMass);
			}
		}

		public void Grab(Rigidbody objectToGrab, Vector3 hitPoint)
		{
			if (objectToGrab != null)
			{
				_grabbingObject = objectToGrab;
				_grabbingObjectJoint = _grabbingObject.GetComponent<Joint>();
				_isGrabbingObject = true;
				_grabStartHeight = hitPoint.y;
				_currentCarryWeight = _grabbingObject.mass;
				UpdateWeightMultipliers();
				StartHoldRigidbody(_grabbingObject, hitPoint);
				_interactionDistanceOnStartGrabbing = Mathf.Clamp(Vector3.Distance(hitPoint, _gripperPointRayCaster.position), _minInteractionDistance, _maxInteractionDistance);
				Zoom = _interactionDistanceOnStartGrabbing;
				OnGrabObject?.Invoke();
			}
		}

		public void Drop()
		{
			if (_isGrabbingObject)
			{
				_interactionDistanceOnStartGrabbing = _maxInteractionDistance;
				StopHoldRigidbody(_grabbingObject);
				_grabbingObjectJoint = null;
				_grabbingObject = null;
				_isGrabbingObject = false;
				_currentCarryWeight = 0f;
				_currentSpeedMultiplier = 1f;
				_currentGravityMultiplier = 0f;
				OnDropObject?.Invoke();
			}
		}

		private float CalculateWeightRatio(float weight)
		{
			if (_maxCarryWeight <= _minCarryWeight)
			{
				return 0f;
			}
			return Mathf.Clamp01((weight - _minCarryWeight) / (_maxCarryWeight - _minCarryWeight));
		}

		private void UpdateWeightMultipliers()
		{
			float time = CalculateWeightRatio(_currentCarryWeight);
			if (_enablePlayerSlowdown)
			{
				float t = _speedReductionCurve.Evaluate(time);
				_currentSpeedMultiplier = Mathf.Lerp(_maxSpeedMultiplier, _minSpeedMultiplier, t);
			}
			else
			{
				_currentSpeedMultiplier = 1f;
			}
			if (_enableYAxisMassLimit)
			{
				float t2 = _gravityBias.Evaluate(time);
				_currentGravityMultiplier = Mathf.Lerp(_minGravityMultiplier, _maxGravityMultiplier, t2);
			}
			else
			{
				_currentGravityMultiplier = 0f;
			}
		}

		private void StartHoldRigidbody(Rigidbody rb, Vector3 hitPoint)
		{
			_newDrive.positionSpring = 8192f;
			_grabbingObjectChildrens.Clear();
			_grabbingObjectChildrens = TransformUtil.GetAllChildren(_grabbingObject.transform);
			_childrensPreviousLayers.Clear();
			_previousLayer = rb.gameObject.layer;
			float weightRatio = CalculateWeightRatio(rb.mass);
			if (_grabbingObjectJoint != null)
			{
				if (_massAffectGrabJoint)
				{
					_newDrive.positionSpring = Mathf.Clamp(_newDrive.positionSpring / rb.mass / (_howMuchMassAffectJoints / 100f), 0f, 8192f);
				}
			}
			else if (_massAffectGrabCarry)
			{
				_newDrive.positionSpring = Mathf.Clamp(_newDrive.positionSpring / rb.mass / (_howMuchMassAffectCarry / 100f), 0f, 8192f);
			}
			_newDrive.positionDamper = 1024f;
			_newDrive.maximumForce = _maxForce + _forceMassMultiplier * rb.mass;
			_newDrive.useAcceleration = true;
			SetupYAxisDrive(rb, weightRatio);
			_gripperJoint.xDrive = _newDrive;
			_gripperJoint.zDrive = _newDrive;
			_gripperJoint.yDrive = _yDrive;
			_gripperJoint.connectedBody = rb;
			_gripperJoint.connectedAnchor = rb.transform.InverseTransformPoint(hitPoint);
			rb.useGravity = false;
		}

		private void SetupYAxisDrive(Rigidbody rb, float weightRatio)
		{
			_yDrive.positionDamper = 1024f;
			_yDrive.useAcceleration = true;
			if (_enableYAxisMassLimit && _grabbingObjectJoint == null)
			{
				float a = _newDrive.positionSpring * (1f - weightRatio * _yAxisMassResistance);
				_yDrive.positionSpring = Mathf.Max(a, 819.2f);
				float a2 = (_maxForce + _forceMassMultiplier * rb.mass) * (1f - weightRatio * 0.5f);
				_yDrive.maximumForce = Mathf.Max(a2, _maxForce * 0.3f);
			}
			else
			{
				_yDrive.positionSpring = _newDrive.positionSpring;
				_yDrive.maximumForce = _newDrive.maximumForce;
			}
		}

		private void ApplyMassBasedYResistance()
		{
			if (_isGrabbingObject && !(_grabbingObject == null) && _enableYAxisMassLimit && !(_grabbingObjectJoint != null) && _currentGravityMultiplier > 0f)
			{
				float num = ConnectedAnchor().y - _grabStartHeight;
				if (num > 0f)
				{
					float num2 = Physics.gravity.y * _currentGravityMultiplier * num;
					_grabbingObject.AddForce(Vector3.up * num2, ForceMode.Acceleration);
				}
			}
		}

		private void StopHoldRigidbody(Rigidbody rb)
		{
			_gripperJoint.connectedBody = null;
			if (!(rb == null))
			{
				rb.useGravity = true;
			}
		}

		public void Throw()
		{
			if ((bool)_grabbingObject)
			{
				Rigidbody component = _grabbingObject.GetComponent<Rigidbody>();
				Vector3 force = _gripperPointRayCaster.forward * _throwForce;
				if (!_massAffectThrow)
				{
					force *= component.mass;
				}
				Drop();
				component.AddForce(force, ForceMode.Impulse);
			}
		}

		public void CheckGrabbingDistance()
		{
			if ((bool)_grabbingObject && Vector3.Distance(ConnectedAnchor(), _gripperPointRayCaster.position) > _maxInteractionDistance + _maxInteractionDistance * 0.25f)
			{
				Drop();
			}
		}

		private float InteractionDistance()
		{
			if (!_grabbingObject)
			{
				return _maxInteractionDistance;
			}
			if (_grabbingObjectJoint == null)
			{
				return _interactionDistanceOnStartGrabbing;
			}
			return Mathf.Clamp(Vector3.Distance(ConnectedAnchor(), _gripperPointRayCaster.position), _minInteractionDistance, _maxInteractionDistance);
		}

		private Vector3 TargetPoint()
		{
			return _gripperPointRayCaster.position + _gripperPointRayCaster.forward * Zoom;
		}

		private Vector3 GetGripperPoint()
		{
			if (_grabbingObjectJoint != null)
			{
				return GrabbingJointInteractionPoint();
			}
			return TargetPoint();
		}

		public void ActiveAngularVelocity()
		{
			_hasAngularVelocity = true;
		}

		public void DesactiveAngularVelocity()
		{
			_hasAngularVelocity = false;
		}

		public void IncreaseDistance()
		{
			Zoom += _zoomSpeed;
		}

		public void DecreaseDistance()
		{
			Zoom -= _zoomSpeed;
		}

		private Vector3 ConnectedAnchor()
		{
			return _grabbingObject.transform.TransformPoint(_gripperJoint.connectedAnchor);
		}

		private Vector3 GrabbingJointInteractionPoint()
		{
			return ConnectedAnchor() + (TargetPoint() - ConnectedAnchor()).normalized * Vector3.Distance(TargetPoint(), ConnectedAnchor()) * 0.3f;
		}
	}
}
