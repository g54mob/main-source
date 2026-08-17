using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
	public GameObject shopContainerPrefab;

	public Transform contentParent;

	public TabGridNavigation navigation;

	public Button btnBack;

	public ShopFooter shopFooter;

	public MyButtonNormal btnBuy;

	public MyButtonNormal btnRefund;

	public TextMeshProUGUI t_buy;

	public TextMeshProUGUI t_refund;

	private ShopContainer _003CcurrentContainer_003Ek__BackingField;

	private List<ShopContainer> shopContainers;

	public static Action<ShopContainer> A_LevelChanged;

	public ShopContainer currentContainer
	{
		get
		{
			return _003CcurrentContainer_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentContainer_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<ShopContainer> b = OnShopSelect;
		Delegate obj = Delegate.Combine(MyButtonShop.A_Select, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonShop.A_Select = (Action<ShopContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ShopContainer> action = default(Action<ShopContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<ShopContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			MyButtonShop.A_Select = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<ShopContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<ShopContainer> b2 = OnShopClicked;
		Delegate obj6 = Delegate.Combine(MyButtonShop.A_Clicked, b2);
		if ((object)obj6 == null)
		{
			MyButtonShop.A_Clicked = (Action<ShopContainer>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ShopContainer> action2 = default(Action<ShopContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyButtonShop.A_Clicked = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<ShopContainer> value = OnShopClicked;
		Delegate obj = Delegate.Remove(MyButtonShop.A_Clicked, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonShop.A_Clicked = (Action<ShopContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ShopContainer> action = default(Action<ShopContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<ShopContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			MyButtonShop.A_Clicked = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<ShopContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<ShopContainer> value2 = OnShopSelect;
		Delegate obj6 = Delegate.Remove(MyButtonShop.A_Select, value2);
		if ((object)obj6 == null)
		{
			MyButtonShop.A_Select = (Action<ShopContainer>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ShopContainer> action2 = default(Action<ShopContainer>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyButtonShop.A_Select = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<ShopContainer>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private unsafe void Start()
	{
		//IL_04b1: Expected I, but got O
		//IL_04e2: Expected O, but got I
		//IL_01d3: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_050a: Expected O, but got I4
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		nint num = (nint)typeof(DataManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppClass<DataManager>)+B8]");
		nint num2 = 0;
		DataManager instance = DataManager.Instance;
		bool flag = (object)DataManager.Instance == null;
		Dictionary<EShopItem, ShopItemData> dictionary = (Dictionary<EShopItem, ShopItemData>)num2;
		if (!flag)
		{
			dictionary = instance._003CshopItems_003Ek__BackingField;
			if (instance._003CshopItems_003Ek__BackingField != null)
			{
				Dictionary<EShopItem, ShopItemData>.ValueCollection values = instance._003CshopItems_003Ek__BackingField.Values;
				List<object> list = Enumerable.ToList((IEnumerable<object>)values);
				bool flag2 = list == null;
				dictionary = (Dictionary<EShopItem, ShopItemData>)(object)values;
				if (!flag2)
				{
					list.Sort();
					List<ShopContainer> list2 = new List<ShopContainer>();
					shopContainers = list2;
					bool flag3 = (object)shopContainerPrefab == null;
					dictionary = (Dictionary<EShopItem, ShopItemData>)(object)shopContainerPrefab;
					if (!flag3)
					{
						List<object> list3 = (List<object>)(object)shopContainers;
						ShopContainer component = shopContainerPrefab.GetComponent<ShopContainer>();
						bool flag4 = shopContainers == null;
						dictionary = (Dictionary<EShopItem, ShopItemData>)(object)shopContainerPrefab;
						if (!flag4)
						{
							int version = list3._version + 1;
							list3._version = version;
							dictionary = (Dictionary<EShopItem, ShopItemData>)(object)list3._items;
							if (list3._items != null)
							{
								int size = list3._size;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (System.Collections.Generic.Dictionary`2<Assets.Scripts._Data.ShopItems.EShopItem, ShopItemData>)+18]");
								if ((nint)size >= (nint)0)
								{
									((List<object>)(object)shopContainers).AddWithResize((object)component);
								}
								else
								{
									int size2 = list3._size + 1;
									list3._size = size2;
								}
								object obj = 0;
								object obj2 = 0;
								List<object>.Enumerator enumerator = default(List<object>.Enumerator);
								ShopItemData shopItemData = default(ShopItemData);
								while (true)
								{
									object obj3 = list._size - 1;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
									{
										List<object> list4 = (List<object>)(object)shopContainers;
										GameObject gameObject = UnityEngine.Object.Instantiate(shopContainerPrefab, contentParent);
										bool flag5 = (object)gameObject == null;
										dictionary = (Dictionary<EShopItem, ShopItemData>)(object)shopContainerPrefab;
										if (flag5)
										{
											break;
										}
										ShopContainer component2 = gameObject.GetComponent<ShopContainer>();
										bool flag6 = shopContainers == null;
										dictionary = (Dictionary<EShopItem, ShopItemData>)(object)gameObject;
										if (flag6)
										{
											break;
										}
										int version2 = list4._version + 1;
										list4._version = version2;
										dictionary = (Dictionary<EShopItem, ShopItemData>)(object)list4._items;
										if (list4._items == null)
										{
											break;
										}
										int size3 = list4._size;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6 (System.Collections.Generic.Dictionary`2<Assets.Scripts._Data.ShopItems.EShopItem, ShopItemData>)+18]");
										if ((nint)size3 >= (nint)0)
										{
											((List<object>)(object)shopContainers).AddWithResize((object)component2);
											obj++;
											obj2 = obj;
										}
										else
										{
											int size4 = list4._size + 1;
											list4._size = size4;
											obj++;
											obj2 = obj;
										}
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
									int num3 = 0;
									while (enumerator.MoveNext())
									{
										if (shopContainers != null)
										{
											ShopContainer shopContainer = shopContainers.get_Item(num3);
											if ((object)shopContainer != null)
											{
												num3++;
												shopContainer.Set(shopItemData);
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									((List<ShopItemData>.Enumerator*)(&enumerator))->Dispose();
									if ((object)navigation == null)
									{
										break;
									}
									navigation.Set(btnBack);
									SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
									if ((object)SaveManager._003CInstance_003Ek__BackingField == null)
									{
										break;
									}
									ProgressionSaveFile progression = saveManager.progression;
									if (saveManager.progression == null)
									{
										break;
									}
									MenuMeta menuMeta = progression.menuMeta;
									if (progression.menuMeta == null)
									{
										break;
									}
									menuMeta.hasVisitedShop = true;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void Buy()
	{
		//IL_017f: Expected O, but got Ref
		//IL_017f: Expected O, but got Ref
		ShopContainer shopContainer = _003CcurrentContainer_003Ek__BackingField;
		AlwaysUi instance2;
		string key;
		if (!shopContainer._003Cdata_003Ek__BackingField.IsMaxLevel())
		{
			if (shopContainer._003Cdata_003Ek__BackingField.CanBuy())
			{
				SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
				if (saveManager.progression.PurchaseShopItem(shopContainer._003Cdata_003Ek__BackingField))
				{
					AudioManager instance = AudioManager.Instance;
					instance.purchaseSfx.Play();
				}
				RefreshPrices();
				Action<ShopContainer> a_LevelChanged = A_LevelChanged;
				if (A_LevelChanged != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v389 @ rax_v25 (System.Action`1<ShopContainer>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			instance2 = AlwaysUi.Instance;
			key = "CANT_AFFORD_SILVER";
		}
		else
		{
			instance2 = AlwaysUi.Instance;
			key = "SHOP_ITEM_MAX_LEVEL";
		}
		string localizedString = LocalizationUtility.GetLocalizedString("PopupText", key);
		Transform transform = btnBuy.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		object obj2 = default(object);
		float desiredScale = default(float);
		instance2.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
	}

	public unsafe void Refund()
	{
		//IL_014d: Expected O, but got Ref
		//IL_014d: Expected O, but got Ref
		ShopContainer shopContainer = _003CcurrentContainer_003Ek__BackingField;
		if (shopContainer._003Cdata_003Ek__BackingField.CanRefund())
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if (saveManager.progression.RefundShopItem(shopContainer._003Cdata_003Ek__BackingField))
			{
				AudioManager instance = AudioManager.Instance;
				instance.purchaseSfx.Play();
			}
			RefreshPrices();
			Action<ShopContainer> a_LevelChanged = A_LevelChanged;
			if (A_LevelChanged != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v346 @ rax_v21 (System.Action`1<ShopContainer>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			AlwaysUi instance2 = AlwaysUi.Instance;
			string localizedString = LocalizationUtility.GetLocalizedString("PopupText", "SHOP_CANT_REFUND");
			Transform transform = btnRefund.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			object obj2 = default(object);
			float desiredScale = default(float);
			instance2.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
		}
	}

	private void RefreshPrices()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720DC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ShopContainer shopContainer = _003CcurrentContainer_003Ek__BackingField;
		bool flag = shopContainer._003Cdata_003Ek__BackingField.IsMaxLevel();
		TextMeshProUGUI textMeshProUGUI = t_buy;
		MyButton myButton;
		bool disabledOverlayButKeepInteractable;
		if (flag)
		{
			t_buy.text = "";
			myButton = btnBuy;
			disabledOverlayButKeepInteractable = true;
		}
		else
		{
			ShopContainer shopContainer2 = _003CcurrentContainer_003Ek__BackingField;
			int price = shopContainer2._003Cdata_003Ek__BackingField.GetPrice();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text = $"<sprite name=silver> {arg}";
			t_buy.text = text;
			myButton = btnBuy;
			int num = price;
			disabledOverlayButKeepInteractable = false;
		}
		myButton.SetDisabledOverlayButKeepInteractable(disabledOverlayButKeepInteractable);
		ShopContainer shopContainer3 = _003CcurrentContainer_003Ek__BackingField;
		if (!shopContainer3._003Cdata_003Ek__BackingField.CanRefund())
		{
			t_refund.text = "";
			btnRefund.SetDisabledOverlayButKeepInteractable(enabled: true);
			return;
		}
		ShopContainer shopContainer4 = _003CcurrentContainer_003Ek__BackingField;
		int refundPrice = shopContainer4._003Cdata_003Ek__BackingField.GetRefundPrice();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		string text2 = $"<sprite name=silver> {arg2}";
		t_refund.text = text2;
		btnRefund.SetDisabledOverlayButKeepInteractable(enabled: false);
	}

	private void OnShopClicked(ShopContainer shopContainerClicked)
	{
		if (!(shopContainerClicked != null) || !(shopContainerClicked._003Cdata_003Ek__BackingField != null) || !MyAchievements.IsUnlocked(shopContainerClicked._003Cdata_003Ek__BackingField, out var _))
		{
			return;
		}
		MyButton btn;
		if (shopContainerClicked._003Cdata_003Ek__BackingField.IsMaxLevel())
		{
			if (!shopContainerClicked._003Cdata_003Ek__BackingField.CanRefund())
			{
				return;
			}
			btn = btnRefund;
		}
		else
		{
			btn = btnBuy;
		}
		ButtonManager.ForceHoverButton(btn);
	}

	public void OnShopSelect(ShopContainer shopContainerClicked)
	{
		shopFooter.Set(shopContainerClicked);
		_003CcurrentContainer_003Ek__BackingField = shopContainerClicked;
		RefreshPrices();
		GameObject gameObject = btnRefund.gameObject;
		ShopItemData shopItemData = shopContainerClicked._003Cdata_003Ek__BackingField;
		gameObject.SetActive(shopItemData.canRefund);
	}
}
