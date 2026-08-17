using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class CollectionItemUI : SelectableUI
{
	public enum CollectionTypes
	{
		WEAPON,
		ITEM,
		ARCANA
	}

	private Image LockedIcon;

	private Image UnlockedIcon;

	private Image Frame;

	private Image _SealIcon;

	private WeaponData _weaponData;

	private WeaponType _weaponType;

	private CollectionsPage _page;

	private ItemData _itemData;

	private ItemType _itemType;

	private ArcanaData _arcanaData;

	private ArcanaType _arcanaType;

	private Button _button;

	private bool _seen;

	public CollectionTypes CollectionType;

	public unsafe void SetData(WeaponData w, CollectionsPage page, WeaponType _wType, bool isSealed)
	{
		//IL_011d: Expected O, but got Ref
		CollectionType = CollectionTypes.WEAPON;
		_weaponData = w;
		_page = page;
		_weaponType = _wType;
		_seen = w._003Cseen_003Ek__BackingField;
		Sprite sprite = SpriteManager.GetSprite(w._003CframeName_003Ek__BackingField, w._003Ctexture_003Ek__BackingField);
		UnlockedIcon.sprite = sprite;
		string spriteName = ((w._003CcollectionFrame_003Ek__BackingField != null) ? w._003CcollectionFrame_003Ek__BackingField : "frameB");
		Sprite sprite2 = SpriteManager.GetSprite(spriteName, "UI");
		Frame.sprite = sprite2;
		SetLocked(w._003Cseen_003Ek__BackingField);
		SetupClickRegister();
		object obj = default(object);
		if (obj == null)
		{
			UnSeal();
		}
		else
		{
			Seal();
		}
		GameObject gameObject = base.gameObject;
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 309 Invalid \"Jump target not found in method: 0x186CA0260\"");
		throw new NullReferenceException();
	}

	public ItemData GetItemData()
	{
		return _itemData;
	}

	private void SetIconSizes()
	{
		//IL_022f: Expected O, but got I4
		//IL_02c9->IL0269: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL0269: Incompatible stack heights: 1 vs 0
		//IL_0318->IL0269: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL0269: Incompatible stack heights: 2 vs 0
		//IL_010e->IL0269: Incompatible stack heights: 2 vs 0
		//IL_013d->IL0269: Incompatible stack heights: 2 vs 0
		//IL_0377->IL0269: Incompatible stack heights: 3 vs 0
		//IL_0176->IL0269: Incompatible stack heights: 3 vs 0
		//IL_03cb->IL0269: Incompatible stack heights: 4 vs 0
		//IL_01ac->IL0269: Incompatible stack heights: 4 vs 0
		//IL_01e4->IL0269: Incompatible stack heights: 4 vs 0
		//IL_0213->IL0269: Incompatible stack heights: 4 vs 0
		//IL_0424->IL0269: Incompatible stack heights: 5 vs 0
		//IL_024c->IL0269: Incompatible stack heights: 5 vs 0
		//IL_0471->IL0269: Incompatible stack heights: 6 vs 0
		if ((object)UnlockedIcon != null)
		{
			RectTransform rectTransform = UnlockedIcon.rectTransform;
			Image unlockedIcon = UnlockedIcon;
			if ((object)UnlockedIcon != null)
			{
				Image sprite = (Image)(object)unlockedIcon.m_Sprite;
				if ((object)unlockedIcon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image unlockedIcon2 = UnlockedIcon;
					if ((object)UnlockedIcon != null)
					{
						Image sprite2 = (Image)(object)unlockedIcon2.m_Sprite;
						if ((object)unlockedIcon2.m_Sprite != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)LockedIcon != null)
								{
									RectTransform rectTransform2 = LockedIcon.rectTransform;
									Image lockedIcon = LockedIcon;
									if ((object)LockedIcon != null)
									{
										object sprite3 = lockedIcon.m_Sprite;
										if ((object)lockedIcon.m_Sprite != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v19 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v19 (System.Object)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out ret2);
											Image lockedIcon2 = LockedIcon;
											if ((object)LockedIcon != null)
											{
												object sprite4 = lockedIcon2.m_Sprite;
												if ((object)lockedIcon2.m_Sprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
													bool flag4 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out ret);
													if ((object)rectTransform2 != null)
													{
														rectTransform2.sizeDelta = sizeDelta;
														if ((object)_SealIcon != null)
														{
															RectTransform rectTransform3 = _SealIcon.rectTransform;
															Image sealIcon = _SealIcon;
															if ((object)_SealIcon != null)
															{
																Image sprite5 = (Image)(object)sealIcon.m_Sprite;
																if ((object)sealIcon.m_Sprite != null)
																{
																	bool flag5 = ((UnityEngine.Object)sprite5).m_CachedPtr == (IntPtr)0;
																	Sprite.get_rect_Injected(((UnityEngine.Object)sprite5).m_CachedPtr, out ret2);
																	CollectionItemUI sealIcon2 = (CollectionItemUI)(object)_SealIcon;
																	if ((object)_SealIcon != null)
																	{
																		CollectionItemUI collectionItemUI = (CollectionItemUI)sealIcon2._itemType;
																		if (sealIcon2._itemType != ItemType.VOID)
																		{
																			bool flag6 = ((UnityEngine.Object)collectionItemUI).m_CachedPtr == (IntPtr)0;
																			Sprite.get_rect_Injected(((UnityEngine.Object)collectionItemUI).m_CachedPtr, out ret);
																			if ((object)rectTransform3 != null)
																			{
																				rectTransform3.sizeDelta = sizeDelta;
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetItem(ItemData w, CollectionsPage page, ItemType _item, bool isSealed)
	{
		//IL_01b1: Expected O, but got Ref
		CollectionType = CollectionTypes.ITEM;
		string spriteName = (w._003CisRelic_003Ek__BackingField ? "frameF" : "frameC");
		Sprite sprite = SpriteManager.GetSprite(spriteName, "UI");
		Frame.sprite = sprite;
		string text = w._003CcollectionFrame_003Ek__BackingField;
		if (w._003CcollectionFrame_003Ek__BackingField != null && text._stringLength > 0)
		{
			Sprite sprite2 = SpriteManager.GetSprite(w._003CcollectionFrame_003Ek__BackingField);
			Frame.sprite = sprite2;
		}
		_itemData = w;
		_itemType = _item;
		_page = page;
		ItemData itemData = _itemData;
		_seen = itemData._003Cseen_003Ek__BackingField;
		Sprite sprite3 = SpriteManager.GetSprite(w._003CframeName_003Ek__BackingField, w._003Ctexture_003Ek__BackingField);
		UnlockedIcon.sprite = sprite3;
		SetLocked(w._003Cseen_003Ek__BackingField);
		SetupClickRegister();
		object obj = default(object);
		if (obj == null)
		{
			UnSeal();
		}
		else
		{
			Seal();
		}
		GameObject gameObject = base.gameObject;
		IntPtr intPtr = default(IntPtr);
		string text2 = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text2);
		SetIconSizes();
	}

	public unsafe void SetArcana(ArcanaData w, CollectionsPage page, ArcanaType type)
	{
		//IL_00f8: Expected O, but got Ref
		CollectionType = CollectionTypes.ARCANA;
		_arcanaData = w;
		ArcanaData arcanaData = _arcanaData;
		arcanaData._003Ctexture_003Ek__BackingField = "items";
		_page = page;
		_arcanaType = type;
		_seen = w._003Cunlocked_003Ek__BackingField;
		Sprite sprite = SpriteManager.GetSprite(w._003CframeName_003Ek__BackingField, w._003Ctexture_003Ek__BackingField);
		UnlockedIcon.sprite = sprite;
		string spriteName = ((_arcanaType <= ArcanaType.T21_BLOODY) ? "frameG" : "frameH");
		Sprite sprite2 = SpriteManager.GetSprite(spriteName, "UI");
		Frame.sprite = sprite2;
		SetLocked(w._003Cunlocked_003Ek__BackingField);
		SetupClickRegister();
		GameObject gameObject = base.gameObject;
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text);
		SetIconSizes();
	}

	public unsafe void Seal()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		Frame.color = (Color)(&obj);
		GameObject gameObject = _SealIcon.gameObject;
		gameObject.SetActive(value: true);
	}

	public unsafe void UnSeal()
	{
		//IL_002c: Expected O, but got Ref
		if (!_seen)
		{
		}
		object obj = default(object);
		Frame.color = (Color)(&obj);
		GameObject gameObject = _SealIcon.gameObject;
		gameObject.SetActive(value: false);
	}

	public bool IsWeapon()
	{
		//IL_0075: Expected I4, but got O
		if (_weaponType != WeaponType.VOID)
		{
			WeaponData weaponData = _weaponData;
			if (_weaponData != null)
			{
				return !weaponData._003CisPowerUp_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool IsPassive()
	{
		//IL_0080: Expected I4, but got O
		if (_weaponType != WeaponType.VOID)
		{
			WeaponData weaponData = _weaponData;
			if (_weaponData != null)
			{
				bool flag = !weaponData._003CisPowerUp_003Ek__BackingField;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool IsItem()
	{
		if (_itemType != ItemType.VOID)
		{
			bool flag = IsRelic();
			return !flag;
		}
		return false;
	}

	public unsafe bool IsRelic()
	{
		//IL_000e: Expected O, but got Ref
		//IL_0074: Expected I4, but got O
		if (_itemType != ItemType.VOID)
		{
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			if (text != null)
			{
				bool flag = text.Contains("RELIC");
				bool flag2 = !flag;
				return !flag2;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool IsArcana()
	{
		//IL_0010: Expected O, but got I4
		object obj = _arcanaType - -1;
		bool flag = obj == null;
		return !flag;
	}

	public bool IsDefaultContent()
	{
		if (_weaponData == null)
		{
			if (_itemData == null)
			{
				return true;
			}
			ItemData itemData = _itemData;
			return itemData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
		}
		WeaponData weaponData = _weaponData;
		return weaponData._003CcontentGroup_003Ek__BackingField == ContentGroupType.BASE;
	}

	public bool IsExtra()
	{
		//IL_00eb: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		if (_weaponData == null)
		{
			if (_itemData == null)
			{
				if (_arcanaData == null)
				{
					return false;
				}
				ArcanaData arcanaData = _arcanaData;
				object obj = arcanaData._003CcontentGroup_003Ek__BackingField - 1;
				return obj == null;
			}
			ItemData itemData = _itemData;
			object obj2 = itemData._003CcontentGroup_003Ek__BackingField - 1;
			return obj2 == null;
		}
		WeaponData weaponData = _weaponData;
		object obj3 = weaponData._003CcontentGroup_003Ek__BackingField - 1;
		return obj3 == null;
	}

	private unsafe void SetLocked(bool isUnlocked)
	{
		//IL_0163: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_01f6: Expected O, but got Ref
		//IL_027c->IL01f7: Incompatible stack heights: 1 vs 0
		//IL_01c2->IL01f7: Incompatible stack heights: 1 vs 0
		//IL_02cf->IL01f7: Incompatible stack heights: 2 vs 0
		//IL_02ee->IL01f7: Incompatible stack heights: 2 vs 0
		if ((object)LockedIcon != null)
		{
			GameObject gameObject = LockedIcon.gameObject;
			if ((object)gameObject != null)
			{
				bool active = (byte)((isUnlocked ? 1u : 0u) ^ 1u) != 0;
				gameObject.SetActive(active);
				if ((object)UnlockedIcon != null)
				{
					GameObject gameObject2 = UnlockedIcon.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(isUnlocked);
						if ((object)Frame != null)
						{
							GameObject gameObject3 = Frame.gameObject;
							if ((object)gameObject3 != null)
							{
								gameObject3.SetActive(value: true);
								if (isUnlocked)
								{
								}
								if ((object)Frame != null)
								{
									RectTransform rectTransform = Frame.rectTransform;
									object frame = Frame;
									if ((object)Frame != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v6 (System.Object)+E0]");
										object obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdi_v6 (System.Object)+E0]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v7 (System.Object)+10]");
											bool flag = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v7 (System.Object)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out Rect _);
											object frame2 = Frame;
											if ((object)Frame != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8 (System.Object)+E0]");
												object obj2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v8 (System.Object)+E0]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v9 (System.Object)+10]");
													bool flag2 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v9 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
													if ((object)rectTransform != null)
													{
														Vector2 sizeDelta = default(Vector2);
														rectTransform.sizeDelta = sizeDelta;
														if (!isUnlocked || (object)Frame != null)
														{
															Frame.color = (Color)(&ret2);
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
		if (CollectionType != CollectionTypes.WEAPON)
		{
			if (CollectionType != CollectionTypes.ITEM)
			{
				_page.SetInfoPanel(_arcanaData, _arcanaType);
			}
			else
			{
				_page.SetInfoPanel(_itemData, _itemType);
			}
		}
		else
		{
			_page.SetInfoPanel(_weaponData, _weaponType);
		}
	}

	private void SetupClickRegister()
	{
		Button component = GetComponent<Button>();
		_button = component;
		Button button = _button;
		UnityAction call = RegisterClick;
		button.m_OnClick.AddListener(call);
	}

	private void RegisterClick()
	{
		//IL_0010: Expected O, but got I4
		object obj = _itemType - 28;
		bool isYellowSign = obj == null;
		_page.RegisterItemClick(isYellowSign);
		if (_itemType != ItemType.VOID)
		{
			if (!_seen)
			{
				return;
			}
			ItemData itemData = _itemData;
			if (!itemData._003Csealable_003Ek__BackingField)
			{
				_page.OnUnsealableClicked();
			}
			else
			{
				_page.ItemClicked(this, _itemType);
			}
		}
		if (_weaponType == WeaponType.VOID)
		{
			return;
		}
		WeaponData weaponData = _weaponData;
		if (weaponData._003Cseen_003Ek__BackingField)
		{
			if (!weaponData._003Csealable_003Ek__BackingField)
			{
				_page.OnUnsealableClicked();
			}
			else
			{
				_page.WeaponClicked(this, _weaponType);
			}
		}
	}

	public WeaponType GetWeaponType()
	{
		return _weaponType;
	}

	public WeaponData GetWeaponData()
	{
		return _weaponData;
	}

	public ItemType GetItemType()
	{
		return _itemType;
	}

	public ContentGroupType GetContentGroup()
	{
		//IL_0114: Expected I4, but got O
		if (_weaponType == WeaponType.VOID)
		{
			goto IL_0096;
		}
		WeaponData weaponData = _weaponData;
		if (_weaponData != null)
		{
			if (weaponData._003CisPowerUp_003Ek__BackingField)
			{
				goto IL_0096;
			}
			if (_weaponData != null)
			{
				return weaponData._003CcontentGroup_003Ek__BackingField;
			}
		}
		goto IL_0106;
		IL_0096:
		if (_itemType != ItemType.VOID && !IsRelic())
		{
			ItemData itemData = _itemData;
			if (_itemData != null)
			{
				return itemData._003CcontentGroup_003Ek__BackingField;
			}
			goto IL_0106;
		}
		return ContentGroupType.BASE;
		IL_0106:
		NullReferenceException ex = new NullReferenceException();
		return (ContentGroupType)ex;
	}

	public ArcanaType GetArcanaType()
	{
		return _arcanaType;
	}

	public CollectionItemUI()
	{
		//IL_000f: Expected I4, but got I8
		//IL_0045: Expected I, but got O
		_arcanaType = ArcanaType.VOID;
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
