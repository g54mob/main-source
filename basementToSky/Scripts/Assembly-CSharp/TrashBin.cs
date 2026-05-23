using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class TrashBin : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "trash");

	private bool isOpened;

	public Outline outLine;

	private List<GameObject> trashes;

	[SerializeField]
	private GameObject[] trashesPrefab;

	public string InteractionText
	{
		get
		{
			if (isOpened)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (FirstPersonController.S.itemOnHand.TryGetComponent<TrashBag>(out var _))
					{
						return interactionString.GetLocalizedString();
					}
					return "";
				}
				return "";
			}
			return "";
		}
	}

	private void Start()
	{
		QuestManager.S.OnCleanUpStarted += Qm_OnCleanUpStarted;
		QuestManager.S.OnCleanUpCompleted += Qm_OnCleanUpCompleted;
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		InitTrashes();
	}

	private void Qm_OnCleanUpCompleted()
	{
		isOpened = false;
	}

	private void Qm_OnCleanUpStarted()
	{
		isOpened = true;
	}

	public void RefillTrashes()
	{
		float num = 1f;
		for (int i = 0; i < trashes.Count; i++)
		{
			if (trashes[i] == null)
			{
				GameObject original = trashesPrefab[Random.Range(0, trashesPrefab.Length)];
				Vector2 vector = Random.insideUnitCircle * num;
				Vector3 position = base.transform.position + new Vector3(vector.x, 1f, vector.y);
				Quaternion rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
				GameObject value = Object.Instantiate(original, position, rotation);
				trashes[i] = value;
			}
		}
	}

	private void InitTrashes()
	{
		float num = 1f;
		trashes = new List<GameObject>();
		for (int i = 0; i < 5; i++)
		{
			GameObject original = trashesPrefab[Random.Range(0, trashesPrefab.Length)];
			Vector2 vector = Random.insideUnitCircle * num;
			Vector3 position = base.transform.position + new Vector3(vector.x, 1f, vector.y);
			Quaternion rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
			GameObject item = Object.Instantiate(original, position, rotation);
			trashes.Add(item);
		}
	}

	public void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (isOpened && player.itemOnHand != null && player.itemOnHand.TryGetComponent<TrashBag>(out var component))
		{
			Object.Destroy(component.gameObject);
			player.itemOnHand = null;
			QuestManager.S.TrashbagCleaned();
			player.ItemOutHand();
			AudioManager.S.PlaySFX(AudioManager.S.trash);
		}
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			if (!isOpened)
			{
				outLine.enabled = false;
			}
			else
			{
				outLine.enabled = true;
			}
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}
}
