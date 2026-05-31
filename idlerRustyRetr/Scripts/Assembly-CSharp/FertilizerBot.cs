using System;
using System.Collections;
using UnityEngine;

public class FertilizerBot : MonoBehaviour
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
	private int charges;

	[SerializeField]
	private float rechargingTime = 16f;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float range = 16f;

	private int moveCycle;

	private const string IDLE = "Idle";

	private const string DISAPPEAR = "disappearpart";

	private const string APPEAR = "appearpart";

	private const string FERTILIZE = "Fertilize";

	private const string STATION = "Stationed";

	private void Start()
	{
		SetAnimation("Stationed");
		UpdateSpeedAndCapacity();
		StartCoroutine(WaitForNextAction());
		GameManager.ins.bots.Add(base.gameObject);
		SaveData.ins.UpdateTotalBots();
		AchievementManager.ins.BuildEveryBot("fert");
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
				TryToFertilize();
			}
		}
	}

	private void TryToFertilize()
	{
		CropSlot closestCropSlotThatNeedsFertilizer = GameManager.ins.getClosestCropSlotThatNeedsFertilizer(base.transform.position + Vector3.up * 0.125f, parentStation.position, range);
		if (closestCropSlotThatNeedsFertilizer == null)
		{
			StartCoroutine(WaitForNextAction());
		}
		else
		{
			StartCoroutine(Fertilize(closestCropSlotThatNeedsFertilizer));
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
		if (moveCycle > 0)
		{
			moveCycle--;
			SetAnimation("Idle");
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
			PickNextAction();
			yield break;
		}
		moveCycle = 20;
		Vector2 target = RandomPointOnXYCircle(base.transform.position, 0.25f);
		if (SaveData.ins.verticalMode)
		{
			if (target.x > 7.5f)
			{
				target = new Vector2(7.5f, target.y);
			}
			if (target.x < -7.5f)
			{
				target = new Vector2(-7.5f, target.y);
			}
		}
		else
		{
			if (target.y > 4.5f)
			{
				target = new Vector2(target.x, 4.5f);
			}
			if (target.y < -4f)
			{
				target = new Vector2(target.x, -4f);
			}
		}
		float x = parentStation.position.x;
		if (target.x > x + range)
		{
			target = new Vector2(x + range, target.y);
		}
		if (target.x < x - range)
		{
			target = new Vector2(x - range, target.y);
		}
		yield return MoveTo(target);
		PickNextAction();
	}

	private IEnumerator MoveTo(Vector2 target)
	{
		while ((Vector2)base.transform.position != target)
		{
			SetAnimation("disappearpart");
			yield return new WaitForSeconds(0.5f);
			base.transform.position = TeleportTowards(target, movementSpeed);
			SetAnimation("appearpart");
			yield return new WaitForSeconds(0.5f);
			if ((Vector2)base.transform.position == target)
			{
				SetAnimation("Idle");
			}
			if ((Vector2)base.transform.position == (Vector2)parentStation.position)
			{
				SetAnimation("Stationed");
			}
			yield return new WaitForSeconds(0.2f);
		}
	}

	private Vector2 TeleportTowards(Vector2 target, float distance)
	{
		if (Vector2.Distance(base.transform.position, target) < distance)
		{
			return target;
		}
		Vector2 vector = target - (Vector2)base.transform.position;
		return (Vector2)base.transform.position + vector.normalized * distance;
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private IEnumerator Fertilize(CropSlot slot)
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
		if (state == State.Charged)
		{
			yield return UndockFromStation();
		}
		if (slot == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		slot.markedForFertilizing = true;
		targetCropSlot = slot;
		Vector2 target = slot.transform.position + Vector3.down * 0.125f;
		SetAnimation("Idle");
		yield return MoveTo(target);
		if ((bool)slot && slot.fertilizedTimer <= 0f)
		{
			SetAnimation("Fertilize");
			GameManager.ins.SpawnFertilizerPopUp(base.transform.position + Vector3.up, -1);
			charges--;
			slot.FertilizeSoil();
			yield return new WaitForSeconds(0.8f);
			SetAnimation("Idle");
			targetCropSlot = null;
		}
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
				yield return MoveTo(parentStation.position);
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
			SetAnimation("Stationed");
		}
		while (!buildingScript.buildingEnabled)
		{
			yield return new WaitForSeconds((float)SaveData.ins.waitForNextActionMS * 0.001f);
		}
		SetAnimation("Fertilize");
		yield return new WaitForSeconds(0.8f);
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
			SetAnimation("Fertilize");
			rechargeBar.ResetRechargeBar();
			UpdateSpeedAndCapacity();
			yield return new WaitForSeconds(0.8f);
			state = State.Working;
		}
	}

	private void UpdateSpeedAndCapacity()
	{
		movementSpeed = buildingScript.getSpeed();
		charges = buildingScript.getCapacity();
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
		if (targetCropSlot != null && targetCropSlot.markedForFertilizing)
		{
			targetCropSlot.markedForFertilizing = false;
			targetCropSlot = null;
		}
	}
}
