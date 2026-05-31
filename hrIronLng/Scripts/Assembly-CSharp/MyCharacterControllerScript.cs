using Rewired;
using UnityEngine;

public class MyCharacterControllerScript : MonoBehaviour
{
	[HideInInspector]
	public CharacterController cont;

	public LayerMask HeadBonkLayers;

	public LayerMask GroundedLayers;

	public LayerMask EnemyLayers;

	public float ExtraMovementHaltRadius;

	public float accelspeed = 1f;

	public float frictionamount = 1f;

	public float runmultiplier = 2f;

	public bool alwaysrun;

	public float maxwalkspeed = 1f;

	public float maxrunspeed = 1f;

	public float gravitymagnitude = 1f;

	public float terminalvelocity = 1f;

	[HideInInspector]
	private Vector3 currentvelocity;

	[HideInInspector]
	private float verticalvelocity;

	[HideInInspector]
	public bool grounded;

	[HideInInspector]
	private bool keypressed;

	[HideInInspector]
	private float runningfactor;

	[HideInInspector]
	public float MovementDelay;

	[HideInInspector]
	public bool CanJump = true;

	[HideInInspector]
	public bool IgnoreNextGroundedCheck;

	public GameObject MyCam;

	public AudioSource Footsteps;

	private PlayerEventScript EventScript;

	private Player player;

	private NoteScript Note;

	private TerminalScript TScript;

	private void Awake()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Start()
	{
		TScript = GameObject.Find("TerminalCanvas").GetComponent<TerminalScript>();
		Note = GameObject.Find("Note").GetComponent<NoteScript>();
		cont = GetComponent<CharacterController>();
		EventScript = GameObject.Find("PlayerEventManager").GetComponent<PlayerEventScript>();
	}

	private void FixedUpdate()
	{
		CheckGrounded();
		MovementKeys();
		DoFriction();
		DoGravity();
		CheckBonk();
		CheckBlock();
	}

	private void Update()
	{
		MovementDelay -= Time.deltaTime;
		if (MovementDelay < 0f)
		{
			MovementDelay = 0f;
		}
		if (MovementDelay > 0f)
		{
			currentvelocity = Vector3.zero;
		}
		else
		{
			cont.Move(AddVelocity() * Time.deltaTime);
		}
	}

	private void CheckBlock()
	{
		if (Physics.Raycast(base.transform.position, currentvelocity, out var _, cont.radius + ExtraMovementHaltRadius, EnemyLayers))
		{
			currentvelocity = Vector3.zero;
		}
	}

	public Vector3 AddVelocity()
	{
		return currentvelocity + new Vector3(0f, verticalvelocity, 0f);
	}

	private void MovementKeys()
	{
		if (EventScript.MyData.DoingFirstPause || TScript.CanType)
		{
			return;
		}
		keypressed = false;
		runningfactor = 1f;
		if (alwaysrun)
		{
			runningfactor = runmultiplier;
		}
		else
		{
			runningfactor = 1f;
		}
		player.GetButton("Run");
		Vector3 vector = new Vector3(0f, 0f, 0f);
		if (player.GetButton("Forward"))
		{
			vector += base.transform.forward;
			keypressed = true;
		}
		if (player.GetButton("Backward"))
		{
			vector += -base.transform.forward;
			keypressed = true;
		}
		if (player.GetButton("Left"))
		{
			vector += -base.transform.right;
			keypressed = true;
		}
		if (player.GetButton("Right"))
		{
			vector += base.transform.right;
			keypressed = true;
		}
		vector = vector.normalized;
		currentvelocity += vector * accelspeed * runningfactor;
		if (runningfactor == 1f)
		{
			if (currentvelocity.magnitude > maxwalkspeed)
			{
				currentvelocity = currentvelocity.normalized * maxwalkspeed;
			}
		}
		else if (currentvelocity.magnitude > maxrunspeed)
		{
			currentvelocity = currentvelocity.normalized * maxrunspeed;
		}
		if (keypressed)
		{
			Note.ToggleNote(b: false);
		}
	}

	private void DoFriction()
	{
		currentvelocity /= 1f + frictionamount;
	}

	private void CheckGrounded()
	{
		grounded = cont.isGrounded;
	}

	private void DoGravity()
	{
		if (!grounded)
		{
			verticalvelocity -= gravitymagnitude;
		}
		else
		{
			verticalvelocity = 0f;
		}
		if (verticalvelocity < Mathf.Abs(terminalvelocity) * -1f)
		{
			verticalvelocity = Mathf.Abs(terminalvelocity) * -1f;
		}
	}

	private void CheckBonk()
	{
		if (Physics.SphereCast(base.transform.position, cont.radius, base.transform.up, out var _, cont.height / 2f + cont.skinWidth - cont.radius, HeadBonkLayers) && verticalvelocity > 0f)
		{
			verticalvelocity = 0f;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
	}
}
