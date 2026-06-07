public class LEManualController : BaseController<LEManualView>
{
	public LEManualController(LEManualView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "LEManualView.CloseButtonEvent")
		{
			GameManager.Instance.ExitSubState();
		}
	}
}
