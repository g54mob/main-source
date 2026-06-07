using System.Collections;
using UnityEngine;

public class QuestIndicator : MonoBehaviour
{
	public QuestType type;

	public float rotateSpeed = 30f;

	private bool isActive;

	private void Start()
	{
		QuestManager.S.OnGarageCleaningStart += S_OnGarageCleaningStart;
		QuestManager.S.OnMowingStarted += S_OnMowingStarted;
		QuestManager.S.OnCleanUpCompleted += S_OnCleanUpCompleted;
		QuestManager.S.OnGarageCleaningCompleted += S_OnGarageCleaningCompleted;
		QuestManager.S.OnNewsPaperDeliveryCompleted += S_OnNewsPaperDeliveryCompleted;
		QuestManager.S.OnMowingCompleted += S_OnMowingCompleted;
		StartCoroutine(DelayedCheckActive());
	}

	private IEnumerator DelayedCheckActive()
	{
		yield return null;
		if (!isActive)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void S_OnMowingStarted()
	{
		if (type == QuestType.Mowing)
		{
			base.gameObject.SetActive(value: true);
			isActive = true;
		}
	}

	private void S_OnGarageCleaningStart()
	{
		if (type == QuestType.GarageCleaning)
		{
			base.gameObject.SetActive(value: true);
			isActive = true;
		}
	}

	private void OnDestroy()
	{
		QuestManager.S.OnGarageCleaningStart -= S_OnGarageCleaningStart;
		QuestManager.S.OnMowingStarted -= S_OnMowingStarted;
		QuestManager.S.OnCleanUpCompleted -= S_OnCleanUpCompleted;
		QuestManager.S.OnGarageCleaningCompleted -= S_OnGarageCleaningCompleted;
		QuestManager.S.OnNewsPaperDeliveryCompleted -= S_OnNewsPaperDeliveryCompleted;
		QuestManager.S.OnMowingCompleted -= S_OnMowingCompleted;
	}

	private void S_OnMowingCompleted()
	{
		if (type == QuestType.Mowing)
		{
			base.gameObject.SetActive(value: false);
			isActive = false;
		}
	}

	private void S_OnNewsPaperDeliveryCompleted()
	{
		if (type == QuestType.Newspaper)
		{
			base.gameObject.SetActive(value: false);
			isActive = false;
		}
	}

	private void S_OnGarageCleaningCompleted()
	{
		if (type == QuestType.GarageCleaning)
		{
			base.gameObject.SetActive(value: false);
			isActive = false;
		}
	}

	private void S_OnCleanUpCompleted()
	{
		if (type == QuestType.Trash)
		{
			base.gameObject.SetActive(value: false);
			isActive = false;
		}
	}

	private void Update()
	{
		base.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
	}
}
