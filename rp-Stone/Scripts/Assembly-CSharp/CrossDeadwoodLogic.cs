using UnityEngine;

public class CrossDeadwoodLogic : Decoration
{
	private enum State
	{
		None = 0,
		Part1_Delay = 1,
		Part1_Walk = 2,
		Part1_Throw = 3,
		Part1_ClimbIn = 4,
		Part1_Rowing = 5,
		Part2 = 6,
		Part3_Arriving = 7,
		Part3_BumpShore = 8,
		Part3_ClimbOut = 9,
		Part3_ApproachGate = 10,
		Dialog = 11
	}

	public AsciiAnimation anim1_bg_prefab;

	public AsciiAnimation anim1_fg_prefab;

	public AsciiAnimation anim1_walk_prefab;

	public AsciiAnimation anim1_throw_prefab;

	public AsciiAnimation anim1_climbIn_prefab;

	public AsciiAnimation anim1_rowing_prefab;

	public AsciiAnimation anim2_bg_prefab;

	public AsciiAnimation anim2_rowing_prefab;

	public AsciiAnimation anim2_tentacle_prefab;

	public AsciiAnimation anim3_bg_prefab;

	public AsciiAnimation anim3_arrive_prefab;

	public AsciiAnimation anim3_bumpShore_prefab;

	public AsciiAnimation anim3_climbOut_prefab;

	public AsciiAnimation anim3_approachGate_prefab;

	public DialogButton skipButton;

	private State currentState;

	private int elapsedStateTics;

	private AsciiAnimation anim1_bg;

	private AsciiAnimation anim1_fg;

	private AsciiAnimation anim1_walk;

	private AsciiAnimation anim1_throw;

	private AsciiAnimation anim1_climbIn;

	private AsciiAnimation anim1_rowing;

	private AsciiAnimation anim2_bg;

	private AsciiAnimation anim2_rowing;

	private AsciiAnimation anim2_tentacle;

	private AsciiAnimation anim3_bg;

	private AsciiAnimation anim3_arrive;

	private AsciiAnimation anim3_bumpShore;

	private AsciiAnimation anim3_climbOut;

	private AsciiAnimation anim3_approachGate;

	private AsciiAnimation currentAnimation;

	private bool showingSkipButton;

	private int showingSkipRemaining;

	private const int TENTACLE_PLAY_FRAME = 35;

	private const int TENTACLE_PAUSE_FRAME = 80;

	private const int TENTACLE_REPLAY_FRAME = 25;

	private static string TENTACLE_COUNT_KEY = "cross_deadwood_river_tentacle_count";

	private void SetState(State newState)
	{
		GameStates.Singleton.hero.PositionY = 1000;
		GameStates.Singleton.userCanLeaveQuest = false;
		anim1_bg.gameObject.SetActive(newState <= State.Part1_Rowing);
		anim1_walk.gameObject.SetActive(newState == State.Part1_Walk);
		anim1_throw.gameObject.SetActive(newState == State.Part1_Throw);
		anim1_climbIn.gameObject.SetActive(newState == State.Part1_ClimbIn);
		anim1_rowing.gameObject.SetActive(newState == State.Part1_Rowing);
		anim2_bg.gameObject.SetActive(newState == State.Part2);
		anim2_rowing.gameObject.SetActive(newState == State.Part2);
		anim3_bg.gameObject.SetActive(newState >= State.Part3_Arriving);
		anim3_arrive.gameObject.SetActive(newState == State.Part3_Arriving);
		anim3_bumpShore.gameObject.SetActive(newState == State.Part3_BumpShore);
		anim3_climbOut.gameObject.SetActive(newState == State.Part3_ClimbOut);
		anim3_approachGate.gameObject.SetActive(newState == State.Part3_ApproachGate);
		if (currentState == State.Dialog)
		{
			UnregisterDialogCallbacks();
		}
		AsciiAnimation asciiAnimation = null;
		if (newState == State.Part1_Delay)
		{
			TryInitTentacle();
		}
		else if (newState == State.Part1_Walk)
		{
			asciiAnimation = anim1_walk;
			AnalyticsMacros.CrossDeadwoodRiver();
		}
		else if (newState == State.Part1_Throw)
		{
			asciiAnimation = anim1_throw;
		}
		else if (newState == State.Part1_ClimbIn)
		{
			asciiAnimation = anim1_climbIn;
		}
		else if (newState == State.Part1_Rowing)
		{
			asciiAnimation = anim1_rowing;
		}
		else if (newState == State.Part2)
		{
			asciiAnimation = anim2_rowing;
		}
		else if (newState == State.Part3_Arriving)
		{
			asciiAnimation = anim3_arrive;
			IncreaseTentacleCount();
		}
		else if (newState == State.Part3_BumpShore)
		{
			asciiAnimation = anim3_bumpShore;
		}
		else if (newState == State.Part3_ClimbOut)
		{
			asciiAnimation = anim3_climbOut;
		}
		else if (newState >= State.Part3_ApproachGate)
		{
			asciiAnimation = anim3_approachGate;
		}
		if (newState == State.Dialog)
		{
			GameStates.Singleton.ShowMouse();
		}
		currentAnimation = asciiAnimation;
		if (asciiAnimation != null)
		{
			asciiAnimation.Sprite.SetFrameIndex(0);
			asciiAnimation.Play();
		}
		switch (newState)
		{
		case State.Part2:
		case State.Part3_Arriving:
			GameStates.Singleton.gameParticleLayer.RecycleAllParticles();
			break;
		case State.Dialog:
			RegisterDialogCallbacks();
			GameStates.Singleton.playChoiceDialog.SetupText(" A conspicuous Bronze Gate \n is built into the cliffside. ", "Examine", "Examine Later", KeyCode.E, KeyCode.L);
			GameStates.Singleton.ShowPlayChoiceDialog();
			HideSkipButton();
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedStateTics++;
		if (currentState == State.Part1_Delay && elapsedStateTics == 5)
		{
			MusicController.singleton.Play("cross_deadwood_river");
		}
		else if (currentState == State.Part3_Arriving && elapsedStateTics == 60)
		{
			AmbianceController.singleton.AddAmbient("cross_deadwood_wind");
		}
		if (currentState == State.Part1_Throw && elapsedStateTics == 70)
		{
			SfxController.singleton.Play("cross_deadwood_splash");
		}
		else if ((currentState == State.Part1_ClimbIn && elapsedStateTics == 73) || ((currentState == State.Part1_Rowing || currentState == State.Part2) && elapsedStateTics % 30 == 20))
		{
			SfxController.singleton.Play("cross_deadwood_row");
		}
		else if (currentState == State.Part3_BumpShore && elapsedStateTics == 5)
		{
			SfxController.singleton.Play("cross_deadwood_bump");
		}
		if (anim2_tentacle != null && currentState == State.Part2)
		{
			if (elapsedStateTics == 35)
			{
				anim2_tentacle.Play();
			}
			else if (elapsedStateTics == 115)
			{
				anim2_tentacle.Pause();
			}
			else if (elapsedStateTics == 140)
			{
				anim2_tentacle.Play();
			}
		}
		if (currentState == State.Part1_Delay && elapsedStateTics >= 45)
		{
			SetState(currentState + 1);
		}
		else if (currentAnimation != null && !currentAnimation.Playing)
		{
			SetState(currentState + 1);
		}
		UpdateSkipButton();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.None)
		{
			return;
		}
		int offsetX2 = r.width / 2;
		if (currentState <= State.Part1_Rowing)
		{
			anim1_bg.Sprite.Draw(r, offsetX2, 0);
		}
		else if (currentState == State.Part2)
		{
			anim2_bg.Sprite.Draw(r, offsetX2, 0);
			if (anim2_tentacle != null)
			{
				anim2_tentacle.Sprite.Draw(r, offsetX2, 0);
			}
		}
		else if (currentState >= State.Part3_Arriving)
		{
			anim3_bg.Sprite.Draw(r, offsetX2, 0);
		}
		if (currentAnimation != null)
		{
			currentAnimation.Sprite.Draw(r, offsetX2, 0);
		}
		if (currentState <= State.Part1_Rowing)
		{
			anim1_fg.Sprite.Draw(r, offsetX2, 0);
		}
		if (!Hud.IsEnabled(Hud.Flag.ABILITIES))
		{
			DrawSkipButton(r);
		}
	}

	private void Update()
	{
	}

	private void InitSkipButton()
	{
		ShowSkipButton();
		skipButton.OnPressed += delegate
		{
			GameStates.Singleton.LeaveQuest();
		};
	}

	private void ShowSkipButton()
	{
		showingSkipButton = true;
		showingSkipRemaining = 75;
	}

	private void HideSkipButton()
	{
		showingSkipRemaining = 0;
	}

	private void UpdateSkipButton()
	{
		if (showingSkipButton)
		{
			if (--showingSkipRemaining > 0)
			{
				skipButton.UpdateTic();
			}
			else if (AsciiMouse.singleton.down0)
			{
				ShowSkipButton();
			}
		}
	}

	private void DrawSkipButton(AsciiRenderProcedural r)
	{
		if (showingSkipButton && showingSkipRemaining > 0)
		{
			skipButton.Draw(r, 2, 1);
		}
	}

	private void HandleButton1(DialogButton button)
	{
		UnregisterDialogCallbacks();
		Data.Quest questById = QuestController.singleton.GetQuestById("bronze_gate");
		QuestController.singleton.MakeAvailable(questById);
		GameStates.Singleton.StartQuest(questById);
	}

	private void HandleButton2(DialogButton button)
	{
		UnregisterDialogCallbacks();
		Data.Quest questById = QuestController.singleton.GetQuestById("bronze_gate");
		QuestController.singleton.MakeAvailable(questById);
		GameStates.Singleton.LeaveQuest();
	}

	private void RegisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed += HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed += HandleButton2;
	}

	private void UnregisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed -= HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed -= HandleButton2;
	}

	private void OnDestroy()
	{
		UnregisterDialogCallbacks();
		Destroy(anim1_bg);
		Destroy(anim1_walk);
		Destroy(anim1_throw);
		Destroy(anim1_climbIn);
		Destroy(anim1_rowing);
		Destroy(anim2_bg);
		Destroy(anim2_rowing);
		Destroy(anim2_tentacle);
		Destroy(anim3_bg);
		Destroy(anim3_arrive);
		Destroy(anim3_bumpShore);
		Destroy(anim3_climbOut);
		Destroy(anim3_approachGate);
	}

	private void Destroy(AsciiAnimation anm)
	{
		if (anm != null)
		{
			Object.Destroy(anm.gameObject);
		}
	}

	protected override void Start()
	{
		base.Start();
		anim1_bg = Object.Instantiate(anim1_bg_prefab);
		anim1_fg = Object.Instantiate(anim1_fg_prefab);
		anim1_walk = Object.Instantiate(anim1_walk_prefab);
		anim1_throw = Object.Instantiate(anim1_throw_prefab);
		anim1_climbIn = Object.Instantiate(anim1_climbIn_prefab);
		anim1_rowing = Object.Instantiate(anim1_rowing_prefab);
		anim1_bg.Sprite.Load();
		anim1_fg.Sprite.Load();
		anim1_walk.Sprite.Load();
		anim1_throw.Sprite.Load();
		anim1_climbIn.Sprite.Load();
		anim1_rowing.Sprite.Load();
		anim2_bg = Object.Instantiate(anim2_bg_prefab);
		anim2_rowing = Object.Instantiate(anim2_rowing_prefab);
		anim2_bg.Sprite.Load();
		anim2_rowing.Sprite.Load();
		anim3_bg = Object.Instantiate(anim3_bg_prefab);
		anim3_arrive = Object.Instantiate(anim3_arrive_prefab);
		anim3_bumpShore = Object.Instantiate(anim3_bumpShore_prefab);
		anim3_climbOut = Object.Instantiate(anim3_climbOut_prefab);
		anim3_approachGate = Object.Instantiate(anim3_approachGate_prefab);
		anim3_bg.Sprite.Load();
		anim3_arrive.Sprite.Load();
		anim3_bumpShore.Sprite.Load();
		anim3_climbOut.Sprite.Load();
		anim3_approachGate.Sprite.Load();
		SetState(State.Part1_Delay);
		if (!QuestController.singleton.HasPlayed("bronze_gate"))
		{
			GameStates.Singleton.HideMouse();
		}
		else
		{
			InitSkipButton();
		}
	}

	private void TryInitTentacle()
	{
		if (PlayerPrefs.GetInt(TENTACLE_COUNT_KEY) % 3 == 1)
		{
			anim2_tentacle = Object.Instantiate(anim2_tentacle_prefab);
			anim2_tentacle.Sprite.Load();
		}
	}

	private void IncreaseTentacleCount()
	{
		int num = PlayerPrefs.GetInt(TENTACLE_COUNT_KEY);
		PlayerPrefs.SetInt(TENTACLE_COUNT_KEY, num + 1);
	}

	public static void ResetTentacleCount()
	{
		PlayerPrefs.DeleteKey(TENTACLE_COUNT_KEY);
	}
}
