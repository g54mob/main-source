using System;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class Vehicle : MonoBehaviour
	{
		[Serializable]
		public class VehicleNitroBoost
		{
			public Rigidbody RigidbodyToBoost;

			public float NitroForce = 200f;

			public float NitroBar = 1f;

			public float SpendNitroSpeed = 2f;

			public float RechargeNitroSpeed = 0.5f;

			public GameObject NitroParticle;

			public bool CanUseNitroState;

			public bool UsingNitroState;

			public void SimulateNitro(bool NitroInputValue)
			{
				if (RigidbodyToBoost == null)
				{
					return;
				}
				if (UsingNitroState)
				{
					RigidbodyToBoost.AddRelativeForce(0f, 0f, NitroForce, ForceMode.Acceleration);
					NitroBar -= Time.deltaTime;
					if (NitroBar <= 0f)
					{
						Debug.Log("Nitro ended");
						CanUseNitroState = false;
						UsingNitroState = false;
					}
				}
				if (CanUseNitroState && !UsingNitroState)
				{
					if (NitroInputValue)
					{
						RigidbodyToBoost.AddRelativeForce(0f, 0f, NitroForce, ForceMode.Impulse);
						CanUseNitroState = false;
						UsingNitroState = true;
					}
				}
				else if (!UsingNitroState)
				{
					NitroBar += RechargeNitroSpeed * Time.deltaTime;
					if (NitroBar > 1f)
					{
						NitroBar = 1f;
						CanUseNitroState = true;
						Debug.Log("Nitro Fully");
					}
				}
				if (NitroParticle != null)
				{
					NitroParticle.SetActive(UsingNitroState);
				}
			}
		}

		[Serializable]
		public class VehicleGroundCheck
		{
			[Header("Ground Check")]
			public Vector3 RaycastOrigin;

			public float RaycastDistance;

			public LayerMask RaycastLayerMask;

			[Header("State")]
			public bool IsGrounded;

			public RaycastHit GroundHit;

			public void GroundCheck(Transform vehicle, Vector3 VehicleDownDirection = default(Vector3))
			{
				if (Physics.Raycast(vehicle.position + vehicle.right * RaycastOrigin.x + vehicle.up * RaycastOrigin.y + vehicle.forward * RaycastOrigin.z, (VehicleDownDirection == Vector3.zero) ? (-vehicle.up) : VehicleDownDirection, out GroundHit, RaycastDistance, RaycastLayerMask))
				{
					IsGrounded = true;
				}
				else
				{
					IsGrounded = false;
				}
			}
		}

		[Serializable]
		public class VehicleOverturnCheck
		{
			[Header("Overturn Check")]
			public Vector3 CheckboxPosition = new Vector3(0f, 1.5f, 0f);

			public Vector3 CheckboxScale = new Vector3(0.4f, 0.3f, 1.5f);

			public LayerMask CheckboxLayerMask;

			[Header("Anti-Overturn")]
			public bool EnableAntiOverturn;

			public float AntiOverturnSpeed = 1f;

			[Header("State")]
			public bool IsOverturned;

			private RaycastHit GroundHit;

			public void OverturnCheck(Transform vehicle)
			{
				Collider[] array = Physics.OverlapBox(vehicle.position + vehicle.right * CheckboxPosition.x + vehicle.up * CheckboxPosition.y + vehicle.forward * CheckboxPosition.z, CheckboxScale, vehicle.rotation, CheckboxLayerMask);
				IsOverturned = array.Length != 0;
			}

			public void AntiOverturn(Transform vehicle)
			{
				if (IsOverturned)
				{
					vehicle.rotation = Quaternion.Lerp(vehicle.rotation, Quaternion.FromToRotation(vehicle.up, GroundHit.normal) * vehicle.rotation, AntiOverturnSpeed * Time.deltaTime);
				}
			}
		}

		[Serializable]
		public class VehicleOverlapBoxCheck
		{
			[Header("Overturn Check")]
			public Vector3 CheckboxPosition = new Vector3(0f, 0f, 0f);

			public Vector3 CheckboxScale = new Vector3(0.4f, 0.4f, 0.4f);

			public LayerMask CheckboxLayerMask;

			[Header("State")]
			public bool Collided;

			private RaycastHit GroundHit;

			public void Check(Transform vehicle)
			{
				Collider[] array = Physics.OverlapBox(vehicle.position + vehicle.right * CheckboxPosition.x + vehicle.up * CheckboxPosition.y + vehicle.forward * CheckboxPosition.z, CheckboxScale, vehicle.rotation, CheckboxLayerMask);
				Collided = array.Length != 0;
				if (Collided)
				{
					Debug.Log("collided");
				}
			}
		}

		[Serializable]
		public class VehicleRaycastCheck
		{
			[Header("Raycast Check")]
			public Vector3 OriginPosition = new Vector3(0f, 0f, 0f);

			public float RayMaxDistance = 1f;

			public LayerMask RayLayerMask;

			[Header("State")]
			public bool IsCollided;

			public RaycastHit raycastHit;

			public void Check(Transform vehicle, Vector3 direction)
			{
				Vector3 origin = vehicle.position + vehicle.right * OriginPosition.x + vehicle.up * OriginPosition.y + vehicle.forward * OriginPosition.z;
				IsCollided = Physics.Raycast(origin, direction, out raycastHit, RayMaxDistance, RayLayerMask);
			}
		}

		[Serializable]
		public class IKTargetPositions
		{
			public Transform PlayerLocation;

			public Transform LeftHandPositionIK;

			public Transform RightHandPositionIK;

			public Transform LeftFootPositionIK;

			public Transform RightFootPositionIK;
		}

		[Serializable]
		public class VehicleEngineSettings
		{
			public float MaxVelocity = 160f;

			public float TorqueForce = 2000f;

			public float BrakeForce = 8000f;

			public Transform CenterOfMass;
		}

		[Serializable]
		public class DrivingProceduralAnimationWeights
		{
			public float FrontalLeanWeight;

			public float SideLeanWeight;

			public float LookAtDirectionWeight;

			public float HintMovementWeight;

			public bool FootPlacement;
		}

		public static class VehicleGizmo
		{
			public static void DrawVector3Position(Vector3 position, Transform Vehicle, string Label = "", Color color = default(Color))
			{
				if (color != Color.clear)
				{
					Gizmos.color = color;
				}
				Vector3 center = Vehicle.position + Vehicle.right * position.x + Vehicle.up * position.y + Vehicle.forward * position.z;
				_ = Label != "";
				Gizmos.DrawSphere(center, 0.03f);
			}

			public static void DrawVehicleInclination(Transform RotationParent, Transform RotationChild)
			{
				if (!(RotationChild == null) && !(RotationParent == null))
				{
					Vector3 center = RotationParent.position + RotationParent.up * 1f;
					Vector3 center2 = RotationChild.position + RotationChild.up * 1f;
					Gizmos.color = Color.white;
					Gizmos.DrawWireSphere(center, 0.01f);
					Gizmos.color = Color.white;
					Gizmos.DrawWireSphere(center2, 0.01f);
					Gizmos.color = Color.grey;
					Gizmos.DrawRay(RotationParent.position, RotationParent.up);
					Gizmos.color = Color.green;
					Gizmos.DrawRay(RotationChild.position, RotationChild.up);
					Gizmos.color = Color.green;
					Gizmos.DrawLine(RotationParent.position - RotationParent.right, RotationParent.position + RotationParent.right);
				}
			}

			public static void DrawRaycastHit(VehicleRaycastCheck rayCheck, Transform vehicle, Vector3 direction)
			{
				Gizmos.color = (rayCheck.IsCollided ? Color.green : Color.red);
				Vector3 vector = vehicle.position + vehicle.right * rayCheck.OriginPosition.x + vehicle.up * rayCheck.OriginPosition.y + vehicle.forward * rayCheck.OriginPosition.z;
				Gizmos.DrawLine(vector, rayCheck.IsCollided ? rayCheck.raycastHit.point : (vector + direction * rayCheck.RayMaxDistance));
			}

			public static void DrawOverturnCheck(VehicleOverturnCheck OverturnCheck, Transform Vehicle)
			{
				if (OverturnCheck.EnableAntiOverturn)
				{
					Gizmos.matrix = Matrix4x4.TRS(Vehicle.position, Vehicle.rotation, Vehicle.localScale);
					Gizmos.color = (OverturnCheck.IsOverturned ? Color.green : Color.red);
					Gizmos.DrawWireCube(Vector3.zero + Vector3.up * OverturnCheck.CheckboxPosition.y + Vector3.right * OverturnCheck.CheckboxPosition.x + Vector3.forward * OverturnCheck.CheckboxPosition.z, OverturnCheck.CheckboxScale);
				}
			}

			public static void DrawOverlapBoxCheck(VehicleOverlapBoxCheck BoxCheck, Transform Vehicle)
			{
				Gizmos.matrix = Matrix4x4.TRS(Vehicle.position, Vehicle.rotation, Vehicle.localScale);
				Gizmos.color = (BoxCheck.Collided ? Color.green : Color.red);
				Gizmos.DrawWireCube(Vector3.zero + Vector3.up * BoxCheck.CheckboxPosition.y + Vector3.right * BoxCheck.CheckboxPosition.x + Vector3.forward * BoxCheck.CheckboxPosition.z, BoxCheck.CheckboxScale);
			}

			public static void DrawVehicleGroundCheck(VehicleGroundCheck GroundCheck, Transform Vehicle)
			{
				Gizmos.color = (GroundCheck.IsGrounded ? Color.green : Color.red);
				Gizmos.DrawLine(Vehicle.position + GroundCheck.RaycastOrigin, Vehicle.position + GroundCheck.RaycastOrigin - Vehicle.up * GroundCheck.RaycastDistance);
			}
		}

		[HideInInspector]
		public Rigidbody rb;

		protected float _horizontal;

		protected float _vertical;

		protected float _smoothedHorizontal;

		protected float _smoothedForward;

		protected float _inclination;

		protected bool _brake;

		private Vector3 _oldPosition;

		private float _currentMagnitude;

		[Header("Vehicle Locomotion Settings")]
		public Vector3 CharacterExitingPosition = new Vector3(-1f, 0f, 0f);

		public VehicleEngineSettings VehicleEngine;

		[Header("Steering Wheel Settings")]
		public GameObject SteeringWheel;

		public float MaxSteerAngle = 20f;

		[Header("Ground Check")]
		public VehicleGroundCheck GroundCheck;

		[Header("Driver Inverse Kinematics")]
		public IKTargetPositions InverseKinematicTargetPositions;

		[Header("Driver Procedural Animation Weights")]
		public DrivingProceduralAnimationWeights AnimationWeights;

		[Header("Vehicle State")]
		public bool IsOn;

		protected virtual void Awake()
		{
			rb = GetComponent<Rigidbody>();
		}

		protected virtual void Update()
		{
			VehicleUpdate();
			_smoothedForward = Mathf.Lerp(_smoothedForward, GetForwardAxisPhysicalMovement(), 5f * Time.deltaTime);
			_smoothedHorizontal = Mathf.Lerp(_smoothedHorizontal, GetHorizontalMovement(), 5f * Time.deltaTime);
			if (rb == null)
			{
				_currentMagnitude = Mathf.Lerp(_currentMagnitude, (base.transform.position - _oldPosition).magnitude * 100f, 10f * Time.deltaTime);
				_oldPosition = base.transform.position;
			}
			else
			{
				_currentMagnitude = Mathf.Lerp(_currentMagnitude, rb.velocity.magnitude, 10f * Time.deltaTime);
			}
		}

		protected virtual void FixedUpdate()
		{
			VehiclePhysicsUpdate();
		}

		protected virtual void VehicleUpdate()
		{
		}

		protected virtual void VehiclePhysicsUpdate()
		{
		}

		public virtual void SetEngineInputs(float HorizontalInput, float VerticalInput, bool BrakeInput)
		{
			_horizontal = HorizontalInput;
			_vertical = VerticalInput;
			_brake = BrakeInput;
		}

		public void GetEngineInputs(out float HorizontalInput, out float VerticalInput, out bool BrakeInput)
		{
			HorizontalInput = _horizontal;
			VerticalInput = _vertical;
			BrakeInput = _brake;
		}

		public float GetHorizontalInput()
		{
			return _horizontal;
		}

		public float GetVerticalInput()
		{
			return _vertical;
		}

		public bool GetBrakeInput()
		{
			return _brake;
		}

		public virtual void Jump(float JumpForce, bool IsGrounded)
		{
			if (IsGrounded)
			{
				rb.AddRelativeForce(0f, JumpForce, 0f, ForceMode.Impulse);
			}
		}

		protected Quaternion SteeringWheelRotation(GameObject SteeringWheel, WheelCollider WheelToGetSteerAngle, float MultiplySteeringWheelRotation = 1f)
		{
			float y = MultiplySteeringWheelRotation * WheelToGetSteerAngle.steerAngle;
			return Quaternion.Euler(new Vector3(SteeringWheel.transform.localEulerAngles.x, y, SteeringWheel.transform.localEulerAngles.x));
		}

		protected Quaternion SteeringWheelRotation(GameObject SteeringWheel, float MultiplySteeringWheelRotation = 1f)
		{
			float y = MultiplySteeringWheelRotation * MaxSteerAngle * _smoothedHorizontal;
			return Quaternion.Euler(new Vector3(SteeringWheel.transform.localEulerAngles.x, y, SteeringWheel.transform.localEulerAngles.x));
		}

		protected virtual void CreateSteeringWheelRotationPivot(GameObject SteeringWheel)
		{
			GameObject gameObject = new GameObject("Steering Wheel");
			gameObject.transform.position = SteeringWheel.transform.position;
			gameObject.transform.rotation = SteeringWheel.transform.rotation;
			gameObject.transform.parent = SteeringWheel.transform.parent;
			SteeringWheel.transform.parent = gameObject.transform;
		}

		protected virtual void CreateSteeringWheelRotationPivot(GameObject SteeringWheel, out GameObject SteeringWheelRotationPivot)
		{
			GameObject gameObject = new GameObject("Steering Wheel");
			gameObject.transform.position = SteeringWheel.transform.position;
			gameObject.transform.rotation = SteeringWheel.transform.rotation;
			gameObject.transform.parent = SteeringWheel.transform.parent;
			SteeringWheelRotationPivot = gameObject;
			SteeringWheel.transform.parent = gameObject.transform;
		}

		protected void WheelSteerAngle(WheelCollider wheel, float SteerAngle, float MaxSteerAngle = 45f)
		{
			SteerAngle = Mathf.Clamp(SteerAngle, 0f - MaxSteerAngle, MaxSteerAngle);
			wheel.steerAngle = SteerAngle;
		}

		protected void WheelTorque(WheelCollider wheel)
		{
			wheel.motorTorque = _vertical * VehicleEngine.TorqueForce;
		}

		protected void WheelBrake(WheelCollider wheel)
		{
			float num = ((_brake || !IsOn) ? VehicleEngine.BrakeForce : 0f);
			float num2 = ((_vertical == 0f) ? (VehicleEngine.BrakeForce / 15f) : num);
			wheel.brakeTorque = (_brake ? num : num2);
		}

		protected void UpdateWheelModelTransformation(WheelCollider wheel_collider, Transform wheel_model, bool JustRotateOnXAxist = false)
		{
			wheel_collider.GetWorldPose(out var pos, out var quat);
			wheel_model.position = pos;
			if (JustRotateOnXAxist)
			{
				Vector3 eulerAngles = quat.eulerAngles;
				eulerAngles.y = 0f;
				eulerAngles.z = 0f;
				wheel_model.localEulerAngles = eulerAngles;
			}
			else
			{
				wheel_model.rotation = quat;
			}
		}

		protected void AddForwardAcceleration(float AccelerationForce)
		{
			if (IsOn)
			{
				rb.AddRelativeForce(0f, 0f, AccelerationForce, ForceMode.Acceleration);
			}
		}

		protected void LimitVehicleSpeed(bool IsGrounded = true, bool LimitGravity = false)
		{
			if (IsGrounded && rb.velocity.magnitude > VehicleEngine.MaxVelocity)
			{
				Vector3 velocity = rb.velocity;
				velocity = Vector3.ClampMagnitude(velocity, VehicleEngine.MaxVelocity);
				if (!LimitGravity)
				{
					velocity.y = rb.velocity.y;
				}
				rb.velocity = velocity;
			}
		}

		protected void SimulateAntiRollBar(float AntiRollForce, WheelCollider LeftWheel, WheelCollider RightWheel)
		{
			float num = 1f;
			float num2 = 1f;
			WheelHit hit;
			bool groundHit = LeftWheel.GetGroundHit(out hit);
			if (groundHit)
			{
				num = (0f - LeftWheel.transform.InverseTransformPoint(hit.point).y - LeftWheel.radius) / LeftWheel.suspensionDistance;
			}
			bool groundHit2 = RightWheel.GetGroundHit(out hit);
			if (groundHit2)
			{
				num2 = (0f - RightWheel.transform.InverseTransformPoint(hit.point).y - RightWheel.radius) / RightWheel.suspensionDistance;
			}
			float num3 = (num - num2) * AntiRollForce;
			if (groundHit)
			{
				rb.AddForceAtPosition(LeftWheel.transform.up * (0f - num3), LeftWheel.transform.position);
			}
			if (groundHit2)
			{
				rb.AddForceAtPosition(RightWheel.transform.up * num3, RightWheel.transform.position);
			}
		}

		protected void SetVehicleCenterOfMass(Transform position)
		{
			if (!(position == null))
			{
				if (position.parent != base.transform)
				{
					Debug.LogWarning("Failed to set Vehicle Center of Mass because the selected Transform is not a child of the Vehicle");
				}
				else
				{
					rb.centerOfMass = position.localPosition;
				}
			}
		}

		public float GetVehicleCurrentSpeed(float Multiplier = 1f)
		{
			if (!(_currentMagnitude * Multiplier > 0.0001f))
			{
				return 0f;
			}
			return _currentMagnitude * Multiplier;
		}

		protected void SimulateVehicleInclination(float InclinationValue, float MaxInclinationAngle, Transform RotationPivotParent, Transform RotationPivotChild, bool FreezeRotationToBetterSimulation = true, float SimulationForce = 8f, float OnGroundRigidbodyDrag = 5f, float OffGroundRigidbodyDrag = 1f, Vector3 GroundAligment = default(Vector3))
		{
			if (RotationPivotChild.parent != RotationPivotParent)
			{
				Debug.LogError("The parent of the RotationPivotChild variable is not the same GameObject as the RotationPivotParent");
				return;
			}
			float b = GetForwardAxisPhysicalMovement() + rb.velocity.magnitude / 10f * (0f - InclinationValue);
			float b2 = (0f - GetForwardAxisPhysicalMovement()) / 2f + rb.velocity.magnitude / 10f * (0f - InclinationValue);
			if (GetForwardAxisPhysicalMovement() > 0f)
			{
				_inclination = Mathf.Lerp(_inclination, b, 8f * Time.deltaTime);
			}
			if (GetForwardAxisPhysicalMovement() < 0f)
			{
				_inclination = Mathf.Lerp(_inclination, b2, 8f * Time.deltaTime);
			}
			if (GetVehicleCurrentSpeed() == 0f)
			{
				_inclination = Mathf.Lerp(_inclination, InclinationValue, 8f * Time.deltaTime);
			}
			_inclination = Mathf.Clamp(_inclination, 0f - MaxInclinationAngle, MaxInclinationAngle);
			_inclination = (_brake ? 0f : _inclination);
			Vector3 zero = Vector3.zero;
			zero.z = _inclination;
			RotationPivotChild.localEulerAngles = new Vector3(0f, 0f, _inclination);
			RotationPivotParent.position = base.transform.position;
			RotationPivotParent.rotation = Quaternion.Slerp(RotationPivotParent.rotation, Quaternion.FromToRotation(RotationPivotParent.up, (GroundAligment != Vector3.zero) ? GroundAligment : GroundCheck.GroundHit.normal) * RotationPivotParent.rotation, 5f * Time.deltaTime);
			RotationPivotParent.localEulerAngles = new Vector3(RotationPivotParent.localEulerAngles.x, base.transform.localEulerAngles.y, RotationPivotParent.localEulerAngles.z);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, RotationPivotChild.rotation, SimulationForce * Time.deltaTime);
			if (FreezeRotationToBetterSimulation)
			{
				if (GroundCheck.IsGrounded)
				{
					rb.angularDrag = OnGroundRigidbodyDrag;
					rb.constraints = RigidbodyConstraints.FreezeRotationZ;
				}
				else
				{
					rb.angularDrag = OffGroundRigidbodyDrag;
					rb.constraints = RigidbodyConstraints.None;
				}
			}
		}

		protected void SimulateGroundAlignment(float AlignmentSpeed = 8f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.FromToRotation(base.transform.up, GroundCheck.GroundHit.normal) * base.transform.rotation, AlignmentSpeed * Time.deltaTime);
		}

		protected void Align(Vector3 Normal, float AlignmentSpeed = 1f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.FromToRotation(base.transform.up, Normal) * base.transform.rotation, AlignmentSpeed * Time.deltaTime);
		}

		public float GetForwardAxisPhysicalMovement()
		{
			float result = 0f;
			if (rb != null)
			{
				return Vector3.Dot(base.transform.forward, rb.velocity.normalized);
			}
			return result;
		}

		public float GetHorizontalMovement()
		{
			return _horizontal;
		}

		public float GetSmoothedForwardMovement()
		{
			return _smoothedForward;
		}

		public float GetSmoothedHorizontalMovement()
		{
			return _smoothedHorizontal;
		}

		public Vector3 GetExitPosition()
		{
			Vector3 characterExitingPosition = CharacterExitingPosition;
			Vector3 characterExitingPosition2 = CharacterExitingPosition;
			characterExitingPosition2.x = 0f - CharacterExitingPosition.x;
			Vector3 origin = base.transform.position + base.transform.forward * CharacterExitingPosition.z + base.transform.up * CharacterExitingPosition.y;
			bool flag = !Physics.Raycast(origin, -base.transform.right, Mathf.Abs(CharacterExitingPosition.x), GroundCheck.RaycastLayerMask);
			bool num = !Physics.Raycast(origin, base.transform.right, Mathf.Abs(CharacterExitingPosition.x), GroundCheck.RaycastLayerMask);
			Vector3 vector = Vector3.zero;
			if (flag)
			{
				vector = characterExitingPosition;
			}
			if (num && !flag)
			{
				vector = characterExitingPosition2;
			}
			if (!num && !flag)
			{
				vector = Vector3.zero;
			}
			if (vector != Vector3.zero)
			{
				return base.transform.TransformPoint(vector);
			}
			return Vector3.zero;
		}
	}
}
