using FIMSpace.Basics;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_Mover : MonoBehaviour
	{
		public Fimp_JoystickInput JoystickInput;

		public Rigidbody Rigb;

		[Header("Setting 'IsGrounded','IsMoving' and 'Speed' parameters for mecanim")]
		public Animator Mecanim;

		public bool StrafeMode;

		[Space(4f)]
		public LegsAnimator AutoSetGroundedAndIsMoving;

		[Space(4f)]
		public float MovementSpeed = 2f;

		[Range(0f, 1f)]
		public float RotateToSpeed = 0.8f;

		public bool AutoRotation = true;

		[Range(0f, 1f)]
		public float DirectMovement;

		[Space(4f)]
		public LayerMask GroundMask = 0;

		[Space(4f)]
		public float JumpPower = 3f;

		public float ExtraRaycastDistance;

		[Space(4f)]
		public float HoldShiftForSpeed;

		public float HoldCtrlForSpeed;

		private Quaternion targetRotation;

		private Quaternion targetInstantRotation;

		private bool isGrounded = true;

		[Space(4f)]
		public LegsAnimator CallImpulseOn;

		public LegsAnimator.PelvisImpulseSettings ImpulseBeforeJump;

		[Space(4f)]
		public string SetMecanimTrigger = "";

		public KeyCode MecanimTriggerOnKey = KeyCode.Q;

		private Vector2 moveDirectionLocal;

		private Vector2 moveDirectionLocalNonZero;

		private Vector3 moveDirectionWorld;

		private float rotationAngle;

		private float sd_rotationAngle;

		private float toJump;

		private Vector3 currentWorldAccel = Vector3.zero;

		private float jumpRequest;

		private float jumpTime = -1f;

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
			targetRotation = base.transform.rotation;
			targetInstantRotation = base.transform.rotation;
			rotationAngle = base.transform.eulerAngles.y;
			if ((bool)Mecanim)
			{
				Mecanim.SetBool("IsGrounded", value: true);
			}
			if ((bool)AutoSetGroundedAndIsMoving)
			{
				AutoSetGroundedAndIsMoving.User_SetIsGrounded(grounded: true);
			}
		}

		private void Update()
		{
			if (Rigb == null)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.Space) && toJump <= 0f)
			{
				jumpRequest = JumpPower;
				if (CallImpulseOn != null)
				{
					toJump = ImpulseBeforeJump.ImpulseDuration * 0.6f;
					CallImpulseOn.User_AddImpulse(ImpulseBeforeJump);
				}
				else
				{
					toJump = 0f;
				}
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
			if ((bool)JoystickInput && JoystickInput.OutputValue != Vector2.zero)
			{
				moveDirectionLocal.x += JoystickInput.OutputValue.x;
				moveDirectionLocal.y += JoystickInput.OutputValue.y;
			}
			bool flag = false;
			Quaternion quaternion = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
			if (moveDirectionLocal != Vector2.zero)
			{
				moveDirectionLocal.Normalize();
				moveDirectionWorld = quaternion * new Vector3(moveDirectionLocal.x, 0f, moveDirectionLocal.y);
				flag = true;
				if ((bool)AutoSetGroundedAndIsMoving)
				{
					AutoSetGroundedAndIsMoving.User_SetIsMoving(moving: true);
				}
				moveDirectionLocalNonZero = moveDirectionLocal;
			}
			else
			{
				if ((bool)AutoSetGroundedAndIsMoving)
				{
					AutoSetGroundedAndIsMoving.User_SetIsMoving(moving: false);
				}
				moveDirectionWorld = Vector3.zero;
			}
			if ((Input.GetKey(KeyCode.R) || moveDirectionLocal != Vector2.zero) && RotateToSpeed > 0f && currentWorldAccel != Vector3.zero)
			{
				targetInstantRotation = (StrafeMode ? quaternion : Quaternion.LookRotation(currentWorldAccel));
				rotationAngle = Mathf.SmoothDampAngle(rotationAngle, targetInstantRotation.eulerAngles.y, ref sd_rotationAngle, Mathf.Lerp(0.5f, 0.01f, RotateToSpeed));
				targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);
			}
			if ((bool)Mecanim)
			{
				Mecanim.SetBool("IsMoving", flag);
			}
			float num = MovementSpeed;
			if (HoldShiftForSpeed != 0f && Input.GetKey(KeyCode.LeftShift))
			{
				num = HoldShiftForSpeed;
			}
			if (HoldCtrlForSpeed != 0f && Input.GetKey(KeyCode.LeftControl))
			{
				num = HoldCtrlForSpeed;
			}
			float num2 = 5f * MovementSpeed;
			if (!flag)
			{
				num2 = 7f * MovementSpeed;
			}
			currentWorldAccel = Vector3.MoveTowards(currentWorldAccel, moveDirectionWorld * num, Time.deltaTime * num2);
			if ((bool)Mecanim && flag)
			{
				Mecanim.SetFloat("Speed", currentWorldAccel.magnitude);
			}
			if ((bool)Mecanim && !string.IsNullOrWhiteSpace(SetMecanimTrigger) && Input.GetKeyDown(MecanimTriggerOnKey))
			{
				Mecanim.SetTrigger(SetMecanimTrigger);
			}
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
			directMovement *= Mathf.InverseLerp(180f, 50f, Mathf.Abs(f));
			a = Vector3.Lerp(a, (StrafeMode ? (base.transform.rotation * new Vector3(moveDirectionLocalNonZero.x, 0f, moveDirectionLocalNonZero.y)) : base.transform.forward) * a.magnitude, directMovement);
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
					Mecanim.SetBool("IsGrounded", value: false);
				}
				if ((bool)AutoSetGroundedAndIsMoving)
				{
					AutoSetGroundedAndIsMoving.User_SetIsGrounded(grounded: false);
				}
			}
			else if (isGrounded)
			{
				a.y -= 2.5f * Time.fixedDeltaTime;
			}
			Rigb.velocity = a;
			Rigb.angularVelocity = Rigb.rotation.QToAngularVelocity(targetRotation, fix: true);
			if (Time.time - jumpTime > 0.2f)
			{
				if (Physics.Raycast(base.transform.position + base.transform.up, -base.transform.up, (isGrounded ? 1.2f : 1.01f) + ExtraRaycastDistance, GroundMask, QueryTriggerInteraction.Ignore))
				{
					if (!isGrounded)
					{
						isGrounded = true;
						if ((bool)Mecanim)
						{
							Mecanim.SetBool("IsGrounded", value: true);
						}
						if ((bool)AutoSetGroundedAndIsMoving)
						{
							AutoSetGroundedAndIsMoving.User_SetIsGrounded(grounded: true);
						}
					}
				}
				else if (isGrounded)
				{
					isGrounded = false;
					if ((bool)Mecanim)
					{
						Mecanim.SetBool("IsGrounded", value: false);
					}
					if ((bool)AutoSetGroundedAndIsMoving)
					{
						AutoSetGroundedAndIsMoving.User_SetIsGrounded(grounded: false);
					}
				}
			}
			else if (isGrounded)
			{
				isGrounded = false;
				if ((bool)Mecanim)
				{
					Mecanim.SetBool("IsGrounded", value: false);
				}
				if ((bool)AutoSetGroundedAndIsMoving)
				{
					AutoSetGroundedAndIsMoving.User_SetIsGrounded(grounded: false);
				}
			}
		}

		public void SwitchStrafeMode()
		{
			StrafeMode = !StrafeMode;
		}
	}
}
