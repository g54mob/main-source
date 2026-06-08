using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelUI : MonoBehaviour
{
	public delegate void SimpleDelegate();

	private const float DELAY_ROW = 0.075f;

	public static MenuPanelUI Instance;

	public Text titleLabel;

	public Text versionLabel;

	public Text cursorLabel;

	public UIMenuColumn textMenuColumn;

	public UIMenuColumn valueMenuColumn;

	public GameObject inputPanelObject;

	public Text commentsLabel;

	public Image backgroundImage;

	private List<DuskersMenuItem> menuItems;

	private HelpManual _helpManualWindow;

	private bool isRenderingRows;

	private float timerDelayBetweenRows;

	private bool firstInactiveLoop;

	private bool hasBeginSelect;

	private Action postSelectAction;

	private bool sliderFirstSlide;

	private float timerSlide;

	private bool isCursorEnabled;

	private bool delayUntilResumeBlink;

	private float timerCursorBlink;

	private float timerUntilResume;

	private int renderStep = -1;

	private int renderMenuItemIdx = -1;

	private List<MenuScreenClass> screenStack;

	private DuskersMenuItem cancelItem;

	private bool autoFullScreen;

	private float timerTillFullScreen;

	public SimpleDelegate finalSetInactive { get; set; }

	public bool IgnoreCancel { get; set; }

	public bool Inactive { get; private set; }

	public string titleTextFinal { get; set; }

	private void Awake()
	{
		Instance = this;
		ResourceManager.OneTimeBackgroundLoad();
		if (backgroundImage != null)
		{
			backgroundImage.enabled = false;
		}
	}

	private void Start()
	{
		versionLabel.text = string.Format("{0} v {1}", string.Empty.ToString(), 1.041f.ToString("0.00#"));
		_helpManualWindow = new HelpManual();
		if (SteamCore.Instance != null)
		{
			SteamCore instance = SteamCore.Instance;
			instance.overlayToggled = (SteamCore.ScreenShownToggle)Delegate.Combine(instance.overlayToggled, new SteamCore.ScreenShownToggle(SteamOverlayToggle));
		}
	}

	private void OnDestroy()
	{
		titleLabel = null;
		versionLabel = null;
		cursorLabel = null;
		inputPanelObject = null;
		commentsLabel = null;
		backgroundImage = null;
	}

	public void Reset()
	{
		renderStep = -1;
		renderMenuItemIdx = -1;
		isRenderingRows = true;
		timerDelayBetweenRows = 0.075f;
		cursorLabel.text = "_";
		commentsLabel.text = string.Empty;
		inputPanelObject.SetActive(false);
		versionLabel.gameObject.SetActive(false);
		EnableCursor();
	}

	public void AddMenuItem(DuskersMenuItem menuItem)
	{
		if (menuItems == null)
		{
			menuItems = new List<DuskersMenuItem>();
		}
		menuItems.Add(menuItem);
		if (menuItem != null)
		{
			textMenuColumn.AddMenuItem(menuItem);
			if (menuItem.MenuType != DuskersMenuItem.MenuTypeEnum.Standard)
			{
				valueMenuColumn.AddMenuItem(menuItem);
			}
			else
			{
				valueMenuColumn.AddEmptyItem();
			}
		}
		else
		{
			textMenuColumn.AddEmptyItem(true);
			valueMenuColumn.AddEmptyItem(true);
		}
	}

	public void RemoveCancelMenu()
	{
		if (cancelItem != null)
		{
			textMenuColumn.RemoveItem(cancelItem);
			valueMenuColumn.RemoveItem(cancelItem);
			menuItems.Remove(cancelItem);
		}
	}

	public void Update()
	{
		if (firstInactiveLoop)
		{
			firstInactiveLoop = false;
			if (finalSetInactive != null)
			{
				finalSetInactive();
			}
		}
		if (autoFullScreen)
		{
			timerTillFullScreen -= Time.deltaTime;
			if (timerTillFullScreen <= 0f)
			{
				autoFullScreen = false;
				Screen.fullScreen = true;
			}
		}
		if (delayUntilResumeBlink)
		{
			timerUntilResume -= Time.deltaTime;
			if (timerUntilResume <= 0f)
			{
				timerUntilResume = 0f;
				delayUntilResumeBlink = false;
				cursorLabel.text = "_";
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
						cursorLabel.text = "_";
					}
				}
				else
				{
					cursorLabel.text = "_";
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
				if (Inactive || screenStack == null)
				{
					return;
				}
				screenStack[screenStack.Count - 1].Update();
				bool flag = false;
				bool flag2 = false;
				int count = menuItems.Count;
				for (int i = 0; i < count && i < menuItems.Count; i++)
				{
					DuskersMenuItem duskersMenuItem = menuItems[i];
					if (duskersMenuItem == null || duskersMenuItem.Hidden || duskersMenuItem.Disabled)
					{
						continue;
					}
					textMenuColumn.RefreshItemColor(i);
					switch (duskersMenuItem.MenuType)
					{
					case DuskersMenuItem.MenuTypeEnum.Standard:
					{
						bool flag3 = false;
						if (Input.GetKeyDown(duskersMenuItem.ShortcutKey))
						{
							textMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
							valueMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
							hasBeginSelect = true;
							if (duskersMenuItem.SelectAction != null)
							{
								postSelectAction = duskersMenuItem.SelectAction;
								flag3 = true;
							}
							else
							{
								Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
							}
							flag = true;
						}
						else if (textMenuColumn.HighlightedIndex == duskersMenuItem.MenuIndex && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
						{
							if (!menuItems[textMenuColumn.HighlightedIndex].Disabled)
							{
								if (menuItems[textMenuColumn.HighlightedIndex].SelectAction != null)
								{
									menuItems[textMenuColumn.HighlightedIndex].SelectAction();
									flag3 = true;
								}
								else
								{
									Debug.LogWarning("Nothing to execute.  No menu action defined for: " + menuItems[textMenuColumn.HighlightedIndex].Label);
								}
							}
							else
							{
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						if (flag3)
						{
							cursorLabel.text = duskersMenuItem.ShortcutKey.ToString().ToLower();
							cursorLabel.gameObject.SetActive(true);
							valueMenuColumn.RefreshItem(textMenuColumn.HighlightedIndex);
							Input.ResetInputAxes();
						}
						break;
					}
					case DuskersMenuItem.MenuTypeEnum.Slider:
						if (Input.GetKeyDown(duskersMenuItem.ShortcutKey))
						{
							if (!menuItems[textMenuColumn.HighlightedIndex].Disabled)
							{
								textMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
								valueMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
								cursorLabel.text = duskersMenuItem.ShortcutKey.ToString().ToLower();
								delayUntilResumeBlink = true;
								timerUntilResume = 0.1f;
								cursorLabel.gameObject.SetActive(true);
								flag = true;
							}
							else
							{
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							if (textMenuColumn.HighlightedIndex != duskersMenuItem.MenuIndex)
							{
								break;
							}
							bool flag4 = false;
							if (!sliderFirstSlide)
							{
								flag4 = true;
							}
							else
							{
								timerSlide -= Time.deltaTime;
								if (timerSlide <= 0f)
								{
									timerSlide = 0f;
									flag4 = true;
								}
							}
							if (!flag4)
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
									valueMenuColumn.RefreshItem(textMenuColumn.HighlightedIndex, duskersMenuItem.SliderValue * duskersMenuItem.SliderValueFactor);
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
									valueMenuColumn.RefreshItem(textMenuColumn.HighlightedIndex, duskersMenuItem.SliderValue * duskersMenuItem.SliderValueFactor);
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
						if (Input.GetKeyDown(duskersMenuItem.ShortcutKey) || (textMenuColumn.HighlightedIndex == duskersMenuItem.MenuIndex && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))))
						{
							if (!menuItems[textMenuColumn.HighlightedIndex].Disabled)
							{
								textMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
								valueMenuColumn.HighlightBar(duskersMenuItem.MenuIndex);
								if (duskersMenuItem.SelectAction != null)
								{
									duskersMenuItem.SelectAction();
								}
								else
								{
									Debug.LogWarning("Nothing to execute.  No menu action defined for: " + duskersMenuItem.Label);
								}
								valueMenuColumn.RefreshItem(textMenuColumn.HighlightedIndex);
								cursorLabel.text = duskersMenuItem.ShortcutKey.ToString().ToLower();
								delayUntilResumeBlink = true;
								timerUntilResume = 0.1f;
								cursorLabel.gameObject.SetActive(true);
								flag = true;
							}
							else
							{
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							if (textMenuColumn.HighlightedIndex != duskersMenuItem.MenuIndex)
							{
								break;
							}
							if ((duskersMenuItem.ShortcutKeyIncrease != KeyCode.None && Input.GetKeyDown(duskersMenuItem.ShortcutKeyIncrease)) || Input.GetButtonDown(duskersMenuItem.ShortcutKeyIncreaseMappedKey))
							{
								if (!menuItems[textMenuColumn.HighlightedIndex].Disabled)
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
								else
								{
									GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
								}
							}
							else if ((duskersMenuItem.ShortcutKeyDecrease != KeyCode.None && Input.GetKeyDown(duskersMenuItem.ShortcutKeyDecrease)) || Input.GetButtonDown(duskersMenuItem.ShortcutKeyDecreaseMappedKey))
							{
								if (!menuItems[textMenuColumn.HighlightedIndex].Disabled)
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
								else
								{
									GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
								}
							}
							else if (sliderFirstSlide)
							{
								sliderFirstSlide = false;
								timerSlide = 0f;
							}
							if (flag2)
							{
								valueMenuColumn.RefreshItem(textMenuColumn.HighlightedIndex);
							}
						}
						break;
					}
				}
				if (!flag)
				{
					if (Input.GetButtonDown("Up"))
					{
						textMenuColumn.MoveUp();
						valueMenuColumn.MoveUp();
					}
					else if (Input.GetButtonDown("Down"))
					{
						textMenuColumn.MoveDown();
						valueMenuColumn.MoveDown();
					}
					else if (!IgnoreCancel && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace)))
					{
						MenuCancel();
					}
					else if (!flag && !flag2 && Input.anyKeyDown && !sliderFirstSlide && (cursorLabel.text == string.Empty || cursorLabel.text == "_") && !CommonMethods.ControlKeyIsBeingPressed() && !Input.GetKeyDown(KeyCode.LeftAlt) && !Input.GetKeyDown(KeyCode.RightAlt) && !Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.RightShift))
					{
						CommonAudioHelper.Instance.PlayErrorSound();
					}
				}
				if (isCursorEnabled && cursorLabel.text == "_")
				{
					timerCursorBlink -= Time.deltaTime;
					if (timerCursorBlink <= 0f)
					{
						timerCursorBlink = 0.2f;
						cursorLabel.gameObject.SetActive(!cursorLabel.gameObject.activeSelf);
					}
				}
			}
			return;
		}
		cursorLabel.text = "_";
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
			else
			{
				textMenuColumn.ShowItem(renderMenuItemIdx);
				valueMenuColumn.ShowItem(renderMenuItemIdx);
			}
		}
		if (renderStep > 2)
		{
			isRenderingRows = false;
			textMenuColumn.MoveToTop();
			valueMenuColumn.MoveToTop();
			inputPanelObject.SetActive(true);
			versionLabel.gameObject.SetActive(true);
		}
		else
		{
			timerDelayBetweenRows = 0.075f;
		}
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

	public void Enable()
	{
		Inactive = false;
		cursorLabel.text = "_";
	}

	public void Clear()
	{
		textMenuColumn.ClearItems();
		valueMenuColumn.ClearItems();
		IgnoreCancel = false;
		if (menuItems != null)
		{
			menuItems.Clear();
		}
	}

	public void RefreshAllValues()
	{
		int count = menuItems.Count;
		for (int i = 0; i < count; i++)
		{
			DuskersMenuItem duskersMenuItem = menuItems[i];
			if (duskersMenuItem != null && !duskersMenuItem.Hidden)
			{
				if (duskersMenuItem.MenuType == DuskersMenuItem.MenuTypeEnum.Slider)
				{
					valueMenuColumn.RefreshItem(i, duskersMenuItem.SliderValue * duskersMenuItem.SliderValueFactor);
				}
				else
				{
					valueMenuColumn.RefreshItem(i);
				}
			}
		}
	}

	public void PushMenu(MenuScreenClass menuScreenClass)
	{
		if (screenStack == null)
		{
			screenStack = new List<MenuScreenClass>();
		}
		if (screenStack.Count == 0 || screenStack[screenStack.Count - 1] != menuScreenClass)
		{
			screenStack.Add(menuScreenClass);
		}
		titleLabel.text = menuScreenClass.ActiveText;
		IgnoreCancel = menuScreenClass.IgnoreCancel;
		if (!IgnoreCancel)
		{
			AddMenuItem(null);
			cancelItem = new DuskersMenuItem("[B]ack", KeyCode.B, MenuCancel, menuItems.Count);
			AddMenuItem(cancelItem);
		}
		cursorLabel.text = "_";
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
		}
		backgroundImage.enabled = !menuScreenClass.HideBackground;
	}

	private void PushNextInStack()
	{
		if (screenStack != null && screenStack.Count > 0)
		{
			Clear();
			Reset();
			screenStack[screenStack.Count - 1].LoadMenu();
		}
	}

	public void PopMenu(MenuScreenClass menu)
	{
		int count = screenStack.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (screenStack[num] == menu)
			{
				PopMenu(num);
				if (screenStack.Count > 0)
				{
					PushNextInStack();
				}
				else
				{
					CloseMenu();
				}
				break;
			}
		}
	}

	public void PopMenu(int idx)
	{
		MenuScreenClass menuScreenClass = screenStack[idx];
		menuScreenClass.CancelMenu();
		screenStack.RemoveAt(idx);
	}

	protected virtual void MenuCancel()
	{
		PopMenu(screenStack.Count - 1);
		if (screenStack != null && screenStack.Count > 0)
		{
			PushNextInStack();
		}
		else
		{
			CloseMenu();
		}
	}

	private void CloseMenu()
	{
		Clear();
		base.gameObject.SetActive(false);
		backgroundImage.enabled = false;
	}

	private void EnableCursor()
	{
		isCursorEnabled = true;
		timerCursorBlink = 0.2f;
	}

	private void SteamOverlayToggle(bool isOn)
	{
		if (!isOn && Screen.fullScreen && GameSaveFile.Get("O_RFS", false))
		{
			Screen.fullScreen = false;
			autoFullScreen = true;
			timerTillFullScreen = 0.3f;
		}
	}
}
