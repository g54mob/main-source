public class StaterInterp_RiseFall : StaterInterp
{
	private float mid;

	public StaterInterp_RiseFall(float mid_)
	{
		mid = mid_;
	}

	public override float InterpImpl(float interp)
	{
		if (interp < mid)
		{
			return Util.LerpScale(interp, 0f, mid, 0f, 1f);
		}
		return Util.LerpScale(interp, mid, 1f, 1f, 0f);
	}
}
