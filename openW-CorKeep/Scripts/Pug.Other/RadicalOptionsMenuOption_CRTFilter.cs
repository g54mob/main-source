public class RadicalOptionsMenuOption_CRTFilter : RadicalMenuOption
{
	private static string[] options = new string[3] { "off", "Menu/Simulated", "Menu/Emulated" };

	public override void OnParentMenuActivation()
	{
		SetLevel(Manager.prefs.crtFilter);
		base.OnParentMenuActivation();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		OptionActiveState optionActiveState = base.GetActiveStateInCurrentScene();
		if (optionActiveState == OptionActiveState.ACTIVE && !Manager.prefs.integerScaling)
		{
			optionActiveState = OptionActiveState.GRAYED_OUT;
		}
		return optionActiveState;
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
		SetLevel(Manager.prefs.crtFilter + amount);
	}

	private void SetLevel(int level)
	{
		Manager.prefs.crtFilter = (level + options.Length) % options.Length;
		UpdateText(Manager.prefs.crtFilter);
	}

	private void UpdateText(int value)
	{
		valueText.Render(options[value]);
	}
}
