using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Manual
{
	private const int ROW_COUNT = 8;

	private const int COLUMN_COUNT = 3;

	private const float MENU_SELECT_DELAY = 0.1f;

	private static GameObject canvasContainerObject;

	private static Text _breadCrumbText;

	private static Text _menuTitleText;

	private static Text _infoText;

	private static HelpMenuEntrySlot[,] _entries;

	private static int _currentRow;

	private static int _currentColumn;

	private static HelpManualBreadCrumb _rootBreadCrumb;

	private static HelpManualBreadCrumb _currentBreadCrumb;

	private static float _menuSelectTimer;

	private static GameObject bottomCenterInfo;

	public static bool IsVisible
	{
		get
		{
			return canvasContainerObject.activeInHierarchy;
		}
		set
		{
			if (canvasContainerObject.activeSelf != value)
			{
				canvasContainerObject.SetActive(value);
			}
			if (value && _currentBreadCrumb != null)
			{
				_currentBreadCrumb = _rootBreadCrumb;
				_currentBreadCrumb.NextCrumb = null;
				LoadMenu(_rootBreadCrumb.ThisMenu);
			}
		}
	}

	public static bool ShowEnterOnSubMenu { get; set; }

	public static bool IsAtTop
	{
		get
		{
			return _currentBreadCrumb.LastCrumb == null;
		}
	}

	public static HelpManualMenuItem SelectedMenuItem
	{
		get
		{
			return _entries[_currentRow, _currentColumn].MenuItem;
		}
	}

	public static void Initalize(GameObject canvasContainer)
	{
		canvasContainerObject = canvasContainer;
		Transform transform = canvasContainer.transform;
		Transform transform2 = transform.FindChild("TopBreadCrumbPane");
		if (transform2 != null)
		{
			transform2 = transform2.FindChild("BreadCrumbText");
			if (transform2 != null)
			{
				_breadCrumbText = transform2.GetComponent<Text>();
			}
		}
		transform2 = transform.FindChild("MiddleInfoPane");
		if (transform2 != null)
		{
			transform2 = transform2.FindChild("InfoText");
			if (transform2 != null)
			{
				_infoText = transform2.GetComponent<Text>();
			}
		}
		_entries = new HelpMenuEntrySlot[8, 3];
		bool flag = false;
		Transform transform3 = transform.FindChild("TopMenuPane");
		if (transform3 != null)
		{
			transform2 = transform3.FindChild("TitleText");
			if (transform2 != null)
			{
				_menuTitleText = transform2.GetComponent<Text>();
			}
			int num = 1;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					transform2 = transform3.FindChild("Item" + num++);
					if (transform2 != null)
					{
						_entries[j, i] = transform2.gameObject.GetComponent<HelpMenuEntrySlot>();
					}
					if (_entries[j, i] == null)
					{
						flag = true;
					}
				}
			}
		}
		Transform transform4 = transform.FindChild("BottomHelpInfoBox");
		if (transform4 != null)
		{
			Transform transform5 = transform4.FindChild("BottomCenter");
			if (transform5 != null)
			{
				bottomCenterInfo = transform5.gameObject;
				bottomCenterInfo.SetActive(false);
			}
		}
		if (_breadCrumbText == null || _infoText == null || _menuTitleText == null || flag)
		{
			Debug.LogError("Could not find all components of HelpManual");
		}
	}

	public static void LoadTopMenu(HelpManualMenu menu)
	{
		_currentBreadCrumb = new HelpManualBreadCrumb(menu, null);
		_rootBreadCrumb = _currentBreadCrumb;
		LoadMenu(menu);
		if (bottomCenterInfo != null)
		{
			bottomCenterInfo.SetActive(false);
		}
	}

	public static void LoadMenu(HelpManualMenu menu)
	{
		_menuTitleText.text = menu.HeaderText;
		_infoText.text = string.Empty;
		int i = 0;
		for (int j = 0; j < 3; j++)
		{
			for (int k = 0; k < 8; k++)
			{
				for (; i < menu.MenuItems.Count && menu.MenuItems.ElementAt(i).Value.IsHidden; i++)
				{
					menu.MenuItems.ElementAt(i).Value.ChangedSinceLastView = false;
				}
				if (i < menu.MenuItems.Count)
				{
					bool flag = true;
					if (menu.MenuItems.ElementAt(i).Value.JumpToMenu != null)
					{
						int count = menu.MenuItems.ElementAt(i).Value.JumpToMenu.MenuItems.Count;
						for (int l = 0; l < count; l++)
						{
							HelpManualMenuItem value = menu.MenuItems.ElementAt(i).Value.JumpToMenu.MenuItems.ElementAt(l).Value;
							if (value.ChangedSinceLastView)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							menu.MenuItems.ElementAt(i).Value.ChangedSinceLastView = false;
						}
					}
					_entries[k, j].SetMenuItem(menu.MenuItems.ElementAt(i).Value);
					if (flag)
					{
						menu.MenuItems.ElementAt(i).Value.ChangedSinceLastView = false;
					}
				}
				else
				{
					_entries[k, j].SetMenuItem(null);
				}
				i++;
			}
		}
		if (menu.MenuItems.Count == 0)
		{
			_infoText.text = "---Under Construction---";
		}
		_currentRow = 0;
		_currentColumn = 0;
		_entries[0, 0].SetCursorHere(true);
		if (_currentBreadCrumb.LastCrumb != null)
		{
			_menuSelectTimer = 0.1f;
		}
		UpdateBreadCrumbText();
		if (ShowEnterOnSubMenu && bottomCenterInfo != null)
		{
			if (_rootBreadCrumb != null)
			{
				bottomCenterInfo.SetActive(true);
			}
			else
			{
				bottomCenterInfo.SetActive(false);
			}
		}
	}

	public static void Update()
	{
		if (DialogUI.Instance.IsShowing)
		{
			return;
		}
		ProcessArrowKeyPresses();
		if (ProcessShortcutKeys())
		{
			_menuSelectTimer = 0.1f;
		}
		else if (IsAtTop && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
		{
			_menuSelectTimer = 0.1f;
		}
		else if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Backspace) && _currentBreadCrumb.LastCrumb != null))
		{
			while (!_currentBreadCrumb.IsMenuNode)
			{
				PopBreadCrumbTrail();
			}
			if (!PopBreadCrumbTrail())
			{
				TryClose();
			}
			else if (ShowEnterOnSubMenu && bottomCenterInfo != null)
			{
				if (!_currentBreadCrumb.IsMenuNode)
				{
					bottomCenterInfo.SetActive(true);
				}
				else
				{
					bottomCenterInfo.SetActive(false);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			TryClose();
		}
		if (!(_menuSelectTimer > 0f))
		{
			return;
		}
		_menuSelectTimer -= Time.deltaTime;
		if (!(_menuSelectTimer <= 0f))
		{
			return;
		}
		HelpManualMenuItem menuItem = _entries[_currentRow, _currentColumn].MenuItem;
		if (menuItem != null)
		{
			if (menuItem.IsJump)
			{
				PushBreadCrumbTrailMenu(menuItem.JumpToMenu);
				return;
			}
			if (!_currentBreadCrumb.IsMenuNode)
			{
				PopBreadCrumbTrail();
			}
			PushBreadCrumbTrailHelpItem(menuItem);
		}
		else
		{
			Debug.LogWarning("Bad menu index selected, coords: " + _currentRow + ", " + _currentColumn);
		}
	}

	public static void ExternalOpenSubmenu(string headerText)
	{
		for (int i = 0; i < 3; i++)
		{
			if (_entries.GetUpperBound(1) <= i)
			{
				continue;
			}
			for (int j = 0; j < 8; j++)
			{
				if (_entries.GetUpperBound(0) > j && _entries[j, i] != null && _entries[j, i].MenuItem != null && string.Equals(_entries[j, i].MenuItem.DisplayText, headerText))
				{
					PushBreadCrumbTrailMenu(_entries[j, i].MenuItem.JumpToMenu);
					PushBreadCrumbTrailHelpItem(_entries[j, i].MenuItem);
					return;
				}
			}
		}
	}

	private static void PushBreadCrumbTrailMenu(HelpManualMenu menu)
	{
		if (_currentBreadCrumb == null)
		{
			Debug.LogWarning("Breadcrumb data not initialized");
			return;
		}
		HelpManualBreadCrumb helpManualBreadCrumb = new HelpManualBreadCrumb(menu, _currentBreadCrumb);
		_currentBreadCrumb.NextCrumb = helpManualBreadCrumb;
		_currentBreadCrumb.LastRow = _currentRow;
		_currentBreadCrumb.LastColumn = _currentColumn;
		_currentBreadCrumb = helpManualBreadCrumb;
		UpdateBreadCrumbText();
		LoadMenu(menu);
	}

	private static void PushBreadCrumbTrailHelpItem(HelpManualMenuItem item)
	{
		if (_currentBreadCrumb == null)
		{
			Debug.LogWarning("Breadcrumb data not initialized");
			return;
		}
		HelpManualBreadCrumb helpManualBreadCrumb = new HelpManualBreadCrumb(item, _currentBreadCrumb);
		_currentBreadCrumb.NextCrumb = helpManualBreadCrumb;
		_currentBreadCrumb = helpManualBreadCrumb;
		UpdateBreadCrumbText();
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				_entries[i, j].SetIsSelected(false);
			}
		}
		_entries[_currentRow, _currentColumn].SetIsSelected(true);
		LoadHelpItem(item);
	}

	private static bool PopBreadCrumbTrail()
	{
		if (_currentBreadCrumb == null)
		{
			Debug.LogWarning("Breadcrumb data not initialized");
			return false;
		}
		if (_currentBreadCrumb.LastCrumb != null)
		{
			if (_currentBreadCrumb.IsMenuNode)
			{
				HelpManualMenu thisMenu = _currentBreadCrumb.LastCrumb.ThisMenu;
				_currentBreadCrumb = _currentBreadCrumb.LastCrumb;
				_currentBreadCrumb.NextCrumb = null;
				if (_currentBreadCrumb.DisplayText != thisMenu.HeaderText)
				{
					Debug.LogWarning("Sanity check fail - ");
				}
				UpdateBreadCrumbText();
				LoadMenu(thisMenu);
				UpdateCursorPos(_currentBreadCrumb.LastRow, _currentBreadCrumb.LastColumn);
			}
			else
			{
				_currentBreadCrumb = _currentBreadCrumb.LastCrumb;
				_currentBreadCrumb.NextCrumb = null;
				UpdateBreadCrumbText();
			}
			return true;
		}
		Debug.LogWarning("Breadcrumb going too far back!!");
		return false;
	}

	private static void UpdateBreadCrumbText()
	{
		if (_rootBreadCrumb == null)
		{
			_breadCrumbText.text = "<no breadcrumb data!!!>";
			return;
		}
		string text = string.Empty;
		for (HelpManualBreadCrumb helpManualBreadCrumb = _rootBreadCrumb; helpManualBreadCrumb != null; helpManualBreadCrumb = helpManualBreadCrumb.NextCrumb)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text += " >> ";
			}
			text += helpManualBreadCrumb.DisplayText;
		}
		_breadCrumbText.text = text;
	}

	private static void LoadHelpItem(HelpManualMenuItem item)
	{
		if (item != null)
		{
			_infoText.text = item.HelpText;
			if (string.IsNullOrEmpty(item.HelpText))
			{
				_infoText.text = "---Under Construction---";
			}
		}
	}

	private static void UpdateCursorPos(int newRow, int newCol)
	{
		_currentRow = newRow;
		_currentColumn = newCol;
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				_entries[i, j].SetCursorHere(false);
			}
		}
		_entries[newRow, newCol].SetCursorHere(true);
	}

	private static void TryClose()
	{
		if (GameplayManager.Instance != null)
		{
			GameplayManager.Instance.CloseHelpWindow();
		}
		else if (PauseMenu.Instance != null)
		{
			PauseMenu.Instance.HideHelp();
		}
		else if (MainMenu.Instance != null)
		{
			MainMenu.Instance.HideHelp();
		}
		IsVisible = false;
	}

	public static bool ProcessArrowKeyPresses()
	{
		bool result = false;
		int currentRow = _currentRow;
		int currentColumn = _currentColumn;
		int num = _currentRow;
		int num2 = _currentColumn;
		if (Input.GetButtonDown("Up"))
		{
			if (_currentRow == 0)
			{
				for (int num3 = 7; num3 >= 0; num3--)
				{
					if (_entries[num3, _currentColumn].IsVisible)
					{
						num = num3;
						break;
					}
				}
			}
			else
			{
				num--;
			}
		}
		else if (Input.GetButtonDown("Down"))
		{
			if (_currentRow == 7 || !_entries[_currentRow + 1, _currentColumn].IsVisible)
			{
				for (int i = 0; i < 8; i++)
				{
					if (_entries[i, _currentColumn].IsVisible)
					{
						num = i;
						break;
					}
				}
			}
			else
			{
				num++;
			}
		}
		else if (Input.GetButtonDown("Left"))
		{
			if (_currentColumn == 0)
			{
				for (int num4 = 2; num4 >= 0; num4--)
				{
					if (_entries[_currentRow, num4].IsVisible)
					{
						num2 = num4;
						break;
					}
				}
			}
			else
			{
				num2--;
			}
		}
		else if (Input.GetButtonDown("Right"))
		{
			if (_currentColumn == 2 || !_entries[_currentRow, _currentColumn + 1].IsVisible)
			{
				for (int j = 0; j < 3; j++)
				{
					if (_entries[_currentRow, j].IsVisible)
					{
						num2 = j;
						break;
					}
				}
			}
			else
			{
				num2++;
			}
		}
		if (currentRow != num || currentColumn != num2)
		{
			result = true;
			UpdateCursorPos(num, num2);
			if (_currentBreadCrumb.LastCrumb != null)
			{
				_menuSelectTimer = 0.1f;
			}
		}
		return result;
	}

	public static bool ProcessShortcutKeys()
	{
		bool result = false;
		bool flag = false;
		int num = _currentRow;
		int num2 = _currentColumn;
		if (Input.GetKeyDown(KeyCode.A))
		{
			num = 0;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.B))
		{
			num = 1;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			num = 2;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			num = 3;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			num = 4;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.F))
		{
			num = 5;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			num = 6;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			num = 7;
			num2 = 0;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.I))
		{
			num = 0;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.J))
		{
			num = 1;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			num = 2;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.L))
		{
			num = 3;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			num = 4;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			num = 5;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.O))
		{
			num = 6;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.P))
		{
			num = 7;
			num2 = 1;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			num = 0;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			num = 1;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			num = 2;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
			num = 3;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.U))
		{
			num = 4;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.V))
		{
			num = 5;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			num = 6;
			num2 = 2;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			num = 7;
			num2 = 2;
			flag = true;
		}
		if (flag)
		{
			if (_entries[num, num2].IsVisible)
			{
				if (!_entries[num, num2].IsSelected)
				{
					result = true;
					UpdateCursorPos(num, num2);
					if (_currentBreadCrumb.LastCrumb != null)
					{
						_menuSelectTimer = 0.1f;
					}
				}
			}
			else
			{
				CommonAudioHelper.Instance.PlayErrorSound();
			}
		}
		return result;
	}
}
