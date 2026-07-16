using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public delegate void Vector2IntEventHandler(Vector2Int input);

	private StateMachine sm;

	[SerializeField]
	private InputHandler inputHandler;

	[SerializeField]
	private PlayerInput playerInput;

	[NonSerialized]
	public Rigidbody2D rb2d;

	[NonSerialized]
	public bool canMove = true;

	private Vector2Int previousStickMoveCardinal;

	private Vector3 lastNonZeroMoveInput;

	private Vector2 lockedMoveVector = Vector2.zero;

	[NonSerialized]
	public Interactable interactTarget;

	public Interactor interactor;

	[Header("Interruption")]
	[SerializeField]
	private float pushStrength = 0.25f;

	[SerializeField]
	private AudioClip pushSound;

	[SerializeField]
	private AudioClip punchSound;

	[NonSerialized]
	public Animator animator;

	[SerializeField]
	private GameObject hat;

	[NonSerialized]
	public AudioSource audioSource;

	public AudioClip[] sounds;

	[SerializeField]
	private InputActionAsset inputActionAsset;

	public bool isAiming;

	private bool interact;

	[NonSerialized]
	public float speedModifierMove = 1f;

	[NonSerialized]
	public float speedModifierRepair = 1f;

	[NonSerialized]
	public float speedModifierShovel = 1f;

	[NonSerialized]
	public HotkeyTooltips primaryHotkeyTooltip;

	[NonSerialized]
	public HotkeyTooltips hotkeyTooltip;

	[NonSerialized]
	public HotkeyTooltips interruptedHotkeyTooltips;

	[SerializeField]
	private InputActionReference inputActionRefRepairUp;

	[SerializeField]
	private InputActionReference inputActionRefRepairLeft;

	[SerializeField]
	private InputActionReference inputActionRefRepairDown;

	[SerializeField]
	private InputActionReference inputActionRefRepairRight;

	[NonSerialized]
	public bool isShoveling;

	[NonSerialized]
	public bool pauseRepairing;

	private int interruptAttempts;

	private Coroutine interruptCoroutine;

	private int pushTweenId = -1;

	public StateMachine SM => sm;

	public InputHandler InputHandler => inputHandler;

	public int PlayerIndex => inputHandler.PlayerIndex;

	public string PlayerDisplayName => $"P{PlayerIndex + 1}";

	[field: SerializeField]
	public float MoveSpeed { get; private set; }

	public Vector2 RawInput { get; private set; }

	[field: SerializeField]
	public float TimeToFillFurnace { get; set; }

	[field: SerializeField]
	public float RepairSpeed { get; private set; }

	[field: SerializeField]
	public float StartingRepairSpeed { get; private set; }

	public bool canRepairAdjacentModules { get; set; }

	public float repairAmount { get; set; }

	public bool IsGamepad => inputHandler.IsGamepad;

	public Vector2 Point { get; private set; }

	public bool Interact
	{
		get
		{
			if (interact)
			{
				interact = false;
				return true;
			}
			return false;
		}
		set
		{
			interact = value;
		}
	}

	public bool Repair { get; private set; }

	public bool ActionPrimary { get; private set; }

	public bool ActionSecondary { get; private set; }

	public bool Reload { get; private set; }

	public bool Reroll { get; private set; }

	public InputActionReference[] repairInputActionRefs => new InputActionReference[4] { inputActionRefRepairUp, inputActionRefRepairRight, inputActionRefRepairLeft, inputActionRefRepairDown };

	public event Vector2IntEventHandler OnStickMoveCardinal;

	public event Action<PlayerController> onDeviceChange;

	public bool GetInteractNoConsume()
	{
		return interact;
	}

	public void LockMoveDirection(Vector2 dir)
	{
		lockedMoveVector = dir;
	}

	private void Awake()
	{
		animator = GetComponent<Animator>();
		interactor = GetComponent<Interactor>();
		rb2d = GetComponent<Rigidbody2D>();
		sm = new StateMachine();
		audioSource = GetComponent<AudioSource>();
		sm.BuildStateDictionary(new StateBase[5]
		{
			new PlayerIdle(sm, this),
			new PlayerWalk(sm, this),
			new PlayerInteract(sm, this),
			new PlayerRepairDamage(sm, this),
			new PlayerRepairMinigame(sm, this)
		});
		lastNonZeroMoveInput = Vector3.zero;
	}

	private IEnumerator Start()
	{
		if (PlayerIndex == -1)
		{
			yield return new WaitUntil(() => PlayerIndex >= 0);
		}
		base.name = PlayerDisplayName;
		CreateHotkeyTooltips((PlayerIndex != 0) ? HotkeyTooltipsPosition.Lower : HotkeyTooltipsPosition.Upper);
		hat.SetActive(PlayerManager.Instance.Players.Count > 1);
		hat.GetComponent<SpriteRenderer>().color = PlayerManager.Instance.PlayerColors[PlayerIndex];
		Train.Instance.GetModuleByType<ModuleFurnace>().FurnaceReady += HandleFurnaceReady;
		LevelManager.Instance.LevelCompleted += HandleLevelCompleted;
		LevelManager.Instance.LevelStarted += HandleLevelStarted;
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		InputManager.Instance.OnInteract += HandleInteract;
		InputManager.Instance.OnInterrupt += HandleInterrupt;
		PlayerManager.Instance.OnCoopStarted += HandleCoopStarted;
		PlayerManager.Instance.OnCoopEnded += HandleCoopEnded;
		PlayerManager.Instance.OnColorsChanged += HandleColorsChanged;
		if ((bool)CameraController.Instance && CameraController.Instance.Targets != null)
		{
			CameraController.Instance.Targets.Add(base.transform);
		}
	}

	private void OnDestroy()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType != null)
		{
			moduleByType.FurnaceReady -= HandleFurnaceReady;
		}
		LevelManager.Instance.LevelCompleted -= HandleLevelCompleted;
		LevelManager.Instance.LevelStarted -= HandleLevelStarted;
		LevelManager.Instance.DestinationReached -= HandleDestinationReached;
		InputManager.Instance.OnInteract -= HandleInteract;
		InputManager.Instance.OnInterrupt -= HandleInterrupt;
		PlayerManager.Instance.OnCoopStarted -= HandleCoopStarted;
		PlayerManager.Instance.OnCoopEnded -= HandleCoopEnded;
		PlayerManager.Instance.OnColorsChanged -= HandleColorsChanged;
		if ((bool)CameraController.Instance && CameraController.Instance.Targets != null)
		{
			CameraController.Instance.Targets.Remove(base.transform);
		}
	}

	private void CreateHotkeyTooltips(HotkeyTooltipsPosition position)
	{
		primaryHotkeyTooltip = UnityEngine.Object.Instantiate(UIManager.Instance.HotkeyTooltipUpperPrefab, UIManager.Instance.HotkeyCanvasTf.GetChild(0)).GetComponent<HotkeyTooltips>();
		primaryHotkeyTooltip.name = PlayerDisplayName + " primary hotkey tooltip";
		primaryHotkeyTooltip.player = this;
		hotkeyTooltip = UnityEngine.Object.Instantiate((position == HotkeyTooltipsPosition.Upper) ? UIManager.Instance.HotkeyTooltipUpperPrefab : UIManager.Instance.HotkeyTooltipLowerPrefab, UIManager.Instance.HotkeyCanvasTf.GetChild(0)).GetComponent<HotkeyTooltips>();
		hotkeyTooltip.name = PlayerDisplayName + " hotkey tooltip";
		hotkeyTooltip.player = this;
	}

	private void HandleCoopStarted(PlayerController controller)
	{
		hat.SetActive(value: true);
	}

	private void HandleCoopEnded(PlayerController controller)
	{
		if (hotkeyTooltip.Position == HotkeyTooltipsPosition.Lower)
		{
			UnityEngine.Object.Destroy(hotkeyTooltip.gameObject);
			UnityEngine.Object.Destroy(primaryHotkeyTooltip.gameObject);
		}
		hotkeyTooltip.SetInteractable(null, null);
		hotkeyTooltip.SetInterruptable(null, null);
		hat.SetActive(value: false);
		if ((bool)interactor.ActiveInteractable)
		{
			interactor.ActiveInteractable.Deselect(interactor);
		}
	}

	private void Update()
	{
		if (Time.timeScale == 0f || PlayerIndex == -1)
		{
			return;
		}
		Move();
		sm.UpdateStates();
		sm.FixedUpdateStates();
		UpdateHotkeyTooltip();
		if ((bool)interactor.ActiveInteractable)
		{
			if (IsGamepad)
			{
				interactor.ActiveInteractable.TranslatePoint(Point);
			}
			else
			{
				interactor.ActiveInteractable.SetPoint(Point);
			}
		}
	}

	private void LateUpdate()
	{
		Interact = false;
		Repair = false;
		ActionSecondary = false;
		Reroll = false;
	}

	public void ForceIdleState()
	{
		sm.ForceState("Idle");
	}

	private void HandleInteract(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (PlayerIndex == playerIndex)
		{
			Interact = true;
			interactor.repairMinigame?.InteractKey(interactor);
		}
	}

	private void HandleInterrupt(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (PlayerIndex == playerIndex)
		{
			if (interruptCoroutine != null)
			{
				StopCoroutine(interruptCoroutine);
			}
			interruptCoroutine = StartCoroutine(TryInterruptCoroutine());
		}
	}

	private IEnumerator TryInterruptCoroutine()
	{
		interruptAttempts++;
		CameraController.Instance.Shake(0.3f, 0.15f, force: true);
		if (interruptAttempts >= InputManager.Instance.InterruptAttemptsRequired)
		{
			audioSource.PlayOneShot(pushSound);
			PushToInterrupt();
			yield return new WaitForEndOfFrame();
			interruptAttempts = 0;
			interactor.InterruptingInteractable?.Interrupt(interactor);
			yield return new WaitForEndOfFrame();
		}
		else
		{
			audioSource.PlayOneShot(punchSound);
			yield return new WaitForSeconds(InputManager.Instance.InterruptTime);
			interruptAttempts = 0;
		}
	}

	private void PushToInterrupt()
	{
		if ((bool)interactor.InterruptingInteractable && (bool)interactor.InterruptingInteractable.Interactor)
		{
			PlayerController otherPlayer = PlayerManager.Instance.GetOtherPlayer(this);
			Module module = interactor.InterruptingInteractable.GetModule();
			Vector3 vector = (otherPlayer.transform.position - base.transform.position).normalized;
			if (Train.Instance.IsFirstModule(module))
			{
				vector = new Vector3(-1f, 0f, 0f);
			}
			else if (Train.Instance.IsLastModule(module))
			{
				vector = new Vector3(1f, 0f, 0f);
			}
			else if (vector == Vector3.zero)
			{
				vector = new Vector3(-1f, 0f, 0f);
			}
			vector = ((!(vector.x < 0f)) ? new Vector3(1f, 0f, 0f) : new Vector3(-1f, 0f, 0f));
			otherPlayer.StopInteracting();
			otherPlayer.Push(vector, 0.5f);
		}
	}

	public void OnPoint(InputValue value)
	{
		Point = value.Get<Vector2>();
	}

	public void Move()
	{
		Vector2 vector = (RawInput = inputHandler.MoveInput);
		if (vector.sqrMagnitude > 0f)
		{
			lastNonZeroMoveInput = vector;
		}
		if (lockedMoveVector != Vector2.zero)
		{
			float num = Vector2.Angle(lockedMoveVector, vector);
			if (vector != Vector2.zero && num < 45f)
			{
				RawInput = Vector2.zero;
			}
			else if (vector == Vector2.zero || num >= 45f)
			{
				lockedMoveVector = Vector2.zero;
			}
		}
	}

	public void Push(Vector3 direction, float time)
	{
		LeanTween.cancel(pushTweenId);
		pushTweenId = LeanTween.value(base.gameObject, base.transform.position, base.transform.position + direction * pushStrength, time).setOnUpdate(delegate(Vector2 pos)
		{
			base.transform.position = pos;
		}).setEase(LeanTweenType.easeOutExpo)
			.id;
	}

	public void WallStopPush()
	{
		LeanTween.cancel(pushTweenId);
	}

	public void OnRepairMinigameUpPress(InputValue value)
	{
		interactor.repairMinigame?.SequencePress(interactor, inputActionRefRepairUp);
	}

	public void OnRepairMinigameLeftPress(InputValue value)
	{
		interactor.repairMinigame?.SequencePress(interactor, inputActionRefRepairLeft);
	}

	public void OnRepairMinigameDownPress(InputValue value)
	{
		interactor.repairMinigame?.SequencePress(interactor, inputActionRefRepairDown);
	}

	public void OnRepairMinigameRightPress(InputValue value)
	{
		interactor.repairMinigame?.SequencePress(interactor, inputActionRefRepairRight);
	}

	private void StickMoveCardinal(Vector2 moveInput)
	{
		if (!IsGamepad)
		{
			return;
		}
		if (moveInput.magnitude < 0.5f)
		{
			previousStickMoveCardinal = Vector2Int.zero;
			return;
		}
		Vector2Int zero = Vector2Int.zero;
		if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
		{
			zero.x = (int)Mathf.Sign(moveInput.x);
			zero.y = 0;
		}
		else
		{
			zero.x = 0;
			zero.y = -(int)Mathf.Sign(moveInput.y);
		}
		if (zero != previousStickMoveCardinal)
		{
			this.OnStickMoveCardinal?.Invoke(zero);
			previousStickMoveCardinal = zero;
		}
	}

	public void OnFix(InputValue value)
	{
		Repair = true;
	}

	public void OnReroll(InputValue value)
	{
		Reroll = true;
	}

	public void OnFire(InputValue value)
	{
		if (value.isPressed)
		{
			ActionPrimary = true;
		}
		else
		{
			ActionPrimary = false;
		}
	}

	public void OnReload(InputValue value)
	{
		if (interactor.ActiveInteractable != null && interactor.ActiveInteractable.TryGetComponent<Module>(out var component))
		{
			component.OnReload(interactor);
		}
	}

	public void OnActionSecondary(InputValue value)
	{
		ActionSecondary = true;
	}

	private void UpdateHotkeyTooltip()
	{
		if (!hotkeyTooltip || !primaryHotkeyTooltip)
		{
			return;
		}
		if (interactor.InteractorState != InteractorStates.Standard)
		{
			primaryHotkeyTooltip.CloseAll();
			hotkeyTooltip.CloseAll();
		}
		else if ((bool)interactor.InterruptingInteractable)
		{
			if (interactor.InterruptingInteractable.ShowOnlyUpperTooltips)
			{
				primaryHotkeyTooltip.SetInterruptable(interactor.InterruptingInteractable, this);
			}
			else
			{
				hotkeyTooltip.SetInterruptable(interactor.InterruptingInteractable, this);
			}
		}
		else if ((bool)interactor.ActiveInteractable)
		{
			if (interactor.ActiveInteractable.ShowOnlyUpperTooltips)
			{
				primaryHotkeyTooltip.SetInteractable(interactor.ActiveInteractable, this);
			}
			else
			{
				hotkeyTooltip.SetInteractable(interactor.ActiveInteractable, this);
			}
		}
		else
		{
			primaryHotkeyTooltip.CloseAll();
			hotkeyTooltip.CloseAll();
		}
	}

	public void Unstuck()
	{
		base.transform.position = Train.Instance.GetPlayerSpawnPoint(PlayerIndex);
	}

	public void AimMove()
	{
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, lastNonZeroMoveInput);
	}

	public void AimTarget(Transform target)
	{
		Vector3 upwards = target.position - base.transform.position;
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		lastNonZeroMoveInput = upwards;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Train")
		{
			base.transform.SetParent(collision.transform);
			if (collision.gameObject.TryGetComponent<Wagon>(out var component))
			{
				component.AddPlayer(this);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.transform.tag == "Train" && collision.gameObject.TryGetComponent<Wagon>(out var component))
		{
			component.RemovePlayer(this);
		}
	}

	public void CheckRoofsAfterDelay(float delay = 0.1f)
	{
		StartCoroutine(TryUpdateRoofAfterDelay(delay));
	}

	private IEnumerator TryUpdateRoofAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		base.transform.GetComponentInParent<Wagon>()?.UpdateRoofsVisibility();
	}

	private void HandleFurnaceReady(Interactor invoker)
	{
		if (invoker == interactor)
		{
			base.transform.position = Train.Instance.Modules[0].transform.position;
			interactor.ForceInteract(Train.Instance.Modules[0].GetComponent<Interactable>());
			sm.ForceState("Interact");
		}
		else
		{
			base.transform.position = Train.Instance.GetPlayerSpawnPoint(1);
			sm.ForceState("Idle");
		}
		canMove = false;
		interactor.InteractorState = InteractorStates.Forced;
	}

	private void HandleLevelStarted()
	{
		canMove = true;
		interactor.InteractorState = InteractorStates.Standard;
	}

	private void HandleLevelCompleted()
	{
		sm.ForceState("Idle");
	}

	public void SetUpForNewSpawn()
	{
		HandleDestinationReached();
	}

	private void HandleDestinationReached()
	{
		canMove = true;
		interactor.whitelist = LevelManager.Instance.StationInteractableWhitelist;
		interactor.InteractorState = InteractorStates.Standard;
	}

	public bool IsInteracting()
	{
		return sm.CurrentState.Key == "Interact";
	}

	public bool IsRepairDamage()
	{
		return sm.CurrentState.Key == "RepairDamage";
	}

	public bool IsRepairMinigame()
	{
		return sm.CurrentState.Key == "RepairMinigame";
	}

	public void PlayerShovelAnimPeak()
	{
		(Train.Instance.Modules[0] as ModuleFurnace).PlayParticleSystems();
	}

	public void PlayerShovelAnimBottom()
	{
		(Train.Instance.Modules[0] as ModuleFurnace).PlaySound();
	}

	public void UpgradeMoveSpeed(float percentValue)
	{
		MoveSpeed *= 1f + percentValue;
	}

	public void UpgradeRepairSpeed(float value, bool isPercent = true)
	{
		if (isPercent)
		{
			RepairSpeed += StartingRepairSpeed * (1f + value) - StartingRepairSpeed;
		}
		else
		{
			RepairSpeed += value;
		}
	}

	public void UpgradeRepairAdjacentModules(float repairAmountPercent)
	{
		canRepairAdjacentModules = true;
		repairAmount = repairAmountPercent / 100f;
	}

	internal Color GetPlayerColor()
	{
		if (PlayerManager.Instance.IsCoop && PlayerManager.Instance.PlayerColors.Count > PlayerIndex && PlayerIndex >= 0)
		{
			return PlayerManager.Instance.GetPlayerColor(PlayerIndex);
		}
		return Color.white;
	}

	internal void StopInteracting()
	{
		sm.ForceState("Idle");
	}

	private void HandleColorsChanged()
	{
		hat.GetComponent<SpriteRenderer>().color = GetPlayerColor();
	}
}
