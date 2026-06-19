using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using UnityEngine;

public class IntroHandler : MonoBehaviour
{
	[Serializable]
	public class Slide
	{
		public Sprite sprite;

		public string text;

		public bool skipFadingOut;

		public MusicRosterType musicToPlay;

		public int syllableComponentToUse;

		public string animTrigger;

		public string animBoolEnabled;

		public string animBoolDisabled;

		public float fadeInDelay;

		public float fadeOutDelay;

		public List<ParticleSystem> particlesToPlay;

		public List<ParticleSystem> particlesToStop;

		public float slideShowTimeOverride;

		public SFXTableIDField audioLoopToPlay;

		public bool stopAnyAudioLoop;
	}

	public enum SlideShowState
	{
		WaitingForNextSlide = 0,
		FadingIn = 1,
		ShowingSlide = 2,
		FadingOut = 3,
		Complete = 4
	}

	public int debugStartIndex;

	public bool isOutro;

	private const float HOLD_TIME_TO_SKIP = 1f;

	private float playerHoldSkipTimer;

	private float showSkipTextTimer;

	public GameObject exitContainer;

	public GameObject exitMaskBarPivot;

	private bool playerSkippedIntro;

	public AudioSource creditsMusicPlayer;

	private TimerSimple slidesTimer = new TimerSimple(5f);

	private SlideShowState slideShowState;

	public SpriteRenderer slideSR;

	private float slideAlpha;

	private int currentSlideIndex;

	public List<string> animBoolsToDisableOnSkip;

	public List<ParticleSystem> particlesToStopOnSkip;

	public List<PugTextEffectFade> textsToFadeOnSkip;

	public List<Slide> slidesList;

	public SpriteRenderer overlay;

	public bool startTextAfterInitialSlideFadedIn = true;

	public PugText text;

	private bool textStarted;

	private const float INITIAL_WAIT_TIME_BEFORE_START = 2f;

	private const float WAIT_TIME_BETWEEN_SLIDES = 0f;

	private const float WAIT_TIME_BETWEEN_SLIDES_AFTER_BRIGHTNESS = 4f;

	private const float START_AND_END_SLIDE_FADE_SPEED = 1f;

	private const float OUTRO_END_SLIDE_FADE_SPEED = 0.3f;

	private const float SLIDE_FADE_SPEED = 2f;

	private const float SLIDE_SHOW_TIME = 4f;

	public int slideToPlayOverlayBrightness;

	private List<PugTextEffectEnunciateSyllables> syllableComponents;

	public Animator animator;

	private int currentAudioLoopPlaying;

	private readonly List<AudioManager.RunningSfxReference> audioLoop = new List<AudioManager.RunningSfxReference>();

	private TimerSimple slideDelayTimer;

	private bool hasFadedOutTexts;

	private bool gameIsStarting;

	private bool slidesDone;

	private bool hasStartedFadeOutMusic;

	private TimerSimple brightnessStartTimer = new TimerSimple(2f);

	private TimerSimple brightnessTimer = new TimerSimple(2f);

	public AnimationCurve brightnessCurve;

	private float fadeSpeed
	{
		get
		{
			if (!isOutro || currentSlideIndex != slidesList.Count - 1)
			{
				if (currentSlideIndex != 0 && currentSlideIndex != slidesList.Count - 1)
				{
					return 2f;
				}
				return 1f;
			}
			return 0.3f;
		}
	}

	private bool shouldShowBrightnessOnSlide => currentSlideIndex == slideToPlayOverlayBrightness;

	private void Start()
	{
		slideAlpha = 0f;
		slideSR.SetAlpha(slideAlpha);
		currentSlideIndex = -1;
		overlay.SetAlpha(0f);
		MoveToNextSlide();
		exitContainer.SetActive(value: false);
		syllableComponents = text.GetComponents<PugTextEffectEnunciateSyllables>().ToList();
	}

	private void Update()
	{
		if (!slidesDone && !playerSkippedIntro)
		{
			if (Manager.input.GetAnyButton())
			{
				showSkipTextTimer = 1f;
				exitContainer.SetActive(value: true);
			}
			if (Manager.input.IsMenuInteractButtonPressed())
			{
				playerHoldSkipTimer = Mathf.Clamp(playerHoldSkipTimer + Time.deltaTime, 0f, 1f);
				if (playerHoldSkipTimer >= 1f)
				{
					SkipIntro();
				}
			}
			else
			{
				playerHoldSkipTimer = Mathf.Clamp(playerHoldSkipTimer - Time.deltaTime, 0f, 1f);
			}
			if (showSkipTextTimer <= 0f && playerHoldSkipTimer <= 0f)
			{
				exitContainer.SetActive(value: false);
			}
			else
			{
				showSkipTextTimer -= Time.deltaTime;
			}
		}
		else
		{
			exitContainer.SetActive(value: false);
		}
		playerHoldSkipTimer = Mathf.Clamp(playerHoldSkipTimer, 0f, 1f);
		exitMaskBarPivot.transform.localScale = new Vector3(playerHoldSkipTimer / 1f, 1f, 1f);
		UpdateOverlayBrightness();
		switch (slideShowState)
		{
		case SlideShowState.WaitingForNextSlide:
			UpdateWaiting();
			break;
		case SlideShowState.FadingIn:
			UpdateFadeIn();
			break;
		case SlideShowState.ShowingSlide:
			UpdateShowing();
			break;
		case SlideShowState.FadingOut:
			UpdateFadeOut();
			break;
		case SlideShowState.Complete:
			UpdateSlidesComplete();
			break;
		}
	}

	private void UpdateWaiting()
	{
		if (overlay.color.a > 0.9f && text.displayedTextString != "")
		{
			text.Render("");
		}
		if (!slidesTimer.isRunning)
		{
			float newLifespan = ((currentSlideIndex == 0) ? 2f : ((currentSlideIndex == slideToPlayOverlayBrightness + 1) ? 4f : 0f));
			slidesTimer.Start(newLifespan);
		}
		if (slidesTimer.isTimerElapsed)
		{
			MoveToNewState(SlideShowState.FadingIn);
		}
	}

	private void UpdateFadeIn()
	{
		if (!startTextAfterInitialSlideFadedIn || currentSlideIndex != 0)
		{
			StartText();
		}
		if (slidesList[currentSlideIndex].fadeInDelay > 0f)
		{
			if (!slideDelayTimer.isRunning)
			{
				slideDelayTimer.Start(slidesList[currentSlideIndex].fadeInDelay);
			}
			if (!slideDelayTimer.isTimerElapsed)
			{
				return;
			}
		}
		if (Manager.music.currentMusicRosterType != slidesList[currentSlideIndex].musicToPlay && slidesList[currentSlideIndex].musicToPlay != MusicRosterType.DEFAULT)
		{
			Manager.music.repeat = false;
			Manager.music.SetNewMusicPlaylist(slidesList[currentSlideIndex].musicToPlay);
			Manager.music.PlayMusic();
		}
		foreach (ParticleSystem item in slidesList[currentSlideIndex].particlesToPlay)
		{
			if (!item.isPlaying)
			{
				item.Play(withChildren: true);
			}
		}
		if (animator != null)
		{
			if (!string.IsNullOrEmpty(slidesList[currentSlideIndex].animBoolEnabled))
			{
				animator.SetBool(slidesList[currentSlideIndex].animBoolEnabled, value: true);
			}
			if (!string.IsNullOrEmpty(slidesList[currentSlideIndex].animTrigger))
			{
				animator.SetTrigger(slidesList[currentSlideIndex].animTrigger);
			}
		}
		int value = slidesList[currentSlideIndex].audioLoopToPlay.value;
		if (value != 0 && currentAudioLoopPlaying != value)
		{
			StopAnyAudioLoop();
			AudioManager.Sfx(value, Vector3.zero, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.UI, reuseSfxs: false, playOnGamepad: false, audioLoop);
			currentAudioLoopPlaying = value;
		}
		slideAlpha = Mathf.Clamp01(slideAlpha + Time.deltaTime * fadeSpeed);
		if (currentSlideIndex - 1 < 0 || !slidesList[currentSlideIndex - 1].skipFadingOut)
		{
			slideSR.SetAlpha(slideAlpha);
		}
		if (slideAlpha >= 1f)
		{
			slideDelayTimer.Stop();
			MoveToNewState(SlideShowState.ShowingSlide);
		}
	}

	private void UpdateShowing()
	{
		if (startTextAfterInitialSlideFadedIn && currentSlideIndex == 0)
		{
			StartText();
		}
		_ = currentSlideIndex;
		_ = slidesList.Count - 1;
		if (syllableComponents[slidesList[currentSlideIndex].syllableComponentToUse].done)
		{
			if (!slidesTimer.isRunning)
			{
				float newLifespan = ((slidesList[currentSlideIndex].slideShowTimeOverride > 0f) ? slidesList[currentSlideIndex].slideShowTimeOverride : 4f);
				slidesTimer.Start(newLifespan);
			}
			if (slidesTimer.isTimerElapsed)
			{
				textStarted = false;
				MoveToNewState(SlideShowState.FadingOut);
			}
		}
	}

	private void UpdateFadeOut()
	{
		foreach (ParticleSystem item in slidesList[currentSlideIndex].particlesToStop)
		{
			if (item.isPlaying)
			{
				item.Stop(withChildren: true);
			}
		}
		if (animator != null && !string.IsNullOrEmpty(slidesList[currentSlideIndex].animBoolDisabled))
		{
			animator.SetBool(slidesList[currentSlideIndex].animBoolDisabled, value: false);
		}
		if (slidesList[currentSlideIndex].stopAnyAudioLoop)
		{
			StopAnyAudioLoop();
		}
		if (currentSlideIndex == slidesList.Count - 1)
		{
			if (animator != null)
			{
				foreach (string item2 in animBoolsToDisableOnSkip)
				{
					animator.SetBool(item2, value: false);
				}
			}
			foreach (ParticleSystem item3 in particlesToStopOnSkip)
			{
				item3.Stop(withChildren: true);
			}
			StopAnyAudioLoop();
		}
		if (slidesList[currentSlideIndex].fadeOutDelay > 0f)
		{
			if (!slideDelayTimer.isRunning)
			{
				slideDelayTimer.Start(slidesList[currentSlideIndex].fadeOutDelay);
			}
			if (!slideDelayTimer.isTimerElapsed)
			{
				return;
			}
		}
		if (currentSlideIndex == slidesList.Count - 1 && !hasFadedOutTexts)
		{
			foreach (PugTextEffectFade item4 in textsToFadeOnSkip)
			{
				if (item4.gameObject.activeInHierarchy)
				{
					item4.FadeOut();
				}
			}
			hasFadedOutTexts = true;
		}
		slideAlpha = Mathf.Clamp01(slideAlpha - Time.deltaTime * fadeSpeed);
		if (!slidesList[currentSlideIndex].skipFadingOut)
		{
			slideSR.SetAlpha(slideAlpha);
		}
		if (slideAlpha <= 0f)
		{
			MoveToNextSlide();
		}
	}

	private void UpdateSlidesComplete()
	{
		text.Render("");
		LoadNextScene();
	}

	private void LoadNextScene()
	{
		if (!slidesDone)
		{
			slidesDone = true;
			if (isOutro)
			{
				Manager.menu.PushMenu(RadicalMenu.MenuType.CREDITS);
				creditsMusicPlayer.Play();
			}
			else
			{
				Manager.load.QueueScene("Main", 3f, 1.5f, FadePresets.blackToBlack);
				gameIsStarting = true;
			}
			FadeOutMusic();
		}
	}

	private void StopAnyAudioLoop()
	{
		if (audioLoop.Count <= 0)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in audioLoop)
		{
			item.FadeOutAndStop(1f);
		}
		audioLoop.Clear();
		currentAudioLoopPlaying = 0;
	}

	private void SkipIntro()
	{
		currentSlideIndex = slidesList.Count - 1;
		text.gameObject.SetActive(value: false);
		slideShowState = SlideShowState.FadingOut;
		exitContainer.SetActive(value: false);
		playerSkippedIntro = true;
		AudioManager.Sfx(SfxTableID.menuSkip, Vector3.zero, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.UI);
	}

	private void MoveToNewState(SlideShowState newSlideShowState)
	{
		slideShowState = newSlideShowState;
		slidesTimer.Stop();
	}

	private void FadeOutMusic()
	{
		if (!hasStartedFadeOutMusic)
		{
			Manager.music.FadeOutVolume(4f);
			hasStartedFadeOutMusic = true;
		}
	}

	private void StartText()
	{
		if (!textStarted)
		{
			for (int i = 0; i < syllableComponents.Count; i++)
			{
				syllableComponents[i].enabled = i == slidesList[currentSlideIndex].syllableComponentToUse;
			}
			textStarted = true;
			if (slidesList[currentSlideIndex].text == "")
			{
				text.Render("");
			}
			else
			{
				text.Render(slidesList[currentSlideIndex].text, rewindEffectAnims: true);
			}
		}
	}

	private void MoveToNextSlide()
	{
		currentSlideIndex++;
		if (currentSlideIndex >= slidesList.Count)
		{
			MoveToNewState(SlideShowState.Complete);
			return;
		}
		slideSR.sprite = slidesList[currentSlideIndex].sprite;
		MoveToNewState(SlideShowState.WaitingForNextSlide);
	}

	private void UpdateOverlayBrightness()
	{
		if (shouldShowBrightnessOnSlide && slideShowState == SlideShowState.ShowingSlide && textStarted && syllableComponents[slidesList[currentSlideIndex].syllableComponentToUse].done && !gameIsStarting)
		{
			if (!brightnessStartTimer.isRunning)
			{
				AudioManager.SfxUI(SfxID.flashIntro, 1f, reuse: false, 1f, 0f);
				brightnessStartTimer.Start();
			}
			if (brightnessStartTimer.isRunning && brightnessStartTimer.isTimerElapsed)
			{
				if (!brightnessTimer.isRunning)
				{
					brightnessTimer.Start();
				}
				float elapsedRatio = brightnessTimer.elapsedRatio;
				overlay.SetAlpha(brightnessCurve.Evaluate(Mathf.Clamp01(elapsedRatio)));
			}
		}
		else if (gameIsStarting || !shouldShowBrightnessOnSlide)
		{
			overlay.SetAlpha(Mathf.Clamp01(overlay.color.a - Time.deltaTime * 2f));
		}
	}

	public void ScanSound_AE()
	{
		AudioManager.SfxUI(SfxID.Bell);
	}

	public void FadeOutCreditsMusic()
	{
		if (!(creditsMusicPlayer == null))
		{
			StartCoroutine(FadeOutCreditsMusicCoroutine());
		}
	}

	private IEnumerator FadeOutCreditsMusicCoroutine()
	{
		TimerSimple fadeTimer = new TimerSimple(2f, unscaled: true, startTimer: true);
		while (fadeTimer.invElapsedRatio > 0f)
		{
			creditsMusicPlayer.volume = fadeTimer.invElapsedRatio;
			yield return null;
		}
		creditsMusicPlayer.volume = 0f;
	}
}
