using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class TransitionManager : MonoBehaviour
{
	public enum TransitionState
	{
		In = 0,
		Out = 1
	}

	public AnimationCurve transitionCurve;

	public GameObject transitionMask;

	public GameObject transitionScreen;

	public AudioMixerGroup audioMixerGroup;

	private bool isTransitioning;

	private SoundManager soundManager;

	public void Awake()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
		transitionScreen.SetActive(value: true);
		StartTransition(TransitionState.In);
	}

	public float StartTransition(TransitionState transitionState)
	{
		if (!isTransitioning)
		{
			StartCoroutine(Transition(transitionState));
			return transitionCurve[transitionCurve.length - 1].time;
		}
		return float.PositiveInfinity;
	}

	public IEnumerator Transition(TransitionState transitionState)
	{
		isTransitioning = true;
		switch (transitionState)
		{
		case TransitionState.In:
		{
			if (SaveSystem.currentPlayerSaveData.overworldState != OverworldTrollManager.OverworldState.ACT_I)
			{
				SoundManager.LoadSoundEffect(base.transform, soundManager.transition_fade_in);
			}
			float transitionSeconds = 0f;
			while (transitionSeconds < transitionCurve[transitionCurve.length - 1].time)
			{
				float num4 = transitionCurve.Evaluate(transitionSeconds);
				transitionMask.transform.localScale = new Vector3(num4, num4, transitionMask.transform.localScale.z);
				float num5 = num4 / transitionCurve[transitionCurve.length - 1].value;
				SetMasterVolume(1f - num5);
				transitionSeconds += Time.deltaTime;
				yield return null;
			}
			float num6 = transitionCurve.Evaluate(transitionCurve[transitionCurve.length - 1].time);
			transitionMask.transform.localScale = new Vector3(num6, num6, transitionMask.transform.localScale.z);
			SetMasterVolume(0f);
			break;
		}
		case TransitionState.Out:
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.transition_fade_out);
			float transitionSeconds = transitionCurve[transitionCurve.length - 1].time;
			while (transitionSeconds > 0f)
			{
				while (TrollDialogManager.isInDialog)
				{
					yield return null;
				}
				float num = transitionCurve.Evaluate(transitionSeconds);
				transitionMask.transform.localScale = new Vector3(num, num, transitionMask.transform.localScale.z);
				float num2 = num / transitionCurve[transitionCurve.length - 1].value;
				SetMasterVolume(1f - num2);
				transitionSeconds -= Time.deltaTime;
				yield return null;
			}
			float num3 = transitionCurve.Evaluate(0f);
			transitionMask.transform.localScale = new Vector3(num3, num3, transitionMask.transform.localScale.z);
			SetMasterVolume(1f);
			break;
		}
		}
		isTransitioning = false;
	}

	public void SetMasterVolume(float value)
	{
		float value2 = value * -40f;
		audioMixerGroup.audioMixer.SetFloat("Volume", value2);
	}
}
