using System.Collections.Generic;
using UnityEngine;

public class MenuScreenClass
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

	protected List<DuskersMenuItem> cheatMenuItems = new List<DuskersMenuItem>();

	private float titleCharacterTimer;

	private Vector2 mouseDownCoords = Vector2.zero;

	private string gameStateValue = string.Empty.ToString();

	private string versionValue = 1.041f.ToString("0.00#");

	private HelpManual _helpManualWindow;

	private Rect cursorRect = new Rect(0f, 0f, 20f, 20f);

	public bool IsLoaded { get; private set; }

	public bool IgnoreCancel { get; set; }

	public bool HideBackground { get; set; }

	public bool Inactive { get; private set; }

	public object MenuData { get; private set; }

	public MenuScreen PreviousMenuScreen { get; set; }

	protected SimpleDelegate postGUIDraw { get; set; }

	protected SimpleDelegate finalSetInactive { get; set; }

	public string ActiveText { get; protected set; }

	protected string InactiveText { get; set; }

	protected string InactiveTextAdditional { get; set; }

	public MenuScreenClass()
		: this(null)
	{
	}

	public MenuScreenClass(object data)
	{
		MenuData = data;
		MenuPanelUI.Instance.Reset();
		Initialize();
		LoadMenu();
	}

	protected virtual void Initialize()
	{
	}

	public virtual void LoadMenu()
	{
		MenuPanelUI.Instance.PushMenu(this);
		IsLoaded = true;
	}

	public virtual void Update()
	{
	}

	public virtual void CancelMenu()
	{
		IsLoaded = false;
	}

	public void ExternalClose()
	{
	}
}
