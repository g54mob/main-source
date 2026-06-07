using UnityEngine;

[RequireComponent(typeof(SimpleMotor))]
public class SimpleMotorStylesApplier : StylesApplierBase
{
	private SimpleMotorAudioEffect simpleMotorAudio;

	public override void Initialize()
	{
		if (simpleMotorAudio == null)
		{
			simpleMotorAudio = base.gameObject.AddComponent<SimpleMotorAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		simpleMotorAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
