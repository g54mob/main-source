using UnityEngine;

public class ShipEnder : MonoBehaviour
{
	private enum State
	{
		ZoneUndone = 0,
		ZoneRevealingChapterComplete0 = 1,
		ZoneRevealingChapterComplete1 = 2,
		ZonePullerCallout = 3,
		ZoneDone = 4,
		ZoneDoneLookingAtPuller = 5,
		ZoneDoneChargingToLeave = 6,
		ZoneDoneWaitingToLeave = 7
	}

	public LiveRain liveRain;

	public SoundEnviron soundEnviron;

	public QuestTrigger ferryTrigger;

	public GameObject boatPullerGo;

	public Transform rewindPlayerPos;

	public AudioClip thunderAudioClip;

	[Space]
	public Dialog.AssetInfo notifyDialogInfo;

	public Dialog.AssetInfo finishedDialogInfo;

	public Dialog.AssetInfo unfinishedDialogInfo;

	public Dialog.AssetInfo confirmLeaveDialogInfo;

	public Dialog.AssetInfo endDialogInfo;

	private EnderClick enderClick;

	private Stater<State> stater;

	private bool haveShownFinishedOrUnfinishedDialog;

	private bool showLeaveDialog = true;

	private AudioSource boatPullerAudioSource;

	private QuestLookAt boatPullerLookAt;

	private bool staringAtBoatPuller
	{
		get
		{
			return ferryTrigger.containsPlayer && boatPullerLookAt.seenByPlayer;
		}
	}

	private void Start()
	{
		boatPullerLookAt = boatPullerGo.GetComponent<QuestLookAt>();
		boatPullerAudioSource = boatPullerGo.GetComponent<AudioSource>();
		enderClick = base.gameObject.GetComponent<EnderClick>();
		stater = new Stater<State>("ShipEnder");
		stater.AddState(State.ZoneUndone).AddFunc(StaterFunc.STEP(delegate
		{
			if (SaveData.it.GetStat("zone-complete-ship") > 0)
			{
				if (SaveData.it.general.era == 0)
				{
					SaveData.it.general.era = 1;
				}
				if (SaveData.it.GetWantRevealCompleteDisasterId().HasValue())
				{
					stater.Go(State.ZoneRevealingChapterComplete0);
				}
				else
				{
					soundEnviron.FadeOut(0f);
					Monitor.BlackOut(1);
					stater.Go(State.ZonePullerCallout);
				}
			}
		}));
		stater.AddState(State.ZoneRevealingChapterComplete0).AddFunc(StaterFunc.STEP(delegate
		{
			if (Book.active != null)
			{
				stater.Go(State.ZoneRevealingChapterComplete1);
			}
		}));
		stater.AddState(State.ZoneRevealingChapterComplete1).AddFunc(StaterFunc.STEP(delegate
		{
			if (Book.active == null)
			{
				Monitor.BlackOut(1);
				stater.Go(State.ZonePullerCallout);
			}
		}));
		stater.AddState(State.ZonePullerCallout).AddFunc(StaterFunc.ENTER(delegate
		{
			soundEnviron.FadeOut(2f);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			Monitor.BlackOut(2);
			Player.instance.DisableInputForOneFrame();
		}))
			.AddFunc(StaterFunc.AT_STEP(2f, delegate
			{
				AudioOneShot.Play(thunderAudioClip);
				liveRain.gameObject.SetActive(true);
			}))
			.AddFunc(StaterFunc.AT_STEP(4f, delegate
			{
				soundEnviron.FadeIn(4f);
			}))
			.AddFunc(StaterFunc.AT_STEP(8f, delegate
			{
				notifyDialogInfo.Show(boatPullerAudioSource);
				stater.Go(State.ZoneDone);
			}));
		stater.AddState(State.ZoneDone).AddFunc(StaterFunc.ENTER(delegate
		{
			soundEnviron.FadeIn(2f);
			liveRain.gameObject.SetActive(true);
		})).AddFunc(StaterFunc.STEP(delegate
		{
			enderClick.Uncharge();
			if (!(stater.stateTime < 1f))
			{
				if (ferryTrigger.containsPlayer)
				{
					if (boatPullerLookAt.seenByPlayer)
					{
						stater.Go(State.ZoneDoneLookingAtPuller);
					}
				}
				else
				{
					showLeaveDialog = true;
				}
			}
		}));
		stater.AddState(State.ZoneDoneLookingAtPuller).AddFunc(StaterFunc.STEP(delegate
		{
			enderClick.Uncharge();
			if (!staringAtBoatPuller)
			{
				stater.Go(State.ZoneDone);
			}
			else if (stater.stateTime > 1.5f)
			{
				stater.Go(State.ZoneDoneChargingToLeave);
			}
		}));
		stater.AddState(State.ZoneDoneChargingToLeave).AddFunc(StaterFunc.ENTER(delegate
		{
			if (showLeaveDialog)
			{
				if (!haveShownFinishedOrUnfinishedDialog)
				{
					if (SaveData.it.GetZoneIsSolved(Story.Zone.Ship))
					{
						finishedDialogInfo.Show();
					}
					else
					{
						unfinishedDialogInfo.Show();
					}
					haveShownFinishedOrUnfinishedDialog = true;
				}
				else
				{
					confirmLeaveDialogInfo.Show();
				}
				showLeaveDialog = false;
			}
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!Game.dialogIsPlaying && !soundEnviron.fadingOut)
			{
				soundEnviron.FadeOut(8f);
			}
			enderClick.Charge();
			if (!staringAtBoatPuller)
			{
				stater.Go(State.ZoneDone);
			}
			else if (enderClick.done)
			{
				stater.Go(State.ZoneDoneWaitingToLeave);
			}
		}));
		stater.AddState(State.ZoneDoneWaitingToLeave).AddFunc(StaterFunc.ENTER(delegate
		{
			endDialogInfo.Show();
		})).AddFunc(StaterFunc.STEP(delegate
		{
			if (!Game.dialogIsPlaying)
			{
				SaveData.it.general.era = 2;
				SaveData.it.SetPlayerExploringSpot(new Player.Spot(rewindPlayerPos));
				Game.LoadTally();
			}
		}));
		stater.Go((SaveData.it.generalRo.era != 0) ? State.ZoneDone : State.ZoneUndone, true);
	}

	private void Update()
	{
		stater.Step(Clock.play.deltaTime);
	}
}
