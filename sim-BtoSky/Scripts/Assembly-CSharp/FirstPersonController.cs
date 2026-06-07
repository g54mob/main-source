using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour
{
	public class InteractableDetectedArgs : EventArgs
	{
		public bool isdetected;

		public string interactionText;
	}

	public static FirstPersonController S;

	public CharacterController playerController;

	public Transform playerCamPos;

	public Transform playerVisual;

	public bool canControl = true;

	public bool rcControl;

	public bool firstBoot = true;

	public bool firstBootScene0 = true;

	public bool firstBootScene1 = true;

	[Header("Stat")]
	public int KnowledgeLevel;

	public int exp;

	public int[] expTable = new int[11]
	{
		0, 10, 20, 20, 30, 40, 40, 40, 40, 40,
		40
	};

	public float stamina;

	public float maxStamina;

	public float staminaDecreaseValue;

	public float hunger;

	public float maxHunger;

	public float hungerDecreaseValue;

	public float hygiene;

	public float maxHygiene;

	private float staminaRegenTime = 1f;

	private float staminaRegenTimeDelat;

	public float money;

	public int ticket;

	[Header("Look")]
	public float mouseSensitivity = 1.5f;

	[SerializeField]
	private float smoothTime = 0.05f;

	[SerializeField]
	private float clampYLimit = 70f;

	private Vector2 currentLook;

	private Vector2 currentLookVelocity;

	[Header("Jump")]
	[SerializeField]
	private Transform groundCheckSphere;

	[SerializeField]
	private float freeFallDelayDelta;

	[SerializeField]
	private float freeFallDelay = 0.15f;

	[SerializeField]
	private Vector3 gravityVelocity = Vector3.zero;

	[SerializeField]
	private float jumpDelayDelta = -0.1f;

	private float gravity = -12f;

	private bool freeFalling;

	private float groundCheckDelay;

	private bool grounded = true;

	[Header("Move")]
	[SerializeField]
	private float moveSpeed = 2f;

	[SerializeField]
	private float sprintSpeed = 10f;

	[SerializeField]
	private float moveSpeedTransisiton = 10f;

	public Vector3 velocity;

	private float tempSpeed;

	private bool sprint;

	private bool canSprint = true;

	public float stepInterval = 0.5f;

	private float timer;

	[Header("Interaction")]
	public LayerMask interactionLayerMask;

	public LayerMask installableLayerMask;

	private bool isDetected;

	public Transform hand;

	public GameObject itemOnHand;

	public bool furnitureOnHand;

	public bool rocketOnHand;

	public bool paintOnHand;

	public Rocket rocket;

	private float eatingTimeDelat;

	private float eatingTime = 1.2f;

	public bool isEating;

	private bool eatingSoundPlaying;

	private IInteractable lastInteractable;

	[Header("RC")]
	public PrometeoCarController PCC;

	public RcCar currentRC;

	public InputSystem_Actions playerInput;

	private Vector3 openFieldSpawnPos = new Vector3(-194f, -20f, 116f);

	private Vector3 houseSpawnPos = new Vector3(14.8954f, 0.964f, -0.0247314f);

	private LocalizedString deployString = new LocalizedString("MyTable", "deploy");

	private LocalizedString paintString = new LocalizedString("MyTable", "paint");

	public event EventHandler<InteractableDetectedArgs> InteractableDetected;

	public event Action OnFoodInHand;

	public event Action OnItemInHand;

	public event Action OnItemOutHand;

	public event Action OnEscPressed;

	public event Action OnArrivedOpenField;

	public event Action OnFirstBoot;

	public event Action<string> OnAltInteractionDetected;

	public event Action OnAltInteractionUndetected;

	private void Awake()
	{
		if (S != null && S != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		playerInput = new InputSystem_Actions();
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
	}

	private void OnEnable()
	{
		if (playerInput != null)
		{
			playerInput.Player.Enable();
			playerInput.Player.Jump.performed += Jump;
			playerInput.Player.MouseRightHold.performed += MouseRightHold;
			playerInput.Player.MouseRightReleased.performed += MouseRightReleased;
			playerInput.Player.Drop.performed += Drop_performed;
			playerInput.Player.Tab.performed += Tab_performed;
			playerInput.Player.Quit.performed += Quit_performed;
		}
		if (SettingManager.S != null)
		{
			SettingManager.S.LoadSensitivity();
		}
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
	}

	private void OnDisable()
	{
		if (playerInput != null)
		{
			playerInput.Player.Jump.performed -= Jump;
			playerInput.Player.MouseRightHold.performed -= MouseRightHold;
			playerInput.Player.MouseRightReleased.performed -= MouseRightReleased;
			playerInput.Player.Drop.performed -= Drop_performed;
			playerInput.Player.Tab.performed -= Tab_performed;
			playerInput.Player.Quit.performed -= Quit_performed;
			playerInput.Player.Disable();
		}
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
	}

	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		StartCoroutine(SetSpawnPos(arg0.buildIndex));
	}

	private IEnumerator SetSpawnPos(int index)
	{
		yield return null;
		switch (index)
		{
		case 1:
		{
			if (firstBoot)
			{
				firstBoot = false;
				firstBootScene0 = false;
			}
			else
			{
				base.transform.position = houseSpawnPos;
			}
			if (hand.transform.childCount != 0 && hand.transform.GetChild(0).TryGetComponent<Paint>(out var _))
			{
				paintOnHand = true;
				itemOnHand = hand.transform.GetChild(0).gameObject;
			}
			if (itemOnHand != null)
			{
				this.OnItemInHand?.Invoke();
			}
			break;
		}
		case 2:
			firstBootScene1 = false;
			base.transform.position = openFieldSpawnPos;
			Debug.Log("PlayerSpawned on Open Field");
			this.OnArrivedOpenField?.Invoke();
			break;
		}
	}

	private void Start()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		GameManager.S.cinemachinePOVCamera.Follow = playerCamPos;
		GameManager.S.cinemachinePOVCamera.LookAt = playerCamPos;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
		if (hand.transform.childCount > 0)
		{
			GrabItem(hand.transform.GetChild(0).gameObject);
			Rigidbody component = itemOnHand.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.ResetInertiaTensor();
			}
		}
		StatInit();
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SavePlayerData();
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
		if (playerInput != null)
		{
			playerInput.Player.Jump.performed -= Jump;
			playerInput.Player.MouseRightHold.performed -= MouseRightHold;
			playerInput.Player.MouseRightReleased.performed -= MouseRightReleased;
			playerInput.Player.Drop.performed -= Drop_performed;
			playerInput.Player.Tab.performed -= Tab_performed;
			playerInput.Player.Quit.performed -= Quit_performed;
			playerInput.Player.Disable();
			playerInput.Dispose();
			playerInput = null;
		}
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		SavePlayerData();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Quit_performed(InputAction.CallbackContext obj)
	{
		this.OnEscPressed?.Invoke();
	}

	private void Tab_performed(InputAction.CallbackContext obj)
	{
		GameManager.S.PlayerPressTab();
	}

	public void DropItem()
	{
		if (!canControl || !(itemOnHand != null))
		{
			return;
		}
		if (rocketOnHand)
		{
			GameManager.S.DeleteBluePrint();
			rocket = null;
			rocketOnHand = false;
		}
		if (furnitureOnHand)
		{
			GameManager.S.DeleteBluePrint();
			furnitureOnHand = false;
		}
		if (paintOnHand)
		{
			paintOnHand = false;
			GameManager.S.DeletePaintTemp();
		}
		Collider[] componentsInChildren = itemOnHand.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			if (collider.GetComponent<MeshCollider>() == null)
			{
				collider.enabled = true;
			}
		}
		itemOnHand.transform.parent = null;
		if (itemOnHand.TryGetComponent<Rigidbody>(out var component))
		{
			component.isKinematic = false;
			Vector3 vector = Camera.main.transform.position + Camera.main.transform.forward * 5f - hand.transform.position;
			vector.Normalize();
			component.AddForce(vector * 5f + velocity * tempSpeed, ForceMode.Impulse);
		}
		Scene activeScene = SceneManager.GetActiveScene();
		SceneManager.MoveGameObjectToScene(itemOnHand, activeScene);
		itemOnHand = null;
		AudioManager.S.PlaySFX(AudioManager.S.dropItem);
		this.OnItemOutHand?.Invoke();
		this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
		{
			isdetected = false,
			interactionText = ""
		});
	}

	private void Drop_performed(InputAction.CallbackContext obj)
	{
		if (!isEating)
		{
			DropItem();
		}
	}

	private void MouseRightReleased(InputAction.CallbackContext obj)
	{
		if (obj.performed)
		{
			isEating = false;
			AudioManager.S.StopEatingSFX();
			eatingTimeDelat = 0f;
		}
	}

	private void MouseRightHold(InputAction.CallbackContext context)
	{
		if (!canControl)
		{
			return;
		}
		Debug.Log($"interaction: {context.interaction}");
		if (context.performed && context.interaction is HoldInteraction)
		{
			if (itemOnHand != null)
			{
				if (itemOnHand.TryGetComponent<Food>(out var _))
				{
					isEating = true;
				}
				else
				{
					isEating = false;
				}
			}
			else
			{
				isEating = false;
			}
		}
		if (context.canceled)
		{
			isEating = false;
			eatingSoundPlaying = false;
			AudioManager.S.StopEatingSFX();
		}
	}

	private void Update()
	{
		PlayerMove();
		if (!canControl)
		{
			return;
		}
		PlayerLook();
		if (!isEating)
		{
			if (furnitureOnHand)
			{
				FurnitureRaycast();
			}
			else
			{
				PlayerRaycast();
			}
		}
		ImHungryMom();
		EatingFood();
	}

	private void StatInit()
	{
		LoadPlayerData();
	}

	private void PlayerLook()
	{
		Vector2 mouseInput = GetMouseInput();
		currentLook = Vector2.SmoothDamp(currentLook, mouseInput, ref currentLookVelocity, smoothTime, float.PositiveInfinity, Time.deltaTime);
		float y = base.transform.eulerAngles.y + currentLook.x;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
		GameManager.S.cinemachinePanTilt.TiltAxis.Value -= currentLook.y;
		GameManager.S.cinemachinePanTilt.TiltAxis.Value = Mathf.Clamp(GameManager.S.cinemachinePanTilt.TiltAxis.Value, 0f - clampYLimit - 10f, clampYLimit);
	}

	public void LookAtTarget(Vector3 targetPos)
	{
		Quaternion quaternion = Quaternion.LookRotation((targetPos - base.transform.position).normalized);
		float y = quaternion.eulerAngles.y;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
		float num = quaternion.eulerAngles.x;
		if (num > 180f)
		{
			num -= 360f;
		}
		GameManager.S.cinemachinePanTilt.TiltAxis.Value = num;
		currentLook = Vector2.zero;
		currentLookVelocity = Vector2.zero;
	}

	private void ImHungryMom()
	{
		if (hunger > 0f)
		{
			hunger -= Time.deltaTime * hungerDecreaseValue;
		}
		else
		{
			hunger = 0f;
		}
	}

	private void EatingFood()
	{
		if (!isEating)
		{
			return;
		}
		if (!eatingSoundPlaying)
		{
			AudioManager.S.EatingSFX();
			eatingSoundPlaying = true;
		}
		if (eatingTimeDelat < eatingTime)
		{
			this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
			{
				isdetected = false
			});
			eatingTimeDelat += Time.deltaTime;
			return;
		}
		if (eatingSoundPlaying)
		{
			AudioManager.S.StopEatingSFX();
			eatingSoundPlaying = false;
		}
		Food component = itemOnHand.GetComponent<Food>();
		EatSomthing(component);
		GameManager.S.PlayerEat();
		if (KnowledgeLevel == 1)
		{
			if (component.knowledgeGain < 5)
			{
				AddExp(5);
			}
			else
			{
				AddExp(component.knowledgeGain);
			}
		}
		else if (GameManager.S.cookingPerkList[0])
		{
			int amount = Mathf.RoundToInt((float)component.knowledgeGain * 1.3f);
			AddExp(amount);
		}
		else
		{
			AddExp(component.knowledgeGain);
		}
		itemOnHand.transform.parent = null;
		SceneManager.MoveGameObjectToScene(itemOnHand, SceneManager.GetActiveScene());
		UnityEngine.Object.Destroy(itemOnHand);
		itemOnHand = null;
		eatingTimeDelat = 0f;
		isEating = false;
		this.OnItemOutHand?.Invoke();
	}

	public void ItemOutHand()
	{
		this.OnItemOutHand?.Invoke();
	}

	public void EatSomthing(Food food)
	{
		if (hunger < maxHunger)
		{
			hunger += food.hungerGain;
			if (hunger > maxHunger)
			{
				hunger = maxHunger;
			}
		}
		else
		{
			hunger = maxHunger;
		}
	}

	private void PlayerGroundCheck()
	{
		_ = playerInput.Player.Look.ReadValue<Vector2>().normalized;
		if (groundCheckDelay < 0.2f)
		{
			groundCheckDelay += Time.deltaTime;
		}
		else
		{
			grounded = Physics.CheckSphere(groundCheckSphere.position, groundCheckSphere.GetComponent<SphereCollider>().radius, groundCheckSphere.GetComponent<SphereCollider>().includeLayers);
		}
		if (grounded)
		{
			freeFallDelayDelta = freeFallDelay;
			if (gravityVelocity.y < 0f)
			{
				gravityVelocity.y = -2f;
			}
			if (jumpDelayDelta >= 0f)
			{
				jumpDelayDelta -= Time.deltaTime;
			}
		}
		else
		{
			if (freeFallDelayDelta >= 0f)
			{
				freeFallDelayDelta -= Time.deltaTime;
			}
			else
			{
				freeFalling = true;
			}
			gravityVelocity.y += gravity * Time.deltaTime;
		}
	}

	private void PlayerMove()
	{
		PlayerGroundCheck();
		Vector2 vector = Vector2.zero;
		if (canControl)
		{
			vector = playerInput.Player.Move.ReadValue<Vector2>().normalized;
		}
		sprint = false;
		if (playerInput.Player.Sprint.IsPressed() && canSprint && grounded)
		{
			sprint = true;
		}
		float b = ((!sprint) ? (moveSpeed * (hunger / maxHunger) + 2.5f) : (sprintSpeed * (hunger / maxHunger) + 4f));
		if (vector.magnitude > 0.1f)
		{
			float y = Mathf.Atan2(vector.x, vector.y) * 57.29578f + GameManager.S.cinemachinePOVCamera.transform.eulerAngles.y;
			velocity = Quaternion.Euler(0f, y, 0f) * Vector3.forward;
			tempSpeed = Mathf.Lerp(tempSpeed, b, moveSpeedTransisiton * Time.deltaTime);
			if (sprint)
			{
				if (!(stamina > 0f))
				{
					sprint = false;
					canSprint = false;
					stamina = 0f;
				}
				staminaRegenTimeDelat = staminaRegenTime;
			}
		}
		else
		{
			tempSpeed = Mathf.Lerp(tempSpeed, 0f, moveSpeedTransisiton * Time.deltaTime);
		}
		if (staminaRegenTimeDelat > 0f)
		{
			staminaRegenTimeDelat -= Time.deltaTime;
		}
		else
		{
			staminaRegenTimeDelat = 0f;
			if (stamina < maxStamina)
			{
				stamina += Time.deltaTime * staminaDecreaseValue;
				if (stamina / maxStamina > 0.2f)
				{
					canSprint = true;
				}
			}
		}
		playerController.Move(velocity * tempSpeed * Time.deltaTime + gravityVelocity * Time.deltaTime);
		if ((playerController.collisionFlags & CollisionFlags.Above) != CollisionFlags.None && gravityVelocity.y > 0f)
		{
			gravityVelocity.y = 0f;
		}
		if (!grounded)
		{
			return;
		}
		if (playerController.velocity.magnitude > 0.1f)
		{
			float num = stepInterval / Mathf.Max(playerController.velocity.magnitude, 1f);
			timer += Time.deltaTime;
			if (timer >= num)
			{
				AudioManager.S.PlayFootStep();
				timer = 0f;
			}
		}
		else
		{
			timer = 0f;
		}
	}

	private void FurnitureRaycast()
	{
		Vector3 position = GameManager.S.cinemachinePOVCamera.transform.position;
		Vector3 forward = GameManager.S.cinemachinePOVCamera.transform.forward;
		float maxDistance = 5f;
		Vector2 zero = Vector2.zero;
		zero = playerInput.Player.MouseWheel.ReadValue<Vector2>().normalized;
		int tick = 0;
		if (zero.y != 0f)
		{
			tick = (int)Mathf.Sign(zero.y);
		}
		LayerMask mask = itemOnHand.GetComponent<Furniture>().installableLayerMask;
		if (Physics.Raycast(position, forward, out var hitInfo, maxDistance))
		{
			if (IsInLayerMask(hitInfo.collider.gameObject, mask))
			{
				Furniture component = itemOnHand.GetComponent<Furniture>();
				GameManager.S.DrawBluePrint(component.furnitureGO, hitInfo.point, canInstall: true, tick, component.size);
				this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
				{
					isdetected = true,
					interactionText = deployString.GetLocalizedString()
				});
				if (playerInput.Player.Interact.triggered)
				{
					GameManager.S.InstallBulePrint();
				}
			}
			else
			{
				Furniture component2 = itemOnHand.GetComponent<Furniture>();
				GameManager.S.DrawBluePrint(component2.furnitureGO, hitInfo.point, canInstall: false, tick, component2.size);
				this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
				{
					isdetected = false
				});
			}
		}
		else
		{
			GameManager.S.DeleteBluePrint();
			this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
			{
				isdetected = false
			});
		}
	}

	private void PlayerRaycast()
	{
		Vector3 position = GameManager.S.cinemachinePOVCamera.transform.position;
		Vector3 forward = GameManager.S.cinemachinePOVCamera.transform.forward;
		float num = 2f;
		Debug.DrawRay(position, forward * num, Color.red);
		if (rocketOnHand)
		{
			if (Physics.Raycast(position, forward, out var hitInfo, num * 2f))
			{
				if (IsInLayerMask(hitInfo.collider.gameObject, installableLayerMask))
				{
					GameManager.S.DrawRocketMountBluePrint(rocket, hitInfo.point, canInstall: true);
					this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
					{
						isdetected = true,
						interactionText = deployString.GetLocalizedString()
					});
					if (playerInput.Player.Interact.triggered)
					{
						if (GameManager.S.isRocketMountExist)
						{
							GameManager.S.RocketMountExist();
							return;
						}
						GameManager.S.InstallRocketMountBluePrint();
						this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
						{
							isdetected = false,
							interactionText = ""
						});
						return;
					}
				}
				else
				{
					GameManager.S.DeleteBluePrint();
					this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
					{
						isdetected = false,
						interactionText = ""
					});
				}
			}
			else
			{
				GameManager.S.DeleteBluePrint();
				this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
				{
					isdetected = false,
					interactionText = ""
				});
			}
		}
		if (Physics.SphereCast(position, 0.1f, forward, out var hitInfo2, num, interactionLayerMask))
		{
			if (hitInfo2.collider.gameObject.layer == LayerMask.NameToLayer("RaycastBlock"))
			{
				if (isDetected)
				{
					this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
					{
						isdetected = false
					});
					isDetected = false;
					if (lastInteractable != null)
					{
						lastInteractable?.OnLost();
						this.OnAltInteractionUndetected?.Invoke();
						lastInteractable = null;
					}
				}
				return;
			}
			IInteractable componentInParent = hitInfo2.collider.GetComponentInParent<IInteractable>();
			IAltInteractable componentInParent2 = hitInfo2.collider.GetComponentInParent<IAltInteractable>();
			if (componentInParent != lastInteractable)
			{
				if (lastInteractable != null)
				{
					lastInteractable?.OnLost();
					this.OnAltInteractionUndetected?.Invoke();
				}
				componentInParent.OnDetected();
				lastInteractable = componentInParent;
				if (componentInParent2 != null && itemOnHand == null)
				{
					this.OnAltInteractionDetected?.Invoke(componentInParent2.AltInteractionText);
				}
			}
			this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
			{
				isdetected = true,
				interactionText = componentInParent.InteractionText
			});
			isDetected = true;
			if (playerInput.Player.AltInteract.triggered && componentInParent2 != null)
			{
				componentInParent2.AltInteract();
				this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
				{
					isdetected = false
				});
				isDetected = false;
				lastInteractable?.OnLost();
				lastInteractable = null;
				this.OnAltInteractionUndetected?.Invoke();
			}
			else if (playerInput.Player.Interact.triggered)
			{
				componentInParent.Interact();
			}
		}
		else if (isDetected)
		{
			this.InteractableDetected?.Invoke(this, new InteractableDetectedArgs
			{
				isdetected = false
			});
			isDetected = false;
			lastInteractable?.OnLost();
			lastInteractable = null;
			this.OnAltInteractionUndetected?.Invoke();
		}
	}

	private void Jump(InputAction.CallbackContext obj)
	{
		if (obj.interaction is PressInteraction && canControl && grounded)
		{
			gravityVelocity.y = Mathf.Sqrt(Mathf.Pow(tempSpeed + 1f, 1f / 3f) * 1.5f * (0f - gravity));
			grounded = false;
			groundCheckDelay = 0f;
		}
	}

	public void GrabItem(GameObject item)
	{
		itemOnHand = item;
		if (item.TryGetComponent<Food>(out var _))
		{
			this.OnFoodInHand?.Invoke();
		}
		else
		{
			this.OnItemInHand?.Invoke();
		}
		if (item.TryGetComponent<Rigidbody>(out var component2))
		{
			if (!component2.isKinematic)
			{
				component2.linearVelocity = Vector3.zero;
				component2.angularVelocity = Vector3.zero;
			}
			component2.isKinematic = true;
		}
		Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		item.transform.parent = hand;
		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
		AudioManager.S.PlaySFX(AudioManager.S.grabItem);
	}

	public void GrabTool(GameObject item)
	{
		itemOnHand = item;
		this.OnItemInHand?.Invoke();
		if (item.TryGetComponent<Rigidbody>(out var component))
		{
			if (!component.isKinematic)
			{
				component.linearVelocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.isKinematic = true;
		}
		Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		item.transform.parent = base.gameObject.transform;
		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
	}

	private bool IsInLayerMask(GameObject obj, LayerMask mask)
	{
		return ((1 << obj.layer) & (int)mask) != 0;
	}

	public Vector2 GetMouseInput()
	{
		return playerInput.Player.Look.ReadValue<Vector2>() * mouseSensitivity;
	}

	public void SellFood()
	{
		if (GameManager.S.intelPerkList[1])
		{
			AddExp(5);
			int num = Mathf.FloorToInt(itemOnHand.GetComponent<Food>().value * 1.5f);
			MoneyUpdated(num);
		}
		else
		{
			float value = itemOnHand.GetComponent<Food>().value;
			MoneyUpdated(value);
		}
		AudioManager.S.PlaySFX(AudioManager.S.money);
		UnityEngine.Object.Destroy(itemOnHand);
		itemOnHand = null;
	}

	public void SellStuff()
	{
		AudioManager.S.PlaySFX(AudioManager.S.money);
		float x = itemOnHand.GetComponent<Item>().value * 0.5f;
		x = MathF.Round(x, 1);
		MoneyUpdated(x);
		UnityEngine.Object.Destroy(itemOnHand);
		itemOnHand = null;
	}

	public void GiveFood()
	{
		UnityEngine.Object.Destroy(itemOnHand);
		itemOnHand = null;
	}

	public void MoneyUpdated(float foodValue)
	{
		money = Mathf.Round((money + foodValue) * 10f) / 10f;
		GameManager.S.MoneyUpdated();
	}

	public void ComsumeItem()
	{
		UnityEngine.Object.Destroy(itemOnHand);
		itemOnHand = null;
		rocketOnHand = false;
		paintOnHand = false;
		furnitureOnHand = false;
		rocket = null;
		this.OnItemOutHand?.Invoke();
	}

	public void AddExp(int amount)
	{
		exp += amount;
		while (KnowledgeLevel < expTable.Length - 1 && exp >= expTable[KnowledgeLevel])
		{
			exp -= expTable[KnowledgeLevel];
			KnowledgeLevel++;
			GameManager.S.PlayerLevelUp();
			Debug.Log("레벨업");
			AudioManager.S.PlayDoorBell(AudioManager.S.levelUp);
		}
	}

	public void SavePlayerData()
	{
		ES3.Save("Player_Knowledge", KnowledgeLevel);
		ES3.Save("Player_Exp", exp);
		ES3.Save("Player_Stamina", stamina);
		ES3.Save("Player_Hunger", hunger);
		ES3.Save("Player_Money", money);
		ES3.Save("Player_Ticket", ticket);
	}

	public void LoadPlayerData()
	{
		KnowledgeLevel = ES3.Load("Player_Knowledge", 1);
		exp = ES3.Load("Player_Exp", 0);
		stamina = ES3.Load("Player_Stamina", maxStamina);
		hunger = ES3.Load("Player_Hunger", 10f);
		money = ES3.Load("Player_Money", 0f);
		ticket = ES3.Load("Player_Ticket", 0);
	}
}
