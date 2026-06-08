public class UtilityBeltUI : AsciiObject
{
	private readonly int BUTTON_COUNT = 6;

	private readonly float LERP_SPEED = 10f;

	public AsciiSprite backgroundStrip;

	public AsciiSprite selectionFrame;

	public AsciiSprite questionMark;

	public DialogButton openCloseButton;

	public DialogButton loadoutButtonPrototype;

	private DialogButton[] loadoutButtons;

	private bool currentState;

	private float f_offsetX;

	private float f_targetX;

	private AsciiRenderProcedural.Clip clip;

	public int displayedWidth { get; private set; }

	public static UtilityBeltUI singleton { get; private set; }

	public void Show()
	{
		SetState(newState: true);
	}

	public void Hide()
	{
		SetState(newState: false);
	}

	private void SetState(bool newState)
	{
		if (newState)
		{
			UtilityBeltKeyShortcuts.singleton.CheckUserInterfaceFTUE();
			f_targetX = loadoutButtonPrototype.Width;
			openCloseButton.label.SetValue("»");
		}
		else
		{
			f_targetX = 0f;
			openCloseButton.label.SetValue("«");
		}
		currentState = newState;
	}

	public override void UpdateTic()
	{
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (loadoutButtons != null)
		{
			GameStates gameStates = GameStates.Singleton;
			if (gameStates.CurrentState >= GameStates.State.Playing && gameStates.CurrentState != GameStates.State.PlayItemScreen)
			{
				_ = gameStates.level.QuestData?.hideHUD;
			}
		}
	}

	private void HandleOpenCloseButtonPressed(DialogButton btn)
	{
		SetState(!currentState);
	}

	private void HandleLoadoutButtonPressed(DialogButton btn)
	{
		int num = 0;
		for (int i = 1; i < BUTTON_COUNT; i++)
		{
			if (btn == loadoutButtons[i])
			{
				num = i;
				break;
			}
		}
		UtilityBeltKeyShortcuts.singleton.RecallLoadout(num + 1);
	}

	private void Start()
	{
	}

	private void Awake()
	{
		singleton = this;
	}
}
