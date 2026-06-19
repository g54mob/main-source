public class RadicalOptionsMenuOption_Fullscreen : RadicalMenuOption
{
	private static string[] fullscreenOptions = new string[3] { "Menu/Windowed", "Menu/BorderlessFullscreen", "Menu/Fullscreen" };

	private void Start()
	{
		UpdateText(Manager.prefs.fullscreen);
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!Manager.platform.CanSetFullscreen)
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override bool OnSkimRight()
	{
		ChangeLevel(1);
		return true;
	}

	public override bool OnSkimLeft()
	{
		ChangeLevel(-1);
		return true;
	}

	private void ChangeLevel(int amount)
	{
		int num = Manager.prefs.fullscreen + amount;
		if (num < 0)
		{
			num = fullscreenOptions.Length - 1;
		}
		else if (num >= fullscreenOptions.Length)
		{
			num = 0;
		}
		Manager.prefs.fullscreen = num;
		UpdateText(num);
	}

	private void UpdateText(int option)
	{
		if (option >= fullscreenOptions.Length)
		{
			valueText.Clear();
		}
		else
		{
			valueText.Render(fullscreenOptions[option]);
		}
	}
}
