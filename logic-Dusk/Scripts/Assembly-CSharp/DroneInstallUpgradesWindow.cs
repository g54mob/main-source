using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneInstallUpgradesWindow
{
	private const float MARGIN = 50f;

	public static DroneInstallUpgradesWindow Instance;

	public DroneSelectedDelegate OnSelectedDrone;

	private List<IDrone> _dronesList;

	private Rect _windowRect;

	private float _windowYPosPercentage = 28f;

	private float _windowWidth;

	private float _windowHeight;

	private IDrone _selectedDrone;

	private List<BaseDroneUpgrade> _upgradesToRemove = new List<BaseDroneUpgrade>();

	private string[] slotNameArray = new string[4] { "Slot 1", "Slot 2", "Slot 3", "Slot 4" };

	private GUIStyle boxStyle;

	public float TopDockingCoordinate { get; set; }

	public float BottomOfWindow
	{
		get
		{
			return _windowRect.y + _windowRect.height;
		}
	}

	public DroneInstallUpgradesWindow()
	{
		Instance = this;
		float num = (float)Screen.height * _windowYPosPercentage / 100f;
		_windowHeight = ((float)(Screen.height * 90) / 100f - num) * 0.55f;
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
	}

	public void ShowWindow(List<IDrone> drones)
	{
		_dronesList = drones;
		_windowRect = new Rect(_windowRect.x, TopDockingCoordinate, _windowRect.width, _windowRect.height);
		_windowRect = CommonMethods.KeepWindowVisible(_windowRect);
		_windowRect = GUI.Window(12, _windowRect, DrawActualWindow, "Drone Upgrades");
	}

	private IDrone GetDrone(int droneNumber)
	{
		IDrone result = null;
		if (_dronesList != null)
		{
			result = _dronesList.FirstOrDefault((IDrone x) => x.DroneNumber == droneNumber);
		}
		return result;
	}

	private void DrawActualWindow(int id)
	{
		DrawBackgroundTexture();
		GUILayout.BeginHorizontal();
		if (_selectedDrone != null)
		{
			GUILayout.BeginVertical();
			GUILayout.Space(1f);
			if (_selectedDrone.Upgrades.Count > 0)
			{
				int num = 1;
				_upgradesToRemove.Clear();
				int count = _selectedDrone.Upgrades.Count;
				for (int i = 0; i < count; i++)
				{
					BaseDroneUpgrade baseDroneUpgrade = _selectedDrone.Upgrades[i];
					if (num != 4)
					{
						string text = string.Empty;
						Color textColor = Color.white;
						if (baseDroneUpgrade != null)
						{
							text = baseDroneUpgrade.Name;
							textColor = DroneManager.GetBasicUpgradeStatusColor(baseDroneUpgrade);
						}
						GUILayout.BeginHorizontal();
						GUILayout.Label(slotNameArray[num]);
						num++;
						GUI.skin.box.normal.textColor = textColor;
						GUILayout.BeginHorizontal(text, GUI.skin.box);
						GUI.skin.box.normal.textColor = Color.white;
						GUILayout.Space(10f);
						GUILayout.Label(" ");
						GUILayout.EndHorizontal();
						if (baseDroneUpgrade == null)
						{
							GUI.enabled = false;
						}
						if (GUILayout.Button("Remove -->"))
						{
							_upgradesToRemove.Add(baseDroneUpgrade);
						}
						if (baseDroneUpgrade == null)
						{
							GUI.enabled = true;
						}
						GUILayout.EndHorizontal();
					}
				}
				count = _upgradesToRemove.Count;
				for (int j = 0; j < count; j++)
				{
					RemoveUpgradeFromSlot(_selectedDrone, _upgradesToRemove[j]);
				}
			}
			else
			{
				GUILayout.Label("     (none)");
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndHorizontal();
	}

	private void RemoveUpgradeFromSlot(IDrone drone, BaseDroneUpgrade upgrade)
	{
		if (GlobalSettings.GameState.ThePlayer.Inventory.InventoryCount < GlobalSettings.GameState.ThePlayer.Inventory.MaxInventorySpace)
		{
			if (GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade))
			{
				drone.RemoveDroneUpgrade(upgrade);
			}
		}
		else
		{
			DialogUI.Instance.ShowDialog("No Space in Inventory", string.Format("You can only hold {0} items in your ship's inventory.  Discard some items to make room.", GlobalSettings.GameState.ThePlayer.Inventory.MaxInventorySpace));
		}
	}

	public void UpdateDroneList(List<IDrone> dronesList)
	{
		_dronesList = dronesList;
		if (_dronesList != null && _dronesList.Count != 0 && _selectedDrone == null)
		{
			_selectedDrone = _dronesList.OrderBy((IDrone x) => x.DroneNumber).FirstOrDefault();
		}
	}

	public bool InstallUpgradeOnCurrentDrone(IInventoryItem item)
	{
		if (!(item is BaseDroneUpgrade))
		{
			return false;
		}
		BaseDroneUpgrade upgrade = (BaseDroneUpgrade)item;
		if (_selectedDrone != null)
		{
			return _selectedDrone.AddDroneUpgrade(upgrade);
		}
		Debug.Log("attempted to install upgrade when no drone is selected");
		return false;
	}

	public void SelectDrone(int droneNumber)
	{
		_selectedDrone = _dronesList.FirstOrDefault((IDrone x) => x.DroneNumber == droneNumber);
	}

	private string GetDroneNameFromNumber(int droneNumber)
	{
		return "Drone " + droneNumber;
	}
}
