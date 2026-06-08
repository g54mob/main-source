using UnityEngine;

public class StoreWindow
{
	private const float MARGIN = 50f;

	private Rect _windowRect;

	private float _windowYPosPercentage = 28f;

	private Vector2 _scrollPosition = default(Vector2);

	private float _windowWidth;

	private float _windowHeight;

	public float TopDockingCoordinate { get; set; }

	public StoreWindow()
	{
		float num = (float)Screen.height * _windowYPosPercentage / 100f;
		_windowHeight = (float)(Screen.height * 90) / 100f - num;
		SetWindowPosition(50f, num);
	}

	private void DrawBackgroundTexture()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.normal.background = ResourceManager.SemiTransparantBackground70;
		GUI.Box(new Rect(2f, 17f, _windowWidth - 4f, _windowHeight - 20f), string.Empty, gUIStyle);
	}

	public void SetWindowPosition(float x, float y)
	{
		_windowWidth = (float)(Screen.width / 2) - 50f;
		_windowRect = new Rect(x, y, _windowWidth, _windowHeight);
	}

	public void ShowWindow()
	{
		_windowRect = new Rect(_windowRect.x, TopDockingCoordinate, _windowRect.width, _windowRect.height);
		_windowRect = CommonMethods.KeepWindowVisible(_windowRect);
		_windowRect = GUI.Window(11, _windowRect, DrawActualWindow, "Upgrades Store");
	}

	private void DrawActualWindow(int id)
	{
		DrawBackgroundTexture();
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical("Categories", GUI.skin.box);
		GUILayout.BeginHorizontal();
		GUILayout.Space(100f);
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.Space(20f);
		GUILayout.BeginVertical("Items for Purchase", GUI.skin.box);
		GUILayout.BeginHorizontal();
		GUILayout.Space(45f);
		GUILayout.Label("Name");
		GUILayout.FlexibleSpace();
		GUILayout.Label("Cost");
		GUILayout.EndHorizontal();
		GUILayout.Box(string.Empty);
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		foreach (DroneUpgradeDefinition upgradeDefinition in DroneUpgradeFactory.UpgradeDefinitions)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(upgradeDefinition.Name);
			GUILayout.FlexibleSpace();
			GUILayout.Label(upgradeDefinition.Cost.ToString());
			bool flag = CanBuyItem(upgradeDefinition);
			if (!flag)
			{
				GUI.enabled = false;
			}
			if (GUILayout.Button("Buy -->"))
			{
				PurchaseItem(upgradeDefinition);
			}
			if (!flag)
			{
				GUI.enabled = true;
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}

	private void PurchaseItem(DroneUpgradeDefinition upgradeDefinition)
	{
		BaseDroneUpgrade item = DroneUpgradeFactory.CreateUpgradeInstance(upgradeDefinition.Type);
		GlobalSettings.GameState.ThePlayer.AddToInventory(item);
	}

	private bool CanBuyItem(DroneUpgradeDefinition upgradeDefinition)
	{
		return GlobalSettings.GameState.ThePlayer.Inventory.InventoryCount < GlobalSettings.GameState.ThePlayer.Inventory.MaxInventorySpace;
	}
}
