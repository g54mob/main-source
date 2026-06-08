using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonPowerInlet : RoomItem, IBreakable, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation, IOverlayCommunication
{
	public delegate void PowerChange();

	public static bool hasShownNavigateHintAtLeastOnce;

	public static bool hasShownMotionHintAtLeastOnce;

	public static bool hasTestedDestroyedAIState;

	private static bool hasCheckedDisconnectWarning;

	public PowerChange poweredDown;

	public bool powered;

	public List<Room> rooms;

	public Material ActivatedMaterial;

	private Material originalMaterial;

	private AudioSource asRGenerator;

	private bool isRGeneratorPaused;

	private bool isRampingGeneratorSoundIn;

	private bool isRampingGeneratorSoundOut;

	private float generatorNormalPitch;

	private float timerRamp;

	private Drone poweringDrone;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override string ItemName
	{
		get
		{
			return "Power Inlet";
		}
	}

	public int RoomCount { get; private set; }

	protected override HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.PowerInlet;
		}
	}

	public override bool Powered
	{
		get
		{
			return powered;
		}
	}

	public override bool Explored
	{
		get
		{
			return base.roomLocation.isScanned || base.roomLocation.isExplored;
		}
	}

	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
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

	public float CurrentHitPoints { get; private set; }

	public float TotalHitpoints
	{
		get
		{
			return 100f;
		}
	}

	public float TimeStunned { get; private set; }

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

	public BrokenStateEnum BrokenState
	{
		get
		{
			if (CurrentHitPoints == TotalHitpoints)
			{
				return BrokenStateEnum.OK;
			}
			if (CurrentHitPoints > 0f)
			{
				return BrokenStateEnum.ErrorsDetected;
			}
			return BrokenStateEnum.Broken;
		}
	}

	public string RepairId
	{
		get
		{
			return "power";
		}
	}

	virtual bool IHasHitpoints.IsDead
	{
		get
		{
			return base.IsDead;
		}
	}

	public override void Start()
	{
		base.Start();
		CurrentHitPoints = TotalHitpoints;
		Transform transform = base.transform.parent.Find("DroneUI");
		if (transform != null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
			droneUIObject.AddInfoCommand("generator");
			droneUIObject.parentObject = base.gameObject;
			if (!GameSaveFile.Get("HNT_SU_RMT", false) || !GameSaveFile.Get("HNT_SU_RRT", false))
			{
				droneUIObject.objectBecameVisible += BecameVisible;
			}
		}
		transform = base.transform.parent.Find("DVOverlay");
		if (transform != null)
		{
			dvOverlayObject = transform.gameObject;
		}
		transform = base.transform.parent.Find("SVOverlay");
		if (transform != null)
		{
			svOverlayObject = transform.gameObject;
		}
		transform = base.transform.parent.Find("DVStatusOverlay");
		if (transform != null)
		{
			dvStatusOverlay = transform.gameObject;
			dvStatusOverlay.GetComponent<Renderer>().enabled = false;
		}
		originalMaterial = itemRenderer.material;
		if (dvOverlayObject != null)
		{
			if (!dvOverlayObjectMat)
			{
				dvOverlayObjectMat = dvOverlayObject.GetComponent<Renderer>().material;
			}
			dvOverlayObjectMat.color = InactiveColor;
		}
		if (svOverlayObject != null)
		{
			if (!svOverlayObjectMat)
			{
				svOverlayObjectMat = svOverlayObject.GetComponent<Renderer>().material;
			}
			svOverlayObjectMat.color = InactiveColor;
		}
		RoomCount = rooms.Count;
		AddSoundSources();
	}

	private new void OnDestroy()
	{
		RemoveSoundSources();
	}

	public override void PowerUp(Drone drone)
	{
		if (base.IsDead)
		{
			return;
		}
		if (drone != null)
		{
			if (asRGenerator == null)
			{
				asRGenerator = drone.gameObject.AddComponent<AudioSource>();
				generatorNormalPitch = asRGenerator.pitch;
				asRGenerator.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_Generator);
				asRGenerator.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_Generator, GameAudio.RemoteVolume);
				asRGenerator.playOnAwake = false;
				asRGenerator.loop = true;
				asRGenerator.spatialBlend = 1f;
			}
			isRampingGeneratorSoundIn = true;
			if (!isRampingGeneratorSoundOut)
			{
				timerRamp = 0f;
			}
			else
			{
				isRampingGeneratorSoundOut = false;
			}
			asRGenerator.pitch = timerRamp;
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				asRGenerator.Play();
			}
		}
		poweringDrone = drone;
		powered = true;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			dvStatusOverlay.GetComponent<Renderer>().enabled = true;
			statusOverlayBlinkManager = new ColorBlinkManager();
			statusOverlayBlinkManager.Start(ActiveColor, Color.black, 0.1f, 10, false);
		}
		if (ActivatedMaterial != null)
		{
			itemRenderer.material = ActivatedMaterial;
		}
		if (dvOverlayObject != null)
		{
			dvOverlayObjectMat.color = ActiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObjectMat.color = ActiveColor;
		}
		dungeonManager.UpdateCameraView();
		int count = rooms.Count;
		for (int i = 0; i < count; i++)
		{
			Room room = rooms[i];
			if (room != null)
			{
				room.power(this, powered);
			}
		}
		if (!hasShownMotionHintAtLeastOnce && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationTypeCountValue > 0)
		{
			if (!GameSaveFile.Get("HNT_MOTION", false))
			{
				bool flag = false;
				foreach (Drone drones in DroneManager.Instance.dronesList)
				{
					if (!(drones != null) || drones.IsDead || drones.BrokenState == BrokenStateEnum.Broken)
					{
						continue;
					}
					foreach (BaseDroneUpgrade upgrade in drones.Upgrades)
					{
						if (upgrade != null && !upgrade.IsBroken && upgrade.GetType() == typeof(AreaSensorUpgrade))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					hasShownMotionHintAtLeastOnce = true;
					HintManager.PushHint(new MotionHint());
				}
			}
		}
		else
		{
			hasShownMotionHintAtLeastOnce = true;
		}
		if (!hasShownNavigateHintAtLeastOnce && GameSaveFile.Get("MISSIONS", 0) > 1 && HintManager.currentHint == null)
		{
			if (!Drone.NagivateHintNotNeeded && !GameSaveFile.Get("HNT_NAVIGATE", false))
			{
				List<Drone> list = null;
				bool flag2 = false;
				bool flag3 = false;
				foreach (Drone drones2 in DroneManager.Instance.dronesList)
				{
					if (drones2.IsDead || drones2.BrokenState == BrokenStateEnum.ErrorsDetected || !(drones2.CurrentRoom != null))
					{
						continue;
					}
					foreach (Corridor corridor in drones2.CurrentRoom.corridors)
					{
						Room otherRoom = corridor.getOtherRoom(drones2.CurrentRoom);
						if (otherRoom != null && otherRoom.isExplored && !otherRoom.boardingVessel && corridor.door != null && corridor.door.state == DoorState.Open)
						{
							if (list == null)
							{
								list = new List<Drone>();
							}
							if (!list.Contains(drones2))
							{
								list.Add(drones2);
							}
							if (drones2.CurrentRoom.boardingVessel)
							{
								flag3 = true;
							}
							else
							{
								flag2 = true;
							}
						}
					}
				}
				if (list != null)
				{
					if (list.Count > 1 && list.Contains(drone))
					{
						list.Remove(drone);
					}
					if (flag3)
					{
						count = list.Count;
						for (int num = count - 1; num >= 0; num--)
						{
							if (list[num].CurrentRoom.boardingVessel)
							{
								list.RemoveAt(num);
							}
						}
						if (list.Count == 0)
						{
							list.Add(drone);
						}
					}
					int index = UnityEngine.Random.Range(0, list.Count);
					Drone drone2 = list[index];
					List<Corridor> list2 = new List<Corridor>();
					if (drone2 != null)
					{
						for (int j = 0; j < 2; j++)
						{
							foreach (Corridor corridor2 in drone2.CurrentRoom.corridors)
							{
								if (!(corridor2.door != null) || corridor2.door.state != DoorState.Open || corridor2.IsAirlock)
								{
									continue;
								}
								Room otherRoom2 = corridor2.getOtherRoom(drone2.CurrentRoom);
								if (otherRoom2 != drone2.CurrentRoom)
								{
									if (j == 0 && otherRoom2.isExplored && !otherRoom2.hasDroneEverEnteredRoom)
									{
										list2.Add(corridor2);
									}
									else if (j == 1 && otherRoom2.isExplored && otherRoom2.hasDroneEverEnteredRoom)
									{
										list2.Add(corridor2);
									}
								}
							}
							if (j == 0 && list2.Count > 0)
							{
								break;
							}
						}
					}
					if (list2.Count > 0)
					{
						index = UnityEngine.Random.Range(0, list2.Count);
						Room otherRoom3 = list2[index].getOtherRoom(drone2.CurrentRoom);
						HintManager.PushHint(new NavigateHint(string.Format("{0} {1}", drone2.DroneNumber, otherRoom3.Label)));
						hasShownNavigateHintAtLeastOnce = true;
					}
				}
			}
			else
			{
				hasShownNavigateHintAtLeastOnce = true;
			}
		}
		if (!hasTestedDestroyedAIState && !GlobalSettings.IsTutorial && GlobalSettings.GameStartedFromGalaxyMap)
		{
			if (ObjectiveManual.IsObjectiveStepActive("singularity", "stepD") && GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "AI", 0) == 3)
			{
				SystemMessageManager.ShowSystemMessage("///[JIL]: ORACLE archive destroyed by MUTEKI security procedure", ConsoleMessageType.JIL_Error);
			}
			hasTestedDestroyedAIState = true;
		}
	}

	public override void PowerDown(Drone drone)
	{
		if (asRGenerator != null)
		{
			isRampingGeneratorSoundOut = true;
			if (!isRampingGeneratorSoundIn)
			{
				timerRamp = 1f;
			}
			else
			{
				isRampingGeneratorSoundIn = false;
			}
		}
		powered = false;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			dvStatusOverlay.GetComponent<Renderer>().enabled = true;
			statusOverlayBlinkManager = new ColorBlinkManager();
			statusOverlayBlinkManager.Start(Color.red, Color.black, 0.1f, 10, false);
		}
		itemRenderer.material = originalMaterial;
		if (dvOverlayObject != null)
		{
			dvOverlayObjectMat.color = InactiveColor;
		}
		if (svOverlayObject != null)
		{
			svOverlayObjectMat.color = InactiveColor;
		}
		foreach (Room room in rooms)
		{
			if (room != null)
			{
				room.power(this, powered);
			}
		}
		dungeonManager.UpdateCameraView();
		if (GlobalSettings.gameMode == GameModeEnum.Normal && !hasCheckedDisconnectWarning && drone != null && drone.brain != null && drone.brain.CurrentState != "NavigatingPath" && !GlobalSettings.CommandeeringShip)
		{
			if (!GlobalSettings.IsTutorial && !GameSaveFile.Get("WS_DIS_GEN", false) && !GameSaveFile.Get("HNT_DISABLE", false))
			{
				DialogUI.Instance.ShowDialog("Tip!", "Your generator has disconnected from the power inlet because the drone is too far away.", ModalWindowType.OK, delegate
				{
					DungeonManager.Instance.DisableAllInputForAMoment();
				});
				GameSaveFile.Save("WS_DIS_GEN", true);
			}
			hasCheckedDisconnectWarning = true;
		}
		if (drone == null && poweringDrone != null)
		{
			foreach (BaseDroneUpgrade upgrade in poweringDrone.Upgrades)
			{
				if (upgrade != null && upgrade is GeneratorUpgrade)
				{
					((GeneratorUpgrade)upgrade).CancelAbility();
				}
			}
		}
		poweringDrone = null;
		if (poweredDown != null)
		{
			poweredDown();
		}
	}

	public void ClearRooms()
	{
		int count = rooms.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (rooms[num] != base.roomLocation)
			{
				if (rooms[num] != null && rooms[num].isPowered)
				{
					rooms[num].power(this, false);
				}
				rooms.RemoveAt(num);
			}
		}
	}

	public bool PowerDownRoom(Room room)
	{
		if (rooms.Contains(room))
		{
			room.power(this, false);
			rooms.Remove(room);
			PowerDownAdjacentRooms(room);
			return true;
		}
		return false;
	}

	public bool PowerUpRoom(Room room)
	{
		if (rooms.Contains(room))
		{
			room.power(this, true);
			return true;
		}
		List<Room> adjacentRooms = room.getAdjacentRooms();
		foreach (Room item in adjacentRooms)
		{
			if (item != null && item.currentPowerSourceList.Contains(this))
			{
				rooms.Add(room);
				room.power(this, true);
				return true;
			}
		}
		return false;
	}

	private void PowerDownAdjacentRooms(Room disconnectedRoom)
	{
		List<Room> adjacentRooms = disconnectedRoom.getAdjacentRooms();
		int count = adjacentRooms.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			Room room = adjacentRooms[num];
			if (room != null && room != base.roomLocation && rooms.Contains(room) && room.isPowered)
			{
				bool flag = true;
				List<Room> adjacentRooms2 = room.getAdjacentRooms();
				foreach (Room item in adjacentRooms2)
				{
					if (item != null && room != base.roomLocation && item.isPowered && item != disconnectedRoom)
					{
						List<Room> consideredRoomList = new List<Room>();
						if (IsPoweredConnectedToRoom(item, ref consideredRoomList))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					PowerDownRoom(room);
					break;
				}
			}
		}
	}

	private bool IsPoweredConnectedToRoom(Room targetRoom, ref List<Room> consideredRoomList)
	{
		if (targetRoom == null)
		{
			return false;
		}
		List<Room> adjacentRooms = targetRoom.getAdjacentRooms();
		foreach (Room item in adjacentRooms)
		{
			if (item != null && !consideredRoomList.Contains(item))
			{
				consideredRoomList.Add(item);
				if (item == base.roomLocation)
				{
					return true;
				}
				if (item.isPowered && IsPoweredConnectedToRoom(item, ref consideredRoomList))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override void Update()
	{
		base.Update();
		if (GlobalSettings.IsGamePaused || base.IsDead)
		{
			return;
		}
		if (!IsInvisibleDueToToggle && gameplayManager != null && !gameplayManager.showSchematicToggleItems)
		{
			SetSchematicVisibility(gameplayManager.showSchematicToggleItems);
		}
		if (IsStunned)
		{
			TimeStunned -= Time.deltaTime;
			if (TimeStunned <= 0f)
			{
				ClearStun();
			}
		}
		if (asRGenerator != null && asRGenerator.isPlaying)
		{
			asRGenerator.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_Generator, GameAudio.RemoteVolume);
		}
		if (isRampingGeneratorSoundIn)
		{
			if (asRGenerator != null)
			{
				timerRamp += Time.deltaTime;
				if (timerRamp >= 1f)
				{
					isRampingGeneratorSoundIn = false;
					asRGenerator.pitch = generatorNormalPitch;
				}
				else
				{
					asRGenerator.pitch = timerRamp / 1f;
				}
			}
			else
			{
				isRampingGeneratorSoundIn = false;
			}
		}
		else
		{
			if (!isRampingGeneratorSoundOut)
			{
				return;
			}
			if (asRGenerator != null)
			{
				timerRamp -= Time.deltaTime;
				if (timerRamp <= 0f)
				{
					isRampingGeneratorSoundOut = false;
					asRGenerator.Stop();
					UnityEngine.Object.Destroy(asRGenerator);
				}
				else
				{
					asRGenerator.pitch = timerRamp / 1f;
				}
			}
			else
			{
				isRampingGeneratorSoundOut = false;
			}
		}
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			itemRenderer.enabled = show;
			base.transform.parent.GetComponent<Renderer>().enabled = show;
			ModelViewRefresh(show);
			return;
		}
		itemRenderer.enabled = false;
		base.transform.parent.GetComponent<Renderer>().enabled = false;
		ModelViewRefresh();
		if (statusOverlayBlinkManager != null)
		{
			statusOverlayBlinkManager = null;
			dvStatusOverlay.GetComponent<Renderer>().enabled = false;
		}
	}

	public void Stun(float durationMin, float durationMax)
	{
		if (base.IsDead)
		{
			return;
		}
		float num = UnityEngine.Random.Range(durationMin, durationMax);
		if (!IsStunned)
		{
			TimeStunned = num;
			PowerDown(null);
			if (StunMtl != null)
			{
				itemRenderer.material = StunMtl;
			}
			else
			{
				itemRenderer.material = baseMtl;
			}
			SystemMessageManager.ShowSystemMessage("Generator in Room " + base.roomLocation.Label + " stunned", ConsoleMessageType.Warning);
		}
		else
		{
			TimeStunned += num;
		}
		IsStunned = true;
	}

	public void ClearStun()
	{
		TimeStunned = 0f;
		IsStunned = false;
		if (!base.IsDead)
		{
			if (baseMtl != null)
			{
				itemRenderer.material = baseMtl;
			}
			GameplayManager.ShowConsoleMessage("Generator in Room " + base.roomLocation.Label + " working.", ConsoleMessageType.Benefit);
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (base.IsDead)
		{
			return;
		}
		CurrentHitPoints -= damage;
		if (CurrentHitPoints <= 0f)
		{
			CurrentHitPoints = 0f;
			if (Powered)
			{
				PowerDown(null);
			}
			base.IsDead = true;
			SetDead();
			SystemMessageManager.ShowSystemMessage("Generator in Room " + base.roomLocation.Label + " destroyed", ConsoleMessageType.Error);
			if (DeathMtl != null)
			{
				itemRenderer.material = DeathMtl;
			}
		}
		else
		{
			if (DamageMtl != null)
			{
				itemRenderer.material = DamageMtl;
			}
			SetDamaged();
			SystemMessageManager.ShowSystemMessage("Generator in Room " + base.roomLocation.Label + " damaged", ConsoleMessageType.Warning);
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	public void ReduceQuality()
	{
		TakeDamage(TotalHitpoints / 2f, DamageType.Physical, null);
	}

	public void Break()
	{
		TakeDamage(9999999f, DamageType.Physical, null);
	}

	public bool Fix(out string fixMessage)
	{
		fixMessage = string.Empty;
		if (base.IsDead)
		{
			base.IsDead = false;
			CurrentHitPoints = TotalHitpoints;
			itemRenderer.material = baseMtl;
			return true;
		}
		return false;
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
	}

	public Color GetBlinkColor(string overlayName)
	{
		Color result = Color.black;
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			result = ((!powered) ? InactiveColor : ActiveColor);
		}
		return result;
	}

	public void SwitchToRemoteSounds()
	{
		if (Powered && asRGenerator != null)
		{
			asRGenerator.Play();
		}
	}

	public void SwitchToSchematicSounds()
	{
		if (asRGenerator != null && asRGenerator.isPlaying)
		{
			asRGenerator.Stop();
		}
	}

	public void StopRemoteSounds()
	{
		if (asRGenerator != null && asRGenerator.isPlaying)
		{
			asRGenerator.Stop();
		}
	}

	public void PauseSoundsOnMenuOpen()
	{
		if (asRGenerator != null && asRGenerator.isPlaying)
		{
			isRGeneratorPaused = true;
			asRGenerator.Pause();
		}
	}

	public void ResumeSoundsOnMenuClose()
	{
		if (isRGeneratorPaused)
		{
			isRGeneratorPaused = false;
			if (asRGenerator != null)
			{
				asRGenerator.Play();
			}
		}
	}

	private void AddSoundSources()
	{
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_Generator);
	}

	private void BecameVisible(object datas)
	{
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.RemotePower && !((BaseShipUpgrade)x).IsBroken) && !GameSaveFile.Get("HNT_SU_RMT", false))
		{
			HintManager.PushHint(new RemoteSUHint(base.roomLocation.Label));
		}
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.PowerManager && !((BaseShipUpgrade)x).IsBroken) && !GameSaveFile.Get("HNT_SU_RRT", false))
		{
			HintManager.PushHint(new RerouteSUHint());
		}
		droneUIObject.objectBecameVisible -= BecameVisible;
	}
}
