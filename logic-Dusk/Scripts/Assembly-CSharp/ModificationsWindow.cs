using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModificationsWindow
{
	private const float MARGIN_X = 50f;

	private const float MARGIN_Y = 50f;

	private Rect _windowRect;

	private float _windowWidth;

	private float _windowHeight;

	private Vector2 _scrollPositionLeft = Vector2.zero;

	private Vector2 _scrollPositionMiddle = Vector2.zero;

	private Vector2 _scrollPositionRight = Vector2.zero;

	private Vector2 _scrollPositionCraftLibrary = Vector2.zero;

	private Vector2 _scrollPositionCraftQueue = Vector2.zero;

	private List<IModification> _availableModifications = new List<IModification>();

	private List<IModification> _queuedModifications = new List<IModification>();

	private List<IInventoryItem> _itemsToScrap = new List<IInventoryItem>();

	private GUIStyle _titleStyle;

	private GUIStyle _titleGreenStyle;

	private GUIStyle _normalText;

	private GUIStyle _normalGreenStyle;

	private GUIStyle _normalRedStyle;

	private GUIStyle _normalGrayStyle;

	private IInventoryItem _selectedItemToMod;

	private Color itemShipUpgradeNormal = Color.gray;

	private Color itemShipUpgradeBroken = new Color(1f, 0.5f, 0.5f);

	private List<ICraftableItem> _queuedCraftables = new List<ICraftableItem>();

	private List<ICraftableItem> _craftablesToRemove = new List<ICraftableItem>();

	private GUIStyle boxStyle;

	private List<IModification> _modsToRemove = new List<IModification>();

	private IInventoryItem _mouseOverItem;

	private int guiAvailableScrapValue = -1;

	private string guiAvailableScrap = string.Empty;

	private int guiModScrapCostValue = -1;

	private int guiCraftScrapCostValue = -1;

	private string guiModScapCost = string.Empty;

	private string guiCraftScapCost = string.Empty;

	public ModificationsWindow()
	{
		_windowWidth = (float)Screen.width - 100f;
		_windowHeight = (float)Screen.height - 100f;
		_windowRect = new Rect(50f, 50f, _windowWidth, _windowHeight);
		_titleStyle = new GUIStyle();
		_titleStyle.fontSize = 16;
		_titleStyle.normal.textColor = Color.white;
		_titleStyle.fontStyle = FontStyle.Bold;
		_titleStyle.alignment = TextAnchor.MiddleCenter;
		_titleGreenStyle = new GUIStyle();
		_titleGreenStyle.fontSize = 16;
		_titleGreenStyle.normal.textColor = Color.green;
		_titleGreenStyle.fontStyle = FontStyle.Bold;
		_titleGreenStyle.alignment = TextAnchor.MiddleCenter;
		_normalGreenStyle = new GUIStyle();
		_normalGreenStyle.normal.textColor = Color.green;
		_normalGreenStyle.alignment = TextAnchor.LowerCenter;
		_normalRedStyle = new GUIStyle();
		_normalRedStyle.normal.textColor = Color.red;
		_normalRedStyle.alignment = TextAnchor.LowerCenter;
		_normalRedStyle = new GUIStyle();
		_normalRedStyle.normal.textColor = Color.red;
		_normalRedStyle.alignment = TextAnchor.LowerCenter;
		_normalText = new GUIStyle();
		_normalText.alignment = TextAnchor.LowerCenter;
		_normalText.normal.textColor = Color.white;
		boxStyle = new GUIStyle();
		boxStyle.normal.background = ResourceManager.SemiTransparantBackground70;
	}

	private void DrawBackgroundTexture()
	{
		GUI.Box(new Rect(2f, 17f, _windowWidth - 4f, _windowHeight - 20f), string.Empty, boxStyle);
	}

	public void ShowWindow()
	{
		_windowRect = CommonMethods.KeepWindowVisible(_windowRect);
		_windowRect = GUI.Window(32, _windowRect, DrawActualWindowContents, "Modifications");
	}

	private void DrawActualWindowContents(int id)
	{
		DrawBackgroundTexture();
		GUILayout.BeginVertical();
		GUILayout.Space(10f);
		if (_selectedItemToMod != null)
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Selected item: ", _titleStyle);
			GUILayout.Label("  " + _selectedItemToMod.Name, _titleGreenStyle);
			if (_selectedItemToMod.AppliedModifications != ModificationStorageIdEnum.None)
			{
				GUILayout.Label(" (has mods)", _titleStyle);
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.Label("Please select an inventory item to modify", _titleStyle);
		}
		GUILayout.Space(10f);
		GUILayout.BeginHorizontal();
		GUILayout.Space(15f);
		DrawLeftInventoryPane();
		GUILayout.Space(30f);
		DrawMiddleModsListPane();
		GUILayout.Space(30f);
		DrawRightModsQueuePane();
		GUILayout.Space(15f);
		GUILayout.EndHorizontal();
		DrawModificationButtons();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		DrawCraftableRecipeSection();
		GUILayout.Space(40f);
		DrawCraftQueueSection();
		GUILayout.Space(15f);
		GUILayout.EndHorizontal();
		DrawCraftingButtons();
		GUILayout.Space(15f);
		GUILayout.EndVertical();
	}

	private void SelectItemToModify(IInventoryItem item)
	{
		_selectedItemToMod = item;
		if (item != null)
		{
			IInventoryItem realItem = item;
			if (item is TempInventoryItem)
			{
				realItem = (item as TempInventoryItem).OriginalItem;
			}
			_availableModifications = ModificationsHelper.GetModificationsForType(realItem.GetType());
			_availableModifications.ForEach(delegate(IModification x)
			{
				x.SetTarget(realItem);
			});
		}
		else
		{
			_availableModifications = new List<IModification>();
		}
	}

	private void DrawModificationButtons()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		bool flag = _queuedModifications.Count == 0 && _itemsToScrap.Count == 0;
		if (flag)
		{
			GUI.enabled = false;
		}
		if (GUILayout.Button("Execute"))
		{
			bool flag2 = true;
			if (!GameSaveFile.Get("WS_STALE", false) && _itemsToScrap.Count > 0)
			{
				if (!GameSaveFile.Get("HNT_DISABLE", false) && GameSaveFile.Get("MISSIONS", 0) == 0 && !GameSaveFile.Get("WS_FP_SCRAP", false))
				{
					flag2 = false;
					DialogUI.Instance.ShowDialog("Warning!", "You are about to scrap equipment before your first mission.\r\n\r\nAre you sure you want to do this?\r\n\r\nThis warning will not appear again...", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.Yes)
						{
							Execute();
							ModificationUI.Instance.Refresh();
						}
					}, 1);
					GameSaveFile.Save("WS_FP_SCRAP", true);
				}
				GameSaveFile.Save("WS_STALE", true);
			}
			if (flag2)
			{
				Execute();
			}
		}
		if (GUILayout.Button("Clear"))
		{
			while (_queuedModifications.Count > 0)
			{
				_queuedModifications.RemoveAt(0);
			}
			while (_itemsToScrap.Count > 0)
			{
				_itemsToScrap.RemoveAt(0);
			}
		}
		if (flag)
		{
			GUI.enabled = true;
		}
		GUILayout.Space(2f);
		GUILayout.EndHorizontal();
	}

	private void Execute()
	{
		_modsToRemove.Clear();
		foreach (IModification queuedModification in _queuedModifications)
		{
			if (queuedModification.CanApplyModToTarget() && queuedModification.ScrapCost <= GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
			{
				int scrapCost = queuedModification.ScrapCost;
				queuedModification.ApplyModToTarget();
				_modsToRemove.Add(queuedModification);
				GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= scrapCost;
			}
		}
		_modsToRemove.ForEach(delegate(IModification x)
		{
			_queuedModifications.Remove(x);
		});
		ScrapItems();
	}

	private void DrawLeftInventoryPane()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Inventory", _titleStyle);
		GUILayout.Space(5f);
		int availableScrap = GetAvailableScrap();
		if (availableScrap != guiAvailableScrapValue)
		{
			if (availableScrap > 0)
			{
				guiAvailableScrap = "Scrap: " + GetAvailableScrap();
			}
			else
			{
				guiAvailableScrap = "Scrap: " + GetAvailableScrap();
			}
			guiAvailableScrapValue = availableScrap;
		}
		if (availableScrap > 0)
		{
			GUILayout.Label(guiAvailableScrap, _normalText);
		}
		else
		{
			GUILayout.Label(guiAvailableScrap, _normalRedStyle);
		}
		GUILayout.Space(5f);
		GUILayout.BeginHorizontal();
		GUILayout.Space(_windowWidth / 3f - 50f);
		GUILayout.EndHorizontal();
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		_scrollPositionLeft = GUILayout.BeginScrollView(_scrollPositionLeft);
		IInventoryItem mouseOverItem = null;
		IEnumerable<IInventoryItem> allItems = GetAllItems();
		foreach (IInventoryItem item in allItems)
		{
			IInventoryItem inventoryItem = item;
			if (item is TempInventoryItem)
			{
				inventoryItem = ((TempInventoryItem)item).OriginalItem;
			}
			bool flag = false;
			if (_itemsToScrap.Contains(item))
			{
				flag = true;
			}
			if (item is TempInventoryItem)
			{
				foreach (IInventoryItem item2 in _itemsToScrap)
				{
					if (item2 is TempInventoryItem && ((TempInventoryItem)item2).OriginalItem.Equals(((TempInventoryItem)item).OriginalItem))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				continue;
			}
			bool flag2 = ModificationsHelper.HasModificationsForType(inventoryItem.GetType());
			Color textColor = Color.white;
			if (inventoryItem is BaseDroneUpgrade)
			{
				textColor = DroneManager.GetBasicUpgradeStatusColor((BaseDroneUpgrade)inventoryItem);
			}
			else if (inventoryItem is BaseShipUpgrade)
			{
				textColor = itemShipUpgradeNormal;
				if (((BaseShipUpgrade)inventoryItem).BrokenState == BrokenStateEnum.Broken)
				{
					textColor = itemShipUpgradeBroken;
				}
			}
			else if (inventoryItem is NonVisualDrone)
			{
				NonVisualDrone nonVisualDrone = (NonVisualDrone)inventoryItem;
				if (nonVisualDrone.IsDead && nonVisualDrone.CurrentHitPoints <= 0f)
				{
					textColor = ((!nonVisualDrone.CanBeFullyRepaired) ? Color.red : Color.yellow);
				}
			}
			_normalText.normal.textColor = textColor;
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Scrap"))
			{
				_itemsToScrap.Add(item);
				if (_selectedItemToMod != null)
				{
					if (item is TempInventoryItem)
					{
						if (_selectedItemToMod is TempInventoryItem && ((TempInventoryItem)item).OriginalItem == ((TempInventoryItem)_selectedItemToMod).OriginalItem)
						{
							SelectItemToModify(null);
						}
					}
					else if (_selectedItemToMod == item)
					{
						SelectItemToModify(null);
					}
				}
			}
			if (Event.current.type == EventType.Repaint && IsMouseOver())
			{
				mouseOverItem = inventoryItem;
			}
			string text = inventoryItem.guiValue;
			int fontSize = _normalText.fontSize;
			if (_mouseOverItem == inventoryItem)
			{
				text = "--- " + text + " ---";
				_normalText.fontSize = 14;
			}
			else if (_selectedItemToMod == inventoryItem)
			{
				text = "---> " + text;
			}
			GUILayout.Label(text, _normalText, GUILayout.Width(220f));
			if (Event.current.type == EventType.Repaint && IsMouseOver())
			{
				mouseOverItem = inventoryItem;
			}
			_normalText.normal.textColor = Color.white;
			_normalText.fontSize = fontSize;
			GUILayout.FlexibleSpace();
			if (!flag2)
			{
				GUI.enabled = false;
			}
			if (GUILayout.Button("Select->"))
			{
				SelectItemToModify(item);
			}
			if (Event.current.type == EventType.Repaint && IsMouseOver())
			{
				mouseOverItem = inventoryItem;
			}
			if (!flag2)
			{
				GUI.enabled = true;
			}
			GUILayout.EndHorizontal();
		}
		if (Event.current.type == EventType.Repaint)
		{
			_mouseOverItem = mouseOverItem;
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}

	private void ScrapItems()
	{
		int count = _itemsToScrap.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			IInventoryItem inventoryItem = _itemsToScrap[num];
			if (inventoryItem == _selectedItemToMod)
			{
				SelectItemToModify(null);
			}
			if (inventoryItem is TempInventoryItem)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= ModificationsHelper.CalculateScrapValue(inventoryItem);
				TempInventoryItem tempInventoryItem = (TempInventoryItem)inventoryItem;
				if (tempInventoryItem.OriginalItem is BaseDroneUpgrade)
				{
					BaseDroneUpgrade upgrade = (BaseDroneUpgrade)tempInventoryItem.OriginalItem;
					IDrone drone = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u == upgrade));
					drone.RemoveDroneUpgrade(upgrade);
				}
				else if (tempInventoryItem.OriginalItem is BaseShipUpgrade)
				{
					GlobalSettings.GameState.ThePlayer.UninstallShipUpgrade((BaseShipUpgrade)tempInventoryItem.OriginalItem);
				}
				_itemsToScrap.RemoveAt(num);
			}
			else if (!(inventoryItem is IDrone))
			{
				GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= ModificationsHelper.CalculateScrapValue(inventoryItem);
				GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(inventoryItem);
				_itemsToScrap.RemoveAt(num);
			}
		}
		count = _itemsToScrap.Count;
		for (int num2 = 0; num2 < count; num2++)
		{
			IInventoryItem inventoryItem2 = _itemsToScrap[num2];
			GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= ModificationsHelper.CalculateScrapValue(inventoryItem2);
			if (inventoryItem2 == _selectedItemToMod)
			{
				SelectItemToModify(null);
			}
			if (!(inventoryItem2 is IDrone))
			{
				continue;
			}
			IDrone drone2 = (IDrone)inventoryItem2;
			GlobalSettings.GameState.ThePlayer.Drones.Remove(drone2);
			foreach (BaseDroneUpgrade upgrade2 in drone2.Upgrades)
			{
				if (upgrade2 != null)
				{
					GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(upgrade2);
				}
			}
			drone2.RemoveAllUpgrades();
			UniverseSaveFile.ClearGroup(((NonVisualDrone)drone2).GroupKey);
		}
		_itemsToScrap.Clear();
	}

	private void DrawMiddleModsListPane()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Available Modifications", _titleStyle);
		GUILayout.BeginHorizontal();
		GUILayout.Space(_windowWidth / 3f - 50f);
		GUILayout.EndHorizontal();
		GUILayout.Space(37f);
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		_scrollPositionMiddle = GUILayout.BeginScrollView(_scrollPositionMiddle);
		if (_selectedItemToMod == null || _availableModifications.Count == 0)
		{
			GUILayout.Space(15f);
			GUILayout.Label("(none)");
		}
		else
		{
			foreach (IModification availableModification in _availableModifications)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(availableModification.DisplayName + string.Format(" ({0} Scrap)", availableModification.ScrapCost), GUILayout.Width(220f));
				GUILayout.FlexibleSpace();
				bool flag = !availableModification.CanApplyModToTarget() || GetAvailableScrap() < availableModification.ScrapCost;
				if (flag)
				{
					GUI.enabled = false;
				}
				if (GUILayout.Button("Queue->"))
				{
					_queuedModifications.Add(availableModification.CopyModification());
				}
				if (flag)
				{
					GUI.enabled = true;
				}
				GUILayout.EndHorizontal();
			}
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}

	private void DrawRightModsQueuePane()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Queue", _titleStyle);
		GUILayout.Space(5f);
		int cost = 0;
		_queuedModifications.ForEach(delegate(IModification x)
		{
			cost -= x.ScrapCost;
		});
		_itemsToScrap.ForEach(delegate(IInventoryItem x)
		{
			cost -= ModificationsHelper.CalculateScrapValue(x);
		});
		if (guiModScrapCostValue != cost)
		{
			if (cost >= 0)
			{
				guiModScapCost = string.Format("Cost: {0} Scrap", cost);
			}
			else
			{
				guiModScapCost = string.Format("Gain: {0} Scrap", -cost);
			}
			guiModScrapCostValue = cost;
		}
		if (cost > GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
		{
			GUILayout.Label(guiModScapCost, _normalRedStyle);
		}
		else if (cost < 0)
		{
			GUILayout.Label(guiModScapCost, _normalGreenStyle);
		}
		else
		{
			GUILayout.Label(guiModScapCost, _normalText);
		}
		GUILayout.Space(5f);
		GUILayout.BeginHorizontal();
		GUILayout.Space(_windowWidth / 3f - 50f);
		GUILayout.EndHorizontal();
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		_scrollPositionRight = GUILayout.BeginScrollView(_scrollPositionRight);
		if (_queuedModifications.Count == 0 && _itemsToScrap.Count == 0)
		{
			GUILayout.Space(15f);
			GUILayout.Label("(none)");
		}
		else
		{
			_modsToRemove.Clear();
			foreach (IModification queuedModification in _queuedModifications)
			{
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label(queuedModification.TargetName);
				GUILayout.Label(" - ");
				GUILayout.Label(queuedModification.DisplayName);
				if (GUILayout.Button("X"))
				{
					_modsToRemove.Add(queuedModification);
				}
				GUILayout.EndHorizontal();
			}
			_modsToRemove.ForEach(delegate(IModification x)
			{
				_queuedModifications.Remove(x);
			});
			List<IInventoryItem> list = null;
			foreach (IInventoryItem item in _itemsToScrap)
			{
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label(item.guiValue);
				if (GUILayout.Button("X"))
				{
					if (list == null)
					{
						list = new List<IInventoryItem>();
					}
					list.Add(item);
				}
				GUILayout.EndHorizontal();
			}
			if (list != null)
			{
				list.ForEach(delegate(IInventoryItem x)
				{
					_itemsToScrap.Remove(x);
				});
			}
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}

	private IEnumerable<IInventoryItem> GetAllItems()
	{
		int c = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy.Count;
		for (int i = 0; i < c; i++)
		{
			yield return GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy[i];
		}
		c = GlobalSettings.GameState.ThePlayer.Drones.Count;
		for (int j = 0; j < c; j++)
		{
			IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[j];
			foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
			{
				if (upgrade != null)
				{
					yield return new TempInventoryItem(upgrade, drone.guiDroneNote);
				}
			}
		}
		c = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount;
		for (int k = 0; k < c; k++)
		{
			BaseShipUpgrade upgrade2 = (BaseShipUpgrade)GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[k];
			if (upgrade2 != null)
			{
				yield return new TempInventoryItem(upgrade2, " (installed)");
			}
		}
		c = GlobalSettings.GameState.ThePlayer.Drones.Count;
		for (int l = 0; l < c; l++)
		{
			IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones[l];
			yield return (IInventoryItem)drone2;
		}
	}

	private int GetAvailableScrap()
	{
		int num = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		int count = _queuedModifications.Count;
		for (int i = 0; i < count; i++)
		{
			num += _queuedModifications[i].ScrapCost;
		}
		count = _itemsToScrap.Count;
		for (int j = 0; j < count; j++)
		{
			num += ModificationsHelper.CalculateScrapValue(_itemsToScrap[j]);
		}
		count = _queuedCraftables.Count;
		for (int k = 0; k < count; k++)
		{
			num += _queuedCraftables[k].ScrapCost;
		}
		return num;
	}

	private void DrawCraftableRecipeSection()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Items To Assemble", _titleStyle);
		GUILayout.Space(15f);
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		GUILayout.BeginHorizontal();
		GUILayout.Space(65f);
		GUILayout.EndHorizontal();
		_scrollPositionCraftLibrary = GUILayout.BeginScrollView(_scrollPositionCraftLibrary);
		_craftablesToRemove.Clear();
		foreach (ICraftableItem allItem in CraftingHelper.GetAllItems())
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label(allItem.DisplayName);
			GUILayout.Label(allItem.guiScrap);
			GUILayout.Space(5f);
			bool flag = GetAvailableScrap() < allItem.ScrapCost;
			if (flag)
			{
				GUI.enabled = false;
			}
			if (GUILayout.Button("-->"))
			{
				_queuedCraftables.Add(allItem);
			}
			if (flag)
			{
				GUI.enabled = true;
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}

	private void DrawCraftQueueSection()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Assembly Queue", _titleStyle);
		GUILayout.Space(10f);
		int cost = 0;
		_queuedCraftables.ForEach(delegate(ICraftableItem x)
		{
			cost += x.ScrapCost;
		});
		if (guiModScrapCostValue != cost)
		{
			guiCraftScapCost = string.Format("Cost: {0} Scrap", cost);
			guiCraftScrapCostValue = cost;
		}
		if (cost > GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
		{
			GUILayout.Label(guiCraftScapCost, _normalRedStyle);
		}
		else
		{
			GUILayout.Label(guiCraftScapCost);
		}
		GUILayout.Space(5f);
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		GUILayout.BeginHorizontal();
		GUILayout.Space(65f);
		GUILayout.EndHorizontal();
		_scrollPositionCraftQueue = GUILayout.BeginScrollView(_scrollPositionCraftQueue);
		if (_queuedCraftables.Count == 0)
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("      (none)     ");
			GUILayout.Space(15f);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("                 ");
			GUILayout.Space(15f);
			GUILayout.EndHorizontal();
		}
		else
		{
			_craftablesToRemove.Clear();
			foreach (ICraftableItem queuedCraftable in _queuedCraftables)
			{
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("              ");
				GUILayout.Label(queuedCraftable.DisplayName);
				GUILayout.Space(5f);
				if (GUILayout.Button("X"))
				{
					_craftablesToRemove.Add(queuedCraftable);
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("                 ");
			GUILayout.Space(15f);
			GUILayout.EndHorizontal();
			_craftablesToRemove.ForEach(delegate(ICraftableItem x)
			{
				_queuedCraftables.Remove(x);
			});
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}

	private void DrawCraftingButtons()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		bool flag = _queuedCraftables.Count == 0;
		if (flag)
		{
			GUI.enabled = false;
		}
		if (GUILayout.Button("Assemble"))
		{
			_craftablesToRemove.Clear();
			foreach (ICraftableItem queuedCraftable in _queuedCraftables)
			{
				if (queuedCraftable.ScrapCost <= GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
				{
					GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(CraftingHelper.CraftItem(queuedCraftable));
					_craftablesToRemove.Add(queuedCraftable);
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap += queuedCraftable.ScrapCost;
				}
			}
			_craftablesToRemove.ForEach(delegate(ICraftableItem x)
			{
				_queuedCraftables.Remove(x);
			});
		}
		if (GUILayout.Button("Clear"))
		{
			while (_queuedCraftables.Count > 0)
			{
				_queuedCraftables.RemoveAt(0);
			}
		}
		if (flag)
		{
			GUI.enabled = true;
		}
		GUILayout.Space(2f);
		GUILayout.EndHorizontal();
	}

	private static bool IsMouseOver()
	{
		Rect lastRect = GUILayoutUtility.GetLastRect();
		Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(lastRect.x, lastRect.y));
		lastRect = new Rect(vector.x, vector.y, lastRect.width, lastRect.height);
		Vector2 point = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
		return lastRect.Contains(point);
	}
}
