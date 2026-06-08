using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation
{
	public DoorStateChangedDelegate AirlockOpenedEvent;

	public DoorStateChangedDelegate AirlockClosedEvent;

	public DoorStateChangedDelegate DoorOpenedEvent;

	public DoorStateChangedDelegate DoorClosedEvent;

	public DoorState state = DoorState.Closed;

	public Transform sliderA;

	public Transform sliderB;

	public bool powered;

	private Color DroneViewColor = Color.black;

	public Color SchematicViewColor;

	public string Label;

	public float CloseRetryDelay = 1f;

	public GameObject[] tiles;

	private bool isDead;

	private static readonly float TOTAL_HITPOINTS = 60f;

	private float currentHitPoints = TOTAL_HITPOINTS;

	public Color DeadColor = Color.grey;

	public Color DisconnectedColor = new Color(0.2f, 0.2f, 0.2f);

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private ColorBlinkManager _blinkManagerDroneView = new ColorBlinkManager();

	private GameObject overlayA;

	private GameObject overlayB;

	private Renderer sliderARenderer;

	private Renderer sliderBRenderer;

	private Renderer overlayARenderer;

	private Renderer overlayBRenderer;

	private Renderer fillSVARenderer;

	private Renderer fillSVBRenderer;

	private Renderer fillSVCorridorRenderer;

	private bool isPartiallyClosed;

	private bool isPartiallyOpen;

	private bool isDisconnecting;

	private bool isExplored;

	private bool isBlinking;

	private bool isBlinkingAirlockSeal;

	private float timerRetry;

	private float timerAnimate;

	private int pryAttemptPass;

	private bool recentlyPowered;

	private float timerRecentlyPoweredCheck;

	private AudioSource asRDoorOpen;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public string LabelSimple { get; set; }

	public bool IsHorizontal { get; set; }

	public bool IsTryingToClose { get; set; }

	public bool IsTryingToOpen { get; private set; }

	public bool IsDisconnected { get; private set; }

	public Corridor corridor { get; private set; }

	public GameObject fillSVA { get; private set; }

	public GameObject fillSVB { get; private set; }

	public GameObject fillSVCorridor { get; private set; }

	public bool onSchematic
	{
		get
		{
			if (corridor != null)
			{
				return corridor.onSchematic;
			}
			return false;
		}
	}

	public Vector3 Position
	{
		get
		{
			return sliderA.transform.position;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return sliderA.GetComponent<Collider>();
		}
	}

	public bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden
	{
		get
		{
			return false;
		}
	}

	public Room CurrentRoom { get; set; }

	public Corridor CurrentCorridor { get; set; }

	public float CurrentHitPoints
	{
		get
		{
			return currentHitPoints;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return TOTAL_HITPOINTS;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsDead
	{
		get
		{
			return isDead;
		}
	}

	public bool IsStunned { get; private set; }

	public Vector3 StunPosition { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	private void Awake()
	{
		AddSoundSources();
		sliderARenderer = sliderA.GetComponent<Renderer>();
		sliderBRenderer = sliderB.GetComponent<Renderer>();
	}

	private void Start()
	{
		corridor = (Corridor)base.transform.parent.GetComponent(typeof(Corridor));
		Transform transform = sliderA.FindChild("Overlay");
		if (transform != null)
		{
			overlayA = transform.gameObject;
			overlayARenderer = overlayA.GetComponent<Renderer>();
			transform = null;
		}
		transform = sliderB.FindChild("Overlay");
		if (transform != null)
		{
			overlayB = transform.gameObject;
			overlayBRenderer = overlayB.GetComponent<Renderer>();
		}
		if (DungeonManager.Instance != null)
		{
			if (overlayARenderer != null)
			{
				overlayARenderer.material.color = ((corridor == null || !corridor.IsAirlock) ? ((!powered) ? DungeonManager.Instance.DVUnPoweredDoor : DungeonManager.Instance.DVPoweredDoor) : ((!powered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
			}
			if (overlayBRenderer != null)
			{
				overlayBRenderer.material.color = ((corridor == null || !corridor.IsAirlock) ? ((!powered) ? DungeonManager.Instance.DVUnPoweredDoor : DungeonManager.Instance.DVPoweredDoor) : ((!powered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
			}
		}
		transform = sliderA.FindChild("SVPanelFill");
		if (transform != null)
		{
			fillSVA = transform.gameObject;
			fillSVARenderer = fillSVA.GetComponent<Renderer>();
			fillSVARenderer.enabled = false;
			fillSVARenderer.material = corridor.dottedOutline;
		}
		transform = sliderB.FindChild("SVPanelFill");
		if (transform != null)
		{
			fillSVB = transform.gameObject;
			fillSVBRenderer = fillSVB.GetComponent<Renderer>();
			fillSVBRenderer.enabled = false;
			fillSVBRenderer.material = corridor.dottedOutline;
		}
		transform = base.transform.parent.FindChild("SVCorridorFill");
		if (transform != null)
		{
			fillSVCorridor = transform.gameObject;
			fillSVCorridorRenderer = fillSVCorridor.GetComponent<Renderer>();
			fillSVCorridorRenderer.enabled = false;
		}
		RefreshSchematicColor();
		corridor.RefreshColors();
		if (state == DoorState.Open)
		{
			return;
		}
		int num = tiles.Length;
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = tiles[i];
			if (gameObject.activeSelf)
			{
				gameObject.SetActive(false);
			}
		}
	}

	private void OnDestroy()
	{
		if (tiles != null)
		{
			int num = tiles.Length;
			for (int i = 0; i < num; i++)
			{
				tiles[i] = null;
			}
			tiles = null;
		}
		overlayA = null;
		overlayB = null;
		fillSVA = null;
		fillSVB = null;
		fillSVCorridor = null;
		sliderARenderer = null;
		sliderBRenderer = null;
		overlayARenderer = null;
		overlayBRenderer = null;
		fillSVARenderer = null;
		fillSVBRenderer = null;
		fillSVCorridorRenderer = null;
	}

	private void Update()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (_blinkManager.IsActive || _blinkManagerDroneView.IsActive)
		{
			bool flag = false;
			Color color;
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				color = _blinkManagerDroneView.Update(Time.deltaTime);
				if (isBlinking)
				{
					flag = true;
					if (_blinkManager != null)
					{
						_blinkManager.Update(Time.deltaTime);
					}
				}
			}
			else
			{
				color = _blinkManager.Update(Time.deltaTime);
				if (isBlinking)
				{
					if (!_blinkManager.IsActive)
					{
						isBlinking = false;
						flag = true;
					}
					if (_blinkManagerDroneView != null)
					{
						_blinkManagerDroneView.Update(Time.deltaTime);
					}
				}
			}
			if (!flag)
			{
				if (IsDead)
				{
					color = DeadColor;
				}
				else if (IsDisconnected)
				{
					color = DisconnectedColor;
				}
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					sliderARenderer.material.color = color;
					sliderBRenderer.material.color = color;
					fillSVARenderer.material.color = color;
					fillSVBRenderer.material.color = color;
					corridor.labelTextObject.color = color;
				}
				if (overlayA != null)
				{
					overlayARenderer.material.color = color;
				}
				if (overlayB != null)
				{
					overlayBRenderer.material.color = color;
				}
			}
			else
			{
				ForceSetDoorColorsRegardlessOfView();
			}
		}
		else if (recentlyPowered)
		{
			timerRecentlyPoweredCheck -= Time.deltaTime;
			if (timerRecentlyPoweredCheck <= 0f)
			{
				recentlyPowered = false;
				ForceSetDoorColorsRegardlessOfView();
			}
		}
		if (isDisconnecting)
		{
			timerAnimate -= Time.deltaTime;
			if (timerAnimate <= 0f)
			{
				power(false);
				swichCameraView();
				IsDisconnected = true;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					sliderARenderer.material.color = DisconnectedColor;
					sliderBRenderer.material.color = DisconnectedColor;
				}
				if (overlayA != null)
				{
					overlayARenderer.material.color = DisconnectedColor;
				}
				if (overlayB != null)
				{
					overlayBRenderer.material.color = DisconnectedColor;
				}
				isDisconnecting = false;
				timerAnimate = 0f;
				_blinkManager.Stop();
				_blinkManagerDroneView.Stop();
				ForceSetDoorColorsRegardlessOfView();
			}
		}
		else if (IsTryingToClose)
		{
			if (IsDead)
			{
				IsTryingToClose = false;
				timerRetry = 0f;
				return;
			}
			if (isPartiallyClosed)
			{
				timerAnimate -= Time.deltaTime;
				if (timerAnimate <= 0f)
				{
					Reopen();
				}
			}
			timerRetry -= Time.deltaTime;
			if (timerRetry <= 0f)
			{
				if (!powered)
				{
					IsTryingToClose = false;
					timerRetry = 0f;
				}
				else if (!IsCorridorBlocked())
				{
					CloseDoor();
					IsTryingToClose = false;
					timerRetry = 0f;
					GameplayManager.ShowConsoleMessage(string.Format("Door {0} closed...", Label), ConsoleMessageType.Healthy);
				}
				else
				{
					PartiallyCloseDoor();
					timerRetry = CloseRetryDelay;
				}
			}
		}
		else
		{
			if (!IsTryingToOpen)
			{
				return;
			}
			if (isPartiallyOpen)
			{
				timerAnimate -= Time.deltaTime;
				if (timerAnimate <= 0f)
				{
					Reclose(pryAttemptPass);
					pryAttemptPass++;
					if (pryAttemptPass >= 3)
					{
						pryAttemptPass = 0;
						IsTryingToOpen = false;
						open(true, false);
					}
					else
					{
						timerRetry = 0.1f;
					}
				}
			}
			else
			{
				timerRetry -= Time.deltaTime;
				if (timerRetry <= 0f)
				{
					PryOpen();
					timerRetry = 0f;
				}
			}
		}
	}

	public void CameraChanged()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (fillSVA != null)
			{
				fillSVARenderer.enabled = false;
				fillSVBRenderer.enabled = false;
				fillSVCorridorRenderer.enabled = false;
			}
		}
		else if (fillSVA != null)
		{
			if (onSchematic)
			{
				fillSVARenderer.enabled = true;
				fillSVBRenderer.enabled = true;
			}
			if (state == DoorState.Open && isExplored)
			{
				fillSVCorridorRenderer.enabled = true;
			}
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public bool open()
	{
		return open(true, true);
	}

	public bool open(bool respectDeadState)
	{
		return open(respectDeadState, true);
	}

	public bool open(bool respectDeadState, bool respectDisconnectedState)
	{
		if (respectDisconnectedState && IsDisconnected)
		{
			return false;
		}
		bool flag = state == DoorState.Closed;
		if (isDead && respectDeadState)
		{
			flag = false;
		}
		else if (BoardingShip.Instance.IsRedockingShip && corridor != null && corridor.IsAirlock && BoardingShip.Instance.destinationAirlock != null && BoardingShip.Instance.destinationAirlock.door == this)
		{
			flag = false;
			ConsoleWindow3.SendConsoleResponse(string.Format("ship currently docking to <{0}>, open command not allowed", BoardingShip.Instance.destinationAirlock.door.Label), ConsoleMessageType.Warning);
		}
		if (flag)
		{
			int num = tiles.Length;
			if (onSchematic)
			{
				for (int i = 0; i < num; i++)
				{
					tiles[i].SetActive(true);
				}
			}
			sliderA.transform.Translate(0f, 1f, 0f);
			sliderB.transform.Translate(0f, -1f, 0f);
			state = DoorState.Open;
			if (GlobalSettings.cameraMode == CameraMode.Schematic && onSchematic && fillSVCorridor != null)
			{
				fillSVCorridorRenderer.enabled = true;
			}
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				asRDoorOpen.Play();
			}
			if (corridor != null)
			{
				if (corridor.IsAirlock)
				{
					if (AirlockOpenedEvent != null)
					{
						AirlockOpenedEvent(this);
					}
					if (BoardingShip.Instance.isExecutingPandemicQuarentineObjective)
					{
						BoardingShip.Instance.EndPandemicQuarantineObjective();
					}
				}
				else if (DoorOpenedEvent != null)
				{
					DoorOpenedEvent(this);
				}
			}
		}
		EventManager.Instance.Publish(GeneralEventType.DoorOpened, new GeneralEventArgs(this));
		return true;
	}

	public bool close()
	{
		return close(true);
	}

	public bool close(bool respectDeadState)
	{
		if (IsDisconnected)
		{
			return false;
		}
		bool flag = state == DoorState.Open;
		if (respectDeadState && IsDead)
		{
			flag = false;
		}
		if (flag)
		{
			if (IsCorridorBlocked())
			{
				PartiallyCloseDoor();
				IsTryingToClose = true;
				timerRetry = CloseRetryDelay;
				SystemMessageManager.ShowSystemMessage(string.Format("Door {0} is blocked", Label), ConsoleMessageType.Warning);
				return false;
			}
			CloseDoor();
		}
		return true;
	}

	public void PryOpen()
	{
		IsTryingToOpen = true;
		timerAnimate = 0.2f;
		PartiallyOpenDoor(pryAttemptPass);
	}

	public void WeldClosed()
	{
		power(false);
		isDead = true;
		currentHitPoints = 0f;
		sliderARenderer.material.color = Color.gray;
		sliderBRenderer.material.color = Color.gray;
		corridor.isWelded = true;
		corridor.droneUIObject.UIObjects[2].GetComponent<Text>().color = Color.gray;
		corridor.RefreshColors();
		ForceSetDoorColorsRegardlessOfView();
	}

	public void DisconnectDoor()
	{
		isDisconnecting = true;
		timerAnimate = 1f;
		_blinkManager.Start(DisconnectedColor, sliderARenderer.material.color, 0.1f);
		_blinkManagerDroneView.Start(DisconnectedColor, overlayARenderer.material.color, 0.1f);
	}

	private void Reopen()
	{
		sliderA.transform.Translate(0f, 0.2f, 0f);
		sliderB.transform.Translate(0f, -0.2f, 0f);
		isPartiallyClosed = false;
		timerAnimate = 0f;
	}

	private void Reclose(int distFactor)
	{
		switch (distFactor)
		{
		case 0:
			sliderA.transform.Translate(0f, -0.1f, 0f);
			sliderB.transform.Translate(0f, 0.1f, 0f);
			break;
		case 1:
			sliderA.transform.Translate(0f, -0.2f, 0f);
			sliderB.transform.Translate(0f, 0.2f, 0f);
			break;
		case 2:
			sliderA.transform.Translate(0f, -0.3f, 0f);
			sliderB.transform.Translate(0f, 0.3f, 0f);
			break;
		}
		isPartiallyOpen = false;
		timerAnimate = 0f;
	}

	private void PartiallyCloseDoor()
	{
		sliderA.transform.Translate(0f, -0.2f, 0f);
		sliderB.transform.Translate(0f, 0.2f, 0f);
		isPartiallyClosed = true;
		timerAnimate = 0.2f;
	}

	private void PartiallyOpenDoor(int distFactor)
	{
		switch (distFactor)
		{
		case 0:
			sliderA.transform.Translate(0f, 0.1f, 0f);
			sliderB.transform.Translate(0f, -0.1f, 0f);
			break;
		case 1:
			sliderA.transform.Translate(0f, 0.2f, 0f);
			sliderB.transform.Translate(0f, -0.2f, 0f);
			break;
		case 2:
			sliderA.transform.Translate(0f, 0.3f, 0f);
			sliderB.transform.Translate(0f, -0.3f, 0f);
			break;
		}
		isPartiallyOpen = true;
		timerAnimate = 0.2f;
	}

	private void CloseDoor()
	{
		GameObject[] array = tiles;
		foreach (GameObject gameObject in array)
		{
			gameObject.SetActive(false);
		}
		sliderA.transform.Translate(0f, -1f, 0f);
		sliderB.transform.Translate(0f, 1f, 0f);
		state = DoorState.Closed;
		if (fillSVCorridor != null)
		{
			fillSVCorridorRenderer.enabled = false;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			asRDoorOpen.Play();
		}
		if (corridor.IsAirlock)
		{
			if (AirlockClosedEvent != null)
			{
				AirlockClosedEvent(this);
			}
			if (!(BoardingShip.Instance.CurrentAirlock == corridor) || !GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsQuarentined)
			{
				return;
			}
			bool flag = false;
			bool isSecondaryScan = false;
			if (LogManager.LogDataFile.GetValue("pandemic", "stepB", 0) != 3 && ObjectiveManual.IsObjectiveStepActive("pandemic", "stepB"))
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			bool flag2 = false;
			int count = EnemyManager.Instance.Enemies.Count;
			int num = 0;
			for (int j = 0; j < count; j++)
			{
				BaseEnemy baseEnemy = EnemyManager.Instance.Enemies[j];
				if (baseEnemy.CurrentRoom.boardingVessel)
				{
					if (baseEnemy is SwarmEnemy || baseEnemy is BruteEnemy)
					{
						flag2 = true;
						break;
					}
					num++;
				}
			}
			if (flag2)
			{
				BoardingShip.Instance.BeginPandemicQuarantineObjective(isSecondaryScan);
			}
			else if (num > 0)
			{
				SystemMessageManager.ShowSystemMessage("///[JIL]: Holmes Scan halted: presence in docking bay non-organic", ConsoleMessageType.JIL_Warning);
			}
		}
		else if (DoorClosedEvent != null)
		{
			DoorClosedEvent(this);
		}
	}

	public void power(bool powerInput)
	{
		if (IsDead)
		{
			return;
		}
		if ((GlobalSettings.cameraMode == CameraMode.Drone || !isBlinking) && !isBlinkingAirlockSeal)
		{
			_blinkManager.Stop();
		}
		if (!isBlinkingAirlockSeal)
		{
			_blinkManagerDroneView.Stop();
		}
		ForceSetDoorColorsRegardlessOfView();
		powered = powerInput;
		RefreshSchematicColor();
		if (corridor != null && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (powered)
			{
				corridor.droneUIObject.SourceBlinkColorChanged(corridor.IsAirlock ? DungeonManager.Instance.DVPoweredAirlock : DungeonManager.Instance.DVPoweredDoor, "SchematicLabel");
			}
			else
			{
				corridor.droneUIObject.SourceBlinkColorChanged(corridor.IsAirlock ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVUnPoweredDoor, "SchematicLabel");
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			ApplySchematicViewColor();
			return;
		}
		recentlyPowered = true;
		timerRecentlyPoweredCheck = 0.25f;
	}

	public void RefreshSchematicColor()
	{
		if (DungeonManager.Instance != null)
		{
			if (powered)
			{
				SchematicViewColor = ((!(corridor == null) && corridor.IsAirlock) ? DungeonManager.Instance.SVPoweredAirlock : DungeonManager.Instance.SVPoweredDoor);
			}
			else
			{
				SchematicViewColor = ((!(corridor == null) && corridor.IsAirlock) ? DungeonManager.Instance.SVUnPoweredAirlock : DungeonManager.Instance.SVUnPoweredDoor);
			}
		}
	}

	public void hide(bool hide)
	{
		if (hide)
		{
			sliderARenderer.enabled = false;
			sliderBRenderer.enabled = false;
			if (fillSVA != null)
			{
				fillSVARenderer.enabled = false;
				fillSVBRenderer.enabled = false;
				fillSVCorridorRenderer.enabled = false;
			}
			return;
		}
		if (!isExplored)
		{
			isExplored = true;
			if (!isBlinking)
			{
				isBlinking = true;
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					_blinkManagerDroneView = new ColorBlinkManager();
					_blinkManagerDroneView.OnBlinkDone += BlinkDoneDV;
					Color white = Color.white;
					white = ((!corridor.IsAirlock) ? DungeonManager.Instance.DVUnPoweredDoor : ((!powered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
					_blinkManagerDroneView.Start(white, Color.black, 0.2f, 3);
				}
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			sliderARenderer.enabled = true;
			sliderBRenderer.enabled = true;
		}
		else if (fillSVA != null)
		{
			fillSVARenderer.enabled = true;
			fillSVBRenderer.enabled = true;
			if (state == DoorState.Open)
			{
				fillSVCorridorRenderer.enabled = true;
			}
		}
		if (corridor != null && !corridor.IsVisible)
		{
			corridor.SetVisible(null);
		}
	}

	private void BlinkDoneDV()
	{
		_blinkManagerDroneView.OnBlinkDone -= BlinkDoneDV;
		RefreshSchematicColor();
		ForceSetDoorColorsRegardlessOfView();
		isBlinking = false;
	}

	private void BlinkDoneSV()
	{
		_blinkManager.OnBlinkDone -= BlinkDoneSV;
		RefreshSchematicColor();
		ForceSetDoorColorsRegardlessOfView();
		isBlinking = false;
	}

	public void swichCameraView()
	{
		if (IsDead || IsDisconnected)
		{
			if (IsDead && corridor != null && corridor.isWelded)
			{
				ForceSetDoorColorsRegardlessOfView();
			}
			return;
		}
		if ((GlobalSettings.cameraMode == CameraMode.Drone || !isBlinking) && !isBlinkingAirlockSeal)
		{
			_blinkManager.Stop();
		}
		if (!isBlinkingAirlockSeal)
		{
			_blinkManagerDroneView.Stop();
		}
		ForceSetDoorColorsRegardlessOfView();
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			Color color = ((corridor == null || !corridor.IsAirlock) ? ((!powered) ? DungeonManager.Instance.DVUnPoweredDoor : DungeonManager.Instance.DVPoweredDoor) : ((!powered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
			if (overlayA != null)
			{
				overlayARenderer.material.color = color;
			}
			if (overlayB != null)
			{
				overlayBRenderer.material.color = color;
			}
		}
		else
		{
			ApplySchematicViewColor();
		}
	}

	private void ApplySchematicViewColor()
	{
		if (IsDead || IsDisconnected)
		{
			return;
		}
		if (!isBlinking || GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (!isBlinkingAirlockSeal)
			{
				_blinkManager.Stop();
			}
			isBlinking = false;
		}
		if (!isBlinking || GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			if (!isBlinkingAirlockSeal)
			{
				_blinkManagerDroneView.Stop();
			}
			isBlinking = false;
		}
		ForceSetDoorColorsRegardlessOfView();
		if (!isBlinking)
		{
			sliderARenderer.material.color = SchematicViewColor;
			sliderBRenderer.material.color = SchematicViewColor;
		}
	}

	public void ForceSetDoorColorsRegardlessOfView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			Color color = ((corridor == null || !corridor.IsAirlock) ? ((!powered) ? DungeonManager.Instance.DVUnPoweredDoor : DungeonManager.Instance.DVPoweredDoor) : ((!powered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
			if (IsDead)
			{
				color = DeadColor;
			}
			else if (IsDisconnected)
			{
				color = DisconnectedColor;
			}
			if (corridor != null && corridor.isWelded)
			{
				color = DungeonManager.Instance.DVWeldedDoor;
				corridor.droneUIObject.UIObjects[2].GetComponent<Text>().color = Color.gray;
			}
			if (overlayA != null)
			{
				overlayARenderer.material.color = color;
			}
			if (overlayB != null)
			{
				overlayBRenderer.material.color = color;
			}
		}
		else if (!IsDead)
		{
			if (!isBlinking)
			{
				if (!IsDisconnected)
				{
					sliderARenderer.material.color = SchematicViewColor;
					sliderBRenderer.material.color = SchematicViewColor;
					return;
				}
				sliderARenderer.material.color = DisconnectedColor;
				sliderBRenderer.material.color = DisconnectedColor;
				fillSVARenderer.material.color = DisconnectedColor;
				fillSVBRenderer.material.color = DisconnectedColor;
				corridor.labelTextObject.color = DisconnectedColor;
			}
		}
		else
		{
			Color color2 = DeadColor;
			if (corridor != null && corridor.isWelded)
			{
				color2 = DungeonManager.Instance.SVWeldedDoor;
			}
			sliderARenderer.material.color = color2;
			sliderBRenderer.material.color = color2;
			fillSVARenderer.material.color = color2;
			fillSVBRenderer.material.color = color2;
			corridor.labelTextObject.color = color2;
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (IsDead)
		{
			return;
		}
		currentHitPoints -= damage;
		if (currentHitPoints <= 0f)
		{
			currentHitPoints = 0f;
			isDead = true;
			if (type != DamageType.Impact)
			{
				open(false);
			}
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				sliderARenderer.material.color = DeadColor;
				sliderBRenderer.material.color = DeadColor;
			}
			overlayARenderer.material.color = DeadColor;
			overlayBRenderer.material.color = DeadColor;
			if (onSchematic || GlobalSettings.cheatMode)
			{
				if (corridor.IsAirlock)
				{
					SystemMessageManager.ShowSystemMessage(string.Format("Airlock {0} has been destroyed", Label), ConsoleMessageType.Warning);
				}
				else
				{
					SystemMessageManager.ShowSystemMessage(string.Format("Door {0} has been destroyed", Label), ConsoleMessageType.Warning);
				}
			}
		}
		else if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			_blinkManagerDroneView.Start(overlayARenderer.material.color, Color.red, 0.2f, 2);
		}
		else
		{
			_blinkManager.Start(sliderARenderer.material.color, Color.red, 0.2f, 2);
		}
	}

	public void BeginSealFailureVisual()
	{
		_blinkManagerDroneView.Start(overlayARenderer.material.color, Color.red, 0.2f);
		_blinkManager.Start(sliderARenderer.material.color, Color.red, 0.2f);
		isBlinkingAirlockSeal = true;
	}

	public void EndSealFailureVisual()
	{
		_blinkManagerDroneView.Stop();
		_blinkManager.Stop();
		isBlinkingAirlockSeal = false;
	}

	public void Stun(float durationMin, float durationMax)
	{
	}

	public void ClearStun()
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	private bool IsCorridorBlocked()
	{
		DroneManager instance = DroneManager.Instance;
		if (instance != null)
		{
			foreach (Drone drones in instance.dronesList)
			{
				if (drones.CurrentCorridor == corridor)
				{
					return true;
				}
				if (corridor.rooms.Contains(drones.CurrentRoom) && corridor.GetComponent<Collider>().bounds.Intersects(drones.GetComponent<Collider>().bounds))
				{
					return true;
				}
			}
			foreach (Drone lootableDrones in instance.LootableDronesList)
			{
				if (lootableDrones.CurrentCorridor == corridor)
				{
					return true;
				}
				if (corridor.rooms.Contains(lootableDrones.CurrentRoom) && corridor.GetComponent<Collider>().bounds.Intersects(lootableDrones.GetComponent<Collider>().bounds))
				{
					return true;
				}
			}
			if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.Probe))
			{
				foreach (DropableItem item in DroneItemDropper.DroppedItemDict[DropItemType.Probe])
				{
					ProbeItem probeItem = (ProbeItem)item;
					if (probeItem != null && corridor.GetComponent<Collider>().bounds.Intersects(probeItem.GetComponent<Collider>().bounds))
					{
						return true;
					}
				}
			}
		}
		EnemyManager instance2 = EnemyManager.Instance;
		if (instance2 != null)
		{
			foreach (BaseEnemy enemy in instance2.Enemies)
			{
				if (enemy.GetType() == typeof(SlimeEnemy))
				{
					continue;
				}
				if (enemy.CurrentCorridor == corridor)
				{
					return true;
				}
				if (enemy.GetType() == typeof(SwarmEnemy) && corridor.rooms.Contains(enemy.CurrentRoom))
				{
					Bounds bounds = enemy.GetComponent<Collider>().bounds;
					bounds.Expand(new Vector3(1f, 1f, 1f));
					if (corridor.GetComponent<Collider>().bounds.Intersects(bounds))
					{
						return true;
					}
				}
				else if (corridor.rooms.Contains(enemy.CurrentRoom))
				{
					Bounds bounds2 = enemy.GetComponent<Collider>().bounds;
					if (corridor.GetComponent<Collider>().bounds.Intersects(bounds2))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public override string ToString()
	{
		return "Door " + Label;
	}

	private void AddSoundSources()
	{
		asRDoorOpen = base.gameObject.AddComponent<AudioSource>();
		asRDoorOpen.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_DoorOpen);
		asRDoorOpen.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_DoorOpen, GameAudio.RemoteVolume);
		asRDoorOpen.playOnAwake = false;
		asRDoorOpen.spatialBlend = 1f;
	}
}
