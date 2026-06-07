using System;
using UnityEngine;

public class Buzzer : BaseComponentView
{
	private LogicIO activeInput;

	private LogicIO volumeInput;

	private LogicIO pitchInput;

	private bool isToggleMode;

	private bool isToggleChanged;

	private bool isBuzzerActive;

	public event Action<bool, float, float, float> OnBuzzerActiveEvent;

	private void Update()
	{
		float num = activeInput.ReadAnalogSignal();
		float arg = volumeInput.ReadAnalogSignal();
		float arg2 = Mathf.Clamp(pitchInput.ReadAnalogSignal(), 0f, 2f);
		if (isToggleMode)
		{
			if (num >= 0.5f)
			{
				if (!isToggleChanged)
				{
					isBuzzerActive = !isBuzzerActive;
					isToggleChanged = true;
				}
			}
			else
			{
				isToggleChanged = false;
			}
			num = (isBuzzerActive ? 1f : 0f);
		}
		else
		{
			isBuzzerActive = num > 0f;
		}
		this.OnBuzzerActiveEvent?.Invoke(isBuzzerActive, num, arg, arg2);
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		int propertyAsInt = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("buzzer_btn_type");
		isToggleMode = propertyAsInt != 0;
		isToggleChanged = false;
		isBuzzerActive = false;
		float propertyAsFloat = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("buzzer_volume", 1f);
		float propertyAsFloat2 = base.BlockBodyView.OverridableProperties.GetPropertyAsFloat("buzzer_pitch", 1f);
		volumeInput.SetSignal(propertyAsFloat);
		pitchInput.SetSignal(propertyAsFloat2);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		base.gameObject.AddComponent<BuzzerStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("buzzer_active", LogicIODirection.Input, 0f));
		volumeInput = base.BlockBodyView.AddLogicIO(new LogicIO("buzzer_volume_input", LogicIODirection.Input, 0f)
		{
			IsInputWithoutKey = true
		});
		pitchInput = base.BlockBodyView.AddLogicIO(new LogicIO("buzzer_pitch_input", LogicIODirection.Input, 0f)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		this.OnBuzzerActiveEvent?.Invoke(arg1: false, 0f, 1f, 1f);
	}

	public override string GetComponentName()
	{
		return typeof(Buzzer).Name;
	}
}
