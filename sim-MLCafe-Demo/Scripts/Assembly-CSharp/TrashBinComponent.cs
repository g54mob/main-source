using MLCN_Localization;
using UnityEngine;

public class TrashBinComponent : MonoBehaviour
{
	[SerializeField]
	private Item wasteItem;

	[SerializeField]
	private GameObject trashAmount;

	[SerializeField]
	private float targetHeight;

	private float startHeight;

	[SerializeField]
	private string soundEmptyBin;

	[SerializeField]
	private string soundThrowAwayGeneric;

	[SerializeField]
	private string soundThrowAwayCoffee;

	[Header("Localization")]
	[SerializeField]
	private string localizedKeyItemIsNotEmpty;

	private void Start()
	{
		startHeight = trashAmount.transform.localPosition.y;
		trashAmount.SetActive(value: false);
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (!character.socket.IsHoldingItem())
		{
			return;
		}
		if (character.socket.GetItemComponent().CanBeWaste() && !character.socket.GetItemComponent().IsWaste())
		{
			string localizedMessage = PopupMessageManager.GetHighlightBegin() + character.socket.GetItemComponent().GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizedKeyItemIsNotEmpty, LocalizationDataTable.Tables.UI);
			PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
		}
		else if (character.socket.GetItemComponent().item.id == wasteItem.id || (character.socket.GetItemComponent().CanBeWaste() && character.socket.GetItemComponent().IsWaste()))
		{
			if (FillTrash())
			{
				Object.Destroy(character.socket.GetItemComponent().gameObject);
				character.socket.Clear();
				SoundManager.PlaySoundOnce(soundThrowAwayGeneric);
			}
		}
		else if (character.socket.GetItemComponent().GetComponent<ProductComponent>() != null)
		{
			ProductComponent component = character.socket.GetItemComponent().GetComponent<ProductComponent>();
			if (component.IsHoldingProduct())
			{
				component.GetComponent<CupComponent>().MarkDirty();
				SoundManager.PlaySoundOnce(soundThrowAwayCoffee);
				FillTrash();
			}
		}
		else if (character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>() != null && FillTrash())
		{
			character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>().PlayTrashcanScream();
			Object.Destroy(character.socket.GetItemComponent().gameObject);
			character.socket.Clear();
			SoundManager.PlaySoundOnce(soundThrowAwayGeneric);
		}
	}

	public bool FillTrash()
	{
		bool num = GetComponent<ItemComponent>().Fill();
		if (num)
		{
			trashAmount.SetActive(value: true);
			float y = Mathf.Lerp(startHeight, targetHeight, (float)GetComponent<ItemComponent>().item.amount * 0.1f);
			trashAmount.transform.localPosition = new Vector3(trashAmount.transform.localPosition.x, y, trashAmount.transform.localPosition.z);
		}
		return num;
	}

	public void EmptyTrash()
	{
		GetComponent<ItemComponent>().EmptyItem();
		SoundManager.PlaySoundOnce(soundEmptyBin);
		trashAmount.SetActive(value: false);
	}
}
