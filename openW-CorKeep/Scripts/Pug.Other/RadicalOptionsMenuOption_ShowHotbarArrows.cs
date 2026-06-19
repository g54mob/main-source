public class RadicalOptionsMenuOption_ShowHotbarArrows : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.ShowHotbarArrows);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.ShowHotbarArrows;
		Manager.prefs.ShowHotbarArrows = flag;
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
		return Manager.prefs.ShowHotbarArrows;
	}
}
