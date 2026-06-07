using System.Collections;
using UnityEngine;

public class Chicken : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private float range = 20f;

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private float runSpeed = 1.1f;

	[SerializeField]
	private Transform parentStation;

	[SerializeField]
	private Animator anim;

	private CropSlot targetCrop;

	private FeederSlot targetFeederSlot;

	private const string WALK = "Walk";

	private const string IDLE = "Idle";

	private const string PECK = "Peck";

	private const string SITDOWN = "SitDown";

	private const string SITLOOK = "SitLook";

	private int improvedCrops;

	private int maxImprovedCrops = 4;

	private int peckRandomly;

	private int maxPeckRandomly = 5;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private void Start()
	{
		StartCoroutine(WaitForNextAction());
		GameManager.ins.animals.Add(base.gameObject);
	}

	private void OnDisable()
	{
		if ((bool)targetCrop)
		{
			targetCrop.markedForImprovement = false;
			targetCrop = null;
		}
		if ((bool)targetFeederSlot)
		{
			targetFeederSlot.state = FeederSlot.State.Filled;
			targetFeederSlot = null;
		}
	}

	private void OnDestroy()
	{
		GameManager.ins.animals.Remove(base.gameObject);
	}

	private void PickNextAction()
	{
		if (peckRandomly < maxPeckRandomly)
		{
			peckRandomly++;
			CropSlot randomCropSlotInRange = GameManager.ins.getRandomCropSlotInRange(parentStation.position, range);
			if ((bool)randomCropSlotInRange)
			{
				StartCoroutine(PeckCropSoil(randomCropSlotInRange, improveCrop: false));
				return;
			}
		}
		else
		{
			CropSlot randomNonImprovedCropSlotInRange = GameManager.ins.getRandomNonImprovedCropSlotInRange(parentStation.position, range);
			if ((bool)randomNonImprovedCropSlotInRange)
			{
				peckRandomly = 0;
				StartCoroutine(PeckCropSoil(randomNonImprovedCropSlotInRange, improveCrop: true));
				return;
			}
		}
		StartCoroutine(SitAndRest());
	}

	private IEnumerator SitAndRest()
	{
		if (base.transform.position != parentStation.position)
		{
			yield return WalkToPosition(parentStation.position);
			anim.Play("SitDown");
			yield return new WaitForSeconds(5f);
		}
		for (int i = 0; i < 6; i++)
		{
			anim.Play("SitLook");
			yield return new WaitForSeconds(5f);
			anim.Play("SitDown");
			yield return new WaitForSeconds(5f);
		}
		PickNextAction();
	}

	private IEnumerator WaitForNextAction()
	{
		yield return WalkToPosition(PickRandomPosition(base.transform.position));
		SetAnimation("Idle");
		yield return new WaitForSeconds(Random.Range(1f, 3f));
		PickNextAction();
	}

	private Vector2 PickRandomPosition(Vector2 center)
	{
		Vector2 result = center + new Vector2(Random.Range(1f, -1f), Random.Range(1f, -1f)).normalized * 1.5f;
		if (parentStation != null)
		{
			if (result.x > parentStation.position.x + range)
			{
				result = new Vector2(parentStation.position.x + range, result.y);
			}
			if (result.x < parentStation.position.x - range)
			{
				result = new Vector2(parentStation.position.x - range, result.y);
			}
			if (result.y > parentStation.position.y + range)
			{
				result = new Vector2(result.x, parentStation.position.y + range);
			}
			if (result.y < parentStation.position.y - range)
			{
				result = new Vector2(result.x, parentStation.position.y - range);
			}
		}
		if (SaveData.ins.verticalMode)
		{
			if (result.x > 7.5f)
			{
				result = new Vector2(7.5f, result.y);
			}
			if (result.x < -7.5f)
			{
				result = new Vector2(-7.5f, result.y);
			}
			if (result.y > 47f)
			{
				result = new Vector2(result.x, 47f);
			}
			if (result.y < -45f)
			{
				result = new Vector2(result.x, -45f);
			}
		}
		else
		{
			if (result.x > 81f)
			{
				result = new Vector2(81f, result.y);
			}
			if (result.x < -81f)
			{
				result = new Vector2(-81f, result.y);
			}
			if (result.y > 4.5f)
			{
				result = new Vector2(result.x, 4.5f);
			}
			if (result.y < -4f)
			{
				result = new Vector2(result.x, -4f);
			}
		}
		return result;
	}

	private IEnumerator PeckCropSoil(CropSlot crop, bool improveCrop)
	{
		if ((bool)crop && improveCrop)
		{
			targetCrop = crop;
			crop.markedForImprovement = true;
		}
		Vector3 vector = new Vector3Int(Random.Range(-1, 2), Random.Range(-1, 2));
		Vector2 target = crop.transform.position + vector * 0.125f;
		yield return WalkToPosition(target);
		for (int i = 0; i < 3; i++)
		{
			yield return PeckForXAmountOfTimes(Random.Range(2, 4));
			yield return new WaitForSeconds(Random.Range(1f, 2f));
			vector = new Vector3Int(Random.Range(-1, 2), Random.Range(-1, 2));
			target = crop.transform.position + vector * 0.125f;
			yield return WalkToPosition(target);
		}
		yield return PeckForXAmountOfTimes(4);
		if ((bool)crop && improveCrop)
		{
			crop.ImproveCrop();
			GameManager.ins.SpawnRegrowthPopUp(crop.transform.position + Vector3.up, 1);
		}
		targetCrop = null;
		if (improveCrop)
		{
			StartCoroutine(SitAndRest());
		}
		else
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator PeckFeederSlot(FeederSlot slot)
	{
		if ((bool)slot)
		{
			targetFeederSlot = slot;
			slot.state = FeederSlot.State.MarkedForConsumption;
		}
		Vector3 offset = new Vector2(0f, 0.875f);
		Vector2 target = slot.transform.position + offset;
		yield return WalkToPosition(target);
		for (int i = 0; i < 4; i++)
		{
			SetDirection(target + Vector2.down);
			yield return PeckForXAmountOfTimes(Random.Range(2, 4));
			yield return new WaitForSeconds(Random.Range(1f, 2f));
			Vector3 vector = new Vector3Int(Random.Range(-1, 2), 0);
			target = slot.transform.position + offset + vector * 0.125f;
			yield return WalkToPosition(target);
			SetDirection(target + Vector2.down);
		}
		yield return PeckForXAmountOfTimes(4);
		if ((bool)slot)
		{
			slot.RemoveOneCropFromSlot();
		}
		GameManager.ins.SpawnHeartPopUp(base.transform.position + Vector3.up);
		targetFeederSlot = null;
		StartCoroutine(SitAndRest());
	}

	private IEnumerator PeckForXAmountOfTimes(int xtimes)
	{
		for (int i = 0; i < xtimes; i++)
		{
			SetAnimation("Peck");
			yield return new WaitForSeconds(0.18f);
			SetAnimation("Idle");
			yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
		}
	}

	private IEnumerator WalkToPosition(Vector2 target)
	{
		SetDirection(target);
		SetAnimation("Walk");
		float num = speed;
		float num2 = 15f;
		if (Vector2.Distance(base.transform.position, target) > num2)
		{
			num = runSpeed;
		}
		yield return new WaitForPositionReached(base.transform, target, num);
	}

	private void SetAnimation(string newState)
	{
		anim.Play(newState + GetDirectionForAnim());
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

	public void SetAnimatorControllerTo(AnimatorOverrideController overrideAnimator)
	{
		anim.runtimeAnimatorController = overrideAnimator;
	}
}
