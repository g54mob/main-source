using System.Collections;
using UnityEngine;

public class VirusAI : MonoBehaviour
{
	private float movementSpeed;

	[SerializeField]
	private int cycle = 400;

	[SerializeField]
	private ParticleSystem particles;

	private void Start()
	{
		StartCoroutine(MoveToRandomSpot());
	}

	private IEnumerator MoveToRandomSpot()
	{
		movementSpeed = Random.Range(0.1f, 0.25f);
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
		}
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		PickNextAction();
	}

	private Vector2 RandomPoint()
	{
		float x = Random.Range(-3f, 3f);
		float y = Random.Range(-3f, 3f);
		return (Vector2)base.transform.position + new Vector2(x, y);
	}

	private void PickNextAction()
	{
		cycle++;
		if (cycle > 400)
		{
			CropSlot closestCropSlotThat = GameManager.ins.getClosestCropSlotThat(CropSlot.State.NeedHarvest, base.transform.position);
			if ((bool)closestCropSlotThat)
			{
				StartCoroutine(DestroyRandomCrop(closestCropSlotThat));
				return;
			}
		}
		StartCoroutine(MoveToRandomSpot());
	}

	private IEnumerator DestroyRandomCrop(CropSlot crop)
	{
		movementSpeed = 0.5f;
		Vector2 vector = crop.transform.position;
		crop.state = CropSlot.State.MarkedForHarvest;
		yield return new WaitForPositionReached(base.transform, vector, movementSpeed);
		particles.Play();
		yield return new WaitForSeconds(1.75f);
		if ((bool)crop && crop.cropType != CropType.None)
		{
			crop.RemoveCropNoSound();
		}
		yield return new WaitForSeconds(0.75f);
		cycle = 0;
		PickNextAction();
	}
}
