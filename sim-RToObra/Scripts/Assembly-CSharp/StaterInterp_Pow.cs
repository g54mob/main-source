using UnityEngine;

public class StaterInterp_Pow : StaterInterp
{
	private float pow;

	public StaterInterp_Pow(float pow_)
	{
		pow = pow_;
	}

	public override float InterpImpl(float interp)
	{
		return Mathf.Pow(interp, pow);
	}
}
