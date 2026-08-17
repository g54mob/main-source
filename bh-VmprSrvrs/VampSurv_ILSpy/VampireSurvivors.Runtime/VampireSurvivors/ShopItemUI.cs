using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class ShopItemUI : SelectableUI
{
	private Image _Icon;

	private Localize _Name;

	private Localize _Description;

	private TextMeshProUGUI _Price;

	private Image _Fader;

	private UISpriteAnimation _SheenAnimation;

	private Image _LockIcon;

	private Image[] _OnlineSuggestionsIcons;

	private WeaponData _weaponData;

	private WeaponType _weaponType;

	private ItemData _itemData;

	private ItemType _itemType;

	private GameWindowedUIPage _page;

	private PlayerOptions _playerOptions;

	private float _price;

	private bool _isSoldOut;

	private int _quantity;

	private int _index;

	private bool _003CIsCustomActionItem_003Ek__BackingField;

	private Action m_OnPurchased;

	public WeaponType WeaponType => _weaponType;

	public ItemType ItemType => _itemType;

	public bool IsSoldOut => _isSoldOut;

	public bool IsCustomActionItem
	{
		get
		{
			return _003CIsCustomActionItem_003Ek__BackingField;
		}
		private set
		{
			_003CIsCustomActionItem_003Ek__BackingField = value;
		}
	}

	public event Action OnPurchased
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 296;
			Delegate obj2 = this.m_OnPurchased;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 296;
			Delegate obj2 = this.m_OnPurchased;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public bool CanBuy()
	{
		//IL_0081: Expected I4, but got O
		//IL_005d: Invalid comparison between O and F4
		if (_isSoldOut)
		{
			return false;
		}
		if ((object)_page != null)
		{
			float currency = _page.GetCurrency();
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_price);
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void InvokeCustomPurchaseAction()
	{
		Action onPurchased = this.m_OnPurchased;
		if (this.m_OnPurchased != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Buy()
	{
		//IL_001e: Invalid comparison between O and F4
		//IL_01ff: Expected I, but got O
		//IL_020d: Expected I, but got O
		//IL_021d: Expected O, but got I
		//IL_0259: Expected O, but got I
		//IL_03de: Expected O, but got I4
		//IL_03f8: Expected O, but got I4
		if (_isSoldOut)
		{
			return;
		}
		float currency = _page.GetCurrency();
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)_price))
		{
			return;
		}
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
			VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
			bool flag = (object)interactingPlayer == null;
			bool flag2 = (object)characterController == null;
			object obj2 = flag2 & flag;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			bool flag5;
			if (obj3 == null)
			{
				if ((object)interactingPlayer != null)
				{
					if ((object)characterController != null)
					{
						object obj4 = (object)characterController - (object)interactingPlayer;
						bool flag4 = obj4 == null;
						flag5 = !flag4;
					}
					else
					{
						bool flag6 = ((UnityEngine.Object)interactingPlayer).m_CachedPtr == (IntPtr)0;
						flag5 = !flag6;
					}
				}
				else
				{
					bool flag7 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
					flag5 = !flag7;
				}
			}
			else
			{
				flag5 = false;
			}
			if (flag5)
			{
				PlayerInfo myPlayerInfo2 = OnlineStageManager._instance.GetMyPlayerInfo();
				myPlayerInfo2._suggestedLevelUp = _index;
				myPlayerInfo2.OnLevelUpSuggested(0, _index);
				return;
			}
		}
		GameWindowedUIPage page = _page;
		if ((object)_page != null)
		{
			nint num = (nint)page;
			nint num2 = (nint)typeof(MerchantUIPage);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rdx_v17 (Il2CppClass<VampireSurvivors.UI.MerchantUIPage>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r8_v8 (Il2CppClass<VampireSurvivors.UI.GameWindowedUIPage>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rdx_v17 (Il2CppClass<VampireSurvivors.UI.MerchantUIPage>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r8_v8 (Il2CppClass<VampireSurvivors.UI.GameWindowedUIPage>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v27+FFFFFFF8+v511 @ rax_v26*8]");
				if (0 == (nint)typeof(MerchantUIPage))
				{
					GetComponent<Selectable>()?.Select();
					_page.SetSelected(this);
					_page.OnUserConfirmInput();
					goto IL_0345;
				}
			}
		}
		if (_itemType == ItemType.VOID)
		{
			_page.Purchase(_weaponType, _weaponData, _price, null);
			SoldOut();
		}
		else
		{
			RectTransform component = GetComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA00F0");
		}
		goto IL_0345;
		IL_0345:
		SetLockState();
		_SheenAnimation.Play();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
	}

	public void SetWeaponData(WeaponData d, WeaponType t, GameWindowedUIPage page, PlayerOptions po, float price, int index, int quantity = 1, float priceMarkupMultiplier = 1f, bool useWeaponDataPrice = false)
	{
		//IL_01c6: Expected I, but got O
		//IL_022e: Expected O, but got I4
		nint num = (nint)typeof(AdventureManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v4 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager>)+E4]");
		IntPtr intPtr;
		if ((nint)0 != 0 && (object)d._003Cprice_003Ek__BackingField != null)
		{
			if ((object)d._003Cprice_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			IntPtr intPtr2 = default(IntPtr);
			intPtr = intPtr2;
		}
		else
		{
			IntPtr intPtr3 = default(IntPtr);
			intPtr = intPtr3;
		}
		object obj = default(object);
		float num2 = (float)(nint)intPtr * (float)obj;
		int index2 = default(int);
		_index = index2;
		_price = num2;
		_weaponData = d;
		_weaponType = t;
		_page = page;
		int quantity2 = default(int);
		_quantity = quantity2;
		_playerOptions = (PlayerOptions)useWeaponDataPrice;
		Sprite sprite = SpriteManager.GetSprite(d._003CframeName_003Ek__BackingField, d._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = d.GetPrefix(t);
		string term = prefix + "name";
		_Name.Term = term;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix2 = d.GetPrefix(t);
		string term2 = prefix2 + "description";
		_Description.Term = term2;
		float currency = _page.GetCurrency();
		if (_price > num2)
		{
			Button component = GetComponent<Button>();
			component.m_OnClick.RemoveAllListeners();
		}
		SetPrice(_price);
		SetIconSize();
		SetLockState();
		HookOnlineCallback();
	}

	private void SetLockState()
	{
		bool flag = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		bool flag2 = false;
		if (!flag)
		{
			bool flag3 = _weaponType == WeaponType.VOID;
			flag2 = false;
			if (!flag3)
			{
				PlayerOptionsData config = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				bool flag4 = obj != null;
				flag2 = false;
				if (!flag4)
				{
					flag2 = true;
				}
			}
		}
		_LockIcon.enabled = flag2;
	}

	public void SetItemData(ItemData d, ItemType t, GameWindowedUIPage page, float price, int index, int quantity = 1, float priceMarkupMultiplier = 1f)
	{
		object obj = default(object);
		object obj2 = default(object);
		float num = (float)obj * (float)obj2;
		int index2 = default(int);
		_index = index2;
		_itemData = d;
		_price = num;
		_itemType = t;
		_page = page;
		int quantity2 = default(int);
		_quantity = quantity2;
		Sprite sprite = SpriteManager.GetSprite(d._003CframeName_003Ek__BackingField, d._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		TextMeshProUGUI component = _Name.GetComponent<TextMeshProUGUI>();
		string localizedName = d.GetLocalizedName(t);
		component.text = localizedName;
		TextMeshProUGUI component2 = _Name.GetComponent<TextMeshProUGUI>();
		string text = component2.text;
		if (text == null || text._stringLength <= 0)
		{
			TextMeshProUGUI component3 = _Name.GetComponent<TextMeshProUGUI>();
			component3.text = d._003Cname_003Ek__BackingField;
		}
		TextMeshProUGUI component4 = _Description.GetComponent<TextMeshProUGUI>();
		string localizedDescription = d.GetLocalizedDescription(t);
		component4.text = localizedDescription;
		TextMeshProUGUI component5 = _Description.GetComponent<TextMeshProUGUI>();
		string text2 = component5.text;
		if (text2 == null || text2._stringLength <= 0)
		{
			TextMeshProUGUI component6 = _Description.GetComponent<TextMeshProUGUI>();
			component6.text = d._003Cdescription_003Ek__BackingField;
		}
		float currency = _page.GetCurrency();
		if (_price > num)
		{
			Button component7 = GetComponent<Button>();
			component7.m_OnClick.RemoveAllListeners();
		}
		SetPrice(_price);
		SetIconSize();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 501 Invalid \"Jump target not found in method: 0x187360A30\"");
		throw new NullReferenceException();
	}

	private unsafe void HookOnlineCallback()
	{
		//IL_005a: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0160: Expected I, but got O
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0375: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_019d: Expected I, but got O
		//IL_01d4: Expected O, but got I
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected I, but got Unknown
		//IL_03cb: Expected I, but got O
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj12;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				num = unchecked((nint)null);
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_012d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v10+v437 @ rax_v48*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r10_v6+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_012d;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v10+8+v493 @ rcx_v39*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					goto IL_03a0;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_012d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_03a0;
			IL_03a0:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v498 @ rdx_v13] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v23+10]");
			bool flag3 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (flag3)
			{
				continue;
			}
			Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> b = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACB30");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v23+30]");
			Delegate obj15 = Delegate.Combine((Delegate)0, b);
			if ((object)obj15 == null)
			{
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj16 == null)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj17 == null)
				{
					throw new InvalidCastException();
				}
			}
			num = (nint)(obj14 + 48);
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
		}
		throw new NullReferenceException();
	}

	private void OnBuySuggestedCallback(int newSuggestion, int seatNumber, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_002f: Expected O, but got I4
		Image[] onlineSuggestionsIcons = _OnlineSuggestionsIcons;
		GameObject gameObject = onlineSuggestionsIcons[seatNumber].gameObject;
		object obj = _index - newSuggestion;
		bool active = obj == null;
		gameObject.SetActive(active);
		Image[] onlineSuggestionsIcons2 = _OnlineSuggestionsIcons;
		CharacterData currentSkinData = character._currentSkinData;
		Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
		onlineSuggestionsIcons2[seatNumber].sprite = sprite;
	}

	public void SetCustomAction(CustomActionInventoryItem inventoryItem, GameWindowedUIPage page, float priceMarkupMultiplier = 1f)
	{
		//IL_00b1: Invalid comparison between F4 and I4
		_page = page;
		float price = (float)inventoryItem.Price * priceMarkupMultiplier;
		_price = price;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
		_Icon.sprite = (Sprite)(object)inventoryItem.CustomAction;
		TextMeshProUGUI component = _Name.GetComponent<TextMeshProUGUI>();
		component.text = inventoryItem.LocalizedName;
		TextMeshProUGUI component2 = _Description.GetComponent<TextMeshProUGUI>();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
		component2.text = inventoryItem.LocalizedName;
		_003CIsCustomActionItem_003Ek__BackingField = true;
		float currency = _page.GetCurrency();
		if (_price > (float)inventoryItem.Price)
		{
			Button component3 = GetComponent<Button>();
			component3.m_OnClick.RemoveAllListeners();
		}
		SetPrice(_price);
		Image icon = _Icon;
		Sprite sprite = icon.m_Sprite;
		if ((object)icon.m_Sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			SetIconSize();
		}
		this.m_OnPurchased = inventoryItem.CustomAction;
	}

	private void SetIconSize()
	{
		//IL_0219->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_026d->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0102->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_012c->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0156->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0192->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_02d2->IL01b9: Incompatible stack heights: 3 vs 0
		//IL_031f->IL01b9: Incompatible stack heights: 4 vs 0
		if ((object)_Icon != null)
		{
			RectTransform rectTransform = _Icon.rectTransform;
			Image icon = _Icon;
			if ((object)_Icon != null)
			{
				Image sprite = (Image)(object)icon.m_Sprite;
				if ((object)icon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image icon2 = _Icon;
					if ((object)_Icon != null)
					{
						object sprite2 = icon2.m_Sprite;
						if ((object)icon2.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)_Icon != null)
								{
									Transform transform = _Icon.transform;
									if ((object)transform != null)
									{
										Transform parent = transform.parent;
										if ((object)parent != null)
										{
											Image component = parent.GetComponent<Image>();
											if ((object)component != null)
											{
												RectTransform rectTransform2 = component.rectTransform;
												object sprite3 = component.m_Sprite;
												if ((object)component.m_Sprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out ret2);
													Image sprite4 = (Image)(object)component.m_Sprite;
													if ((object)component.m_Sprite != null)
													{
														bool flag4 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
														Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
														if ((object)rectTransform2 != null)
														{
															rectTransform2.sizeDelta = sizeDelta;
															return;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnSelected()
	{
		GameWindowedUIPage page = _page;
		if ((object)_page != null && ((UnityEngine.Object)page).m_CachedPtr != (IntPtr)0)
		{
			_page.SetSelected(this);
		}
	}

	public void ShuffleText()
	{
		TextMeshProUGUI component = _Name.GetComponent<TextMeshProUGUI>();
		TextMeshProUGUI component2 = _Name.GetComponent<TextMeshProUGUI>();
		string text = component2.text;
		string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(text);
		component.text = text2;
		TextMeshProUGUI component3 = _Description.GetComponent<TextMeshProUGUI>();
		TextMeshProUGUI component4 = _Description.GetComponent<TextMeshProUGUI>();
		string text3 = component4.text;
		string text4 = VampireSurvivors.App.Tools.Extensions.Shuffle(text3);
		component3.text = text4;
	}

	public void SetPrice(float i)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F7F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_price = i;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(i, null, currentInfo);
		_Price.text = text;
		if (_itemType == ItemType.DUMMY_GOLDENEGG_MAX)
		{
			_Price.text = "ALL";
		}
	}

	public float GetPrice()
	{
		return _price;
	}

	public void SoldOut()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F80]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_Price.text = "Sold Out";
		_isSoldOut = true;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Fader, 0.5f, 0.05f);
	}

	public ItemData GetItemData()
	{
		return _itemData;
	}

	public WeaponData GetWeaponData()
	{
		return _weaponData;
	}

	protected unsafe override void OnDestroy()
	{
		//IL_005a: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_009f: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0226: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0160: Expected I, but got O
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_037b: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_019d: Expected I, but got O
		//IL_01d4: Expected O, but got I
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected I, but got Unknown
		//IL_03d1: Expected I, but got O
		base.OnDestroy();
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj12;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				num = unchecked((nint)null);
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_012d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ r8_v10+v439 @ rax_v48*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r10_v6+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_012d;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ r8_v10+8+v495 @ rcx_v41*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					goto IL_03a6;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_012d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_03a6;
			IL_03a6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v500 @ rdx_v14] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v23+10]");
			bool flag3 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (flag3)
			{
				continue;
			}
			Action<int, int, VampireSurvivors.Objects.Characters.CharacterController> value = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACB30");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v23+30]");
			Delegate obj15 = Delegate.Remove((Delegate)0, value);
			if ((object)obj15 == null)
			{
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj16 == null)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj17 == null)
				{
					throw new InvalidCastException();
				}
			}
			num = (nint)(obj14 + 48);
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
		}
		throw new NullReferenceException();
	}

	private void AnimateBuy()
	{
		_SheenAnimation.Play();
	}

	public ShopItemUI()
	{
		//IL_0036: Expected I, but got O
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
