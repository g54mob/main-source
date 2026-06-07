using System;
using System.Collections;
using UnityEngine;

public class PinionAI : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private CharacterInteraction interactionScript;

	private float speed = 0.75f;

	[Header("Crossover visuals")]
	[SerializeField]
	private CrossoverSkin[] crossoverSkins;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Waiting";

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
			speed = 0.33f;
		}
		SetDirection(base.transform.position + Vector3.right);
		SetAnimation("Waiting");
	}

	private void Start()
	{
		StartCoroutine(Wait());
		ChangeAnimatorControllerForCrossover();
	}

	private IEnumerator Wait()
	{
		CharacterInteraction characterInteraction = GameManager.ins.GetFreeNPCinRange(base.transform.position, 15f);
		if (SaveData.ins.checkIfCrossover())
		{
			characterInteraction = null;
		}
		if (characterInteraction != null && characterInteraction != interactionScript.lastNpc && UnityEngine.Random.value < 0.25f && GameManager.ins.isPathFree(base.transform.position, characterInteraction.transform.position))
		{
			interactionScript.lastNpc = characterInteraction;
			characterInteraction.lastNpc = interactionScript;
			StartCoroutine(MeetCharacter(characterInteraction));
			yield break;
		}
		SetAnimation("Waiting");
		interactionScript.isBusy = false;
		float seconds = UnityEngine.Random.Range(5f, 15f);
		yield return new WaitForSeconds(seconds);
		interactionScript.isBusy = true;
		if (!interactionScript.isTalking)
		{
			StartCoroutine(WalkToNewSpot());
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
		StartCoroutine(Wait());
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
		StartCoroutine(Wait());
	}

	private IEnumerator WalkToNewSpot()
	{
		Vector2 vector = RandomPointOnXYCircle(base.transform.position, UnityEngine.Random.Range(2f, 5f));
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, speed);
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
		{
			StartCoroutine(WalkToNewSpot());
		}
		else
		{
			StartCoroutine(Wait());
		}
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		Vector2 result = center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
		if (SaveData.ins.verticalMode)
		{
			if (result.x > 7f)
			{
				result = new Vector2(7f, result.y);
			}
			if (result.x < -7f)
			{
				result = new Vector2(-7f, result.y);
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

	private void SetAnimation(string newState)
	{
		workerAnim.Play(newState + GetDirectionForAnim());
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
