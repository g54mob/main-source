using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using VolFx;

public class VcrIntroManager : MonoBehaviour
{
	public static VcrIntroManager Singleton;

	[SerializeField]
	private GameObject blueScreenParentGroup;

	[SerializeField]
	private GameObject vcr_TextAndSymbol_Play;

	[SerializeField]
	private GameObject vcr_TextAndSymbol_Pause;

	[SerializeField]
	private GameObject vcr_TextAndSymbol_Eject;

	[SerializeField]
	private TMP_Text vcrRoundCounter_Text;

	[SerializeField]
	private VolumeProfile postVolumeProfile;

	public bool isIntroActive;

	private bool fadeOutVcrEffect;

	[SerializeField]
	private float vcrEffect_FadeCurr;

	[SerializeField]
	private float vcrEffect_Fade_Speed;

	[Header("Audio")]
	[SerializeField]
	private AudioSource vcr_PlayNoise_Source;

	[SerializeField]
	private AudioSource vcr_EjectNoise_Source;

	[SerializeField]
	private AudioClip sfx_TapeDistortStop;

	public bool isInBlackStarOrbScreenEffects;

	private float blackStarEffects_Squeeze_Base;

	[SerializeField]
	private float blackStar_ScreenEffects_Duration;

	private float blackStar_DefaultDuration;

	private float blackStar_ScreenEffects_Duration_Curr;

	public bool glitchScreenUntilFalse;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		blueScreenParentGroup.SetActive(value: true);
		blackStar_DefaultDuration = blackStar_ScreenEffects_Duration;
	}

	private void Update()
	{
		HandleVcrEffectFadeOut();
		HandleBlackStarScreenEffects();
		if (Application.isEditor && Input.GetKeyDown(KeyCode.Alpha3))
		{
			AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(GameManager.Singleton.playerObject.transform.position);
			StartGlitchedOutBlackStarOrbEffect(1.2f);
		}
	}

	public void VCR_Intro_Reset()
	{
		blueScreenParentGroup.SetActive(value: true);
		HudManager.Singleton.HideAllCurrencyDisplays();
		isIntroActive = false;
		fadeOutVcrEffect = false;
		SetVcrPostEffect(1f);
		vcrEffect_FadeCurr = 1f;
		vcr_TextAndSymbol_Pause.SetActive(value: true);
		vcr_TextAndSymbol_Play.SetActive(value: false);
		vcrRoundCounter_Text.gameObject.SetActive(value: true);
		vcrRoundCounter_Text.text = GetVHSCounterFromNumber(PlayerStats.Singleton.totalRounds);
		if (postVolumeProfile.TryGet<ColorAdjustments>(out var component))
		{
			component.postExposure.value = 0f;
			component.contrast.value = 50f;
			if (OptionsManager.Singleton.colorDesaturation_Setting == 1)
			{
				component.saturation.value = -16f;
			}
			else
			{
				component.saturation.value = 0f;
			}
		}
		if (postVolumeProfile.TryGet<VhsVol>(out var component2))
		{
			component2._squeeze.value = blackStarEffects_Squeeze_Base;
		}
	}

	private IEnumerator StartVcrIntro_Coroutine()
	{
		isIntroActive = true;
		vcr_PlayNoise_Source.volume = AudioManager.Singleton.sfxVolume;
		yield return new WaitForSeconds(0.2f);
		vcr_PlayNoise_Source.Play();
		yield return new WaitForSeconds(1f);
		vcr_TextAndSymbol_Pause.SetActive(value: false);
		vcr_TextAndSymbol_Play.SetActive(value: true);
		yield return new WaitForSeconds(0.5f);
		vcrRoundCounter_Text.text = GetVHSCounterFromNumber(PlayerStats.Singleton.totalRounds + 1);
		yield return new WaitForSeconds(1f);
		try
		{
			if (MenuToGameBridger.Singleton.HasNGPlusModsOn())
			{
				PlayerStats.Singleton.disableTutorials = true;
			}
		}
		catch
		{
		}
		GameManager.Singleton.ChangeGameState(GameManager.GameState.Playing);
		yield return new WaitForSeconds(0.5f);
		blueScreenParentGroup.SetActive(value: false);
		HudManager.Singleton.ShowAllCurrencyDisplays();
		isIntroActive = false;
		fadeOutVcrEffect = true;
	}

	private IEnumerator StartVcr_ENDING_EJECT_Coroutine()
	{
		blueScreenParentGroup.SetActive(value: true);
		vcr_TextAndSymbol_Play.SetActive(value: true);
		vcr_TextAndSymbol_Pause.SetActive(value: false);
		isIntroActive = true;
		vcr_PlayNoise_Source.volume = AudioManager.Singleton.sfxVolume;
		yield return new WaitForSeconds(0.2f);
		vcr_EjectNoise_Source.Play();
		yield return new WaitForSeconds(2f);
		vcr_TextAndSymbol_Pause.SetActive(value: false);
		vcr_TextAndSymbol_Play.SetActive(value: false);
		vcr_TextAndSymbol_Eject.SetActive(value: true);
		yield return new WaitForSeconds(3f);
		isIntroActive = false;
		fadeOutVcrEffect = true;
		PlayerStats.Singleton.ending_Chainsaw = true;
		GameManager.Singleton.StoreThisRoundsPlaytimeIntoStats();
		MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
		if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
		{
			MenuToGameBridger.Singleton.endingCompletedString = "Truth";
		}
		else
		{
			MenuToGameBridger.Singleton.endingCompletedString = "A";
		}
		MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding = true;
		SceneManager.LoadScene("Epilogue");
	}

	public void PlayTapeWindDownSFX()
	{
		vcr_PlayNoise_Source.PlayOneShot(sfx_TapeDistortStop, AudioManager.Singleton.sfxVolume);
	}

	public void StartIntro()
	{
		vcrRoundCounter_Text.gameObject.SetActive(value: false);
		VCR_Intro_Reset();
		StartCoroutine(StartVcrIntro_Coroutine());
	}

	public void StartEnding_EJECT()
	{
		vcrRoundCounter_Text.gameObject.SetActive(value: true);
		VCR_Intro_Reset();
		StartCoroutine(StartVcr_ENDING_EJECT_Coroutine());
	}

	private void HandleVcrEffectFadeOut()
	{
		if (fadeOutVcrEffect)
		{
			if (vcrEffect_FadeCurr > 0f)
			{
				vcrEffect_FadeCurr -= Time.deltaTime * vcrEffect_Fade_Speed;
			}
			else
			{
				vcrEffect_FadeCurr = 0f;
				fadeOutVcrEffect = false;
			}
			SetVcrPostEffect(vcrEffect_FadeCurr);
		}
	}

	public void SetVcrPostEffect(float _val)
	{
		_val = Mathf.Clamp(_val, 0f, 1f);
		if (postVolumeProfile.TryGet<VhsVol>(out var component))
		{
			component._weight.value = _val;
		}
	}

	private string GetVHSCounterFromNumber(int _value)
	{
		_value = Mathf.Clamp(_value, 0, 9999);
		int num = _value / 100;
		int num2 = _value % 100;
		return $"{num:00}:{num2:00}";
	}

	public void SetGlitchedChainsawScreenEffects(bool _val)
	{
		glitchScreenUntilFalse = _val;
		if (glitchScreenUntilFalse)
		{
			if (postVolumeProfile.TryGet<VhsVol>(out var component))
			{
				blackStarEffects_Squeeze_Base = 0.45f;
				component._squeeze.value = 0.965f;
				component._weight.value = 1f;
			}
		}
		else
		{
			isInBlackStarOrbScreenEffects = true;
			blackStar_ScreenEffects_Duration = 3f;
			blackStar_ScreenEffects_Duration_Curr = 1f;
		}
	}

	public void StartGlitchedOutBlackStarOrbEffect(float _duration = -1f)
	{
		isInBlackStarOrbScreenEffects = true;
		if (postVolumeProfile.TryGet<VhsVol>(out var component))
		{
			blackStarEffects_Squeeze_Base = 0.45f;
			component._squeeze.value = 0.965f;
			component._weight.value = 1f;
		}
		blackStar_ScreenEffects_Duration = ((_duration == -1f) ? blackStar_DefaultDuration : _duration);
		blackStar_ScreenEffects_Duration_Curr = 1f;
	}

	private void HandleBlackStarScreenEffects()
	{
		if (!isInBlackStarOrbScreenEffects)
		{
			return;
		}
		if (postVolumeProfile.TryGet<VhsVol>(out var component))
		{
			component._weight.value = Mathf.Lerp(0f, 1f, blackStar_ScreenEffects_Duration_Curr);
			component._squeeze.value = Mathf.Lerp(blackStarEffects_Squeeze_Base, 1f, blackStar_ScreenEffects_Duration_Curr);
		}
		if (postVolumeProfile.TryGet<ColorAdjustments>(out var component2))
		{
			component2.postExposure.value = Mathf.Lerp(0f, -0.5f, blackStar_ScreenEffects_Duration_Curr);
			component2.contrast.value = Mathf.Lerp(50f, 100f, blackStar_ScreenEffects_Duration_Curr);
			component2.saturation.value = Mathf.Lerp(0f, -100f, blackStar_ScreenEffects_Duration_Curr);
		}
		blackStar_ScreenEffects_Duration_Curr -= Time.deltaTime / blackStar_ScreenEffects_Duration;
		if (!(blackStar_ScreenEffects_Duration_Curr <= 0f))
		{
			return;
		}
		if (postVolumeProfile.TryGet<VhsVol>(out var component3))
		{
			component3._weight.value = 0f;
			component3._squeeze.value = blackStarEffects_Squeeze_Base;
		}
		if (postVolumeProfile.TryGet<ColorAdjustments>(out var component4))
		{
			component4.postExposure.value = 0f;
			component4.contrast.value = 50f;
			if (OptionsManager.Singleton.colorDesaturation_Setting == 1)
			{
				component2.saturation.value = -16f;
			}
			else
			{
				component2.saturation.value = 0f;
			}
		}
		isInBlackStarOrbScreenEffects = false;
	}
}
