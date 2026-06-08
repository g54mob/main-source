using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigShipUpgradeUi : MonoBehaviour
{
	private const int INVENTORY_ROW_COUNT = 9;

	private const int INVENTORY_COLUMN_COUNT = 1;

	private const int MAX_INVENTORY_SLOTS = 9;

	public static BoardingConfigShipUpgradeUi Instance;

	public UITextLabel tooltips;

	public UIBreakStatsItem breakStats;

	public Text topRightLabel;

	private bool _initialized;

	private int _currentRowInventory;

	private int _currentColInventory;

	private bool _cursorIsAtInventory;

	private BoardingConfigShipPanel _shipPanel;

	private BoardingConfigInventorySlot[,] _inventory = new BoardingConfigInventorySlot[9, 1];

	private bool _needsInitialData = true;

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	private void Awake()
	{
		Instance = this;
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		bool flag = false;
		Transform transform = base.transform.FindChild("PanelMain");
		if (transform != null)
		{
			Transform transform2 = transform.FindChild("ShipPanel");
			if (transform2 != null)
			{
				_shipPanel = transform2.gameObject.GetComponent<BoardingConfigShipPanel>();
			}
			Transform transform3 = transform.FindChild("InventoryPanel");
			if (transform3 != null)
			{
				transform3 = transform3.FindChild("Grid");
				if (transform3 != null)
				{
					flag = true;
					int num = 1;
					int num2 = 97;
					for (int i = 0; i < 1; i++)
					{
						for (int j = 0; j < 9; j++)
						{
							transform2 = transform3.FindChild("inventorySlot" + num++);
							if (transform2 != null)
							{
								_inventory[j, i] = transform2.gameObject.GetComponent<BoardingConfigInventorySlot>();
								_inventory[j, i].address.text = (char)num2 + ".";
							}
							if (_inventory[j, i] == null)
							{
								flag = false;
							}
							num2++;
						}
					}
				}
			}
		}
		if (_shipPanel == null || !flag)
		{
			Debug.LogError("BoardingConfigShipUpgradeUi did not resolve all fields properly");
		}
		if (tooltips != null)
		{
			tooltips.label.text = string.Empty;
		}
		_initialized = true;
	}

	public void SetLatestData()
	{
		_needsInitialData = false;
		_shipPanel.UpdateData();
		_shipPanel.ShowCursor(true);
		RefreshInventoryItems();
		_currentRowInventory = 0;
		_currentColInventory = 0;
		_cursorIsAtInventory = false;
		int num = GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots;
		List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
		int count = itemsCopy.Count;
		for (int i = 0; i < count; i++)
		{
			IInventoryItem inventoryItem = itemsCopy[i];
			if (inventoryItem != null && ((BaseShipUpgrade)inventoryItem).IsPermanentUpgrade)
			{
				num--;
				break;
			}
		}
		if (num == 1)
		{
			topRightLabel.enabled = true;
			topRightLabel.text = "[1] = UNINSTALL UPGRADE";
		}
		else if (num > 1)
		{
			topRightLabel.enabled = true;
			topRightLabel.text = "[1-" + GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots + "] = UNINSTALL UPGRADE";
		}
		else
		{
			topRightLabel.enabled = false;
		}
	}

	private void RefreshInventoryItems()
	{
		for (int i = 0; i < 1; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				_inventory[j, i].SetInventoryItem(null);
				_inventory[j, i].SetCursorHere(false);
			}
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy == null)
		{
			return;
		}
		foreach (IInventoryItem item in GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy)
		{
			if (item.InventoryType != InventoryTypeEnum.ShipUpgrade)
			{
				continue;
			}
			_inventory[num2, num3].SetInventoryItem(item);
			if (++num >= 9)
			{
				Debug.LogWarning("Too many inventory items to display in UI");
				break;
			}
			if (++num2 >= 9)
			{
				num2 = 0;
				if (++num3 >= 1)
				{
					Debug.LogWarning("Too many inventory items to display in UI (2)");
					break;
				}
			}
		}
	}

	private void Update()
	{
		if (_needsInitialData)
		{
			_needsInitialData = false;
			SetLatestData();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			IsVisible = false;
			SystemOverlayUI.Instance.IsVisible = true;
			SystemOverlayUI.Instance.RefreshDroneInfo();
			SystemOverlayUI.Instance.RefreshPlayerShipInfo();
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIExitMenu);
		}
		else
		{
			ProcessKeyPresses();
		}
	}

	private void ProcessKeyPresses()
	{
		if (!_cursorIsAtInventory)
		{
			if (Input.GetButtonDown("Right"))
			{
				_cursorIsAtInventory = true;
				_shipPanel.ShowCursor(false);
				_currentRowInventory = 0;
				_currentColInventory = 0;
				BoardingConfigInventorySlot boardingConfigInventorySlot = null;
				for (int i = 0; i < 1; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						if (_inventory[j, i].InventoryItem != null)
						{
							_currentRowInventory = j;
							_currentColInventory = i;
							boardingConfigInventorySlot = _inventory[j, i];
							break;
						}
					}
					if (boardingConfigInventorySlot != null)
					{
						break;
					}
				}
				if (boardingConfigInventorySlot == null)
				{
					boardingConfigInventorySlot = _inventory[0, 0];
				}
				if (boardingConfigInventorySlot != null)
				{
					boardingConfigInventorySlot.SetCursorHere(true);
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				}
			}
			else if (Input.GetButtonDown("Up"))
			{
				_shipPanel.ArrowUp();
			}
			else if (Input.GetButtonDown("Down"))
			{
				_shipPanel.ArrowDown();
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				if (_shipPanel.SelectedUpgrade != null && !_shipPanel.SelectedUpgrade.IsPermanentUpgrade)
				{
					RemoveCurrentUpgradeAndMoveToInventory();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
		}
		else if (Input.GetButtonDown("Left") && _currentColInventory == 0)
		{
			_cursorIsAtInventory = false;
			_shipPanel.ShowCursor(true);
			CurInvSlot().SetCursorHere(false);
			_currentRowInventory = 0;
			_currentColInventory = 0;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetButtonDown("Left"))
		{
			CurInvSlot().SetCursorHere(false);
			_currentColInventory--;
			CurInvSlot().SetCursorHere(true);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		else if (Input.GetButtonDown("Right"))
		{
			if (_currentColInventory < 0 && InvSlot(_currentRowInventory, _currentColInventory + 1).InventoryItem != null)
			{
				CurInvSlot().SetCursorHere(false);
				_currentColInventory++;
				CurInvSlot().SetCursorHere(true);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
		}
		else if (Input.GetButtonDown("Up"))
		{
			if (_currentRowInventory > 0)
			{
				CurInvSlot().SetCursorHere(false);
				_currentRowInventory--;
				CurInvSlot().SetCursorHere(true);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
		}
		else if (Input.GetButtonDown("Down"))
		{
			if (_currentColInventory < 8)
			{
				BoardingConfigInventorySlot boardingConfigInventorySlot2 = InvSlot(_currentRowInventory + 1, _currentColInventory);
				if (boardingConfigInventorySlot2 != null)
				{
					CurInvSlot().SetCursorHere(false);
					_currentRowInventory++;
					CurInvSlot().SetCursorHere(true);
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			IInventoryItem inventoryItem = CurInvSlot().InventoryItem;
			if (inventoryItem != null)
			{
				int shipUpgradeSlots = _shipPanel.ThePlayer.MyShip.ShipUpgradeSlots;
				if (_shipPanel.ThePlayer.MyShip.InstalledInventory.InventoryCount < shipUpgradeSlots && !_shipPanel.ThePlayer.HasShipUpgradeInstalled(((BaseShipUpgrade)inventoryItem).UpgradeType) && !inventoryItem.IsBroken)
				{
					RemoveCurrentItemFromInventoryAndInstall();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
		int newRow;
		int newCol;
		int zeroBasedIndex;
		if (ProcessAlphaShortcutKeysInventory(out newRow, out newCol))
		{
			if (newRow < 0 || newRow >= 9 || newCol < 0 || newCol >= 1)
			{
				return;
			}
			if (InvSlot(newRow, newCol).InventoryItem != null)
			{
				if (!_cursorIsAtInventory)
				{
					_shipPanel.ShowCursor(false);
					_cursorIsAtInventory = true;
				}
				else
				{
					CurInvSlot().SetCursorHere(false);
				}
				_currentRowInventory = newRow;
				_currentColInventory = newCol;
				CurInvSlot().SetCursorHere(true);
				if (_shipPanel.ThePlayer.MyShip.InstalledInventory.InventoryCount < _shipPanel.ThePlayer.MyShip.ShipUpgradeSlots && !_shipPanel.ThePlayer.HasShipUpgradeInstalled(((BaseShipUpgrade)CurInvSlot().InventoryItem).UpgradeType) && ((BaseShipUpgrade)CurInvSlot().InventoryItem).BrokenState == BrokenStateEnum.OK)
				{
					RemoveCurrentItemFromInventoryAndInstall();
				}
				else
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
		else if (CheckForKeyPressForNumericIndexSelect(out zeroBasedIndex) && zeroBasedIndex >= 0 && zeroBasedIndex < _shipPanel.ThePlayer.MyShip.ShipUpgradeSlots)
		{
			if (_cursorIsAtInventory)
			{
				_cursorIsAtInventory = false;
				_shipPanel.ShowCursor(true);
				CurInvSlot().SetCursorHere(false);
				_currentRowInventory = 0;
				_currentColInventory = 0;
			}
			_shipPanel.SetCursorAtSlot(zeroBasedIndex);
			if (_shipPanel.SelectedUpgrade != null && !_shipPanel.SelectedUpgrade.IsPermanentUpgrade)
			{
				RemoveCurrentUpgradeAndMoveToInventory();
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
	}

	private void RemoveCurrentItemFromInventoryAndInstall()
	{
		IInventoryItem inventoryItem = CurInvSlot().InventoryItem;
		if (!_shipPanel.InstallUpgradeAnySlot((BaseShipUpgrade)inventoryItem))
		{
			return;
		}
		GlobalSettings.GameState.ThePlayer.RemoveFromInventory(inventoryItem);
		_shipPanel.UpdateData();
		RefreshInventoryItems();
		if (CurInvSlot().InventoryItem == null)
		{
			bool flag = false;
			for (int num = 0; num >= 0; num--)
			{
				for (int num2 = 8; num2 >= 0; num2--)
				{
					if (InvSlot(num2, num).InventoryItem != null)
					{
						flag = true;
						CurInvSlot().SetCursorHere(false);
						_currentRowInventory = num2;
						_currentColInventory = num;
						CurInvSlot().SetCursorHere(true);
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				_cursorIsAtInventory = false;
				_shipPanel.ShowCursor(true);
				CurInvSlot().SetCursorHere(false);
				_currentRowInventory = 0;
				_currentColInventory = 0;
			}
		}
		else
		{
			CurInvSlot().SetCursorHere(true);
		}
		GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
	}

	private void RemoveCurrentUpgradeAndMoveToInventory()
	{
		BoardingConfigInventorySlot boardingConfigInventorySlot = null;
		for (int i = 0; i < 1; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (_inventory[j, i].InventoryItem == null)
				{
					boardingConfigInventorySlot = _inventory[j, i];
					break;
				}
			}
			if (boardingConfigInventorySlot != null)
			{
				break;
			}
		}
		if (boardingConfigInventorySlot != null)
		{
			BaseShipUpgrade selectedUpgrade = _shipPanel.SelectedUpgrade;
			_shipPanel.RemoveSelectedUpgrade();
			if (GlobalSettings.GameState.ThePlayer.AddToInventory(selectedUpgrade))
			{
				boardingConfigInventorySlot.SetInventoryItem(selectedUpgrade);
				_shipPanel.ShowCursor(true);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
			}
		}
	}

	private BoardingConfigInventorySlot CurInvSlot()
	{
		return InvSlot(_currentRowInventory, _currentColInventory);
	}

	private BoardingConfigInventorySlot InvSlot(int row, int col)
	{
		if (row < 0 || row >= 9 || col < 0 || col >= 1)
		{
			return null;
		}
		return _inventory[row, col];
	}

	private bool CheckForKeyPressForNumericIndexSelect(out int zeroBasedIndex)
	{
		bool result = false;
		zeroBasedIndex = -1;
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			result = true;
			zeroBasedIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			result = true;
			zeroBasedIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			result = true;
			zeroBasedIndex = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
			result = true;
			zeroBasedIndex = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
		{
			result = true;
			zeroBasedIndex = 4;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
		{
			result = true;
			zeroBasedIndex = 5;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
		{
			result = true;
			zeroBasedIndex = 6;
		}
		return result;
	}

	private bool ProcessAlphaShortcutKeysInventory(out int newRow, out int newCol)
	{
		bool result = false;
		newRow = _currentRowInventory;
		newCol = _currentColInventory;
		if (Input.GetKeyDown(KeyCode.A))
		{
			newRow = 0;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			newRow = 1;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			newRow = 2;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			newRow = 3;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			newRow = 4;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.F))
		{
			newRow = 5;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			newRow = 6;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			newRow = 7;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.I))
		{
			newRow = 8;
			newCol = 0;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.J))
		{
			newRow = 1;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			newRow = 2;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			newRow = 3;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			newRow = 4;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			newRow = 5;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			newRow = 6;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.P))
		{
			newRow = 7;
			newCol = 1;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			newRow = 0;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			newRow = 1;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			newRow = 2;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
			newRow = 3;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.U))
		{
			newRow = 4;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.V))
		{
			newRow = 5;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			newRow = 6;
			newCol = 2;
			result = true;
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			newRow = 7;
			newCol = 2;
			result = true;
		}
		return result;
	}
}
