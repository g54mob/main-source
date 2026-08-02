using UnityEngine;
using UnityEngine.UI;

namespace Suntail
{
	public class PlayerInteractions : MonoBehaviour
	{
		[Header("Interaction variables")]
		[Tooltip("Layer mask for interactive objects")]
		[SerializeField]
		private LayerMask interactionLayer;

		[Tooltip("Maximum distance from player to object of interaction")]
		[SerializeField]
		private float interactionDistance = 3f;

		[Tooltip("Tag for door object")]
		[SerializeField]
		private string doorTag = "Door";

		[Tooltip("Tag for pickable object")]
		[SerializeField]
		private string itemTag = "Item";

		[Tooltip("The player's main camera")]
		[SerializeField]
		private Camera mainCamera;

		[Tooltip("Parent object where the object to be lifted becomes")]
		[SerializeField]
		private Transform pickupParent;

		[Header("Keybinds")]
		[Tooltip("Interaction key")]
		[SerializeField]
		private KeyCode interactionKey = KeyCode.E;

		[Header("Object Following")]
		[Tooltip("Minimum speed of the lifted object")]
		[SerializeField]
		private float minSpeed;

		[Tooltip("Maximum speed of the lifted object")]
		[SerializeField]
		private float maxSpeed = 3000f;

		[Header("UI")]
		[Tooltip("Background object for text")]
		[SerializeField]
		private Image uiPanel;

		[Tooltip("Text holder")]
		[SerializeField]
		private Text panelText;

		[Tooltip("Text when an object can be lifted")]
		[SerializeField]
		private string itemPickUpText;

		[Tooltip("Text when an object can be drop")]
		[SerializeField]
		private string itemDropText;

		[Tooltip("Text when the door can be opened")]
		[SerializeField]
		private string doorOpenText;

		[Tooltip("Text when the door can be closed")]
		[SerializeField]
		private string doorCloseText;

		private PhysicsObject _physicsObject;

		private PhysicsObject _currentlyPickedUpObject;

		private PhysicsObject _lookObject;

		private Quaternion _lookRotation;

		private Vector3 _raycastPosition;

		private Rigidbody _pickupRigidBody;

		private Door _lookDoor;

		private float _currentSpeed;

		private float _currentDistance;

		private CharacterController _characterController;

		private void Start()
		{
			mainCamera = Camera.main;
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			Interactions();
			LegCheck();
		}

		private void Interactions()
		{
			_raycastPosition = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
			if (Physics.Raycast(_raycastPosition, mainCamera.transform.forward, out var hitInfo, interactionDistance, interactionLayer))
			{
				if (hitInfo.collider.CompareTag(itemTag))
				{
					_lookObject = hitInfo.collider.GetComponentInChildren<PhysicsObject>();
					ShowItemUI();
				}
				else if (hitInfo.collider.CompareTag(doorTag))
				{
					_lookDoor = hitInfo.collider.gameObject.GetComponentInChildren<Door>();
					ShowDoorUI();
					if (Input.GetKeyDown(interactionKey))
					{
						_lookDoor.PlayDoorAnimation();
					}
				}
			}
			else
			{
				_lookDoor = null;
				_lookObject = null;
				uiPanel.gameObject.SetActive(value: false);
			}
			if (!Input.GetKeyDown(interactionKey))
			{
				return;
			}
			if (_currentlyPickedUpObject == null)
			{
				if (_lookObject != null)
				{
					PickUpObject();
				}
			}
			else
			{
				BreakConnection();
			}
		}

		private void LegCheck()
		{
			if (Physics.SphereCast(_characterController.center + base.transform.position, 0.3f, Vector3.down, out var hitInfo, 2f) && hitInfo.collider.CompareTag(itemTag))
			{
				BreakConnection();
			}
		}

		private void FixedUpdate()
		{
			if (_currentlyPickedUpObject != null)
			{
				_currentDistance = Vector3.Distance(pickupParent.position, _pickupRigidBody.position);
				_currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, _currentDistance / interactionDistance);
				_currentSpeed *= Time.fixedDeltaTime;
				Vector3 vector = pickupParent.position - _pickupRigidBody.position;
				_pickupRigidBody.velocity = vector.normalized * _currentSpeed;
			}
		}

		public void PickUpObject()
		{
			_physicsObject = _lookObject.GetComponentInChildren<PhysicsObject>();
			_currentlyPickedUpObject = _lookObject;
			_lookRotation = _currentlyPickedUpObject.transform.rotation;
			_pickupRigidBody = _currentlyPickedUpObject.GetComponent<Rigidbody>();
			_pickupRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
			_pickupRigidBody.transform.rotation = _lookRotation;
			_physicsObject.playerInteraction = this;
			StartCoroutine(_physicsObject.PickUp());
		}

		public void BreakConnection()
		{
			if ((bool)_currentlyPickedUpObject)
			{
				_pickupRigidBody.constraints = RigidbodyConstraints.None;
				_currentlyPickedUpObject = null;
				_physicsObject.pickedUp = false;
				_currentDistance = 0f;
			}
		}

		private void ShowDoorUI()
		{
			uiPanel.gameObject.SetActive(value: true);
			if (_lookDoor.doorOpen)
			{
				panelText.text = doorCloseText;
			}
			else
			{
				panelText.text = doorOpenText;
			}
		}

		private void ShowItemUI()
		{
			uiPanel.gameObject.SetActive(value: true);
			if (_currentlyPickedUpObject == null)
			{
				panelText.text = itemPickUpText;
			}
			else if (_currentlyPickedUpObject != null)
			{
				panelText.text = itemDropText;
			}
		}
	}
}
