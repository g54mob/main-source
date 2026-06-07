using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBotAI : MonoBehaviour
{
	public enum State
	{
		Working = 0,
		Charged = 1,
		NeedsCharging = 2,
		Charging = 3
	}

	public State state;

	private BiofuelSlot targetBioSlot;

	[SerializeField]
	private Building buildingScript;

	[SerializeField]
	private Transform parentStation;

	[SerializeField]
	private RechargeBar rechargeBar;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private SpriteRenderer[] cropSr;

	[SerializeField]
	private int charges;

	[SerializeField]
	private int carryCapacity;

	private int currentCarryAmount;

	[SerializeField]
	private int rechargingTimeInSeconds = 16;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float range = 10f;

	private const string IDLE = "Idle";

	private const string CARRY = "Carry";

	private const string STATION = "Station";

	private const string UNSTATION = "Unstation";

	private List<BiofuelConverter> biofuelConverters;

	private List<PlantSeedButton> cropsAndSeedsInInventory;

	private void Start()
	{
		biofuelConverters = new List<BiofuelConverter>();
		cropsAndSeedsInInventory = new List<PlantSeedButton>();
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		PickNextAction();
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("carry");
	}

	private void PickNextAction()
	{
		if ((bool)this)
		{
			if (state == State.NeedsCharging)
			{
				StartCoroutine(TryRecharge());
				return;
			}
			if (!buildingScript.buildingEnabled)
			{
				StartCoroutine(DockAndWait());
				return;
			}
			SortListOfBiofuelConverters();
			SortListOfCrops();
			TryToStockEmptySlot();
		}
	}

	private void SortListOfBiofuelConverters()
	{
		if (biofuelConverters.Count > 0)
		{
			biofuelConverters.Clear();
		}
		for (int i = 0; i < GameManager.ins.bioConverters.Count; i++)
		{
			if (Vector2.Distance(GameManager.ins.bioConverters[i].transform.position, parentStation.position) < range)
			{
				biofuelConverters.Add(GameManager.ins.bioConverters[i]);
			}
		}
		biofuelConverters.Sort((BiofuelConverter a, BiofuelConverter b) => Vector2.Distance(base.transform.position, a.transform.position).CompareTo(Vector2.Distance(base.transform.position, b.transform.position)));
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
			if (Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Blackberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.BlackCurrant && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Blueberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Boysenberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Cloudberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Raspberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.RedCurrant && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.RedGooseberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Strawberry && Inventory.ins.cropAndSeedInventory[i].cropAmount >= 1)
			{
				list.Add(Inventory.ins.cropAndSeedInventory[i]);
			}
		}
		for (int j = 0; j < Inventory.ins.cropAndSeedInventory.Count && Inventory.ins.cropAndSeedInventory[j].cropType != CropType.Wheat; j++)
		{
			if (Inventory.ins.cropAndSeedInventory[j].cropAmount >= 1)
			{
				list.Add(Inventory.ins.cropAndSeedInventory[j]);
			}
		}
		if (list.Count > 3)
		{
			list.RemoveAt(0);
		}
		int count = list.Count;
		for (int k = 0; k < count; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			cropsAndSeedsInInventory.Add(list[index]);
			list.RemoveAt(index);
		}
	}

	private void TryToStockEmptySlot()
	{
		BiofuelSlot biofuelSlot = null;
		CropType cropType = CropType.None;
		for (int i = 0; i < biofuelConverters.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < biofuelConverters[i].allSlots.Length; j++)
			{
				if (biofuelConverters[i].allSlots[j].state == BiofuelSlot.State.Empty)
				{
					flag = true;
					biofuelSlot = biofuelConverters[i].allSlots[j];
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			bool flag2 = false;
			for (int k = 0; k < cropsAndSeedsInInventory.Count; k++)
			{
				if (cropsAndSeedsInInventory[k].cropAmount > 0 && cropsAndSeedsInInventory[k].cropType != biofuelConverters[i].allSlots[0].cropType && cropsAndSeedsInInventory[k].cropType != biofuelConverters[i].allSlots[1].cropType && cropsAndSeedsInInventory[k].cropType != biofuelConverters[i].allSlots[2].cropType)
				{
					flag2 = true;
					cropType = cropsAndSeedsInInventory[k].cropType;
				}
			}
			if (flag2)
			{
				biofuelSlot.cropType = cropType;
				biofuelSlot.state = BiofuelSlot.State.MarkedForStock;
				break;
			}
		}
		if (biofuelSlot != null && cropType != CropType.None)
		{
			StartCoroutine(StockBiofuel(biofuelSlot, cropType));
		}
		else
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator StockBiofuel(BiofuelSlot slot, CropType crop)
	{
		if (!this)
		{
			yield break;
		}
		targetBioSlot = slot;
		Vector2 bioSlotTarget = slot.transform.position;
		SpendCropsFromInventory(crop);
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		Sprite bestCropSprite = GameManager.ins.getCropSprite(crop);
		Vector2 closestStorage = GameManager.ins.getClosestStorage(bioSlotTarget);
		Vector2 closestStorage2 = GameManager.ins.getClosestStorage(base.transform.position);
		Vector2 vector = closestStorage;
		if (Vector2.Distance(base.transform.position, closestStorage2) < Vector2.Distance(base.transform.position, closestStorage))
		{
			vector = closestStorage2;
		}
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Carry");
		for (int i = 0; i < currentCarryAmount; i++)
		{
			cropSr[i].sprite = bestCropSprite;
		}
		yield return new WaitForPositionReached(base.transform, bioSlotTarget, movementSpeed);
		if ((bool)slot)
		{
			slot.AddCropToBiofuelSlot(crop, currentCarryAmount);
			for (int j = 0; j < cropSr.Length; j++)
			{
				cropSr[j].sprite = null;
			}
			SetAnimation("Idle");
			charges--;
			if (charges <= 0)
			{
				state = State.NeedsCharging;
			}
		}
		else
		{
			Vector2 closestStorage3 = GameManager.ins.getClosestStorage(base.transform.position);
			yield return new WaitForPositionReached(base.transform, closestStorage3, movementSpeed);
			for (int k = 0; k < cropSr.Length; k++)
			{
				cropSr[k].sprite = null;
			}
			SetAnimation("Idle");
			Inventory.ins.AddToCropInventory(crop, currentCarryAmount);
		}
		targetBioSlot = null;
		PickNextAction();
	}

	private void SpendCropsFromInventory(CropType crop)
	{
		int cropInventoryQuantity = Inventory.ins.GetCropInventoryQuantity(crop);
		int num = 0;
		if (carryCapacity >= 1 && cropInventoryQuantity >= 1)
		{
			currentCarryAmount = 1;
			num++;
		}
		if (carryCapacity >= 2 && cropInventoryQuantity >= 2)
		{
			currentCarryAmount = 2;
			num++;
		}
		if (carryCapacity >= 3 && cropInventoryQuantity >= 3)
		{
			currentCarryAmount = 3;
			num++;
		}
		Inventory.ins.AddToCropInventory(crop, -num);
	}

	private IEnumerator WaitForNextAction()
	{
		if (!this)
		{
			yield break;
		}
		if (state == State.Charged)
		{
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
			PickNextAction();
			yield break;
		}
		SetAnimation("Idle");
		Vector2 vector = RandomPointOnXYCircle(base.transform.position, 0.125f);
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
		float x = parentStation.position.x;
		if (vector.x > x + range)
		{
			vector = new Vector2(x + range, vector.y);
		}
		if (vector.x < x - range)
		{
			vector = new Vector2(x - range, vector.y);
		}
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed * 0.1f);
		PickNextAction();
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private IEnumerator TryRecharge()
	{
		if ((bool)this)
		{
			if (base.transform.position != parentStation.position)
			{
				yield return new WaitForPositionReached(base.transform, parentStation.position, movementSpeed);
				SetAnimation("Station");
			}
			while (!buildingScript.buildingEnabled)
			{
				yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
			}
			int biofuelConsumption = buildingScript.getBiofuelConsumption();
			if (Inventory.ins.biofuel < biofuelConsumption)
			{
				rechargeBar.PlayNoBiofuelWarning();
				yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
				StartCoroutine(TryRecharge());
			}
			else
			{
				Inventory.ins.AddBiofuel(-biofuelConsumption);
				SaveData.ins.statsPanel.AddBiofuelConsumption(biofuelConsumption, GameManager.ins.timeElapsed);
				GameManager.ins.SpawnBiofuelPopUp((Vector2)base.transform.position + Vector2.up, -biofuelConsumption);
				yield return DockAndRecharge();
			}
		}
	}

	private IEnumerator DockAndRecharge()
	{
		if ((bool)this)
		{
			state = State.Charging;
			rechargeBar.RechargeFor(rechargingTimeInSeconds * 1000);
			rechargeBar.StopNoBiofuelWarning();
			yield return new WaitForSeconds(rechargingTimeInSeconds);
			charges = GameManager.ins.carryBotCharges;
			state = State.Charged;
			PickNextAction();
		}
	}

	private IEnumerator DockAndWait()
	{
		if (base.transform.position != parentStation.position)
		{
			yield return new WaitForPositionReached(base.transform, parentStation.position, movementSpeed);
			SetAnimation("Station");
		}
		while (!buildingScript.buildingEnabled)
		{
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
		}
		SetAnimation("Unstation");
		yield return new WaitForSeconds(0.7f);
		state = State.Working;
		PickNextAction();
	}

	private IEnumerator UndockFromStation()
	{
		if ((bool)this)
		{
			while (!buildingScript.buildingEnabled)
			{
				yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
			}
			SetAnimation("Unstation");
			rechargeBar.ResetRechargeBar();
			yield return new WaitForSeconds(0.7f);
			UpdateSpeedAndCapacity();
			state = State.Working;
		}
	}

	private void UpdateSpeedAndCapacity()
	{
		movementSpeed = buildingScript.getSpeed();
		carryCapacity = buildingScript.getCapacity();
		charges = GameManager.ins.carryBotCharges;
	}

	private void SetAnimation(string newState)
	{
		if ((bool)anim)
		{
			anim.Play(newState);
		}
	}

	private void OnDestroy()
	{
		FreeUpSlot();
		GameManager.ins.bots.Remove(base.gameObject);
		SaveData.ins.UpdateTotalBots();
	}

	private void FreeUpSlot()
	{
		if ((bool)targetBioSlot && targetBioSlot.state == BiofuelSlot.State.MarkedForStock)
		{
			targetBioSlot.state = BiofuelSlot.State.Empty;
			targetBioSlot = null;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(parentStation.position, range);
	}
}
