using System.Linq;
using UnityEngine;

public class DroneSwapUi2 : MonoBehaviour
{
	private const int UPGRADE_COLUMNS = 2;

	private const int UPGRADE_ROWS_MAX = 4;

	public static DroneSwapUi2 Instance;

	public UIBreakStatsItem breakStats;

	public UITextLabel hintTextLabel;

	public Color AliveColor;

	public Color DisabledColor;

	public Color DestroyedColor;

	public Color DisabledNumberColor;

	public Color DestroyedNumberColor;

	private Vector2 _cursorPos = new Vector2(0f, 0f);

	private DroneSwapUpgradeSlot[,] _slots = new DroneSwapUpgradeSlot[4, 2];

	private DroneSwapDroneInfoPanel[] _dronePanels = new DroneSwapDroneInfoPanel[2];

	private bool _initialized;

	private bool _firstUpdate = true;

	private bool _showSelectionBorders;

	public HelpManualMenuHelper helper { get; private set; }

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			if (base.gameObject.activeSelf != value)
			{
				base.gameObject.SetActive(value);
			}
			if (!value)
			{
				if (_dronePanels[0].Drone != null)
				{
					_dronePanels[0].Drone.IsBeingSwapped = false;
				}
				if (_dronePanels[1].Drone != null)
				{
					_dronePanels[1].Drone.IsBeingSwapped = false;
				}
			}
		}
	}

	private void Awake()
	{
		Instance = this;
		if (!_initialized)
		{
			Initialize();
		}
		if (breakStats != null)
		{
			breakStats.gameObject.SetActive(false);
		}
	}

	private void Initialize()
	{
		CommandHelper.Initialize();
		helper = new HelpManualMenuHelper();
		helper.BuildMenus(true);
		bool flag = false;
		Transform transform = base.transform.FindChild("UpgradeSwapPanel");
		Transform transform2;
		if (transform != null)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					transform2 = transform.FindChild(string.Format("Slot{0}-{1}", j + 1, i + 1));
					if (transform2 != null)
					{
						_slots[i, j] = transform2.gameObject.GetComponent<DroneSwapUpgradeSlot>();
					}
					else
					{
						flag = true;
					}
				}
			}
		}
		transform2 = base.transform.FindChild("LeftDroneInfoBox");
		if (transform2 != null)
		{
			_dronePanels[0] = transform2.gameObject.GetComponent<DroneSwapDroneInfoPanel>();
		}
		transform2 = base.transform.FindChild("RightDroneInfoBox");
		if (transform2 != null)
		{
			_dronePanels[1] = transform2.gameObject.GetComponent<DroneSwapDroneInfoPanel>();
		}
		if (_dronePanels.Any((DroneSwapDroneInfoPanel x) => x == null) || flag)
		{
			Debug.LogError("DroneSwapUi2 did not resolve all fields properly");
		}
		else
		{
			_dronePanels[0].SetColors(AliveColor, DisabledColor, DestroyedColor, DisabledNumberColor, DestroyedNumberColor);
			_dronePanels[1].SetColors(AliveColor, DisabledColor, DestroyedColor, DisabledNumberColor, DestroyedNumberColor);
		}
		_initialized = true;
	}

	private void Update()
	{
		if (_firstUpdate)
		{
			_firstUpdate = false;
			UpdateCursorPos(_cursorPos, true);
			if (_showSelectionBorders)
			{
				_slots[0, 1].SetIsSelected(true);
			}
		}
		ProcessArrowKeyPresses();
		ProcessShortcutKeys();
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if (CommonMethods.ControlKeyIsBeingPressed())
			{
				DoQuickSwap();
			}
			else
			{
				SwapCurrentSelections();
			}
		}
	}

	private void ProcessArrowKeyPresses()
	{
		Vector2 cursorPos = _cursorPos;
		if (Input.GetButtonDown("Up"))
		{
			if (_cursorPos.x == 0f)
			{
				_cursorPos.x = GetMaxUpgradesAllowed((int)_cursorPos.y) - 1;
			}
			else
			{
				_cursorPos.x -= 1f;
			}
		}
		else if (Input.GetButtonDown("Down"))
		{
			if (_cursorPos.x == (float)(GetMaxUpgradesAllowed((int)_cursorPos.y) - 1))
			{
				_cursorPos.x = 0f;
			}
			else
			{
				_cursorPos.x += 1f;
			}
		}
		else if (Input.GetButtonDown("Left"))
		{
			if (_cursorPos.y == 0f)
			{
				_cursorPos.y = 1f;
			}
			else
			{
				_cursorPos.y -= 1f;
			}
			if (_showSelectionBorders)
			{
				_cursorPos.x = 0f;
				for (int i = 0; i < 4; i++)
				{
					if (_slots[i, (int)_cursorPos.y].IsSelected)
					{
						_cursorPos.x = i;
						break;
					}
				}
			}
		}
		else if (Input.GetButtonDown("Right"))
		{
			if (_cursorPos.y == 1f)
			{
				_cursorPos.y = 0f;
			}
			else
			{
				_cursorPos.y += 1f;
			}
			if (_showSelectionBorders)
			{
				_cursorPos.x = 0f;
				for (int j = 0; j < 4; j++)
				{
					if (_slots[j, (int)_cursorPos.y].IsSelected)
					{
						_cursorPos.x = j;
						break;
					}
				}
			}
		}
		if (!(cursorPos != _cursorPos))
		{
			return;
		}
		if (cursorPos.y != _cursorPos.y)
		{
			while (!_slots[(int)_cursorPos.x, (int)_cursorPos.y].IsVisible && _cursorPos.x > 0f)
			{
				_cursorPos.x -= 1f;
			}
		}
		UpdateCursorPos(_cursorPos, false);
	}

	private void ProcessShortcutKeys()
	{
		Vector2 cursorPos = _cursorPos;
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
		{
			if (0 < GetMaxUpgradesAllowed(0))
			{
				_cursorPos.y = 0f;
				_cursorPos.x = 0f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
		{
			if (1 < GetMaxUpgradesAllowed(0))
			{
				_cursorPos.y = 0f;
				_cursorPos.x = 1f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
		{
			if (2 < GetMaxUpgradesAllowed(0))
			{
				_cursorPos.y = 0f;
				_cursorPos.x = 2f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
		{
			if (3 < GetMaxUpgradesAllowed(0))
			{
				_cursorPos.y = 0f;
				_cursorPos.x = 3f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			if (0 < GetMaxUpgradesAllowed(1))
			{
				_cursorPos.y = 1f;
				_cursorPos.x = 0f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			if (1 < GetMaxUpgradesAllowed(1))
			{
				_cursorPos.y = 1f;
				_cursorPos.x = 1f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			if (2 < GetMaxUpgradesAllowed(1))
			{
				_cursorPos.y = 1f;
				_cursorPos.x = 2f;
			}
		}
		else if (Input.GetKeyDown(KeyCode.D) && 3 < GetMaxUpgradesAllowed(1))
		{
			_cursorPos.y = 1f;
			_cursorPos.x = 3f;
		}
		if (cursorPos != _cursorPos)
		{
			UpdateCursorPos(_cursorPos, false);
		}
	}

	private int GetMaxUpgradesAllowed(int column)
	{
		int result = 4;
		if (_dronePanels[column].Drone != null)
		{
			result = _dronePanels[column].Drone.NumberOfUpgradeSlots;
		}
		return result;
	}

	private void UpdateCursorPos(Vector2 newPos, bool ignoreSound)
	{
		_cursorPos = newPos;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				_slots[i, j].SetCursorHere(false);
				if (j == (int)newPos.y)
				{
					_slots[i, j].SetIsSelected(false);
				}
			}
		}
		if (_showSelectionBorders)
		{
			_slots[(int)newPos.x, (int)newPos.y].SetIsSelected(true);
		}
		_slots[(int)newPos.x, (int)newPos.y].SetCursorHere(true);
		if (!ignoreSound)
		{
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
	}

	private void SwapCurrentSelections()
	{
		int num = -1;
		int num2 = -1;
		if (_cursorPos.y == 0f)
		{
			if (_showSelectionBorders || (!_showSelectionBorders && _slots[(int)_cursorPos.x, 0].Upgrade != null))
			{
				num = (int)_cursorPos.x;
			}
			for (int i = 0; i < _dronePanels[1].Drone.NumberOfUpgradeSlots; i++)
			{
				if (_showSelectionBorders)
				{
					if (_slots[i, 1].IsSelected)
					{
						num2 = i;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
						break;
					}
				}
				else if (num2 == -1 && _slots[i, 1].Upgrade == null)
				{
					num2 = i;
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
					break;
				}
			}
		}
		else
		{
			if (_showSelectionBorders || (!_showSelectionBorders && _slots[(int)_cursorPos.x, 1].Upgrade != null))
			{
				num2 = (int)_cursorPos.x;
			}
			for (int j = 0; j < _dronePanels[0].Drone.NumberOfUpgradeSlots; j++)
			{
				if (_showSelectionBorders)
				{
					if (_slots[j, 0].IsSelected)
					{
						num = j;
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
						break;
					}
				}
				else if (num == -1 && _slots[j, 0].Upgrade == null)
				{
					num = j;
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UIUnEquip);
					break;
				}
			}
		}
		if (num != -1 && num2 != -1)
		{
			SwapSpecifiedSlots(num, num2);
		}
	}

	private void SwapSpecifiedSlots(int leftSlotNum, int rightSlotNum)
	{
		Drone drone = _dronePanels[0].Drone;
		Drone drone2 = _dronePanels[1].Drone;
		if (drone == null || drone2 == null)
		{
			return;
		}
		BaseDroneUpgrade baseDroneUpgrade = drone.PullUpgrade(leftSlotNum);
		BaseDroneUpgrade baseDroneUpgrade2 = drone2.PullUpgrade(rightSlotNum);
		if (baseDroneUpgrade != null)
		{
			drone2.AddDroneUpgrade(rightSlotNum, baseDroneUpgrade);
		}
		_slots[rightSlotNum, 1].SetUpgrade(baseDroneUpgrade);
		if (baseDroneUpgrade2 != null)
		{
			drone.AddDroneUpgrade(leftSlotNum, baseDroneUpgrade2);
		}
		_slots[leftSlotNum, 0].SetUpgrade(baseDroneUpgrade2);
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			SchematicViewCanvas.Instance.RefreshDrone(drone2.DroneNumber);
		}
		if (DroneManager.Instance != null)
		{
			if (DroneManager.Instance.CurrentDrone.DroneNumber == drone.DroneNumber)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
			else if (DroneManager.Instance.CurrentDrone.DroneNumber == drone2.DroneNumber)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
		}
		bool flag = true;
		for (int i = 0; i < 2; i++)
		{
			Drone drone3 = _dronePanels[i].Drone;
			for (int j = 0; j < drone3.NumberOfUpgradeSlots; j++)
			{
				if (drone3.Upgrades[j] == null)
				{
					flag = false;
					break;
				}
			}
		}
		bool flag2 = false;
		if (_showSelectionBorders != flag)
		{
			flag2 = true;
			_showSelectionBorders = flag;
		}
		for (int k = 0; k < 2; k++)
		{
			Drone drone4 = _dronePanels[k].Drone;
			if (!flag2)
			{
				continue;
			}
			for (int l = 0; l < drone4.NumberOfUpgradeSlots; l++)
			{
				_slots[l, k].SetIsSelected(false);
			}
			if (_showSelectionBorders)
			{
				if ((int)_cursorPos.y == k)
				{
					_slots[(int)_cursorPos.x, k].SetIsSelected(true);
				}
				else
				{
					_slots[0, k].SetIsSelected(true);
				}
			}
		}
	}

	private void DoQuickSwap()
	{
		if (_slots[(int)_cursorPos.x, (int)_cursorPos.y].Upgrade == null)
		{
			return;
		}
		int num = ((_cursorPos.y == 0f) ? 1 : 0);
		Drone drone = _dronePanels[(int)_cursorPos.y].Drone;
		Drone drone2 = _dronePanels[num].Drone;
		if (drone == null || drone2 == null)
		{
			return;
		}
		int num2 = -1;
		for (int i = 0; i < drone2.NumberOfUpgradeSlots; i++)
		{
			if (_slots[i, num].Upgrade == null)
			{
				num2 = i;
				break;
			}
		}
		if (num2 == -1)
		{
			return;
		}
		int leftSlotNum;
		int rightSlotNum;
		if (num == 1)
		{
			leftSlotNum = (int)_cursorPos.x;
			rightSlotNum = num2;
		}
		else
		{
			rightSlotNum = (int)_cursorPos.x;
			leftSlotNum = num2;
		}
		SwapSpecifiedSlots(leftSlotNum, rightSlotNum);
		int num3 = -1;
		for (int j = (int)_cursorPos.x + 1; j < drone.NumberOfUpgradeSlots; j++)
		{
			if (_slots[j, (int)_cursorPos.y].Upgrade != null)
			{
				num3 = j;
				break;
			}
		}
		if (num3 == -1)
		{
			for (int k = 0; k < (int)_cursorPos.x; k++)
			{
				if (_slots[k, (int)_cursorPos.y].Upgrade != null)
				{
					num3 = k;
					break;
				}
			}
		}
		if (num3 != -1)
		{
			UpdateCursorPos(new Vector2(num3, _cursorPos.y), true);
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIEquip);
		}
	}

	public void SetDrones(Drone leftDrone, Drone rightDrone)
	{
		if (!_initialized)
		{
			Initialize();
		}
		leftDrone.IsBeingSwapped = true;
		rightDrone.IsBeingSwapped = true;
		_dronePanels[0].SetDrone(leftDrone);
		_dronePanels[1].SetDrone(rightDrone);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				_slots[i, j].SetCursorHere(false);
				_slots[i, j].SetIsSelected(false);
				if (i >= GetMaxUpgradesAllowed(j))
				{
					_slots[i, j].IsVisible = false;
				}
				else
				{
					_slots[i, j].IsVisible = true;
				}
			}
		}
		int num = 0;
		bool showSelectionBorders = true;
		for (int k = 0; k < leftDrone.NumberOfUpgradeSlots; k++)
		{
			BaseDroneUpgrade baseDroneUpgrade = leftDrone.Upgrades[k];
			_slots[num++, 0].SetUpgrade(baseDroneUpgrade);
			if (baseDroneUpgrade == null)
			{
				showSelectionBorders = false;
			}
		}
		num = 0;
		for (int l = 0; l < rightDrone.NumberOfUpgradeSlots; l++)
		{
			BaseDroneUpgrade baseDroneUpgrade2 = rightDrone.Upgrades[l];
			_slots[num++, 1].SetUpgrade(baseDroneUpgrade2);
			if (baseDroneUpgrade2 == null)
			{
				showSelectionBorders = false;
			}
		}
		_showSelectionBorders = showSelectionBorders;
		_cursorPos = new Vector2(0f, 0f);
		UpdateCursorPos(_cursorPos, false);
		if (_showSelectionBorders)
		{
			_slots[0, 1].SetIsSelected(true);
		}
	}

	public void SetHintText(string hint)
	{
		if (!string.IsNullOrEmpty(hint))
		{
			hintTextLabel.label.text = hint;
			hintTextLabel.label.gameObject.SetActive(true);
		}
		else
		{
			hintTextLabel.label.gameObject.SetActive(false);
		}
	}
}
