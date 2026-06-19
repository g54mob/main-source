public class RadicalOptionsMenuOption_RGBEffects : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.useRGBEffects);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.useRGBEffects;
		Manager.prefs.useRGBEffects = flag;
		UpdateText(flag);
	}

	public override bool OnSkimRight()
	{
		return OnSkimLeft();
	}

	public override bool OnSkimLeft()
	{
		OnActivated();
		return true;
	}

	private void UpdateText(bool value)
	{
		valueText.Render(value ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.useRGBEffects;
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!Manager.rgb.IsAvailable)
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}
}
