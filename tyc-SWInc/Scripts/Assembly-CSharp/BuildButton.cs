using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[NonSerialized]
	private Furniture furn;

	public string Name;

	public string Description;

	public bool IsInRentMode = true;

	public Toggle FavoriteToggle;

	public GUIToolTipper FavoriteTip;

	public Sprite Thumbnail;

	public float Price;

	public Image ButtonImage;

	public Image New;

	public Image SelfImg;

	public RectTransform Self;

	public Button button;

	[NonSerialized]
	public BuildDescriptor Descriptor;

	public int Order;

	public GameObject Counter;

	public Text CounterLabel;

	[NonSerialized]
	private bool _useFav;

	[NonSerialized]
	public AwardTrophy.AwardData Award;

	private bool _disableFavUpdate;

	public bool IsNew
	{
		get
		{
			return New.gameObject.activeSelf;
		}
		set
		{
			New.gameObject.SetActive(value);
		}
	}

	public Furniture Furn
	{
		get
		{
			return furn;
		}
		set
		{
			furn = value;
			if (furn != null && !furn.IsConstructionFurniture())
			{
				FavoriteToggle.gameObject.SetActive(true);
				_useFav = !furn.Type.Equals("Award");
				_disableFavUpdate = true;
				FavoriteToggle.isOn = Options.IsFavFurn(furn);
				_disableFavUpdate = false;
				RefreshInventory(GameSettings.GetInventoryCount(furn.name));
			}
		}
	}

	public void UpdateVisible(Rect r, Vector3[] corners)
	{
		Self.GetWorldCorners(corners);
		Rect other = Rect.MinMaxRect(corners[1].x, corners[3].y, corners[3].x, corners[1].y);
		bool flag = r.Overlaps(other);
		SelfImg.enabled = flag;
		ButtonImage.gameObject.SetActive(flag);
		FavoriteToggle.gameObject.SetActive(flag && _useFav);
		if (flag)
		{
			button.enabled = false;
			button.enabled = true;
		}
	}

	public void OnFavToggled()
	{
		if (!(Furn != null))
		{
			return;
		}
		FavoriteTip.TooltipDescription = (FavoriteToggle.isOn ? "RemoveFavorite" : "AddFavorite");
		FavoriteTip.UpdateTip();
		if (!_disableFavUpdate)
		{
			if (FavoriteToggle.isOn)
			{
				Options.AddFavFurn(Furn);
			}
			else
			{
				Options.RemoveFavFurn(Furn);
			}
			HUD.Instance.RefreshCats();
		}
	}

	public void RefreshInventory(int count)
	{
		if (Award != null)
		{
			Counter.SetActive(true);
			RectTransform component = Counter.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(component.sizeDelta.y * 2f, component.sizeDelta.y);
			CounterLabel.text = "Sell";
		}
		else if (count == 0)
		{
			Counter.SetActive(false);
		}
		else
		{
			Counter.SetActive(true);
			CounterLabel.text = ((count < 100) ? count.ToString() : "99+");
		}
	}

	public void SellInventory(BaseEventData b)
	{
		if (!(furn != null))
		{
			return;
		}
		PointerEventData pointerEventData = b as PointerEventData;
		if (pointerEventData != null && pointerEventData.button == PointerEventData.InputButton.Right)
		{
			if (Award != null)
			{
				GameSettings.Instance.MyCompany.MakeTransaction(AwardTrophy.GetAwardWorth(Award.Tier, Award.Year), Company.TransactionCategory.Construction, true, "Recycle");
				GameSettings.Instance.RemoveAward(Award);
				HUD.Instance.BuildDetailPanel.Disable();
				UISoundFX.PlaySFX("Kaching");
			}
			else
			{
				GameSettings.SellAllInventory(furn.name);
			}
			SelectorController.CanClick = false;
		}
		else
		{
			button.onClick.Invoke();
		}
	}

	public int CompareTo(BuildButton other)
	{
		bool flag = Furn != null && Options.IsFavFurn(Furn);
		bool flag2 = other.Furn != null && Options.IsFavFurn(other.Furn);
		if (flag == flag2)
		{
			return Order.CompareTo(other.Order);
		}
		if (!flag)
		{
			return 1;
		}
		return -1;
	}

	public void SetAttributes(string realName, string name, string desc, Sprite t, float price)
	{
		Name = name;
		Description = desc;
		Thumbnail = t;
		Price = price;
		base.name = "BuildButton" + realName;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Furn != null)
		{
			HUD.Instance.BuildDetailPanel.SetFurniture(Furn, Award);
		}
		else
		{
			HUD.Instance.BuildDetailPanel.SetGeneric(Name, Description, Thumbnail, Price, (IsInRentMode || !GameSettings.Instance.RentMode || GameSettings.Instance.EditMode) ? null : "Landlord");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HUD.Instance.BuildDetailPanel.Disable();
	}
}
