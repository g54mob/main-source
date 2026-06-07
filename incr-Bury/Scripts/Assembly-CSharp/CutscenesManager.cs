using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class CutscenesManager : MonoBehaviour
{
	public enum CutsceneState
	{
		Idle = 0,
		BadEnding = 1,
		GoodEnding = 2
	}

	public static CutscenesManager Singleton;

	public CutsceneState cutsceneState;

	[Header("Bad Ending")]
	[SerializeField]
	private GameObject cloudWall_BlockerWall;

	[SerializeField]
	private List<GameObject> lessonTime_ShowGroupList;

	[SerializeField]
	private GameObject skyroom_HappinessFace;

	[SerializeField]
	private AudioSource monologueSource_BadEnding;

	[SerializeField]
	private GameObject badEnding_Teleprompter_Canvas;

	[SerializeField]
	private GameObject badEnding_Teleprompter_Text;

	[SerializeField]
	private GameObject badEnding_Teleprompter_TOGETHERtext;

	[SerializeField]
	private float be_TOGETHERcanvasTiming;

	private bool be_hasSwappedToTOGETHERcanvas;

	[SerializeField]
	private Vector2 badEnding_TelepromterText_StartAndEndPos;

	private float badEnding_Teleprompter_ScrollSpeedDefault;

	[SerializeField]
	private float badEnding_Teleprompter_ScrollSpeed_ForNonEnglishLanguages;

	[SerializeField]
	private GameObject be_PlayerCollisionCage;

	[SerializeField]
	private GameObject be_LessonTimeLetters;

	[SerializeField]
	private GameObject dummyCoin_Prefab;

	[SerializeField]
	private Transform be_dummyCoin_spawnPoint;

	[SerializeField]
	private GameObject be_tvStaticPlanes;

	private bool be_HasTouchedBackWall;

	[SerializeField]
	private GameObject cameraAttachedTOGETHERText;

	[Header("Animation")]
	[SerializeField]
	private FloatingObjectFollow piggyObjectFollower;

	[SerializeField]
	private Animator piggyAnim;

	[Header("Cameras")]
	[SerializeField]
	private GameObject camera_Player;

	[SerializeField]
	private GameObject camera_PiggyCutscene;

	[SerializeField]
	private GameObject camera_PiggyCutscene_BlackOutSphere;

	[SerializeField]
	private GameObject camera_ChainSawCutscene;

	[Header("BAD ENDING: Ms Rainbow Frames")]
	[SerializeField]
	private int be_msRainbow_CurrentFrame;

	[SerializeField]
	private List<float> be_msRainbow_FrameTimes;

	[SerializeField]
	private List<GameObject> be_msRainbow_Frames;

	[SerializeField]
	private List<float> be_TimeMarkers;

	[SerializeField]
	private List<float> be_SpeedMarkers;

	[Header("Good Ending (Hatch)")]
	[SerializeField]
	private Animator hatch_Anim;

	[SerializeField]
	private Transform pit_TeleportPlayerLocation;

	[SerializeField]
	private AudioSource monologueSource_GoodEnding;

	[SerializeField]
	private GameObject ge_PlayerCollisionCage;

	[SerializeField]
	private GameObject ge_RainbowSpotLight_Starting;

	[SerializeField]
	private GameObject ge_RainbowSpotLight_EndPose;

	public ParticleSystem ge_WinkSparkle_Particles;

	[Header("GOOD ENDING: Ms Rainbow Frames")]
	[SerializeField]
	private int ge_msRainbow_CurrentFrame;

	[SerializeField]
	private List<float> ge_msRainbow_FrameTimes;

	[SerializeField]
	private List<GameObject> ge_msRainbow_Frames;

	[SerializeField]
	private List<GameObject> ge_CharacterRevealObjects;

	private bool ge_isAnimatingFrames;

	[Header("Good Ending: Subtitles")]
	[SerializeField]
	private List<GameObject> ge_SubtitlesList;

	[SerializeField]
	private List<float> ge_SubtitlesList_Times;

	private float ge_SubtitlesTimer;

	private int ge_SubtitlesIndex_curr;

	[Header("Chainsaw Ending")]
	[SerializeField]
	private Animator anim_ChainsawDrop;

	[SerializeField]
	private Animator anim_ChainsawCutscene;

	[SerializeField]
	private AudioSource chainsawCutting_AudioSource;

	[SerializeField]
	private AudioSource chainsawRumbling_AudioSource;

	[SerializeField]
	private AudioSource chainsaw_Wink_AudioSource;

	[SerializeField]
	private AudioSource radioLanding_AudioSource;

	[SerializeField]
	private AudioSource radioSource_ButtonClick;

	[SerializeField]
	private AudioSource radioSource_SillyMusic;

	[SerializeField]
	private AudioSource radioSource_MurderMusic;

	private bool wasPlayingMonologueBeforePausing_GoodEnding;

	private bool wasPlayingMonologueBeforePausing_BadEnding;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		HudManager singleton = HudManager.Singleton;
		singleton.OnPausingGame_Action = (Action)Delegate.Combine(singleton.OnPausingGame_Action, new Action(OnGamePaused));
		HudManager singleton2 = HudManager.Singleton;
		singleton2.OnUnpausingGame_Action = (Action)Delegate.Combine(singleton2.OnUnpausingGame_Action, new Action(OnGameUnPaused));
		badEnding_Teleprompter_Canvas.SetActive(value: false);
		be_PlayerCollisionCage.SetActive(value: false);
		badEnding_Teleprompter_TOGETHERtext.SetActive(value: false);
		BadEnding_HideAllMsRainbowFrames();
		ge_PlayerCollisionCage.SetActive(value: false);
		GoodEnding_ShowMsRainbowFrame(0, _playScreenEffect: false);
		ShowHideCharacterRevealObjects(_show: false);
		GoodEnding_MsRainbowSpotlightSwap(_endPose: false);
		anim_ChainsawDrop.gameObject.SetActive(value: false);
		anim_ChainsawCutscene.gameObject.SetActive(value: false);
		GoodEnding_HideAllSubtitles();
	}

	private void OnDestroy()
	{
		HudManager singleton = HudManager.Singleton;
		singleton.OnPausingGame_Action = (Action)Delegate.Remove(singleton.OnPausingGame_Action, new Action(OnGamePaused));
		HudManager singleton2 = HudManager.Singleton;
		singleton2.OnUnpausingGame_Action = (Action)Delegate.Remove(singleton2.OnUnpausingGame_Action, new Action(OnGameUnPaused));
	}

	private void Update()
	{
		if (Application.isEditor && Input.GetKeyDown(KeyCode.Alpha4))
		{
			GameManager.Singleton.playerObject.transform.position = new Vector3(0f, 7f, -115f);
		}
		if (cutsceneState == CutsceneState.Idle)
		{
			return;
		}
		if (cutsceneState == CutsceneState.BadEnding)
		{
			if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
			{
				float num = badEnding_Teleprompter_ScrollSpeedDefault;
				for (int i = 0; i < be_TimeMarkers.Count; i++)
				{
					if (monologueSource_BadEnding.time >= be_TimeMarkers[i])
					{
						num = badEnding_Teleprompter_ScrollSpeedDefault * be_SpeedMarkers[i];
					}
				}
				if (badEnding_Teleprompter_Text.transform.localPosition.y < badEnding_TelepromterText_StartAndEndPos.y)
				{
					badEnding_Teleprompter_Text.transform.Translate(Vector3.up * (num * Time.deltaTime), Space.Self);
				}
			}
			else if (badEnding_Teleprompter_Text.transform.localPosition.y < badEnding_TelepromterText_StartAndEndPos.y)
			{
				badEnding_Teleprompter_Text.transform.Translate(Vector3.up * (badEnding_Teleprompter_ScrollSpeed_ForNonEnglishLanguages * Time.deltaTime), Space.Self);
			}
			BadEnding_HandleMsRainbowFrames();
			if (!be_hasSwappedToTOGETHERcanvas && monologueSource_BadEnding.time >= be_TOGETHERcanvasTiming)
			{
				be_hasSwappedToTOGETHERcanvas = true;
				badEnding_Teleprompter_TOGETHERtext.SetActive(value: true);
				badEnding_Teleprompter_Text.SetActive(value: false);
			}
		}
		else if (cutsceneState == CutsceneState.GoodEnding)
		{
			GoodEnding_HandleMsRainbowFrames();
			GoodEnding_HandleSubtitles();
		}
	}

	public void SkyRoom_BackwallTrigger_Entered()
	{
		if (be_HasTouchedBackWall)
		{
			return;
		}
		be_HasTouchedBackWall = true;
		cloudWall_BlockerWall.SetActive(value: true);
		skyroom_HappinessFace.SetActive(value: false);
		foreach (GameObject lessonTime_ShowGroup in lessonTime_ShowGroupList)
		{
			lessonTime_ShowGroup.SetActive(value: true);
		}
		AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(GameManager.Singleton.playerObject.transform.position);
		VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(1.2f);
		AudioManager.Singleton.PlayAmbientTrack(7, 0f, _fadeIn: false, 0.25f);
	}

	public void BadEnding_StartCutscene()
	{
		CassettesManager.Singleton.StopAllTapes();
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip)
		{
			SkipCutsceneModActive_BadEndingSkip();
		}
		else if (cutsceneState == CutsceneState.Idle)
		{
			HudManager.Singleton.DisableHudForCutscenes();
			GameManager.Singleton.radioInScene.StopRadioMusic();
			be_PlayerCollisionCage.SetActive(value: true);
			BadEnding_ResetMsBerryFrames();
			badEnding_Teleprompter_Text.transform.localPosition = new Vector3(badEnding_Teleprompter_Text.transform.localPosition.x, badEnding_TelepromterText_StartAndEndPos.x, badEnding_Teleprompter_Text.transform.localPosition.z);
			badEnding_Teleprompter_ScrollSpeedDefault = 2.293519f;
			CalculateBadEndingScrollSpeed_ForNonEnglishLanguages();
			GameManager.Singleton.ChangeGameState(GameManager.GameState.Cutscene);
			cutsceneState = CutsceneState.BadEnding;
			be_hasSwappedToTOGETHERcanvas = false;
			badEnding_Teleprompter_TOGETHERtext.SetActive(value: false);
			badEnding_Teleprompter_Canvas.SetActive(value: true);
			badEnding_Teleprompter_Text.SetActive(value: true);
			AudioManager.Singleton.QuietDownAmbientPlayer(0.5f);
			AudioManager.Singleton.ResetDuckedVolume();
			monologueSource_BadEnding.volume = AudioManager.Singleton.sfxVolume * 1.5f;
			monologueSource_BadEnding.Play();
			be_LessonTimeLetters.SetActive(value: false);
		}
	}

	private void CalculateBadEndingScrollSpeed_ForNonEnglishLanguages()
	{
		if (!(LocalizationSettings.SelectedLocale.Identifier.Code == "en"))
		{
			Debug.Log("Non-English detected, calculating text scroll speed");
			badEnding_Teleprompter_ScrollSpeed_ForNonEnglishLanguages = Mathf.Abs(badEnding_TelepromterText_StartAndEndPos.y - badEnding_TelepromterText_StartAndEndPos.x) / (monologueSource_BadEnding.clip.length - 3.5f);
		}
	}

	public void BadEnding_ResetMsBerryFrames()
	{
		be_msRainbow_CurrentFrame = 0;
		BadEnding_ShowMsRainbowFrame(0);
	}

	private void BadEnding_HandleMsRainbowFrames()
	{
		if (be_msRainbow_CurrentFrame + 1 < be_msRainbow_FrameTimes.Count && monologueSource_BadEnding.time > be_msRainbow_FrameTimes[be_msRainbow_CurrentFrame + 1])
		{
			be_msRainbow_CurrentFrame++;
			BadEnding_ShowMsRainbowFrame(be_msRainbow_CurrentFrame);
		}
	}

	private void BadEnding_HideAllMsRainbowFrames()
	{
		foreach (GameObject be_msRainbow_Frame in be_msRainbow_Frames)
		{
			be_msRainbow_Frame.SetActive(value: false);
		}
	}

	public void BadEnding_ShowMsRainbowFrame(int _frame, bool _playScreenEffect = true)
	{
		if (_frame > be_msRainbow_Frames.Count - 1)
		{
			Debug.Log("No more ms rainbow frames.");
			return;
		}
		BadEnding_HideAllMsRainbowFrames();
		if (be_msRainbow_Frames[_frame] != null)
		{
			be_msRainbow_Frames[_frame].SetActive(value: true);
		}
		if (_playScreenEffect)
		{
			AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(be_msRainbow_Frames[_frame].transform.position, 0.5f);
			VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(1.8f);
		}
		switch (_frame)
		{
		case 3:
			SpawnDummyCoins_BadEnding();
			break;
		case 30:
			AudioManager.Singleton.PlaySFX_GlitchedAlarm();
			be_tvStaticPlanes.SetActive(value: true);
			BadEnding_ShowTogetherJumpScareTextInNonEnglishLanguages();
			StartCoroutine(WaitASecThenChangeToPiggyCutscene());
			break;
		}
		Debug.Log("FRAME: " + _frame);
	}

	private void SpawnDummyCoins_BadEnding()
	{
		for (int i = 0; i < 30; i++)
		{
			UnityEngine.Object.Instantiate(dummyCoin_Prefab, be_dummyCoin_spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.1f, 0.8f), UnityEngine.Random.Range(-1f, 1f)) * 5f, ForceMode.VelocityChange);
		}
		AudioManager.Singleton.PlayCoinDummyDroppingSequence(be_dummyCoin_spawnPoint.position);
	}

	private IEnumerator WaitASecThenChangeToPiggyCutscene()
	{
		yield return new WaitForSeconds(2f);
		GameManager.Singleton.PiggyEndingCutscene_SwitchToNightVisuals();
		camera_Player.SetActive(value: false);
		camera_PiggyCutscene.SetActive(value: true);
		StartCoroutine(PiggyCutscene_BlackScreenDelay(3f));
	}

	private IEnumerator PiggyCutscene_BlackScreenDelay(float _delay)
	{
		camera_PiggyCutscene_BlackOutSphere.SetActive(value: true);
		yield return new WaitForSeconds(_delay);
		StartCoroutine(FadeOutMaterial(2f, camera_PiggyCutscene_BlackOutSphere.GetComponent<Renderer>()));
		AudioManager.Singleton.PlayAmbientTrack(5, 0f, _fadeIn: false, 0.4f);
		AudioManager.Singleton.PlaySFX_RisingSpookyShrillNoise(10.8f);
		yield return new WaitForSeconds(2f);
		piggyObjectFollower.EnableMovement();
		yield return new WaitForSeconds(2f);
		piggyAnim.Play("PigBlink");
	}

	private IEnumerator FadeOutMaterial(float duration, Renderer _rend)
	{
		Material mat = _rend.material;
		Color color = mat.GetColor("_BaseColor");
		float startAlpha = color.a;
		float t = 0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			color.a = Mathf.Lerp(startAlpha, 0f, t / duration);
			mat.SetColor("_BaseColor", color);
			yield return null;
		}
		color.a = 0f;
		mat.SetColor("_BaseColor", color);
	}

	public void PiggyEnding_CutToBlack()
	{
		Material material = camera_PiggyCutscene_BlackOutSphere.GetComponent<Renderer>().material;
		Color color = material.GetColor("_BaseColor");
		color.a = 1f;
		material.SetColor("_BaseColor", color);
		AudioManager.Singleton.PlayNightTimeHeavyLeverSFX();
		AudioManager.Singleton.StopAmbientMusic();
		PlayerStats.Singleton.ending_Happiness = true;
		StartCoroutine(WaitASecThenLoadCreditsScene(5f));
	}

	private IEnumerator WaitASecThenLoadCreditsScene(float _delay)
	{
		yield return new WaitForSeconds(_delay);
		GameManager.Singleton.StoreThisRoundsPlaytimeIntoStats();
		MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
		if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
		{
			MenuToGameBridger.Singleton.endingCompletedString = "Together";
		}
		else
		{
			MenuToGameBridger.Singleton.endingCompletedString = "B";
		}
		MenuToGameBridger.Singleton.comingBackToMainMenuFromPigEnding = true;
		SceneManager.LoadScene("Credits");
	}

	private void SkipCutsceneModActive_BadEndingSkip()
	{
		PlayerStats.Singleton.ending_Happiness = true;
		GameManager.Singleton.StoreThisRoundsPlaytimeIntoStats();
		MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
		if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
		{
			MenuToGameBridger.Singleton.endingCompletedString = "Together";
		}
		else
		{
			MenuToGameBridger.Singleton.endingCompletedString = "B";
		}
		MenuToGameBridger.Singleton.comingBackToMainMenuFromPigEnding = true;
		SceneManager.LoadScene("EndingResults");
	}

	private void SkipCutsceneModActive_GoodEndingSkip()
	{
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
		SceneManager.LoadScene("EndingResults");
	}

	public void PlayAnim_OpenHatch()
	{
		AudioManager.Singleton.PlaySFX_HatchOpen(hatch_Anim.gameObject.transform.position);
		hatch_Anim.Play("OpenHatch");
	}

	public void TeleportPlayerToEndGamePit()
	{
		AudioManager.Singleton.PlayAmbientTrack(2, 0.5f, _fadeIn: true);
		GameManager.Singleton.playerObject.GetComponent<Rigidbody>().position = pit_TeleportPlayerLocation.position;
		CassettesManager.Singleton.StopAllTapes();
	}

	public void GoodEnding_StartCutscene()
	{
		CassettesManager.Singleton.StopAllTapes();
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip)
		{
			SkipCutsceneModActive_GoodEndingSkip();
		}
		else if (cutsceneState == CutsceneState.Idle)
		{
			if (PcManager.Singleton.confession_IsPlaying)
			{
				PcManager.Singleton.ConfessionMonologue_Stop();
			}
			ge_isAnimatingFrames = true;
			HudManager.Singleton.DisableHudForCutscenes();
			GameManager.Singleton.radioInScene.StopRadioMusic();
			ge_PlayerCollisionCage.SetActive(value: true);
			GoodEnding_ResetMsBerryFrames();
			GameManager.Singleton.ChangeGameState(GameManager.GameState.Cutscene);
			cutsceneState = CutsceneState.GoodEnding;
			AudioManager.Singleton.QuietDownAmbientPlayer(0.35f);
			AudioManager.Singleton.ResetDuckedVolume();
			monologueSource_GoodEnding.volume = AudioManager.Singleton.sfxVolume * 1.5f;
			monologueSource_GoodEnding.Play();
			StartCoroutine(StartChainsawDrop_wDelay());
			GoodEnding_ResetSubtitles();
		}
	}

	public void GoodEnding_ResetMsBerryFrames()
	{
		ge_msRainbow_CurrentFrame = 0;
		GoodEnding_ShowMsRainbowFrame(0);
	}

	private void GoodEnding_HandleMsRainbowFrames()
	{
		if (ge_isAnimatingFrames && ge_msRainbow_CurrentFrame + 1 < ge_msRainbow_FrameTimes.Count && monologueSource_GoodEnding.time > ge_msRainbow_FrameTimes[ge_msRainbow_CurrentFrame + 1])
		{
			ge_msRainbow_CurrentFrame++;
			GoodEnding_ShowMsRainbowFrame(ge_msRainbow_CurrentFrame);
		}
	}

	private void GoodEnding_HideAllMsRainbowFrames()
	{
		foreach (GameObject ge_msRainbow_Frame in ge_msRainbow_Frames)
		{
			ge_msRainbow_Frame.SetActive(value: false);
		}
	}

	public void GoodEnding_ShowMsRainbowFrame(int _frame, bool _playScreenEffect = true)
	{
		if (_frame > ge_msRainbow_Frames.Count - 1)
		{
			Debug.Log("No more ms rainbow frames.");
			return;
		}
		GoodEnding_HideAllMsRainbowFrames();
		if (ge_msRainbow_Frames[_frame] != null)
		{
			ge_msRainbow_Frames[_frame].SetActive(value: true);
		}
		if (_playScreenEffect)
		{
			AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(ge_msRainbow_Frames[_frame].transform.position, 0.5f);
			VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(1.8f);
		}
		switch (_frame)
		{
		case 32:
			ShowHideCharacterRevealObjects(_show: true);
			AudioManager.Singleton.PlayNightTimeHeavyLeverSFX();
			break;
		case 36:
			GoodEnding_MsRainbowSpotlightSwap(_endPose: true);
			break;
		}
		Debug.Log("FRAME: " + _frame);
	}

	public void GoodEnding_HandleSubtitles()
	{
		if (cutsceneState == CutsceneState.GoodEnding && ge_SubtitlesIndex_curr < ge_SubtitlesList.Count - 1)
		{
			ge_SubtitlesTimer += Time.deltaTime;
			if (ge_SubtitlesTimer >= ge_SubtitlesList_Times[ge_SubtitlesIndex_curr + 1])
			{
				ge_SubtitlesIndex_curr++;
				GoodEnding_ShowSubtitle(ge_SubtitlesIndex_curr);
			}
		}
	}

	public void GoodEnding_HideAllSubtitles()
	{
		foreach (GameObject ge_Subtitles in ge_SubtitlesList)
		{
			if ((bool)ge_Subtitles)
			{
				ge_Subtitles.SetActive(value: false);
			}
		}
	}

	public void GoodEnding_ShowSubtitle(int _index)
	{
		GoodEnding_HideAllSubtitles();
		if ((bool)ge_SubtitlesList[_index])
		{
			ge_SubtitlesList[_index].SetActive(value: true);
		}
	}

	public void GoodEnding_ResetSubtitles()
	{
		ge_SubtitlesIndex_curr = 0;
		ge_SubtitlesTimer = 0.27f;
		GoodEnding_HideAllSubtitles();
	}

	private void ShowHideCharacterRevealObjects(bool _show)
	{
		foreach (GameObject ge_CharacterRevealObject in ge_CharacterRevealObjects)
		{
			ge_CharacterRevealObject.SetActive(_show);
		}
	}

	private void GoodEnding_MsRainbowSpotlightSwap(bool _endPose)
	{
		if (_endPose)
		{
			ge_RainbowSpotLight_Starting.SetActive(value: false);
			ge_RainbowSpotLight_EndPose.SetActive(value: true);
		}
		else
		{
			ge_RainbowSpotLight_Starting.SetActive(value: true);
			ge_RainbowSpotLight_EndPose.SetActive(value: false);
		}
	}

	private IEnumerator StartChainsawDrop_wDelay()
	{
		yield return new WaitForSeconds(160f);
		ChainsawDrop_StartAnimation();
	}

	public void ChainsawDrop_StartAnimation()
	{
		HudManager.Singleton.EnableCrossHairs();
		anim_ChainsawDrop.gameObject.SetActive(value: true);
		anim_ChainsawDrop.Play("Chainsaw Drop");
	}

	public void ChainsawCutscene_Start()
	{
		GoodEnding_HideAllMsRainbowFrames();
		ge_isAnimatingFrames = false;
		anim_ChainsawDrop.gameObject.SetActive(value: false);
		camera_Player.SetActive(value: false);
		camera_PiggyCutscene.SetActive(value: false);
		camera_ChainSawCutscene.SetActive(value: true);
		anim_ChainsawCutscene.gameObject.SetActive(value: true);
		anim_ChainsawCutscene.Play("Anim_ChainsawEnding");
	}

	public void StartChainsawCuttingSFX()
	{
		chainsawCutting_AudioSource.volume = AudioManager.Singleton.sfxVolume;
		chainsawCutting_AudioSource.Play();
	}

	public void StopChainsawCuttingSFX()
	{
		chainsawCutting_AudioSource.Stop();
	}

	public void PlaySFX_ChainsawWink()
	{
		chainsaw_Wink_AudioSource.volume = AudioManager.Singleton.sfxVolume * 2f;
		chainsaw_Wink_AudioSource.Play();
	}

	public void PlaySFX_RadioLanding()
	{
		radioLanding_AudioSource.volume = AudioManager.Singleton.sfxVolume;
		radioLanding_AudioSource.Play();
	}

	public void PlaySFX_RadioButtonClick()
	{
		radioSource_ButtonClick.volume = AudioManager.Singleton.sfxVolume;
		radioSource_ButtonClick.Play();
	}

	public void PlayRadioMusic_SillyMusic()
	{
		radioSource_SillyMusic.Play();
	}

	public void PlayRadioMusic_MurderMusic()
	{
		radioSource_MurderMusic.Play();
	}

	public void StopRadioMusic_SillyMusic()
	{
		radioSource_SillyMusic.Stop();
	}

	public void StopRadioMusic_MurderMusic()
	{
		radioSource_MurderMusic.Stop();
	}

	public void StopChainsawRumbling()
	{
		chainsawRumbling_AudioSource.Stop();
	}

	private void OnGameUnPaused()
	{
		if (cutsceneState == CutsceneState.BadEnding)
		{
			if (wasPlayingMonologueBeforePausing_BadEnding)
			{
				wasPlayingMonologueBeforePausing_BadEnding = false;
				monologueSource_BadEnding.UnPause();
			}
		}
		else if (cutsceneState == CutsceneState.GoodEnding && wasPlayingMonologueBeforePausing_GoodEnding)
		{
			wasPlayingMonologueBeforePausing_GoodEnding = false;
			monologueSource_GoodEnding.UnPause();
		}
	}

	private void OnGamePaused()
	{
		if (cutsceneState == CutsceneState.BadEnding)
		{
			if (monologueSource_BadEnding.isPlaying)
			{
				wasPlayingMonologueBeforePausing_BadEnding = true;
				monologueSource_BadEnding.Pause();
			}
		}
		else if (cutsceneState == CutsceneState.GoodEnding && monologueSource_GoodEnding.isPlaying)
		{
			wasPlayingMonologueBeforePausing_GoodEnding = true;
			monologueSource_GoodEnding.Pause();
		}
	}

	private void BadEnding_ShowTogetherJumpScareTextInNonEnglishLanguages()
	{
		cameraAttachedTOGETHERText.SetActive(LocalizationSettings.SelectedLocale.Identifier.Code != "en");
	}
}
