using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI;

public class EquipmentIconPaused : MonoBehaviour
{
	private List<Image> _Levels;

	private Image _Icon;

	private Sprite _CompletedLevel;

	private Sprite _IncompleteLevel;

	private GameObject _LevelIconPrefab;

	private RectTransform _LevelIconContainer;

	private TextMeshProUGUI _LimitBreakLevelText;

	private List<GameObject> _spawned;

	private WeaponType _type;

	public void SetData(WeaponType t, int level, int maxLevel, Sprite s, bool isBanished)
	{
		//IL_02e5: Expected O, but got I
		//IL_018f: Expected I4, but got O
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_01b8: Expected I4, but got O
		//IL_01f8: Expected I4, but got O
		//IL_0212: Expected O, but got I
		//IL_0482->IL031e: Incompatible stack heights: 1 vs 0
		//IL_0305->IL031e: Incompatible stack heights: 1 vs 0
		//IL_0423->IL031e: Incompatible stack heights: 2 vs 0
		_type = t;
		bool flag = maxLevel <= 0;
		int num = maxLevel;
		if (flag)
		{
			goto IL_0217;
		}
		Image image = null;
		object obj = default(object);
		Rect ret;
		while (true)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_LevelIconPrefab, _LevelIconContainer);
			List<object> spawned = (List<object>)(object)_spawned;
			if (_spawned == null)
			{
				break;
			}
			int version = spawned._version + 1;
			spawned._version = version;
			object[] items = spawned._items;
			if (spawned._items == null)
			{
				break;
			}
			if (spawned._size >= items.Length)
			{
				((List<object>)(object)_spawned).AddWithResize((object)gameObject);
			}
			else
			{
				int size = spawned._size + 1;
				spawned._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Sprite sprite = ((level > (nint)image) ? _CompletedLevel : _IncompleteLevel);
			if ((object)gameObject == null)
			{
				break;
			}
			Image component = gameObject.GetComponent<Image>();
			if ((object)component == null)
			{
				break;
			}
			component.sprite = sprite;
			bool flag2 = obj == null;
			num = (int)spawned._items;
			if (!flag2)
			{
				bool flag3 = (nint)image < level;
				num = (int)spawned._items;
				if (!flag3)
				{
					Image component2 = gameObject.GetComponent<Image>();
					if ((object)component2 == null)
					{
						break;
					}
					num = (int)component2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ r9_v8 (System.Int32)+2A8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
					ret = (Rect)0;
				}
			}
			image = (Image)(image + 1);
			if ((nint)image >= maxLevel)
			{
				goto IL_0217;
			}
		}
		goto IL_031e;
		IL_0217:
		if ((object)_Icon != null)
		{
			Sprite sprite2 = default(Sprite);
			_Icon.sprite = sprite2;
			if ((object)_Icon != null)
			{
				RectTransform rectTransform = _Icon.rectTransform;
				Image icon = _Icon;
				if ((object)_Icon != null)
				{
					object sprite3 = icon.m_Sprite;
					if ((object)icon.m_Sprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdi_v12 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdi_v12 (System.Object)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out Rect _);
						EquipmentIconPaused icon2 = (EquipmentIconPaused)(object)_Icon;
						if ((object)_Icon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v9 (VampireSurvivors.UI.EquipmentIconPaused)+E0]");
							EquipmentIconPaused equipmentIconPaused = (EquipmentIconPaused)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rbx_v9 (VampireSurvivors.UI.EquipmentIconPaused)+E0]");
							if ((nint)0 != 0)
							{
								bool flag5 = ((UnityEngine.Object)equipmentIconPaused).m_CachedPtr == (IntPtr)0;
								Sprite.get_rect_Injected(((UnityEngine.Object)equipmentIconPaused).m_CachedPtr, out ret);
								if ((object)rectTransform != null)
								{
									bool flag6 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
									Vector2 value = default(Vector2);
									RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_031e;
		IL_031e:
		throw new NullReferenceException();
	}

	public WeaponType GetWeaponType()
	{
		return _type;
	}

	public unsafe void SetLimitBreakLevel(int limitBreakLevel, int foundWeaponLevel)
	{
		//IL_006e: Expected O, but got Ref
		GameObject gameObject = _LevelIconContainer.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _LimitBreakLevelText.gameObject;
		gameObject2.SetActive(value: true);
		int value = foundWeaponLevel + limitBreakLevel;
		object obj = default(object);
		string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public EquipmentIconPaused()
	{
		List<Image> levels = new List<Image>();
		_Levels = levels;
		List<GameObject> spawned = new List<GameObject>();
		_spawned = spawned;
	}
}
