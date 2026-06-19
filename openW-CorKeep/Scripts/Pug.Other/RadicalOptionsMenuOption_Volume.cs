using System.Text;
using UnityEngine;

public class RadicalOptionsMenuOption_Volume : RadicalPauseMenuOption
{
	public enum VolumeType
	{
		SFX = 0,
		MUSIC = 1,
		AMBIENT = 2,
		INSTRUMENTS = 3,
		MASTER = 4
	}

	private const int NUMBER_OF_STEPS = 8;

	private const float STEP_SIZE = 0.125f;

	public VolumeType volumeType;

	private int volumeStepBeforeTurningOff;

	private float volume
	{
		get
		{
			VolumeType volumeType = this.volumeType;
			switch (volumeType)
			{
			case VolumeType.SFX:
				return Manager.prefs.sfxVolume;
			case VolumeType.MUSIC:
				return Manager.prefs.musicVolume;
			case VolumeType.INSTRUMENTS:
				return Manager.prefs.instrumentsSfxVolume;
			case VolumeType.AMBIENT:
				return Manager.prefs.ambientSfxVolume;
			case VolumeType.MASTER:
				return Manager.prefs.masterAudioVolume;
			default:
			{
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(volumeType);
				float result = default(float);
				return result;
			}
			}
		}
	}

	private void Start()
	{
		UpdateText();
	}

	private bool OnSkimDelta(int delta)
	{
		SetVolume(Mathf.RoundToInt(volume / 0.125f) + delta);
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

	public override void OnActivated()
	{
		if (volume == 0f)
		{
			SetVolume((volumeStepBeforeTurningOff != 0) ? volumeStepBeforeTurningOff : 5);
		}
		else
		{
			volumeStepBeforeTurningOff = Mathf.RoundToInt(volume / 0.125f);
			SetVolume(0);
		}
		base.OnActivated();
	}

	public override void OnSelected()
	{
		base.OnSelected();
		PreSelectVolume(Mathf.RoundToInt(volume / 0.125f));
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		ResetPreSelectedVolume();
	}

	public void SetVolume(int value)
	{
		float num = Mathf.Clamp01((float)value * 0.125f);
		switch (volumeType)
		{
		case VolumeType.SFX:
			Manager.prefs.sfxVolume = num;
			break;
		case VolumeType.MUSIC:
			Manager.prefs.musicVolume = num;
			break;
		case VolumeType.AMBIENT:
			Manager.prefs.ambientSfxVolume = num;
			break;
		case VolumeType.INSTRUMENTS:
			Manager.prefs.instrumentsSfxVolume = num;
			break;
		case VolumeType.MASTER:
			Manager.prefs.masterAudioVolume = num;
			break;
		}
		UpdateText();
		PreSelectVolume(value);
	}

	public void PreSelectVolume(int value)
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = ((value > i) ? PugTextEffectMenuOption.SELECTED_VALUE_COLOR : PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR);
		}
	}

	public void ResetPreSelectedVolume()
	{
		for (int i = 0; i < valueText.glyphs.Count; i++)
		{
			valueText.glyphs[i].color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		}
	}

	public void UpdateText()
	{
		int num = Mathf.RoundToInt(volume * 8f);
		StringBuilder preallocatedStringBuilder = Manager.memory.preallocatedStringBuilder;
		preallocatedStringBuilder.Clear();
		for (int i = 0; i < 8; i++)
		{
			preallocatedStringBuilder.Append((i < num) ? '♦' : '♢');
		}
		valueText.Render(preallocatedStringBuilder.ToString());
	}
}
