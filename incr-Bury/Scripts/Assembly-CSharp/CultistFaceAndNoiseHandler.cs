using System;
using System.Collections.Generic;
using UnityEngine;

public class CultistFaceAndNoiseHandler : MonoBehaviour
{
	private class VoiceAudioClipInfo
	{
		public AudioClip clip;

		public float clipDelay;
	}

	private BerryCultist_AI ourCultistScript;

	[SerializeField]
	private AudioSource cultistVoice_AudioSource;

	[SerializeField]
	private List<VoiceAudioClipInfo> voiceClipQueue = new List<VoiceAudioClipInfo>();

	[Header("Random Roaming Noises")]
	[SerializeField]
	private float makeRandomNoises_Timer;

	private float makeRandomNoises_Timer_Curr;

	[Header("Face")]
	[SerializeField]
	private SkinnedMeshRenderer mouth_SkinnedMesh;

	private float mouth_BlendValue;

	[SerializeField]
	private Animator eye_Anim;

	private void Awake()
	{
		ourCultistScript = GetComponent<BerryCultist_AI>();
	}

	private void Start()
	{
		CalculateNextNoiseTiming();
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
	}

	private void Update()
	{
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			HandlePlayingVoiceClips();
			HandleMouthBlendDecay();
			HandleRandomlyMakingVoiceNoises();
		}
	}

	public void QueueUpNewVoiceSounds()
	{
		voiceClipQueue.Clear();
		float num = 0f;
		int num2 = UnityEngine.Random.Range(1, 4);
		for (int i = 0; i < num2; i++)
		{
			VoiceAudioClipInfo voiceAudioClipInfo = new VoiceAudioClipInfo();
			voiceAudioClipInfo.clip = AudioManager.Singleton.cultistNoises_Normal[UnityEngine.Random.Range(0, AudioManager.Singleton.cultistNoises_Normal.Count)];
			voiceAudioClipInfo.clipDelay = num;
			num += voiceAudioClipInfo.clip.length;
			voiceClipQueue.Add(voiceAudioClipInfo);
		}
	}

	private void HandlePlayingVoiceClips()
	{
		if (voiceClipQueue.Count <= 0)
		{
			return;
		}
		for (int num = voiceClipQueue.Count - 1; num >= 0; num--)
		{
			voiceClipQueue[num].clipDelay -= Time.deltaTime;
			if (voiceClipQueue[num].clipDelay <= 0f)
			{
				float num2 = 1f;
				try
				{
					if (GameManager.Singleton.audioduck_BlipsAndBloops)
					{
						num2 = 0.1f;
					}
				}
				catch
				{
				}
				cultistVoice_AudioSource.pitch = UnityEngine.Random.Range(0.95f, 1.1f);
				cultistVoice_AudioSource.PlayOneShot(voiceClipQueue[num].clip, AudioManager.Singleton.sfxVolume * 0.75f * num2);
				OpenMouth(UnityEngine.Random.Range(45f, 80f));
				voiceClipQueue.RemoveAt(num);
			}
		}
	}

	private void HandleRandomlyMakingVoiceNoises()
	{
		if (makeRandomNoises_Timer_Curr > 0f)
		{
			makeRandomNoises_Timer_Curr -= Time.deltaTime;
			if (makeRandomNoises_Timer_Curr <= 0f)
			{
				QueueUpNewVoiceSounds();
				CalculateNextNoiseTiming();
				makeRandomNoises_Timer_Curr = makeRandomNoises_Timer;
			}
		}
	}

	private void CalculateNextNoiseTiming()
	{
		makeRandomNoises_Timer_Curr = UnityEngine.Random.Range(3f, 12f);
	}

	public void PlayNegativeNoise()
	{
		if (GameManager.Singleton.gameState != GameManager.GameState.Playing)
		{
			return;
		}
		float num = 1f;
		try
		{
			if (GameManager.Singleton.audioduck_BlipsAndBloops)
			{
				num = 0.1f;
			}
		}
		catch
		{
		}
		if (voiceClipQueue.Count > 0)
		{
			voiceClipQueue.Clear();
		}
		cultistVoice_AudioSource.pitch = UnityEngine.Random.Range(0.95f, 1.1f);
		cultistVoice_AudioSource.PlayOneShot(AudioManager.Singleton.cultistNoises_Negative[UnityEngine.Random.Range(0, AudioManager.Singleton.cultistNoises_Negative.Count)], AudioManager.Singleton.sfxVolume * 0.75f * num);
		OpenMouth(100f);
	}

	private void OpenMouth(float _amount)
	{
		if (_amount > 100f)
		{
			_amount = 100f;
		}
		mouth_BlendValue = 100f - _amount;
		mouth_SkinnedMesh.SetBlendShapeWeight(0, mouth_BlendValue);
	}

	private void HandleMouthBlendDecay()
	{
		if (mouth_BlendValue < 100f)
		{
			if (mouth_BlendValue <= 100f)
			{
				mouth_BlendValue += Time.deltaTime * 125f;
				mouth_SkinnedMesh.SetBlendShapeWeight(0, mouth_BlendValue);
			}
			else
			{
				mouth_BlendValue = 100f;
				mouth_SkinnedMesh.SetBlendShapeWeight(0, mouth_BlendValue);
			}
		}
	}

	private void OnNightTime()
	{
		eye_Anim.speed = 0f;
		cultistVoice_AudioSource.mute = true;
	}
}
