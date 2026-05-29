using System;
using System.Collections;
using UnityEngine;

public class UpgradeWorkerAI : MonoBehaviour
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
	private BuildingProgressBar buildBar;

	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private ParticleSystem particles;

	private Building targetBuilding;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Wait";

	private const string CRAFT = "Craft";

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
			particles = null;
		}
		if (crossover == CrossoverFarmType.Balatro)
		{
			particles = null;
		}
		SetDirection(base.transform.position + Vector3.right);
		SetAnimation("Wait");
	}

	private void Start()
	{
		PickNextAction();
		ChangeAnimatorControllerForCrossover();
	}

	private void PickNextAction()
	{
		if (!this)
		{
			return;
		}
		Building closestBuildSlotThat = GameManager.ins.getClosestBuildSlotThat(Building.State.NeedsUpgrading, base.transform.position);
		if (closestBuildSlotThat != null)
		{
			StartCoroutine(Upgrade(closestBuildSlotThat));
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

	private IEnumerator WaitForNextAction()
	{
		if (alternateMovement)
		{
			Vector2 vector = RandomPointOnXYCircle(base.transform.position, 0.75f);
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
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed * 0.5f);
		}
		else
		{
			SetAnimation("Wait");
			interactionScript.isBusy = false;
			yield return new WaitForSeconds(1f);
			interactionScript.isBusy = true;
			if (interactionScript.isTalking)
			{
				yield break;
			}
		}
		alternateMovement = !alternateMovement;
		PickNextAction();
	}

	private Vector2 RandomPointOnXYCircle(Vector2 center, float radius)
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return center + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * radius;
	}

	private IEnumerator Upgrade(Building building)
	{
		if (building == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		targetBuilding = building;
		float x = 1f;
		Vector2 centerTarget = building.center.position;
		Vector2 vector = centerTarget - new Vector2(x, 0f);
		if (base.transform.position.x > centerTarget.x)
		{
			vector = centerTarget + new Vector2(x, 0f);
		}
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		if ((bool)building)
		{
			SetDirection(centerTarget);
			SetAnimation("Craft");
			int upgradeTime = building.building.constructionTime * 60;
			if (SaveData.ins.focusMode)
			{
				upgradeTime *= 2;
			}
			building.StartUpgrading();
			buildBar.BuildFor(upgradeTime);
			yield return new WaitForSeconds(0.5f);
			if ((bool)particles)
			{
				particles.Play();
			}
			yield return new WaitForSeconds(upgradeTime);
			if ((bool)building)
			{
				building.FinishUpgrading();
			}
			buildBar.ResetBuildBar();
			if ((bool)particles)
			{
				particles.Stop();
			}
		}
		targetBuilding = null;
		SetAnimation("Wait");
		yield return new WaitForSeconds(0.5f);
		PickNextAction();
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
		SetAnimation("Wait");
	}

	public void FinishTalking()
	{
		StartCoroutine(WaitForNextAction());
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
				particles.transform.localPosition = Vector2.right;
			}
		}
		if (num >= 135f || num < -135f)
		{
			dir = Direction.Left;
			if ((bool)particles)
			{
				particles.transform.localPosition = Vector2.left;
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
