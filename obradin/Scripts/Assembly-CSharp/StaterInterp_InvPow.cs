using UnityEngine;

public class StaterInterp_InvPow : StaterInterp
{
	private float pow;

	public StaterInterp_InvPow(float pow_)
	{
		pow = pow_;
	}

	public override float InterpImpl(float interp)
	{
		return 1f - Mathf.Pow(1f - interp, pow);
	}
}
