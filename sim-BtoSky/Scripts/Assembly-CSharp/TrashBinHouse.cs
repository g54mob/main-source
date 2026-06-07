using UnityEngine;
using UnityEngine.Localization;

public class TrashBinHouse : MonoBehaviour, IInteractable
{
	private LocalizedString interactionDumpString = new LocalizedString("MyTable", "trash");

	private LocalizedString interactionTakeString = new LocalizedString("MyTable", "takeoutTrash");

	private LocalizedString interactionEmptyString = new LocalizedString("MyTable", "empty");

	public Outline outLine;

	private int numOfTrash;

	private float weightOfTrash;

	private float lowTrashPos = 0.15f;

	[SerializeField]
	private GameObject trashBagPrefab;

	[SerializeField]
	private GameObject trashBagGO;

	public string InteractionText
	{
		get
		{
			if (FirstPersonController.S.itemOnHand != null)
			{
				if (FirstPersonController.S.itemOnHand.TryGetComponent<Trash>(out var _))
				{
					return interactionDumpString.GetLocalizedString();
				}
				return "";
			}
			if (numOfTrash > 0)
			{
				return interactionTakeString.GetLocalizedString();
			}
			return interactionEmptyString.GetLocalizedString();
		}
	}

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	public void Interact()
	{
		if (FirstPersonController.S.itemOnHand != null)
		{
			if (FirstPersonController.S.itemOnHand.TryGetComponent<Trash>(out var component))
			{
				numOfTrash++;
				weightOfTrash += component.GetComponent<Rigidbody>().mass;
				if (numOfTrash <= 6)
				{
					trashBagGO.transform.localPosition = new Vector3(trashBagGO.transform.localPosition.x, lowTrashPos + (float)numOfTrash * 0.07f, trashBagGO.transform.localPosition.z);
				}
				FirstPersonController.S.ComsumeItem();
				AudioManager.S.PlaySFX(AudioManager.S.trash);
			}
			else
			{
				GameManager.S.TryTrashWrongStuff();
				AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
			}
		}
		else if (numOfTrash > 0)
		{
			GameObject gameObject = Object.Instantiate(trashBagPrefab, base.transform.position, Quaternion.identity);
			gameObject.GetComponent<Rigidbody>().mass = weightOfTrash;
			FirstPersonController.S.GrabItem(gameObject);
			numOfTrash = 0;
			weightOfTrash = 0f;
			trashBagGO.transform.localPosition = new Vector3(trashBagGO.transform.localPosition.x, lowTrashPos, trashBagGO.transform.localPosition.z);
		}
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
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
