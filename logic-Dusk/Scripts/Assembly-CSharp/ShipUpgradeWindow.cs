using System.Collections.Generic;
using UnityEngine;

public class ShipUpgradeWindow
{
	private const float MARGIN = 50f;

	private Rect _windowRect;

	private Rect _windowRectLarge;

	private Rect _windowRectSmall;

	private float _windowYPosPercentage = 28f;

	private float _windowWidth;

	private float _windowHeight;

	private List<BaseShipUpgrade> _upgradesToRemove = new List<BaseShipUpgrade>();

	private GUIStyle boxStyle;

	private string[] slotNameArray = new string[4] { "Slot 1", "Slot 2", "Slot 3", "Slot 4" };

	public float TopDockingCoordinate { get; set; }

	public float BottomOfWindow
	{
		get
		{
			return _windowRect.y + _windowRect.height;
		}
	}

	public ShipUpgradeWindow()
	{
		float num = (float)Screen.height * _windowYPosPercentage / 100f;
		_windowHeight = ((float)(Screen.height * 90) / 100f - num) * 1.8f;
		SetWindowPosition(50f, num);
		boxStyle = new GUIStyle();
		boxStyle.normal.background = ResourceManager.SemiTransparantBackground70;
	}

	private void DrawBackgroundTexture()
	{
		GUI.Box(new Rect(2f, 17f, _windowWidth - 4f, _windowHeight - 20f), string.Empty, boxStyle);
	}

	public void SetWindowPosition(float x, float y)
	{
		_windowWidth = (float)(Screen.width / 2) - 50f;
		_windowRect = new Rect(x, y, _windowWidth, _windowHeight);
		_windowRectLarge = _windowRect;
		_windowRectSmall = _windowRect;
		_windowRectSmall.height *= 0.25f;
	}

	public void ShowWindow(bool smallView)
	{
		if (smallView)
		{
			_windowRect = new Rect(_windowRect.x, TopDockingCoordinate, _windowRectSmall.width, _windowRectSmall.height);
		}
		else
		{
			_windowRect = new Rect(_windowRect.x, TopDockingCoordinate, _windowRectLarge.width, _windowRectLarge.height);
		}
		_windowRect = CommonMethods.KeepWindowVisible(_windowRect);
		_windowRect = GUI.Window(28, _windowRect, DrawActualWindow, "Ship Upgrades");
	}

	private void DrawActualWindow(int id)
	{
		DrawBackgroundTexture();
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		GUILayout.Space(1f);
		_upgradesToRemove.Clear();
		for (int i = 1; i <= GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots; i++)
		{
			BaseShipUpgrade baseShipUpgrade = null;
			if (i <= GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount)
			{
				baseShipUpgrade = (BaseShipUpgrade)GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[i - 1];
			}
			string text = string.Empty;
			Color textColor = Color.white;
			if (baseShipUpgrade != null)
			{
				text = baseShipUpgrade.Name;
				if (baseShipUpgrade.BrokenState == BrokenStateEnum.Broken)
				{
					textColor = Color.red;
				}
			}
			GUILayout.BeginHorizontal();
			GUILayout.Label(slotNameArray[i - 1]);
			GUI.skin.box.normal.textColor = textColor;
			GUILayout.BeginHorizontal(text, GUI.skin.box);
			GUI.skin.box.normal.textColor = Color.white;
			GUILayout.Space(20f);
			GUILayout.Label(" ");
			GUILayout.EndHorizontal();
			if (baseShipUpgrade == null)
			{
				GUI.enabled = false;
			}
			if (GUILayout.Button("Remove -->"))
			{
				_upgradesToRemove.Add(baseShipUpgrade);
			}
			if (baseShipUpgrade == null)
			{
				GUI.enabled = true;
			}
			GUILayout.EndHorizontal();
		}
		if (_upgradesToRemove.Count > 0)
		{
			_upgradesToRemove.ForEach(delegate(BaseShipUpgrade x)
			{
				RemoveUpgradeFromSlot(x);
			});
		}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}

	private void RemoveUpgradeFromSlot(BaseShipUpgrade upgrade)
	{
		if (GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade))
		{
			GlobalSettings.GameState.ThePlayer.UninstallShipUpgrade(upgrade);
		}
		else
		{
			DialogUI.Instance.ShowDialog("No Space in Inventory", string.Format("You can only hold {0} items in your ship's inventory.  Discard some items to make room.", GlobalSettings.GameState.ThePlayer.Inventory.MaxInventorySpace));
		}
	}

	public bool InstallUpgrade(IInventoryItem item)
	{
		if (!(item is BaseShipUpgrade))
		{
			return false;
		}
		return GlobalSettings.GameState.ThePlayer.InstallShipUpgrade((BaseShipUpgrade)item);
	}
}
