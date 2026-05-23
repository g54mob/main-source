public class StaterInterp_Step : StaterInterp
{
	private float mid;

	public StaterInterp_Step(float mid_)
	{
		mid = mid_;
	}

	public override float InterpImpl(float interp)
	{
		return (!(interp < mid)) ? 1f : 0f;
	}
}
