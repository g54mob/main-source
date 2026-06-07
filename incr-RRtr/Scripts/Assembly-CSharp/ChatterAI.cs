using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatterAI : MonoBehaviour
{
	public enum ChatterAction
	{
		Water = 0,
		Harvest = 1,
		Stock = 2,
		Build = 3,
		Feed = 4,
		Collect = 5,
		Fertilize = 6,
		PickBerries = 7,
		MoveBuilding = 8,
		Plant = 9
	}

	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	public ChatterAction currentAction;

	private string chatterName;

	private float movementSpeed = 1f;

	private int charges;

	private float timer;

	private bool needsRest;

	private TwitchIntegration twitchIntegration;

	[Header("Visuals")]
	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private SpriteRenderer cropSr;

	[SerializeField]
	private TMP_Text nameTagText;

	[SerializeField]
	private Sprite poopSprite;

	[SerializeField]
	private Sprite buildingBoxSprite;

	[SerializeField]
	private ParticleSystem emoteParticles;

	private Renderer emoteParticlesRenderer;

	[Header("Colors")]
	[SerializeField]
	private Color purple;

	[SerializeField]
	private AnimatorOverrideController purpleAnim;

	[SerializeField]
	private Color pink;

	[SerializeField]
	private AnimatorOverrideController pinkAnim;

	[SerializeField]
	private Color blue;

	[SerializeField]
	private AnimatorOverrideController blueAnim;

	[SerializeField]
	private Color green;

	[SerializeField]
	private AnimatorOverrideController greenAnim;

	[SerializeField]
	private Color yellow;

	[SerializeField]
	private AnimatorOverrideController yellowAnim;

	[SerializeField]
	private Color red;

	[SerializeField]
	private AnimatorOverrideController redAnim;

	[SerializeField]
	private Color gray;

	[SerializeField]
	private AnimatorOverrideController grayAnim;

	[SerializeField]
	private Color gold;

	[SerializeField]
	private AnimatorOverrideController goldAnim;

	[SerializeField]
	private ParticleSystem goldParticles;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WATER = "Water";

	private const string PICK = "Pick";

	private const string WAIT = "Waiting";

	private const string CARRY = "Carry";

	private const string CROUCH = "Crouch";

	private const string BUILD = "Build";

	private const string BENCH = "Bench";

	private Building targetBuilding;

	private BiofuelSlot targetBiofuelSlot;

	private CropSlot targetHarvestCrop;

	private CropSlot targetWaterCrop;

	private FeederSlot targetFeederSlot;

	private Poop targetPoop;

	private CropSlot targetFertSlot;

	private BerryBush targetBush;

	private CropSlot targetPlantSlot;

	private List<PlantSeedButton> cropsAndSeedsInInventory;

	private void Start()
	{
		charges = GameManager.ins.chatterCharges;
		emoteParticlesRenderer = emoteParticles.GetComponent<Renderer>();
		cropsAndSeedsInInventory = new List<PlantSeedButton>();
		StartCoroutine(WaitForNextAction());
		InvokeRepeating("NeedsRest", Random.Range(60, 2000), 1800f);
	}

	public void UpdateNameTagTo(string value, bool subbed)
	{
		chatterName = value;
		nameTagText.text = value;
		PickRandomColor(subbed);
	}

	public void LinkTo(TwitchIntegration script)
	{
		twitchIntegration = script;
	}

	private void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (timer > (float)SaveData.ins.inactivityTimer * 60f)
		{
			twitchIntegration.DespawnChatterBot(chatterName);
		}
	}

	public void ResetTimer()
	{
		timer = 0f;
	}

	private IEnumerator WaitForNextAction()
	{
		SetAnimation("Waiting");
		yield return new WaitForSeconds(1f);
		PickNextAction();
	}

	private void PickNextAction()
	{
		if (this == null)
		{
			return;
		}
		if (needsRest)
		{
			Bench closestBench = GameManager.ins.getClosestBench(base.transform.position);
			if ((bool)closestBench)
			{
				StartCoroutine(RestOnBench(closestBench));
				return;
			}
		}
		if (currentAction == ChatterAction.Build)
		{
			Building closestBuildSlotThat = GameManager.ins.getClosestBuildSlotThat(Building.State.NeedsBuilding, base.transform.position);
			if ((bool)closestBuildSlotThat)
			{
				StartCoroutine(Build(closestBuildSlotThat));
				return;
			}
		}
		if (currentAction == ChatterAction.Stock)
		{
			BiofuelSlot closestBiofuelSlotThat = GameManager.ins.getClosestBiofuelSlotThat(BiofuelSlot.State.Empty, base.transform.position);
			CropType cropForBioSlot = GetCropForBioSlot(closestBiofuelSlotThat);
			if ((bool)closestBiofuelSlotThat && cropForBioSlot != CropType.None)
			{
				StartCoroutine(StockBiofuel(closestBiofuelSlotThat, cropForBioSlot));
				return;
			}
		}
		if (currentAction == ChatterAction.Harvest)
		{
			CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position);
			if ((bool)closestCropSlotThat)
			{
				StartCoroutine(Harvest(closestCropSlotThat));
				return;
			}
		}
		if (currentAction == ChatterAction.Water)
		{
			CropSlot closestCropSlotThat2 = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedWater, base.transform.position);
			if ((bool)closestCropSlotThat2)
			{
				StartCoroutine(Water(closestCropSlotThat2));
				return;
			}
		}
		if (currentAction == ChatterAction.Feed)
		{
			FeederSlot closestFeederSlotTo = GameManager.ins.getClosestFeederSlotTo(FeederSlot.State.Empty, base.transform.position, base.transform.position, 999f);
			if ((bool)closestFeederSlotTo)
			{
				SortListOfCrops();
				if (cropsAndSeedsInInventory.Count <= 0)
				{
					StartCoroutine(WaitForNextAction());
				}
				else
				{
					StartCoroutine(Feed(closestFeederSlotTo, cropsAndSeedsInInventory[0].cropType));
				}
				return;
			}
		}
		if (currentAction == ChatterAction.Collect)
		{
			Poop closestPoopThat = GameManager.ins.getClosestPoopThat(Poop.State.NeedsCollecting, base.transform.position, base.transform.position, 999f);
			if ((bool)closestPoopThat)
			{
				StartCoroutine(Collect(closestPoopThat));
				return;
			}
		}
		if (currentAction == ChatterAction.Fertilize)
		{
			CropSlot closestCropSlotThatNeedsFertilizer = GameManager.ins.getClosestCropSlotThatNeedsFertilizer(base.transform.position, base.transform.position, 999f);
			if ((bool)closestCropSlotThatNeedsFertilizer)
			{
				StartCoroutine(Fertilize(closestCropSlotThatNeedsFertilizer));
				return;
			}
		}
		if (currentAction == ChatterAction.PickBerries)
		{
			BerryBush closestBerryBushThat = GameManager.ins.getClosestBerryBushThat(BerryBush.State.NeedsHarvest, base.transform.position, base.transform.position, 999f);
			if (closestBerryBushThat != null)
			{
				StartCoroutine(GoToBerryBush(closestBerryBushThat));
				return;
			}
		}
		if (currentAction == ChatterAction.MoveBuilding)
		{
			BuildingBox closestBuildingBoxThat = GameManager.ins.getClosestBuildingBoxThat(BuildingBox.State.NeedsMoving, base.transform.position);
			if ((bool)closestBuildingBoxThat)
			{
				StartCoroutine(MoveBox(closestBuildingBoxThat));
				return;
			}
		}
		if (currentAction == ChatterAction.Plant)
		{
			CropSlot closestCropSlotThatCanBeSeeded = GameManager.ins.getClosestCropSlotThatCanBeSeeded(base.transform.position);
			if ((bool)closestCropSlotThatCanBeSeeded)
			{
				StartCoroutine(Plant(closestCropSlotThatCanBeSeeded));
				return;
			}
		}
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator Build(Building building)
	{
		if (building == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		building.state = Building.State.MarkedForBuilding;
		targetBuilding = building;
		float x = 1f;
		Vector2 vector = (Vector2)building.center.position - new Vector2(x, 0f);
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (building == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		workerAnim.Play("Build");
		int num = building.building.constructionTime * 60;
		if ((bool)building)
		{
			building.StartBuilding();
		}
		yield return new WaitForSeconds(num);
		if ((bool)building)
		{
			building.CompleteBuild();
		}
		targetBuilding = null;
		SetAnimation("Waiting");
		yield return new WaitForSeconds(1f);
		StartCoroutine(WaitForNextAction());
	}

	private void SortListOfCrops()
	{
		if (cropsAndSeedsInInventory.Count > 0)
		{
			cropsAndSeedsInInventory.Clear();
		}
		List<PlantSeedButton> list = new List<PlantSeedButton>();
		for (int i = 0; i < Inventory.ins.cropAndSeedInventory.Count; i++)
		{
			if (Inventory.ins.cropAndSeedInventory[i].cropAmount >= 1)
			{
				list.Add(Inventory.ins.cropAndSeedInventory[i]);
			}
		}
		int count = list.Count;
		for (int j = 0; j < count; j++)
		{
			int index = Random.Range(0, list.Count);
			cropsAndSeedsInInventory.Add(list[index]);
			list.RemoveAt(index);
		}
	}

	private CropType GetCropForBioSlot(BiofuelSlot slot)
	{
		if (slot == null)
		{
			return CropType.None;
		}
		SortListOfCrops();
		BiofuelConverter converterScript = slot.converterScript;
		for (int i = 0; i < cropsAndSeedsInInventory.Count; i++)
		{
			if (cropsAndSeedsInInventory[i].cropAmount > 0 && cropsAndSeedsInInventory[i].cropType != converterScript.allSlots[0].cropType && cropsAndSeedsInInventory[i].cropType != converterScript.allSlots[1].cropType && cropsAndSeedsInInventory[i].cropType != converterScript.allSlots[2].cropType)
			{
				return cropsAndSeedsInInventory[i].cropType;
			}
		}
		return CropType.None;
	}

	private IEnumerator StockBiofuel(BiofuelSlot slot, CropType crop)
	{
		slot.cropType = crop;
		slot.state = BiofuelSlot.State.MarkedForStock;
		targetBiofuelSlot = slot;
		Inventory.ins.AddToCropInventory(crop, -1);
		Sprite bestCropSprite = GameManager.ins.getCropSprite(crop);
		Vector2 bioSlotTarget = slot.transform.position;
		Vector2 closestStorage = GameManager.ins.getClosestStorage(bioSlotTarget);
		Vector2 closestStorage2 = GameManager.ins.getClosestStorage(base.transform.position);
		Vector2 vector = closestStorage;
		if (Vector2.Distance(base.transform.position, closestStorage2) < Vector2.Distance(base.transform.position, closestStorage))
		{
			vector = closestStorage2;
		}
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetDirection(bioSlotTarget);
		SetAnimation("Carry");
		cropSr.sprite = bestCropSprite;
		yield return new WaitForPositionReached(base.transform, bioSlotTarget, movementSpeed);
		if ((bool)slot)
		{
			slot.AddCropToBiofuelSlot(crop, 1);
			targetBiofuelSlot = null;
			cropSr.sprite = null;
		}
		else
		{
			Vector2 closestStorage3 = GameManager.ins.getClosestStorage(base.transform.position);
			targetBiofuelSlot = null;
			SetDirection(closestStorage3);
			SetAnimation("Carry");
			yield return new WaitForPositionReached(base.transform, closestStorage3, movementSpeed);
			cropSr.sprite = null;
			SetAnimation("Waiting");
			Inventory.ins.AddToCropInventory(crop, 1);
		}
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator Harvest(CropSlot crop)
	{
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForHarvest;
		targetHarvestCrop = crop;
		Vector2 target = crop.transform.position;
		Vector2 vector = Vector2.zero;
		SetDirection(target);
		float num = 0.5f;
		float num2 = 0.25f;
		if (dir == Direction.Right)
		{
			vector = target + Vector2.left * num;
		}
		if (dir == Direction.Left)
		{
			vector = target + Vector2.right * num;
		}
		if (dir == Direction.Down)
		{
			vector = target + Vector2.up * num2;
		}
		if (dir == Direction.Up)
		{
			vector = target + Vector2.down * num2;
		}
		vector += Vector2.up * 0.5f;
		target += Vector2.up * 0.5f;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (!crop || crop.cropType == CropType.None)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(target);
		SetAnimation("Pick");
		Sprite cropSprite = GameManager.ins.getCropSprite(crop.cropType);
		crop.HarvestCropSlot();
		targetHarvestCrop = null;
		yield return new WaitForSeconds(0.2f);
		cropSr.sprite = cropSprite;
		yield return new WaitForSeconds(0.1f);
		Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
		SetDirection(closestStorage);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, closestStorage, movementSpeed);
		cropSr.sprite = null;
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator Water(CropSlot crop)
	{
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForWatering;
		targetWaterCrop = crop;
		if (charges <= 0)
		{
			yield return GetWater();
		}
		Vector2 target = crop.transform.position;
		Vector2 vector = Vector2.zero;
		SetDirection(target);
		float num = 1f;
		float num2 = 0.5f;
		if (dir == Direction.Right)
		{
			vector = target + Vector2.left * num;
		}
		if (dir == Direction.Left)
		{
			vector = target + Vector2.right * num;
		}
		if (dir == Direction.Down)
		{
			vector = target + Vector2.up * num2;
		}
		if (dir == Direction.Up)
		{
			vector = target + Vector2.down * num2;
		}
		vector += Vector2.up * 0.5f;
		target += Vector2.up * 0.5f;
		SetDirection(vector + Vector2.up * 0.5f);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetDirection(target);
		SetAnimation("Water");
		yield return new WaitForSeconds(1f);
		charges--;
		if ((bool)crop && crop.cropType != CropType.None)
		{
			crop.WaterCropSlot();
		}
		targetWaterCrop = null;
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator GetWater()
	{
		WaterSource water = GameManager.ins.getClosestWaterSource(base.transform.position);
		Vector2 closestPointOnWaterSourceCollider = GameManager.ins.getClosestPointOnWaterSourceCollider(water, base.transform.position);
		SetDirection(closestPointOnWaterSourceCollider);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, closestPointOnWaterSourceCollider, movementSpeed);
		if (water == null)
		{
			StartCoroutine(GetWater());
			yield break;
		}
		SetAnimation("Crouch");
		yield return new WaitForSeconds(0.5f);
		charges = GameManager.ins.chatterCharges;
	}

	private IEnumerator Feed(FeederSlot feedSlot, CropType crop)
	{
		if ((bool)this)
		{
			feedSlot.state = FeederSlot.State.MarkedForStock;
			targetFeederSlot = feedSlot;
			Vector2 feedSlotTarget = feedSlot.transform.position;
			Inventory.ins.AddToCropInventory(crop, -1);
			Sprite cropSprite = GameManager.ins.getCropSprite(crop);
			Vector2 closestStorage = GameManager.ins.getClosestStorage(feedSlotTarget);
			Vector2 closestStorage2 = GameManager.ins.getClosestStorage(base.transform.position);
			Vector2 vector = closestStorage;
			if (Vector2.Distance(base.transform.position, closestStorage2) < Vector2.Distance(base.transform.position, closestStorage))
			{
				vector = closestStorage2;
			}
			SetDirection(vector);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
			SetDirection(feedSlotTarget);
			SetAnimation("Carry");
			cropSr.sprite = cropSprite;
			yield return new WaitForPositionReached(base.transform, feedSlotTarget, movementSpeed);
			if ((bool)feedSlot)
			{
				feedSlot.AddCropToFeederSlot(crop, 1);
				cropSr.sprite = null;
				SetAnimation("Waiting");
			}
			else
			{
				Vector2 closestStorage3 = GameManager.ins.getClosestStorage(base.transform.position);
				SetDirection(closestStorage3);
				SetAnimation("Carry");
				yield return new WaitForPositionReached(base.transform, closestStorage3, movementSpeed);
				cropSr.sprite = null;
				SetAnimation("Waiting");
				Inventory.ins.AddToCropInventory(crop, 1);
			}
			targetFeederSlot = null;
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator Collect(Poop poop)
	{
		if ((bool)this)
		{
			targetPoop = poop;
			poop.state = Poop.State.MarkedForCollection;
			Vector2 vector = poop.transform.position;
			SetDirection(vector);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
			SetAnimation("Pick");
			yield return new WaitForSeconds(0.2f);
			cropSr.sprite = poopSprite;
			poop.HarvestPoop();
			targetPoop = null;
			int amount = 3;
			Inventory.ins.AddFertilizer(amount);
			GameManager.ins.SpawnFertilizerPopUp((Vector2)base.transform.position + Vector2.up, amount);
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(TakePoopToHouse());
		}
	}

	private IEnumerator TakePoopToHouse()
	{
		if ((bool)this)
		{
			Vector2 closestFertilizerFacility = GameManager.ins.getClosestFertilizerFacility(base.transform.position);
			SetDirection(closestFertilizerFacility);
			SetAnimation("Carry");
			yield return new WaitForPositionReached(base.transform, closestFertilizerFacility, movementSpeed);
			cropSr.sprite = null;
			SetAnimation("Waiting");
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator Fertilize(CropSlot fertSlot)
	{
		if (!this)
		{
			yield break;
		}
		if (Inventory.ins.fertilizer <= 0)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		Inventory.ins.AddFertilizer(-1);
		fertSlot.markedForFertilizing = true;
		targetFertSlot = fertSlot;
		Vector2 fertSlotTarget = fertSlot.transform.position;
		Vector2 closestFertilizerFacility = GameManager.ins.getClosestFertilizerFacility(fertSlotTarget);
		Vector2 closestFertilizerFacility2 = GameManager.ins.getClosestFertilizerFacility(base.transform.position);
		Vector2 vector = closestFertilizerFacility;
		if (Vector2.Distance(base.transform.position, closestFertilizerFacility2) < Vector2.Distance(base.transform.position, closestFertilizerFacility))
		{
			vector = closestFertilizerFacility2;
		}
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		cropSr.sprite = poopSprite;
		SetDirection(fertSlotTarget);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, fertSlotTarget, movementSpeed);
		if ((bool)fertSlot && fertSlot.fertilizedTimer <= 0f)
		{
			SetAnimation("Crouch");
			cropSr.sprite = null;
			GameManager.ins.SpawnFertilizerPopUp(base.transform.position + Vector3.up, -1);
			fertSlot.FertilizeSoil();
			yield return new WaitForSeconds(0.3f);
			SetAnimation("Waiting");
			targetFertSlot = null;
		}
		StartCoroutine(WaitForNextAction());
	}

	public void NeedsRest()
	{
		needsRest = true;
	}

	private IEnumerator RestOnBench(Bench bench)
	{
		if (bench == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(bench.transform.position);
		SetAnimation("Walk");
		bench.SetOccupied(state: true);
		yield return new WaitForPositionReached(base.transform, bench.transform.position, movementSpeed);
		workerAnim.Play("Bench");
		yield return new WaitForSeconds(45f);
		if (bench == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(bench.transform.position + Vector3.down);
		SetAnimation("Walk");
		bench.SetOccupied(state: false);
		needsRest = false;
		yield return new WaitForPositionReached(base.transform, bench.transform.position + Vector3.down * 0.5f, movementSpeed);
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator GoToBerryBush(BerryBush bush)
	{
		if (bush == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		targetBush = bush;
		targetBush.state = BerryBush.State.MarkedForHarvest;
		Vector2 vector = bush.transform.position + Vector3.right * 0.5625f;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (bush == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetAnimation("Pick");
		bush.Harvest();
		yield return new WaitForSeconds(0.2f);
		cropSr.sprite = bush.cropSO.cropSprite;
		targetBush = null;
		yield return new WaitForSeconds(0.1f);
		Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
		SetDirection(closestStorage);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, closestStorage, movementSpeed);
		cropSr.sprite = null;
		SetAnimation("Waiting");
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator MoveBox(BuildingBox box)
	{
		if (box == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		Vector2 vector = box.transform.position + new Vector3(0.5625f, 0.5625f);
		SetDirection(vector);
		SetAnimation("Walk");
		box.state = BuildingBox.State.MarkedForMoving;
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Pick");
		yield return new WaitForSeconds(0.2f);
		box.PickUpBox();
		cropSr.sprite = buildingBoxSprite;
		yield return new WaitForSeconds(0.1f);
		Vector2 vector2 = box.target + new Vector2(0.5625f, 0.5625f);
		SetDirection(vector2);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, vector2, movementSpeed);
		box.PutDownBox();
		cropSr.sprite = null;
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator Plant(CropSlot crop)
	{
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForSeeding;
		targetPlantSlot = crop;
		Vector2 vector = crop.transform.position;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Crouch");
		yield return new WaitForSeconds(0.3f);
		if ((bool)crop && crop.state == CropSlot.State.MarkedForSeeding)
		{
			CropType cropType = CropType.None;
			int num = 0;
			if (crop.cropPatchParent.cropSign != null)
			{
				if (crop.cropPatchParent.cropSign.getCropType() == CropType.DontSeedSign)
				{
					crop.state = CropSlot.State.Empty;
					targetPlantSlot = null;
					StartCoroutine(WaitForNextAction());
					yield break;
				}
				CropSO cropSO = crop.cropPatchParent.cropSign.getCropSO();
				if (cropSO != null)
				{
					cropType = cropSO.cropType;
					num = cropSO.cropCost;
				}
			}
			if (cropType == CropType.None)
			{
				cropType = GetRandomCropFromTheLastX();
				num = GameManager.ins.getCropSO(cropType).cropCost;
			}
			if (Inventory.ins.spareParts < num)
			{
				crop.state = CropSlot.State.Empty;
				targetPlantSlot = null;
				StartCoroutine(WaitForNextAction());
				yield break;
			}
			crop.PlantSeed(cropType, playSound: false);
			yield return new WaitForSeconds(0.5f);
		}
		targetPlantSlot = null;
		StartCoroutine(WaitForNextAction());
	}

	private CropType GetRandomCropFromTheLastX()
	{
		int x = 8;
		List<CropType> listOfCropsFromTheLastX = Inventory.ins.GetListOfCropsFromTheLastX(x);
		return listOfCropsFromTheLastX[Random.Range(0, listOfCropsFromTheLastX.Count)];
	}

	private void SetAnimation(string newState)
	{
		workerAnim.Play(newState + GetDirectionForAnim());
	}

	private void SetDirection(Vector2 target)
	{
		Vector2 to = target - (Vector2)base.transform.position;
		float num = Vector2.SignedAngle(Vector2.right, to);
		if (num >= -45f && num < 45f)
		{
			dir = Direction.Right;
		}
		if (num >= 135f || num < -135f)
		{
			dir = Direction.Left;
		}
		if (num >= 45f && num < 135f)
		{
			dir = Direction.Up;
		}
		if (num >= -135f && num < -45f)
		{
			dir = Direction.Down;
		}
	}

	private string GetDirectionForAnim()
	{
		if (dir == Direction.Down)
		{
			return "Down";
		}
		if (dir == Direction.Up)
		{
			return "Up";
		}
		if (dir == Direction.Right)
		{
			return "Right";
		}
		if (dir == Direction.Left)
		{
			return "Left";
		}
		return "";
	}

	private void PickRandomColor(bool subbed)
	{
		if (subbed)
		{
			ChangeColorToGold();
			return;
		}
		int num = Random.Range(0, 7);
		if (num == 0)
		{
			ChangeColorToPurple();
		}
		if (num == 1)
		{
			ChangeColorToPink();
		}
		if (num == 2)
		{
			ChangeColorToBlue();
		}
		if (num == 3)
		{
			ChangeColorToGreen();
		}
		if (num == 4)
		{
			ChangeColorToOrange();
		}
		if (num == 5)
		{
			ChangeColorToRed();
		}
		if (num == 6)
		{
			ChangeColorToGray();
		}
	}

	public void ChangeColorToPurple()
	{
		workerAnim.runtimeAnimatorController = purpleAnim;
		nameTagText.color = purple;
		goldParticles.Stop();
	}

	public void ChangeColorToPink()
	{
		workerAnim.runtimeAnimatorController = pinkAnim;
		nameTagText.color = pink;
		goldParticles.Stop();
	}

	public void ChangeColorToBlue()
	{
		workerAnim.runtimeAnimatorController = blueAnim;
		nameTagText.color = blue;
		goldParticles.Stop();
	}

	public void ChangeColorToGreen()
	{
		workerAnim.runtimeAnimatorController = greenAnim;
		nameTagText.color = green;
		goldParticles.Stop();
	}

	public void ChangeColorToOrange()
	{
		workerAnim.runtimeAnimatorController = yellowAnim;
		nameTagText.color = yellow;
		goldParticles.Stop();
	}

	public void ChangeColorToRed()
	{
		workerAnim.runtimeAnimatorController = redAnim;
		nameTagText.color = red;
		goldParticles.Stop();
	}

	public void ChangeColorToGray()
	{
		workerAnim.runtimeAnimatorController = grayAnim;
		nameTagText.color = gray;
		goldParticles.Stop();
	}

	public void ChangeColorToGold()
	{
		workerAnim.runtimeAnimatorController = goldAnim;
		nameTagText.color = gold;
		goldParticles.Play();
	}

	public void PlayEmoteParticles(Texture2D img)
	{
		emoteParticlesRenderer.material.mainTexture = img;
		emoteParticles.Play();
	}

	private void OnDestroy()
	{
		if (targetBuilding != null && targetBuilding.state == Building.State.MarkedForBuilding)
		{
			targetBuilding.state = Building.State.NeedsBuilding;
		}
		if (targetBiofuelSlot != null && targetBiofuelSlot.state == BiofuelSlot.State.MarkedForStock)
		{
			targetBiofuelSlot.state = BiofuelSlot.State.Empty;
		}
		if (targetHarvestCrop != null && targetHarvestCrop.state == CropSlot.State.MarkedForHarvest)
		{
			targetHarvestCrop.state = CropSlot.State.NeedHarvest;
		}
		if (targetWaterCrop != null && targetWaterCrop.state == CropSlot.State.MarkedForWatering)
		{
			targetWaterCrop.state = CropSlot.State.NeedWater;
		}
		if (targetFeederSlot != null && targetFeederSlot.state == FeederSlot.State.MarkedForStock)
		{
			targetFeederSlot.state = FeederSlot.State.Empty;
		}
		if (targetPoop != null && targetPoop.state == Poop.State.MarkedForCollection)
		{
			targetPoop.state = Poop.State.NeedsCollecting;
		}
		if (targetFertSlot != null && targetFertSlot.markedForFertilizing)
		{
			targetFertSlot.markedForFertilizing = false;
		}
		if (targetBush != null && targetBush.state == BerryBush.State.MarkedForHarvest)
		{
			targetBush.state = BerryBush.State.Empty;
		}
		if (targetPlantSlot != null && targetPlantSlot.state == CropSlot.State.MarkedForSeeding)
		{
			targetPlantSlot.state = CropSlot.State.Empty;
		}
	}
}
