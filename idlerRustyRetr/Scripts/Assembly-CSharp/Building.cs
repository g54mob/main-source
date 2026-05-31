using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public enum State
	{
		NeedsBuilding = 0,
		IsBuilding = 1,
		Built = 2,
		NeedsUpgrading = 3,
		IsUpgrading = 4,
		MarkedForBuilding = 5,
		MarkedForUpgrading = 6,
		NeedsMoving = 7
	}

	public State state;

	[Header("Visuals")]
	[SerializeField]
	private GameObject workBenchPlusOutline;

	[SerializeField]
	private Animator poofAnimation;

	public Transform center;

	[SerializeField]
	private GameObject finishedObject;

	[SerializeField]
	private SpriteRenderer rangeSprite;

	[Header("Building Info")]
	public BuildingSO building;

	private Vector2Int anchorCoord;

	public bool buildingEnabled = true;

	[Header("Upgrade | Demolish")]
	[SerializeField]
	private bool canDemolish = true;

	[SerializeField]
	private bool canUpgrade;

	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private GameObject selected;

	[SerializeField]
	private GameObject upgrading;

	private Collider2D demolishCollider;

	[Header("Boxes for moving")]
	public BuildingBox[] boxes;

	private Vector2[] initialBoxLocalPositions;

	[SerializeField]
	private GameObject newLocationSprite;

	private Vector2 initialNewLocationSpriteLocalPos;

	public Vector2Int moveToCoord = new Vector2Int(-1, -1);

	[Header("Building Level")]
	public int speedLevel;

	public bool upgradingSpeed;

	public int capacityLevel;

	public bool upgradingCapacity;

	[Header("Crops Slots")]
	public GameObject[] cropSlots;

	public CropSign cropSign;

	[Header("Animal Slots")]
	public AnimalSlot[] animalSlots;

	[Header("Hover over")]
	[SerializeField]
	private Vector2 hoverSize;

	private float hoverOverTimer;

	[Header("Max upgrade building")]
	[SerializeField]
	private SpriteRenderer buildingSprite;

	[SerializeField]
	private Sprite maxedSprite;

	[SerializeField]
	private SpriteRenderer botSprite;

	private void Start()
	{
		TryGetComponent<Collider2D>(out demolishCollider);
		if ((bool)demolishCollider)
		{
			demolishCollider.enabled = false;
		}
		if (highlight != null)
		{
			highlight.SetActive(value: false);
		}
		if (selected != null)
		{
			selected.SetActive(value: false);
		}
		if (upgrading != null)
		{
			upgrading.SetActive(value: false);
		}
		if (rangeSprite != null)
		{
			rangeSprite.gameObject.SetActive(value: false);
		}
		if (state == State.Built)
		{
			finishedObject.SetActive(value: true);
			workBenchPlusOutline.SetActive(value: false);
			if ((bool)AchievementManager.ins)
			{
				AchievementManager.ins.BuildAllBuildings(building.name);
			}
			if ((bool)AchievementManager.ins)
			{
				AchievementManager.ins.PlaceAnimal(building.buildType);
			}
		}
		if (state == State.NeedsBuilding || state == State.IsBuilding || state == State.MarkedForBuilding)
		{
			workBenchPlusOutline.SetActive(value: true);
			finishedObject.SetActive(value: false);
			if (state == State.IsBuilding)
			{
				state = State.NeedsBuilding;
			}
		}
		if (state == State.NeedsUpgrading || state == State.IsUpgrading || state == State.MarkedForUpgrading)
		{
			if (upgrading != null)
			{
				upgrading.SetActive(value: true);
			}
			if (state == State.IsUpgrading)
			{
				state = State.NeedsUpgrading;
			}
		}
		initialBoxLocalPositions = new Vector2[boxes.Length];
		for (int i = 0; i < initialBoxLocalPositions.Length; i++)
		{
			initialBoxLocalPositions[i] = boxes[i].transform.localPosition;
		}
		if ((bool)newLocationSprite)
		{
			initialNewLocationSpriteLocalPos = newLocationSprite.transform.localPosition;
		}
		if (state == State.NeedsMoving)
		{
			SetNewBuildingCoord(moveToCoord);
		}
		CheckIfBuildingIsMaxed();
		SetBuildingToEnabled(buildingEnabled);
	}

	public void Demolish(bool moveTo)
	{
		GameManager.ins.buildings.Remove(this);
		GridSystem.ins.RemoveBuildingAt(anchorCoord, building.size);
		if (!moveTo)
		{
			GameManager.ins.RemoveIncrementalPriceFrom(building.buildType, speedLevel, capacityLevel);
		}
		Inventory.ins.AddToBuildingInventory(building, -1);
		if (moveTo)
		{
			GridSystem.ins.MarkTilesAsOccupied(moveToCoord, building.size, occupiedState: true);
		}
		if ((bool)UpgradePanel.ins && UpgradePanel.ins.currentBuildingSelected == this)
		{
			UpgradePanel.ins.HideUpgradePanel();
		}
		Object.Destroy(base.gameObject);
	}

	public void SelectThisBuildingToMove()
	{
		GameManager.ins.state = GameManager.State.IsMovingBuilding;
		GameManager.ins.buildingSelectedForMoving = this;
		GameManager.ins.houseSelectedForMoving = null;
		GameManager.ins.decorSelectedForMoving = null;
		if (GameManager.ins.qualityUpdate)
		{
			GridSystem.ins.MarkTilesAsOccupied(anchorCoord, building.size, occupiedState: false);
		}
	}

	public void SetNewBuildingCoord(Vector2Int target)
	{
		if (GameManager.ins.qualityUpdate)
		{
			GridSystem.ins.MarkTilesAsOccupied(anchorCoord, building.size, occupiedState: true);
		}
		if (!(target == anchorCoord))
		{
			moveToCoord = target;
			state = State.NeedsMoving;
			GridSystem.ins.MarkTilesAsOccupied(moveToCoord, building.size, occupiedState: true);
			Object.Destroy(finishedObject);
			Vector3 vector = displacement(anchorCoord, moveToCoord);
			for (int i = 0; i < boxes.Length; i++)
			{
				boxes[i].NeedsMovingTo(vector);
				GameManager.ins.boxesToMove.Add(boxes[i]);
			}
			workBenchPlusOutline.SetActive(value: true);
			if ((bool)newLocationSprite)
			{
				newLocationSprite.transform.position += vector;
			}
			if ((bool)newLocationSprite)
			{
				newLocationSprite.SetActive(value: true);
			}
		}
	}

	private Vector3 displacement(Vector2Int origin, Vector2Int target)
	{
		return GridSystem.ins.getWorldPosition(target) - GridSystem.ins.getWorldPosition(origin);
	}

	public void CheckIfAllBoxesHaveBeenMoved()
	{
		for (int i = 0; i < boxes.Length; i++)
		{
			if (boxes[i].state == BuildingBox.State.MarkedForMoving || boxes[i].state == BuildingBox.State.NeedsMoving)
			{
				return;
			}
		}
		TeleportBuildingToNewSite();
	}

	private void TeleportBuildingToNewSite()
	{
		GameManager.ins.gridSystem.AddBuildingAt(moveToCoord, this);
		GridSystem.ins.QuickBuild(building, State.Built, moveToCoord, out var bScript);
		for (int i = 0; i < animalSlots.Length; i++)
		{
			if (animalSlots[i].occupied)
			{
				Animal animalScript = animalSlots[i].animalScript;
				bScript.animalSlots[i].MoveAnimalToThisSlot(animalScript, animalSlots[i].animalId);
			}
		}
		AchievementManager.ins.MoveABuilding();
		AchievementManager.ins.RemoveAnimal(building.buildType);
		Demolish(moveTo: true);
	}

	private void Update()
	{
		if (highlight == null)
		{
			return;
		}
		if (animalSlots.Length != 0)
		{
			canDemolish = true;
			for (int i = 0; i < animalSlots.Length; i++)
			{
				if (animalSlots[i].occupied)
				{
					canDemolish = false;
					break;
				}
			}
		}
		if (GameManager.ins.state == GameManager.State.CanDemolish && canDemolish)
		{
			if (state != State.IsBuilding && state != State.IsUpgrading && state != State.NeedsMoving && !highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
				demolishCollider.enabled = true;
			}
			return;
		}
		if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
			demolishCollider.enabled = false;
		}
		if (GameManager.ins.state == GameManager.State.CanUpgrade && canUpgrade)
		{
			if (state != State.NeedsBuilding && state != State.IsBuilding && state != State.NeedsMoving && !highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
				demolishCollider.enabled = true;
			}
			return;
		}
		if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
			demolishCollider.enabled = false;
		}
		if (GameManager.ins.state == GameManager.State.CanMoveBuilding)
		{
			if (state == State.Built && !highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
				demolishCollider.enabled = true;
			}
			return;
		}
		if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
			demolishCollider.enabled = false;
		}
		if (rangeSprite == null)
		{
			return;
		}
		if (mouseIsInsideHoverOverArea())
		{
			hoverOverTimer += Time.deltaTime;
			if (hoverOverTimer > 0.5f)
			{
				rangeSprite.gameObject.SetActive(value: true);
			}
			else
			{
				rangeSprite.gameObject.SetActive(value: false);
			}
		}
		else
		{
			hoverOverTimer = 0f;
			rangeSprite.gameObject.SetActive(value: false);
		}
	}

	private bool mouseIsInsideHoverOverArea()
	{
		bool result = false;
		Vector2 mousePositionInWorld = GameManager.ins.mousePositionInWorld;
		if (mousePositionInWorld.x < center.position.x + hoverSize.x / 2f && mousePositionInWorld.x > center.position.x - hoverSize.x / 2f && mousePositionInWorld.y < center.position.y + hoverSize.y / 2f && mousePositionInWorld.y > center.position.y - hoverSize.y / 2f)
		{
			result = true;
		}
		return result;
	}

	public void AddAnchorCoord(Vector2Int coord)
	{
		anchorCoord = coord;
	}

	public void UpdateCropsSlots()
	{
		for (int i = 0; i < cropSlots.Length; i++)
		{
		}
	}

	public void StartBuilding()
	{
		state = State.IsBuilding;
	}

	public void CompleteBuild()
	{
		if ((bool)poofAnimation)
		{
			poofAnimation.SetTrigger("poof");
		}
		finishedObject.SetActive(value: true);
		workBenchPlusOutline.SetActive(value: false);
		GameManager.ins.gridSystem.SetActiveTileObjsAt(anchorCoord, building.size, active: false);
		state = State.Built;
		AchievementManager.ins.BuildAllBuildings(building.name);
	}

	public void MarkForUpgrading(bool speedLvl, bool capacityLvl)
	{
		state = State.NeedsUpgrading;
		if (speedLvl)
		{
			upgradingSpeed = true;
		}
		if (capacityLvl)
		{
			upgradingCapacity = true;
		}
		if (upgradingSpeed)
		{
			speedLevel++;
		}
		if (upgradingCapacity)
		{
			capacityLevel++;
		}
		ShowUpgradingIcon(activeState: true);
	}

	public void StartUpgrading()
	{
		state = State.IsUpgrading;
	}

	public void FinishUpgrading()
	{
		upgradingSpeed = false;
		upgradingCapacity = false;
		ShowUpgradingIcon(activeState: false);
		CheckIfBuildingIsMaxed();
		state = State.Built;
		if ((bool)UpgradePanel.ins)
		{
			UpgradePanel.ins.BuildingHasFinishedUpgrading(this);
		}
	}

	public void CheckIfBuildingIsMaxed()
	{
		if (!(buildingSprite == null) && !(maxedSprite == null))
		{
			int num = building.capacityUpgrade.Length - 1;
			int num2 = building.speedUpgrade.Length - 1;
			if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
			{
				num -= building.capacityFrost;
				num2 -= building.speedFrost;
			}
			if (capacityLevel == num && speedLevel == num2)
			{
				buildingSprite.sprite = maxedSprite;
				AchievementManager.ins.MaxedBot(building.buildType);
			}
		}
	}

	public void SetBuildingToEnabled(bool value)
	{
		if (buildingSprite == null)
		{
			return;
		}
		buildingEnabled = value;
		if (value)
		{
			buildingSprite.color = Color.white;
		}
		else
		{
			buildingSprite.color = new Color(0.65f, 0.65f, 0.65f, 1f);
		}
		if (!(botSprite == null))
		{
			if (value)
			{
				botSprite.color = Color.white;
			}
			else
			{
				botSprite.color = new Color(0.65f, 0.65f, 0.65f, 1f);
			}
		}
	}

	public void ShowSelectedIcon(bool activeState)
	{
		selected.SetActive(activeState);
	}

	public void ShowUpgradingIcon(bool activeState)
	{
		upgrading.SetActive(activeState);
	}

	public float getSpeed()
	{
		if (upgradingSpeed && (state == State.NeedsUpgrading || state == State.MarkedForUpgrading || state == State.IsUpgrading))
		{
			int num = speedLevel - 1;
			if (num < 0)
			{
				num = 0;
			}
			return (float)building.speedUpgrade[num].level * 0.01f;
		}
		return (float)building.speedUpgrade[speedLevel].level * 0.01f;
	}

	public int getCapacity()
	{
		if (upgradingCapacity && (state == State.NeedsUpgrading || state == State.MarkedForUpgrading || state == State.IsUpgrading))
		{
			int num = capacityLevel - 1;
			if (num < 0)
			{
				num = 0;
			}
			return building.capacityUpgrade[num].level;
		}
		return building.capacityUpgrade[capacityLevel].level;
	}

	public int getBiofuelConsumption()
	{
		int num = Mathf.FloorToInt(speedLevel / 2) + capacityLevel + 1;
		if (SaveData.ins.farmType == SaveData.FarmType.WinterSnow)
		{
			num *= 2;
		}
		return num;
	}

	public Vector2Int getCoords()
	{
		return anchorCoord;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		if (GameManager.ins.state == GameManager.State.CanDemolish && canDemolish)
		{
			if (state != State.IsBuilding && state != State.IsUpgrading && state != State.NeedsMoving)
			{
				GameManager.ins.SetStateToIdle();
				AreYouSure.ins.SpawnOn(this);
			}
		}
		else if (GameManager.ins.state == GameManager.State.CanMoveBuilding)
		{
			if (state == State.Built)
			{
				SelectThisBuildingToMove();
			}
		}
		else if (GameManager.ins.state == GameManager.State.CanUpgrade && canUpgrade && state != State.NeedsBuilding && state != State.IsBuilding && state != State.MarkedForBuilding && state != State.NeedsMoving)
		{
			UpgradePanel.ins.SpawnUpgradePanel(speedLevel, capacityLevel, this);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(center.position, hoverSize);
	}
}
