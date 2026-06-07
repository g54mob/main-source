using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalSlot : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Feeder parentFeeder;

	public bool occupied;

	public GameObject highlight;

	public GameObject slotOccupied;

	public int animalId;

	public Animal animalScript;

	public LineRenderer lr;

	private bool showLine;

	private BoxCollider2D coll;

	private void Awake()
	{
		coll = GetComponent<BoxCollider2D>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (GameManager.ins.state == GameManager.State.CanPlaceAnimal && !occupied)
		{
			PlaceAnimal(GameManager.ins.animalSelected);
		}
		if (GameManager.ins.state == GameManager.State.CanMoveAnimal && occupied)
		{
			SelectAnimalToMove();
		}
		if (GameManager.ins.state == GameManager.State.IsMovingAnimal && !occupied)
		{
			TeleportSelectedAnimalToHere();
		}
	}

	private void SelectAnimalToMove()
	{
		GameManager.ins.animalSelectedForMoving = animalScript;
		GameManager.ins.state = GameManager.State.IsMovingAnimal;
	}

	private void TeleportSelectedAnimalToHere()
	{
		GameManager.ins.SetStateToIdle();
		if (!(GameManager.ins.animalSelectedForMoving == null))
		{
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			int id = GameManager.ins.animalSelectedForMoving.parentSlot.animalId;
			GameManager.ins.animalSelectedForMoving.parentSlot.RemoveAnimalFromSlot();
			MoveAnimalToThisSlot(GameManager.ins.animalSelectedForMoving, id);
			GameManager.ins.animalSelectedForMoving = null;
			GridSystem.ins.MoveAnimal();
		}
	}

	public void MoveAnimalToThisSlot(Animal animalObj, int id)
	{
		animalId = id;
		animalObj.parentSlot = this;
		occupied = true;
		slotOccupied.SetActive(value: true);
		animalScript = animalObj;
	}

	public void RemoveAnimalFromSlot()
	{
		occupied = false;
		slotOccupied.SetActive(value: false);
		animalId = 0;
		animalScript = null;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showLine = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		showLine = false;
	}

	private void Update()
	{
		ShowLine();
		ShowHighlight();
		ShowCollider();
	}

	private void ShowLine()
	{
		if (occupied && showLine)
		{
			if (!lr.enabled)
			{
				lr.enabled = true;
			}
			lr.SetPosition(0, animalScript.transform.position);
			lr.SetPosition(1, slotOccupied.transform.position);
		}
		else if (lr.enabled)
		{
			lr.enabled = false;
		}
	}

	private void ShowHighlight()
	{
		if (GameManager.ins.state == GameManager.State.CanPlaceAnimal && !occupied)
		{
			highlight.SetActive(value: true);
			return;
		}
		highlight.SetActive(value: false);
		if (GameManager.ins.state == GameManager.State.CanMoveAnimal && occupied)
		{
			highlight.SetActive(value: true);
			return;
		}
		highlight.SetActive(value: false);
		if (GameManager.ins.state == GameManager.State.IsMovingAnimal && !occupied)
		{
			highlight.SetActive(value: true);
		}
		else
		{
			highlight.SetActive(value: false);
		}
	}

	private void ShowCollider()
	{
		if (GameManager.ins.state == GameManager.State.CanDemolish)
		{
			coll.enabled = false;
		}
		else
		{
			coll.enabled = true;
		}
	}

	private void PlaceAnimal(AnimalSO animal)
	{
		if (!(animal == null))
		{
			GameManager.ins.SetStateToIdle();
			if (!checkIfPlayerHasResources(GameManager.ins.animalFSCost, GameManager.ins.animalBFCost))
			{
				SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
				return;
			}
			Inventory.ins.AddFossils(-GameManager.ins.animalFSCost);
			Inventory.ins.AddBiofuel(-GameManager.ins.animalBFCost);
			GameManager.ins.SpawnFossilPopUp(base.transform.position + Vector3.up * 0.5f, -GameManager.ins.animalFSCost);
			GameManager.ins.SpawnBiofuelPopUp(base.transform.position + Vector3.up * 1f, -GameManager.ins.animalBFCost);
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
			GameManager.ins.IncrementAnimalPricing(animal, 1);
			Animal animal2 = Object.Instantiate(animal.basePrefab, base.transform.position, Quaternion.identity);
			animalId = animal.animalIndexInList;
			animal2.SetAnimatorControllerTo(animal.animatorController);
			animal2.parentSlot = this;
			occupied = true;
			slotOccupied.SetActive(value: true);
			animalScript = animal2;
			AchievementManager.ins.PlaceAnimal(animal);
			AchievementManager.ins.AddAnimalStat(animal, 1);
			GameManager.ins.animalSelected = null;
		}
	}

	private bool checkIfPlayerHasResources(int fossils, int biofuel)
	{
		if (Inventory.ins.fossils < fossils)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuel)
		{
			return false;
		}
		return true;
	}

	public void QuickPlaceAnimal(AnimalSO animal)
	{
		Vector2 vector = (Vector2)base.transform.position + new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f));
		if (SaveData.ins.verticalMode)
		{
			if (vector.x > 7.5f)
			{
				vector = new Vector2(7.5f, vector.y);
			}
			if (vector.x < -7.5f)
			{
				vector = new Vector2(-7.5f, vector.y);
			}
		}
		else
		{
			if (vector.y > 4.5f)
			{
				vector = new Vector2(vector.x, 4.5f);
			}
			if (vector.y < -4f)
			{
				vector = new Vector2(vector.x, -4f);
			}
		}
		Animal animal2 = Object.Instantiate(animal.basePrefab, vector, Quaternion.identity);
		animalId = animal.animalIndexInList;
		animal2.SetAnimatorControllerTo(animal.animatorController);
		animal2.parentSlot = this;
		occupied = true;
		slotOccupied.SetActive(value: true);
		animalScript = animal2;
		GameManager.ins.IncrementAnimalPricing(animal, 1);
		AchievementManager.ins.PlaceAnimal(animal);
	}
}
