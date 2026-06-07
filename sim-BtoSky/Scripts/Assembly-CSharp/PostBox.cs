using UnityEngine;
using UnityEngine.Localization;

public class PostBox : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "interaction-inscert");

	public Outline outLine;

	public bool isOpened;

	public string InteractionText
	{
		get
		{
			if (isOpened)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (FirstPersonController.S.itemOnHand.TryGetComponent<NewsPapers>(out var _))
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
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		QuestManager.S.OnNewsPaperDeliveryStarted += Qm_OnNewsPaperDeliveryStarted;
		QuestManager.S.OnNewsPaperDeliveryCompleted += Qm_OnNewsPaperDeliveryCompleted;
	}

	private void Qm_OnNewsPaperDeliveryCompleted()
	{
		isOpened = false;
		Collider[] components = GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = false;
		}
	}

	private void OnDestroy()
	{
		QuestManager.S.OnNewsPaperDeliveryStarted -= Qm_OnNewsPaperDeliveryStarted;
		QuestManager.S.OnNewsPaperDeliveryCompleted -= Qm_OnNewsPaperDeliveryCompleted;
	}

	private void Qm_OnNewsPaperDeliveryStarted()
	{
		isOpened = true;
		Collider[] components = GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = true;
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (isOpened && player.itemOnHand != null && player.itemOnHand.TryGetComponent<NewsPapers>(out var component))
		{
			QuestManager.S.NewspaperDelivered();
			component.PutNewspaper();
			isOpened = false;
			AudioManager.S.PlaySFX(AudioManager.S.postBox);
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
