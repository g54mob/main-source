using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
	public delegate bool MenuItemValidate();

	public delegate void SimpleDelegate();

	protected const float MENU_ITEMS_START_Y = 200f;

	protected const float MENU_ITEMS_WIDTH = 350f;

	protected const float MENU_ITEMS_HEIGHT = 20f;

	private const float MENU_SLIDER_WIDTH = 200f;

	private const float MENU_SLIDER_HEIGHT = 18f;

	private const float TITLE_CHARACTER_TIME = 0.3f;

	private const float MENU_HEIGHT = 300f;

	protected const bool ENABLE_ORIGINAL_STYLE = false;

	protected const bool ENABLE_ORIGINAL_MENU = false;

	private const float DELAY_ROW = 0.075f;

	public GameObject HelpManualUiObject;

	protected static RenderTexture screenRt;

	protected List<DuskersMenuItem> menuItems = new List<DuskersMenuItem>();

	protected List<DuskersMenuItem> cheatMenuItems = new List<DuskersMenuItem>();

	protected string titleTextFinal = string.Empty;

	private string titleTextCurrent = string.Empty;

	private GUIStyle textStyle = new GUIStyle();

	private GUIStyle textTitleStyle = new GUIStyle();

	private GUIStyle inputStyle;

	private int titleCharacterPosition;

	private float titleCharacterTimer;

	private bool mouseIsDown;

	private bool sliderFirstSlide;

	private float timerSlide;

	private bool firstInactiveLoop;

	private Vector2 mouseDownCoords = Vector2.zero;

	private int currentMenuItem;

	private Rect backgroundRect = new Rect(0f, 0f, 0f, 0f);

	private Rect cheatModeRect = new Rect(1f, 1f, 100f, 20f);

	private Rect titlePosition = new Rect(0f, 55f, 500f, 35f);

	private Rect versionPosition = new Rect(0f, 0f, 250f, 25f);

	private Rect cheatWindowRect = new Rect(0f, 0f, 200f, 300f);

	private Rect inactiveRect = new Rect(0f, 0f, 0f, 80f);

	private Rect highlightRect = new Rect(0f, 0f, 0f, 0f);

	private string gameStateValue = string.Empty.ToString();

	private string versionValue = 1.041f.ToString("0.00#");

	private string versionInfo = string.Empty;

	private HelpManual _helpManualWindow;

	private bool isCursorEnabled;

	private bool isShowingCursor;

	private float timerCursorBlink;

	private Rect cursorRect = new Rect(0f, 0f, 20f, 20f);

	private string cursorInputCharacter = string.Empty;

	private bool isRenderingRows;

	private float timerDelayBetweenRows;

	private int renderStep = -1;

	private int renderMenuItemIdx = -1;

	private bool hasBeginSelect;

	private Action postSelectAction;

	public bool IgnoreCancel { get; set; }

	public bool HideBackground { get; set; }

	public bool Inactive { get; private set; }

	public bool DisableClass { get; protected set; }

	public MenuScreen PreviousMenuScreen { get; set; }

	protected SimpleDelegate postGUIDraw { get; set; }

	protected SimpleDelegate finalSetInactive { get; set; }

	protected string InactiveText { get; set; }

	protected string InactiveTextAdditional { get; set; }

	protected virtual void Awake()
	{
		ResourceManager.OneTimeBackgroundLoad();
		if (MenuBackground.Instance != null)
		{
			if (screenRt == null)
			{
				switch (SystemManager.AspectRatio)
				{
				case SystemManager.AspectRationEnum.ar16x10:
					screenRt = RenderTexture.GetTemporary(3000, 1875, 0, RenderTextureFormat.ARGB32);
					break;
				case SystemManager.AspectRationEnum.ar16x9OrUnknown:
					screenRt = RenderTexture.GetTemporary(3000, 1152, 0, RenderTextureFormat.ARGB32);
					break;
				case SystemManager.AspectRationEnum.ar3x2:
					screenRt = RenderTexture.GetTemporary(3000, 2000, 0, RenderTextureFormat.ARGB32);
					break;
				case SystemManager.AspectRationEnum.ar4x3:
					screenRt = RenderTexture.GetTemporary(3000, 2250, 0, RenderTextureFormat.ARGB32);
					break;
				case SystemManager.AspectRationEnum.ar5x4:
					screenRt = RenderTexture.GetTemporary(3000, 2400, 0, RenderTextureFormat.ARGB32);
					break;
				case SystemManager.AspectRationEnum.ar21x9:
					screenRt = RenderTexture.GetTemporary(3000, 1286, 0, RenderTextureFormat.ARGB32);
					break;
				}
			}
			RenderTexture.active = screenRt;
			GL.Clear(true, true, new Color(0f, 0f, 0f, 1f));
			RenderTexture.active = null;
			Vector3 zero = Vector3.zero;
			zero.y = MenuBackground.Instance.transform.localScale.y;
			zero.x = zero.y * Camera.main.aspect;
			zero.z = MenuBackground.Instance.transform.localScale.z;
			MenuBackground.Instance.transform.localScale = zero;
			MenuBackground.Instance.backgroundMat.mainTexture = screenRt;
			MenuBackground.Instance.gameObject.SetActive(true);
		}
		else if (screenRt != null)
		{
			RenderTexture.ReleaseTemporary(screenRt);
			screenRt = null;
		}
	}

	protected virtual void Start()
	{
		if (!IgnoreCancel)
		{
			menuItems.Add(new DuskersMenuItem("[C]ancel", KeyCode.C, MenuCancel, menuItems.Count));
		}
		textStyle.font = ResourceManager.LoadAsset<Font>("Fonts/WHITRABT");
		textStyle.normal.textColor = GlobalSettings.Constants.CONSOLE_GREEN;
		textStyle.wordWrap = true;
		textTitleStyle.font = ResourceManager.LoadAsset<Font>("Fonts/WHITRABT");
		textTitleStyle.normal.textColor = GlobalSettings.Constants.MENU_TITLE;
		textTitleStyle.wordWrap = true;
		textStyle.fontSize = 20;
		textTitleStyle.fontSize = 30;
		inputStyle = new GUIStyle();
		inputStyle.font = ResourceManager.LoadAsset<Font>("Fonts/WHITRABT");
		inputStyle.normal.textColor = Color.white;
		inputStyle.fontSize = 20;
		EnableCursor();
		CalculateMenuItemMetrics();
		titleCharacterPosition = 0;
		titleCharacterTimer = 0.3f;
		versionInfo = string.Format("{0} v {1}", gameStateValue, versionValue);
		titleTextCurrent = titleTextFinal;
		titlePosition.x = 100f;
		titlePosition.y = 140f;
		_helpManualWindow = new HelpManual();
		isRenderingRows = true;
		timerDelayBetweenRows = 0.075f;
	}

	public void OnApplicationQuit()
	{
		if (screenRt != null)
		{
			RenderTexture.ReleaseTemporary(screenRt);
		}
	}

	protected virtual void OnDestroy()
	{
	}

	public virtual void ReloadMenuItems()
	{
		if (GlobalSettings.cheatMode && cheatMenuItems.Count > 0)
		{
			foreach (DuskersMenuItem cheatMenuItem in cheatMenuItems)
			{
				menuItems.Remove(cheatMenuItem);
				menuItems.Add(cheatMenuItem);
			}
		}
		CalculateMenuItemMetrics();
	}

	protected virtual void Update()
	{
		if (DisableClass)
		{
			return;
		}
		if (firstInactiveLoop)
		{
			firstInactiveLoop = false;
			if (finalSetInactive != null)
			{
				finalSetInactive();
			}
		}
		if (!isRenderingRows)
		{
			if (DialogUI.Instance != null && DialogUI.Instance.IsShowing)
			{
				if (!DialogUI.Instance.TestKeyInput())
				{
					if (Input.GetKeyDown(KeyCode.Escape))
					{
						DialogUI.Instance.CloseDialog();
						cursorInputCharacter = string.Empty;
					}
				}
				else
				{
					cursorInputCharacter = string.Empty;
				}
			}
			else if (hasBeginSelect)
			{
				hasBeginSelect = false;
				if (postSelectAction != null)
				{
					postSelectAction();
				}
			}
			else
			{
				if (Inactive)
				{
					return;
				}
				if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.X))
				{
					if (ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
					{
						GlobalSettings.cheatMode = !GlobalSettings.cheatMode;
					}
					if (cheatMenuItems.Count > 0)
					{
						if (GlobalSettings.cheatMode)
						{
							foreach (DuskersMenuItem cheatMenuItem in cheatMenuItems)
							{
								menuItems.Add(cheatMenuItem);
							}
							CalculateMenuItemMetrics();
						}
						else
						{
							foreach (DuskersMenuItem cheatMenuItem2 in cheatMenuItems)
							{
								menuItems.Remove(cheatMenuItem2);
							}
							CalculateMenuItemMetrics();
						}
					}
				}
				else
				{
					bool flag = false;
					bool flag2 = false;
					int count = menuItems.Count;
					for (int i = 0; i < count; i++)
					{
						DuskersMenuItem duskersMenuItem = menuItems[i];
						if (duskersMenuItem.Hidden)
						{
							continue;
						}
						switch (duskersMenuItem.MenuType)
						{
						case DuskersMenuItem.MenuTypeEnum.Standard:
						{
							bool flag4 = false;
							if (Input.GetKeyDown(duskersMenuItem.ShortcutKey))
							{
								currentMenuItem = duskersMenuItem.MenuIndex;
								hasBeginSelect = true;
								if (duskersMenuItem.SelectAction != null)
								{
									postSelectAction = duskersMenuItem.SelectAction;
									flag4 = true;
								}
								else
								{
									Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
								}
								flag = true;
							}
							else if (currentMenuItem == duskersMenuItem.MenuIndex && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
							{
								if (menuItems[currentMenuItem].SelectAction != null)
								{
									menuItems[currentMenuItem].SelectAction();
									flag4 = true;
								}
								else
								{
									Debug.LogWarning("Nothing to execute.  No menu action defined for: " + menuItems[currentMenuItem].Label);
								}
							}
							if (flag4)
							{
								cursorInputCharacter = duskersMenuItem.ShortcutKey.ToString().ToLower();
							}
							break;
						}
						case DuskersMenuItem.MenuTypeEnum.Slider:
							if (Input.GetKeyDown(duskersMenuItem.ShortcutKey))
							{
								currentMenuItem = duskersMenuItem.MenuIndex;
								flag = true;
							}
							else
							{
								if (currentMenuItem != duskersMenuItem.MenuIndex)
								{
									break;
								}
								bool flag3 = false;
								if (!sliderFirstSlide)
								{
									flag3 = true;
								}
								else
								{
									timerSlide -= Time.deltaTime;
									if (timerSlide <= 0f)
									{
										timerSlide = 0f;
										flag3 = true;
									}
								}
								if (!flag3)
								{
									break;
								}
								if ((duskersMenuItem.ShortcutKeyIncrease != KeyCode.None && Input.GetKey(duskersMenuItem.ShortcutKeyIncrease)) || Input.GetButton(duskersMenuItem.ShortcutKeyIncreaseMappedKey))
								{
									if (!sliderFirstSlide)
									{
										sliderFirstSlide = true;
										timerSlide = 0.3f;
									}
									else
									{
										timerSlide = 0.1f;
									}
									if (duskersMenuItem.SliderValue < 1f)
									{
										duskersMenuItem.SliderValue += duskersMenuItem.SliderStepSize;
										if (duskersMenuItem.SliderValue > 1f)
										{
											duskersMenuItem.SliderValue = 1f;
										}
										if (duskersMenuItem.SelectActionIncrease != null)
										{
											duskersMenuItem.SelectActionIncrease(duskersMenuItem);
										}
										else
										{
											Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
										}
									}
								}
								else if ((duskersMenuItem.ShortcutKeyDecrease != KeyCode.None && Input.GetKey(duskersMenuItem.ShortcutKeyDecrease)) || Input.GetButton(duskersMenuItem.ShortcutKeyDecreaseMappedKey))
								{
									if (!sliderFirstSlide)
									{
										sliderFirstSlide = true;
										timerSlide = 0.3f;
									}
									else
									{
										timerSlide = 0.1f;
									}
									if (duskersMenuItem.SliderValue > 0f)
									{
										duskersMenuItem.SliderValue -= duskersMenuItem.SliderStepSize;
										if (duskersMenuItem.SliderValue < 0f)
										{
											duskersMenuItem.SliderValue = 0f;
										}
										if (duskersMenuItem.SelectActionDecrease != null)
										{
											duskersMenuItem.SelectActionDecrease(duskersMenuItem);
										}
										else
										{
											Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
										}
									}
								}
								else if (sliderFirstSlide)
								{
									sliderFirstSlide = false;
									timerSlide = 0f;
								}
							}
							break;
						case DuskersMenuItem.MenuTypeEnum.MultiItemSlider:
							if (Input.GetKeyDown(duskersMenuItem.ShortcutKey) || (currentMenuItem == duskersMenuItem.MenuIndex && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))))
							{
								currentMenuItem = duskersMenuItem.MenuIndex;
								if (duskersMenuItem.SelectAction != null)
								{
									duskersMenuItem.SelectAction();
								}
								else
								{
									Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
								}
								flag = true;
							}
							else
							{
								if (currentMenuItem != duskersMenuItem.MenuIndex)
								{
									break;
								}
								if ((duskersMenuItem.ShortcutKeyIncrease != KeyCode.None && Input.GetKeyDown(duskersMenuItem.ShortcutKeyIncrease)) || Input.GetButtonDown(duskersMenuItem.ShortcutKeyIncreaseMappedKey))
								{
									if (duskersMenuItem.SelectActionIncrease != null)
									{
										duskersMenuItem.SelectActionIncrease(duskersMenuItem);
									}
									else
									{
										Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
									}
									flag2 = true;
								}
								else if ((duskersMenuItem.ShortcutKeyDecrease != KeyCode.None && Input.GetKeyDown(duskersMenuItem.ShortcutKeyDecrease)) || Input.GetButtonDown(duskersMenuItem.ShortcutKeyDecreaseMappedKey))
								{
									if (duskersMenuItem.SelectActionDecrease != null)
									{
										duskersMenuItem.SelectActionDecrease(duskersMenuItem);
									}
									else
									{
										Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
									}
									flag2 = true;
								}
								else if (sliderFirstSlide)
								{
									sliderFirstSlide = false;
									timerSlide = 0f;
								}
							}
							break;
						}
					}
					if (!flag)
					{
						if (Input.GetButtonDown("Up"))
						{
							do
							{
								currentMenuItem--;
								if (currentMenuItem < 0)
								{
									currentMenuItem = menuItems.Count - 1;
								}
							}
							while (menuItems[currentMenuItem].Hidden);
						}
						else if (Input.GetButtonDown("Down"))
						{
							do
							{
								currentMenuItem++;
								if (currentMenuItem >= menuItems.Count)
								{
									currentMenuItem = 0;
								}
							}
							while (menuItems[currentMenuItem].Hidden);
						}
						else if (!IgnoreCancel && Input.GetKeyDown(KeyCode.Escape))
						{
							MenuCancel();
						}
						else if (!flag && !flag2 && Input.anyKeyDown && !sliderFirstSlide && cursorInputCharacter == string.Empty)
						{
							CommonAudioHelper.Instance.PlayErrorSound();
						}
					}
				}
				if (isCursorEnabled)
				{
					timerCursorBlink -= Time.deltaTime;
					if (timerCursorBlink <= 0f)
					{
						timerCursorBlink = 0.2f;
						isShowingCursor = !isShowingCursor;
					}
				}
			}
			return;
		}
		timerDelayBetweenRows -= Time.deltaTime;
		if (!(timerDelayBetweenRows <= 0f))
		{
			return;
		}
		if (renderStep <= 0 || renderStep > 1)
		{
			renderStep++;
		}
		else
		{
			renderMenuItemIdx++;
			if (renderMenuItemIdx >= menuItems.Count)
			{
				renderStep++;
				renderMenuItemIdx = menuItems.Count;
			}
		}
		if (renderStep > 2)
		{
			isRenderingRows = false;
			PostRenderMenuItems();
		}
		else
		{
			timerDelayBetweenRows = 0.075f;
		}
	}

	protected virtual void OnGUI()
	{
		if (DisableClass)
		{
			return;
		}
		if (!Inactive && (DialogUI.Instance == null || !DialogUI.Instance.IsShowing))
		{
			if (screenRt != null)
			{
				RenderTexture.active = screenRt;
			}
			GUI.depth = -1;
			if (!HideBackground)
			{
				backgroundRect.width = Screen.width;
				backgroundRect.height = Screen.height;
			}
			bool flag = false;
			Vector2 zero = Vector2.zero;
			if (!isRenderingRows)
			{
				if (Event.current.type == EventType.MouseDown)
				{
					CommonAudioHelper.Instance.PlayErrorSound();
				}
				if (mouseIsDown && flag)
				{
					mouseIsDown = false;
				}
			}
			if (GlobalSettings.cheatMode)
			{
				GUIStyle gUIStyle = new GUIStyle();
				gUIStyle.normal.textColor = Color.red;
				GUI.Label(cheatModeRect, "Cheat Mode!!!", gUIStyle);
			}
			if (!isRenderingRows || renderStep >= 0)
			{
				GUI.Label(titlePosition, titleTextCurrent, textTitleStyle);
			}
			versionPosition.x = Screen.width - 250;
			versionPosition.y = Screen.height - 50;
			if (!isRenderingRows)
			{
				int fontSize = GUI.skin.label.fontSize;
				GUI.skin.label.fontSize = 16;
				GUI.Label(versionPosition, versionInfo);
				GUI.skin.label.fontSize = fontSize;
			}
			Vector2 mousePosition = Event.current.mousePosition;
			if (!isRenderingRows && mouseIsDown)
			{
				mousePosition = mouseDownCoords;
			}
			Rect lastRect;
			DrawMenuItemsText(mousePosition, out lastRect);
			if (!isRenderingRows || renderStep >= 2)
			{
				lastRect.x = 100f;
				lastRect.y += 80f;
				lastRect.width = 180f;
				GUI.Label(lastRect, "Input Selection:", inputStyle);
				if (string.IsNullOrEmpty(cursorInputCharacter))
				{
					if (isCursorEnabled && isShowingCursor)
					{
						cursorRect.x = lastRect.x + lastRect.width;
						cursorRect.y = lastRect.y;
						GUI.Label(cursorRect, "_", inputStyle);
					}
				}
				else
				{
					cursorRect.x = lastRect.x + lastRect.width;
					cursorRect.y = lastRect.y;
					GUI.Label(cursorRect, cursorInputCharacter, inputStyle);
				}
			}
			if (GlobalSettings.cheatMode)
			{
				cheatWindowRect.x = Screen.width / 4 * 3;
				cheatWindowRect.y = (float)(Screen.height / 2) - 150f;
				GUI.Window(27, cheatWindowRect, DrawCheatMenuWindow, "Cheat Menu");
			}
			RenderTexture.active = null;
		}
		else if (!string.IsNullOrEmpty(InactiveText))
		{
			if (screenRt != null)
			{
				RenderTexture.active = screenRt;
			}
			inactiveRect.y = (float)Screen.height * 0.66f;
			inactiveRect.width = Screen.width;
			GUI.skin.label.fontSize = 40;
			GUI.skin.label.normal.textColor = Color.white;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(inactiveRect, InactiveText);
			inactiveRect.y += 50f;
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.normal.textColor = GlobalSettings.Constants.LIGHT_GRAY;
			GUI.Label(inactiveRect, InactiveTextAdditional);
			GUI.skin.label.fontSize = 12;
			GUI.skin.label.normal.textColor = Color.white;
			RenderTexture.active = null;
		}
		if (postGUIDraw != null)
		{
			postGUIDraw();
		}
	}

	protected virtual void DrawCheatMenuWindow(int id)
	{
	}

	private void DrawMenuItemsText(Vector2 mouseCoords)
	{
		Rect lastRect;
		DrawMenuItemsText(mouseCoords, out lastRect);
	}

	private void DrawMenuItemsText(Vector2 mouseCoords, out Rect lastRect)
	{
		lastRect = default(Rect);
		int count = menuItems.Count;
		if (isRenderingRows)
		{
			count = renderMenuItemIdx;
		}
		string text = string.Empty;
		bool flag = false;
		for (int i = 0; i < count; i++)
		{
			DuskersMenuItem duskersMenuItem = menuItems[i];
			if (duskersMenuItem.Hidden)
			{
				continue;
			}
			lastRect = duskersMenuItem.WindowRect;
			Color color = GlobalSettings.Constants.CONSOLE_GREEN;
			if (duskersMenuItem.MenuIndex == currentMenuItem)
			{
				if (!isRenderingRows)
				{
					highlightRect.x = duskersMenuItem.WindowRect.x - 2f;
					highlightRect.y = duskersMenuItem.WindowRect.y - 5f;
					highlightRect.width = duskersMenuItem.TextWidth + 5f;
					highlightRect.height = duskersMenuItem.WindowRect.height + 3f;
					color = Color.black;
				}
				text = duskersMenuItem.Description;
			}
			if (!flag && !string.IsNullOrEmpty(duskersMenuItem.Description))
			{
				flag = true;
			}
			Color white = Color.white;
			if (mouseIsDown)
			{
				white = Color.gray;
			}
			textStyle.normal.textColor = ((duskersMenuItem.MenuIndex != currentMenuItem && duskersMenuItem.OverridenColor.a != 0f) ? duskersMenuItem.OverridenColor : color);
			GUI.Label(duskersMenuItem.WindowRect, duskersMenuItem.Label, textStyle);
			if (duskersMenuItem.MenuType == DuskersMenuItem.MenuTypeEnum.Slider)
			{
				Rect windowRect = duskersMenuItem.WindowRect;
				windowRect.x += duskersMenuItem.TextWidth + 10f;
				windowRect.y -= 3f;
				windowRect.width = 200f;
				windowRect.height = 18f;
				windowRect.width = 200f * (duskersMenuItem.SliderValue * duskersMenuItem.SliderValueFactor);
				windowRect.height = 18f;
			}
			else if (duskersMenuItem.MenuType == DuskersMenuItem.MenuTypeEnum.MultiItemSlider)
			{
				Rect windowRect2 = duskersMenuItem.WindowRect;
				windowRect2.x += duskersMenuItem.TextWidth + 10f;
				windowRect2.width = 200f;
				windowRect2.height = 20f;
				if (!isRenderingRows)
				{
					textStyle.normal.textColor = ((duskersMenuItem.MenuIndex != currentMenuItem) ? Color.gray : Color.white);
				}
				else
				{
					textStyle.normal.textColor = Color.gray;
				}
				GUI.Label(windowRect2, duskersMenuItem.TextValue, textStyle);
			}
		}
		if (flag)
		{
			lastRect.y += 40f;
			if (!isRenderingRows && !string.IsNullOrEmpty(text))
			{
				textStyle.normal.textColor = Color.gray;
				lastRect.width *= 3f;
				GUI.Label(lastRect, text, textStyle);
				lastRect.width /= 3f;
			}
			lastRect.y -= 20f;
		}
		textStyle.normal.textColor = GlobalSettings.Constants.CONSOLE_GREEN;
	}

	private void CheckForMenuClick(Vector2 mouseUpCoords, Vector2 mouseDownCoords)
	{
		foreach (DuskersMenuItem menuItem in menuItems)
		{
			if (menuItem.WindowRect.Contains(mouseUpCoords) && menuItem.WindowRect.Contains(mouseDownCoords))
			{
				if (menuItem.SelectAction != null)
				{
					menuItem.SelectAction();
				}
				else
				{
					Debug.LogWarning("Nothing to execute.  No menu action defined for: " + menuItem.Label);
				}
			}
		}
	}

	protected void CalculateMenuItemMetrics()
	{
		float num = 0f;
		num = 150f;
		float num2 = 200f;
		foreach (DuskersMenuItem menuItem in menuItems)
		{
			if (!menuItem.Hidden)
			{
				menuItem.TextWidth = textStyle.CalcSize(new GUIContent(menuItem.Label)).x;
				num2 += menuItem.TopMargin;
				menuItem.WindowRect = new Rect(num, num2, 350f, 20f);
				num2 += 23f;
			}
		}
	}

	protected virtual void MenuCancel()
	{
		if (PreviousMenuScreen != null)
		{
			PreviousMenuScreen.Enable();
		}
		else if (MenuBackground.Instance != null)
		{
			MenuBackground.Instance.gameObject.SetActive(false);
		}
		UnityEngine.Object.Destroy(this);
	}

	public void Disable()
	{
		Disable(false);
	}

	public void Disable(bool useDelayedDisable)
	{
		Inactive = true;
		if (useDelayedDisable)
		{
			firstInactiveLoop = true;
		}
	}

	public virtual void Enable()
	{
		isRenderingRows = true;
		renderStep = -1;
		renderMenuItemIdx = -1;
		timerDelayBetweenRows = 0.075f;
		Inactive = false;
		cursorInputCharacter = string.Empty;
	}

	public void ExternalClose()
	{
		MenuCancel();
	}

	private void EnableCursor()
	{
		isCursorEnabled = true;
		isShowingCursor = true;
		timerCursorBlink = 0.2f;
	}

	private void DisableCursor()
	{
		isCursorEnabled = false;
	}

	protected virtual void PostRenderMenuItems()
	{
	}
}
