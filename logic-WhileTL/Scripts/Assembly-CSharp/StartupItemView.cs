using App.Data;

public class StartupItemView : ActiveComponent
{
	public Startup Data;

	protected override void OnInit()
	{
		base.OnInit();
	}

	public StartupItemView(Startup s)
	{
	}

	public void Redraw(Startup p)
	{
	}
}
