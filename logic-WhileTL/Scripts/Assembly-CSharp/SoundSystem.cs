using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
	private static string audioClipsResourcesRoot = "Sound/";

	public float fadeDuration;

	public int magicMaxNotMusicNotLoopSoundsConstant;

	private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

	private Dictionary<SoundGroup, Dictionary<bool, Dictionary<string, AudioSource>>> currentClips = new Dictionary<SoundGroup, Dictionary<bool, Dictionary<string, AudioSource>>>();

	private bool changeMusic;

	private float changeMusicSpeed;

	private float fadeTimer;

	private string activeClip;

	private void Awake()
	{
		currentClips = new Dictionary<SoundGroup, Dictionary<bool, Dictionary<string, AudioSource>>>();
		currentClips.Add(SoundGroup.UI, new Dictionary<bool, Dictionary<string, AudioSource>>());
		currentClips[SoundGroup.UI].Add(key: true, new Dictionary<string, AudioSource>());
		currentClips[SoundGroup.UI].Add(key: false, new Dictionary<string, AudioSource>());
		currentClips.Add(SoundGroup.MUSIC, new Dictionary<bool, Dictionary<string, AudioSource>>());
		currentClips[SoundGroup.MUSIC].Add(key: true, new Dictionary<string, AudioSource>());
		currentClips[SoundGroup.MUSIC].Add(key: false, new Dictionary<string, AudioSource>());
	}

	public void ActiveMusic(string name)
	{
		if (!(activeClip == clips[name].name))
		{
			activeClip = clips[name].name;
			changeMusic = true;
			changeMusicSpeed = Logic.GetModel().globalSaves.musicVolume / fadeDuration * Time.fixedDeltaTime;
			fadeTimer = Time.unscaledTime;
			currentClips[SoundGroup.MUSIC][true][activeClip + "0"].time = 0f;
		}
	}

	public void SetLoopVolume(string name, float volume, SoundGroup group = SoundGroup.UI)
	{
		if (name == "Monokanal/WhileTrueLearn_RoomTone_Loop")
		{
			currentClips[group][true][clips[name].name + "0"].volume = 0f;
		}
		else
		{
			currentClips[group][true][clips[name].name + "0"].volume = volume;
		}
	}

	public void SetVolume(SoundGroup group, float value)
	{
		if (group == SoundGroup.MUSIC)
		{
			changeMusic = false;
			foreach (KeyValuePair<string, AudioSource> item in currentClips[SoundGroup.MUSIC][true])
			{
				item.Value.volume = 0f;
			}
			foreach (KeyValuePair<string, AudioSource> item2 in currentClips[SoundGroup.MUSIC][false])
			{
				item2.Value.volume = value;
			}
			if (currentClips[group][true].ContainsKey(activeClip + "0"))
			{
				currentClips[group][true][activeClip + "0"].volume = value;
			}
			return;
		}
		foreach (KeyValuePair<string, AudioSource> item3 in currentClips[group][true])
		{
			if (item3.Value.volume > 0f)
			{
				item3.Value.volume = value;
			}
		}
		foreach (KeyValuePair<string, AudioSource> item4 in currentClips[group][false])
		{
			item4.Value.volume = value;
		}
	}

	private void FixedUpdate()
	{
		if (!changeMusic)
		{
			return;
		}
		foreach (KeyValuePair<string, AudioSource> item in currentClips[SoundGroup.MUSIC][true])
		{
			int num = ((item.Value.clip.name == activeClip) ? 1 : (-1));
			item.Value.volume += (float)num * changeMusicSpeed;
		}
		if (!(Time.unscaledTime - fadeTimer >= fadeDuration))
		{
			return;
		}
		foreach (KeyValuePair<string, AudioSource> item2 in currentClips[SoundGroup.MUSIC][true])
		{
			item2.Value.volume = 0f;
		}
		currentClips[SoundGroup.MUSIC][true][activeClip + "0"].volume = Logic.GetModel().globalSaves.musicVolume;
		changeMusic = false;
	}

	public void Play(string sound, SoundGroup group = SoundGroup.UI, bool loop = false, float loopVolume = 0f)
	{
		if (!clips.ContainsKey(sound))
		{
			AudioClip audioClip = Resources.Load(audioClipsResourcesRoot + sound) as AudioClip;
			if (audioClip != null)
			{
				clips.Add(sound, audioClip);
			}
		}
		if (clips.ContainsKey(sound))
		{
			Play(clips[sound], group, loop, loopVolume);
		}
	}

	private IEnumerator DeleteSoundEvent(float delay, string name, SoundGroup group = SoundGroup.UI, bool loop = false)
	{
		yield return new WaitForSeconds(delay);
		Object.Destroy(currentClips[group][loop][name]);
		currentClips[group][loop].Remove(name);
		if (group == SoundGroup.UI)
		{
			magicMaxNotMusicNotLoopSoundsConstant--;
		}
	}

	public void Play(AudioClip clip, SoundGroup group = SoundGroup.UI, bool loop = false, float loopVolume = 0f)
	{
		if (group == SoundGroup.UI && !loop && currentClips[SoundGroup.UI][false].Count >= magicMaxNotMusicNotLoopSoundsConstant)
		{
			return;
		}
		string text = clip.name;
		int num = 0;
		if (group == SoundGroup.UI)
		{
			while (currentClips[group][loop].ContainsKey(text + num))
			{
				num++;
			}
		}
		text += num;
		if (currentClips[group][loop].ContainsKey(text))
		{
			return;
		}
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.loop = loop;
		currentClips[group][loop].Add(text, audioSource);
		if (group == SoundGroup.UI)
		{
			audioSource.volume = Logic.GetModel().globalSaves.soundVolume;
		}
		if (group == SoundGroup.MUSIC)
		{
			foreach (KeyValuePair<string, AudioSource> item in currentClips[group][true])
			{
				item.Value.volume = 0f;
			}
		}
		if (!loop)
		{
			if (group == SoundGroup.UI)
			{
				magicMaxNotMusicNotLoopSoundsConstant++;
			}
			StartCoroutine(DeleteSoundEvent(clip.length, text, group, loop));
		}
		else
		{
			audioSource.volume = loopVolume;
		}
		audioSource.Play();
	}
}
