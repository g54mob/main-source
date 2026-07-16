using System.Linq;
using MLCN_Localization;
using UnityEngine;

public class JunkDepotComponent : MonoBehaviour
{
	[SerializeField]
	private string localizedKeyCantThrowAwayThisItem = "";

	[SerializeField]
	private string localizedKeyCantThrowAwayMultipleItems = "";

	[SerializeField]
	private Item[] itemExceptions;

	[SerializeField]
	private Item itemGarbageCan;

	[SerializeField]
	private string soundThrowAway;

	[SerializeField]
	private string soundThrowAwayValuable;

	private ShopMenu shopMenu;

	private bool IsItemException(Item item)
	{
		return itemExceptions.Any((Item x) => x.id == item.id);
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (!character.socket.IsHoldingItem())
		{
			return;
		}
		if (character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>() != null)
		{
			character.socket.GetItemComponent().GetComponent<EntitySmoghComponent>().PlayTrashcanScream();
			Object.Destroy(character.socket.GetItemComponent().gameObject);
			character.socket.Clear();
			SoundManager.PlaySoundOnce(soundThrowAwayValuable);
			return;
		}
		if (character.socket.GetItemComponent().item.id == itemGarbageCan.id)
		{
			character.socket.GetItemComponent().GetComponent<TrashBinComponent>().EmptyTrash();
			return;
		}
		if (character.socket.GetItemComponent().GetComponentsInChildren<ItemComponent>().Length > 1)
		{
			string localizedMessage = PopupMessageManager.GetHighlightBegin() + character.socket.GetItemComponent().GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizedKeyCantThrowAwayMultipleItems, LocalizationDataTable.Tables.UI);
			PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
			return;
		}
		if (IsItemException(character.socket.GetItemComponent().item))
		{
			string localizedMessage2 = PopupMessageManager.GetHighlightBegin() + character.socket.GetItemComponent().GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizedKeyCantThrowAwayThisItem, LocalizationDataTable.Tables.UI);
			PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage2);
			return;
		}
		if (shopMenu == null)
		{
			shopMenu = Object.FindFirstObjectByType<ShopMenu>();
		}
		if (!(shopMenu == null))
		{
			ShopOption shopOption = shopMenu.GetShopOptions().shopOptions.Find((ShopOption x) => x.itemId == character.socket.GetItemComponent().item.id);
			if (shopOption == null)
			{
				ThrowAway(character);
				SoundManager.PlaySoundOnce(soundThrowAway);
				return;
			}
			if (shopOption.notForBuy)
			{
				ThrowAway(character);
				SoundManager.PlaySoundOnce(soundThrowAway);
				return;
			}
			int num = shopOption.buyPrice / 5;
			WalletSystem.GetPlayerWallet().AddAmount(num);
			CafeShopManager.AddDeposits(num);
			SoundManager.PlaySoundOnce(soundThrowAwayValuable);
			ThrowAway(character);
		}
	}

	private void ThrowAway(CharacterControllerComponent character)
	{
		SaveableInstance component = character.socket.GetItemComponent().GetComponent<SaveableInstance>();
		if (component != null)
		{
			CafeDataLoader.UnregisterSaveableInstance(component);
			if (component != null)
			{
				Object.Destroy(component);
			}
		}
		Object.Destroy(character.socket.GetItemComponent().gameObject);
		character.socket.Clear();
	}
}
