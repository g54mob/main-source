using System;
using System.Collections;
using UnityEngine;

public class FossilWorkerAI : MonoBehaviour
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

	private float movementSpeed = 1.5f;

	[SerializeField]
	private BuildingProgressBar buildBar;

	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private ParticleSystem particles;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Waiting";

	private const string DIG = "Dig";

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
		StartCoroutine(LookForFossil());
		ChangeAnimatorControllerForCrossover();
	}

	private IEnumerator LookForFossil()
	{
		Vector2 vector = RandomPointOnXYCircle(base.transform.position, 2.5f);
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetAnimation("Waiting");
		interactionScript.isBusy = false;
		yield return new WaitForSeconds(2.5f);
		interactionScript.isBusy = true;
		if (interactionScript.isTalking)
		{
			yield break;
		}
		int num = Inventory.ins.getHighestFossilCost() * 3;
		if (Inventory.ins.fossils > num)
		{
			StartCoroutine(LookForFossil());
			yield break;
		}
		GameManager.ins.fossil.SpawnOnRandomCrop(out var randomCropSlot);
		if (randomCropSlot == null)
		{
			StartCoroutine(LookForFossil());
		}
		else
		{
			StartCoroutine(GoDigFossil());
		}
	}

	private IEnumerator GoDigFossil()
	{
		float x = 1f;
		Vector2 centerTarget = GameManager.ins.fossil.transform.position;
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
		{
			x = 0f;
			centerTarget += Vector2.up * 0.25f;
		}
		centerTarget += Vector2.up * 0.25f;
		Vector2 vector = centerTarget - new Vector2(x, 0f);
		if (base.transform.position.x > centerTarget.x)
		{
			vector = centerTarget + new Vector2(x, 0f);
		}
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		SetDirection(centerTarget);
		SetAnimation("Dig");
		if (SaveData.ins.checkIfCrossover(out var crossover2) && crossover2 == CrossoverFarmType.VampireSurvivors)
		{
			GameManager.ins.fossil.PlayBlueColor();
		}
		int durationInSeconds = 30;
		int multiplier = 16;
		buildBar.BuildFor(durationInSeconds * multiplier);
		for (int i = 0; i < multiplier; i++)
		{
			yield return new WaitForSeconds(durationInSeconds);
			Inventory.ins.AddFossils(1);
			GameManager.ins.SpawnFossilPopUp((Vector2)GameManager.ins.fossil.transform.position + Vector2.up, 1);
		}
		buildBar.ResetBuildBar();
		GameManager.ins.fossil.Despawn();
		StartCoroutine(LookForFossil());
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
		StartCoroutine(LookForFossil());
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
		StartCoroutine(LookForFossil());
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		Vector2 result = center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
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
		}
		else
		{
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
			if ((bool)particles)
			{
				particles.transform.localPosition = new Vector2(0.875f, -0.375f);
			}
		}
		if (num >= 135f || num < -135f)
		{
			dir = Direction.Left;
			if ((bool)particles)
			{
				particles.transform.localPosition = new Vector2(-0.875f, -0.375f);
			}
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
