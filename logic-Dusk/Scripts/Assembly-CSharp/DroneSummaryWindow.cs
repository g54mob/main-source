using System.Collections.Generic;
using UnityEngine;

public class DroneSummaryWindow
{
	public const float HEIGHT_WINDOW = 140f;

	public const float HEIGHT_WINDOW_VERTICAL = 85f;

	public const float MARGIN = 50f;

	public const float MARGIN_VERTICAL = 2f;

	private const float DRAG_START_DISTANCE = 30f;

	public bool AllowDragDrop;

	private List<IDrone> _dronesList;

	private Rect _startingWindowRect;

	private Rect bottomDroneWindowRect;

	private Rect nextWindowRect;

	private float _windowYPosPercentage = 10f;

	private Vector2 _scrollPosition = default(Vector2);

	private float _windowWidth = 100f;

	private int _selectedDroneNumber = -1;

	private float[] _warningTimerAllDrones = new float[7];

	private readonly float WARNING_DISPLAY_DURATION = 2.5f;

	private Texture _warningImage;

	private GUIStyle[] _droneWindowStyles = new GUIStyle[7];

	private GUIStyle guiStyle;

	private string[] droneSlotNameArray = new string[4] { "Deploy Slot 1", "Deploy Slot 2", "Deploy Slot 3", "Deploy Slot 4" };

	private string[] droneNameArray = new string[8] { "1 - Drone", "2 - Drone", "3 - Drone", "4 - Drone", "5 - Drone", "6 - Drone", "7 - Drone", "8 - Drone" };

	private string[] slotNumberArray = new string[4] { "1:", "2:", "3:", "4:" };

	private string[] droneNameBaseArray = new string[8] { "1 - ", "2 - ", "3 - ", "4 - ", "5 - ", "6 - ", "7 - ", "8 - " };

	private bool _isPreparedToDrag;

	private bool _isDraggingDroneWindow;

	private int _droneIndexBeingDragged = -1;

	private Vector2 _startDragPosition = Vector2.zero;

	public bool recordedRectsForMouseHint;

	public float BottomOfWindow
	{
		get
		{
			return _startingWindowRect.y + _startingWindowRect.height;
		}
	}

	public float BottomOfAllWindows
	{
		get
		{
			return bottomDroneWindowRect.y + bottomDroneWindowRect.height;
		}
	}

	public float LeftOfVerticalWindow
	{
		get
		{
			return 2f + _windowWidth;
		}
	}

	public bool UseVerticalLayout { get; private set; }

	public event DroneSelectedDelegate OnDroneSelected;

	public event DroneSelectedDelegate OnDroneDropped;

	public DroneSummaryWindow(bool verticalLayout)
	{
		UseVerticalLayout = verticalLayout;
		float y = (float)Screen.height * _windowYPosPercentage / 100f;
		SetWindowPosition(50f, y);
		_warningImage = ResourceManager.LoadAsset<Texture>("warning-sign-md");
		for (int i = 0; i < _warningTimerAllDrones.Length; i++)
		{
			_warningTimerAllDrones[i] = 0f;
		}
		guiStyle = new GUIStyle();
		guiStyle.wordWrap = false;
	}

	public void SetWindowPosition(float x, float y)
	{
		SetWindowPosition(x, y, 140f);
	}

	public void SetWindowPosition(float x, float y, float h)
	{
		if (!UseVerticalLayout)
		{
			_windowWidth = ((float)Screen.width - 100f) / 7f;
		}
		else
		{
			_windowWidth = 425f;
		}
		_startingWindowRect = new Rect(x, y, _windowWidth, h);
	}

	private void DrawBackgroundTexture()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.normal.background = ResourceManager.SemiTransparantBackground70;
		GUI.Box(new Rect(2f, 17f, _startingWindowRect.width - 4f, _startingWindowRect.height - 20f), string.Empty, gUIStyle);
	}

	private void DrawDragDropTargetTexture(Rect drawRect)
	{
		GUIStyle style = new GUIStyle();
		GUI.Box(drawRect, string.Empty, style);
	}

	public void ShowWindow(List<IDrone> drones)
	{
		_dronesList = drones;
		if (_droneWindowStyles[0] == null)
		{
			for (int i = 0; i < _droneWindowStyles.Length; i++)
			{
				_droneWindowStyles[i] = new GUIStyle(GUI.skin.window);
			}
		}
		nextWindowRect = _startingWindowRect;
		bottomDroneWindowRect = _startingWindowRect;
		bool flag = false;
		bool flag2 = false;
		if (AllowDragDrop && !_isDraggingDroneWindow && !_isPreparedToDrag && Event.current.type == EventType.MouseDown)
		{
			flag = true;
			_startDragPosition = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);
		}
		else if (_isPreparedToDrag && Event.current.type == EventType.MouseDrag)
		{
			if (!_isDraggingDroneWindow && Vector2.Distance(_startDragPosition, Event.current.mousePosition) > 30f)
			{
				_isDraggingDroneWindow = true;
			}
		}
		else if (Event.current.type == EventType.MouseUp)
		{
			if (_isDraggingDroneWindow)
			{
				flag2 = true;
			}
			else
			{
				_droneIndexBeingDragged = -1;
			}
			_isPreparedToDrag = false;
			_isDraggingDroneWindow = false;
			_startDragPosition = Vector2.zero;
		}
		for (int j = 0; j < 7 && _droneWindowStyles[j] != null; j++)
		{
			if (flag2 && _droneIndexBeingDragged != j && nextWindowRect.Contains(Event.current.mousePosition))
			{
				IDrone drone = FirstOrDefaultLowMem(_dronesList, _droneIndexBeingDragged + 1);
				if (drone != null)
				{
					IDrone drone2 = FirstOrDefaultLowMem(_dronesList, j + 1);
					drone.DroneNumber = j + 1;
					if (drone2 != null)
					{
						drone2.DroneNumber = _droneIndexBeingDragged + 1;
					}
					if (this.OnDroneDropped != null)
					{
						this.OnDroneDropped(j + 1);
						GUI.FocusWindow(j + 1);
					}
				}
				_droneIndexBeingDragged = -1;
			}
			else if (_isDraggingDroneWindow && nextWindowRect.Contains(Event.current.mousePosition))
			{
				DrawDragDropTargetTexture(new Rect(nextWindowRect.x + 3f, nextWindowRect.y + 3f, nextWindowRect.width - 6f, nextWindowRect.height - 6f));
			}
			IDrone drone3 = FirstOrDefaultLowMem(_dronesList, j + 1);
			_droneWindowStyles[j].normal.textColor = Color.white;
			string text = string.Empty;
			if (drone3 != null)
			{
				text = droneNameBaseArray[j] + drone3.DroneName;
				if (drone3.IsDead && !drone3.CanBeFullyRepaired)
				{
					_droneWindowStyles[j].normal.textColor = Color.red;
					text += string.Format(" ({0})", "Destroyed");
				}
				else if (drone3.IsDead && drone3.CanBeFullyRepaired)
				{
					_droneWindowStyles[j].normal.textColor = GlobalSettings.Constants.ORANGE;
					text += string.Format(" ({0})", "Disabled");
				}
				else if (!drone3.IsUnderPlayerControl)
				{
					_droneWindowStyles[j].normal.textColor = Color.green;
					text = string.Format("*{0}*", text);
				}
				bottomDroneWindowRect = nextWindowRect;
			}
			else if (drone3 == null)
			{
				text = droneNameArray[j];
				_droneWindowStyles[j].normal.textColor = Color.gray;
			}
			bool flag3 = drone3 != null;
			if (flag3 && !GlobalSettings.cheatMode)
			{
				flag3 = (drone3.IsVisible || drone3.IsInvisibleDueToToggle) && !drone3.InterfaceDisconnected;
			}
			if (!UseVerticalLayout && j < 4)
			{
				GUI.Label(new Rect(nextWindowRect.x + 30f, nextWindowRect.y - 20f, nextWindowRect.width - 30f, 20f), droneSlotNameArray[j]);
			}
			if (flag3)
			{
				if (flag && nextWindowRect.Contains(Event.current.mousePosition))
				{
					_droneIndexBeingDragged = j;
					_isPreparedToDrag = true;
				}
				Rect clientRect = nextWindowRect;
				if (_isDraggingDroneWindow && _droneIndexBeingDragged == j)
				{
					text = "Drone ?";
					clientRect = new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, nextWindowRect.width, nextWindowRect.height);
				}
				GUI.Window(1 + j, clientRect, DrawSummaryWindow, text, _droneWindowStyles[j]);
			}
			if (!UseVerticalLayout)
			{
				nextWindowRect.x += _startingWindowRect.width;
			}
			else
			{
				nextWindowRect.y += _startingWindowRect.height;
			}
		}
		recordedRectsForMouseHint = true;
	}

	private IDrone FirstOrDefaultLowMem(List<IDrone> droneList, int droneNumber)
	{
		if (_dronesList != null)
		{
			int count = _dronesList.Count;
			for (int i = 0; i < count; i++)
			{
				if (_dronesList[i].DroneNumber == droneNumber)
				{
					return _dronesList[i];
				}
			}
		}
		return null;
	}

	private void DrawSummaryWindow(int id)
	{
		int myDroneNumber = GetMyDroneNumber(id);
		if (myDroneNumber == _selectedDroneNumber)
		{
			DrawBackgroundTexture();
		}
		if (_warningTimerAllDrones[myDroneNumber - 1] > 0f)
		{
			ShowWarningOnDroneWindow();
		}
		IDrone drone = null;
		int count = _dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			if (_dronesList[i].DroneNumber == myDroneNumber)
			{
				drone = _dronesList[i];
				break;
			}
		}
		if (drone == null || (!drone.IsVisible && !drone.IsInvisibleDueToToggle))
		{
			return;
		}
		if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
		{
			_selectedDroneNumber = myDroneNumber;
			if (this.OnDroneSelected != null)
			{
				this.OnDroneSelected(myDroneNumber);
			}
		}
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		if (drone.IsDead)
		{
			guiStyle.normal.textColor = Color.red;
		}
		else
		{
			guiStyle.normal.textColor = Color.gray;
		}
		if (drone.IsDead && drone.CanBeFullyRepaired && drone is NonVisualDrone)
		{
			GUILayout.Label(((NonVisualDrone)drone).guiTimeLeft, guiStyle);
		}
		else if (!UseVerticalLayout)
		{
			GUILayout.Label(drone.guiDroneStatus, guiStyle);
		}
		else
		{
			guiStyle.alignment = TextAnchor.UpperRight;
			GUI.Label(new Rect(275f, 0f, 125f, 30f), drone.guiDroneStatus, guiStyle);
			guiStyle.alignment = TextAnchor.UpperLeft;
		}
		if (!UseVerticalLayout)
		{
			GUILayout.Space(10f);
		}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		int num = 1;
		int count2 = drone.Upgrades.Count;
		for (int j = 0; j < count2; j++)
		{
			BaseDroneUpgrade baseDroneUpgrade = drone.Upgrades[j];
			if (num > drone.NumberOfUpgradeSlots)
			{
				break;
			}
			guiStyle.normal.textColor = DroneManager.GetDroneUpgradeStatusColor(baseDroneUpgrade, drone);
			GUILayout.BeginHorizontal();
			if (baseDroneUpgrade != null)
			{
				string text = ((baseDroneUpgrade.BrokenState != BrokenStateEnum.ErrorsDetected) ? string.Format("{0}: {1}", num++, baseDroneUpgrade.Name) : string.Format("{0}: !!! {1}", num++, baseDroneUpgrade.Name));
				if (baseDroneUpgrade is IStorageUpgrade)
				{
					IStorageUpgrade storageUpgrade = (IStorageUpgrade)baseDroneUpgrade;
				}
				else if (baseDroneUpgrade is IDamagableObject)
				{
					IDamagableObject damagableObject = (IDamagableObject)baseDroneUpgrade;
					if (damagableObject.TotalHitpoints > 0f)
					{
						text += damagableObject.guiStatus;
					}
				}
				else if (baseDroneUpgrade is IPoweredObject)
				{
					IPoweredObject poweredObject = (IPoweredObject)baseDroneUpgrade;
					if (poweredObject.TotalPower > 0f)
					{
						text += poweredObject.guiStatus;
					}
				}
				GUILayout.Label(text, guiStyle);
			}
			else
			{
				num++;
				GUILayout.Label(slotNumberArray[j], guiStyle);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndVertical();
		GUILayout.Space(10f);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndScrollView();
	}

	private int GetMyDroneNumber(int windowId)
	{
		return windowId - 1 + 1;
	}

	public void SetSelectedDrone(int droneNumber)
	{
		_selectedDroneNumber = droneNumber;
	}

	private void ShowWarningOnDroneWindow()
	{
		Rect position = new Rect(2f, 2f, 25f, 25f);
		GUI.DrawTexture(position, _warningImage);
	}

	public void Update()
	{
		if (_dronesList == null || GlobalSettings.IsGamePaused)
		{
			return;
		}
		for (int i = 0; i < _warningTimerAllDrones.Length; i++)
		{
			if (_warningTimerAllDrones[i] > 0f)
			{
				_warningTimerAllDrones[i] -= Time.deltaTime;
			}
			if (_warningTimerAllDrones[i] < 0f)
			{
				_warningTimerAllDrones[i] = 0f;
			}
		}
	}

	public void DroneReceivedDamage(Drone drone, float damageAmount, DamageType type)
	{
		if (drone.DroneNumber >= 0 && drone.DroneNumber < 7)
		{
			_warningTimerAllDrones[drone.DroneNumber - 1] = WARNING_DISPLAY_DURATION;
		}
	}
}
