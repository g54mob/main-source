using System.Collections;
using PaintIn3D;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public static AudioManager S;

	public AudioMixer mixer;

	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private AudioSource sfxSource;

	[SerializeField]
	private AudioSource footStepSource;

	[SerializeField]
	private AudioSource doorBellSource;

	[SerializeField]
	private AudioSource rocketSfxSource;

	[SerializeField]
	private AudioSource mowerSource;

	[SerializeField]
	private AudioSource cookingSource;

	[SerializeField]
	private AudioSource rcSource;

	public AudioClip bgm;

	public AudioClip bgm2;

	public AudioClip memoCheck;

	public AudioClip doorOpen;

	public AudioClip doorClose;

	public AudioClip doorLocked;

	public AudioClip uiClicked;

	public AudioClip uiToggle;

	public AudioClip questStart;

	public AudioClip questDone;

	public AudioClip grabItem;

	public AudioClip dropItem;

	public AudioClip craftingTableInteract;

	public AudioClip craftingTableDone;

	public AudioClip rocketPartsInstalled;

	public AudioClip eating;

	public AudioClip money;

	public AudioClip knockingDoor;

	public AudioClip foodStacked;

	public AudioClip busStopInteract;

	public AudioClip[] wakingClips;

	public AudioClip[] wakingClipsGrass;

	public AudioClip waterRocketLaunched;

	public AudioClip waterRocketFlying;

	public AudioClip plasticImpact;

	public AudioClip computerOn;

	public AudioClip notEnoughMoney;

	public AudioClip computerBuy;

	public AudioClip refridgeOpen;

	public AudioClip refridgeClose;

	public AudioClip shelfPut;

	public AudioClip tutorialUIOn;

	public AudioClip trash;

	public AudioClip postBox;

	public AudioClip waterSplash;

	public AudioClip[] grassCutted;

	public AudioClip levelUp;

	public AudioClip cookingPan;

	public AudioClip cookingBoil;

	public AudioClip motorIngred;

	public AudioClip powderPour;

	public AudioClip powderBoil;

	public AudioClip grind;

	public AudioClip motorTesting;

	public AudioClip motorFail;

	public AudioClip cameraAngle;

	public AudioClip rocketCrashed;

	public AudioClip vidUploaded;

	public AudioClip unlockColor;

	public AudioClip score;

	public AudioClip rcRun;

	public AudioClip[] rcScrap;

	public AudioClip coin;

	public AudioClip stickerMachine;

	public AudioClip paintSpray;

	public AudioClip unScrew;

	public AudioClip desolder;

	public AudioClip parachute;

	public AudioClip solidFuelRocketLaunched;

	public AudioClip solidFuelRocketFlying;

	public bool demoComplete;

	private bool playClipA = true;

	private int sceneNum;

	private void OnEnable()
	{
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		CwPaintSphere.OnStartPainting += CwPaintSphere_OnStartPainting;
		CwPaintSphere.OnStopPainting += CwPaintSphere_OnStopPainting;
		CwPaintDecal.OnPutDecal += CwPaintDecal_OnPutDecal;
	}

	private void CwPaintDecal_OnPutDecal()
	{
		PlaySFX(rocketPartsInstalled);
	}

	private void CwPaintSphere_OnStopPainting()
	{
		StopCookingSFX();
	}

	public void RcControlling(bool controlling)
	{
		if (controlling)
		{
			rcSource.volume = Mathf.Lerp(rcSource.volume, 0.5f, Time.deltaTime * 5f);
			rcSource.pitch = Mathf.Lerp(rcSource.pitch, 1.2f, Time.deltaTime * 5f);
		}
		else
		{
			rcSource.volume = Mathf.Lerp(rcSource.volume, 0f, Time.deltaTime * 3f);
			rcSource.pitch = Mathf.Lerp(rcSource.pitch, 0.8f, Time.deltaTime * 3f);
		}
	}

	public void PlayRcSFX()
	{
		rcSource.clip = rcRun;
		rcSource.Play();
	}

	public void StopRcSFX()
	{
		rcSource.Stop();
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
		CwPaintSphere.OnStartPainting -= CwPaintSphere_OnStartPainting;
		CwPaintSphere.OnStopPainting -= CwPaintSphere_OnStopPainting;
		CwPaintDecal.OnPutDecal -= CwPaintDecal_OnPutDecal;
	}

	private void CwPaintSphere_OnStartPainting()
	{
		PlayCookingSFX(paintSpray, 1f);
	}

	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		sceneNum = arg0.buildIndex;
	}

	private void Awake()
	{
		if (S != null && S != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		StartCoroutine(PlayAlternately());
	}

	private IEnumerator PlayAlternately()
	{
		while (true)
		{
			AudioClip audioClip = (playClipA ? bgm : bgm2);
			musicSource.clip = audioClip;
			musicSource.Play();
			Debug.Log("현재 재생 중: " + audioClip.name);
			yield return new WaitForSeconds(audioClip.length);
			playClipA = !playClipA;
		}
	}

	public void PlaySFX(AudioClip clip)
	{
		sfxSource.pitch = 1f;
		sfxSource.PlayOneShot(clip);
	}

	public void PlayDoorBell(AudioClip clip)
	{
		sfxSource.pitch = 1f;
		doorBellSource.PlayOneShot(clip);
	}

	public void PlayFootStep()
	{
		AudioClip clip = ((sceneNum != 1) ? wakingClipsGrass[Random.Range(0, S.wakingClipsGrass.Length)] : wakingClips[Random.Range(0, S.wakingClips.Length)]);
		footStepSource.PlayOneShot(clip);
	}

	public void PlayRcScrap()
	{
		AudioClip clip = rcScrap[Random.Range(0, rcScrap.Length)];
		sfxSource.PlayOneShot(clip);
	}

	public void EatingSFX()
	{
		sfxSource.pitch = 1f;
		sfxSource.clip = eating;
		sfxSource.loop = true;
		sfxSource.Play();
	}

	public void StopEatingSFX()
	{
		sfxSource.Stop();
		sfxSource.loop = false;
	}

	public void PlayRocketSFX(AudioClip clip)
	{
		sfxSource.pitch = 1f;
		rocketSfxSource.clip = clip;
		rocketSfxSource.Play();
	}

	public void StopRocketSFX()
	{
		StartCoroutine(FadeOutSFX(rocketSfxSource, 0.5f));
	}

	private IEnumerator FadeOutSFX(AudioSource source, float fadeTime)
	{
		float startVolume = source.volume;
		while (source.volume > 0f)
		{
			source.volume -= startVolume * Time.deltaTime / fadeTime;
			yield return null;
		}
		source.Stop();
		source.volume = 1f;
	}

	public void PlayRandomPitch(AudioClip clip)
	{
		sfxSource.pitch = Random.Range(0.85f, 1.1f);
		sfxSource.PlayOneShot(clip);
	}

	public void StopSFX()
	{
		sfxSource.loop = false;
		sfxSource.Stop();
	}

	public void PlayMowingSound()
	{
		if (!mowerSource.isPlaying)
		{
			mowerSource.PlayOneShot(grassCutted[Random.Range(0, grassCutted.Length - 1)]);
		}
	}

	public void PlayCookingSFX(AudioClip clip, float volume)
	{
		sfxSource.pitch = 1f;
		cookingSource.clip = clip;
		cookingSource.Play();
		cookingSource.volume = volume;
	}

	public void StopCookingSFX()
	{
		cookingSource.Stop();
	}

	public void StopTestingSound()
	{
		StartCoroutine(FadeOutSFX(cookingSource, 0.5f));
	}

	public bool CheckCookingSFXPlaying()
	{
		if (cookingSource.isPlaying)
		{
			return true;
		}
		return false;
	}

	public void PlayWaterCollisionSound()
	{
		if (!sfxSource.isPlaying)
		{
			sfxSource.PlayOneShot(waterSplash);
		}
	}

	public void PlaySFXLoop(AudioClip clip)
	{
		sfxSource.loop = true;
		sfxSource.clip = clip;
		sfxSource.Play();
	}
}
