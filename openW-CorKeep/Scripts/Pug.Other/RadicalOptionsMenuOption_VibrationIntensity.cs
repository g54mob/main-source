using System.Text;
using UnityEngine;

public class RadicalOptionsMenuOption_VibrationIntensity : RadicalPauseMenuOption
{
	[SerializeField]
	private int NUMBER_OF_STEPS = 10;

	[SerializeField]
	private float MAX_INTENSITY = 1f;

	public float vibrationLengthWhenOptionChanged = 0.5f;

	private float STEP_SIZE => MAX_INTENSITY / (float)NUMBER_OF_STEPS;

	private float _vibrationIntensity => Manager.prefs.vibrationIntensity;

	private bool _isVibrationEnabled => Manager.prefs.vibration;

	private void Start()
	{
		UpdateText(_isVibrationEnabled ? _vibrationIntensity : 0f, rumble: false);
	}

	public override void OnActivated()
	{
		Manager.prefs.vibration = !_isVibrationEnabled;
		UpdateText(Manager.prefs.vibration ? _vibrationIntensity : 0f, Manager.prefs.vibration);
		base.OnActivated();
	}

	private bool OnSkimDelta(int delta)
	{
		SetIntensity(Mathf.RoundToInt(_vibrationIntensity / MAX_INTENSITY * (float)NUMBER_OF_STEPS) + delta);
		return true;
	}

	public override bool OnSkimRight()
	{
		return OnSkimDelta(1);
	}

	public override bool OnSkimLeft()
	{
		return OnSkimDelta(-1);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		PreSelect(Mathf.RoundToInt(_vibrationIntensity * STEP_SIZE));
	}

	public void PreSelect(int value)
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = ((value > i) ? PugTextEffectMenuOption.SELECTED_VALUE_COLOR : PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR);
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		ResetPreSelected();
	}

	public void ResetPreSelected()
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		}
	}

	public void SetIntensity(int value)
	{
		float num = Mathf.Clamp((float)value * STEP_SIZE, 0f, MAX_INTENSITY);
		Manager.prefs.vibrationIntensity = num;
		Manager.prefs.vibration = num != 0f;
		UpdateText(num, _isVibrationEnabled);
		PreSelect(value);
	}

	private void UpdateText(float intensity, bool rumble = true)
	{
		int num = Mathf.RoundToInt(intensity / MAX_INTENSITY * (float)NUMBER_OF_STEPS);
		StringBuilder preallocatedStringBuilder = Manager.memory.preallocatedStringBuilder;
		preallocatedStringBuilder.Clear();
		for (int i = 0; i < NUMBER_OF_STEPS; i++)
		{
			preallocatedStringBuilder.Append((i < num) ? '♦' : '♢');
		}
		valueText.Render(preallocatedStringBuilder.ToString());
		if (rumble)
		{
			Manager.input.singleplayerInputModule.RumbleNow(vibrationLengthWhenOptionChanged);
		}
	}
}
