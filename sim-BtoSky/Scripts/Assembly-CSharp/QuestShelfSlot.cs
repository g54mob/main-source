using UnityEngine;
using UnityEngine.Localization;

public class QuestShelfSlot : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "interaction-place");

	[SerializeField]
	private Shelf shelf;

	private Item mountedItem;

	public string InteractionText
	{
		get
		{
			if (mountedItem == null)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (FirstPersonController.S.itemOnHand.TryGetComponent<Item>(out var component))
					{
						if (component.itemName == "Garage")
						{
							if (mountedItem == null)
							{
								return interactionString.GetLocalizedString();
							}
							return "";
						}
						return "";
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
		QuestManager.S.OnGarageCleaningStart += Gm_OnGarageCleaningStart;
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
	}

	private void OnDestroy()
	{
		QuestManager.S.OnGarageCleaningStart -= Gm_OnGarageCleaningStart;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SaveLayer();
	}

	private void Gm_OnGarageCleaningStart()
	{
	}

	private void Update()
	{
	}

	private void SaveLayer()
	{
		ES3.Save("QuestShelf_Layer", base.gameObject.layer);
	}

	public void Interact()
	{
		FirstPersonController player = GameManager.S.player;
		if (mountedItem == null && player.itemOnHand != null && player.itemOnHand.TryGetComponent<Item>(out var component) && component.itemName == "Garage")
		{
			mountedItem = component;
			shelf.items.Add(mountedItem.gameObject);
			component.transform.parent = base.transform;
			component.transform.localPosition = Vector3.zero;
			component.transform.localRotation = Quaternion.identity;
			component.GetComponent<Collider>().enabled = false;
			player.itemOnHand = null;
			QuestManager.S.GarageCleaned(component.gameObject);
			player.ItemOutHand();
			AudioManager.S.PlayRandomPitch(AudioManager.S.shelfPut);
		}
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
