using LocoSim.Implementations;
using UnityEngine;
using UnityEngine.Audio;

public class LampControl : MonoBehaviour
{
	public enum LampState
	{
		Off = 0,
		On = 1,
		Blinking = 2,
		None = 3
	}

	private const float SMOOTH_PERCENTAGE_ENOUGH = 0.999f;

	public IndicatorEmission lampInd;

	public LampState lampState;

	private LampState blinkState;

	public AudioClip warningAudio;

	public AudioClip onStateBuzzingLoopAudio;

	public AudioClip blinkStateBuzzingLoopAudio;

	public AudioMixerGroup lampAudioMixerGroup;

	private AudioSource onStateBuzzingAudioSource;

	private AudioSource blinkStateBuzzingAudioSource;

	public bool IsOn => lampInd.Value > 0.5f;

	private void Awake()
	{
		if (lampInd == null)
		{
			Debug.LogError("Lamp indicator not set to lamp controller!", this);
		}
		LampState state = lampState;
		lampState = LampState.None;
		SetLampState(state);
	}

	private void Update()
	{
		float emissionValue = lampInd.EmissionValue;
		if (lampState == LampState.Off && emissionValue > lampInd.minValue * 0.999f)
		{
			lampInd.Value = lampInd.minValue;
		}
		else if (lampState == LampState.On && emissionValue < lampInd.maxValue * 0.999f)
		{
			lampInd.Value = lampInd.maxValue;
		}
		else
		{
			if (lampState != LampState.Blinking)
			{
				return;
			}
			if (blinkState == LampState.Off)
			{
				lampInd.Value = lampInd.minValue;
				if (emissionValue < lampInd.minValue + 0.0009999871f)
				{
					blinkState = LampState.On;
				}
			}
			else if (blinkState == LampState.On)
			{
				lampInd.Value = lampInd.maxValue;
				if (emissionValue > lampInd.maxValue * 0.999f)
				{
					blinkState = LampState.Off;
				}
			}
		}
	}

	public void SetLampState(LampState state, bool playWarningAudio = false)
	{
		if (lampState == state)
		{
			return;
		}
		if (playWarningAudio && warningAudio != null)
		{
			warningAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), lampAudioMixerGroup, base.transform);
		}
		if (onStateBuzzingLoopAudio != null)
		{
			if (state == LampState.On)
			{
				if (onStateBuzzingAudioSource == null)
				{
					onStateBuzzingAudioSource = NAudio.CreateSource(base.transform, onStateBuzzingLoopAudio, 1f, 1f, loop: true, playAtStart: true, 1f, 500f, 0f, 1f, lampAudioMixerGroup).source;
				}
				else
				{
					Debug.LogError("Unexpected state: onStateBuzzingAudioSource is not null, when state changed to On. Something is not right", this);
				}
				onStateBuzzingAudioSource.Play();
			}
			else if (onStateBuzzingAudioSource != null)
			{
				onStateBuzzingAudioSource.Stop();
				Object.Destroy(onStateBuzzingAudioSource.gameObject);
				onStateBuzzingAudioSource = null;
			}
		}
		if (blinkStateBuzzingLoopAudio != null)
		{
			if (state == LampState.Blinking)
			{
				if (blinkStateBuzzingAudioSource == null)
				{
					blinkStateBuzzingAudioSource = NAudio.CreateSource(base.transform, blinkStateBuzzingLoopAudio, 1f, 1f, loop: true, playAtStart: true, 1f, 500f, 0f, 1f, lampAudioMixerGroup).source;
				}
				else
				{
					Debug.LogError("Unexpected state: blinkStateBuzzingAudioSource is not null, when state changed to On. Something is not right", this);
				}
				blinkStateBuzzingAudioSource.Play();
			}
			else if (blinkStateBuzzingAudioSource != null)
			{
				blinkStateBuzzingAudioSource.Stop();
				Object.Destroy(blinkStateBuzzingAudioSource.gameObject);
				blinkStateBuzzingAudioSource = null;
			}
		}
		lampState = state;
	}

	public void ProcessLampLogicCode(float lampStateCode, bool audioAllowed)
	{
		LampLogic.LampState lampState = (LampLogic.LampState)lampStateCode;
		switch (lampState)
		{
		case LampLogic.LampState.LAMP_OFF:
			SetLampState(LampState.Off);
			break;
		case LampLogic.LampState.LAMP_ON_NO_AUDIO:
			SetLampState(LampState.On);
			break;
		case LampLogic.LampState.LAMP_ON_WITH_AUDIO:
			SetLampState(LampState.On, audioAllowed);
			break;
		case LampLogic.LampState.LAMP_BLINK_NO_AUDIO:
			SetLampState(LampState.Blinking);
			break;
		case LampLogic.LampState.LAMP_BLINK_WITH_AUDIO:
			SetLampState(LampState.Blinking, audioAllowed);
			break;
		default:
			Debug.LogError($"Unexpected state: Unhandled value ({lampStateCode} - {lampState})");
			break;
		}
	}
}
