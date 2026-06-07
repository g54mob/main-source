using System.Collections;
using UnityEngine;

public class BerryBot : MonoBehaviour
{
	public enum State
	{
		Working = 0,
		Charged = 1,
		NeedsCharging = 2,
		Charging = 3
	}

	public State state;

	private bool alternateMovement;

	private BerryBush targetBush;

	[SerializeField]
	private Building buildingScript;

	[SerializeField]
	private Transform parentStation;

	[SerializeField]
	private RechargeBar rechargeBar;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private SpriteRenderer cropSr;

	[SerializeField]
	private int charges;

	[SerializeField]
	private int rechargingTimeInSeconds = 16;

	[SerializeField]
	private float movementSpeed = 0.5f;

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
		AchievementManager.ins.BuildEveryBot("berry");
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
		BerryBush closestBerryBushThat = GameManager.ins.getClosestBerryBushThat(BerryBush.State.NeedsHarvest, base.transform.position, parentStation.position, range);
		if (closestBerryBushThat != null)
		{
			StartCoroutine(GoToBerryBush(closestBerryBushThat));
		}
		else
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private Vector2 RandomPoint()
	{
		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);
		return (Vector2)base.transform.position + new Vector2(x, y);
	}

	private IEnumerator WaitForNextAction()
	{
		if (state == State.Charged)
		{
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
			PickNextAction();
			yield break;
		}
		if (alternateMovement)
		{
			Vector2 vector = RandomPoint();
			if (SaveData.ins.verticalMode)
			{
				if (vector.x > 7f)
				{
					vector = new Vector2(7f, vector.y);
				}
				if (vector.x < -7f)
				{
					vector = new Vector2(-7f, vector.y);
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
			SetAnimation("Idle");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		}
		else
		{
			SetAnimation("Idle");
			yield return new WaitForSeconds(2f);
		}
		alternateMovement = !alternateMovement;
		PickNextAction();
	}

	private IEnumerator GoToBerryBush(BerryBush bush)
	{
		if (bush == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		targetBush = bush;
		targetBush.state = BerryBush.State.MarkedForHarvest;
		Vector2 vector = bush.transform.position + Vector3.right * 0.5625f;
		SetAnimation("Idle");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if (bush == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		bush.Harvest();
		cropSr.sprite = bush.cropSO.cropSprite;
		targetBush = null;
		SetAnimation("Carry");
		Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
		if (closestStorage.x > base.transform.position.x)
		{
			anim.transform.localScale = new Vector2(1f, 1f);
		}
		else
		{
			anim.transform.localScale = new Vector2(-1f, 1f);
		}
		yield return new WaitForPositionReached(base.transform, closestStorage, movementSpeed);
		cropSr.sprite = null;
		SetAnimation("Idle");
		charges--;
		if (charges <= 0)
		{
			state = State.NeedsCharging;
		}
		PickNextAction();
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
		charges = GameManager.ins.berryBotCharges;
	}

	private void SetAnimation(string newState)
	{
		if (!(anim == null))
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
		if ((bool)targetBush && targetBush.state == BerryBush.State.MarkedForHarvest)
		{
			targetBush.state = BerryBush.State.Empty;
			targetBush = null;
		}
	}
}
