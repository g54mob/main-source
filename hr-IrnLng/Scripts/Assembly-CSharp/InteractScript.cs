using Rewired;
using UnityEngine;

public class InteractScript : ImportantObjectClass
{
	public float InteractDistance;

	public LayerMask InteractLayers;

	private Player player;

	private CanvasGroup MapCanvas;

	private MyMouseLook MyMouse;

	[HideInInspector]
	public bool MapState;

	private float ExtinguishDistance;

	public LayerMask ExtinguishLayers;

	public bool HasExtinguisher;

	private bool DoExtinguish;

	public GameObject Extinguisher;

	public ParticleSystem ExtinguisherParts;

	private bool ExtinguisherRaisedButton;

	public AudioSource ExtinguisherSound;

	private CanvasGroup BriefingCanvas;

	private bool BriefingState;

	public CanvasGroup Cursor;

	private PlayerEventScript EventScript;

	private NoteScript Note;

	public CanvasGroup ExitPrompt;

	private MonsterModelTriggerScript MScript;

	private TerminalScript TScript;

	private void Awake()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Start()
	{
		Note = GameObject.Find("Note").GetComponent<NoteScript>();
		TScript = GameObject.Find("TerminalCanvas").GetComponent<TerminalScript>();
		EventScript = GameObject.Find("PlayerEventManager").GetComponent<PlayerEventScript>();
		MapCanvas = GameObject.Find("MapCanvas").GetComponent<CanvasGroup>();
		BriefingCanvas = GameObject.Find("BriefingCanvas").GetComponent<CanvasGroup>();
		MyMouse = GameObject.Find("PlayerCamera").GetComponent<MyMouseLook>();
		MScript = GameObject.Find("MonsterModelTrigger").GetComponent<MonsterModelTriggerScript>();
		ExtinguishDistance = 50f;
	}

	private void Update()
	{
		if (player.GetButtonDown("Esc"))
		{
			if (!MapState && !BriefingState && !Note.NoteState() && !TScript.CanType)
			{
				if (ExitPrompt.alpha == 1f)
				{
					TogglePrompt(b: false);
				}
				else
				{
					TogglePrompt(b: true);
				}
				return;
			}
			ToggleMap(0);
			ToggleBriefing(0);
			TScript.CanType = false;
		}
		if (player.GetButtonDown("Cancel") && ExitPrompt.alpha == 1f)
		{
			TogglePrompt(b: false);
		}
		else
		{
			if (EventScript.MyData.DoingFirstPause)
			{
				return;
			}
			bool flag = false;
			if (Note.NoteState() && (player.GetButtonDown("Use") || player.GetButtonDown("Esc")))
			{
				Note.ToggleNote(b: false);
				return;
			}
			if (player.GetButtonDown("Map") && !TScript.CanType)
			{
				ToggleMap(-1);
				TScript.CanType = false;
				Note.ToggleNote(b: false);
				EventScript.MyData.PressedMap = true;
			}
			if (player.GetButtonDown("Briefing") && !TScript.CanType)
			{
				ToggleBriefing(-1);
				TScript.CanType = false;
				Note.ToggleNote(b: false);
				EventScript.MyData.PressedBriefing = true;
			}
			if (player.GetButtonDown("ExitTerminal"))
			{
				TScript.CanType = false;
			}
			if (player.GetButtonDown("Confirm") && ExitPrompt.alpha == 1f)
			{
				ReturnToMenu();
			}
			if (MScript.DoingAttackDelay)
			{
				ToggleMap(0);
				ToggleBriefing(0);
				TScript.CanType = false;
			}
			if (BriefingState || MapState || TScript.CanType)
			{
				return;
			}
			if (player.GetButtonDown("Use"))
			{
				TScript.CanType = false;
			}
			if (!HasExtinguisher)
			{
				ExtinguisherRaisedButton = false;
				DoExtinguish = false;
				if (player.GetButtonDown("Use"))
				{
					Interact();
					flag = true;
				}
				if (player.GetButton("Use") && !flag)
				{
					ConstantInteract();
				}
				return;
			}
			if (player.GetButtonDown("Use") && (bool)CheckForInteractive())
			{
				Interact();
				return;
			}
			if (player.GetButtonDown("Use") && ExtinguisherRaisedButton)
			{
				DoExtinguish = true;
				ExtinguisherParts.Play();
				ExtinguisherSound.Play();
			}
			if (player.GetButtonUp("Use"))
			{
				DoExtinguish = false;
				ExtinguisherParts.Stop();
				ExtinguisherRaisedButton = true;
				ExtinguisherSound.Stop();
			}
		}
	}

	private void FixedUpdate()
	{
		Extinguisher.SetActive(HasExtinguisher);
		if (DoExtinguish)
		{
			ShootFireExtinguisher();
		}
		if ((bool)CheckForInteractive())
		{
			Cursor.alpha = 1f;
		}
		else
		{
			Cursor.alpha = 0f;
		}
	}

	private void ReturnToMenu()
	{
		Application.LoadLevel("Menu");
	}

	private void TogglePrompt(bool b)
	{
		if (b)
		{
			ExitPrompt.alpha = 1f;
		}
		else
		{
			ExitPrompt.alpha = 0f;
		}
	}

	private void ToggleBriefing(int i)
	{
		if (i == -1)
		{
			BriefingState = !BriefingState;
		}
		if (i == 0)
		{
			BriefingState = false;
		}
		if (i == 1)
		{
			BriefingState = true;
		}
		if (BriefingState)
		{
			BriefingCanvas.alpha = 1f;
			ToggleMap(0);
		}
		else
		{
			BriefingCanvas.alpha = 0f;
		}
	}

	private void ToggleMap(int i)
	{
		if (i == -1)
		{
			MapState = !MapState;
		}
		if (i == 0)
		{
			MapState = false;
		}
		if (i == 1)
		{
			MapState = true;
		}
		MyMouse.SetCursor(!MapState);
		if (MapState)
		{
			MapCanvas.alpha = 1f;
			MapCanvas.interactable = true;
			MapCanvas.blocksRaycasts = true;
			ToggleBriefing(0);
		}
		else
		{
			MapCanvas.alpha = 0f;
			MapCanvas.interactable = false;
			MapCanvas.blocksRaycasts = false;
		}
	}

	private void Interact()
	{
		GameObject gameObject = CheckForInteractive();
		if (gameObject != null)
		{
			gameObject.GetComponent<ImportantObjectClass>().DoInteraction();
		}
	}

	private void ConstantInteract()
	{
		GameObject gameObject = CheckForInteractive();
		if (gameObject != null)
		{
			gameObject.GetComponent<ImportantObjectClass>().DoConstantInteraction();
		}
	}

	private GameObject CheckForInteractive()
	{
		GameObject result = null;
		if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, InteractDistance, InteractLayers) && hitInfo.transform.tag == "InteractiveObject")
		{
			result = hitInfo.transform.gameObject;
		}
		return result;
	}

	private void ShootFireExtinguisher()
	{
		if (Physics.SphereCast(base.transform.position, 0.25f, base.transform.forward, out var hitInfo, ExtinguishDistance, ExtinguishLayers))
		{
			hitInfo.transform.gameObject.GetComponent<FireScript>().Extinguish();
		}
	}
}
