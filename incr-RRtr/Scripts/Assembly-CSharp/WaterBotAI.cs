using System;
using System.Collections;
using UnityEngine;

public class WaterBotAI : MonoBehaviour
{
	public enum State
	{
		Working = 0,
		Charged = 1,
		NeedsCharging = 2,
		Charging = 3
	}

	public State state;

	private CropSlot targetCropSlot;

	[SerializeField]
	private Building buildingScript;

	[SerializeField]
	private Transform parentStation;

	[SerializeField]
	private RechargeBar rechargeBar;

	[SerializeField]
	private Animator anim;

	private int waterCapacity;

	[SerializeField]
	private int charges;

	[SerializeField]
	private float rechargingTime = 16f;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float range = 14f;

	private const string IDLE = "Idle";

	private const string WATER = "Water";

	private const string REFILL = "Refill";

	private const string STATION = "Station";

	private const string UNSTATION = "Unstation";

	private void Start()
	{
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		PickNextAction();
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("water");
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
		CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedWater, base.transform.position, parentStation.position, range);
		if (closestCropSlotThat == null)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(Water(closestCropSlotThat));
		}
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
		if (waterCapacity <= 0)
		{
			yield return GetWater();
		}
		else
		{
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
		}
		PickNextAction();
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private IEnumerator Water(CropSlot crop)
	{
		if (!this)
		{
			yield break;
		}
		if (crop == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		crop.state = CropSlot.State.MarkedForWatering;
		targetCropSlot = crop;
		Vector2 target = crop.transform.position;
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		if (waterCapacity <= 0)
		{
			yield return GetWater();
		}
		SetAnimation("Idle");
		yield return new WaitForPositionReached(base.transform, target, movementSpeed);
		if ((bool)crop && crop.cropType != CropType.None)
		{
			SetAnimation("Water");
			waterCapacity--;
			crop.WaterCropSlot();
			yield return new WaitForSeconds(1f);
			SetAnimation("Idle");
			targetCropSlot = null;
		}
		if (waterCapacity <= 0 && charges <= 0)
		{
			state = State.NeedsCharging;
		}
		PickNextAction();
	}

	private IEnumerator GetWater()
	{
		if ((bool)this)
		{
			WaterSource water = GameManager.ins.getClosestWaterSource(base.transform.position);
			Vector2 vector = water.transform.position;
			SetAnimation("Idle");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
			if (water == null)
			{
				yield return GetWater();
				yield break;
			}
			SetAnimation("Refill");
			yield return new WaitForSeconds(1.5999999f);
			waterCapacity = buildingScript.getCapacity();
			charges--;
		}
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
			rechargeBar.RechargeFor((int)rechargingTime);
			rechargeBar.StopNoBiofuelWarning();
			yield return new WaitForSeconds(rechargingTime);
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
		waterCapacity = buildingScript.getCapacity();
		charges = GameManager.ins.waterBotCharges;
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
		if (targetCropSlot != null && targetCropSlot.state == CropSlot.State.MarkedForWatering)
		{
			targetCropSlot.state = CropSlot.State.NeedWater;
			targetCropSlot = null;
		}
	}
}
