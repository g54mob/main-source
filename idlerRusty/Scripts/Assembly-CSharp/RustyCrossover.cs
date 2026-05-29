using System;
using System.Collections;
using Steamworks;
using UnityEngine;

public class RustyCrossover : MonoBehaviour
{
	public enum Direction
	{
		Down = 0,
		Up = 1,
		Right = 2,
		Left = 3
	}

	[Header("Visuals")]
	[SerializeField]
	private Animator workerAnim;

	[SerializeField]
	private Animator hatAnim;

	[Space]
	[SerializeField]
	private AnimatorOverrideController goldenSkin;

	[SerializeField]
	private GameObject goldenParticles;

	private bool needsRest;

	private float movementSpeed = 1f;

	private int walkCycle;

	private Direction dir;

	private const string DOWN = "Down";

	private const string UP = "Up";

	private const string RIGHT = "Right";

	private const string LEFT = "Left";

	private const string WALK = "Walk";

	private const string WAIT = "Waiting";

	private const string SIT = "Sit";

	private const string BUILD = "Build";

	private const string BENCH = "Bench";

	private void Start()
	{
		Bench closestBench = GameManager.ins.getClosestBench(base.transform.position);
		if ((bool)closestBench)
		{
			base.transform.position = closestBench.transform.position;
		}
		NeedsRest();
		PickNextAction();
		StartCoroutine(CheckIfSupporterDLC());
		CheckChristmasHat();
	}

	private IEnumerator CheckIfSupporterDLC()
	{
		int counter = 0;
		while (!SteamManager.Initialized)
		{
			yield return null;
			counter++;
			if (counter >= 500)
			{
				yield break;
			}
		}
		if (SteamApps.BIsDlcInstalled(new AppId_t(2943560u)))
		{
			if ((bool)goldenSkin)
			{
				workerAnim.runtimeAnimatorController = goldenSkin;
			}
			if ((bool)goldenParticles)
			{
				goldenParticles.SetActive(value: true);
			}
		}
	}

	private void CheckChristmasHat()
	{
		if (DateTime.Now.Month == 12 && (bool)hatAnim)
		{
			hatAnim.gameObject.SetActive(value: true);
		}
	}

	private void SetAnimation(string newState)
	{
		workerAnim.Play(newState + GetDirectionForAnim());
		if ((bool)hatAnim && hatAnim.gameObject.activeInHierarchy)
		{
			hatAnim.Play(newState + GetDirectionForAnim());
		}
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

	private void PickNextAction()
	{
		if (needsRest)
		{
			Bench closestBench = GameManager.ins.getClosestBench(base.transform.position);
			if ((bool)closestBench)
			{
				StartCoroutine(RestOnBench(closestBench));
				return;
			}
		}
		if (walkCycle < 5)
		{
			walkCycle++;
			StartCoroutine(WalkToRandomSpot());
		}
		else
		{
			walkCycle = 0;
			StartCoroutine(SitOnFloor());
		}
	}

	private IEnumerator WalkToRandomSpot()
	{
		Vector2 vector = RandomPointOnXYCircle(base.transform.position, 3f);
		SetDirection(vector);
		SetAnimation("Walk");
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		StartCoroutine(WaitForNextAction());
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

	private IEnumerator SitOnFloor()
	{
		SetAnimation("Sit");
		yield return new WaitForSeconds(UnityEngine.Random.Range(15, 60));
		StartCoroutine(WaitForNextAction());
	}

	private IEnumerator WaitForNextAction()
	{
		SetAnimation("Waiting");
		yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
		PickNextAction();
	}

	public void NeedsRest()
	{
		needsRest = true;
	}

	private IEnumerator RestOnBench(Bench bench)
	{
		if (bench == null)
		{
			StartCoroutine(WaitForNextAction());
			yield break;
		}
		SetDirection(bench.transform.position);
		SetAnimation("Walk");
		bench.SetOccupied(state: true);
		yield return new WaitForPositionReached(base.transform, bench.transform.position, movementSpeed);
		workerAnim.Play("Bench");
		if ((bool)hatAnim)
		{
			hatAnim.Play("Bench");
		}
		float seconds = 60f;
		float time = 60 + UnityEngine.Random.Range(180, 480);
		Invoke("NeedsRest", time);
		yield return new WaitForSeconds(seconds);
		if (bench == null)
		{
			PickNextAction();
			yield break;
		}
		SetDirection(bench.transform.position + Vector3.down);
		SetAnimation("Walk");
		bench.SetOccupied(state: false);
		needsRest = false;
		yield return new WaitForPositionReached(base.transform, bench.transform.position + Vector3.down * 0.5f, movementSpeed);
		PickNextAction();
	}
}
