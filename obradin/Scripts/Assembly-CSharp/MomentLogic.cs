using System;
using System.Collections.Generic;
using UnityEngine;

public class MomentLogic : MonoBehaviour, WatchHost
{
	private enum State
	{
		BootExploring = 0,
		Exploring = 1,
		EnterMomentStartSlow = 2,
		EnterMomentStartFast = 3,
		EnterMomentCommit = 4,
		EnterMomentCancel = 5,
		InMomentBoot = 6,
		ChapterTitles = 7,
		Dialog = 8,
		StartMusic = 9,
		Music = 10,
		Wander = 11,
		PrepRevealingBookPages = 12,
		ExitMomentDoor = 13,
		ExitMomentIncept = 14,
		ReturnToExploring = 15,
		RevealingBookPages = 16,
		InBookAfterReveal = 17,
		OpeningExitPortal = 18,
		InHunt = 19,
		PullCorpse = 20,
		PullCorpseLoadInceptive = 21,
		MomentPhoto = 22,
		MomentPhotoAuto = 23,
		MomentPhotoAutoDone = 24
	}

	[HideInInspector]
	public string id = string.Empty;

	public string dialogId;

	public AudioClip dialogAudioClip;

	public AudioClip musicAudioClip;

	public AudioClip wanderNormalAudioClip;

	public AudioClip wanderCorpseAudioClip;

	public float musicOutroll;

	public Dialog dialog;

	public Clearing clearing;

	public ExitPortal exitPortal;

	public Curtain curtain;

	public OneBit oneBit;

	[Readonly]
	public CorpseBox pullableCorpseBox;

	[Readonly]
	public List<CorpseBox> allCorpseBoxes;

	[Readonly]
	public HelpIris helpIris;

	[Readonly]
	public Texture2D mermaidCensoredTexture;

	public string builtFromBaseHash;

	private bool ended;

	private bool skippedDialog;

	private float momentStartTime;

	private float momentEndTime;

	private bool startedMusic;

	private AudioOneShot musicAudioOneShot;

	private AudioOneShot wanderAudioOneShot;

	private float timeOffset;

	private bool haveTakenDebugScreenshot;

	private Strider strider;

	private CorpseBox pullCorpseBox;

	private string enterMomentId;

	private const float kDefaultMusicVolume = 0.75f;

	private StaterPropFloat musicVolumeProp = new StaterPropFloat(0.75f);

	private Stater<State> stater;

	private bool haveAddedVisitCountToSaveData;

	private bool haveSeenMomentDialog;

	private bool haveVisitedMoment;

	private bool wantSkipDialog;

	private float exploringStuckResetCounter;

	private Player.Spot momentPlayerSpot;

	private const float kExitMomentDuration = 7f;

	private const float kHuntPeriod = 3f;

	private const float kHuntBeatAudioVolume = 0.6f;

	private const float kHuntNetherRingDuration = 1f;

	private const float kDialogVolume = 0.5f;

	private static int soloWatchLayerMask;

	public bool isFinal
	{
		get
		{
			return id.EndsWith("final");
		}
	}

	public bool inHunt
	{
		get
		{
			return IsInState(State.InHunt);
		}
	}

	public bool wantHunt
	{
		get
		{
			return pullableCorpseBox != null;
		}
	}

	public bool canHunt
	{
		get
		{
			return wantHunt && (IsInState(State.Wander) || (haveVisitedMoment && IsInState(State.Music)));
		}
	}

	public string enteringMomentId
	{
		get
		{
			return enterMomentId;
		}
	}

	public bool isMomentPhotoAutoDone
	{
		get
		{
			return stater.curStateId == State.MomentPhotoAutoDone;
		}
	}

	private AudioClip wanderAudioClip
	{
		get
		{
			return (!wantHunt) ? wanderNormalAudioClip : wanderCorpseAudioClip;
		}
	}

	private bool canSkipDialog
	{
		get
		{
			return haveVisitedMoment || haveSeenMomentDialog;
		}
	}

	private bool wantWanderSoloWatch
	{
		get
		{
			return wantHunt && !haveVisitedMoment;
		}
	}

	private bool IsInState(State state)
	{
		return stater.curStateId == state;
	}

	private void Awake()
	{
	}

	private void Start()
	{
		strider = Player.instance.GetComponent<Strider>();
		stater = new Stater<State>("MomentLogic");
		Stater<State>.enableDebugLog = true;
		if (isFinal)
		{
			stater.AddState(State.BootExploring).SetDurations(0f, 0f, State.Exploring).AddFunc(StaterFunc.ENTER(delegate
			{
				Monitor.BlackOut(7);
				curtain.exploringSoundEnviron.FadeIn(1f);
			}));
			stater.AddState(State.Exploring).SetDurations(1f).AddFunc(StaterFunc.ENTER(delegate
			{
				curtain.exploringSoundEnviron.FadeIn(1f);
				exploringStuckResetCounter = 0f;
			}))
				.AddFunc(StaterFunc.AT_INTERP(0.01f, delegate
				{
					string wantRevealCompleteDisasterId = SaveData.it.GetWantRevealCompleteDisasterId();
					if (wantRevealCompleteDisasterId.HasValue())
					{
						Game.instance.RevealCompleteChapter(wantRevealCompleteDisasterId);
					}
				}))
				.AddFunc(StaterFunc.STEP(delegate
				{
					if (helpIris != null && curtain.watchHand.exploringForce == WatchHand.ExploringForce.None)
					{
						helpIris.AllowChargingForOneFrame();
					}
					if (Player.instance.transform.position.ToVector2XZ().sqrMagnitude > 900f)
					{
						Player.instance.WarpToPlayerStart();
					}
					if (Clock.play.running && Player.instance.inputEnabled && RInput.GetButton(4) && RInput.GetButton(53))
					{
						exploringStuckResetCounter += Clock.play.deltaTime;
						if (exploringStuckResetCounter > 15f)
						{
							exploringStuckResetCounter = 0f;
							Player.instance.WarpToPlayerStart();
						}
					}
					else
					{
						exploringStuckResetCounter = 0f;
					}
				}));
			stater.AddState(State.EnterMomentStartSlow).SetDurations(2.4f, 0f, State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
			{
				curtain.PlayChargingAudio(curtain.chargingAudioClip, 2.4f);
			}))
				.AddTarget(curtain.forwardCurtainStaterProp, 1f);
			stater.AddState(State.EnterMomentStartFast).SetDurations(0f, 0f, State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
			{
				Monitor.BlackOut(1);
				curtain.exploringSoundEnviron.FadeOut(0.5f);
			}));
			stater.AddState(State.EnterMomentCommit).AddFunc(StaterFunc.ENTER(delegate
			{
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
			stater.AddState(State.EnterMomentCancel).SetDurations(0.1f, 0f, State.Exploring).AddFunc(StaterFunc.ENTER(delegate
			{
				curtain.StopChargingAudio();
				AudioOneShot.Play(curtain.cancelAudioClip);
			}))
				.AddTarget(curtain.forwardCurtainStaterProp, 0f);
			return;
		}
		haveVisitedMoment = SaveData.it.momentRo[id].visited;
		haveSeenMomentDialog = SaveData.it.GetStat("#dia-" + id) > 0;
		strider.volume = 0f;
		if (pullableCorpseBox != null && (pullableCorpseBox.alreadyUnlocked || pullableCorpseBox.alreadyVisited))
		{
			pullableCorpseBox = null;
		}
		stater.AddState(State.InMomentBoot).SetDurations(0f, 0f, State.ChapterTitles);
		stater.AddState(State.ChapterTitles).AddFunc(StaterFunc.ENTER(delegate
		{
			SaveData.it.general.lastVisitedMomentId = id;
			if (wantHunt)
			{
				exitPortal.mode = ExitPortal.Mode.ClosedInvisible;
			}
			else if (haveVisitedMoment)
			{
				exitPortal.mode = ExitPortal.Mode.Open;
			}
			else
			{
				exitPortal.mode = ExitPortal.Mode.Closed;
			}
			if (SaveData.it.generalRo.momentPlayerSpotId == id)
			{
				if (SaveData.it.momentRo[id].revealedPageInBook)
				{
					stater.Go(State.Wander);
				}
				else
				{
					dialog.Play(dialogId, new Dialog.Extra(dialogAudioClip).SetAudioClipVolume(0.5f));
					stater.Go(State.StartMusic);
				}
			}
			else if (!haveVisitedMoment)
			{
				stater.Go(State.Dialog);
			}
			else
			{
				SaveData.it.general.bookPageId = id;
				Story.Moment moment = Story.it.GetMoment(id);
				dialog.customString = Lang.Get("dialog_chapter", "$chapter_num", Lang.Get(string.Format("book_numeral_{0}", moment.disaster.index + 1)), "$chapter_name", Lang.Get(string.Format("book_chapter_{0}_name", moment.disaster.index)), "$part_num", moment.indexInDisaster + 1, "$part_max", moment.disaster.moments.Count);
				dialog.Play("chapter-title", new Dialog.Extra().SetWantBlackFramesAfter(true));
			}
		})).AddFunc(StaterFunc.STEP(delegate
		{
			dialog.showSkip = false;
			Player.instance.DisableInputForOneFrame();
			if (!dialog.isPlayingFullscreen)
			{
				stater.Go(State.Dialog);
			}
			else if (CheckSkipDialog())
			{
				stater.Go(State.Dialog);
			}
			else if (!DebugCheckSkip())
			{
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				Monitor.BlackOut(1);
			}));
		stater.AddState(State.Dialog).AddFunc(StaterFunc.ENTER(delegate
		{
			dialog.Play(dialogId, new Dialog.Extra(dialogAudioClip).SetAudioClipVolume(0.5f));
			dialog.showSkip = canSkipDialog;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Player.instance.DisableInputForOneFrame();
			if (!dialog.isPlayingFullscreen)
			{
				stater.Go(State.StartMusic);
			}
			else if (CheckSkipDialog())
			{
				stater.Go(State.StartMusic);
			}
			else if (!DebugCheckSkip())
			{
			}
		}));
		stater.AddState(State.StartMusic).AddFunc(StaterFunc.ENTER(delegate
		{
			if (dialog.isPlaying)
			{
				dialog.SwitchToAudioOnly();
			}
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Player.instance.DisableInputForOneFrame();
			if (!Monitor.blackingOut)
			{
				stater.Go(State.Music);
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				musicAudioOneShot = AudioOneShot.Play(musicAudioClip);
				musicAudioOneShot.gameObject.AddComponent<AudioPauseEcho>();
			}));
		stater.AddState(State.Music).AddFunc(StaterFunc.ENTER(delegate
		{
			Game.SaveActive();
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (helpIris != null)
			{
				helpIris.AllowChargingForOneFrame();
			}
			if (wantSkipDialog && !dialog.isPlaying)
			{
				UpdateWanderStriderVolume();
			}
			if (musicAudioOneShot == null || musicAudioOneShot.time > musicAudioClip.length - musicOutroll - 7f)
			{
				if (haveVisitedMoment)
				{
					stater.Go(State.Wander);
				}
				else
				{
					stater.Go(State.PrepRevealingBookPages);
				}
			}
			else if (exitPortal.outsideT > 0f)
			{
				stater.Go(State.ExitMomentDoor);
			}
			else if (!haveVisitedMoment && musicAudioOneShot != null && Impatient.WantSkip("moment"))
			{
				musicAudioOneShot.Stop(7f);
				stater.Go(State.PrepRevealingBookPages);
			}
			else
			{
				StoreMomentPlayerSpot();
				DebugCheckSkip();
			}
		}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				if (helpIris != null)
				{
					helpIris.ZeroAll();
				}
			}));
		stater.AddState(State.Wander).AddFunc(StaterFunc.STEP(delegate
		{
			if (wanderAudioOneShot == null && (musicAudioOneShot == null || musicAudioOneShot.done))
			{
				wanderAudioOneShot = AudioOneShot.Play(wanderAudioClip, true);
				wanderAudioOneShot.gameObject.AddComponent<AudioPauseEcho>();
			}
			if (wanderAudioOneShot != null)
			{
				float f = wanderAudioOneShot.timeSinePlay * 2f * (float)Math.PI / 12f;
				float input = ((!haveVisitedMoment) ? Mathf.Cos(f) : Mathf.Sin(f));
				float num = Util.SmoothStepEdges(0f, 0.5f, wanderAudioOneShot.time) - Util.SmoothStepEdges(wanderAudioClip.length - 2f, wanderAudioClip.length, wanderAudioOneShot.time);
				wanderAudioOneShot.volume = num * Util.LerpScale(input, -1f, 1f, 0.2f, 0.4f);
			}
			if (wantWanderSoloWatch && stater.stateTime < 2f)
			{
				SetSoloWatch(true);
				Player.instance.DisableMovementForOneFrame();
			}
			else
			{
				SetSoloWatch(false);
				if (helpIris != null)
				{
					helpIris.AllowChargingForOneFrame();
				}
			}
			UpdateWanderStriderVolume();
			if (exitPortal.outsideT > 0f)
			{
				stater.Go(State.ExitMomentDoor);
			}
			else
			{
				StoreMomentPlayerSpot();
				DebugCheckSkip();
			}
		})).AddFunc(StaterFunc.EXIT(delegate
		{
			SetSoloWatch(false);
			if (wanderAudioOneShot != null)
			{
				wanderAudioOneShot.Stop(0.5f);
			}
		}));
		stater.AddState(State.InHunt).AddFunc(StaterFunc.ENTER(delegate
		{
			if (dialog.isPlaying)
			{
				dialog.Stop(true);
			}
			if (musicAudioOneShot != null && !musicAudioOneShot.done)
			{
				musicAudioOneShot.Stop(0.1f);
			}
			if (wanderAudioOneShot != null)
			{
				wanderAudioOneShot.Stop(0.1f);
			}
			strider.volume = 0f;
			oneBit.linedSettings.nether = true;
			oneBit.linedSettings.watchHandOnly = false;
			oneBit.linedSettings.netherRingEdges = Vector4.zero;
			oneBit.linedSettings.curtainSettings.t = 0f;
			oneBit.linedSettings.netherCenter = Player.instance.footPos;
			oneBit.linedSettings.netherPulseDist = 0f;
			oneBit.linedSettings.netherRingEdges = new Vector4(0f, 0f, 0f, 40f);
			curtain.watchHand.UnHide();
			exitPortal.mode = ExitPortal.Mode.ClosedInvisible;
			foreach (CorpseBox allCorpseBox in allCorpseBoxes)
			{
				if (allCorpseBox != pullableCorpseBox)
				{
					allCorpseBox.gameObject.SetActive(false);
				}
			}
			pullableCorpseBox.focusGo.SetActive(true);
			pullableCorpseBox.SetCorpseMaterialFocus(true);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			UpdateHuntNetherRing();
			curtain.SetClockPanic();
			if (!DebugCheckSkip())
			{
			}
		}))
			.AddFunc(StaterFunc.PERIODIC(3f, delegate(int c, float t)
			{
				oneBit.linedSettings.netherPulseDist = Mathf.Lerp(5f, 9f, Util.SmoothStepEdges(0f, 0.1f, t * 3f) - Util.SmoothStepEdges(0.1f, 1f, t * 3f));
			}))
			.AddFunc(StaterFunc.AT_PERIODIC(3f, 0f, delegate(int c)
			{
				if (c == 0)
				{
					AudioOneShot.Play(curtain.huntStartAudioClip, false, 0.75f);
				}
				else
				{
					AudioOneShot.Play(curtain.cancelAudioClip);
				}
			}));
		stater.AddState(State.PullCorpse).AddFunc(StaterFunc.ENTER(delegate
		{
			AudioOneShot.Play(curtain.pullCorpseAudioClip);
			pullCorpseBox.vaporMesh.Launch();
		})).AddFunc(StaterFunc.STEP(delegate
		{
			UpdateHuntNetherRing();
			curtain.SetClockPanic(!pullCorpseBox.alreadyUnlocked);
			Player.instance.DisableMovementForOneFrame();
			VaporMesh vaporMesh = pullCorpseBox.vaporMesh;
			if (vaporMesh.enabled && vaporMesh.completelyCoveringBody && pullCorpseBox.focusGo.activeSelf)
			{
				pullCorpseBox.focusGo.SetActive(false);
				pullCorpseBox.SetCorpseMaterialFocus(false);
			}
		}))
			.AddFunc(StaterFunc.AT_STEP(3f, delegate
			{
				SaveData.it.moment[pullCorpseBox.visitMomentId].unlocked = true;
				if (pullCorpseBox.inceptive)
				{
					stater.Go(State.PullCorpseLoadInceptive);
				}
				else
				{
					stater.Go(State.ReturnToExploring);
				}
			}));
		stater.AddState(State.PullCorpseLoadInceptive).AddFunc(StaterFunc.ENTER(delegate
		{
			Monitor.BlackOut(2);
		})).AddFunc(StaterFunc.AT_STEP(0.01f, delegate
		{
			Game.LoadMomentScene(pullCorpseBox.visitMomentId);
		}));
		stater.AddState(State.ExitMomentIncept).AddFunc(StaterFunc.ENTER(delegate
		{
			dialog.Stop();
			AudioOneShot.Play(curtain.acceptAudioClip);
			oneBit.linedSettings.curtainSettings.reverse = true;
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Player.instance.DisableMovementForOneFrame();
		}))
			.AddFunc(StaterFunc.SEQ_INTERP(1f, delegate(float t)
			{
				oneBit.linedSettings.curtainSettings.t = t;
				oneBit.linedSettings.curtainSettings.worldCenter = curtain.watchHand.dialTransform.position;
				musicVolumeProp.f = 0.75f - t;
			}))
			.AddFunc(StaterFunc.SEQ(delegate
			{
				oneBit.linedSettings.curtainSettings.t = 0f;
				oneBit.linedSettings.nether = true;
				oneBit.linedSettings.netherCenter = pullCorpseBox.focusBurstPos;
				oneBit.linedSettings.netherPulseDist = 0f;
				oneBit.linedSettings.netherRingEdges = new Vector4(0f, 0f, 0f, 40f);
				curtain.burstGo.SetActive(true);
				curtain.burstGo.transform.position = pullCorpseBox.focusBurstPos;
				curtain.burstGo.transform.localScale = 2f * Vector3.one;
				curtain.watchHand.Hide();
				exitPortal.mode = ExitPortal.Mode.ClosedInvisible;
				foreach (CorpseBox allCorpseBox2 in allCorpseBoxes)
				{
					allCorpseBox2.focusGo.SetActive(allCorpseBox2 == pullCorpseBox);
					allCorpseBox2.SetCorpseMaterialFocus(false);
				}
			}))
			.AddFunc(StaterFunc.SEQ_INTERP(2f, delegate(float t)
			{
				float num = t * 20f;
				float num2 = Util.LerpScale(t, 0.5f, 1f, 1f, 0f);
				oneBit.linedSettings.netherRingEdges = new Vector4(num, num + num2, num + num2, 40f);
				curtain.burstGo.transform.localRotation = Quaternion.AngleAxis(4f * Clock.play.time, new Vector3(0f, 1f, 0f));
			}))
			.AddFunc(StaterFunc.SEQ(delegate
			{
				oneBit.linedSettings.nether = false;
				curtain.burstGo.SetActive(false);
				Monitor.BlackOut(1);
				Game.LoadMomentScene(pullCorpseBox.visitMomentId);
			}));
		stater.AddState(State.PrepRevealingBookPages).SetDurations(7f).AddFunc(StaterFunc.ENTER(delegate
		{
			if (dialog.isPlaying)
			{
				dialog.Stop();
			}
		}))
			.AddFunc(StaterFunc.EVERYFRAME(delegate
			{
				Game.BlockPauseMenuForOneFrame();
			}))
			.AddFunc(StaterFunc.INTERP(delegate
			{
				strider.volume = Mathf.Max(0f, strider.volume - Clock.play.deltaTime / 7f);
			}))
			.AddFunc(StaterFunc.STEP(delegate
			{
				Monitor.BlackOut(1);
				if (musicAudioOneShot == null || musicAudioOneShot.done || musicAudioOneShot.time > musicAudioClip.length - 2f)
				{
					stater.Go(State.RevealingBookPages);
				}
				if (helpIris != null)
				{
					helpIris.ZeroAll();
				}
			}))
			.AddTarget(curtain.reverseCurtainStaterProp, 1f);
		stater.AddState(State.RevealingBookPages).AddFunc(StaterFunc.ENTER(delegate
		{
			if (musicAudioOneShot != null)
			{
				AudioPauseEcho component = musicAudioOneShot.GetComponent<AudioPauseEcho>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			AddVisitCountToSaveData();
			Game.instance.RevealNewBookPages(id);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (Book.active == null || !Book.active.inAnim)
			{
				stater.Go(State.InBookAfterReveal);
			}
			else if (!DebugCheckSkip())
			{
			}
		}));
		stater.AddState(State.InBookAfterReveal).AddFunc(StaterFunc.STEP(delegate
		{
			if (Book.active == null)
			{
				if (wantHunt)
				{
					AudioOneShot.Play(curtain.postBookAudioClip, false, 0.1f);
					stater.Go(State.Wander);
				}
				else
				{
					stater.Go(State.OpeningExitPortal);
				}
			}
			else if (!DebugCheckSkip())
			{
			}
		})).AddFunc(StaterFunc.EXIT(delegate
		{
			strider.volume = 1f;
			oneBit.linedSettings.curtainSettings.reverse = false;
			oneBit.linedSettings.curtainSettings.t = 0f;
		}));
		stater.AddState(State.OpeningExitPortal).SetDurations(0f, 3f, State.Wander).AddFunc(StaterFunc.AT_STEP(1f, delegate
		{
			exitPortal.mode = ExitPortal.Mode.Open;
			exitPortal.PlayOpenAudio();
		}))
			.AddFunc(StaterFunc.EVERYFRAME(delegate
			{
				Monitor.BlackOut(1);
			}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				AudioOneShot.Play(curtain.postBookAudioClip, false, 0.1f);
			}));
		stater.AddState(State.ExitMomentDoor).SetDurations(1f, 0f, State.ReturnToExploring).AddFunc(StaterFunc.ENTER(delegate
		{
			if (dialog.isPlaying)
			{
				dialog.Stop();
			}
		}))
			.AddFunc(StaterFunc.EVERYFRAME(delegate
			{
				Game.BlockPauseMenuForOneFrame();
			}))
			.AddFunc(StaterFunc.INTERP(delegate(float t)
			{
				if (curtain.chargingAudioOneShot == null)
				{
					curtain.chargingAudioOneShot = AudioOneShot.Play(curtain.chargingAudioClip, false, 0f);
				}
				float volume = Util.LerpScale(t, 0f, 0.5f, 0f, 1f);
				curtain.chargingAudioOneShot.volume = volume;
			}))
			.AddFunc(StaterFunc.EXIT(delegate
			{
				curtain.StopChargingAudio();
				AudioOneShot.Play(curtain.cancelAudioClip);
				if (musicAudioOneShot != null)
				{
					musicAudioOneShot.Stop(0.1f);
				}
			}))
			.AddTarget(curtain.reverseCurtainStaterProp, 1f)
			.AddTarget(musicVolumeProp, 0f);
		stater.AddState(State.ReturnToExploring).AddFunc(StaterFunc.ENTER(delegate
		{
			Monitor.BlackOut(1);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (curtain.chargingAudioDone && (musicAudioOneShot == null || musicAudioOneShot.done))
			{
				SaveData.it.general.lastVisitedMomentExitPlayTime = SaveData.it.generalRo.playTime;
				AddVisitCountToSaveData();
				ClearMomentPlayerSpot();
				Game.SaveActive();
				Game.LoadExploringScene();
			}
			Monitor.BlackOut(1);
		}));
		stater.AddState(State.MomentPhoto).AddFunc(StaterFunc.ENTER(EnterMomentPhoto)).AddFunc(StaterFunc.STEP(delegate
		{
			if (Input.GetKeyDown(KeyCode.T))
			{
				MomentPhotographer.Snap(id, oneBit);
			}
		}));
		stater.AddState(State.MomentPhotoAuto).SetDurations(0f, 1f, State.MomentPhotoAutoDone).AddFunc(StaterFunc.ENTER(EnterMomentPhoto))
			.AddFunc(StaterFunc.AT_STEP(0.5f, delegate
			{
				MomentPhotographer.Snap(id, oneBit);
			}));
		stater.AddState(State.MomentPhotoAutoDone);
	}

	private void Update()
	{
		oneBit.linedSettings.curtainSettings.worldCenter = curtain.watchHand.curtainCenterWorldPos;
		if (musicAudioOneShot != null && !musicAudioOneShot.done && !musicAudioOneShot.fadingOut)
		{
			musicAudioOneShot.volume = musicVolumeProp.f;
			if (musicVolumeProp.f == 0f)
			{
				musicAudioOneShot.Stop();
			}
		}
		stater.Step(Clock.play.deltaTime);
		if (IsInState(State.Exploring) || IsInState(State.Music) || IsInState(State.Wander))
		{
			Game.AllowBookForOneFrame();
		}
	}

	public void GoMomentPhotoAuto()
	{
		stater.Go(State.MomentPhotoAuto);
	}

	private void EnterMomentPhoto()
	{
		exitPortal.gameObject.SetActive(false);
		dialog.Stop();
		MomentPhotographer.Prep(id);
		if (musicAudioOneShot != null)
		{
			musicAudioOneShot.Stop();
		}
	}

	public void StartEnterMoment(string enterMomentId_, bool fast)
	{
		if (!Game.IsValidScene(enterMomentId_))
		{
			SaveData.it.SetStat("demo-end", 1);
			return;
		}
		enterMomentId = enterMomentId_;
		curtain.watchHand.dial.hourT = (float)(Story.it.GetMoment(enterMomentId).disaster.index + 1) / 12f;
		stater.Go((!fast) ? State.EnterMomentStartSlow : State.EnterMomentStartFast);
	}

	public void StartHunt()
	{
		stater.Go(State.InHunt);
	}

	public void StartPullCorpse(CorpseBox corpseBox)
	{
		pullCorpseBox = corpseBox;
		stater.Go(State.PullCorpse);
	}

	public void StartInception(CorpseBox corpseBox)
	{
		pullCorpseBox = corpseBox;
		stater.Go(State.ExitMomentIncept);
	}

	public void CancelEnterMoment()
	{
		if (IsInState(State.EnterMomentStartSlow) || IsInState(State.EnterMomentStartFast))
		{
			stater.Go(State.EnterMomentCancel);
		}
	}

	private void AddVisitCountToSaveData()
	{
		if (!haveAddedVisitCountToSaveData)
		{
			haveAddedVisitCountToSaveData = true;
			SaveData.it.moment[id].visitCount++;
			SaveData.it.UpdateZoneCompletion(Story.it.GetMoment(id).zone);
		}
	}

	private void UpdateHuntNetherRing()
	{
		float num = 1f * oneBit.linedSettings.netherRingEdges.x / 20f + Clock.play.deltaTime;
		float num2 = num / 1f;
		if (num2 < 1f)
		{
			float num3 = num2 * 20f;
			float num4 = Util.LerpScale(num2, 0.5f, 1f, 1f, 0f);
			oneBit.linedSettings.netherRingEdges = new Vector4(num3, num3 + num4, num3 + num4, 40f);
		}
		else
		{
			oneBit.linedSettings.netherRingEdges = new Vector4(40f, 40f, 40f, 40f);
		}
	}

	private bool CheckSkipDialog()
	{
		if (wantSkipDialog || (canSkipDialog && dialog.time > 0.1f && RInput.GetButtonDown(4)))
		{
			wantSkipDialog = true;
			return true;
		}
		return false;
	}

	private void StoreMomentPlayerSpot()
	{
		if (momentPlayerSpot == null)
		{
			momentPlayerSpot = new Player.Spot();
		}
		Player.instance.FillSpot(momentPlayerSpot);
		SaveData.it.SetPlayerMomentSpot(id, momentPlayerSpot);
	}

	private void ClearMomentPlayerSpot()
	{
		SaveData.it.SetPlayerMomentSpot(string.Empty, null);
	}

	private void UpdateWanderStriderVolume(float speed = 1f)
	{
		if (dialog == null || !dialog.isPlaying)
		{
			strider.volume = Mathf.Min(1f, strider.volume + speed * Clock.play.deltaTime / 10f);
		}
	}

	private void SetSoloWatch(bool soloWatch)
	{
		if (soloWatchLayerMask == 0)
		{
			soloWatchLayerMask = 1 << LayerMask.NameToLayer("Player");
		}
		oneBit.linedSettings.curtainSettings.t = (soloWatch ? 1 : 0);
		oneBit.linedSettings.curtainSettings.behindWatchHand = soloWatch;
		oneBit.linedSettings.soloLayerBits = (soloWatch ? soloWatchLayerMask : 0);
	}

	private bool DebugCheckSkip()
	{
		return false;
	}
}
