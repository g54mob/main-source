using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldcrest : MonoBehaviour
{
	public GoldcrestPos currentPos;

	[SerializeField]
	private Animator anim;

	private SpriteRenderer sr;

	private int cycles;

	private int maxCycles = 10;

	private const string FLY = "Fly";

	private const string IDLE = "Idle";

	private const string PECK = "Peck";

	private const string PECKPECK = "PeckPeck";

	private const string PECKPECKPECK = "PeckPeckPeck";

	private const string STARTLOOK = "LookSide";

	private const string ENDLOOK = "LookForward";

	private void Start()
	{
		if (!GameManager.ins.contentUpdate)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		base.transform.parent = null;
		sr = GetComponent<SpriteRenderer>();
		maxCycles = Random.Range(10, 20);
		cycles = Random.Range(0, 10);
		PickNextAction();
	}

	private void PickNextAction()
	{
		cycles++;
		if (cycles < maxCycles)
		{
			if (Random.value < 0.33f)
			{
				StartCoroutine(Peck());
			}
			else if (Random.value > 0.67f)
			{
				StartCoroutine(LookAround());
			}
			else
			{
				StartCoroutine(WaitForNextAction());
			}
		}
		else
		{
			cycles = 0;
			GoldcrestPos targetPos = getTargetPos();
			if ((bool)targetPos)
			{
				StartCoroutine(FlyToNewPosition(targetPos));
			}
			else
			{
				StartCoroutine(WaitForNextAction());
			}
		}
	}

	private IEnumerator WaitForNextAction()
	{
		yield return new WaitForSeconds(Random.Range(1f, 3f));
		PickNextAction();
	}

	private IEnumerator FlyToNewPosition(GoldcrestPos newPosition)
	{
		sr.sortingOrder = 1;
		if ((bool)currentPos)
		{
			currentPos.occupied = false;
		}
		currentPos = newPosition;
		currentPos.occupied = true;
		SetDirection(currentPos.transform.position);
		SetAnimation("Fly");
		float speed = Random.Range(0.8f, 1.8f);
		yield return new WaitForPositionReached(base.transform, newPosition.transform.position, speed);
		SetAnimation("Idle");
		if (currentPos != null && currentPos.setLayerToZero)
		{
			sr.sortingOrder = 0;
		}
		yield return new WaitForSeconds(Random.Range(1f, 3f));
		PickNextAction();
	}

	private GoldcrestPos getTargetPos()
	{
		List<GoldcrestPos> list = new List<GoldcrestPos>();
		for (int i = 0; i < GameManager.ins.goldcrestPositions.Count; i++)
		{
			if (!GameManager.ins.goldcrestPositions[i].occupied && Vector2.Distance(GameManager.ins.goldcrestPositions[i].transform.position, base.transform.position) < 20f)
			{
				list.Add(GameManager.ins.goldcrestPositions[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[Random.Range(0, list.Count)];
	}

	private IEnumerator Peck()
	{
		string animation = "Peck";
		if (Random.value < 0.33f)
		{
			animation = "PeckPeck";
		}
		if (Random.value > 0.67f)
		{
			animation = "PeckPeckPeck";
		}
		SetAnimation(animation);
		yield return new WaitForSeconds(Random.Range(1.2f, 3f));
		PickNextAction();
	}

	private IEnumerator LookAround()
	{
		SetAnimation("LookSide");
		yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
		SetAnimation("LookForward");
		yield return new WaitForSeconds(Random.Range(1.5f, 3f));
		PickNextAction();
	}

	private void SetDirection(Vector2 target)
	{
		if (target.x < base.transform.position.x)
		{
			base.transform.localScale = new Vector3(1f, 1f);
		}
		else
		{
			base.transform.localScale = new Vector3(-1f, 1f);
		}
	}

	private void SetAnimation(string state)
	{
		if ((bool)anim)
		{
			anim.Play(state);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(base.transform.position, 20f);
	}
}
