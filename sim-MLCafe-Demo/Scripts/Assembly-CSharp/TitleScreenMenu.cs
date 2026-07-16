using UnityEngine;

public class TitleScreenMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject context;

	[SerializeField]
	private UIContentAnimator whiteTransitionBlend;

	[SerializeField]
	private UIContentAnimator[] animators;

	[SerializeField]
	private AudioSource musicAudioSource;

	[SerializeField]
	private AnimationCurve musicFadeInCurve;

	private float targetVolume;

	private static TitleScreenMenu instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		whiteTransitionBlend.OnPlay();
		targetVolume = musicAudioSource.volume;
		musicAudioSource.volume = 0f;
		StartCoroutine(UIAnimator.SoundAnimator(musicAudioSource, 0f, targetVolume, musicFadeInCurve, whiteTransitionBlend.GetFadeTime()));
	}

	public static void ShowTitleScreen()
	{
		instance.context.SetActive(value: true);
	}

	public static void HideTitleScreen()
	{
		instance.context.SetActive(value: false);
	}

	public void StartGame()
	{
		for (int i = 0; i < animators.Length; i++)
		{
			if (!animators[i].gameObject.active)
			{
				animators[i].gameObject.SetActive(value: true);
			}
			animators[i].OnPlay();
		}
	}

	public void Settings()
	{
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
