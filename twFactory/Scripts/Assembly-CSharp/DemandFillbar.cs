using UnityEngine;

public class DemandFillbar : FillBar
{
	[SerializeField]
	private Gradient colorGradient;

	public override void SetBarValue(float value)
	{
		base.SetBarValue(value);
		barImage.color = colorGradient.Evaluate(value);
	}
}
