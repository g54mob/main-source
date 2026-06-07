using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public enum State
	{
		NeedsBuilding = 0,
		IsBuilding = 1,
		Built = 2,
		NeedsMoving = 3
	}

	[Serializable]
	public struct CrossoverSprites
	{
		public CrossoverFarmType type;

		public Sprite logo;
	}

	public State state;

	[Header("Information")]
	public string houseName;

	public string houseDesc;

	[SerializeField]
	private Sprite houseLogo;

	public HouseType houseType;

	public Vector2Int size = new Vector2Int(1, 1);

	[Header("Price")]
	public int spareParts;

	public int biofuel;

	[Header("Moving")]
	public Vector2Int moveToCoord;

	public BuildingBox[] boxes;

	private Vector2[] initialBoxLocalPositions;

	[SerializeField]
	private GameObject newLocationSprite;

	private Vector2 initialNewLocationSpriteLocalPos;

	[Header("References")]
	private Vector2Int anchorCoord;

	[SerializeField]
	private GameObject highlight;

	[SerializeField]
	private GameObject workBenchPlusOutline;

	[SerializeField]
	private Animator poofAnimation;

	public Transform center;

	[SerializeField]
	private GameObject finishedObject;

	[SerializeField]
	private GameObject characterObject;

	private Collider2D moveCollider;

	[Header("Crossover Sprites")]
	[SerializeField]
	private CrossoverSprites[] crossoverSprites;

	public string balatroJokerEffect;

	public Sprite balatroJokerImage;

	public Sprite getLogoSprite()
	{
		Sprite logo = houseLogo;
		if ((bool)SaveData.ins && SaveData.ins.checkIfCrossover(out var crossover))
		{
			for (int i = 0; i < crossoverSprites.Length; i++)
			{
				if (crossoverSprites[i].type == crossover)
				{
					logo = crossoverSprites[i].logo;
					break;
				}
			}
		}
		return logo;
	}

	private void Start()
	{
		TryGetComponent<Collider2D>(out moveCollider);
		if ((bool)moveCollider)
		{
			moveCollider.enabled = false;
		}
		highlight.GetComponent<SpriteRenderer>().sortingOrder = 99;
		highlight.SetActive(value: false);
		GameManager.ins.houses.Add(this);
		if (state == State.Built)
		{
			finishedObject.SetActive(value: true);
			workBenchPlusOutline.SetActive(value: false);
			if ((bool)characterObject)
			{
				characterObject.transform.parent = null;
			}
			GameManager.ins.gridSystem.MarkTilesAsOccupied(anchorCoord, size, occupiedState: true);
			GameManager.ins.UnlockFeaturesFrom(houseType);
			StartCoroutine(DoubleCheckUnlockingHouseFeatures());
		}
		if (state == State.NeedsBuilding || state == State.IsBuilding)
		{
			workBenchPlusOutline.SetActive(value: true);
			finishedObject.SetActive(value: false);
			GameManager.ins.housesToBeBuilt.Add(this);
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
			if ((bool)characterObject)
			{
				characterObject.transform.parent = null;
			}
			GameManager.ins.UnlockFeaturesFrom(houseType);
			StartCoroutine(DoubleCheckUnlockingHouseFeatures());
			SetNewHouseCoord(moveToCoord);
		}
	}

	private IEnumerator DoubleCheckUnlockingHouseFeatures()
	{
		yield return null;
		yield return null;
		GameManager.ins.UnlockFeaturesFrom(houseType);
		yield return null;
		yield return null;
		AchievementManager.ins.BuildHouse(this);
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
		if ((bool)characterObject)
		{
			characterObject.transform.parent = null;
		}
		GameManager.ins.gridSystem.MarkTilesAsOccupied(anchorCoord, size, occupiedState: true);
		GameManager.ins.UnlockFeaturesFrom(houseType);
		state = State.Built;
	}

	private void Update()
	{
		if (GameManager.ins.state == GameManager.State.CanMoveBuilding)
		{
			if (state == State.Built && !highlight.activeInHierarchy)
			{
				highlight.SetActive(value: true);
				moveCollider.enabled = true;
			}
		}
		else if (highlight.activeInHierarchy)
		{
			highlight.SetActive(value: false);
			moveCollider.enabled = false;
		}
	}

	public void SelectThisHouseToMove()
	{
		GameManager.ins.state = GameManager.State.IsMovingBuilding;
		GameManager.ins.houseSelectedForMoving = this;
		GameManager.ins.buildingSelectedForMoving = null;
		GameManager.ins.decorSelectedForMoving = null;
		if (GameManager.ins.qualityUpdate)
		{
			GridSystem.ins.MarkTilesAsOccupied(anchorCoord, size, occupiedState: false);
		}
	}

	public void SetNewHouseCoord(Vector2Int target)
	{
		if (GameManager.ins.qualityUpdate)
		{
			GridSystem.ins.MarkTilesAsOccupied(anchorCoord, size, occupiedState: true);
		}
		if (!(target == anchorCoord))
		{
			moveToCoord = target;
			state = State.NeedsMoving;
			GridSystem.ins.MarkTilesAsOccupied(moveToCoord, size, occupiedState: true);
			finishedObject.SetActive(value: false);
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
		TeleportHouseToNewSite();
	}

	private void TeleportHouseToNewSite()
	{
		state = State.Built;
		GridSystem.ins.RemoveHouseAt(anchorCoord, size);
		GridSystem.ins.MarkTilesAsOccupied(moveToCoord, size, occupiedState: true);
		GridSystem.ins.AddHouseAt(moveToCoord, this);
		base.transform.position = GridSystem.ins.getWorldPosition(moveToCoord);
		anchorCoord = moveToCoord;
		moveToCoord = new Vector2Int(-1, -1);
		finishedObject.SetActive(value: true);
		workBenchPlusOutline.SetActive(value: false);
		for (int i = 0; i < boxes.Length; i++)
		{
			boxes[i].transform.localPosition = initialBoxLocalPositions[i];
		}
		if ((bool)newLocationSprite)
		{
			newLocationSprite.SetActive(value: false);
		}
		if ((bool)newLocationSprite)
		{
			newLocationSprite.transform.localPosition = initialNewLocationSpriteLocalPos;
		}
	}

	public Vector2Int getCoords()
	{
		return anchorCoord;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanMoveBuilding && eventData.button == PointerEventData.InputButton.Left && state == State.Built)
		{
			SelectThisHouseToMove();
		}
	}

	public void AddAnchorCoord(Vector2Int coord)
	{
		anchorCoord = coord;
	}
}
