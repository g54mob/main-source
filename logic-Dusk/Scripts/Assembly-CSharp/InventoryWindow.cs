using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow
{
	private const float MARGIN = 50f;

	private const float DRAG_START_DISTANCE = 30f;

	private int _myWindowId = 10;

	private Rect _windowRect;

	private float _windowYPosPercentage = 28f;

	private Vector2 _scrollPosition = default(Vector2);

	private float _windowWidth;

	private float _windowHeight;

	private List<IInventoryItem> _itemsToDelete = new List<IInventoryItem>(100);

	private List<IInventoryItem> _itemsToScrap = new List<IInventoryItem>(100);

	private Color itemShipUpgradeNormal = Color.gray;

	private Color itemShipUpgradeBroken = new Color(1f, 0.5f, 0.5f);

	private Dictionary<IInventoryItem, Rect> _itemDrawRects = new Dictionary<IInventoryItem, Rect>();

	private bool _isOnLeft;

	private GUIStyle boxStyle;

	private GUIStyle _inventoryTextGuiStyle = new GUIStyle();

	private Vector2 _startDragPosition = Vector2.zero;

	private bool _isPreparedToDrag;

	private IInventoryItem _dropTarget;

	private IInventoryItem _sourceItemToReport;

	private IInventoryItem _targetItemToReport;

	private IInventoryItem _itemToSell;

	public InventoryModeEnum InventoryMode { get; set; }

	public float TopDockingCoordinate { get; set; }

	public int filterToggle { get; private set; }

	public float WindowWidth
	{
		get
		{
			return _windowWidth;
		}
	}

	public bool IsShipUpgradeOnly { get; set; }

	public IInventory inventory { get; private set; }

	public bool AllowDragDrop { get; set; }

	public event InventoryItemSelectedDelegate InstallInventoryItem;

	public event InventoryItemSelectedDelegate SellForRationsInventoryItem;

	public event InventoryItemDroppedDelegate DroppedItem;

	public event FuelSoldDelegate PropulsionFuel;

	public event FuelSoldDelegate JumpFuel;

	public InventoryWindow(IInventory inventory)
	{
		AllowDragDrop = true;
		SetInventory(inventory);
		float num = (float)Screen.height * _windowYPosPercentage / 100f;
		_windowHeight = (float)(Screen.height * 90) / 100f - num;
		SetWindowPosition(Screen.width / 2, num);
		InventoryMode = InventoryModeEnum.None;
		boxStyle = new GUIStyle();
		boxStyle.normal.background = ResourceManager.SemiTransparantBackground70;
	}

	public void PositionLeft()
	{
		_isOnLeft = true;
		SetWindowPosition((float)(Screen.width / 2) - WindowWidth - 2f);
	}

	public void PositionRight()
	{
		_isOnLeft = false;
		SetWindowPosition(Screen.width / 2);
	}

	public void SetInventory(IInventory inventory)
	{
		this.inventory = inventory;
	}

	public void OverrideWindowId(int id)
	{
		_myWindowId = id;
	}

	private void DrawBackgroundTexture()
	{
		GUI.Box(new Rect(2f, 17f, _windowWidth - 4f, _windowHeight - 20f), string.Empty, boxStyle);
	}

	public void SetWindowPosition(float x)
	{
		SetWindowPosition(x, _windowRect.y);
	}

	public void SetWindowPosition(float x, float y)
	{
		_windowWidth = (float)(Screen.width / 2) - 50f;
		_windowRect = new Rect(x, y, _windowWidth, _windowHeight);
	}

	public void ShowWindow(string title)
	{
		_windowRect = new Rect(_windowRect.x, TopDockingCoordinate, _windowRect.width, _windowRect.height);
		_windowRect = CommonMethods.KeepWindowVisible(_windowRect);
		_windowRect = GUI.Window(_myWindowId, _windowRect, DrawActualWindow, title);
	}

	public void ShowWindow()
	{
		ShowWindow("Inventory");
	}

	private void DrawActualWindow(int id)
	{
		if (Event.current.type == EventType.Repaint)
		{
			_itemDrawRects.Clear();
		}
		else
		{
			_dropTarget = null;
		}
		if (GlobalSettings.InventoryDragInfo.IsDragging && GlobalSettings.InventoryDragInfo.SourceWindow != this)
		{
			Vector2 point = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
			foreach (KeyValuePair<IInventoryItem, Rect> itemDrawRect in _itemDrawRects)
			{
				if (itemDrawRect.Value.Contains(point))
				{
					_dropTarget = itemDrawRect.Key;
					break;
				}
			}
			if (Event.current.type == EventType.MouseUp)
			{
				_sourceItemToReport = GlobalSettings.InventoryDragInfo.ItemBeingDragged;
				_targetItemToReport = _dropTarget;
				GlobalSettings.InventoryDragInfo.IsDragging = false;
				GlobalSettings.InventoryDragInfo.SourceWindow = null;
				GlobalSettings.InventoryDragInfo.ItemBeingDragged = null;
				_startDragPosition = Vector2.zero;
			}
		}
		DrawBackgroundTexture();
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.Label(inventory.guiScrap);
		GUILayout.EndHorizontal();
		GUILayout.Space(6f);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		if (_isOnLeft)
		{
			GUILayout.FlexibleSpace();
			GUILayout.Label("Prop Fuel (reserve): " + inventory.PropulsionFuelReserve);
			if (GUILayout.Button(">") && inventory.PropulsionFuelReserve > 0 && this.PropulsionFuel != null)
			{
				this.PropulsionFuel(1);
			}
		}
		else
		{
			if (GUILayout.Button("<") && inventory.PropulsionFuelReserve > 0 && this.PropulsionFuel != null)
			{
				this.PropulsionFuel(1);
			}
			GUILayout.Label("Prop Fuel (reserve): " + inventory.PropulsionFuelReserve);
		}
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		if (_isOnLeft)
		{
			GUILayout.Label("Jump Fuel: " + inventory.JumpFuel);
			if (GUILayout.Button(">") && inventory.JumpFuel > 0 && this.JumpFuel != null)
			{
				this.JumpFuel(1);
			}
		}
		else
		{
			if (GUILayout.Button("<") && inventory.JumpFuel > 0 && this.JumpFuel != null)
			{
				this.JumpFuel(1);
			}
			GUILayout.Label("Jump Fuel: " + inventory.JumpFuel);
			GUILayout.FlexibleSpace();
		}
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.Space(6f);
		GUILayout.BeginVertical(string.Empty, GUI.skin.box);
		GUILayout.BeginHorizontal();
		GUILayout.Space(350f);
		if (GUILayout.Toggle(filterToggle == 0, "All"))
		{
			filterToggle = 0;
		}
		if (GUILayout.Toggle(filterToggle == 1, "Drone"))
		{
			filterToggle = 1;
		}
		if (GUILayout.Toggle(filterToggle == 2, "Ship"))
		{
			filterToggle = 2;
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(10f);
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		int num = 0;
		if (inventory.InventoryCount > 0)
		{
			_itemsToDelete.Clear();
			_itemsToScrap.Clear();
			foreach (IInventoryItem item in inventory.ItemsCopy)
			{
				if (item == null || (filterToggle != 0 && ((filterToggle == 1 && item.InventoryType != InventoryTypeEnum.DroneUpgrade) || (filterToggle == 2 && item.InventoryType != InventoryTypeEnum.ShipUpgrade))))
				{
					continue;
				}
				num++;
				GUILayout.BeginHorizontal();
				if (InventoryMode == InventoryModeEnum.ItemInstallMode)
				{
					if (IsShipUpgradeOnly && item.InventoryType != InventoryTypeEnum.ShipUpgrade)
					{
						GUI.enabled = false;
					}
					else
					{
						GUI.enabled = true;
					}
					if (GUILayout.Button("<-- Install") && this.InstallInventoryItem != null && this.InstallInventoryItem(item))
					{
						_itemsToDelete.Add(item);
					}
				}
				else if (InventoryMode == InventoryModeEnum.TradeModeAuto && GUILayout.Button("<-- Buy With Scrap"))
				{
					_itemToSell = item;
				}
				_inventoryTextGuiStyle.normal.textColor = Color.white;
				string text = item.guiValue;
				if (item is BaseDroneUpgrade)
				{
					_inventoryTextGuiStyle.normal.textColor = DroneManager.GetBasicUpgradeStatusColor((BaseDroneUpgrade)item);
				}
				else if (item is BaseShipUpgrade)
				{
					_inventoryTextGuiStyle.normal.textColor = itemShipUpgradeNormal;
					if (((BaseShipUpgrade)item).BrokenState == BrokenStateEnum.Broken)
					{
						_inventoryTextGuiStyle.normal.textColor = itemShipUpgradeBroken;
					}
				}
				if (item == _dropTarget)
				{
					_inventoryTextGuiStyle.normal.textColor = Color.cyan;
					text += " <---";
				}
				GUILayout.Label(text, _inventoryTextGuiStyle, GUILayout.Width(290f));
				if (Event.current.type == EventType.Repaint)
				{
					Rect lastRect = GUILayoutUtility.GetLastRect();
					Vector2 vector = GUIUtility.GUIToScreenPoint(new Vector2(lastRect.x, lastRect.y));
					lastRect = new Rect(vector.x, vector.y, lastRect.width, lastRect.height);
					_itemDrawRects[item] = lastRect;
				}
				string guiInventoryType = item.guiInventoryType;
				GUILayout.Label(guiInventoryType, _inventoryTextGuiStyle);
				GUILayout.FlexibleSpace();
				if (InventoryMode != InventoryModeEnum.TradeModeAuto)
				{
					if (_isOnLeft && InventoryMode == InventoryModeEnum.TradeMode && GUILayout.Button("Trade For Scrap -->"))
					{
						_itemToSell = item;
					}
					else if (!_isOnLeft && GUILayout.Button("Scrap"))
					{
						_itemsToScrap.Add(item);
					}
				}
				GUILayout.EndHorizontal();
			}
			_itemsToDelete.ForEach(delegate(IInventoryItem x)
			{
				inventory.RemoveInventoryItem(x);
			});
			foreach (IInventoryItem item2 in _itemsToScrap)
			{
				inventory.Scrap += ModificationsHelper.CalculateScrapValue(item2);
				inventory.RemoveInventoryItem(item2);
			}
		}
		if (num == 0)
		{
			GUILayout.Label("      (empty)");
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.Space(5f);
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(inventory.guiStatus);
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		if (AllowDragDrop && !GlobalSettings.InventoryDragInfo.IsDragging && !_isPreparedToDrag && Event.current.type == EventType.MouseDown)
		{
			_startDragPosition = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);
			Vector2 point2 = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
			{
				foreach (KeyValuePair<IInventoryItem, Rect> itemDrawRect2 in _itemDrawRects)
				{
					if (itemDrawRect2.Value.Contains(point2))
					{
						GlobalSettings.InventoryDragInfo.SourceWindow = this;
						GlobalSettings.InventoryDragInfo.ItemBeingDragged = itemDrawRect2.Key;
						_isPreparedToDrag = true;
						break;
					}
				}
				return;
			}
		}
		if (_isPreparedToDrag && Event.current.type == EventType.MouseDrag && !GlobalSettings.InventoryDragInfo.IsDragging && Vector2.Distance(_startDragPosition, Event.current.mousePosition) > 30f)
		{
			GlobalSettings.InventoryDragInfo.IsDragging = true;
			_isPreparedToDrag = false;
		}
	}

	public void Update()
	{
		if (_sourceItemToReport != null && _targetItemToReport != null)
		{
			if (this.DroppedItem != null)
			{
				this.DroppedItem(_sourceItemToReport, _targetItemToReport);
			}
			_sourceItemToReport = null;
			_targetItemToReport = null;
		}
		if (_itemToSell != null)
		{
			if (this.SellForRationsInventoryItem != null)
			{
				this.SellForRationsInventoryItem(_itemToSell);
			}
			_itemToSell = null;
		}
	}
}
