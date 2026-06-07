using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private float walkSpeed;

	[Header("Animation stuff")]
	[SerializeField]
	private Animator bodyAnim;

	[SerializeField]
	private Animator headAnim;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string RUN = "Run";

	private const string IDLE1 = "Body1";

	private const string IDLE2 = "Body2";

	private const string HEAD1 = "Head1";

	private const string HEAD2 = "Head2";

	private const string HEAD3 = "Head3";

	private const string HEAD4 = "Head4";

	private const string HEADEATING = "HeadEating";

	private float walkDistance = 3f;

	private void Start()
	{
		GameManager.ins.deers.Add(this);
		StartCoroutine(Move());
	}

	private IEnumerator Move()
	{
		Vector2 vector = RandomPointFrom(base.transform.position);
		bool eat = false;
		bool drink = false;
		if (Random.value < 0.2f)
		{
			CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.IsGrowing, base.transform.position);
			if (closestCropSlotThat != null)
			{
				vector = RoundToNearestPixel(closestCropSlotThat.transform.position);
			}
			if (closestCropSlotThat != null)
			{
				eat = true;
			}
		}
		if (Random.value > 0.8f)
		{
			WaterSource closestWaterSource = GameManager.ins.getClosestWaterSource(base.transform.position);
			if (closestWaterSource != null)
			{
				vector = RoundToNearestPixel(GameManager.ins.getClosestPointOnWaterSourceCollider(closestWaterSource, base.transform.position));
			}
			if (closestWaterSource != null)
			{
				drink = true;
			}
		}
		SetDirection(vector);
		if (Vector2.Distance(base.transform.position, vector) < walkDistance)
		{
			SetBodyAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, vector, walkSpeed);
		}
		else
		{
			SetBodyAnimation("Run");
			yield return new WaitForPositionReached(base.transform, vector, runSpeed);
		}
		if (eat || drink)
		{
			StartCoroutine(Idle(eatOrDrink: true));
		}
		else
		{
			StartCoroutine(Idle(eatOrDrink: false));
		}
	}

	private IEnumerator Idle(bool eatOrDrink)
	{
		PlayRandomIdleBody();
		PlayRandomIdleHead(includeEating: false);
		yield return new WaitForSeconds(1.5f);
		int random = Random.Range(2, 6);
		for (int i = 0; i < random; i++)
		{
			PlayRandomIdleHead(eatOrDrink);
			yield return new WaitForSeconds(Random.Range(1f, 3f));
		}
		PlayRandomIdleHead(includeEating: false);
		yield return new WaitForSeconds(1f);
		StartCoroutine(Move());
	}

	private void PlayRandomIdleBody()
	{
		int num = Random.Range(0, 2);
		if (num == 0)
		{
			SetBodyAnimation("Body1");
		}
		if (num == 1)
		{
			SetBodyAnimation("Body2");
		}
	}

	private void PlayRandomIdleHead(bool includeEating)
	{
		int num = (includeEating ? Random.Range(0, 6) : Random.Range(0, 4));
		if (num == 0)
		{
			SetHeadAnimation("Head1");
		}
		if (num == 1)
		{
			SetHeadAnimation("Head2");
		}
		if (num == 2)
		{
			SetHeadAnimation("Head3");
		}
		if (num == 3)
		{
			SetHeadAnimation("Head4");
		}
		if (num == 4)
		{
			SetHeadAnimation("HeadEating");
		}
		if (num == 5)
		{
			SetHeadAnimation("HeadEating");
		}
	}

	private Vector2 RandomPointFrom(Vector2 center)
	{
		Vector2 vector = new Vector2(Random.Range(6f, -5f), Random.Range(5f, -6f));
		Vector2 vector2 = center + vector;
		if (SaveData.ins.verticalMode)
		{
			float x = Random.Range(-7.5f, 7.5f);
			vector2 = new Vector2(x, vector2.y);
			if (vector2.y > 47f)
			{
				vector2 = new Vector2(vector2.x, 47f);
			}
			if (vector2.y < -45f)
			{
				vector2 = new Vector2(vector2.x, -45f);
			}
		}
		else
		{
			float y = Random.Range(-4.5f, 4f);
			vector2 = new Vector2(vector2.x, y);
			if (vector2.x > 81f)
			{
				vector2 = new Vector2(81f, vector2.y);
			}
			if (vector2.x < -81f)
			{
				vector2 = new Vector2(-81f, vector2.y);
			}
		}
		return RoundToNearestPixel(vector2);
	}

	private Vector2 RoundToNearestPixel(Vector2 pos)
	{
		float x = Mathf.Round(pos.x * 16f) / 16f;
		float y = Mathf.Round(pos.y * 16f) / 16f;
		return new Vector2(x, y);
	}

	private void SetBodyAnimation(string newState)
	{
		if (newState == "Walk" || newState == "Run")
		{
			HideHeadAnimation();
		}
		bodyAnim.Play(newState + GetDirectionForAnim());
	}

	private void SetHeadAnimation(string newState)
	{
		headAnim.gameObject.SetActive(value: true);
		headAnim.Play(newState + GetDirectionForAnim());
	}

	private void HideHeadAnimation()
	{
		headAnim.gameObject.SetActive(value: false);
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

	private Vector2 GetCenterOfMassFromAllDeers(List<Deer> deers)
	{
		Vector2 zero = Vector2.zero;
		int count = deers.Count;
		foreach (Deer deer in deers)
		{
			zero += (Vector2)deer.transform.position;
		}
		if (count > 0)
		{
			zero /= (float)count;
		}
		return zero;
	}
}
