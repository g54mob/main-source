using System.Text;
using UnityEngine;

public class RadicalOptionsMenuOption_Brightness : RadicalPauseMenuOption
{
	private const int NUMBER_OF_STEPS = 10;

	private const float STEP_SIZE = 0.1f;

	private const float MAX_BRIGHTNESS = 0.5f;

	private float brightness => Manager.prefs.brightness;

	private void Start()
	{
		UpdateText();
	}

	private bool OnSkimDelta(int delta)
	{
		SetBrightness(Mathf.RoundToInt((brightness + 0.5f) / 0.1f) + delta);
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
		PreSelectBrightness(Mathf.RoundToInt((brightness + 0.5f) / 0.1f));
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		ResetPreSelectedBrightness();
	}

	public void SetBrightness(int value)
	{
		float num = Mathf.Clamp((float)(value - 5) * 0.1f, -0.5f, 0.5f);
		Manager.prefs.brightness = num;
		UpdateText();
		PreSelectBrightness(value);
	}

	public void PreSelectBrightness(int value)
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = ((value > i) ? PugTextEffectMenuOption.SELECTED_VALUE_COLOR : PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR);
		}
	}

	public void ResetPreSelectedBrightness()
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		}
	}

	public void UpdateText()
	{
		int num = Mathf.RoundToInt((brightness + 0.5f) * 10f);
		StringBuilder preallocatedStringBuilder = Manager.memory.preallocatedStringBuilder;
		preallocatedStringBuilder.Clear();
		for (int i = 0; i < 10; i++)
		{
			preallocatedStringBuilder.Append((i < num) ? '♦' : '♢');
		}
		valueText.Render(preallocatedStringBuilder.ToString());
	}
}
