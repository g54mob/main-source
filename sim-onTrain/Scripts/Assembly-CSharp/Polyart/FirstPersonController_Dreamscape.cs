using System.Collections;
using UnityEngine;

namespace Polyart
{
	public class FirstPersonController_Dreamscape : MonoBehaviour
	{
		[Header("Character Options")]
		[SerializeField]
		private bool canSprint = true;

		[SerializeField]
		private bool canJump = true;

		[SerializeField]
		private bool canCrouch = true;

		[SerializeField]
		private bool canHeadBob = true;

		[SerializeField]
		private bool canInteract = true;

		[SerializeField]
		private bool useFootsteps = true;

		[Header("Controls")]
		[SerializeField]
		private KeyCode sprintKey = KeyCode.LeftShift;

		[SerializeField]
		private KeyCode jumpKey = KeyCode.Space;

		[SerializeField]
		private KeyCode crouchKey = KeyCode.LeftControl;

		[SerializeField]
		private KeyCode interactKey = KeyCode.E;

		[Header("Interaction")]
		[SerializeField]
		private Vector3 interactionRayPoint;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private LayerMask interactionLayer;

		private Interactable_Dreamscape currentInteractable;

		[Header("Movement Parameters")]
		[SerializeField]
		private float walkSpeed = 3f;

		[SerializeField]
		private float sprintSpeed = 6f;

		[SerializeField]
		private float crouchSpeed = 1.5f;

		[Header("Camera Parameters")]
		[SerializeField]
		[Range(1f, 10f)]
		private float lookSpeedX = 2f;

		[SerializeField]
		[Range(1f, 10f)]
		private float lookSpeedY = 2f;

		[SerializeField]
		[Range(1f, 180f)]
		private float lowerLookLimit = 80f;

		[SerializeField]
		[Range(1f, 180f)]
		private float upperLookLimit = 80f;

		[Header("Jumping Parameters")]
		[SerializeField]
		private float jumpForce = 8f;

		[SerializeField]
		private float gravity = 30f;

		[Header("Crouching Parameters")]
		[SerializeField]
		private float crouchHeight = 0.5f;

		[SerializeField]
		private float standinghHeight = 2f;

		[SerializeField]
		private float timeToCrouch = 0.25f;

		[SerializeField]
		private Vector3 crouchCenter = new Vector3(0f, 0.5f, 0f);

		[SerializeField]
		private Vector3 standingCenter = new Vector3(0f, 0f, 0f);

		private bool isCrouching;

		private bool duringCrouchAnim;

		[Header("Headbob Parameters")]
		[SerializeField]
		private float walkBobSpeed = 14f;

		[SerializeField]
		private float walkBobAmount = 0.05f;

		[SerializeField]
		private float sprintBobSpeed = 18f;

		[SerializeField]
		private float sprintBobAmount = 0.11f;

		[Header("Footstep Parameters")]
		[SerializeField]
		private float baseStepSpeed = 0.5f;

		[SerializeField]
		private float crouchStepMultiplier = 1.5f;

		[SerializeField]
		private float sprintStepMultiplier = 0.6f;

		[SerializeField]
		private AudioSource footstepAudioSource;

		[SerializeField]
		private AudioClip[] woodClips;

		[SerializeField]
		private AudioClip[] stoneClips;

		[SerializeField]
		private AudioClip[] waterClips;

		[SerializeField]
		private AudioClip[] grassClips;

		private float footstepTimer;

		private float defaultYPos;

		private float timer;

		private Camera playerCamera;

		private CharacterController characterController;

		private Vector3 moveDirection;

		private Vector2 currentInput;

		private float rotationX;

		public bool CanMove { get; private set; } = true;

		private bool isSprinting
		{
			get
			{
				if (canSprint)
				{
					return Input.GetKey(sprintKey);
				}
				return false;
			}
		}

		private bool ShouldJump
		{
			get
			{
				if (Input.GetKeyDown(jumpKey))
				{
					return characterController.isGrounded;
				}
				return false;
			}
		}

		private bool ShouldCrouch
		{
			get
			{
				if (Input.GetKeyDown(crouchKey) && !duringCrouchAnim)
				{
					return characterController.isGrounded;
				}
				return false;
			}
		}

		private float GetCurrentOffset
		{
			get
			{
				if (!isCrouching)
				{
					if (!isSprinting)
					{
						return baseStepSpeed;
					}
					return baseStepSpeed * sprintStepMultiplier;
				}
				return baseStepSpeed * crouchStepMultiplier;
			}
		}

		private void Awake()
		{
			playerCamera = GetComponentInChildren<Camera>();
			characterController = GetComponent<CharacterController>();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			defaultYPos = playerCamera.transform.localPosition.y;
		}

		private void Update()
		{
			if (CanMove)
			{
				HandleMovementInput();
				HandleMouseLook();
				if (canJump)
				{
					HandleJump();
				}
				if (canCrouch)
				{
					HandleCrouch();
				}
				if (canHeadBob)
				{
					HandleHeadBob();
				}
				if (canInteract)
				{
					HandleInteractionCheck();
					HandleInteractionInput();
				}
				if (useFootsteps)
				{
					HandleFootsteps();
				}
				ApplyFinalMovements();
			}
		}

		private void HandleMovementInput()
		{
			currentInput = new Vector2((isCrouching ? crouchSpeed : (isSprinting ? sprintSpeed : walkSpeed)) * Input.GetAxis("Vertical"), (isCrouching ? crouchSpeed : (isSprinting ? sprintSpeed : walkSpeed)) * Input.GetAxis("Horizontal"));
			float y = moveDirection.y;
			moveDirection = base.transform.TransformDirection(Vector3.forward) * currentInput.x + base.transform.TransformDirection(Vector3.right) * currentInput.y;
			moveDirection.y = y;
		}

		private void HandleHeadBob()
		{
			if (characterController.isGrounded && (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f))
			{
				timer += Time.deltaTime * (isSprinting ? sprintBobSpeed : walkBobSpeed);
				playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultYPos + Mathf.Sin(timer) * (isSprinting ? sprintBobAmount : walkBobAmount), playerCamera.transform.localPosition.z);
			}
		}

		private void HandleMouseLook()
		{
			rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
			rotationX = Mathf.Clamp(rotationX, 0f - upperLookLimit, lowerLookLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
			base.transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeedX, 0f);
		}

		private void HandleJump()
		{
			if (ShouldJump)
			{
				moveDirection.y = jumpForce;
			}
		}

		private void HandleCrouch()
		{
			if (ShouldCrouch)
			{
				StartCoroutine(CrouchStand());
			}
		}

		private void ApplyFinalMovements()
		{
			if (!characterController.isGrounded)
			{
				moveDirection.y -= gravity * Time.deltaTime;
			}
			characterController.Move(moveDirection * Time.deltaTime);
		}

		private IEnumerator CrouchStand()
		{
			if (!isCrouching || !Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
			{
				duringCrouchAnim = true;
				float timeElapsed = 0f;
				float targetHeight = (isCrouching ? standinghHeight : crouchHeight);
				float currentHeight = characterController.height;
				Vector3 targetCenter = (isCrouching ? standingCenter : crouchCenter);
				Vector3 currentCenter = characterController.center;
				while (timeElapsed < timeToCrouch)
				{
					characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
					characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / timeToCrouch);
					timeElapsed += Time.deltaTime;
					yield return null;
				}
				characterController.height = targetHeight;
				characterController.center = targetCenter;
				isCrouching = !isCrouching;
				duringCrouchAnim = false;
			}
		}

		private void HandleInteractionCheck()
		{
			if (Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out var hitInfo, interactionDistance))
			{
				if (hitInfo.collider.gameObject.layer == 7 && (currentInteractable == null || hitInfo.collider.gameObject.GetInstanceID() != currentInteractable.gameObject.GetInstanceID()))
				{
					hitInfo.collider.TryGetComponent<Interactable_Dreamscape>(out currentInteractable);
					if ((bool)currentInteractable)
					{
						currentInteractable.OnFocus();
					}
				}
			}
			else if ((bool)currentInteractable)
			{
				currentInteractable.OnLoseFocus();
				currentInteractable = null;
			}
		}

		private void HandleFootsteps()
		{
			if (!characterController.isGrounded || currentInput == Vector2.zero)
			{
				return;
			}
			footstepTimer -= Time.deltaTime;
			if (!(footstepTimer <= 0f))
			{
				return;
			}
			if (Physics.Raycast(playerCamera.transform.position, Vector3.down, out var hitInfo, 2f))
			{
				switch (hitInfo.collider.tag)
				{
				case "Footsteps/Grass":
					footstepAudioSource.PlayOneShot(grassClips[Random.Range(0, grassClips.Length - 1)]);
					break;
				case "Footsteps/Stone":
					footstepAudioSource.PlayOneShot(stoneClips[Random.Range(0, stoneClips.Length - 1)]);
					break;
				case "Footsteps/Water":
					footstepAudioSource.PlayOneShot(waterClips[Random.Range(0, waterClips.Length - 1)]);
					break;
				case "Footsteps/Wood":
					footstepAudioSource.PlayOneShot(woodClips[Random.Range(0, woodClips.Length - 1)]);
					break;
				default:
					footstepAudioSource.PlayOneShot(grassClips[Random.Range(0, grassClips.Length - 1)]);
					break;
				}
			}
			footstepTimer = GetCurrentOffset;
		}

		private void HandleInteractionInput()
		{
			if (Input.GetKeyDown(interactKey) && currentInteractable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out var _, interactionDistance, interactionLayer))
			{
				currentInteractable.OnInteract();
			}
		}
	}
}
