using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAI : MonoBehaviour
{
	private float movementSpeed;

	private float movementSpeedQOL = 0.375f;

	[SerializeField]
	private BuildingSO bufferflySO;

	private SpriteRenderer sr;

	[SerializeField]
	private int amountOfBioPollen;

	private int targetAmount = 8;

	[SerializeField]
	private Transform parentCage;

	private BerryBush targetBush;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		StartCoroutine(MoveSlightly());
		amountOfBioPollen = Random.Range(0, targetAmount);
		GameManager.ins.beesButterflies.Add(base.gameObject);
		SaveData.ins.UpdateTotalBees();
	}

	private void OnDestroy()
	{
		GameManager.ins.beesButterflies.Remove(base.gameObject);
		SaveData.ins.UpdateTotalBees();
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

	private void PickNextAction()
	{
		if (amountOfBioPollen >= targetAmount && (bool)parentCage)
		{
			StartCoroutine(GoToButterflyCage());
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
		Transform transform = parentCage;
		int num = 2;
		for (int i = 0; i < GameManager.ins.berryBushes.Count; i++)
		{
			if (GameManager.ins.berryBushes[i].occupants.Count < num && Vector2.Distance(GameManager.ins.berryBushes[i].transform.position, transform.position) < (float)bufferflySO.rangeSize)
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

	private IEnumerator GoToButterflyCage()
	{
		if ((bool)this)
		{
			Vector2 vector = parentCage.position + Vector3.down * 0.0625f;
			if (Random.value > 0.5f)
			{
				vector += Vector2.up * 0.0625f;
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
			amountOfBioPollen = 0;
			StartCoroutine(MoveSlightly());
		}
	}
}
