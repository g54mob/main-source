using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class WorkerAI : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	public enum Action
	{
		MoveBox = 0,
		Build = 1,
		Stock = 2,
		Harvest = 3,
		Water = 4
	}

	[SerializeField]
	private CharacterInteraction interactionScript;

	[Header("Levels")]
	[SerializeField]
	private int wateringCan;

	[SerializeField]
	private float movementSpeed;

	[Header("Target")]
	[SerializeField]
	private Transform target;

	[Header("Visuals")]
	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private Animator hatAnim;

	[SerializeField]
	private SpriteRenderer cropSr;

	[SerializeField]
	private Sprite buildingBoxSprite;

	[SerializeField]
	private BuildingProgressBar buildBar;

	[SerializeField]
	private GameObject buildBarBG;

	[Header("Overrides")]
	[SerializeField]
	private bool haikuTheRobot;

	[Space]
	[SerializeField]
	private bool needsRest;

	[SerializeField]
	private bool speedBoost;

	[Space]
	[SerializeField]
	private AnimatorOverrideController goldenSkin;

	[SerializeField]
	private GameObject goldenParticles;

	[Header("Crossover visuals")]
	[SerializeField]
	private CrossoverSkin[] crossoverSkins;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WATER = "Water";

	private const string REFILL = "Refill";

	private const string PICK = "Pick";

	private const string WAIT = "Waiting";

	private const string IDLE = "Idle";

	private const string CARRY = "Carry";

	private const string SIT = "Sit";

	private const string BUILD = "Build";

	private const string BENCH = "Bench";

	public List<Action> actions;

	private bool pickedAction;

	private List<PlantSeedButton> cropsAndSeedsInInventory;

	private void Start()
	{
		cropSr.sprite = null;
		cropsAndSeedsInInventory = new List<PlantSeedButton>();
		StartCoroutine(WaitForNextAction());
		Invoke("NeedsRest", UnityEngine.Random.Range(1600, 2000));
		if (SaveData.ins.checkIfCrossover())
		{
			ChangeAnimatorControllerForCrossover();
			return;
		}
		StartCoroutine(CheckIfSupporterDLC());
		CheckChristmasHat();
	}

	private IEnumerator CheckIfSupporterDLC()
	{
		int counter = 0;
		while (!SteamManager.Initialized)
		{
			yield return null;
			counter++;
			if (counter >= 500)
			{
				yield break;
			}
		}
		if (SteamApps.BIsDlcInstalled(new AppId_t(2943560u)))
		{
			if ((bool)goldenSkin)
			{
				workerAnim.runtimeAnimatorController = goldenSkin;
			}
			if ((bool)goldenParticles)
			{
				goldenParticles.SetActive(value: true);
			}
		}
	}

	private void CheckChristmasHat()
	{
		if (DateTime.Now.Month == 12 && (bool)hatAnim)
		{
			hatAnim.gameObject.SetActive(value: true);
		}
	}

	private void PickNextAction()
	{
		pickedAction = false;
		BlockedLand blockedLandMarkedForClearing = GameManager.ins.getBlockedLandMarkedForClearing();
		if ((bool)blockedLandMarkedForClearing)
		{
			StartCoroutine(ClearLand(blockedLandMarkedForClearing));
			pickedAction = true;
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
		for (int i = 0; i < actions.Count; i++)
		{
			if (actions[i] == Action.MoveBox)
			{
				BuildingBox closestBuildingBoxThat = GameManager.ins.getClosestBuildingBoxThat(BuildingBox.State.NeedsMoving, base.transform.position);
				if ((bool)closestBuildingBoxThat)
				{
					StartCoroutine(MoveBox(closestBuildingBoxThat));
					pickedAction = true;
					break;
				}
			}
			if (actions[i] == Action.Build)
			{
				if (GameManager.ins.housesToBeBuilt.Count > 0 && !haikuTheRobot)
				{
					StartCoroutine(BuildHouse(GameManager.ins.housesToBeBuilt[0]));
					pickedAction = true;
					break;
				}
				Building closestBuildSlotThat = GameManager.ins.getClosestBuildSlotThat(Building.State.NeedsBuilding, base.transform.position);
				if ((bool)closestBuildSlotThat)
				{
					StartCoroutine(Build(closestBuildSlotThat));
					pickedAction = true;
					break;
				}
			}
			if (actions[i] == Action.Stock)
			{
				BiofuelSlot closestBiofuelSlotThat = GameManager.ins.getClosestBiofuelSlotThat(BiofuelSlot.State.Empty, base.transform.position);
				CropType cropForBioSlot = GetCropForBioSlot(closestBiofuelSlotThat);
				if ((bool)closestBiofuelSlotThat && cropForBioSlot != CropType.None)
				{
					StartCoroutine(StockBiofuel(closestBiofuelSlotThat, cropForBioSlot));
					pickedAction = true;
					break;
				}
			}
			if (actions[i] == Action.Harvest)
			{
				CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position);
				if ((bool)closestCropSlotThat)
				{
					StartCoroutine(Harvest(closestCropSlotThat));
					pickedAction = true;
					break;
				}
			}
			if (actions[i] == Action.Water)
			{
				CropSlot closestCropSlotThat2 = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedWater, base.transform.position);
				if ((bool)closestCropSlotThat2)
				{
					StartCoroutine(Water(closestCropSlotThat2));
					pickedAction = true;
					break;
				}
			}
		}
		if (!pickedAction)
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator ClearLand(BlockedLand blockedLand)
	{
		if (blockedLand == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		int loops = blockedLand.objectsToClear.Count;
		blockedLand.ChangeStateTo(BlockedLand.State.IsClearing);
		for (int i = 0; i < loops; i++)
		{
			GameObject debris = blockedLand.getClosestDebrisTo(base.transform.position);
			Vector2 vector = debris.transform.position + Vector3.left;
			SetDirection(vector);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
			workerAnim.Play("Build");
			if ((bool)hatAnim)
			{
				hatAnim.Play("Build");
			}
			int num = 2;
			if (UnityEngine.Random.value < 0.33f)
			{
				num = 1;
			}
			if (UnityEngine.Random.value > 0.67f)
			{
				num = 3;
			}
			yield return new WaitForSeconds(0.6f * (float)num);
			blockedLand.RemoveDebrisFromList(debris);
		}
		blockedLand.FinishClearingLand();
		PickNextAction();
	}

	private IEnumerator BuildHouse(House house)
	{
		if (house == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		GameManager.ins.housesToBeBuilt.RemoveAt(0);
		Vector2 vector = house.transform.position;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (house == null)
		{
			PickNextAction();
			yield break;
		}
		workerAnim.Play("Build");
		if ((bool)hatAnim && hatAnim.gameObject.activeSelf)
		{
			hatAnim.Play("Build");
		}
		int num = 300;
		if (SaveData.ins.focusMode)
		{
			num *= 2;
		}
		house.StartBuilding();
		buildBar.BuildFor(num);
		yield return new WaitForSeconds(num);
		house.CompleteBuild();
		buildBar.ResetBuildBar();
		SetAnimation("Idle");
		yield return new WaitForSeconds(1f);
		buildBar.ResetBuildBar();
		PickNextAction();
	}

	private IEnumerator Build(Building building)
	{
		if (building == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		building.state = Building.State.MarkedForBuilding;
		Vector2 vector = building.center.position;
		if (building.boxes != null && building.boxes.Length != 0)
		{
			vector = building.boxes[UnityEngine.Random.Range(0, building.boxes.Length)].transform.position;
		}
		Vector2 vector2 = new Vector2(-0.25f, 0.375f);
		if (haikuTheRobot)
		{
			vector2 = new Vector2(-0.5f, -0.125f);
		}
		vector += vector2;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (building == null)
		{
			PickNextAction();
			yield break;
		}
		workerAnim.Play("Build");
		if ((bool)hatAnim)
		{
			hatAnim.Play("Build");
		}
		int num = building.building.constructionTime * 60;
		if (building.building.name == "Crop Patch 1x1")
		{
			num = (int)((float)num * 0.5f);
		}
		if (building.building.name == "Crop Patch 2x2")
		{
			num = (int)((float)num * 0.75f);
		}
		if (SaveData.ins.focusMode)
		{
			num *= 2;
		}
		if (!GameManager.ins.firstBuild)
		{
			GameManager.ins.firstBuild = true;
			num = 30;
		}
		if ((bool)building)
		{
			building.StartBuilding();
		}
		buildBar.BuildFor(num);
		yield return new WaitForSeconds(num);
		if ((bool)building)
		{
			building.CompleteBuild();
		}
		buildBar.ResetBuildBar();
		SetAnimation("Idle");
		yield return new WaitForSeconds(1f);
		buildBar.ResetBuildBar();
		PickNextAction();
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
			int index = UnityEngine.Random.Range(0, list.Count);
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
			cropSr.sprite = null;
		}
		else
		{
			Vector2 closestStorage3 = GameManager.ins.getClosestStorage(base.transform.position);
			SetDirection(closestStorage3);
			SetAnimation("Carry");
			yield return new WaitForPositionReached(base.transform, closestStorage3, movementSpeed);
			cropSr.sprite = null;
			SetAnimation("Idle");
			Inventory.ins.AddToCropInventory(crop, 1);
		}
		PickNextAction();
	}

	private IEnumerator Harvest(CropSlot crop)
	{
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForHarvest;
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
			PickNextAction();
			yield break;
		}
		SetDirection(target);
		SetAnimation("Pick");
		Sprite cropSprite = GameManager.ins.getCropSprite(crop.cropType);
		crop.HarvestCropSlot();
		yield return new WaitForSeconds(0.2f);
		cropSr.sprite = cropSprite;
		yield return new WaitForSeconds(0.1f);
		Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
		SetDirection(closestStorage);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, closestStorage, movementSpeed);
		cropSr.sprite = null;
		PickNextAction();
	}

	private IEnumerator Water(CropSlot crop)
	{
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForWatering;
		if (wateringCan <= 0)
		{
			yield return GetWater();
		}
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		Vector2 target = crop.transform.position;
		Vector2 vector = Vector2.zero;
		SetDirection(target);
		float num = 1.5f;
		float num2 = 1f;
		if (haikuTheRobot)
		{
			num = 1f;
			num2 = 0.5f;
		}
		if (checkCrossoverOffset(out var offsetX, out var offsetY))
		{
			num = offsetX;
			num2 = offsetY;
		}
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
		wateringCan--;
		if ((bool)crop && crop.cropType != CropType.None)
		{
			crop.WaterCropSlot();
		}
		PickNextAction();
	}

	private IEnumerator GetWater()
	{
		WaterSource closestWaterSource = GameManager.ins.getClosestWaterSource(base.transform.position);
		Vector2 closestPointOnWaterSourceCollider = GameManager.ins.getClosestPointOnWaterSourceCollider(closestWaterSource, base.transform.position);
		SetDirection(closestPointOnWaterSourceCollider);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, closestPointOnWaterSourceCollider, movementSpeed);
		SetAnimation("Refill");
		yield return new WaitForSeconds(0.5f);
		wateringCan = GameManager.ins.maxWaterUses;
	}

	public void NeedsRest()
	{
		needsRest = true;
		float time = 1800f;
		if (!haikuTheRobot)
		{
			if (GameManager.ins.bots.Count > 20)
			{
				time = 1500f;
			}
			if (GameManager.ins.bots.Count > 40)
			{
				time = 1200f;
			}
			if (GameManager.ins.bots.Count > 60)
			{
				time = 900f;
			}
			if (GameManager.ins.bots.Count > 80)
			{
				time = 600f;
			}
		}
		Invoke("NeedsRest", time);
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
		if ((bool)hatAnim)
		{
			hatAnim.Play("Bench");
		}
		float seconds = 60f;
		if (!haikuTheRobot)
		{
			if (GameManager.ins.bots.Count > 20)
			{
				seconds = 90f;
			}
			if (GameManager.ins.bots.Count > 40)
			{
				seconds = 120f;
			}
			if (GameManager.ins.bots.Count > 60)
			{
				seconds = 150f;
			}
			if (GameManager.ins.bots.Count > 80)
			{
				seconds = 180f;
			}
		}
		yield return new WaitForSeconds(seconds);
		if (bench == null)
		{
			PickNextAction();
			yield break;
		}
		SetDirection(bench.transform.position + Vector3.down);
		SetAnimation("Walk");
		bench.SetOccupied(state: false);
		needsRest = false;
		StartSpeedBoost();
		yield return new WaitForPositionReached(base.transform, bench.transform.position + Vector3.down * 0.5f, movementSpeed);
		PickNextAction();
	}

	private void StartSpeedBoost()
	{
		if (!speedBoost)
		{
			speedBoost = true;
			movementSpeed = 1.25f;
			Invoke("EndSpeedBoost", 300f);
		}
	}

	private void EndSpeedBoost()
	{
		speedBoost = false;
		movementSpeed = 1f;
	}

	private IEnumerator MoveBox(BuildingBox box)
	{
		if (box == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		Vector2 vector = box.transform.position + new Vector3(0.5625f, 0.5625f);
		Vector2 newBoxLocation = box.target + new Vector2(0.5625f, 0.5625f);
		SetDirection(vector);
		SetAnimation("Walk");
		box.state = BuildingBox.State.MarkedForMoving;
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Pick");
		yield return new WaitForSeconds(0.2f);
		if ((bool)box)
		{
			box.PickUpBox();
		}
		cropSr.sprite = buildingBoxSprite;
		yield return new WaitForSeconds(0.1f);
		SetDirection(newBoxLocation);
		SetAnimation("Carry");
		yield return new WaitForPositionReached(base.transform, newBoxLocation, movementSpeed);
		if ((bool)box)
		{
			box.PutDownBox();
		}
		cropSr.sprite = null;
		PickNextAction();
	}

	private IEnumerator WaitForNextAction()
	{
		SetAnimation("Waiting");
		yield return new WaitForSeconds(0.5f);
		interactionScript.isBusy = false;
		yield return new WaitForSeconds(0.5f);
		interactionScript.isBusy = true;
		if (!interactionScript.isTalking)
		{
			PickNextAction();
		}
	}

	private IEnumerator MeetCharacter(CharacterInteraction npc)
	{
		interactionScript.lastNpc = npc;
		npc.lastNpc = interactionScript;
		interactionScript.isTalking = true;
		npc.isTalking = true;
		npc.TriggerWalkToMeetCharacter(base.transform.position);
		yield return WalkToMeetCharacter(npc.transform.position);
		for (int i = 0; i < 3; i++)
		{
			npc.PlayTopic();
			yield return new WaitForSeconds(5f);
			npc.StopTopic();
			interactionScript.PlayTopic();
			yield return new WaitForSeconds(5f);
			interactionScript.StopTopic();
		}
		interactionScript.isTalking = false;
		npc.isTalking = false;
		npc.TriggerEndOfTalk();
		StartCoroutine(WaitForNextAction());
	}

	public IEnumerator WalkToMeetCharacter(Vector3 othernpcPosition)
	{
		Vector2 vector = (base.transform.position + othernpcPosition) / 2f;
		Vector2 vector2 = othernpcPosition - base.transform.position;
		_ = vector + vector2.normalized * 0.75f;
		Vector2 vector3 = ((!(base.transform.position.x < vector.x)) ? (vector + Vector2.right * 0.75f) : (vector + Vector2.left * 0.75f));
		SetDirection(vector3);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector3, 1.2f);
		SetDirection(base.transform.position + Vector3.down);
		SetAnimation("Waiting");
	}

	public void FinishTalking()
	{
		StartCoroutine(WaitForNextAction());
	}

	private bool checkCrossoverOffset(out float offsetX, out float offsetY)
	{
		offsetX = 1.5f;
		offsetY = 1f;
		if (SaveData.ins.crossoverFarmType == CrossoverFarmType.VampireSurvivors)
		{
			offsetX = 0.5f;
		}
		return SaveData.ins.checkIfCrossover();
	}

	private void ChangeAnimatorControllerForCrossover()
	{
		SaveData.ins.checkIfCrossover(out var crossover);
		for (int i = 0; i < crossoverSkins.Length; i++)
		{
			if (crossoverSkins[i].crossover == crossover)
			{
				workerAnim.runtimeAnimatorController = crossoverSkins[i].skin;
				break;
			}
		}
		SetDirection(base.transform.position + Vector3.right);
		SetAnimation("Waiting");
		if (crossover == CrossoverFarmType.VampireSurvivors && haikuTheRobot)
		{
			workerAnim.transform.localPosition -= Vector3.up * 0.25f;
			cropSr.transform.localPosition += Vector3.up * 0.5f;
			buildBar.transform.localPosition += Vector3.up * 0.5f;
			buildBarBG.transform.localPosition += Vector3.up * 0.5f;
		}
		if (crossover == CrossoverFarmType.Balatro && haikuTheRobot)
		{
			workerAnim.transform.localPosition -= Vector3.up * 0.25f;
			cropSr.transform.localPosition += Vector3.up * 0.375f;
			buildBar.transform.localPosition += Vector3.up * 0.375f;
			buildBarBG.transform.localPosition += Vector3.up * 0.375f;
		}
	}

	private void SetAnimation(string newState)
	{
		workerAnim.Play(newState + GetDirectionForAnim());
		if ((bool)hatAnim && hatAnim.gameObject.activeInHierarchy)
		{
			hatAnim.Play(newState + GetDirectionForAnim());
		}
	}

	private void SetDirection(Vector2 target)
	{
		Vector2 to = target - (Vector2)base.transform.position;
		float num = Vector2.SignedAngle(Vector2.right, to);
		if (SaveData.ins.checkIfCrossover())
		{
			if (target.x > base.transform.position.x)
			{
				dir = Direction.Right;
			}
			else
			{
				dir = Direction.Left;
			}
			return;
		}
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
}
