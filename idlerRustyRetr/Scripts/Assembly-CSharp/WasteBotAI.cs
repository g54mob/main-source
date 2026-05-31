using System.Collections;
using UnityEngine;

public class WasteBotAI : MonoBehaviour
{
	public enum State
	{
		Working = 0,
		Charged = 1,
		NeedsCharging = 2,
		Charging = 3
	}

	public State state;

	private Poop targetPoop;

	[SerializeField]
	private Building buildingScript;

	[SerializeField]
	private Transform parentStation;

	[SerializeField]
	private RechargeBar rechargeBar;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private Sprite poopSprite;

	[SerializeField]
	private SpriteRenderer[] poopSr;

	[SerializeField]
	private int charges;

	[SerializeField]
	private int wasteCapacity;

	private int currentWasteAmount;

	private int rechargingTimeInSeconds = 16;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float range = 14f;

	private const string IDLE = "Idle";

	private const string WALK = "Walk";

	private const string COLLECT = "Collect";

	private const string STATION = "Stationed";

	private void Start()
	{
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		PickNextAction();
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("waste");
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
				TryInitialCollection();
			}
		}
	}

	private IEnumerator WaitForNextAction()
	{
		if ((bool)this)
		{
			if (state == State.Charged)
			{
				yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
				PickNextAction();
			}
			else
			{
				yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
				PickNextAction();
			}
		}
	}

	private void TryInitialCollection()
	{
		Poop closestPoopThat = GameManager.ins.getClosestPoopThat(Poop.State.NeedsCollecting, base.transform.position, parentStation.position, range);
		if (closestPoopThat == null)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(GoToCollect(closestPoopThat));
		}
	}

	private IEnumerator GoToCollect(Poop poop)
	{
		if (!this)
		{
			yield break;
		}
		targetPoop = poop;
		poop.state = Poop.State.MarkedForCollection;
		Vector2 target = poop.transform.position;
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, target, movementSpeed);
		SetAnimation("Collect");
		yield return new WaitForSeconds(0.7f);
		poop.HarvestPoop();
		targetPoop = null;
		int amount = 3;
		Inventory.ins.AddFertilizer(amount);
		GameManager.ins.SpawnFertilizerPopUp((Vector2)base.transform.position + Vector2.up, amount);
		poopSr[currentWasteAmount].sprite = poopSprite;
		currentWasteAmount++;
		yield return new WaitForSeconds(0.2f);
		if (wasteCapacity <= currentWasteAmount)
		{
			StartCoroutine(TakePoopToHouse());
			yield break;
		}
		Poop closestPoopThat = GameManager.ins.getClosestPoopThat(Poop.State.NeedsCollecting, base.transform.position, parentStation.position, range);
		if (closestPoopThat == null)
		{
			StartCoroutine(TakePoopToHouse());
		}
		else
		{
			StartCoroutine(GoToCollect(closestPoopThat));
		}
	}

	private IEnumerator TakePoopToHouse()
	{
		if ((bool)this)
		{
			Vector2 closestFertilizerFacility = GameManager.ins.getClosestFertilizerFacility(base.transform.position);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, closestFertilizerFacility, movementSpeed);
			for (int i = 0; i < poopSr.Length; i++)
			{
				poopSr[i].sprite = null;
			}
			currentWasteAmount = 0;
			SetAnimation("Idle");
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
		wasteCapacity = buildingScript.getCapacity();
		charges = GameManager.ins.wasteBotCharges;
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
		if (targetPoop != null && targetPoop.state == Poop.State.MarkedForCollection)
		{
			targetPoop.state = Poop.State.NeedsCollecting;
			targetPoop = null;
		}
	}
}
