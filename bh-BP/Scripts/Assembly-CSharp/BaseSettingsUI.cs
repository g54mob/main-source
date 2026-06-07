public class BaseSettingsUI : OverlayUI
{
	public static BaseSettingsUI I;

	public CoolButton BtnClose;

	public SettingsScreen Scrn;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnCloseClicked()
	{
	}
}
