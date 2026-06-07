using System.Collections;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverworldTrollManager : MonoBehaviour
{
	public enum OverworldState
	{
		ACT_I = 0,
		ACT_II = 1,
		ACT_III = 2
	}

	public enum Ending
	{
		BadEnding = 0,
		GoodEnding = 1,
		AscensionEnding = 2,
		DuckEnding = 3
	}

	public TrollDialogManager trollDialogManager;

	public TransitionManager transitionManager;

	public SoundManager soundManager;

	public BridgeLoop bridgeLoop;

	public CameraFollow cameraFollow;

	public PlayerMovement playerMovement;

	public ObjectShake playerShake;

	public SineScale playerSineScale;

	public Transform playerTransform;

	public Transform act1PlayerPosition;

	public float distanceToInput;

	private bool performedInput;

	public bool introCutscene;

	public bool inTitelCard;

	public bool outroCutscene;

	public Animator actDisplayAnimator;

	public TMP_Text actDisplayText;

	public LocalizedString actLocalizedString;

	public Animator outlineAnimator;

	public Animator fillAnimator;

	public Transform promptTextHolder;

	public Vector3 textOffset;

	public AnimationCurve manholeCurve;

	public Transform manHoleTransform;

	public AnimationCurve trollCurve;

	public Transform trollTransform;

	public GameObject titleCardScreen;

	public TMP_Text titleCardText;

	public Transform act3PlayerPosition;

	public static Vector3 trollCapturePosition;

	public AnimationCurve trollDefeatXCurve;

	public AnimationCurve trollDefeatYCurve;

	public ObjectShake trollShake;

	public AnimationCurve slipRotationCurve;

	public AnimationCurve slipYCurve;

	public DuckManager duckManager;

	public Transform duckEndingObjects;

	public SpriteRenderer trollOutlineRenderer;

	public SpriteRenderer trollFillRenderer;

	public Transform bridgeCollision;

	public AnimationCurve cameraCurve;

	public GlobalColor outlineColor;

	public GlobalColor whiteColor;

	public bool mouseClicked;

	public float lookTime;

	private bool doCheckForeshadowing;

	private float elapsedShadowTime;

	public LocalizedString crossTheBridgeString;

	public LocalizedString badEndingString;

	public LocalizedString goodEndingString;

	public LocalizedString ascensionEndingString;

	public LocalizedString duckEndingString;

	public LocalizedString remainOnBridgeString;

	public LocalizedString attemptCountSingularString;

	public LocalizedString attemptCountMultipleString;

	public LocalizedString timeCountHourString;

	public LocalizedString timeCountHoursString;

	public LocalizedString timeCountMinuteString;

	public LocalizedString timeCountMinutesString;

	public LocalizedString timeCountSecondString;

	public LocalizedString timeCountSecondsString;

	public LocalizedString timeCountTextString;

	public LocalizedString scrapCountSingularString;

	public LocalizedString scrapCountMultipleString;

	public LocalizedString cheatCountZeroString;

	public LocalizedString cheatCountSingularString;

	public LocalizedString cheatCountMultipleString;

	public void Awake()
	{
		PlayerSaveData playerSaveData = SaveSystem.LoadPlayerSaveData();
		if (playerSaveData == null)
		{
			SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		}
		else
		{
			SaveSystem.currentPlayerSaveData = playerSaveData;
		}
	}

	public void Start()
	{
		soundManager = SoundManager.instance;
		SoundManager.LoadSoundEffect(soundManager.ambientSource.transform, soundManager.overworld_bridge_ambience);
		titleCardScreen.GetComponent<Image>().color = outlineColor.globalColor;
		titleCardText.color = whiteColor.globalColor;
		switch (SaveSystem.currentPlayerSaveData.overworldState)
		{
		case OverworldState.ACT_I:
			outlineAnimator.gameObject.SetActive(value: false);
			fillAnimator.gameObject.SetActive(value: false);
			SetRealWorld(act1PlayerPosition.position, 0f);
			StartCoroutine(TitleCard(crossTheBridgeString.GetLocalizedString()));
			StartCoroutine(DisplayAct(7f));
			break;
		case OverworldState.ACT_II:
			bridgeLoop.gameObject.SetActive(value: true);
			StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.rematchInvitationTopics), 1f));
			StartCoroutine(DisplayAct(0f));
			break;
		case OverworldState.ACT_III:
			introCutscene = true;
			SetRealWorld(act3PlayerPosition.position, 2.5f);
			if (SaveSystem.currentPlayerSaveData.ending == Ending.GoodEnding || SaveSystem.currentPlayerSaveData.ending == Ending.BadEnding)
			{
				transitionManager.gameObject.SetActive(value: false);
				transitionManager.SetMasterVolume(0f);
				outlineAnimator.enabled = false;
				fillAnimator.enabled = false;
				trollCapturePosition = new Vector3(trollCapturePosition.x, trollCapturePosition.y - 2.5f, trollCapturePosition.z);
				trollTransform.localPosition = trollCapturePosition;
				StartCoroutine(OutroCutscene());
			}
			if (SaveSystem.currentPlayerSaveData.ending == Ending.AscensionEnding)
			{
				transitionManager.gameObject.SetActive(value: false);
				transitionManager.SetMasterVolume(0f);
				titleCardScreen.GetComponent<Image>().color = whiteColor.globalColor;
				titleCardText.color = outlineColor.globalColor;
				StartCoroutine(Credits());
			}
			if (SaveSystem.currentPlayerSaveData.ending == Ending.DuckEnding)
			{
				duckEndingObjects.gameObject.SetActive(value: true);
				duckManager.StartSwimming();
				duckManager.enabled = false;
				duckManager.rb.velocity = Vector2.left * duckManager.swimSpeed;
				cameraFollow.enabled = false;
				cameraFollow.transform.position = new Vector3(duckManager.transform.position.x, playerTransform.position.y, cameraFollow.transform.position.z);
				trollTransform.transform.SetParent(duckManager.pieceHolder.transform);
				trollTransform.transform.localPosition = new Vector3(0f, 0.25f, 0f);
				trollOutlineRenderer.sortingLayerName = "Background";
				trollFillRenderer.sortingLayerName = "Background";
				trollOutlineRenderer.GetComponent<DepthSorter>().enabled = false;
				trollFillRenderer.GetComponent<DepthSorter>().enabled = false;
				trollFillRenderer.sortingOrder = duckManager.spriteRenderer.sortingOrder - 2;
				trollOutlineRenderer.sortingOrder = duckManager.spriteRenderer.sortingOrder - 1;
				bridgeCollision.gameObject.SetActive(value: false);
				StartCoroutine(DuckCutscene());
			}
			StartCoroutine(DisplayAct(0f));
			break;
		}
		SaveSystem.currentPlayerSaveData.firstGameinScene = true;
		SpeedrunTimer.doCountTime = true;
		if (SteamAchievements.IsThisAchievementUnlocked("BAD_ENDING") || SteamAchievements.IsThisAchievementUnlocked("GOOD_ENDING") || SteamAchievements.IsThisAchievementUnlocked("ASCENSION_ENDING") || SteamAchievements.IsThisAchievementUnlocked("DUCK_ENDING"))
		{
			doCheckForeshadowing = true;
		}
	}

	public void Update()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldState.ACT_I && (double)playerTransform.position.y > -2.5 && !introCutscene)
		{
			introCutscene = true;
			StartCoroutine(IntroCutscene());
			playerMovement.StopMovement();
		}
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldState.ACT_II && !introCutscene)
		{
			CheckForStartInput();
		}
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldState.ACT_III && playerTransform.position.y > 20f && !outroCutscene)
		{
			outroCutscene = true;
			playerMovement.StopMovement();
			StartCoroutine(PlayerOutro());
		}
		if (SaveSystem.currentPlayerSaveData.overworldState != OverworldState.ACT_II && playerTransform.position.y < -60f)
		{
			playerMovement.StopMovement();
			SetRealWorld(act1PlayerPosition.position, 0f);
			StartCoroutine(TitleCard(crossTheBridgeString.GetLocalizedString()));
			SteamAchievements.UnlockAchievement("WALK_WRONG_WAY");
		}
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
		{
			mouseClicked = true;
		}
		if (!doCheckForeshadowing)
		{
			return;
		}
		if (playerTransform.position.y > trollTransform.position.y && Vector3.Distance(playerTransform.position, trollTransform.position) < 0.25f)
		{
			if (elapsedShadowTime < 1f)
			{
				elapsedShadowTime += Time.deltaTime;
				return;
			}
			elapsedShadowTime = 0f;
			SteamAchievements.UnlockAchievement("HIDE_BEHIND_TROLL");
			doCheckForeshadowing = false;
		}
		else
		{
			elapsedShadowTime = 0f;
		}
	}

	public void LateUpdate()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldState.ACT_II && !introCutscene)
		{
			promptTextHolder.transform.position = Camera.main.WorldToScreenPoint(base.transform.position) + textOffset;
		}
	}

	public void CheckForStartInput()
	{
		if (performedInput)
		{
			return;
		}
		if (Vector3.Distance(playerTransform.position, base.transform.position) < distanceToInput)
		{
			if (Input.GetKeyDown("space"))
			{
				StartChessMatchButton();
			}
			else if (!promptTextHolder.gameObject.activeSelf)
			{
				promptTextHolder.gameObject.SetActive(value: true);
			}
		}
		else if (promptTextHolder.gameObject.activeSelf)
		{
			promptTextHolder.gameObject.SetActive(value: false);
		}
	}

	public void StartChessMatchButton()
	{
		StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.rematchAcceptTopics), 0f));
		OnStartChessMatch();
	}

	public void OnStartChessMatch()
	{
		performedInput = true;
		promptTextHolder.gameObject.SetActive(value: false);
		playerMovement.StopMovement();
		StartCoroutine(StartChessMatch());
	}

	public void SetRealWorld(Vector3 position, float trollBonusYOffset)
	{
		playerTransform.position = position;
		base.transform.position = new Vector3(position.x, 0f + trollBonusYOffset, position.z);
		Camera.main.transform.parent.transform.position = new Vector3(position.x, position.y, Camera.main.transform.position.z);
	}

	public IEnumerator StartChessMatch()
	{
		playerMovement.enabled = false;
		while (TrollDialogManager.isInDialog)
		{
			yield return null;
		}
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		yield return new WaitForSeconds(transitionManager.StartTransition(TransitionManager.TransitionState.Out) + 0.5f);
		SceneManager.LoadScene("Chess");
	}

	public IEnumerator TitleCard(string title)
	{
		inTitelCard = true;
		titleCardText.text = title;
		titleCardScreen.SetActive(value: true);
		yield return new WaitForSeconds(2f);
		titleCardText.gameObject.SetActive(value: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		yield return new WaitForSeconds(2f);
		titleCardScreen.SetActive(value: false);
		titleCardText.gameObject.SetActive(value: false);
		inTitelCard = false;
		StartCoroutine(PlayerIntro());
	}

	public IEnumerator PlayerIntro()
	{
		cameraFollow.enabled = false;
		float storedYPos = act1PlayerPosition.position.y;
		playerTransform.position = new Vector3(playerTransform.position.x, act1PlayerPosition.position.y - 10f, playerTransform.position.z);
		playerMovement.rb.velocity = Vector2.up * playerMovement.moveSpeed;
		playerMovement.UpdateAnimation();
		playerMovement.enabled = false;
		while (playerTransform.position.y < storedYPos)
		{
			yield return null;
		}
		playerTransform.position = new Vector3(playerTransform.position.x, storedYPos, playerTransform.position.z);
		cameraFollow.enabled = true;
		playerMovement.enabled = true;
		playerMovement.StopMovement();
	}

	public IEnumerator PlayerOutro()
	{
		if (SaveSystem.currentPlayerSaveData.ending == Ending.GoodEnding)
		{
			cameraFollow.enabled = false;
			float storedYPos = playerTransform.position.y + 10f;
			playerMovement.rb.velocity = Vector2.up * playerMovement.moveSpeed;
			playerMovement.UpdateAnimation();
			playerMovement.enabled = false;
			while (playerTransform.position.y < storedYPos)
			{
				yield return null;
			}
		}
		else
		{
			playerMovement.enabled = false;
			yield return new WaitForSeconds(3f);
			StartCoroutine(playerShake.Shake(0.25f, 0.1f));
			SoundManager.LoadSoundEffect(playerTransform, soundManager.player_heart_pounce);
			yield return new WaitForSeconds(1.25f);
			StartCoroutine(playerShake.Shake(0.5f, 0.1f));
			SoundManager.LoadSoundEffect(playerTransform, soundManager.player_heart_pounce);
			yield return new WaitForSeconds(1.5f);
			StartCoroutine(playerShake.Shake(1f, 0.1f));
			SoundManager.LoadSoundEffect(playerTransform, soundManager.player_heart_pounce);
			yield return new WaitForSeconds(3f);
			SoundManager.LoadSoundEffect(playerTransform, soundManager.player_troll_transformation);
			playerSineScale.enabled = true;
			yield return new WaitForSeconds(1f);
			StartCoroutine(playerShake.Shake(3f, 0.25f));
			yield return new WaitForSeconds(3f);
			playerTransform.GetComponent<AudioSource>().Stop();
			playerSineScale.enabled = false;
			playerSineScale.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			playerTransform.gameObject.SetActive(value: false);
			trollTransform.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			trollTransform.transform.position = playerTransform.position;
			yield return new WaitForSeconds(3f);
		}
		playerTransform.position = new Vector3(playerTransform.position.x, 10f, playerTransform.position.z);
		playerMovement.StopMovement();
		StartCoroutine(Credits());
	}

	public IEnumerator IntroCutscene()
	{
		yield return new WaitForSeconds(1f);
		ObjectShake cameraShake = Camera.main.GetComponent<ObjectShake>();
		StartCoroutine(cameraShake.Shake(0.25f, 0.125f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_capture);
		yield return new WaitForSeconds(1f);
		StartCoroutine(cameraShake.Shake(0.25f, 0.25f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_capture);
		yield return new WaitForSeconds(1f);
		StartCoroutine(cameraShake.Shake(0.25f, 0.5f));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_capture);
		SoundManager.LoadSoundEffect(trollTransform, soundManager.chess_piece_slip);
		float elapsedSeconds = 0f;
		bool shake = false;
		while (elapsedSeconds < manholeCurve[manholeCurve.length - 1].time)
		{
			manHoleTransform.transform.localPosition = new Vector3(manHoleTransform.transform.localPosition.x, manholeCurve.Evaluate(elapsedSeconds), manHoleTransform.transform.localPosition.z);
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds > manholeCurve[2].time && !shake)
			{
				StartCoroutine(cameraShake.Shake(0.25f, 0.05f));
				SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_manhole_blast);
				shake = true;
			}
			yield return null;
		}
		StartCoroutine(cameraShake.Shake(0.25f, 0.05f));
		trollTransform.transform.localPosition = new Vector3(0f, 20f, 0f);
		outlineAnimator.gameObject.SetActive(value: true);
		fillAnimator.gameObject.SetActive(value: true);
		elapsedSeconds = 0f;
		shake = false;
		while (elapsedSeconds < trollCurve[trollCurve.length - 1].time)
		{
			trollTransform.transform.localPosition = new Vector3(trollTransform.transform.localPosition.x, trollCurve.Evaluate(elapsedSeconds), trollTransform.transform.localPosition.z);
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds > trollCurve[2].time && !shake)
			{
				StartCoroutine(cameraShake.Shake(0.25f, 0.05f));
				SoundManager.LoadSoundEffect(trollTransform, soundManager.chess_accusation_false);
				SoundManager.LoadSoundEffect(base.transform, soundManager.player_walk);
				shake = true;
			}
			yield return null;
		}
		yield return new WaitForSeconds(1f);
		StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.introductionTopic, 1f));
		yield return new WaitForSeconds(3f);
		while (TrollDialogManager.isInDialog)
		{
			yield return null;
		}
		SaveSystem.currentPlayerSaveData.overworldState = OverworldState.ACT_II;
		ChessTrollManager.doStartTopic = true;
		OnStartChessMatch();
	}

	public IEnumerator OutroCutscene()
	{
		trollShake.StartCoroutine(trollShake.Shake(float.PositiveInfinity, 0.025f));
		ObjectShake component = Camera.main.GetComponent<ObjectShake>();
		StartCoroutine(component.Shake(0.25f, 0.25f));
		SoundManager.LoadSoundEffect(trollTransform, soundManager.chess_piece_capture);
		Keyframe[] keys = trollDefeatXCurve.keys;
		keys[0].value = trollTransform.localPosition.x;
		keys[0].outTangent = 1f;
		keys[1].inTangent = 1f;
		trollDefeatXCurve.keys = keys;
		Keyframe[] keys2 = trollDefeatYCurve.keys;
		keys2[0].value = trollTransform.localPosition.y;
		keys2[0].outTangent = 1f;
		trollDefeatYCurve.keys = keys2;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < trollDefeatYCurve[trollDefeatYCurve.length - 1].time)
		{
			trollTransform.localPosition = new Vector3(trollDefeatXCurve.Evaluate(elapsedSeconds), trollDefeatYCurve.Evaluate(elapsedSeconds), trollTransform.localPosition.z);
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		SoundManager.LoadSoundEffect(trollTransform, soundManager.overworld_manhole_blast);
		yield return new WaitForSeconds(1f);
		if (SaveSystem.currentPlayerSaveData.ending == Ending.BadEnding)
		{
			StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.outroCheaterTopic, 1f, noAnimation: true));
		}
		else
		{
			StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.outroFairPlayerTopic, 1f, noAnimation: true));
		}
		yield return new WaitForSeconds(3f);
		while (TrollDialogManager.isInDialog)
		{
			yield return null;
		}
		yield return new WaitForSeconds(1f);
		trollShake.StopAllCoroutines();
		yield return new WaitForSeconds(1f);
		SoundManager.LoadSoundEffect(trollTransform, soundManager.chess_piece_slip);
		Transform slipTransform = trollTransform;
		float slipSeconds = 0f;
		while (slipSeconds < slipYCurve[slipYCurve.length - 1].time)
		{
			slipTransform.rotation = Quaternion.Euler(0f, 0f, slipRotationCurve.Evaluate(slipSeconds));
			slipTransform.localPosition = new Vector3(0f, slipYCurve.Evaluate(slipSeconds), 0f);
			slipSeconds += Time.deltaTime;
			yield return null;
		}
		introCutscene = false;
	}

	public IEnumerator DuckCutscene()
	{
		yield return new WaitForSeconds(2f);
		trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.duckBoundTrollTopics[0], 1f));
		while (TrollDialogManager.isInDialog)
		{
			yield return null;
		}
		yield return new WaitForSeconds(3f);
		Keyframe[] keys = cameraCurve.keys;
		keys[0].value = cameraFollow.transform.position.x;
		keys[1].value = playerTransform.position.x;
		cameraCurve.keys = keys;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < cameraCurve[cameraCurve.length - 1].time)
		{
			cameraFollow.transform.position = new Vector3(cameraCurve.Evaluate(elapsedSeconds), cameraFollow.transform.position.y, cameraFollow.transform.position.z);
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		cameraFollow.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraFollow.transform.position.z);
		bridgeCollision.gameObject.SetActive(value: true);
		cameraFollow.enabled = true;
		trollTransform.transform.SetParent(base.transform, worldPositionStays: true);
		trollOutlineRenderer.sortingLayerName = "Outline";
		trollFillRenderer.sortingLayerName = "Outline";
		trollOutlineRenderer.GetComponent<DepthSorter>().enabled = true;
		trollFillRenderer.GetComponent<DepthSorter>().enabled = true;
		outlineAnimator.enabled = false;
		fillAnimator.enabled = false;
		introCutscene = false;
	}

	public IEnumerator Credits()
	{
		inTitelCard = true;
		titleCardScreen.SetActive(value: true);
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		SpeedrunTimer.doCountTime = false;
		yield return new WaitForSeconds(2f);
		if (SaveSystem.currentPlayerSaveData.ending == Ending.BadEnding)
		{
			titleCardText.text = badEndingString.GetLocalizedString();
			SteamAchievements.UnlockAchievement("BAD_ENDING");
		}
		if (SaveSystem.currentPlayerSaveData.ending == Ending.GoodEnding)
		{
			titleCardText.text = goodEndingString.GetLocalizedString();
			SteamAchievements.UnlockAchievement("GOOD_ENDING");
		}
		if (SaveSystem.currentPlayerSaveData.ending == Ending.AscensionEnding)
		{
			titleCardText.text = ascensionEndingString.GetLocalizedString();
			SteamAchievements.UnlockAchievement("ASCENSION_ENDING");
		}
		if (SaveSystem.currentPlayerSaveData.ending == Ending.DuckEnding)
		{
			titleCardText.text = duckEndingString.GetLocalizedString();
			SteamAchievements.UnlockAchievement("DUCK_ENDING");
		}
		titleCardText.gameObject.SetActive(value: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		if (SaveSystem.currentPlayerSaveData.ending == Ending.DuckEnding)
		{
			yield return new WaitForSeconds(1f);
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_honk);
		}
		yield return new WaitForSeconds(lookTime);
		mouseClicked = false;
		yield return new WaitUntil(() => mouseClicked);
		mouseClicked = false;
		if (SaveSystem.currentPlayerSaveData.ending == Ending.AscensionEnding || SaveSystem.currentPlayerSaveData.ending == Ending.DuckEnding)
		{
			titleCardText.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(1f);
			titleCardText.text = remainOnBridgeString.GetLocalizedString();
			titleCardText.gameObject.SetActive(value: true);
			SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
			yield return new WaitForSeconds(lookTime);
			mouseClicked = false;
			yield return new WaitUntil(() => mouseClicked);
			mouseClicked = false;
		}
		titleCardText.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		if (SaveSystem.currentPlayerSaveData.totalAttemptCount != 1)
		{
			SetLocalizedStringValue(attemptCountMultipleString, "attemptCount", SaveSystem.currentPlayerSaveData.totalAttemptCount.ToString());
			titleCardText.text = attemptCountMultipleString.GetLocalizedString();
		}
		else
		{
			titleCardText.text = attemptCountSingularString.GetLocalizedString();
		}
		titleCardText.gameObject.SetActive(value: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		yield return new WaitForSeconds(lookTime);
		mouseClicked = false;
		yield return new WaitUntil(() => mouseClicked);
		mouseClicked = false;
		titleCardText.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		float totalGameTime = SaveSystem.currentPlayerSaveData.totalGameTime;
		int value = Mathf.FloorToInt(totalGameTime * 1000f);
		SteamUserStats.SetStat("SpeedrunTime", value);
		SteamUserStats.StoreStats();
		SteamLeaderboards.AutoUpdateScoreToLeaderboard();
		float num = Mathf.Floor(totalGameTime / 3600f);
		float num2 = Mathf.Floor(totalGameTime / 60f) - num * 60f;
		float num3 = Mathf.Floor(totalGameTime % 60f);
		string text = "";
		if (num > 0f)
		{
			text = ((num != 1f) ? (text + num + " " + timeCountHoursString.GetLocalizedString() + " ") : (text + "1 " + timeCountHourString.GetLocalizedString() + " "));
		}
		text = ((num2 != 1f) ? (text + num2 + " " + timeCountMinutesString.GetLocalizedString() + " ") : (text + "1 " + timeCountMinuteString.GetLocalizedString() + " "));
		text = ((num3 != 1f) ? (text + num3 + " " + timeCountSecondsString.GetLocalizedString()) : (text + "1 " + timeCountSecondString.GetLocalizedString()));
		titleCardText.text = timeCountTextString.GetLocalizedString() + " " + text;
		if (totalGameTime < 900f)
		{
			SteamAchievements.UnlockAchievement("COMPLETE_UNDER_15_MIN");
		}
		if (totalGameTime < 600f)
		{
			SteamAchievements.UnlockAchievement("COMPLETE_UNDER_10_MIN");
		}
		titleCardText.gameObject.SetActive(value: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		yield return new WaitForSeconds(lookTime);
		mouseClicked = false;
		yield return new WaitUntil(() => mouseClicked);
		mouseClicked = false;
		if (SaveSystem.currentPlayerSaveData.totalScrapCount > 0)
		{
			titleCardText.gameObject.SetActive(value: false);
			yield return new WaitForSeconds(1f);
			if (SaveSystem.currentPlayerSaveData.totalScrapCount == 1)
			{
				titleCardText.text = scrapCountSingularString.GetLocalizedString();
			}
			else
			{
				SetLocalizedStringValue(scrapCountMultipleString, "scrapCount", SaveSystem.currentPlayerSaveData.totalScrapCount.ToString());
				titleCardText.text = scrapCountMultipleString.GetLocalizedString();
			}
			titleCardText.gameObject.SetActive(value: true);
			SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
			yield return new WaitForSeconds(lookTime);
			mouseClicked = false;
			yield return new WaitUntil(() => mouseClicked);
			mouseClicked = false;
		}
		titleCardText.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(1f);
		if (SaveSystem.currentPlayerSaveData.totalCheatCount == 0)
		{
			titleCardText.text = cheatCountZeroString.GetLocalizedString();
		}
		if (SaveSystem.currentPlayerSaveData.totalCheatCount == 1)
		{
			titleCardText.text = cheatCountSingularString.GetLocalizedString();
		}
		if (SaveSystem.currentPlayerSaveData.totalCheatCount > 1)
		{
			SetLocalizedStringValue(cheatCountMultipleString, "cheatCount", SaveSystem.currentPlayerSaveData.totalCheatCount.ToString());
			titleCardText.text = cheatCountMultipleString.GetLocalizedString();
		}
		titleCardText.gameObject.SetActive(value: true);
		SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
		yield return new WaitForSeconds(lookTime);
		mouseClicked = false;
		yield return new WaitUntil(() => mouseClicked);
		mouseClicked = false;
		titleCardText.gameObject.SetActive(value: false);
		SaveSystem.currentPlayerSaveData.overworldState = OverworldState.ACT_II;
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Credits");
	}

	public static void SetLocalizedStringValue(LocalizedString localizedString, string valueKey, string value)
	{
		StringVariable stringVariable;
		if (!localizedString.TryGetValue(valueKey, out var value2))
		{
			stringVariable = new StringVariable();
			localizedString.Add(valueKey, stringVariable);
		}
		else
		{
			stringVariable = value2 as StringVariable;
		}
		stringVariable.Value = value;
	}

	private IEnumerator DisplayAct(float delay)
	{
		yield return new WaitForSeconds(delay);
		string text = "";
		switch (SaveSystem.currentPlayerSaveData.overworldState)
		{
		case OverworldState.ACT_I:
			text = "I";
			break;
		case OverworldState.ACT_II:
			text = "II";
			break;
		case OverworldState.ACT_III:
			text = "III";
			break;
		}
		string localizedString = actLocalizedString.GetLocalizedString();
		actDisplayText.text = localizedString + " " + text;
		actDisplayAnimator.enabled = true;
	}
}
