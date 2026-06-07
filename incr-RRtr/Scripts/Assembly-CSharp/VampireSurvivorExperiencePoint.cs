using System.Collections;
using UnityEngine;

public class VampireSurvivorExperiencePoint : MonoBehaviour
{
	public enum EXPOINT
	{
		Biofuel = 0,
		SpareParts = 1,
		Combined = 2
	}

	private Transform currentTarget;

	private float lerpSpeed = 5f;

	private float range = 3f;

	private bool isLerping;

	[SerializeField]
	private int sparePartsAmount;

	[SerializeField]
	private int biofuelAmount;

	private bool alternate;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite[] sprites;

	public void SetToType(EXPOINT type)
	{
		switch (type)
		{
		case EXPOINT.SpareParts:
			spriteRenderer.sprite = sprites[0];
			break;
		case EXPOINT.Biofuel:
			spriteRenderer.sprite = sprites[1];
			break;
		case EXPOINT.Combined:
			spriteRenderer.sprite = sprites[2];
			break;
		}
		switch (type)
		{
		case EXPOINT.Combined:
			biofuelAmount = Random.Range(1, 4);
			sparePartsAmount = Random.Range(1, 4);
			break;
		case EXPOINT.Biofuel:
			biofuelAmount = 1;
			sparePartsAmount = 0;
			break;
		case EXPOINT.SpareParts:
			biofuelAmount = 0;
			sparePartsAmount = 1;
			break;
		}
	}

	private void LateUpdate()
	{
		if (isLerping)
		{
			return;
		}
		alternate = !alternate;
		if (alternate)
		{
			return;
		}
		if (GameManager.ins.expMagnets.Count > 0)
		{
			foreach (VampireSurvivorExperienceMagnet expMagnet in GameManager.ins.expMagnets)
			{
				if (Vector2.Distance(base.transform.position, expMagnet.transform.position) < range)
				{
					LerpTo(expMagnet.transform);
					break;
				}
			}
		}
		if (Vector2.Distance(base.transform.position, GameManager.ins.mousePositionInWorld) < 1f)
		{
			StartCoroutine(LerpTowardsPosition(GameManager.ins.mousePositionInWorld));
		}
	}

	private void LerpTo(Transform target)
	{
		currentTarget = target;
		isLerping = true;
		StartCoroutine(LerpTowardsTarget());
	}

	private IEnumerator LerpTowardsTarget()
	{
		while (Vector2.Distance(base.transform.position, currentTarget.position) > 0.25f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, currentTarget.position, lerpSpeed * Time.deltaTime);
			yield return null;
		}
		SpawnReward();
		DisableObject();
	}

	private IEnumerator LerpTowardsPosition(Vector2 target)
	{
		currentTarget = null;
		isLerping = true;
		while (Vector2.Distance(base.transform.position, target) > 0.25f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, target, lerpSpeed * 4f * Time.deltaTime);
			yield return null;
		}
		SpawnReward();
		DisableObject();
	}

	private void OnDisable()
	{
		isLerping = false;
	}

	private void SpawnReward()
	{
		Vector2 vector = base.transform.position + Vector3.up * 1.5f;
		if (sparePartsAmount != 0 && biofuelAmount != 0)
		{
			GameManager.ins.SpawnBiofuelPopUp(vector + Vector2.left * 0.5f, biofuelAmount);
			Inventory.ins.AddBiofuel(biofuelAmount);
			GameManager.ins.SpawnSparePartsPopUp(vector + Vector2.right * 0.5f, sparePartsAmount);
			Inventory.ins.AddSpareParts(sparePartsAmount);
		}
		else if (biofuelAmount != 0)
		{
			GameManager.ins.SpawnBiofuelPopUp(vector, biofuelAmount);
			Inventory.ins.AddBiofuel(biofuelAmount);
		}
		else if (sparePartsAmount != 0)
		{
			GameManager.ins.SpawnSparePartsPopUp(vector, sparePartsAmount);
			Inventory.ins.AddSpareParts(sparePartsAmount);
		}
	}

	private void DisableObject()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, range);
	}
}
