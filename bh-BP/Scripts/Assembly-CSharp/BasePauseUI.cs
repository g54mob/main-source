using I2.Loc;

public class BasePauseUI : OverlayUI
{
	public static BasePauseUI I;

	public CoolButton BtnResume;

	public CoolButton BtnEncyclopedia;

	public CoolButton BtnSettings;

	public CoolButton BtnMainMenu;

	public Localize LocMainMenu;

	public CoolButton BtnDiscord;

	public CoolButton BtnQuit;

	public CoolButton BtnAch;

	public LocalizationParamsManager ParamsEventDemoTime;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	public override void Deactivate()
	{
	}

	private void OnResumeClicked()
	{
	}

	private void OnSettingsClicked()
	{
	}

	private void OnEncyclopediaClicked()
	{
	}

	private void OnClearClicked()
	{
	}

	private void OnClearConfirmed()
	{
	}

	private void OnMainMenuClicked()
	{
	}

	private void OnMainMenuConfirmed()
	{
	}

	private void OnQuitClicked()
	{
	}

	private void OnQuitConfirmed()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnDiscordClicked()
	{
	}
}
