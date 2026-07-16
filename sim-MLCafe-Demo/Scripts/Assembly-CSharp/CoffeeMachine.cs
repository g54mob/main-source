using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : WorkstationCore
{
	[SerializeField]
	private Item garbageItem;

	[SerializeField]
	private SkinnedMeshRenderer coffeefilterRenderer;

	[SerializeField]
	private SkinnedMeshRenderer groundedcoffeeRenderer;

	[SerializeField]
	private Transform kettleFillPoint;

	[SerializeField]
	private ItemSocket cupSocket;

	private CupComponent activeCup;

	private AnomalyTag activeFlavourMix;

	private bool coffeeWaste;

	public override void OnInit()
	{
	}

	public override void OnPlayerInteraction(CharacterControllerComponent character)
	{
		if (!character.socket.IsHoldingItem())
		{
			if (cupSocket.IsHoldingItem())
			{
				character.socket.PushItem(cupSocket.GetItemComponent());
				GetWorkstationComponent("Cup").UnmarkReady();
			}
			else if (coffeeWaste)
			{
				PushCoffeeWaste(character.socket);
			}
		}
		else
		{
			ItemComponent itemComponent = character.socket.GetItemComponent();
			if (!(itemComponent == null))
			{
				CheckComponent(itemComponent);
			}
		}
	}

	private void CheckComponent(ItemComponent itemComponent)
	{
		bool flag = false;
		bool flag2 = false;
		WorkstationComponent[] array = workstationComponents;
		foreach (WorkstationComponent workstationComponent in array)
		{
			if (workstationComponent.IsRequiredItem(itemComponent))
			{
				flag = true;
				if (workstationComponent.DependenciesReady(workstationComponents))
				{
					flag2 = true;
					workstationComponent.OnProcessItemComponent.Invoke(itemComponent, workstationComponent.GetTag());
					workstationComponent.MarkReady();
				}
			}
		}
		if (flag)
		{
		}
	}

	private void PushCoffeeWaste(ItemSocket socket)
	{
		ItemComponent component = Object.Instantiate(InventorySystem.GetItemLibrary().itemInfos[garbageItem.id].prefab, socket.transform).GetComponent<ItemComponent>();
		socket.PushItem(component);
		activeFlavourMix = null;
		coffeefilterRenderer.gameObject.SetActive(value: false);
		groundedcoffeeRenderer.gameObject.SetActive(value: false);
		groundedcoffeeRenderer.SetBlendShapeWeight(0, 0f);
	}

	public void OnPushFilter(ItemComponent itemComponent)
	{
		coffeefilterRenderer.gameObject.SetActive(value: true);
		coffeefilterRenderer.SetBlendShapeWeight(0, 100f);
	}

	public void OnPushGroundedCoffee(ItemComponent itemComponent)
	{
		activeFlavourMix = itemComponent.item.tag;
		itemComponent.Consume();
		groundedcoffeeRenderer.gameObject.SetActive(value: true);
		groundedcoffeeRenderer.SetBlendShapeWeight(0, 100f);
	}

	public void OnPushCup(ItemComponent itemComponent)
	{
		activeCup = itemComponent.GetComponent<CupComponent>();
		cupSocket.PushItem(itemComponent);
	}

	public void OnFillCup(ItemComponent itemComponent)
	{
		activeCup.GetComponent<ItemComponent>().RefillItem();
		activeFlavourMix.anomalyFlags += itemComponent.item.tag.anomalyFlags;
		activeCup.GetComponent<ProductComponent>().ApplyProduct(ProductInfo.ProductType.Drink, GetIngredients(), activeCup.cupSize, activeFlavourMix);
		itemComponent.GetComponent<KettleComponent>().PlayFillAnimation(kettleFillPoint);
		Material material = coffeefilterRenderer.material;
		Color color = material.GetColor("_Gradient_Bottom");
		Color black = Color.black;
		TweenerManager.TweenMaterialColor("FilterToWaste", material, "_Gradient_Bottom", color, black, 1f, TweenerManager.GetDefaultEaseCurve(), null);
	}

	public Item[] GetIngredients()
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < workstationComponents.Length; i++)
		{
			if (workstationComponents[i].useItemId && !workstationComponents[i].useItemType && InventorySystem.GetItemLibrary().itemInfos[workstationComponents[i].GetRequiredItem().id].itemType == ItemInfo.ItemType.Ingredient)
			{
				list.Add(workstationComponents[i].GetRequiredItem());
			}
		}
		return list.ToArray();
	}
}
