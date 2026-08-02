using System;
using UnityEngine;

namespace AquariusMax.Demo
{
	[RequireComponent(typeof(CharacterController))]
	public class DemoCharacter : MonoBehaviour
	{
		[SerializeField]
		private Camera cam;

		[SerializeField]
		private float gravityModifier = 2f;

		[SerializeField]
		private float walkSpeed = 5f;

		[SerializeField]
		private float runSpeed = 10f;

		[SerializeField]
		private float jumpSpeed = 10f;

		[SerializeField]
		private float landingForce = 10f;

		[SerializeField]
		private float mouseXSensitivity = 2f;

		[SerializeField]
		private float mouseYSensitivity = 2f;

		private CharacterController charControl;

		private Quaternion characterTargetRot;

		private Quaternion cameraTargetRot;

		private bool isWalking = true;

		private Vector2 moveInput = Vector2.zero;

		private Vector3 move = Vector3.zero;

		private bool jumpPressed;

		private CollisionFlags collisionFlags;

		private void Start()
		{
			if (cam == null)
			{
				cam = Camera.main;
			}
			charControl = GetComponent<CharacterController>();
			characterTargetRot = base.transform.localRotation;
			cameraTargetRot = cam.transform.localRotation;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void GetMoveInput(out float speed)
		{
			float axis = Input.GetAxis("Horizontal");
			float axis2 = Input.GetAxis("Vertical");
			moveInput = new Vector2(axis, axis2);
			if (moveInput.sqrMagnitude > 1f)
			{
				moveInput.Normalize();
			}
			isWalking = !Input.GetKey(KeyCode.LeftShift);
			speed = (isWalking ? walkSpeed : runSpeed);
		}

		private void CameraLook()
		{
			float y = Input.GetAxis("Mouse X") * mouseXSensitivity;
			float num = Input.GetAxis("Mouse Y") * mouseYSensitivity;
			characterTargetRot *= Quaternion.Euler(0f, y, 0f);
			cameraTargetRot *= Quaternion.Euler(0f - num, 0f, 0f);
			cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);
			base.transform.localRotation = characterTargetRot;
			cam.transform.localRotation = cameraTargetRot;
		}

		private void Update()
		{
			CameraLook();
			jumpPressed = Input.GetKeyDown(KeyCode.Space);
		}

		private void FixedUpdate()
		{
			GetMoveInput(out var speed);
			Vector3 vector = base.transform.forward * moveInput.y + base.transform.right * moveInput.x;
			Physics.SphereCast(base.transform.position, charControl.radius, Vector3.down, out var hitInfo, charControl.height / 2f, -1, QueryTriggerInteraction.Ignore);
			vector = Vector3.ProjectOnPlane(vector, hitInfo.normal).normalized;
			move.x = vector.x * speed;
			move.z = vector.z * speed;
			if (charControl.isGrounded)
			{
				move.y = 0f - landingForce;
				if (jumpPressed)
				{
					move.y = jumpSpeed;
					jumpPressed = false;
				}
			}
			else
			{
				move += Physics.gravity * gravityModifier * Time.fixedDeltaTime;
			}
			collisionFlags = charControl.Move(move * Time.fixedDeltaTime);
		}

		private Quaternion ClampRotationAroundXAxis(Quaternion q)
		{
			q.x /= q.w;
			q.y /= q.w;
			q.z /= q.w;
			q.w = 1f;
			float value = 114.59156f * Mathf.Atan(q.x);
			value = Mathf.Clamp(value, -90f, 90f);
			q.x = Mathf.Tan(MathF.PI / 360f * value);
			return q;
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;
			if (collisionFlags != CollisionFlags.Below && !(attachedRigidbody == null) && !attachedRigidbody.isKinematic)
			{
				attachedRigidbody.AddForceAtPosition(charControl.velocity * 0.1f, hit.point, ForceMode.Impulse);
			}
		}
	}
}
