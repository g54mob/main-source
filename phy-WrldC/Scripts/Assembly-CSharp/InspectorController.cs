public class InspectorController : BaseController<InspectorView>
{
	public InspectorController(InspectorView view)
		: base(view)
	{
		view.SetColorPresets(GameManager.Instance.LEOptionsModel.ColorPresets);
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "InspectorView.ColorPresetsChangedEvent")
		{
			GameManager.Instance.LEOptionsModel.ColorPresets = view.GetColorPresets();
			GameManager.Instance.LEOptionsModel.SaveValuesOnDisk();
		}
	}
}
