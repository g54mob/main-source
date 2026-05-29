using System;
using System.Collections;
using UnityEngine;

public class HarvestBotAI : MonoBehaviour
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

	[SerializeField]
	private SpriteRenderer[] cropSr;

	[SerializeField]
	private int charges;

	[SerializeField]
	private int harvestCapacity;

	private int currentHarvestAmount;

	[SerializeField]
	private int rechargingTimeInSeconds = 16;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float range = 12f;

	private const string IDLE = "Idle";

	private const string WALK = "Walk";

	private const string HARVEST = "Harvest";

	private const string STATION = "Stationed";

	private bool moveCycle;

	private int moveCycles;

	private void Start()
	{
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		PickNextAction();
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("harvest");
	}

	private void PickNextAction()
	{
		if ((bool)this)
		{
			if (state == State.NeedsCharging)
			{
				StartCoroutine(TryRecharge());
			}
			else if (!buildingScript.buildingEnabled)
			{
				StartCoroutine(DockAndWait());
			}
			else
			{
				TryInitialHarvest();
			}
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
		moveCycle = !moveCycle;
		moveCycles++;
		if (moveCycles < 10)
		{
			SetAnimation("Idle");
			yield return new WaitForSeconds(0.2f);
		}
		else
		{
			moveCycles = 0;
			SetAnimation("Walk");
			Vector2 vector = RandomPointOnXYCircle(base.transform.position, 0.5f);
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
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		}
		PickNextAction();
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private void TryInitialHarvest()
	{
		CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position, parentStation.position, range);
		if (closestCropSlotThat == null)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(GoToHarvest(closestCropSlotThat));
		}
	}

	private IEnumerator GoToHarvest(CropSlot crop)
	{
		if (!this)
		{
			yield break;
		}
		targetCropSlot = crop;
		crop.state = CropSlot.State.MarkedForHarvest;
		Vector2 target = crop.transform.position;
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, target, movementSpeed);
		SetAnimation("Harvest");
		yield return new WaitForSeconds(0.4f);
		if ((bool)crop && crop.cropType != CropType.None)
		{
			Sprite cropSprite = GameManager.ins.getCropSprite(crop.cropType);
			crop.HarvestCropSlot();
			yield return new WaitForSeconds(0.2f);
			targetCropSlot = null;
			cropSr[currentHarvestAmount].sprite = cropSprite;
			currentHarvestAmount++;
			yield return new WaitForSeconds(0.3f);
		}
		if (harvestCapacity <= currentHarvestAmount)
		{
			StartCoroutine(TakeCropsToHouse());
			yield break;
		}
		CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position, parentStation.position, range);
		if (closestCropSlotThat == null)
		{
			StartCoroutine(TakeCropsToHouse());
		}
		else
		{
			StartCoroutine(GoToHarvest(closestCropSlotThat));
		}
	}

	private IEnumerator TakeCropsToHouse()
	{
		if ((bool)this)
		{
			Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, closestStorage, movementSpeed);
			for (int i = 0; i < cropSr.Length; i++)
			{
				cropSr[i].sprite = null;
			}
			currentHarvestAmount = 0;
			charges--;
			if (charges <= 0)
			{
				state = State.NeedsCharging;
			}
			PickNextAction();
		}
	}

	private IEnumerator TryRecharge()
	{
		if ((bool)this)
		{
			if (base.transform.position != parentStation.position)
			{
				yield return new WaitForPositionReached(base.transform, parentStation.position, movementSpeed);
				SetAnimation("Stationed");
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
			rechargeBar.RechargeFor(rechargingTimeInSeconds);
			rechargeBar.StopNoBiofuelWarning();
			yield return new WaitForSeconds(rechargingTimeInSeconds);
			state = State.Charged;
			PickNextAction();
		}
	}

	private IEnumerator DockAndWait()
	{
		if (base.transform.position != parentStation.position)
		{
			yield return new WaitForPositionReached(base.transform, parentStation.position, movementSpeed);
			SetAnimation("Stationed");
		}
		while (!buildingScript.buildingEnabled)
		{
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
		}
		SetAnimation("Idle");
		yield return new WaitForSeconds(0.1f);
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
			SetAnimation("Idle");
			rechargeBar.ResetRechargeBar();
			yield return new WaitForSeconds(0.1f);
			UpdateSpeedAndCapacity();
			state = State.Working;
		}
	}

	private void UpdateSpeedAndCapacity()
	{
		movementSpeed = buildingScript.getSpeed();
		harvestCapacity = buildingScript.getCapacity();
		charges = GameManager.ins.harvestBotCharges;
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
		if (targetCropSlot != null && targetCropSlot.state == CropSlot.State.MarkedForHarvest)
		{
			targetCropSlot.state = CropSlot.State.NeedHarvest;
			targetCropSlot = null;
		}
	}
}
