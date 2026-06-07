using System.Collections;
using Pathfinding.RVO;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(RVOController))]
public class PlayerMovement : MonoBehaviour
{
	public static float gameplayTimeScale = 1f;

	protected Vector3 startPosition;

	public float speed = 14f;

	public float speedDuringDay = 14f;

	public float sprintSpeed = 23f;

	public float sprintSpeedDuringDay = 23f;

	public float moveSpeedWhenDead = 8f;

	public float gravity = -19.62f;

	public Transform meshParent;

	public float maxMeshRotationSpeed = 360f;

	public Animator meshAnimator;

	public float yFallThroughMapDetection = -10f;

	private Hp hp;

	protected Transform viewTransform;

	protected CharacterController controller;

	protected Player input;

	private Quaternion desiredMeshRotation;

	private RVOController rvoController;

	protected float yVelocity;

	protected bool heavyArmorEquipped;

	protected bool racingHorseEquipped;

	protected bool canAlwaysSprintEquipped;

	private bool moving;

	protected bool sprinting;

	private bool sprintingToggledOn;

	private bool dead;

	public static PlayerMovement instance;

	[SerializeField]
	private Equippable heavyArmorPerk;

	[SerializeField]
	private Equippable warHorsePerk;

	[SerializeField]
	private Equippable canAlwaysSprint;

	protected DayNightCycle dayNightCycle;

	protected float slowedFor = -1f;

	protected Vector3 velocity;

	public Hp Hp => hp;

	public bool Moving => moving;

	public bool Sprinting => sprinting;

	public bool Dead
	{
		get
		{
			return dead;
		}
		set
		{
			dead = value;
		}
	}

	public Vector3 Velocity => velocity;

	public static void ToggleTimeScale()
	{
		if (Time.timeScale != 0f)
		{
			if (gameplayTimeScale == 1f)
			{
				gameplayTimeScale = 2f;
			}
			else
			{
				gameplayTimeScale = 1f;
			}
			Time.timeScale = gameplayTimeScale;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	public void TeleportTo(Vector3 _position)
	{
		controller.enabled = false;
		controller.transform.position = _position;
		StartCoroutine(EnableControllerNextFrame(controller));
	}

	public virtual void Start()
	{
		startPosition = base.transform.position;
		PlayerManager.RegisterPlayer(this);
		viewTransform = Camera.main.transform;
		controller = GetComponent<CharacterController>();
		input = ReInput.players.GetPlayer(0);
		rvoController = GetComponent<RVOController>();
		hp = GetComponent<Hp>();
		heavyArmorEquipped = PerkManager.IsEquipped(heavyArmorPerk);
		racingHorseEquipped = PerkManager.IsEquipped(warHorsePerk);
		canAlwaysSprintEquipped = PerkManager.IsEquipped(canAlwaysSprint);
		dayNightCycle = DayNightCycle.Instance;
	}

	public void Slow(float duration)
	{
		slowedFor = Mathf.Max(duration, slowedFor);
	}

	private void Update()
	{
		if (input.GetButtonDown("Change Timescale"))
		{
			ToggleTimeScale();
		}
		Vector2 inputVector = new Vector2(input.GetAxis("Move Vertical"), input.GetAxis("Move Horizontal"));
		if (input.GetButton("Move Towards Mouse"))
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector3 vector = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
			inputVector = new Vector2(mousePosition.y - vector.y, mousePosition.x - vector.x);
		}
		if (LocalGamestate.Instance.PlayerFrozen)
		{
			inputVector = Vector2.zero;
		}
		if (input.GetButtonDown("Sprint Toggle"))
		{
			sprintingToggledOn = !sprintingToggledOn;
		}
		if (sprintingToggledOn && input.GetButton("Sprint"))
		{
			sprintingToggledOn = false;
		}
		sprinting = (input.GetButton("Sprint") || sprintingToggledOn) && (hp.HpPercentage >= 1f || canAlwaysSprintEquipped);
		MoveScript(inputVector);
		if (((Behaviour)(object)rvoController).enabled)
		{
			rvoController.velocity = velocity;
		}
		Vector3 vector2 = new Vector3(velocity.x, 0f, velocity.z);
		moving = vector2.sqrMagnitude > 0.1f;
		if (moving)
		{
			desiredMeshRotation = Quaternion.LookRotation(vector2.normalized, Vector3.up);
		}
		if (desiredMeshRotation != meshParent.rotation)
		{
			meshParent.rotation = Quaternion.RotateTowards(meshParent.rotation, desiredMeshRotation, maxMeshRotationSpeed * Time.deltaTime);
		}
		meshAnimator.SetBool("Moving", moving);
		meshAnimator.SetBool("Sprinting", sprinting);
	}

	private void OnDisable()
	{
		meshAnimator.SetBool("Moving", value: false);
	}

	private IEnumerator EnableControllerNextFrame(CharacterController controller)
	{
		yield return new WaitForEndOfFrame();
		controller.enabled = true;
	}

	public virtual void MoveScript(Vector2 inputVector)
	{
		Vector3 normalized = Vector3.ProjectOnPlane(viewTransform.forward, Vector3.up).normalized;
		Vector3 normalized2 = Vector3.ProjectOnPlane(viewTransform.right, Vector3.up).normalized;
		velocity = Vector3.zero;
		velocity += normalized * inputVector.x;
		velocity += normalized2 * inputVector.y;
		velocity = Vector3.ClampMagnitude(velocity, 1f);
		if (Dead)
		{
			slowedFor = -1f;
			velocity *= moveSpeedWhenDead;
		}
		else
		{
			bool flag = dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day;
			velocity *= ((!sprinting) ? (flag ? speedDuringDay : speed) : (flag ? sprintSpeedDuringDay : sprintSpeed));
			slowedFor -= Time.deltaTime;
			velocity *= ((slowedFor > 0f) ? 0.33f : 1f);
			if (heavyArmorEquipped && DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				velocity *= PerkManager.instance.heavyArmor_SpeedMultiplyer;
			}
			if (racingHorseEquipped)
			{
				velocity *= PerkManager.instance.racingHorse_SpeedMultiplyer;
			}
		}
		if (controller.enabled)
		{
			if (controller.isGrounded)
			{
				yVelocity = 0f;
			}
			else
			{
				yVelocity += gravity * Time.deltaTime;
			}
			controller.Move((velocity + Vector3.up * yVelocity) * Time.deltaTime);
			if (base.transform.position.y < yFallThroughMapDetection)
			{
				velocity = Vector3.zero;
				yVelocity = 0f;
				TeleportTo(startPosition);
			}
		}
	}
}
