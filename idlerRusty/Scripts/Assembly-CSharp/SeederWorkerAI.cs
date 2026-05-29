using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeederWorkerAI : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	private float movementSpeed = 1.25f;

	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private int restTimerInSeconds = 60;

	[SerializeField]
	private Transform sittingTransform;

	private CropPatch targetCropPatch;

	private CropType crop;

	private int cropPrice;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Waiting";

	private const string BENCH = "Bench";

	private const string PLANT = "Seed";

	public List<CropPatch> availableCropPatches;

	[Header("Crossover visuals")]
	[SerializeField]
	private CrossoverSkin[] crossoverSkins;

	private void ChangeAnimatorControllerForCrossover()
	{
		if (!SaveData.ins.checkIfCrossover())
		{
			return;
		}
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
	}

	private void Start()
	{
		StartCoroutine(WaitForNextAction());
		ChangeAnimatorControllerForCrossover();
	}

	private void GetAllEmptyCropPatches()
	{
		availableCropPatches.Clear();
		if (GameManager.ins.cropPatches.Count == 0)
		{
			return;
		}
		for (int i = 0; i < GameManager.ins.cropPatches.Count; i++)
		{
			if (GameManager.ins.cropPatches[i].cropSign != null && GameManager.ins.cropPatches[i].cropSign.getCropType() == CropType.DontSeedSign)
			{
				continue;
			}
			int num = GameManager.ins.cropPatches[i].cropSlots.Length;
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				if (GameManager.ins.cropPatches[i].cropSlots[j].state == CropSlot.State.Empty || GameManager.ins.cropPatches[i].cropSlots[j].state == CropSlot.State.Fossil)
				{
					num2++;
				}
			}
			if (!((float)num2 < (float)num * 0.75f))
			{
				availableCropPatches.Add(GameManager.ins.cropPatches[i]);
			}
		}
	}

	private CropPatch getClosestCropPatchFromList()
	{
		CropPatch result = null;
		float num = 999f;
		if (availableCropPatches != null && availableCropPatches.Count > 0)
		{
			for (int i = 0; i < availableCropPatches.Count; i++)
			{
				float num2 = Vector2.Distance(base.transform.position, availableCropPatches[i].transform.position);
				if (num2 < num)
				{
					result = availableCropPatches[i];
					num = num2;
				}
			}
		}
		return result;
	}

	private void PickNextAction()
	{
		if (!this)
		{
			return;
		}
		if (!GameManager.ins.autoPlantSeeds)
		{
			StartCoroutine(GoToHouseToRest());
			return;
		}
		GetAllEmptyCropPatches();
		CropPatch closestCropPatchFromList = getClosestCropPatchFromList();
		if (closestCropPatchFromList != null)
		{
			crop = Inventory.ins.GetRandomCropFromTheLastX(8);
			cropPrice = GameManager.ins.getCropSO(crop).cropCost;
			PlantPatch(closestCropPatchFromList);
			Debug.Log("Plant seeds on " + closestCropPatchFromList.transform.parent.transform.parent.name);
		}
		else
		{
			StartCoroutine(WaitForNextAction());
			Debug.Log("Wander around");
		}
	}

	private IEnumerator WaitForNextAction()
	{
		yield return WanderToANewSpot();
		PickNextAction();
	}

	private void PlantPatch(CropPatch patch)
	{
		StartCoroutine(PlantEmptySlotOnCropPatch(patch));
	}

	private IEnumerator PlantEmptySlotOnCropPatch(CropPatch cropPatch)
	{
		if (cropPatch == null)
		{
			PickNextAction();
			yield break;
		}
		CropSlot targetSlot = null;
		for (int i = 0; i < cropPatch.cropSlots.Length; i++)
		{
			if (cropPatch.cropSlots[i].state == CropSlot.State.Empty)
			{
				targetSlot = cropPatch.cropSlots[i];
				break;
			}
		}
		if (targetSlot == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(targetSlot.transform.position);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, targetSlot.transform.position, movementSpeed);
		if (targetSlot.state != CropSlot.State.Empty)
		{
			PlantPatch(cropPatch);
			yield break;
		}
		if (cropPatch.cropSign != null)
		{
			if (cropPatch.cropSign.getCropType() == CropType.DontSeedSign)
			{
				StartCoroutine(WaitForNextAction());
				yield break;
			}
			CropSO cropSO = cropPatch.cropSign.getCropSO();
			if (cropSO != null)
			{
				crop = cropSO.cropType;
				cropPrice = cropSO.cropCost;
			}
		}
		if (Inventory.ins.spareParts < cropPrice)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetAnimation("Seed");
		yield return new WaitForSeconds(0.5f);
		if (targetSlot != null)
		{
			targetSlot.PlantSeed(crop, playSound: false);
			SaveData.ins.statsPanel.UpdateCropStats();
			Debug.Log("planted seed on " + targetSlot.gameObject.name, targetSlot);
		}
		yield return new WaitForSeconds(0.3f);
		PlantPatch(cropPatch);
	}

	private IEnumerator RestOnBench()
	{
		Bench benchTarget = GameManager.ins.getClosestBench(base.transform.position);
		if (benchTarget == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(benchTarget.transform.position);
		SetAnimation("Walk");
		benchTarget.SetOccupied(state: true);
		yield return new WaitForPositionReached(base.transform, benchTarget.transform.position, movementSpeed);
		workerAnim.Play("Bench");
		yield return new WaitForSeconds(restTimerInSeconds);
		if (benchTarget == null)
		{
			PickNextAction();
			yield break;
		}
		SetDirection(benchTarget.transform.position + Vector3.down);
		SetAnimation("Walk");
		benchTarget.SetOccupied(state: false);
		yield return new WaitForPositionReached(base.transform, benchTarget.transform.position + Vector3.down, movementSpeed);
		PickNextAction();
	}

	private IEnumerator GoToHouseToRest()
	{
		if (base.transform.position != sittingTransform.position)
		{
			SetDirection(sittingTransform.position);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, sittingTransform.position, movementSpeed);
			workerAnim.Play("Bench");
		}
		yield return new WaitForSeconds(1f);
		PickNextAction();
	}

	private IEnumerator WanderToANewSpot()
	{
		Vector2 vector = RandomPointOnXYCircle(base.transform.position, UnityEngine.Random.Range(1f, 2f));
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
			if (vector.y > 47f)
			{
				vector = new Vector2(vector.x, 47f);
			}
			if (vector.y < -45f)
			{
				vector = new Vector2(vector.x, -45f);
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
			if (vector.x > 81f)
			{
				vector = new Vector2(81f, vector.y);
			}
			if (vector.x < -81f)
			{
				vector = new Vector2(-81f, vector.y);
			}
		}
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Waiting");
		yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private void SetAnimation(string newState)
	{
		if ((bool)workerAnim)
		{
			workerAnim.Play(newState + GetDirectionForAnim());
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
