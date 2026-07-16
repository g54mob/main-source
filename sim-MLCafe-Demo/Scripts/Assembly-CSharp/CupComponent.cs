using UnityEngine;

public class CupComponent : MonoBehaviour
{
	public Product.ProductSize cupSize;

	[SerializeField]
	private Dirt dirt;

	[SerializeField]
	private bool isDirty;

	private ProductComponent productComponent;

	private void Start()
	{
		Init();
	}

	public void Init()
	{
		productComponent = GetComponent<ProductComponent>();
		if (isDirty)
		{
			MarkDirty();
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (character.socket.IsHoldingItem() && (bool)character.socket.GetItemComponent().GetComponent<KettleComponent>() && (bool)character.socket.GetItemComponent().GetComponent<ProductComponent>())
		{
			if (isDirty)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_cup_dirty");
				return;
			}
			if (character.socket.GetItemComponent().IsEmpty())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(character.socket.GetItemComponent().localizationItemIsEmpty);
				return;
			}
			if (GetComponent<ItemComponent>().item.amount > 0 || productComponent.IsHoldingProduct())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(GetComponent<ItemComponent>().localizationItemIsAlreadyFull);
				return;
			}
			Product product = character.socket.GetItemComponent().GetComponent<ProductComponent>().GetProduct();
			productComponent.TransferProduct(product, cupSize);
			character.socket.GetItemComponent().Consume();
			if (character.socket.GetItemComponent().item.amount == 0)
			{
				character.socket.GetItemComponent().GetComponent<ProductComponent>().ClearProduct();
			}
		}
		else
		{
			GetComponent<ItemComponent>().OnInteraction(character);
		}
	}

	public bool IsUseable()
	{
		return !isDirty;
	}

	public bool IsDirty()
	{
		return isDirty;
	}

	public void MarkDirty()
	{
		isDirty = true;
		productComponent.ClearProduct();
		if (dirt == null)
		{
			dirt = new Dirt();
			dirt.dirtType = Dirt.DirtType.Dish;
		}
		CustomerManager.AddDirtStat(dirt);
	}

	public void UnmarkDirty()
	{
		isDirty = false;
		CustomerManager.RemoveDirtStat(dirt);
	}

	public void BreakCup()
	{
		CustomerManager.AddDirtStat(new Dirt(Dirt.DirtType.BrokenObject));
	}
}
