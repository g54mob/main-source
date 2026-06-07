public class ManualController : BaseController<ManualView>
{
	public ManualController(ManualView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "ManualView.CloseButtonEvent")
		{
			GameManager.Instance.RevertToPreviousState();
		}
	}
}
