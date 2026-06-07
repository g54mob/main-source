public class BlockVisualizationController : BaseController<BlockVisualizationView>
{
	public BlockVisualizationController(BlockVisualizationView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "BlockVisualizationView.CloseEvent")
		{
			GameManager.Instance.ChangeState(ConstructionState.Instance);
		}
	}
}
