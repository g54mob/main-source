using System.Collections;
using UnityEngine;

public class Dog : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private bool cat;

	private CropSlot targetCropSlot;

	[Header("Stats")]
	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private float walkSpeed;

	[Header("Visuals")]
	[SerializeField]
	private Animator anim;

	[SerializeField]
	private SpriteRenderer cropSpriteRenderer;

	[SerializeField]
	private Transform houseTransform;

	private Direction dir;

	private Direction dirLR;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private Vector2 cDOWN = new Vector2(0f, -0.4375f);

	private Vector2 cUP = new Vector2(0f, 0.5f);

	private Vector2 cRIGHT = new Vector2(0.5f, 0.0625f);

	private Vector2 cLEFT = new Vector2(-0.5f, 0.0625f);

	private const string WALK = "Walk";

	private const string RUN = "Trot";

	private const string SIT = "Sit";

	private const string STAND = "Stand";

	private const string STANDBARK = "StandBark";

	private const string SITBARK = "SitBark";

	private const string SLEEP = "Sleep";

	private int harvestCount;

	private bool recentlyFollowedNPC;

	private void Start()
	{
		StartCoroutine(WaitForNextAction());
		GameManager.ins.animals.Add(base.gameObject);
	}

	private void PickNextAction()
	{
		if (recentlyFollowedNPC)
		{
			StartCoroutine(GoHomeAndWait());
			recentlyFollowedNPC = false;
			return;
		}
		if (harvestCount < 4)
		{
			CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position);
			if ((bool)closestCropSlotThat)
			{
				StartCoroutine(GoToHarvest(closestCropSlotThat));
				harvestCount++;
			}
			else
			{
				StartCoroutine(WaitForNextAction());
			}
			return;
		}
		Transform randomNPCInRangeForPet = GameManager.ins.GetRandomNPCInRangeForPet(base.transform.position, 10f);
		if ((bool)randomNPCInRangeForPet)
		{
			StartCoroutine(FollowNearbyNPC(randomNPCInRangeForPet));
			recentlyFollowedNPC = true;
			harvestCount = 0;
		}
		else
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator WaitForNextAction()
	{
		yield return MoveToTarget(RandomPointFrom(base.transform.position), forceWalk: true);
		if (cat)
		{
			SetIdleAnimation("Sit");
			yield return new WaitForSeconds(Random.Range(5, 10));
		}
		else
		{
			SetIdleAnimation("Stand");
			yield return new WaitForSeconds(Random.Range(2, 5));
		}
		PickNextAction();
	}

	private IEnumerator GoHomeAndWait()
	{
		Vector2 target = houseTransform.position + Vector3.down * 0.5f;
		yield return MoveToTarget(target, forceWalk: false);
		if (cat)
		{
			SetSinglularAnimation("Sleep");
			yield return new WaitForSeconds(Random.Range(20, 30));
		}
		else
		{
			SetIdleAnimation("Sit");
			yield return new WaitForSeconds(Random.Range(20, 30));
		}
		PickNextAction();
	}

	private IEnumerator FollowNearbyNPC(Transform npcTransform)
	{
		for (int i = 0; i < 8; i++)
		{
			Vector2 vector = npcTransform.position;
			Vector2 normalized = (vector - (Vector2)base.transform.position).normalized;
			yield return MoveToTarget(RoundToNearestPixel(vector - normalized * 0.75f), forceWalk: false);
			if (cat)
			{
				SetIdleAnimation("Sit");
			}
			else
			{
				SetIdleAnimation("Stand");
			}
			yield return new WaitForSeconds(Random.Range(1f, 3f));
		}
		PickNextAction();
	}

	private void TryInitialHarvest()
	{
		CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position);
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
		yield return MoveToTarget(target, forceWalk: false);
		if ((bool)crop && crop.cropType != CropType.None)
		{
			Sprite cropSprite = GameManager.ins.getCropSprite(crop.cropType);
			crop.HarvestCropSlot();
			cropSpriteRenderer.sprite = cropSprite;
			targetCropSlot = null;
			if (!cat)
			{
				SetAnimation("Stand");
				yield return new WaitForSeconds(0.4f);
			}
			StartCoroutine(TakeCropsToHouse());
		}
		else
		{
			PickNextAction();
		}
	}

	private IEnumerator TakeCropsToHouse()
	{
		if ((bool)this)
		{
			Vector2 closestStorage = GameManager.ins.getClosestStorage(base.transform.position);
			yield return MoveToTarget(closestStorage, forceWalk: true);
			cropSpriteRenderer.sprite = null;
			PickNextAction();
		}
	}

	private IEnumerator MoveToTarget(Vector2 target, bool forceWalk)
	{
		SetDirection(target);
		if (forceWalk)
		{
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, target, walkSpeed);
			yield break;
		}
		float num = Vector2.Distance(base.transform.position, target);
		float num2 = 4f;
		if (num < num2)
		{
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, target, walkSpeed);
		}
		else
		{
			SetAnimation("Trot");
			yield return new WaitForPositionReached(base.transform, target, runSpeed);
		}
	}

	private Vector2 RandomPointFrom(Vector2 center)
	{
		Vector2 vector = new Vector2(Random.Range(2.5f, -2.5f), Random.Range(2.5f, -2.5f));
		Vector2 pos = center + vector;
		if (SaveData.ins.verticalMode)
		{
			if (pos.x > 7.5f)
			{
				pos = new Vector2(7.5f, pos.y);
			}
			if (pos.x < -7.5f)
			{
				pos = new Vector2(-7.5f, pos.y);
			}
			if (pos.y > 47f)
			{
				pos = new Vector2(pos.x, 47f);
			}
			if (pos.y < -45f)
			{
				pos = new Vector2(pos.x, -45f);
			}
		}
		else
		{
			if (pos.x > 81f)
			{
				pos = new Vector2(81f, pos.y);
			}
			if (pos.x < -81f)
			{
				pos = new Vector2(-81f, pos.y);
			}
			if (pos.y > 4.5f)
			{
				pos = new Vector2(pos.x, 4.5f);
			}
			if (pos.y < -4f)
			{
				pos = new Vector2(pos.x, -4f);
			}
		}
		return RoundToNearestPixel(pos);
	}

	private Vector2 RoundToNearestPixel(Vector2 pos)
	{
		float x = Mathf.Round(pos.x * 16f) / 16f;
		float y = Mathf.Round(pos.y * 16f) / 16f;
		return new Vector2(x, y);
	}

	private void SetAnimation(string newState)
	{
		if (newState != "Trot")
		{
			anim.speed = 1f;
		}
		else
		{
			anim.speed = 1.5f;
			newState = "Walk";
		}
		anim.Play(newState + GetDirectionForAnim(dir));
	}

	private void SetIdleAnimation(string newState)
	{
		anim.speed = 1f;
		anim.Play(newState + GetDirectionForAnim(dirLR));
	}

	private void SetSinglularAnimation(string newState)
	{
		anim.Play(newState);
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
		if (target.x > base.transform.position.x)
		{
			dirLR = Direction.Right;
		}
		else
		{
			dirLR = Direction.Left;
		}
		if (dir == Direction.Down)
		{
			cropSpriteRenderer.transform.localPosition = cDOWN;
		}
		if (dir == Direction.Up)
		{
			cropSpriteRenderer.transform.localPosition = cUP;
		}
		if (dir == Direction.Right)
		{
			cropSpriteRenderer.transform.localPosition = cRIGHT;
		}
		if (dir == Direction.Left)
		{
			cropSpriteRenderer.transform.localPosition = cLEFT;
		}
	}

	private string GetDirectionForAnim(Direction direction)
	{
		return direction switch
		{
			Direction.Down => "Down", 
			Direction.Up => "Up", 
			Direction.Right => "Right", 
			Direction.Left => "Left", 
			_ => "", 
		};
	}

	private void OnDestroy()
	{
		FreeUpSlot();
		GameManager.ins.animals.Remove(base.gameObject);
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
