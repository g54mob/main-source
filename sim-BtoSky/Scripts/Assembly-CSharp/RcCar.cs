using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;

public class RcCar : MonoBehaviour, IInteractable, IAltInteractable
{
	public class InteractableDetectedArgs : EventArgs
	{
		public bool isdetected;

		public string interactionText;
	}

	public PrometeoCarController PCC;

	[SerializeField]
	private GameObject rcKit;

	[SerializeField]
	private CinemachineCamera rcCam;

	[SerializeField]
	private Transform foodMount;

	[SerializeField]
	private GameObject currentMountedFood;

	[Header("Scan")]
	[SerializeField]
	private Transform magnetPos;

	public float viewRadius = 10f;

	[Range(0f, 360f)]
	public float viewAngle = 90f;

	public float pullForce = 50f;

	private List<Rigidbody> scraps = new List<Rigidbody>();

	private bool magnaticOn;

	[Header("Layer")]
	public LayerMask targetMask;

	public LayerMask obstacleMask;

	private bool isActive;

	private InputSystem_Actions input;

	private Vector2 moveInput;

	private IInteractable lastInteractable;

	private bool isDetected;

	private bool onConversation;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	private LocalizedString altInteractionText { get; } = new LocalizedString("MyTable", "rc_control");

	public string AltInteractionText => altInteractionText.GetLocalizedString();

	public virtual string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	public static event EventHandler<InteractableDetectedArgs> InteractableDetected;

	public static event Action OnControlRc;

	public static event Action OnControlRcDone;

	public static event Action OnGrabRCcar;

	private void S_OnEndConversation(object sender, EventArgs e)
	{
		onConversation = false;
	}

	private void Start()
	{
		GameManager.S.RcCarSpawned();
		rcCam = GameManager.S.rcCam;
		isActive = false;
	}

	private void OnEnable()
	{
		GameManager.S.OnEndConversation += S_OnEndConversation;
	}

	private void OnDisable()
	{
		GameManager.S.OnEndConversation -= S_OnEndConversation;
	}

	private void Update()
	{
		if (isActive)
		{
			moveInput = FirstPersonController.S.playerInput.Player.RcMove.ReadValue<Vector2>();
			Debug.Log(moveInput);
			float y = moveInput.y;
			float x = moveInput.x;
			PCC.HandleMovement(y);
			PCC.HandleSteering(x);
			PCC.HandleDeceleration(y);
			RcLook();
			if (FirstPersonController.S.playerInput.Player.AltInteract.triggered)
			{
				ReleaseScraps();
			}
		}
	}

	private void FixedUpdate()
	{
		if (isActive && magnaticOn)
		{
			FindTargetsInFOV();
		}
	}

	private void ReleaseScraps()
	{
		foreach (Rigidbody scrap in scraps)
		{
			scrap.transform.parent = null;
			scrap.isKinematic = false;
			scrap.GetComponent<Collider>().enabled = true;
		}
		scraps.Clear();
	}

	public void FindTargetsInFOV()
	{
		Collider[] array = Physics.OverlapSphere(magnetPos.position, viewRadius, targetMask);
		foreach (Collider collider in array)
		{
			Rigidbody component = collider.GetComponent<Rigidbody>();
			if (component == null || scraps.Contains(component))
			{
				continue;
			}
			Vector3 normalized = (collider.transform.position - magnetPos.position).normalized;
			if (Vector3.Angle(magnetPos.forward, normalized) < viewAngle / 2f)
			{
				float num = Vector3.Distance(magnetPos.position, collider.transform.position);
				if (num < 0.5f)
				{
					AttachObject(component);
				}
				else if (num < 2f)
				{
					component.linearVelocity *= 0.9f;
					float num2 = 10f;
					collider.transform.position = Vector3.MoveTowards(collider.transform.position, magnetPos.position, num2 * Time.fixedDeltaTime);
				}
				else
				{
					float num3 = 1f - num / viewRadius;
					Vector3 normalized2 = (magnetPos.position - collider.transform.position).normalized;
					component.AddForce(normalized2 * pullForce * num3, ForceMode.Acceleration);
				}
			}
		}
	}

	private void AttachObject(Rigidbody rb)
	{
		if (!scraps.Contains(rb))
		{
			scraps.Add(rb);
			rb.isKinematic = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.GetComponent<Collider>().enabled = false;
			rb.transform.SetParent(magnetPos);
			AudioManager.S.PlayRcScrap();
		}
	}

	private void RcLook()
	{
		Vector3 position = Camera.main.transform.position;
		Vector3 forward = Camera.main.transform.forward;
		float maxDistance = 5f;
		if (Physics.SphereCast(position, 0.1f, forward, out var hitInfo, maxDistance, FirstPersonController.S.interactionLayerMask))
		{
			if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("RaycastBlock"))
			{
				ResetDetection();
				return;
			}
			IInteractable componentInParent = hitInfo.collider.GetComponentInParent<IInteractable>();
			if (componentInParent is NPC || componentInParent is NpcHouse)
			{
				HandleSuccess(componentInParent);
				return;
			}
		}
		ResetDetection();
	}

	private void HandleSuccess(IInteractable interactableObj)
	{
		if (interactableObj != lastInteractable)
		{
			lastInteractable?.OnLost();
			interactableObj.OnDetected();
			lastInteractable = interactableObj;
		}
		RcCar.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
		{
			isdetected = true,
			interactionText = interactableObj.InteractionText
		});
		isDetected = true;
		if (FirstPersonController.S.playerInput.Player.Interact.triggered)
		{
			interactableObj.Interact();
			onConversation = true;
		}
	}

	private void ResetDetection()
	{
		if (isDetected)
		{
			RcCar.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
			{
				isdetected = false
			});
			isDetected = false;
			lastInteractable?.OnLost();
			lastInteractable = null;
		}
	}

	public void Interact()
	{
		Food component;
		if (FirstPersonController.S.itemOnHand == null)
		{
			if (currentMountedFood != null)
			{
				FirstPersonController.S.GrabItem(currentMountedFood);
				currentMountedFood = null;
				return;
			}
			foreach (Rigidbody scrap in scraps)
			{
				scrap.transform.parent = null;
				scrap.isKinematic = false;
				scrap.GetComponent<Collider>().enabled = true;
			}
			scraps.Clear();
			UnityEngine.Object.Instantiate(rcKit, FirstPersonController.S.transform.position + Vector3.up * 3f, Quaternion.identity).GetComponent<Furniture>().Interact();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (FirstPersonController.S.itemOnHand.TryGetComponent<Food>(out component) && currentMountedFood == null)
		{
			currentMountedFood = component.gameObject;
			component.transform.parent = foodMount;
			component.transform.localPosition = Vector3.zero;
			component.transform.localRotation = Quaternion.identity;
			FirstPersonController.S.itemOnHand = null;
			FirstPersonController.S.ItemOutHand();
			AudioManager.S.PlayRandomPitch(AudioManager.S.shelfPut);
		}
	}

	public void AltInteract()
	{
		if (!isActive)
		{
			isActive = true;
			rcCam.Priority = 1;
			CinemachineCamera cinemachineCamera = rcCam;
			cinemachineCamera.Follow = base.transform;
			cinemachineCamera.LookAt = base.transform;
			FirstPersonController.S.canControl = false;
			FirstPersonController.S.rcControl = true;
			FirstPersonController.S.currentRC = this;
			GameManager.S.OnPlayerPressTab += S_OnPlayerPressTab;
			RcCar.OnControlRc?.Invoke();
			FirstPersonController.S.playerInput.Player.MouseRightHold.performed += MouseRightHold_performed;
			FirstPersonController.S.playerInput.Player.MouseRightReleased.performed += MouseRightReleased_performed;
			AudioManager.S.PlayRcSFX();
		}
	}

	private void MouseRightReleased_performed(InputAction.CallbackContext obj)
	{
		magnaticOn = false;
	}

	private void MouseRightHold_performed(InputAction.CallbackContext obj)
	{
		magnaticOn = true;
	}

	private void S_OnPlayerPressTab(object sender, EventArgs e)
	{
		if (!onConversation)
		{
			isActive = false;
			rcCam.Priority = 0;
			FirstPersonController.S.canControl = true;
			FirstPersonController.S.rcControl = false;
			GameManager.S.OnPlayerPressTab -= S_OnPlayerPressTab;
			RcCar.OnControlRcDone?.Invoke();
			FirstPersonController.S.playerInput.Player.MouseRightHold.performed -= MouseRightHold_performed;
			FirstPersonController.S.playerInput.Player.MouseRightReleased.performed -= MouseRightReleased_performed;
			AudioManager.S.StopRcSFX();
		}
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
