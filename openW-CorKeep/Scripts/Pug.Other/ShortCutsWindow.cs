using System.Collections.Generic;
using UnityEngine;

public class ShortCutsWindow : UIelement
{
	private enum ShortcutType
	{
		Default = 0,
		QuickTrash = 1,
		LockItems = 2
	}

	public enum ModifierType
	{
		None = 0,
		LeftClick = 1,
		RightClick = 2
	}

	public struct ShortCut
	{
		public string Keybind;

		public string Desc;

		public ModifierType ModifierType;
	}

	public struct ShortCutString
	{
		public string Desc;

		public string Keybind;
	}

	public GameObject root;

	public GameObject visibleContainer;

	public GameObject shortCutsContainer;

	public PugText title;

	public PugText shortCutTextPrefab;

	public SpriteRenderer background;

	public BoxCollider backgroundCollider;

	private List<PugText> shortCutEntries = new List<PugText>();

	[Header("Background Colors")]
	public Color defaultBackgroundColor = new Color(0f, 0f, 0f, 0.6f);

	public Color quickTrashBackgroundColor = new Color(0.4f, 0f, 0f, 0.6f);

	public Color itemLockBackgroundColor = new Color(0.3f, 0.3f, 0f, 0.6f);

	[Header("Title Colors")]
	public Color defaultTitleColor = new Color(0.349f, 0.616f, 0.733f, 1f);

	public Color quickTrashTitleColor = new Color(0.66f, 0f, 0f, 1f);

	public Color itemLockTitleColor = new Color(0.86f, 0.8f, 0.28f, 1f);

	private const string SHORTCUTS_TITLE = "shortcutsPC";

	private const string TOGGLE_SHORTCUTS = "toggleShortcuts";

	private const string TOGGLE_SHORTCUTS_WINDOW = "ToggleShortCutsWindow";

	private const string LEFT_CLICK_TERM = "UIInteract";

	private const string RIGHT_CLICK_TERM = "UISecondInteract";

	private const string PICK_UP_ONE = "pickUpOne";

	private const string PICK_UP_ONE_TERM = "PickUpItems";

	private const string PICK_UP_HALF = "pickUpHalf";

	private const string PICK_UP_HALF_TERM = "PickUpHalf";

	private const string DROP_TO_WORLD = "dropToWorld";

	private const string DROP_TO_WORLD_TERM = "DropSelectedItem";

	private const string QUICK_MOVE = "quickMove";

	private const string QUICK_MOVE_TERM = "QuickMoveItems";

	private const string ItemLockTitle = "Menu/UiItemLockTitle";

	private const string ItemLockLine1 = "Menu/UiItemLockLine1";

	private const string ItemLockLine2 = "Menu/UiItemLockLine2";

	private const string ItemLockLine3 = "Menu/UiItemLockLine3";

	private const string QuickTrashTitle = "Menu/UiQuickTrashTitle";

	private const string QuickTrashLine1 = "Menu/UiQuickTrashLine1";

	private const string QuickTrashLine2 = "Menu/UiQuickTrashLine2";

	private const string QuickTrashLine3 = "Menu/UiQuickTrashLine3";

	private List<ShortCut> keyBoardShortCuts = new List<ShortCut>
	{
		new ShortCut
		{
			Keybind = "PickUpItems",
			Desc = "pickUpOne"
		},
		new ShortCut
		{
			Keybind = "PickUpHalf",
			Desc = "pickUpHalf",
			ModifierType = ModifierType.RightClick
		},
		new ShortCut
		{
			Keybind = "QuickMoveItems",
			Desc = "quickMove",
			ModifierType = ModifierType.LeftClick
		}
	};

	private List<ShortCut> controllerShortCuts = new List<ShortCut>
	{
		new ShortCut
		{
			Keybind = "PickUpItems",
			Desc = "pickUpOne"
		},
		new ShortCut
		{
			Keybind = "PickUpHalf",
			Desc = "pickUpHalf"
		},
		new ShortCut
		{
			Keybind = "DropSelectedItem",
			Desc = "dropToWorld",
			ModifierType = ModifierType.LeftClick
		},
		new ShortCut
		{
			Keybind = "QuickMoveItems",
			Desc = "quickMove",
			ModifierType = ModifierType.LeftClick
		}
	};

	public override bool isShowing => root.activeInHierarchy;

	private void Awake()
	{
		HideUI();
	}

	public void ToggleUI()
	{
		root.gameObject.SetActive(!root.gameObject.activeSelf);
	}

	public void ShowUI()
	{
		root.gameObject.SetActive(value: true);
	}

	public void HideUI()
	{
		root.gameObject.SetActive(value: false);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		bool hasShownShortCutsWindow = Manager.prefs.hasShownShortCutsWindow;
		if (Manager.prefs.hideInGameUI)
		{
			HideUI();
			return;
		}
		if (!hasShownShortCutsWindow && Manager.ui.isChestInventoryUIShowing && !Manager.saves.IsCreativeModeCharacter())
		{
			ShowUI();
		}
		if (!isShowing)
		{
			return;
		}
		bool isAnyInventoryShowing = Manager.ui.isAnyInventoryShowing;
		visibleContainer.SetActive(isAnyInventoryShowing);
		if (isAnyInventoryShowing)
		{
			UpdateShortCuts();
			if (!hasShownShortCutsWindow)
			{
				Manager.prefs.hasShownShortCutsWindow = true;
			}
		}
	}

	private void RenderLockItemsInformation()
	{
		title.Render("Menu/UiItemLockTitle");
		foreach (PugText shortCutEntry in shortCutEntries)
		{
			shortCutEntry.gameObject.SetActive(value: false);
		}
		string[] array = new string[3] { "Menu/UiItemLockLine1", "Menu/UiItemLockLine2", "Menu/UiItemLockLine3" };
		float previousBottom = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			if (shortCutEntries.Count <= i)
			{
				shortCutEntries.Add(Object.Instantiate(shortCutTextPrefab, shortCutsContainer.transform));
			}
			PugText pugText = shortCutEntries[i];
			pugText.gameObject.SetActive(value: true);
			shortCutEntries[i].localize = true;
			pugText.Render(array[i]);
			float paddingFromPrevious = 0.375f;
			previousBottom = UIManager.PositionElementBeneath(pugText.transform, previousBottom, pugText.dimensions.height, paddingFromPrevious);
		}
		UpdateBackgroundAndLayout(previousBottom);
	}

	private void RenderQuickTrashInformation()
	{
		title.Render("Menu/UiQuickTrashTitle");
		foreach (PugText shortCutEntry in shortCutEntries)
		{
			shortCutEntry.gameObject.SetActive(value: false);
		}
		string[] array = new string[3] { "Menu/UiQuickTrashLine1", "Menu/UiQuickTrashLine2", "Menu/UiQuickTrashLine3" };
		float previousBottom = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			if (shortCutEntries.Count <= i)
			{
				shortCutEntries.Add(Object.Instantiate(shortCutTextPrefab, shortCutsContainer.transform));
			}
			PugText pugText = shortCutEntries[i];
			pugText.gameObject.SetActive(value: true);
			shortCutEntries[i].localize = true;
			pugText.Render(array[i]);
			float paddingFromPrevious = 0.375f;
			previousBottom = UIManager.PositionElementBeneath(pugText.transform, previousBottom, pugText.dimensions.height, paddingFromPrevious);
		}
		UpdateBackgroundAndLayout(previousBottom);
	}

	private void RenderDefaultInformation()
	{
		bool prefersJoystick = Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
		title.Render("shortcutsPC");
		List<ShortCutString> shortCutStrings = GetShortCutStrings();
		shortCutStrings.Add(new ShortCutString
		{
			Desc = "toggleShortcuts",
			Keybind = Manager.ui.GetShortCutString("ToggleShortCutsWindow", prefersJoystick)
		});
		int i = 0;
		float previousBottom = 0f;
		for (; i < shortCutStrings.Count * 2; i += 2)
		{
			bool num = i == shortCutStrings.Count * 2 - 2;
			if (shortCutEntries.Count <= i + 1)
			{
				shortCutEntries.Add(Object.Instantiate(shortCutTextPrefab, shortCutsContainer.transform));
				shortCutEntries.Add(Object.Instantiate(shortCutTextPrefab, shortCutsContainer.transform));
			}
			int index = i / 2;
			shortCutEntries[i].gameObject.SetActive(value: true);
			string desc = shortCutStrings[index].Desc;
			shortCutEntries[i].localize = true;
			shortCutEntries[i].Render(desc);
			float paddingFromPrevious = (num ? 0.5f : 0.375f);
			previousBottom = UIManager.PositionElementBeneath(shortCutEntries[i].transform, previousBottom, shortCutEntries[i].dimensions.height, paddingFromPrevious);
			int index2 = i + 1;
			shortCutEntries[index2].gameObject.SetActive(value: true);
			shortCutEntries[index2].localize = false;
			shortCutEntries[index2].Render(shortCutStrings[index].Keybind);
			previousBottom = UIManager.PositionElementBeneath(shortCutEntries[index2].transform, previousBottom, shortCutEntries[index2].dimensions.height, 0.0625f);
			if (num)
			{
				shortCutEntries[i].SetTempColor(Color.gray);
				shortCutEntries[i + 1].SetTempColor(Color.gray);
			}
		}
		for (; i < shortCutEntries.Count; i++)
		{
			shortCutEntries[i].gameObject.SetActive(value: false);
		}
		UpdateBackgroundAndLayout(previousBottom);
	}

	private Color GetBackgroundColorForType(ShortcutType type)
	{
		return type switch
		{
			ShortcutType.QuickTrash => quickTrashBackgroundColor, 
			ShortcutType.LockItems => itemLockBackgroundColor, 
			_ => defaultBackgroundColor, 
		};
	}

	private Color GetTitleColorForType(ShortcutType type)
	{
		return type switch
		{
			ShortcutType.QuickTrash => quickTrashTitleColor, 
			ShortcutType.LockItems => itemLockTitleColor, 
			_ => defaultTitleColor, 
		};
	}

	private void UpdateBackgroundAndLayout(float previousBottom, float extraPadding = 0.25f)
	{
		float num = 0f - previousBottom + title.dimensions.size.y + extraPadding;
		Transform obj = background.transform;
		Vector3 localPosition = obj.localPosition;
		obj.localPosition = new Vector3(localPosition.x, (0f - num) / 2f, localPosition.z);
		background.size = new Vector2(background.size.x, num);
		Vector3 size = backgroundCollider.size;
		size = new Vector3(size.x, num, size.z);
		backgroundCollider.size = size;
		root.transform.localPosition = new Vector3(0f, Mathf.Max(0f, num - 12.125f), 0f);
		ShortcutType currentInfoType = GetCurrentInfoType();
		background.color = GetBackgroundColorForType(currentInfoType);
		title.SetTempColor(GetTitleColorForType(currentInfoType));
	}

	private ShortcutType GetCurrentInfoType()
	{
		return Manager.ui.mouse.mouseMode switch
		{
			UIMouse.MouseMode.QuickTrash => ShortcutType.QuickTrash, 
			UIMouse.MouseMode.Locking => ShortcutType.LockItems, 
			_ => ShortcutType.Default, 
		};
	}

	private void UpdateShortCuts()
	{
		switch (GetCurrentInfoType())
		{
		case ShortcutType.QuickTrash:
			RenderQuickTrashInformation();
			break;
		case ShortcutType.LockItems:
			RenderLockItemsInformation();
			break;
		default:
			RenderDefaultInformation();
			break;
		}
	}

	private List<ShortCutString> GetShortCutStrings()
	{
		List<ShortCutString> list = new List<ShortCutString>();
		bool flag = Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
		List<ShortCut> obj = (flag ? controllerShortCuts : keyBoardShortCuts);
		string shortCutString = Manager.ui.GetShortCutString("UIInteract", flag);
		string shortCutString2 = Manager.ui.GetShortCutString("UISecondInteract", flag);
		foreach (ShortCut item in obj)
		{
			string text = Manager.ui.GetShortCutString(item.Keybind, flag);
			if (!string.IsNullOrEmpty(text))
			{
				if (item.ModifierType == ModifierType.LeftClick)
				{
					text = text + " +" + shortCutString;
				}
				else if (item.ModifierType == ModifierType.RightClick)
				{
					text = text + " +" + shortCutString2;
				}
				list.Add(new ShortCutString
				{
					Desc = item.Desc,
					Keybind = text
				});
			}
		}
		return list;
	}
}
