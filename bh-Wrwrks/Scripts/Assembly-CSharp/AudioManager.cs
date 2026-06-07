using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public enum Sound
	{
		DragModule = 0,
		DropModule = 1,
		StartWire = 2,
		EndWire = 3,
		Slider = 4,
		Dial = 5,
		Monster_Hit = 6,
		Hurt0 = 7,
		Hurt1 = 8,
		Gold = 9,
		Buy = 10,
		UI_Button = 11,
		Explosion = 12,
		Explosion_Small = 13,
		Explosion_Electric = 14,
		Explosion_Potion = 15,
		Zap = 16,
		Upgrade = 17,
		WaveClear = 18,
		Shop = 19,
		GameOver = 20,
		Monster_Death_Basic = 21,
		Monster_Death_Bat = 22,
		Monster_Death_Armor = 23,
		Monster_Death_Bones = 24,
		Monster_Death_Crash = 25,
		Monster_Death_Bubble = 26,
		Monster_Death_Bubble_Solo = 27,
		Monster_Death_Fish = 28,
		Underwater_Bubble_0 = 29,
		Underwater_Bubble_1 = 30,
		Underwater_Bubble_2 = 31,
		Monster_Death_Boss_Goblin = 32,
		Monster_Death_Boss_Squid = 33,
		Sizzle0 = 34,
		Sizzle1 = 35,
		Bow_Shoot = 36,
		Blood_Blade = 37,
		Shuriken_Shoot = 38,
		Bash = 39,
		Rocket = 40,
		Imp_Fire = 41,
		Chicken = 42,
		Penguin = 43,
		Beam = 44,
		Ghost = 45,
		Bones0 = 46,
		Bones1 = 47,
		Bones2 = 48,
		Magic_Bolt = 49,
		Rocks = 50,
		Beep = 51,
		Buzz_Bee = 52,
		Boing0 = 53,
		Boing1 = 54,
		Heal = 55,
		Sleighbells = 56,
		Crit = 57,
		Barrel_Splash = 58,
		Droplets = 59,
		Explosion_Plant = 60,
		Explosion_Fairy = 61,
		Explosion_Ice = 62,
		Explosion_Balloon = 63,
		Swipe = 64,
		Mageblade = 65,
		Bell_Proc = 66,
		Bell_Hit0 = 67,
		Bell_Hit1 = 68,
		Bell_Hit2 = 69,
		UI_Error = 70,
		UI_Menu_Slide_0 = 71,
		Explosion_Ice_Small = 72,
		Bloody_Punch = 73,
		Monitor = 74,
		Rat0 = 75,
		Laser = 76,
		Shock = 77,
		Robot = 78,
		Laser_Charge = 79,
		Shock_Charge = 80,
		Shock_Short = 81,
		Robot_Mechanism = 82,
		Wizard_Shoot = 83,
		Enemy_Slash = 84,
		Smash0 = 85,
		Smash1 = 86,
		Drill = 87,
		Water_Waves = 88,
		Monster_Death_Crash_2 = 89,
		Player_Death = 90,
		Wind_Bolt = 91,
		Vortex = 92,
		Shock_Wep = 93,
		BubbleCharge = 94,
		BossSplash = 95,
		Sapper_Boom = 96
	}

	public enum Music
	{
		Title = 0,
		Battle = 1,
		Shop_Water = 2,
		Battle_Water = 3,
		Shop_Orbit = 4,
		Battle_Orbit = 5
	}

	public Dungeon dungeon;

	public AudioSource uiSFX;

	public AudioSource gameSFX;

	public AudioSource[] gameSFX_var;

	public AudioSource music;

	private float volSFX = 1f;

	private float volUI = 1f;

	private float volMusic = 0.5f;

	public float sfxScale = 10f;

	private float _musicScale = 10f;

	public float vocalScale = 10f;

	public AudioClip[] sfxList;

	public AudioClip[] musicList;

	public AudioClip[] moduleIntroSFX;

	public AudioMixer musicMixer;

	private List<Sound> ongoingSFX = new List<Sound>();

	private int varIndex;

	public Music currMusic;

	public bool continuous;

	public static Sound RandomBoneSound => Utils.RandElem(new List<Sound>
	{
		Sound.Bones0,
		Sound.Bones1,
		Sound.Bones2
	});

	public float musicScale
	{
		get
		{
			return _musicScale;
		}
		set
		{
			_musicScale = value;
			SetMusicVolume();
		}
	}

	private void Start()
	{
		musicMixer.SetFloat("LowPassFrequency", 10000f);
		musicMixer.SetFloat("LowPassResonance", 1f);
	}

	public void SetMusicVolume()
	{
		music.volume = volMusic * musicScale / 10f;
	}

	public void PauseGame()
	{
		gameSFX.Pause();
		StartCoroutine(musicPause());
	}

	public void SetMusicLowpass(bool active)
	{
		StartCoroutine(musicPause(!active));
	}

	private IEnumerator musicPause(bool unpause = false)
	{
		float frames = 20f;
		musicMixer.GetFloat("LowPassFrequency", out var OP);
		float DP = 500f;
		if (unpause)
		{
			DP = 10000f;
		}
		for (int i = 0; (float)i < frames; i++)
		{
			musicMixer.SetFloat("LowPassFrequency", Mathf.Lerp(OP, DP, (float)(i + 1) / frames));
			yield return Dungeon.WaitUI(1);
		}
		yield return null;
	}

	public void UnpauseGame()
	{
		gameSFX.UnPause();
		StartCoroutine(musicPause(unpause: true));
	}

	public void PlayUI_Randomized(Sound c, float minPitch = 0.65f, float maxPitch = 1f, float minVol = 0.5f, float maxVol = 1f)
	{
		uiSFX.pitch = Random.Range(minPitch, maxPitch);
		uiSFX.volume = Random.Range(minVol, maxVol) * volSFX * volUI * sfxScale / 10f;
		uiSFX.PlayOneShot(sfxList[(int)c]);
	}

	public void PlayUI(AudioClip c, float pitch = 1f, float vol = 1f)
	{
		uiSFX.pitch = pitch;
		uiSFX.volume = vol * volSFX * volUI * sfxScale / 10f;
		uiSFX.PlayOneShot(c);
	}

	public void StopGameSound()
	{
		gameSFX.Stop();
		AudioSource[] array = gameSFX_var;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	public void PlayModSound(Module mod, float vol = 1f)
	{
		if ((int)mod.name >= moduleIntroSFX.Length)
		{
			Debug.LogWarning("MISSING SFX: " + mod.name);
			return;
		}
		gameSFX.volume = vol * volSFX * sfxScale / 10f;
		gameSFX.PlayOneShot(moduleIntroSFX[(int)mod.name]);
	}

	public void PlaySound(Sound c, float pitch = 1f, float vol = 1f)
	{
		if (!ongoingSFX.Contains(c))
		{
			StartCoroutine(SoundBuffer(c));
			if (pitch != 1f)
			{
				gameSFX_var[varIndex].pitch = pitch;
				gameSFX_var[varIndex].volume = vol * volSFX * sfxScale / 10f;
				gameSFX_var[varIndex].PlayOneShot(sfxList[(int)c]);
				varIndex = (varIndex + 1) % gameSFX_var.Length;
			}
			else
			{
				gameSFX.pitch = pitch;
				gameSFX.volume = vol * volSFX * sfxScale / 10f;
				gameSFX.PlayOneShot(sfxList[(int)c]);
			}
		}
	}

	public void PlaySound_Repeatable(Sound c, float pitch = 1f, float vol = 1f)
	{
		if (pitch != 1f)
		{
			gameSFX_var[varIndex].pitch = pitch;
			gameSFX_var[varIndex].volume = vol * volSFX * sfxScale / 10f;
			gameSFX_var[varIndex].PlayOneShot(sfxList[(int)c]);
			varIndex = (varIndex + 1) % gameSFX_var.Length;
		}
		else
		{
			gameSFX.pitch = pitch;
			gameSFX.volume = vol * volSFX * sfxScale / 10f;
			gameSFX.PlayOneShot(sfxList[(int)c]);
		}
	}

	public void PlaySoundRandomized(Sound c, float minPitch = 0.65f, float maxPitch = 1f, float minVol = 0.5f, float maxVol = 1f)
	{
		if (!ongoingSFX.Contains(c))
		{
			StartCoroutine(SoundBuffer(c));
			gameSFX_var[varIndex].pitch = Random.Range(minPitch, maxPitch);
			gameSFX_var[varIndex].volume = Random.Range(minVol, maxVol) * volSFX * sfxScale / 10f;
			gameSFX_var[varIndex].PlayOneShot(sfxList[(int)c]);
			varIndex = (varIndex + 1) % gameSFX_var.Length;
		}
	}

	public void PlaySoundRandomized_Repeatable(Sound c, float minPitch = 0.65f, float maxPitch = 1f, float minVol = 0.5f, float maxVol = 1f)
	{
		gameSFX_var[varIndex].pitch = Random.Range(minPitch, maxPitch);
		gameSFX_var[varIndex].volume = Random.Range(minVol, maxVol) * volSFX * sfxScale / 10f;
		gameSFX_var[varIndex].PlayOneShot(sfxList[(int)c]);
		varIndex = (varIndex + 1) % gameSFX_var.Length;
	}

	private IEnumerator SoundBuffer(Sound c)
	{
		ongoingSFX.Add(c);
		yield return null;
		ongoingSFX.RemoveAll((Sound x) => x == c);
	}

	public float PlayMusic(Music m)
	{
		currMusic = m;
		return PlayMusic(musicList[(int)m]);
	}

	private float PlayMusic(AudioClip c)
	{
		continuous = false;
		music.volume = volMusic * musicScale / 10f;
		music.loop = true;
		music.clip = c;
		music.Play();
		return c.length * 60f;
	}

	public void SwitchMusic(Music m)
	{
		StartCoroutine(musicSwitcher(m));
	}

	private IEnumerator musicSwitcher(Music m)
	{
		Music prev = currMusic;
		currMusic = m;
		for (int i = 0; (float)i < 45f; i++)
		{
			music.volume = Mathf.Lerp(volMusic * musicScale / 10f, 0f, (float)(i + 1) / 45f);
			yield return Dungeon.Wait(1);
		}
		music.Stop();
		continuous = false;
		music.loop = true;
		music.clip = musicList[(int)m];
		if (m == Music.Title)
		{
			music.time = 25f;
		}
		if (m == Music.Shop_Water && prev == Music.Battle_Water)
		{
			music.time = 19f;
		}
		music.Play();
		for (int i = 0; (float)i < 35f; i++)
		{
			music.volume = Mathf.Lerp(0f, volMusic * musicScale / 10f, (float)(i + 1) / 45f);
			yield return Dungeon.Wait(1);
		}
		music.volume = volMusic * musicScale / 10f;
	}

	public void StopGameMusic()
	{
		if (!continuous)
		{
			music.Stop();
		}
	}
}
