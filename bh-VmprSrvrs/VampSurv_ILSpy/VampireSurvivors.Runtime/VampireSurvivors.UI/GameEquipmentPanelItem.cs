using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.UI;

public class GameEquipmentPanelItem : MonoBehaviour
{
	private RectTransform _levelContainer;

	private GameObject _levelPrefab;

	private Image _icon;

	private Image _BlockedIcon;

	private float _iconAlphaWhenEquipmentDisabled;

	private Vector2 _blockedIconSizeWhenEquipmentDisabled;

	private WeaponData _data;

	private WeaponType _type;

	private bool _isSet;

	private int _currentLevel;

	private readonly List<GameObject> _spawnedSlots;

	public void Initialize(VampireSurvivors.Objects.Characters.CharacterController ownerCharacter, WeaponData data, WeaponType type)
	{
		//IL_0255: Expected O, but got I4
		//IL_055e: Expected O, but got I4
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_028e: Expected O, but got I4
		//IL_064e->IL0573: Incompatible stack heights: 1 vs 0
		//IL_02e1->IL0573: Incompatible stack heights: 1 vs 0
		//IL_030d->IL0573: Incompatible stack heights: 1 vs 0
		//IL_0337->IL0573: Incompatible stack heights: 1 vs 0
		//IL_0361->IL0573: Incompatible stack heights: 1 vs 0
		//IL_039d->IL0573: Incompatible stack heights: 1 vs 0
		//IL_06a7->IL0573: Incompatible stack heights: 2 vs 0
		//IL_06ee->IL0573: Incompatible stack heights: 3 vs 0
		//IL_03ed->IL0573: Incompatible stack heights: 3 vs 0
		//IL_0419->IL0573: Incompatible stack heights: 3 vs 0
		//IL_044f->IL0573: Incompatible stack heights: 3 vs 0
		//IL_0471->IL0573: Incompatible stack heights: 3 vs 0
		//IL_053c->IL0573: Incompatible stack heights: 3 vs 0
		//IL_04fd->IL0573: Incompatible stack heights: 3 vs 0
		_data = data;
		_type = type;
		if (data != null)
		{
			Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
			if ((object)_icon != null)
			{
				_icon.sprite = sprite;
				if ((object)_icon != null)
				{
					_icon.enabled = true;
					WeaponData data2 = _data;
					bool flag = _data == null;
					object[] array = null;
					WeaponData weaponData = null;
					WeaponData weaponData2 = null;
					if (!flag)
					{
						Vector2 sizeDelta = default(Vector2);
						while (true)
						{
							if ((nint)weaponData < data2._003Clevel_003Ek__BackingField)
							{
								GameObject item = UnityEngine.Object.Instantiate(_levelPrefab, _levelContainer);
								List<object> spawnedSlots = (List<object>)(object)_spawnedSlots;
								if (_spawnedSlots == null)
								{
									break;
								}
								int version = spawnedSlots._version + 1;
								spawnedSlots._version = version;
								array = spawnedSlots._items;
								if (spawnedSlots._items == null)
								{
									break;
								}
								if (spawnedSlots._size >= array.Length)
								{
									((List<object>)(object)_spawnedSlots).AddWithResize((object)item);
								}
								else
								{
									int size = spawnedSlots._size + 1;
									spawnedSlots._size = size;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								data2 = _data;
								weaponData2 = (WeaponData)(weaponData2 + 1);
								if (_data == null)
								{
									break;
								}
								weaponData = weaponData2;
								continue;
							}
							if ((object)_icon == null)
							{
								break;
							}
							RectTransform rectTransform = _icon.rectTransform;
							WeaponData icon = (WeaponData)(object)_icon;
							if ((object)_icon == null)
							{
								break;
							}
							WeaponData weaponData3 = (WeaponData)icon._003Cseen_003Ek__BackingField;
							if (!icon._003Cseen_003Ek__BackingField)
							{
								break;
							}
							if (~(weaponData3._003Chidden_003Ek__BackingField ? 1u : 0u) != 0)
							{
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(icon._003Cseen_003Ek__BackingField);
								break;
							}
							Sprite.get_rect_Injected((IntPtr)(weaponData3._003Chidden_003Ek__BackingField ? 1 : 0), out Rect ret);
							WeaponData icon2 = (WeaponData)(object)_icon;
							if ((object)_icon == null)
							{
								break;
							}
							WeaponData weaponData4 = (WeaponData)icon2._003Cseen_003Ek__BackingField;
							if (!icon2._003Cseen_003Ek__BackingField)
							{
								break;
							}
							bool flag2 = (byte)(~(weaponData4._003Chidden_003Ek__BackingField ? 1u : 0u)) != 0;
							Sprite.get_rect_Injected((IntPtr)(weaponData4._003Chidden_003Ek__BackingField ? 1 : 0), out Rect ret2);
							if ((object)rectTransform == null)
							{
								break;
							}
							rectTransform.sizeDelta = sizeDelta;
							if ((object)_icon == null)
							{
								break;
							}
							Transform transform = _icon.transform;
							if ((object)transform == null)
							{
								break;
							}
							Transform parent = transform.parent;
							if ((object)parent == null)
							{
								break;
							}
							Image component = parent.GetComponent<Image>();
							if ((object)component == null)
							{
								break;
							}
							RectTransform rectTransform2 = component.rectTransform;
							WeaponData sprite2 = (WeaponData)(object)component.m_Sprite;
							if ((object)component.m_Sprite == null)
							{
								break;
							}
							bool flag3 = (byte)(~(sprite2._003Chidden_003Ek__BackingField ? 1u : 0u)) != 0;
							Sprite.get_rect_Injected((IntPtr)(sprite2._003Chidden_003Ek__BackingField ? 1 : 0), out ret);
							WeaponData sprite3 = (WeaponData)(object)component.m_Sprite;
							if ((object)component.m_Sprite == null)
							{
								break;
							}
							bool flag4 = (byte)(~(sprite3._003Chidden_003Ek__BackingField ? 1u : 0u)) != 0;
							Sprite.get_rect_Injected((IntPtr)(sprite3._003Chidden_003Ek__BackingField ? 1 : 0), out ret2);
							if ((object)rectTransform2 == null)
							{
								break;
							}
							rectTransform2.sizeDelta = sizeDelta;
							SetLevel(1);
							if ((object)_levelContainer == null)
							{
								break;
							}
							GameObject gameObject = _levelContainer.gameObject;
							if ((object)gameObject == null)
							{
								break;
							}
							gameObject.SetActive(value: false);
							_isSet = true;
							if ((object)ownerCharacter == null || (object)ownerCharacter._weaponsManager == null)
							{
								break;
							}
							Weapon weaponByType = ownerCharacter._weaponsManager.GetWeaponByType(type);
							Behaviour blockedIcon;
							bool flag5;
							if ((object)weaponByType != null && ((WeaponData)(object)weaponByType)._003Chidden_003Ek__BackingField)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1244 @ rax_v61 (VampireSurvivors.Objects.Weapons.Weapon)+151]");
								SetDisabledIcon(disabled: false);
								blockedIcon = _BlockedIcon;
								if ((object)_BlockedIcon == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1244 @ rax_v61 (VampireSurvivors.Objects.Weapons.Weapon)+151]");
								flag5 = false;
							}
							else
							{
								blockedIcon = _BlockedIcon;
								if ((object)_BlockedIcon == null)
								{
									break;
								}
								flag5 = false;
							}
							blockedIcon.enabled = flag5;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Reset()
	{
		//IL_00b8: Expected O, but got I
		Behaviour icon = _icon;
		if ((object)_icon != null)
		{
			_icon.enabled = false;
			if (_spawnedSlots != null)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					UnityEngine.Object.Destroy(null, 0f);
				}
				icon = (Behaviour)(object)_spawnedSlots;
				if (_spawnedSlots != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v3 (UnityEngine.Behaviour)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v3 (UnityEngine.Behaviour)+18]");
					if ((nint)0 > (nint)0)
					{
						IntPtr cachedPtr = ((UnityEngine.Object)icon).m_CachedPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v3 (UnityEngine.Behaviour)+18]");
						Array.Clear((Array)(nint)cachedPtr, 0, 0);
					}
					_isSet = false;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public bool IsSet()
	{
		return _isSet;
	}

	public unsafe void SetBlocked(bool blocked)
	{
		//IL_007b: Expected O, but got Ref
		Image blockedIcon = _BlockedIcon;
		if ((object)_BlockedIcon != null && ((UnityEngine.Object)blockedIcon).m_CachedPtr != (IntPtr)0)
		{
			bool flag = (byte)((blocked ? 1u : 0u) ^ 1u) != 0;
			_icon.enabled = flag;
			_BlockedIcon.enabled = blocked;
			object obj = default(object);
			_BlockedIcon.color = (Color)(&obj);
		}
	}

	public unsafe void SetDisabledIcon(bool disabled)
	{
		//IL_0059: Expected O, but got Ref
		//IL_00c0: Expected O, but got Ref
		Image blockedIcon = _BlockedIcon;
		if ((object)_BlockedIcon != null && ((UnityEngine.Object)blockedIcon).m_CachedPtr != (IntPtr)0)
		{
			_BlockedIcon.enabled = disabled;
			object obj = default(object);
			_BlockedIcon.color = (Color)(&obj);
			RectTransform rectTransform = _BlockedIcon.rectTransform;
			Vector2 sizeDelta = default(Vector2);
			rectTransform.sizeDelta = sizeDelta;
			if (disabled)
			{
			}
			Color color = _icon.color;
			_icon.color = (Color)(&obj);
		}
	}

	public void CreateSlots()
	{
		//IL_0102: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		WeaponData data = _data;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < data._003Clevel_003Ek__BackingField)
		{
			GameObject item = UnityEngine.Object.Instantiate(_levelPrefab, _levelContainer);
			List<object> spawnedSlots = (List<object>)(object)_spawnedSlots;
			int version = spawnedSlots._version + 1;
			spawnedSlots._version = version;
			object[] items = spawnedSlots._items;
			if (spawnedSlots._size >= items.Length)
			{
				spawnedSlots.AddWithResize((object)item);
			}
			else
			{
				int size = spawnedSlots._size + 1;
				spawnedSlots._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			data = _data;
			obj++;
			obj2 = obj;
		}
	}

	public void SetLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_005d->IL00c1: Incompatible stack heights: 1 vs 0
		//IL_0094->IL00c1: Incompatible stack heights: 1 vs 0
		//IL_0155->IL00c1: Incompatible stack heights: 2 vs 0
		//IL_01b4->IL00c1: Incompatible stack heights: 3 vs 0
		//IL_0214->IL00c1: Incompatible stack heights: 4 vs 0
		//IL_026f->IL0275: Incompatible stack heights: 5 vs 0
		//IL_0274->IL0274: Incompatible stack heights: 5 vs 0
		int num2 = default(int);
		int num = (_currentLevel = num2 - 1);
		if (num <= 0)
		{
			return;
		}
		object obj = 0;
		while (true)
		{
			List<GameObject> spawnedSlots = _spawnedSlots;
			if (_spawnedSlots != null)
			{
				bool flag = (nint)obj >= spawnedSlots._size;
				GameObject[] items = spawnedSlots._items;
				if (spawnedSlots._items != null)
				{
					Transform transform = (Transform)(object)items[obj];
					if ((object)items[obj] != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)transform).m_CachedPtr);
						Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform2 != null)
						{
							bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)transform2).m_CachedPtr, 0);
							Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
							if ((object)transform3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v41 (UnityEngine.Transform)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v41 (UnityEngine.Transform)+10]");
								IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
								GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
								if ((object)gameObject != null)
								{
									bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
									obj++;
									if ((nint)obj >= num)
									{
										break;
									}
									continue;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public WeaponData GetWData()
	{
		return _data;
	}

	public WeaponType GetWType()
	{
		return _type;
	}

	public GameEquipmentPanelItem()
	{
		List<GameObject> spawnedSlots = new List<GameObject>();
		_spawnedSlots = spawnedSlots;
	}

	private unsafe void _003CSetDisabledIcon_003Eg__SetIconAlpha_007C15_0(float value)
	{
		//IL_0023: Expected O, but got Ref
		Color color = _icon.color;
		object obj = default(object);
		_icon.color = (Color)(&obj);
	}
}
