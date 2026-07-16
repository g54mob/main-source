using System.Collections.Generic;
using System.Linq;
using MLCN_Localization;
using UnityEngine;

public class CoffeeMixer : MonoBehaviour
{
	[SerializeField]
	private CoffeeMixerComponent[] components;

	[SerializeField]
	private ItemSocket cupSocket;

	[SerializeField]
	private bool usingCupFill = true;

	[SerializeField]
	private bool usingKettleFill;

	[SerializeField]
	private Item[] validCups;

	[SerializeField]
	private Item garbageItem;

	[SerializeField]
	private Transform kettleFillPoint;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyCupFull;

	[SerializeField]
	private string localizationKeyCupDirty;

	[SerializeField]
	private string localizationKeyInvalidMissingItem;

	[SerializeField]
	private string localizationKeyInvalidMissingCup;

	[SerializeField]
	private string localizationKeyKettleMustBeEmpty;

	[SerializeField]
	private string localizationKeyInvalidMissingKettle;

	[SerializeField]
	private string localizationKeyitemNotEnough;

	private bool coffeeFinished;

	private AnomalyTag additionalTags = new AnomalyTag();

	private void Start()
	{
		SaveableInstance[] componentsInChildren = base.transform.GetComponentsInChildren<SaveableInstance>();
		foreach (SaveableInstance saveableInstance in componentsInChildren)
		{
			if (saveableInstance.gameObject == base.gameObject || saveableInstance.GetComponent<ItemSocket>() != null)
			{
				continue;
			}
			ItemComponent item = saveableInstance.GetComponent<ItemComponent>();
			for (int j = 0; j < components.Length; j++)
			{
				if (validCups.Any((Item x) => x.id == item.item.id))
				{
					cupSocket.SetItemToSocket(item);
				}
				else if (components[j].requiredItem.id == item.item.id)
				{
					if (components[j].socket.useExistingObject)
					{
						components[j].socket.FillSkinnedItem(item);
					}
					else
					{
						components[j].socket.PushSkinnedItem(item, item.GetComponentInChildren<SkinnedMeshRenderer>());
					}
					components[j].ready = true;
					additionalTags.anomalyFlags += item.item.tag.anomalyFlags;
				}
			}
		}
	}

	public bool NeedsItem(Item item)
	{
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].isDependingOnInteractionItem)
			{
				if (GlobalReferences.GetCharacterController().socket.GetItemComponent().item.id == components[i].interactionItem.id)
				{
					return true;
				}
			}
			else if (GlobalReferences.GetCharacterController().socket.GetItemComponent().item.id == components[i].requiredItem.id)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsFinished()
	{
		return coffeeFinished;
	}

	public bool IsReady()
	{
		if (!components.Any((CoffeeMixerComponent x) => !x.ready))
		{
			return !coffeeFinished;
		}
		return false;
	}

	public Item[] GetIngredients()
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < components.Length; i++)
		{
			if (InventorySystem.GetItemLibrary().itemInfos[components[i].requiredItem.id].itemType == ItemInfo.ItemType.Ingredient)
			{
				list.Add(components[i].requiredItem);
			}
		}
		return list.ToArray();
	}

	public void OnPlayerInteraction(CharacterControllerComponent character)
	{
		CheckComponents(character.socket);
	}

	private void CheckComponents(ItemSocket socket)
	{
		if (coffeeFinished)
		{
			if (!cupSocket.IsHoldingItem() && !socket.IsHoldingItem())
			{
				ItemComponent component = Object.Instantiate(InventorySystem.GetItemLibrary().itemInfos[garbageItem.id].prefab, socket.transform).GetComponent<ItemComponent>();
				socket.PushItem(component);
				coffeeFinished = false;
				ClearMixer();
			}
			else if (!socket.IsHoldingItem())
			{
				cupSocket.GetItemComponent().ActivateCollision();
				cupSocket.SwapItems(socket);
			}
			return;
		}
		if (socket.IsHoldingItem())
		{
			if (socket.GetItemComponent().item.id == cupSocket.onlyItem.id && (socket.GetItemComponent().item.amount > 0 || socket.GetItemComponent().GetComponent<ProductComponent>().GetProduct()
				.isFilled))
			{
				return;
			}
			if (!cupSocket.IsHoldingItem() && socket.GetItemComponent().GetInfo().itemType == ItemInfo.ItemType.Dish)
			{
				for (int i = 0; i < validCups.Length; i++)
				{
					if (socket.GetItemComponent().item.id != validCups[i].id)
					{
						continue;
					}
					if (usingCupFill)
					{
						if (socket.GetItemComponent().GetComponent<ProductComponent>() != null && socket.GetItemComponent().GetComponent<ProductComponent>().GetProduct() != null && socket.GetItemComponent().GetComponent<ProductComponent>().GetProduct()
							.isFilled)
						{
							PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyCupFull, Color.white, 0.7f);
						}
						else if (socket.GetItemComponent().GetComponent<CupComponent>().IsUseable())
						{
							cupSocket.PushItem(socket.GetItemComponent());
							MarkTutorialCheckListOption("CoffeeMixer_Cup");
						}
						else
						{
							PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyCupDirty, Color.red, 0.7f);
						}
					}
					else if (usingKettleFill)
					{
						if (socket.GetItemComponent().item.amount == 0)
						{
							cupSocket.PushItem(socket.GetItemComponent());
							break;
						}
						string localizedMessage = PopupMessageManager.GetHighlightBegin() + InventorySystem.GetItemLibrary().itemInfos[validCups[0].id].GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizationKeyKettleMustBeEmpty, LocalizationDataTable.Tables.UI);
						PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
					}
					break;
				}
				return;
			}
		}
		else
		{
			if (!cupSocket.IsHoldingItem())
			{
				PopMissingCupMessage();
			}
			if (components.Any((CoffeeMixerComponent x) => !x.ready && !x.isDependingOnCup))
			{
				CoffeeMixerComponent coffeeMixerComponent = components.First((CoffeeMixerComponent x) => !x.ready && !x.isDependingOnCup);
				if (coffeeMixerComponent != null)
				{
					PopMissingDepencyMessage(coffeeMixerComponent);
				}
			}
		}
		for (int num = 0; num < components.Length; num++)
		{
			if (components[num].ready || !CheckRequiredItem(socket, num))
			{
				continue;
			}
			if (components[num].isDependingOnCup && !cupSocket.IsHoldingItem())
			{
				PopMissingCupMessage();
				continue;
			}
			if (CheckInteractionDepency(num))
			{
				if (!AllDepenciesReady(components[num].isDependingOnOtherReady, num, components[num].dependencyComponentIndex))
				{
					PopMissingDepencyMessage(num);
					return;
				}
				if (socket.GetItemComponent().useLimitedAmount)
				{
					if (socket.GetItemComponent().IsEmpty())
					{
						PopItemEmpty(socket.GetItemComponent());
						return;
					}
					if (usingKettleFill && socket.GetItemComponent().item.amount < 2)
					{
						PopItemNotEnough(socket.GetItemComponent());
						return;
					}
					if (usingCupFill)
					{
						socket.GetItemComponent().Consume();
					}
					if (usingKettleFill)
					{
						socket.GetItemComponent().Consume(2);
					}
				}
				if (CheckLockState(num))
				{
					components[num].ready = true;
					components[num].OnReady.Invoke();
					additionalTags.anomalyFlags += socket.GetItemComponent().item.tag.anomalyFlags;
					break;
				}
			}
			else if (!AllDepenciesReady(components[num].isDependingOnOtherReady, num, components[num].dependencyComponentIndex))
			{
				PopMissingDepencyMessage(num);
			}
			else if (CheckLockState(num))
			{
				if (!socket.GetItemComponent().useLimitedAmount)
				{
					socket.GetItemComponent().DeactivateCollision();
				}
				additionalTags.anomalyFlags += socket.GetItemComponent().item.tag.anomalyFlags;
				if (components[num].socket.useExistingObject)
				{
					components[num].socket.FillSkinnedItem(socket.GetItemComponent());
				}
				else
				{
					components[num].socket.PushSkinnedItem(socket.GetItemComponent(), socket.GetItemComponent().GetComponentInChildren<SkinnedMeshRenderer>());
				}
				components[num].ready = true;
				components[num].OnReady.Invoke();
				break;
			}
			return;
		}
		bool num2 = !components.Any((CoffeeMixerComponent x) => !x.ready);
		bool flag = cupSocket.IsHoldingItem();
		if (!(num2 && flag))
		{
			return;
		}
		ItemComponent itemComponent = cupSocket.GetItemComponent();
		if (socket.GetItemComponent().GetComponent<KettleComponent>() != null)
		{
			socket.GetItemComponent().GetComponent<KettleComponent>().PlayFillAnimation(kettleFillPoint);
			CoffeeMixerComponent coffeeMixerComponent2 = components.FirstOrDefault((CoffeeMixerComponent x) => x.requiredItem.id == 7);
			if (coffeeMixerComponent2 != null)
			{
				Material material = coffeeMixerComponent2.socket.GetItemComponent().GetComponentInChildren<SkinnedMeshRenderer>().material;
				Color color = material.GetColor("_Gradient_Bottom");
				Color wasteColor = coffeeMixerComponent2.socket.GetItemComponent().GetWasteColor();
				TweenerManager.TweenMaterialColor("FilterToWaste", material, "_Gradient_Bottom", color, wasteColor, 1f, TweenerManager.GetDefaultEaseCurve(), null);
			}
		}
		if (usingCupFill)
		{
			itemComponent.productComponent.ApplyProduct(ProductInfo.ProductType.Drink, GetIngredients(), itemComponent.GetComponent<CupComponent>().cupSize, additionalTags);
		}
		if (usingKettleFill)
		{
			itemComponent.RefillItem();
			itemComponent.productComponent.ApplyProduct(ProductInfo.ProductType.Drink, GetIngredients(), Product.ProductSize.Monstrous, additionalTags);
		}
		coffeeFinished = true;
		if (TutorialManager.IsRunning() && TutorialManager.GetCurrentState() <= TutorialManager.TutorialState.MakeCoffee)
		{
			EntitySmoghComponent entitySmoghComponent = Object.FindFirstObjectByType<EntitySmoghComponent>();
			if (!(entitySmoghComponent == null))
			{
				entitySmoghComponent.PlayReactionMadeCoffee(additionalTags.anomalyFlags);
			}
		}
	}

	private bool CheckRequiredItem(ItemSocket characterSocket, int currentIndex)
	{
		if (components[currentIndex].isDependingOnInteractionItem)
		{
			if (characterSocket.IsHoldingItem())
			{
				return characterSocket.GetItemComponent().item.id == components[currentIndex].interactionItem.id;
			}
			return false;
		}
		if (characterSocket.IsHoldingItem())
		{
			return characterSocket.GetItemComponent().item.id == components[currentIndex].requiredItem.id;
		}
		return false;
	}

	private bool CheckComponentIndexDepencies(bool check, ItemSocket characterSocket, int currentIndex)
	{
		if (!check)
		{
			return true;
		}
		return false;
	}

	private bool AllDepenciesReady(bool check, int currentIndex, int[] depencies)
	{
		if (!check || depencies.Length == 0)
		{
			return true;
		}
		for (int i = 0; i < components[currentIndex].dependencyComponentIndex.Length; i++)
		{
			if (!components[components[currentIndex].dependencyComponentIndex[i]].ready)
			{
				return false;
			}
		}
		return true;
	}

	private bool CheckInteractionDepency(int currentIndex)
	{
		if (components[currentIndex].isDependingOnInteractionItem)
		{
			return true;
		}
		return false;
	}

	private bool CheckLockState(int currentIndex)
	{
		if (!components[currentIndex].canLock || components[currentIndex].lockState)
		{
			return !components[currentIndex].canLock;
		}
		return true;
	}

	private void PopMissingDepencyMessage(int currentIndex)
	{
		int num = -1;
		for (int i = 0; i < components[currentIndex].dependencyComponentIndex.Length; i++)
		{
			if (!components[components[currentIndex].dependencyComponentIndex[i]].ready)
			{
				num = components[currentIndex].dependencyComponentIndex[i];
				break;
			}
		}
		if (num != -1)
		{
			string localizedName = InventorySystem.GetItemLibrary().itemInfos[components[num].requiredItem.id].GetLocalizedName();
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidMissingItem, 1.5f, localizedName);
		}
	}

	private void PopMissingDepencyMessage(CoffeeMixerComponent component)
	{
		string localizedName = InventorySystem.GetItemLibrary().itemInfos[component.requiredItem.id].GetLocalizedName();
		PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidMissingItem, 1.5f, localizedName);
	}

	private void PopMissingCupMessage()
	{
		if (usingCupFill)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidMissingCup);
		}
		if (usingKettleFill)
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidMissingKettle);
		}
	}

	private void PopItemEmpty(ItemComponent itemComponent)
	{
		string localizedMessage = PopupMessageManager.GetHighlightBegin() + itemComponent.GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(itemComponent.localizationItemIsEmpty, LocalizationDataTable.Tables.UI);
		PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
	}

	private void PopItemNotEnough(ItemComponent itemComponent)
	{
		string localizedMessage = PopupMessageManager.GetHighlightBegin() + itemComponent.GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizationKeyitemNotEnough, LocalizationDataTable.Tables.UI);
		PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
	}

	private void ClearMixer()
	{
		additionalTags = new AnomalyTag();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].socket == cupSocket)
			{
				continue;
			}
			if (components[i].socket != null)
			{
				if (components[i].socket.useExistingObject)
				{
					components[i].socket.UnfillSkinnedItem();
				}
				else
				{
					components[i].socket.GetItemComponent().DestoryItem();
					components[i].socket.Clear();
				}
			}
			components[i].ready = false;
		}
	}

	public void MarkTutorialCheckListOption(string checkListKey)
	{
		TutorialManager.TryCheckSectionChecklistOption(checkListKey, TutorialManager.TutorialState.MakeCoffee);
	}
}
