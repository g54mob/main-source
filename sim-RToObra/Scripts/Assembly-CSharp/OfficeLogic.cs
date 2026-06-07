using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeLogic : MonoBehaviour, WatchHost
{
	private enum State
	{
		Intro = 0,
		ReceivingPackage = 1,
		Package = 2,
		OpeningPackage = 3,
		ReadingLetter = 4,
		PawClosed = 5,
		OpeningPaw = 6,
		PawOpen = 7,
		GettingWatch = 8,
		PawReady = 9,
		EnterMomentSlow = 10,
		EnterMomentFast = 11,
		EnterMomentCancel = 12,
		EnterMomentCommit = 13,
		WaitingForVictory = 14,
		Victory = 15,
		Failure = 16,
		WaitForCredits = 17
	}

	private enum PawState
	{
		Closed = 0,
		Open = 1,
		Ready = 2
	}

	private class Focus
	{
		public float charge;

		public float startTime;

		public DeskBox deskBox;

		public void Clear()
		{
			charge = 0f;
			deskBox = null;
		}
	}

	public OneBit oneBit;

	public Camera playerCamera;

	public GameObject sceneGo;

	public GameObject victoryGo;

	public GameObject letterRootGo;

	public AudioClip victoryMusicClip;

	public AudioClip failureMusicClip;

	public AudioClip openLetterAudioClip;

	public AudioClip closeLetterAudioClip;

	public AudioSource introAudioSource;

	public SoundEnviron soundEnviron;

	public Curtain curtain;

	public RectTransform paperTransform;

	public Text letterText;

	public QuestLookAt bookshelfLookAt;

	public Dialog.AssetInfos dialogInfos;

	[Readonly]
	public List<DeskSet> deskSets;

	[Readonly]
	public List<DeskBox> deskBoxes;

	[Readonly]
	public Animator victoryAnimator;

	[Readonly]
	public Transform victoryEyeTransform;

	[Readonly]
	public CorpseBox corpseBox;

	private Stater<State> stater;

	private Focus focus = new Focus();

	private Player player;

	private PawState pawState;

	private string enterMomentId;

	private bool completedShipZoneCorrectly;

	private bool startWithPlayerLookReset;

	private AudioOneShot musicAudioOneShot;

	private float introTimer;

	private DeskBoxFinder deskBoxFinder;

	private EnderClick enderClick;

	private bool inBook;

	private string shelfObjectsDeskSetName;

	private const float kIntroDuration = 34.1f;

	private bool dialogIsPlaying
	{
		get
		{
			return Game.instance.dialog.isPlaying;
		}
	}

	private bool saveData_haveRevealedBook
	{
		get
		{
			return SaveData.it.generalRo.officeHaveRevealedBook;
		}
		set
		{
			SaveData.it.general.officeHaveRevealedBook = value;
		}
	}

	private bool saveData_pawReady
	{
		get
		{
			return SaveData.it.generalRo.officePawReady;
		}
		set
		{
			SaveData.it.general.officePawReady = value;
		}
	}

	private bool saveData_packageReady
	{
		get
		{
			return SaveData.it.generalRo.officePackageReady;
		}
		set
		{
			SaveData.it.general.officePackageReady = value;
		}
	}

	private bool saveData_endedOnce
	{
		get
		{
			return SaveData.it.generalRo.officeEndedOnce;
		}
		set
		{
			SaveData.it.general.officeEndedOnce = value;
		}
	}

	public bool inHunt
	{
		get
		{
			return false;
		}
	}

	public bool canHunt
	{
		get
		{
			return false;
		}
	}

	public string enteringMomentId
	{
		get
		{
			return enterMomentId;
		}
	}

	private void Start()
	{
		player = Player.instance;
		deskBoxFinder = new DeskBoxFinder(playerCamera, deskBoxes);
		enderClick = GetComponent<EnderClick>();
		SaveData.it.general.era = 3;
		completedShipZoneCorrectly = SaveData.it.GetZoneIsSolved(Story.Zone.Ship);
		if (completedShipZoneCorrectly)
		{
			letterText.text = Lang.GetGendered("office_letter_win", SaveData.it.generalRo.playerGender);
			shelfObjectsDeskSetName = "shelf_objects_good";
		}
		else if (SaveData.it.GetNumFatesCorrect() >= 30)
		{
			letterText.text = Lang.GetGendered("office_letter_mid", SaveData.it.generalRo.playerGender);
			shelfObjectsDeskSetName = "shelf_objects_mid";
		}
		else
		{
			letterText.text = Lang.GetGendered("office_letter_fail", SaveData.it.generalRo.playerGender);
			shelfObjectsDeskSetName = "shelf_objects_bad";
		}
		stater = new Stater<State>("Office");
		letterRootGo.gameObject.SetActive(false);
		stater.AddState(State.Intro).AddFunc(StaterFunc.ENTER(delegate
		{
			Monitor.BlackOut(1);
			ActivateDeskSets("teacup_center");
			if (DebugMenu.WantSkip())
			{
				stater.Go(State.ReceivingPackage);
			}
		})).AddFunc(StaterFunc.AT_STEP(0.0001f, delegate
		{
			ShowDialog("office-intro");
		}))
			.AddFunc(StaterFunc.AT_STEP(10f, delegate
			{
				introAudioSource.Play();
			}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				if (!dialogIsPlaying)
				{
					introTimer += Clock.play.deltaTime;
				}
				if (introTimer > 34.1f)
				{
					stater.Go(State.ReceivingPackage);
				}
				Game.BlockPauseMenuForOneFrame();
			}));
		stater.AddState(State.ReceivingPackage).AddFunc(StaterFunc.ENTER(delegate
		{
			ShowDialog((!completedShipZoneCorrectly) ? "office-delivery-envelope" : "office-delivery-package");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialogIsPlaying)
			{
				stater.Go(State.Package);
			}
		}));
		stater.AddState(State.Package).AddFunc(StaterFunc.ENTER(delegate
		{
			saveData_packageReady = true;
			Game.SaveActive();
			if (startWithPlayerLookReset)
			{
				ResetPlayerLook();
			}
			ActivateDeskSets("teacup_side", (!completedShipZoneCorrectly) ? "envelope_closed" : "package_closed");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			UpdateFocus();
			if (CheckDeskBoxActionId("open-package"))
			{
				stater.Go(State.OpeningPackage);
			}
		}));
		stater.AddState(State.OpeningPackage).AddFunc(StaterFunc.ENTER(delegate
		{
			ShowDialog((!completedShipZoneCorrectly) ? "office-open-envelope" : "office-open-package");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialogIsPlaying)
			{
				stater.Go(State.ReadingLetter);
			}
		}));
		stater.AddState(State.ReadingLetter).AddFunc(StaterFunc.ENTER(delegate
		{
			focus.Clear();
			Monitor.BlackOut(2);
			letterRootGo.gameObject.SetActive(true);
			RInput.mode = RInput.Mode.Ui;
			AudioOneShot.Play(openLetterAudioClip, false, 0.5f);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			OneBit.ShowOverlayForFrames(3);
			player.DisableInputForOneFrame();
			bool flag = RInput.GetButtonDown(44) || RInput.GetButtonDown(17) || RInput.GetButtonDown(10);
			if (completedShipZoneCorrectly)
			{
				if (stater.stateTime > 1f && flag)
				{
					if (pawState == PawState.Closed)
					{
						stater.Go(State.PawClosed);
					}
					else if (pawState == PawState.Open)
					{
						stater.Go(State.PawOpen);
					}
					else
					{
						stater.Go(State.PawReady);
					}
				}
			}
			else if (stater.stateTime > 1f && flag)
			{
				stater.Go(State.Failure);
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				if (completedShipZoneCorrectly)
				{
					AudioOneShot.Play(closeLetterAudioClip, false, 0.5f);
					RInput.mode = RInput.Mode.Play;
					letterRootGo.gameObject.SetActive(false);
					ResetPlayerLook();
				}
			}));
		stater.AddState(State.PawClosed).AddFunc(StaterFunc.ENTER(delegate
		{
			ActivateDeskSets("teacup_side", "package_opened", "fabric_rolled");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			UpdateFocus();
			if (CheckDeskBoxActionId("open-book"))
			{
				OpenBook();
			}
			if (CheckDeskBoxActionId("read-letter"))
			{
				stater.Go(State.ReadingLetter);
			}
			if (CheckDeskBoxActionId("unroll-paw"))
			{
				stater.Go(State.OpeningPaw);
			}
		}));
		stater.AddState(State.OpeningPaw).AddFunc(StaterFunc.ENTER(delegate
		{
			ShowDialog("office-open-paw");
			pawState = PawState.Open;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialogIsPlaying)
			{
				stater.Go(State.PawOpen);
			}
		}));
		stater.AddState(State.PawOpen).AddFunc(StaterFunc.ENTER(delegate
		{
			ActivateDeskSets("teacup_side", "package_opened", "fabric_unrolled", "monkeypaw_nowatch");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			UpdateFocus();
			if (CheckDeskBoxActionId("get-watch"))
			{
				stater.Go(State.GettingWatch);
			}
			if (CheckDeskBoxActionId("open-book"))
			{
				OpenBook();
			}
			if (CheckDeskBoxActionId("read-letter"))
			{
				stater.Go(State.ReadingLetter);
			}
		}));
		stater.AddState(State.GettingWatch).AddFunc(StaterFunc.ENTER(delegate
		{
			ShowDialog("office-get-watch");
			pawState = PawState.Ready;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialogIsPlaying)
			{
				stater.Go(State.PawReady);
			}
		}));
		stater.AddState(State.PawReady).AddFunc(StaterFunc.ENTER(delegate
		{
			saveData_pawReady = true;
			pawState = PawState.Ready;
			Game.SaveActive();
			curtain.StopChargingAudio();
			if (startWithPlayerLookReset)
			{
				ResetPlayerLook();
			}
			ActivateDeskSets("teacup_side", "package_opened", "fabric_unrolled", "monkeypaw_watch");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (CheckVictory())
			{
				stater.Go(State.WaitingForVictory);
			}
			else
			{
				UpdateFocus();
				if (CheckDeskBoxActionId("open-book"))
				{
					OpenBook();
				}
				if (CheckDeskBoxActionId("read-letter"))
				{
					stater.Go(State.ReadingLetter);
				}
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				if (saveData_endedOnce)
				{
					enderClick.Clear();
				}
			}));
		stater.AddState(State.EnterMomentSlow).SetDurations(2.4f, 0f, State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
		{
			curtain.PlayChargingAudio(curtain.chargingAudioClip, 2.4f);
		}))
			.AddFunc(StaterFunc.AT_INTERP(1f, delegate
			{
				AudioOneShot.Play(curtain.acceptAudioClip, false, 0.5f);
			}))
			.AddTarget(curtain.forwardCurtainStaterProp, 1f);
		stater.AddState(State.EnterMomentFast).SetDurations(0f, 0f, State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
		{
			Monitor.BlackOut(1);
			curtain.exploringSoundEnviron.FadeOut(0.5f);
		}));
		stater.AddState(State.EnterMomentCancel).SetDurations(0.1f, 0f, State.PawReady).AddFunc(StaterFunc.ENTER(delegate
		{
			curtain.StopChargingAudio();
			AudioOneShot.Play(curtain.cancelAudioClip);
		}))
			.AddTarget(curtain.forwardCurtainStaterProp, 0f);
		stater.AddState(State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
		{
			saveData_haveRevealedBook = true;
			Monitor.BlackOut(1);
			AudioOneShot.Play(curtain.acceptAudioClip, false, 0.5f);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Monitor.BlackOut(1);
			if (stater.stateTime > 0.1f && curtain.exploringSoundEnviron.fadedOut)
			{
				Game.LoadMomentScene(enterMomentId);
			}
		}));
		stater.AddState(State.WaitingForVictory).SetDurations(0f, 2f, State.Victory).AddFunc(StaterFunc.ENTER(delegate
		{
			Monitor.BlackOut(1);
			Awards.Give(Awards.Id.GoodEnding);
		}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				player.DisableInputForOneFrame();
				Monitor.BlackOut(1);
			}));
		stater.AddState(State.Victory).AddFunc(StaterFunc.ENTER(delegate
		{
			musicAudioOneShot = AudioOneShot.Play(victoryMusicClip);
			victoryGo.gameObject.SetActive(true);
			victoryAnimator.Play("Victory");
			victoryAnimator.Update(0f);
			victoryAnimator.Update(0f);
			corpseBox.gameObject.SetActive(false);
			soundEnviron.FadeOut(1f);
			Monitor.BlackOut(1);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			player.transform.position = victoryEyeTransform.position + new Vector3(0f, -0.7f, 0f);
			player.look = victoryEyeTransform.rotation;
			player.DisableInputForOneFrame();
			if (saveData_endedOnce && stater.stateTime < 3f)
			{
				Monitor.BlackOut(1);
			}
			if (stater.stateTime >= 16f)
			{
				Monitor.BlackOut(1);
			}
			if (musicAudioOneShot.done)
			{
				saveData_endedOnce = true;
				stater.Go(State.WaitForCredits);
			}
		}));
		int[] failureIrisBeats = new int[28]
		{
			1, 1, 1, 1, 2, 2, 3, 3, 4, 4,
			4, 4, 5, 5, 6, 6, 7, 7, 7, 7,
			8, 9, 9, 9, 10, 10, 10, 10
		};
		stater.AddState(State.Failure).AddFunc(StaterFunc.ENTER(delegate
		{
			musicAudioOneShot = AudioOneShot.Play(failureMusicClip);
			soundEnviron.FadeOut(1f);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			OneBit.ShowOverlayForFrames(3);
			player.DisableInputForOneFrame();
			float time = musicAudioOneShot.time;
			float f = time * 1.3333334f * 4f;
			int num = Mathf.Min(failureIrisBeats.Length - 1, Mathf.FloorToInt(f));
			float t = (float)failureIrisBeats[num] / 10f;
			Vector2 anchoredPosition = paperTransform.anchoredPosition;
			anchoredPosition.y = Mathf.Lerp(0f, -Resolution.bufferH, t);
			paperTransform.anchoredPosition = anchoredPosition;
			if (musicAudioOneShot.done)
			{
				stater.Go(State.WaitForCredits);
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				letterRootGo.gameObject.SetActive(false);
				Awards.Give(Awards.Id.BadEnding);
			}));
		stater.AddState(State.WaitForCredits).AddFunc(StaterFunc.ENTER(delegate
		{
			Game.SaveActive();
			ShowDialog("the-end");
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!dialogIsPlaying)
			{
				Game.LoadCredits();
			}
		}));
		victoryAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		victoryGo.gameObject.SetActive(false);
		if (saveData_pawReady)
		{
			startWithPlayerLookReset = true;
			stater.Go(State.PawReady);
			if (CheckVictory(true))
			{
				stater.Go(State.WaitingForVictory);
			}
		}
		else if (saveData_packageReady)
		{
			startWithPlayerLookReset = true;
			stater.Go(State.Package);
		}
		else
		{
			stater.Go(State.Intro);
		}
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
		if (saveData_haveRevealedBook && stater.curStateId < State.WaitingForVictory)
		{
			Game.AllowBookForOneFrame();
		}
	}

	private bool CheckDeskBoxActionId(string actionId)
	{
		if (focus.deskBox == null || !focus.deskBox.actionId.HasValue() || focus.charge < 0.1f)
		{
			return false;
		}
		if (OneBit.GetOverlayIsVisible())
		{
			return false;
		}
		if (RInput.GetButtonDown(4))
		{
			return focus.deskBox.actionId == actionId;
		}
		return false;
	}

	private void UpdateFocus()
	{
		deskBoxFinder.Search();
		if (focus.deskBox != null)
		{
			if (focus.deskBox == deskBoxFinder.found)
			{
				focus.charge = Mathf.Min(1f, focus.charge + Clock.play.deltaTime);
			}
			else
			{
				focus.charge -= 4f * Clock.play.deltaTime;
				if (focus.charge <= 0f)
				{
					focus.Clear();
				}
			}
		}
		else
		{
			focus.deskBox = deskBoxFinder.found;
			focus.charge = 0f;
			focus.startTime = Clock.play.time;
		}
		foreach (DeskBox deskBox in deskBoxes)
		{
			deskBox.focusGo.SetActive(deskBox == focus.deskBox);
		}
		if (focus.deskBox != null)
		{
			float num = Clock.play.time - focus.startTime;
			float x = focus.charge * Util.LerpScale(Mathf.Sin(num * 5f), -1f, 1f, 0.1f, 10f);
			oneBit.linedSettings.examine = true;
			oneBit.linedSettings.examineReveal = new Vector3(x, 0f, 0f);
			oneBit.linedSettings.examineDitherOffset = Vector2.zero;
		}
	}

	private void ActivateDeskSets(params string[] names)
	{
		foreach (DeskSet deskSet in deskSets)
		{
			bool flag = false;
			flag |= deskSet.name == shelfObjectsDeskSetName;
			flag |= Array.IndexOf(names, deskSet.name) >= 0;
			deskSet.gameObject.SetActive(flag);
		}
		oneBit.linedSettings.examine = false;
		focus.Clear();
	}

	private void OpenBook()
	{
		if (saveData_haveRevealedBook)
		{
			Game.instance.ShowBook();
			return;
		}
		Game.instance.RevealBook(true);
		saveData_haveRevealedBook = true;
	}

	private bool CheckVictory(bool atBoot = false)
	{
		if (saveData_endedOnce)
		{
			if (bookshelfLookAt.seenByPlayer)
			{
				enderClick.Charge();
				return enderClick.done;
			}
			enderClick.Uncharge();
			return false;
		}
		bool flag = inBook;
		inBook = Book.active != null && Book.active.isActiveAndEnabled;
		if (atBoot || (flag && !inBook))
		{
			return SaveData.it.GetNumFatesCorrect() == Manifest.it.crewCount;
		}
		return false;
	}

	private void ShowDialog(string id)
	{
		dialogInfos.Show(id, new Dialog.Extra().SetWantBlackFramesAfter(true));
		if (!id.Contains("intro"))
		{
			ResetPlayerLook();
		}
	}

	private void ResetPlayerLook()
	{
		Player.instance.look = Quaternion.Euler(40f, 0f, 0f);
	}

	public void StartEnterMoment(string enterMomentId_, bool fast)
	{
		enterMomentId = enterMomentId_;
		curtain.watchHand.dial.hourT = (float)(Story.it.GetMoment(enterMomentId).disaster.index + 1) / 12f;
		stater.Go((!fast) ? State.EnterMomentSlow : State.EnterMomentFast);
	}

	public void CancelEnterMoment()
	{
		stater.Go(State.EnterMomentCancel);
	}

	public void StartHunt()
	{
	}

	public void StartInception(CorpseBox corpseBox)
	{
	}

	public void StartPullCorpse(CorpseBox corpseBox)
	{
	}
}
