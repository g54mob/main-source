using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbletAI : MonoBehaviour
{
	private float movementSpeed;

	private float movementSpeedQOL = 0.5f;

	[SerializeField]
	private BuildingSO beehiveSO;

	private SpriteRenderer sr;

	[SerializeField]
	private int amountOfBioPollen;

	private int targetAmount = 16;

	[SerializeField]
	private Beehive parentHive;

	private BerryBush targetBush;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		StartCoroutine(MoveSlightly());
		amountOfBioPollen = Random.Range(0, targetAmount);
		GameManager.ins.bees.Add(this);
		GameManager.ins.beesButterflies.Add(base.gameObject);
		SaveData.ins.UpdateTotalBees();
		GameManager.ins.DistributeBees();
	}

	private void OnDestroy()
	{
		GameManager.ins.bees.Remove(this);
		GameManager.ins.beesButterflies.Remove(base.gameObject);
		SaveData.ins.UpdateTotalBees();
		GameManager.ins.DistributeBees();
		if ((bool)targetBush)
		{
			targetBush.RemoveOccupant(base.transform);
		}
	}

	private IEnumerator MoveSlightly()
	{
		if (!this)
		{
			yield break;
		}
		movementSpeed = Random.Range(0.06f, 0.12f);
		Vector2 vector = RandomPoint();
		if (SaveData.ins.verticalMode)
		{
			if (vector.x > 7.5f)
			{
				vector = new Vector2(7f, vector.y);
			}
			if (vector.x < -7.5f)
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
			if (vector.y > 4.5f)
			{
				vector = new Vector2(vector.x, 4f);
			}
			if (vector.y < -4f)
			{
				vector = new Vector2(vector.x, -3.5f);
			}
			if (vector.x > 81f)
			{
				vector = new Vector2(81f, vector.y);
			}
			if (vector.x < -81f)
			{
				vector = new Vector2(-81f, vector.y);
			}
		}
		if (base.transform.position.x > vector.x)
		{
			sr.flipX = true;
		}
		if (base.transform.position.x < vector.x)
		{
			sr.flipX = false;
		}
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		PickNextAction();
	}

	private Vector2 RandomPoint()
	{
		float x = Random.Range(-0.5f, 0.5f);
		float y = Random.Range(-0.5f, 0.5f);
		return (Vector2)base.transform.position + new Vector2(x, y);
	}

	private void OnDrawGizmos()
	{
	}

	public void AssignNewBeehiveAsParent(Beehive beehive)
	{
		parentHive = beehive;
	}

	private void PickNextAction()
	{
		if (amountOfBioPollen >= targetAmount && (bool)parentHive)
		{
			StartCoroutine(GoToBeehive(parentHive));
			return;
		}
		BerryBush berryBush = NearbyBerryBush();
		if ((bool)berryBush)
		{
			StartCoroutine(VisitBerryBush(berryBush));
		}
		else
		{
			StartCoroutine(MoveSlightly());
		}
	}

	private BerryBush NearbyBerryBush()
	{
		List<BerryBush> list = new List<BerryBush>();
		Transform transform = base.transform;
		if ((bool)parentHive)
		{
			transform = parentHive.transform;
		}
		int num = 2;
		for (int i = 0; i < GameManager.ins.berryBushes.Count; i++)
		{
			if (GameManager.ins.berryBushes[i].occupants.Count < num && Vector2.Distance(GameManager.ins.berryBushes[i].transform.position, transform.position) < (float)beehiveSO.rangeSize)
			{
				list.Add(GameManager.ins.berryBushes[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[Random.Range(0, list.Count)];
	}

	private IEnumerator VisitBerryBush(BerryBush bush)
	{
		if (!this)
		{
			yield break;
		}
		if ((bool)bush)
		{
			bush.AddOccupant(base.transform);
		}
		if ((bool)bush)
		{
			targetBush = bush;
		}
		float num = Random.Range(0.125f, 1f);
		Vector2 vector = bush.transform.position + Vector3.right * num;
		if (base.transform.position.x > vector.x)
		{
			sr.flipX = true;
		}
		if (base.transform.position.x < vector.x)
		{
			sr.flipX = false;
		}
		movementSpeed = movementSpeedQOL;
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		yield return new WaitForSeconds(Random.Range(6f, 12f));
		if (bush == null)
		{
			StartCoroutine(MoveSlightly());
			yield break;
		}
		if ((bool)bush)
		{
			bush.Pollinate();
		}
		if ((bool)bush)
		{
			bush.RemoveOccupant(base.transform);
		}
		amountOfBioPollen++;
		StartCoroutine(MoveSlightly());
	}

	private IEnumerator GoToBeehive(Beehive hive)
	{
		if ((bool)this)
		{
			Vector2 vector = hive.transform.position + Vector3.down * 0.0625f;
			if (Random.value > 0.5f)
			{
				vector += Vector2.down * 0.0625f;
			}
			if (Random.value > 0.5f)
			{
				vector += Vector2.right * Random.Range(0.0625f, 0.25f);
			}
			else
			{
				vector += Vector2.left * Random.Range(0.0625f, 0.25f);
			}
			if (base.transform.position.x > vector.x)
			{
				sr.flipX = true;
			}
			if (base.transform.position.x < vector.x)
			{
				sr.flipX = false;
			}
			movementSpeed = movementSpeedQOL;
			yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
			if ((bool)hive)
			{
				hive.AddNectarToHive();
			}
			if ((bool)hive)
			{
				amountOfBioPollen = 0;
			}
			if ((bool)hive)
			{
				yield return new WaitForSeconds(Random.Range(6f, 12f));
			}
			StartCoroutine(MoveSlightly());
		}
	}
}
