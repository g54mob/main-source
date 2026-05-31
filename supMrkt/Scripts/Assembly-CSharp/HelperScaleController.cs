public class HelperScaleController : ScaleController
{
	public CustomerHelper Helper;

	public HelperScaleController(Scale scale, CustomerHelper helper)
		: base(null)
	{
	}

	public override void OnStateIdle()
	{
	}

	public override void OnStateControl()
	{
	}

	public override void OnStateBarcode()
	{
	}

	public override void OnStatePlacement()
	{
	}
}
