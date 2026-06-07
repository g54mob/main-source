public class StaterInterp_Smoothstep : StaterInterp
{
	private float e0;

	private float e1;

	public StaterInterp_Smoothstep(float e0_, float e1_)
	{
		e0 = e0_;
		e1 = e1_;
	}

	public override float InterpImpl(float interp)
	{
		return Util.SmoothStepEdges(e0, e1, interp);
	}
}
