using System;
using System.Collections;
using UnityEngine;

public class BeekeeperAI : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private CharacterInteraction interactionScript;

	private float movementSpeed = 1f;

	private bool alternateMovement;

	[SerializeField]
	private int restTimerInSeconds = 120;

	private float restTimer;

	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private bool needsRest;

	[SerializeField]
	private bool speedBoost;

	[SerializeField]
	private int currentBeehiveIndex;

	private Vector3 hiveOffset = Vector3.left;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Waiting";

	private const string BENCH = "Bench";

	private const string COLLECT = "Harvest";

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
		if (crossover == CrossoverFarmType.VampireSurvivors)
		{
			hiveOffset = new Vector3(-1.5f, 0f, 0f);
		}
		SetDirection(base.transform.position + Vector3.right);
		SetAnimation("Waiting");
	}

	private void Start()
	{
		StartCoroutine(WaitForNextAction());
		ChangeAnimatorControllerForCrossover();
		InvokeRepeating("NeedsRest", UnityEngine.Random.Range(120, 300), 300f);
	}

	private void PickNextAction()
	{
		Beehive closestBeehiveMarkedForHarvest = GameManager.ins.getClosestBeehiveMarkedForHarvest(base.transform.position);
		if ((bool)closestBeehiveMarkedForHarvest)
		{
			StartCoroutine(GoToBeehive(closestBeehiveMarkedForHarvest));
			return;
		}
		if (GameManager.ins.benches.Count > 0 && needsRest)
		{
			StartCoroutine(RestOnBench());
			return;
		}
		CharacterInteraction characterInteraction = GameManager.ins.GetFreeNPCinRange(base.transform.position, 15f);
		if (SaveData.ins.checkIfCrossover())
		{
			characterInteraction = null;
		}
		if (characterInteraction != null && characterInteraction != interactionScript.lastNpc && UnityEngine.Random.value < 0.25f && GameManager.ins.isPathFree(base.transform.position, characterInteraction.transform.position))
		{
			StartCoroutine(MeetCharacter(characterInteraction));
		}
		else
		{
			StartCoroutine(WaitForNextAction());
		}
	}

	private IEnumerator MeetCharacter(CharacterInteraction npc)
	{
		interactionScript.lastNpc = npc;
		npc.lastNpc = interactionScript;
		interactionScript.isTalking = true;
		npc.isTalking = true;
		npc.TriggerWalkToMeetCharacter(base.transform.position);
		yield return WalkToMeetCharacter(npc.transform.position);
		for (int i = 0; i < 3; i++)
		{
			npc.PlayTopic();
			yield return new WaitForSeconds(5f);
			npc.StopTopic();
			interactionScript.PlayTopic();
			yield return new WaitForSeconds(5f);
			interactionScript.StopTopic();
		}
		interactionScript.isTalking = false;
		npc.isTalking = false;
		npc.TriggerEndOfTalk();
		StartCoroutine(WaitForNextAction());
	}

	public IEnumerator WalkToMeetCharacter(Vector3 othernpcPosition)
	{
		Vector2 vector = (base.transform.position + othernpcPosition) / 2f;
		Vector2 vector2 = othernpcPosition - base.transform.position;
		_ = vector + vector2.normalized * 0.75f;
		Vector2 vector3 = ((!(base.transform.position.x < vector.x)) ? (vector + Vector2.right * 0.75f) : (vector + Vector2.left * 0.75f));
		SetDirection(vector3);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector3, 1.2f);
		SetDirection(base.transform.position + Vector3.down);
		SetAnimation("Waiting");
	}

	public void FinishTalking()
	{
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator WaitForNextAction()
	{
		if (alternateMovement)
		{
			Vector2 vector = RandomPointOnXYCircle(base.transform.position, 2f);
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
			SetDirection(vector);
			SetAnimation("Walk");
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		}
		else
		{
			SetAnimation("Waiting");
			interactionScript.isBusy = false;
			yield return new WaitForSeconds(2f);
			interactionScript.isBusy = true;
			if (interactionScript.isTalking)
			{
				yield break;
			}
		}
		alternateMovement = !alternateMovement;
		PickNextAction();
	}

	private IEnumerator GoToBeehive(Beehive hive)
	{
		if (hive == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		Vector2 vector = hive.transform.position + hiveOffset;
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		workerAnim.Play("Harvest");
		yield return new WaitForSeconds(0.5f);
		if (hive == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		hive.HarvestBiofuel();
		yield return new WaitForSeconds(0.1f);
		SetDirection(base.transform.position + Vector3.right);
		SetAnimation("Waiting");
		yield return new WaitForSeconds(1f);
		alternateMovement = false;
		StartCoroutine(WaitForNextAction());
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
		if ((bool)workerAnim)
		{
			workerAnim.Play("Bench");
		}
		float seconds = UnityEngine.Random.Range((float)restTimerInSeconds * 0.5f, restTimerInSeconds);
		yield return new WaitForSeconds(seconds);
		if (benchTarget == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(benchTarget.transform.position + Vector3.down);
		SetAnimation("Walk");
		benchTarget.SetOccupied(state: false);
		needsRest = false;
		StartSpeedBoost();
		yield return new WaitForPositionReached(base.transform, benchTarget.transform.position, movementSpeed);
		StartCoroutine(WaitForNextAction());
	}

	private void NeedsRest()
	{
		needsRest = true;
	}

	private void StartSpeedBoost()
	{
		if (!speedBoost)
		{
			speedBoost = true;
			movementSpeed = 1.25f;
			Invoke("EndSpeedBoost", 300f);
		}
	}

	private void EndSpeedBoost()
	{
		speedBoost = false;
		movementSpeed = 1f;
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private void SetAnimation(string newState)
	{
		if (!(workerAnim == null))
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
