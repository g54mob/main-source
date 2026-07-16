using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Wagon : MonoBehaviour
{
	public int wagonIndex;

	private Door doorLeft;

	private Door doorRight;

	private Roof[] roofs;

	private Door doorPort;

	private Door doorStarboard;

	public PathFollower pathFollower;

	[SerializeField]
	private GameObject hardeningGO;

	public Transform backBlockerPosition;

	private List<PlayerController> playersInWagon = new List<PlayerController>();

	private Animator animator;

	[SerializeField]
	private SpriteRenderer paint;

	[SerializeField]
	private SpriteRenderer roof;

	[SerializeField]
	private SpriteMask roofMask;

	[SerializeField]
	private Sprite roofSprite;

	[field: SerializeField]
	public WagonType WagonType { get; private set; }

	[field: SerializeField]
	public ModuleSlot[] ModuleSlots { get; private set; }

	[HideInInspector]
	public float TrainWidth { get; private set; }

	[field: SerializeField]
	public List<ParticleSystem> Fireworks { get; private set; }

	public Module[] Modules
	{
		get
		{
			Module[] array = new Module[ModuleSlots.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ModuleSlots[i].Module;
			}
			return array;
		}
	}

	private void Awake()
	{
		pathFollower = GetComponent<PathFollower>();
		roofs = GetComponentsInChildren<Roof>();
		Transform transform = base.transform.Find("Walls & Doors/Door Left");
		if (transform != null)
		{
			doorLeft = transform.GetComponent<Door>();
		}
		Transform transform2 = base.transform.Find("Walls & Doors/Door Right");
		if (transform2 != null)
		{
			doorRight = transform2.GetComponent<Door>();
		}
		Transform transform3 = base.transform.Find("Walls & Doors/Door Port");
		if (transform3 != null)
		{
			doorPort = transform3.GetComponent<Door>();
		}
		Transform transform4 = base.transform.Find("Walls & Doors/Door Starboard");
		if (transform4 != null)
		{
			doorStarboard = transform4.GetComponent<Door>();
		}
		animator = GetComponent<Animator>();
	}

	protected void Start()
	{
		if (!Train.Instance.Wagons.Contains(this))
		{
			Train.Instance.Wagons.Add(this);
		}
		wagonIndex = Train.Instance.Wagons.IndexOf(this);
		base.name = $"Wagon {wagonIndex}";
		SetRoofsVisibility(RoofVisibility.Invisible);
		TrainWidth = GetComponent<BoxCollider2D>().size.x;
		if (wagonIndex != 0)
		{
			pathFollower.parentPf = Train.Instance.Wagons[0].pathFollower;
		}
		Train.Instance.UpdateDoorLocks();
		PlayerManager.Instance.OnCoopEnded += HandleCoopEnded;
		Level.OnLevelStarted += HandleLevelStarted;
		MenuSettings.OnShowRoofsToggled += HandleRoofVisToggle;
		if (WagonType != WagonType.Main && WagonType != WagonType.Starting)
		{
			SetWagonArt(Train.Instance.currentTrain);
		}
	}

	private void Update()
	{
		animator.SetFloat("Speed", Train.Instance.SpeedCurrent / 2.4f);
		if (Train.Instance.currentTrain.trainType != TrainType.Regular && roof.color != Color.white)
		{
			roof.color = new Color(1f, 1f, 1f, roof.color.a);
		}
	}

	private void OnDestroy()
	{
		PlayerManager.Instance.OnCoopEnded -= HandleCoopEnded;
		Level.OnLevelStarted -= HandleLevelStarted;
		MenuSettings.OnShowRoofsToggled -= HandleRoofVisToggle;
	}

	private void HandleCoopEnded(PlayerController controller)
	{
	}

	public void AddPlayer(PlayerController player)
	{
		if (!playersInWagon.Contains(player))
		{
			playersInWagon.Add(player);
			UpdateRoofsVisibility(player);
		}
	}

	public void RemovePlayer(PlayerController player)
	{
		if (playersInWagon.Contains(player))
		{
			playersInWagon.Remove(player);
			UpdateRoofsVisibility(player);
		}
	}

	public void UpdateDoorLocks()
	{
		if ((bool)doorRight)
		{
			doorRight.IsLocked = false;
		}
		if ((bool)doorLeft)
		{
			if (Train.Instance.Wagons.Count - 1 > wagonIndex)
			{
				doorLeft.IsLocked = false;
			}
			else
			{
				doorLeft.IsLocked = true;
			}
		}
	}

	private void HandleLevelStarted()
	{
		UpdateRoofsVisibility();
	}

	private void HandleRoofVisToggle()
	{
		UpdateRoofsVisibility();
	}

	public void SetRoofsVisibility(RoofVisibility visiblity)
	{
		Roof[] array = roofs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetVisible(visiblity);
		}
		if (!PlayerManager.Instance.IsCoop)
		{
			return;
		}
		Module[] modules = Modules;
		foreach (Module module in modules)
		{
			if (!module || !module.showRoof)
			{
				continue;
			}
			switch (visiblity)
			{
			case RoofVisibility.Transparent:
				if (module.Interactable?.Interactor?.playerController?.SM?.CurrentState is PlayerInteract && module.Interactable?.Interactor?.playerController == module.CurrentInteractor?.playerController)
				{
					module.ShowRoofElement();
				}
				else
				{
					module.TransparentRoofElement();
				}
				break;
			case RoofVisibility.Invisible:
				module.HideRoofElement();
				break;
			default:
				module.ShowRoofElement();
				break;
			}
		}
	}

	public void UpdateRoofsVisibility(PlayerController exception = null)
	{
		if ((!Train.ShowRoofOnEmptyWagons && PlayerManager.Instance.Players.Count == 1) || !LevelManager.Instance.IsPlaying)
		{
			return;
		}
		if (playersInWagon.Count == 0)
		{
			SetRoofsVisibility(Train.ShowRoofOnEmptyWagons ? RoofVisibility.Visible : RoofVisibility.Invisible);
		}
		else if (playersInWagon.Any((PlayerController p) => !p.IsInteracting()))
		{
			List<PlayerController> list = playersInWagon.Where((PlayerController p) => p.IsInteracting()).ToList();
			if (list != null)
			{
				if (list.Count == 0)
				{
					SetRoofsVisibility(RoofVisibility.Invisible);
				}
				else if ((bool)list.FirstOrDefault((PlayerController p) => (bool)p.interactor.ActiveInteractable && p.interactor.ActiveInteractable.gameObject.GetComponent<Module>().showRoof))
				{
					SetRoofsVisibility(RoofVisibility.Transparent);
				}
				else
				{
					SetRoofsVisibility(RoofVisibility.Invisible);
				}
			}
			else
			{
				SetRoofsVisibility(RoofVisibility.Invisible);
			}
		}
		else if (playersInWagon.All((PlayerController p) => (bool)p.interactor.ActiveInteractable && p.interactor.ActiveInteractable.gameObject.GetComponent<Module>().showRoof))
		{
			SetRoofsVisibility(RoofVisibility.Visible);
		}
		else if (playersInWagon.All((PlayerController p) => !p.interactor.ActiveInteractable || !p.interactor.ActiveInteractable.gameObject.GetComponent<Module>().showRoof))
		{
			SetRoofsVisibility(RoofVisibility.Invisible);
		}
		else
		{
			SetRoofsVisibility(RoofVisibility.Transparent);
		}
	}

	public void SetModuleTypes(ModuleCombatTypes[] types)
	{
		for (int i = 0; i < ModuleSlots.Length; i++)
		{
			ModuleSlots[i].SetModuleType(ModuleCombatTypes.Wild);
		}
	}

	public void SetHardening(bool isHardened)
	{
		hardeningGO.SetActive(isHardened);
		NewTrainBase newTrainBase = Train.Instance.currentTrain;
		SpriteRenderer component = hardeningGO.GetComponent<SpriteRenderer>();
		if (newTrainBase.HardenPlatingArt == null || newTrainBase.HardenPlatingArt.Count == 0)
		{
			newTrainBase = Train.Instance.trains.Keys.ElementAt(0);
		}
		if (WagonType == WagonType.Main)
		{
			component.sprite = newTrainBase.HardenPlatingArt[0];
		}
		else
		{
			component.sprite = newTrainBase.HardenPlatingArt[ModuleSlots.Length];
		}
	}

	public void SetHardedningArt(NewTrainBase currentTrain)
	{
		SpriteRenderer component = hardeningGO.GetComponent<SpriteRenderer>();
		if (currentTrain.HardenPlatingArt == null || currentTrain.HardenPlatingArt.Count == 0)
		{
			currentTrain = Train.Instance.trains.Keys.ElementAt(0);
		}
		if (WagonType == WagonType.Main)
		{
			component.sprite = currentTrain.HardenPlatingArt[0];
		}
		else
		{
			component.sprite = currentTrain.HardenPlatingArt[ModuleSlots.Length];
		}
	}

	public void LockExteriorDoors((bool, bool) locks)
	{
		doorPort.IsLocked = locks.Item1;
		doorStarboard.IsLocked = locks.Item2;
	}

	public void SetWagonArt(NewTrainBase train)
	{
		if (train.trainType == TrainType.Regular)
		{
			animator.Play(train.wagonRoofAnimName[ModuleSlots.Count() - 1] ?? "");
			paint.enabled = true;
			roof.sprite = roofSprite;
			roofMask.sprite = roofSprite;
		}
		else
		{
			animator.Play(train.wagonRoofAnimName[ModuleSlots.Count() - 1] ?? "");
			paint.enabled = false;
			roof.sprite = train.wagonRoofSprite[ModuleSlots.Count() - 1];
			roof.color = Color.white;
			roofMask.sprite = train.wagonRoofSprite[ModuleSlots.Count() - 1];
		}
	}
}
