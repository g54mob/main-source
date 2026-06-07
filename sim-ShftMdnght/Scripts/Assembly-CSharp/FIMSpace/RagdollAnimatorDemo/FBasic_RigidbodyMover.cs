using System;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[AddComponentMenu("FImpossible Creations/Demos/Fimpossible Demo Mover")]
	[DefaultExecutionOrder(-100)]
	public class FBasic_RigidbodyMover : FimpossibleComponent
	{
		public Rigidbody Rigb;

		[Space(4f)]
		public float MovementSpeed = 2f;

		[Range(0f, 1f)]
		public float RotateToSpeed = 0.8f;

		[Tooltip("When true, applying rotation by rigidbody.rotation = ...\nWhen false, applying rotation using angular velocity (smoother interpolation)")]
		public bool FixedRotation = true;

		[Range(0f, 1f)]
		public float DirectMovement;

		[Range(0f, 1f)]
		public float Interia = 1f;

		[Space(4f)]
		public LayerMask GroundMask = 0;

		[Space(4f)]
		public float ExtraRaycastDistance = 0.01f;

		[Tooltip("Using Spherecast is Radius greater than zero")]
		public float RaycastRadius;

		[Space(10f)]
		[Tooltip("Setting 'Grounded','Moving' and 'Speed' parameters for mecanim")]
		public Animator Mecanim;

		[Tooltip("Animator property which will not allowing character movement is set to true")]
		public string IsBusyProperty = "";

		public bool DisableRootMotion;

		[Space(6f)]
		public bool UpdateInput = true;

		[Space(1f)]
		public float JumpPower = 3f;

		public float HoldShiftForSpeed;

		public float HoldCtrlForSpeed;

		public Action OnJump;

		private bool wasInitialized;

		[NonSerialized]
		public Vector2 moveDirectionLocal = Vector3.zero;

		[NonSerialized]
		public float jumpRequest;

		private Quaternion targetRotation;

		private Quaternion targetInstantRotation;

		private float rotationAngle;

		private float sd_rotationAngle;

		private float toJump;

		private bool wasRootmotion;

		private float jumpTime = -1f;

		public Vector2 moveDirectionLocalNonZero { get; private set; }

		public Vector3 moveDirectionWorld { get; set; }

		public Vector3 currentWorldAccel { get; private set; }

		public bool isGrounded { get; private set; } = true;

		public void SetTargetRotation(Vector3 dir)
		{
			targetInstantRotation = Quaternion.LookRotation(dir);
			if (currentWorldAccel == Vector3.zero)
			{
				currentWorldAccel = new Vector3(1E-07f, 0f, 0f);
			}
		}

		public void SetRotation(Vector3 dir)
		{
			targetInstantRotation = Quaternion.LookRotation(dir);
			rotationAngle = targetInstantRotation.eulerAngles.y;
			targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);
		}

		public void MoveTowards(Vector3 wPos, bool setDir = true)
		{
			Vector3 vector = new Vector3(wPos.x, 0f, wPos.z);
			Vector3 vector2 = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			Vector3 vector3 = (moveDirectionWorld = (vector - vector2).normalized);
			if (setDir)
			{
				SetTargetRotation(vector3);
			}
		}

		public void ResetTargetRotation()
		{
			targetRotation = base.transform.rotation;
			targetInstantRotation = base.transform.rotation;
			rotationAngle = base.transform.eulerAngles.y;
			currentWorldAccel = Vector3.zero;
			jumpRequest = 0f;
		}

		private void Start()
		{
			if (!Rigb)
			{
				Rigb = GetComponent<Rigidbody>();
			}
			if ((bool)Rigb)
			{
				Rigb.maxAngularVelocity = 30f;
				if (Rigb.interpolation == RigidbodyInterpolation.None)
				{
					Rigb.interpolation = RigidbodyInterpolation.Interpolate;
				}
				Rigb.constraints = (RigidbodyConstraints)80;
			}
			isGrounded = true;
			targetRotation = base.transform.rotation;
			targetInstantRotation = base.transform.rotation;
			rotationAngle = base.transform.eulerAngles.y;
			if ((bool)Mecanim)
			{
				Mecanim.SetBool("Grounded", value: true);
			}
			wasInitialized = true;
		}

		private void OnEnable()
		{
			if (wasInitialized)
			{
				ResetTargetRotation();
				Rigb.isKinematic = false;
				Rigb.detectCollisions = true;
				isGrounded = true;
				if ((bool)Mecanim)
				{
					isGrounded = Mecanim.GetBool("Grounded");
				}
				CheckGroundedState();
			}
		}

		private void OnDisable()
		{
			Rigb.isKinematic = true;
			Rigb.detectCollisions = true;
		}

		protected virtual void Update()
		{
			if (Rigb == null)
			{
				return;
			}
			bool flag = true;
			if ((bool)Mecanim && !string.IsNullOrWhiteSpace(IsBusyProperty))
			{
				flag = !Mecanim.GetBool(IsBusyProperty);
			}
			if (UpdateInput && flag)
			{
				if (Input.GetKeyDown(KeyCode.Space) && toJump <= 0f)
				{
					jumpRequest = JumpPower;
					toJump = 0f;
				}
				moveDirectionLocal = Vector2.zero;
				if (Input.GetKey(KeyCode.A))
				{
					moveDirectionLocal += Vector2.left;
				}
				else if (Input.GetKey(KeyCode.D))
				{
					moveDirectionLocal += Vector2.right;
				}
				if (Input.GetKey(KeyCode.W))
				{
					moveDirectionLocal += Vector2.up;
				}
				else if (Input.GetKey(KeyCode.S))
				{
					moveDirectionLocal += Vector2.down;
				}
				Quaternion quaternion = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
				if (moveDirectionLocal != Vector2.zero)
				{
					moveDirectionLocal.Normalize();
					moveDirectionWorld = quaternion * new Vector3(moveDirectionLocal.x, 0f, moveDirectionLocal.y);
					moveDirectionLocalNonZero = moveDirectionLocal;
				}
				else
				{
					moveDirectionWorld = Vector3.zero;
				}
				if (moveDirectionWorld != Vector3.zero)
				{
					targetInstantRotation = Quaternion.LookRotation(moveDirectionWorld);
				}
			}
			else if (!flag)
			{
				moveDirectionWorld = Vector3.zero;
			}
			bool flag2 = false;
			if (moveDirectionWorld != Vector3.zero)
			{
				flag2 = true;
			}
			if (RotateToSpeed > 0f && currentWorldAccel != Vector3.zero)
			{
				rotationAngle = Mathf.SmoothDampAngle(rotationAngle, targetInstantRotation.eulerAngles.y, ref sd_rotationAngle, Mathf.Lerp(0.5f, 0.01f, RotateToSpeed));
				targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);
			}
			if ((bool)Mecanim)
			{
				Mecanim.SetBool("Moving", flag2);
			}
			float num = MovementSpeed;
			if (UpdateInput)
			{
				if (HoldShiftForSpeed != 0f && Input.GetKey(KeyCode.LeftShift))
				{
					num = HoldShiftForSpeed;
				}
				if (HoldCtrlForSpeed != 0f && Input.GetKey(KeyCode.LeftControl))
				{
					num = HoldCtrlForSpeed;
				}
			}
			float num2 = 5f * MovementSpeed;
			if (!flag2)
			{
				num2 = 7f * MovementSpeed;
			}
			if (Interia < 1f)
			{
				currentWorldAccel = Vector3.Lerp(Vector3.Slerp(currentWorldAccel, moveDirectionWorld * num, Time.deltaTime * num2), Vector3.MoveTowards(currentWorldAccel, moveDirectionWorld * num, Time.deltaTime * num2), Interia);
			}
			else
			{
				currentWorldAccel = Vector3.MoveTowards(currentWorldAccel, moveDirectionWorld * num, Time.deltaTime * num2);
			}
			if ((bool)Mecanim && flag2)
			{
				Mecanim.SetFloat("Speed", currentWorldAccel.magnitude);
			}
			moveDirectionWorld = Vector3.zero;
		}

		private void FixedUpdate()
		{
			if (Rigb == null)
			{
				return;
			}
			Vector3 a = currentWorldAccel;
			float f = Mathf.DeltaAngle(Rigb.rotation.eulerAngles.y, targetInstantRotation.eulerAngles.y);
			float directMovement = DirectMovement;
			directMovement *= Mathf.Lerp(1f, Mathf.InverseLerp(180f, 50f, Mathf.Abs(f)), Interia);
			a = Vector3.Lerp(a, base.transform.forward * a.magnitude, directMovement);
			a.y = Rigb.velocity.y;
			toJump -= Time.fixedDeltaTime;
			if (jumpRequest != 0f && toJump <= 0f)
			{
				Rigb.position += base.transform.up * jumpRequest * 0.01f;
				a.y = jumpRequest;
				isGrounded = false;
				jumpRequest = 0f;
				jumpTime = Time.time;
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("Grounded", value: false);
				}
				if (OnJump != null)
				{
					OnJump();
				}
			}
			else if (isGrounded)
			{
				a.y -= 2.5f * Time.fixedDeltaTime;
			}
			if (!wasRootmotion && !Rigb.isKinematic)
			{
				Rigb.velocity = a;
			}
			if (FixedRotation)
			{
				Rigb.rotation = targetRotation;
			}
			else
			{
				Rigb.angularVelocity = Rigb.rotation.QToAngularVelocity(targetRotation, fix: true);
			}
			if (Time.time - jumpTime > 0.2f)
			{
				CheckGroundedState();
			}
			else if (isGrounded)
			{
				isGrounded = false;
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("Grounded", value: false);
				}
			}
		}

		public void CheckGroundedState()
		{
			if (DoRaycasting())
			{
				if (!isGrounded)
				{
					isGrounded = true;
					if ((bool)Mecanim)
					{
						Mecanim.SetBool("Grounded", value: true);
					}
				}
			}
			else if (isGrounded)
			{
				isGrounded = false;
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("Grounded", value: false);
				}
			}
		}

		private void OnAnimatorMove()
		{
			if (!DisableRootMotion)
			{
				if (Mecanim.deltaPosition.magnitude > Time.unscaledDeltaTime * 0.1f)
				{
					wasRootmotion = true;
				}
				else
				{
					wasRootmotion = false;
				}
				Mecanim.ApplyBuiltinRootMotion();
			}
		}

		private bool DoRaycasting()
		{
			if (RaycastRadius <= 0f)
			{
				return Physics.Raycast(base.transform.position + base.transform.up, -base.transform.up, (isGrounded ? 1.2f : 1.01f) + ExtraRaycastDistance, GroundMask, QueryTriggerInteraction.Ignore);
			}
			return Physics.SphereCast(new Ray(base.transform.position + base.transform.up, -base.transform.up), RaycastRadius, (isGrounded ? 1.2f : 1.01f) + ExtraRaycastDistance - RaycastRadius * 0.5f, GroundMask, QueryTriggerInteraction.Ignore);
		}
	}
}
