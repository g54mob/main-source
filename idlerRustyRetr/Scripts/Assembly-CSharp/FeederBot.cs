using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeederBot : MonoBehaviour
{
	public enum State
	{
		Working = 0,
		Charged = 1,
		NeedsCharging = 2,
		Charging = 3
	}

	public State state;

	private FeederSlot targetFeederSlot;

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

	private void Start()
	{
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		StartCoroutine(WaitForNextAction());
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("feeder");
	}

	private void PickNextAction()
	{
		if (!this)
		{
			return;
		}
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
		FeederSlot closestFeederSlotTo = GameManager.ins.getClosestFeederSlotTo(FeederSlot.State.Empty, base.transform.position, parentStation.position, range);
		if (closestFeederSlotTo == null)
		{
			StartCoroutine(WaitForNextAction());
			return;
		}
		CropType randomCropFromTheFirstX = GetRandomCropFromTheFirstX();
		if (randomCropFromTheFirstX == CropType.None)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(StockFeederSlot(closestFeederSlotTo, randomCropFromTheFirstX));
		}
	}

	private CropType GetRandomCropFromTheFirstX()
	{
		int num = 1;
		List<CropType> list = new List<CropType>();
		for (int i = 0; i < Inventory.ins.cropAndSeedInventory.Count; i++)
		{
			if (Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Blackberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.BlackCurrant && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Blueberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Boysenberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Cloudberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Raspberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.RedCurrant && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.RedGooseberries && Inventory.ins.cropAndSeedInventory[i].cropType != CropType.Strawberry)
			{
				if (Inventory.ins.cropAndSeedInventory[i].cropAmount >= 1)
				{
					list.Add(Inventory.ins.cropAndSeedInventory[i].cropType);
				}
				if (list.Count >= num)
				{
					break;
				}
			}
		}
		if (list.Count == 0)
		{
			return CropType.None;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private IEnumerator StockFeederSlot(FeederSlot slot, CropType crop)
	{
		if (!this)
		{
			yield break;
		}
		slot.state = FeederSlot.State.MarkedForStock;
		targetFeederSlot = slot;
		Vector2 feedSlotTarget = slot.transform.position;
		SpendCropsFromInventory(crop);
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		Sprite bestCropSprite = GameManager.ins.getCropSprite(crop);
		Vector2 closestStorage = GameManager.ins.getClosestStorage(feedSlotTarget);
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
		yield return new WaitForPositionReached(base.transform, feedSlotTarget, movementSpeed);
		if ((bool)slot)
		{
			slot.AddCropToFeederSlot(crop, currentCarryAmount);
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
		targetFeederSlot = null;
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
			charges = GameManager.ins.feederBotCharges;
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
		charges = GameManager.ins.feederBotCharges;
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
		if ((bool)targetFeederSlot && targetFeederSlot.state == FeederSlot.State.MarkedForStock)
		{
			targetFeederSlot.state = FeederSlot.State.Empty;
			targetFeederSlot = null;
		}
	}
}
