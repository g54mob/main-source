using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private GameObject poop_obj;

	[SerializeField]
	private float movementSpeed = 0.5f;

	private int roam;

	private int roamMin = 8;

	private int fullness;

	private int fullnessMin = 2;

	private float range = 14f;

	private const string WALK = "Walk";

	private const string IDLE = "Idle";

	private const string EAT = "Eat";

	[SerializeField]
	private Animator anim;

	public AnimalSlot parentSlot;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private void Start()
	{
		roam = Random.Range(1, roamMin);
		fullness = Random.Range(1, fullnessMin);
		Invoke("PickNextAction", Random.Range(0.5f, 2f));
		GameManager.ins.animals.Add(base.gameObject);
	}

	private void PickNextAction()
	{
		if (roam <= 0)
		{
			if (Inventory.ins.fertilizer > 999)
			{
				WaterSource closestWaterSource = GameManager.ins.getClosestWaterSource(base.transform.position);
				StartCoroutine(DrinkWaterFromWell(closestWaterSource));
				return;
			}
			FeederSlot availableFeederSlotFrom = GameManager.ins.getAvailableFeederSlotFrom(parentSlot);
			if ((bool)availableFeederSlotFrom)
			{
				StartCoroutine(PoopAndEatFoodFrom(availableFeederSlotFrom));
				return;
			}
		}
		StartCoroutine(MoveRandomly());
		roam--;
	}

	private IEnumerator MoveRandomly()
	{
		Vector2 vector = RandomPointFrom(base.transform.position);
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Idle");
		yield return new WaitForSeconds(Random.Range(1f, 4f));
		PickNextAction();
	}

	private Vector2 RandomPointFrom(Vector2 center)
	{
		Vector2 vector = new Vector2(Random.Range(2.5f, -2.5f), Random.Range(2.5f, -2.5f));
		Vector2 normalized = (vector - center).normalized;
		Vector2 result = center + vector;
		for (int i = 0; i < GameManager.ins.waterSources.Count; i++)
		{
			float num = Vector2.Distance(GameManager.ins.waterSources[i].transform.position, center + vector);
			if (num < 1f)
			{
				result = center + vector - normalized * num;
			}
		}
		for (int j = 0; j < GameManager.ins.feeders.Count; j++)
		{
			float num2 = Vector2.Distance(GameManager.ins.feeders[j].transform.position, center + vector);
			if (num2 < 1.75f)
			{
				result = center + vector - normalized * num2;
			}
		}
		if (parentSlot != null)
		{
			if (result.x > parentSlot.transform.position.x + range)
			{
				result = new Vector2(parentSlot.transform.position.x + range, result.y);
			}
			if (result.x < parentSlot.transform.position.x - range)
			{
				result = new Vector2(parentSlot.transform.position.x - range, result.y);
			}
			if (result.y > parentSlot.transform.position.y + range)
			{
				result = new Vector2(result.x, parentSlot.transform.position.y + range);
			}
			if (result.y < parentSlot.transform.position.y - range)
			{
				result = new Vector2(result.x, parentSlot.transform.position.y - range);
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

	private Vector2 RandomStraightPointFrom(Vector2 center)
	{
		Vector2 vector = center;
		Vector2 zero = Vector2.zero;
		float num = Random.Range(1f, 3.5f);
		zero = ((Random.value > 0.5f) ? ((!(Random.value > 0.5f)) ? Vector2.left : Vector2.right) : ((!(Random.value > 0.5f)) ? Vector2.down : Vector2.up));
		for (int i = 0; i < GameManager.ins.waterSources.Count; i++)
		{
			if (Vector2.Distance(GameManager.ins.waterSources[i].transform.position, center + zero) < 1f)
			{
				num = 2.5f;
			}
		}
		for (int j = 0; j < GameManager.ins.feeders.Count; j++)
		{
			if (Vector2.Distance(GameManager.ins.feeders[j].transform.position, center + zero) < 1.5f)
			{
				num = 3.5f;
			}
		}
		vector = center + zero * num;
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
			if (vector.x > 81f)
			{
				vector = new Vector2(81f, vector.y);
			}
			if (vector.x < -81f)
			{
				vector = new Vector2(-81f, vector.y);
			}
			if (vector.y > 4.5f)
			{
				vector = new Vector2(vector.x, 4.5f);
			}
			if (vector.y < -4f)
			{
				vector = new Vector2(vector.x, -4f);
			}
		}
		return vector;
	}

	private IEnumerator PoopAndEatFoodFrom(FeederSlot slot)
	{
		fullness--;
		if (fullness <= 0)
		{
			Object.Instantiate(poop_obj, base.transform.position, Quaternion.identity);
			fullness = fullnessMin;
		}
		slot.state = FeederSlot.State.MarkedForConsumption;
		Vector2 vector = (Vector2)slot.transform.position + Vector2.down * 0.5f;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if ((bool)slot)
		{
			SetDirection(slot.transform.position);
			SetAnimation("Eat");
			roam = roamMin;
			yield return new WaitForSeconds(4f);
		}
		if ((bool)slot)
		{
			slot.RemoveOneCropFromSlot();
		}
		GameManager.ins.SpawnHeartPopUp(base.transform.position + Vector3.up);
		WaterSource closestWaterSource = GameManager.ins.getClosestWaterSource(base.transform.position);
		if (Vector2.Distance(base.transform.position, closestWaterSource.transform.position) < range)
		{
			StartCoroutine(DrinkWaterFromWell(closestWaterSource));
		}
		else
		{
			PickNextAction();
		}
	}

	private IEnumerator DrinkWaterFromWell(WaterSource well)
	{
		Vector2 closestPointOnWaterSourceCollider = GameManager.ins.getClosestPointOnWaterSourceCollider(well, base.transform.position);
		SetDirection(closestPointOnWaterSourceCollider);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, closestPointOnWaterSourceCollider, movementSpeed);
		SetAnimation("Eat");
		yield return new WaitForSeconds(4f);
		roam = roamMin;
		PickNextAction();
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
