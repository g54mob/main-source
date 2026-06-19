public class RadicalPauseMenuOption_ExitToTitle : RadicalPauseMenuOption
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.load.ExitGame();
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		if (Manager.ecs.ServerWorld == null)
		{
			labelText.Render("exit");
		}
		else
		{
			labelText.Render("saveAndExit");
		}
	}
}
