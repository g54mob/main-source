using UnityEngine;

public class WaterfallLogic : Decoration
{
	private enum State
	{
		Waiting = 0,
		Approach = 1,
		Dialog = 2,
		Descent0 = 3,
		Descent0b = 4,
		Descent1 = 5,
		Descent2 = 6,
		DescentComplete = 7
	}

	private const int heroPosOffsetX = -4;

	private string buttonLabel1 = "Leave";

	private string buttonLabel2 = "Items";

	public AsciiAnimation animDescent0_prefab;

	public AsciiAnimation animDescent0b_prefab;

	public AsciiAnimation animDescent1_prefab;

	public AsciiAnimation animDescent2_prefab;

	public AsciiSprite backgroundDescent1_prefab;

	public AsciiSprite backgroundDescent2_prefab;

	private State currentState;

	private int stateElapsedTics;

	private AsciiAnimation animDescent0;

	private AsciiAnimation animDescent0b;

	private AsciiAnimation animDescent1;

	private AsciiAnimation animDescent2;

	private AsciiSprite backgroundDescent1;

	private AsciiSprite backgroundDescent2;

	private int delayTillNextItemCheck;

	private void SetState(State newState)
	{
		GameStates.Singleton.level.background.gameObject.SetActive(newState < State.Descent1);
		animDescent0.gameObject.SetActive(newState == State.Descent0);
		animDescent0b.gameObject.SetActive(newState == State.Descent0b);
		animDescent1.gameObject.SetActive(newState == State.Descent1);
		animDescent2.gameObject.SetActive(newState == State.Descent2);
		backgroundDescent1.gameObject.SetActive(newState == State.Descent1);
		backgroundDescent2.gameObject.SetActive(newState == State.Descent2 || newState == State.DescentComplete);
		if (currentState == State.Dialog)
		{
			UnregisterDialogCallbacks();
		}
		switch (newState)
		{
		case State.Approach:
		{
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			gameCamera.SetupLerpToPos(base.PositionX, gameCamera.PositionY, gameCamera.PositionZ, 0f);
			gameCamera.JumpToDestination();
			AmbianceController.singleton.AddAmbient("waterfall_a");
			GameStates.Singleton.level.heroLimitX = -4;
			break;
		}
		case State.Dialog:
			RegisterDialogCallbacks();
			GameStates.Singleton.ShowPlayChoiceDialog("The Deadwood Canyon river\nends in a steep waterfall.", buttonLabel1, buttonLabel2, Binding.Action.Leave, Binding.Action.Inventory);
			break;
		case State.Descent0:
			GameStates.Singleton.hero.PositionY = 1000;
			GameStates.Singleton.userCanLeaveQuest = false;
			GameStates.Singleton.HideMouse();
			animDescent0.Sprite.SetFrameIndex(0);
			animDescent0.Play();
			SfxController.singleton.Play("pickup_success");
			break;
		case State.Descent0b:
			animDescent0b.Sprite.SetFrameIndex(0);
			animDescent0b.Play();
			break;
		case State.Descent1:
			GameStates.Singleton.level.GetDecorationWithId("waterfall_bg").Die(DeathReason.DecorationCleanup);
			GameStates.Singleton.gameParticleLayer.RecycleAllParticles();
			animDescent1.Sprite.SetFrameIndex(0);
			animDescent1.Play();
			AmbianceController.singleton.StopAllAmbient();
			AmbianceController.singleton.AddAmbient("waterfall_b");
			break;
		case State.Descent2:
			GameStates.Singleton.gameParticleLayer.RecycleAllParticles();
			animDescent2.Sprite.SetFrameIndex(0);
			animDescent2.Play();
			AmbianceController.singleton.StopAllAmbient();
			AmbianceController.singleton.AddAmbient("waterfall_c");
			break;
		case State.DescentComplete:
		{
			ProgressFlags.SetFlag("waterfall_dialog_seen");
			GameStates.Singleton.CompleteQuest();
			Data.Quest questById = QuestController.singleton.GetQuestById("fungus_forest");
			QuestController.singleton.MakeAvailable(questById);
			GameStates.Singleton.StartQuest(questById);
			GameStates.Singleton.hero.ReplenishHitpoints();
			GameStates.Singleton.ShowMouse();
			AchievementController.singleton.ReportLocationStartedManually(questById);
			break;
		}
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		stateElapsedTics++;
		if (currentState == State.Approach)
		{
			if (GameStates.Singleton.hero.PositionX == base.PositionX + -4 && GameStates.Singleton.hero.PositionZ == base.PositionZ)
			{
				GameStates.Singleton.hero.SetState(Hero.State.Idle);
				if (HasGrapplingHook())
				{
					SetState(State.Descent0);
				}
				else if (!QuestController.singleton.HasPlayed("fungus_forest"))
				{
					SetState(State.Descent0);
				}
			}
		}
		else if (currentState == State.Dialog)
		{
			if (delayTillNextItemCheck-- <= 0)
			{
				delayTillNextItemCheck = 10;
				if (HasGrapplingHook())
				{
					SetState(State.Descent0);
				}
			}
		}
		else if (currentState == State.Descent0)
		{
			if (stateElapsedTics != 1 && stateElapsedTics == 82)
			{
				MusicController.singleton.Play("waterfall_descent");
			}
			if (!animDescent0.Playing)
			{
				SetState(State.Descent0b);
			}
		}
		else if (currentState == State.Descent0b)
		{
			if (!animDescent0b.Playing)
			{
				SetState(State.Descent1);
			}
		}
		else if (currentState == State.Descent1)
		{
			if (!animDescent1.Playing)
			{
				if (Level.OnCustomEvent != null)
				{
					Level.OnCustomEvent("complete", "waterfall");
				}
				SetState(State.Descent2);
			}
		}
		else if (currentState == State.Descent2 && !animDescent2.Playing)
		{
			SetState(State.DescentComplete);
		}
	}

	private void Update()
	{
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.Descent0)
		{
			animDescent0.Sprite.Draw(r, r.width / 2, offsetY);
		}
		else if (currentState == State.Descent0b)
		{
			animDescent0b.Sprite.Draw(r, r.width / 2, offsetY);
		}
		else if (currentState == State.Descent1)
		{
			backgroundDescent1.Draw(r, r.width / 2, 0);
			animDescent1.Sprite.Draw(r, r.width / 2, 0);
		}
		else if (currentState == State.Descent2 || currentState == State.DescentComplete)
		{
			backgroundDescent2.Draw(r, r.width / 2, 0);
			animDescent2.Sprite.Draw(r, r.width / 2, 0);
		}
	}

	private void HandleButton1(DialogButton button)
	{
		GameStates.Singleton.CompleteQuest();
	}

	private void HandleButton2(DialogButton button)
	{
		GameStates.Singleton.SetState(GameStates.State.PlayItemScreen);
	}

	private bool HasGrapplingHook()
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(hero.LeftHand != null) || !hero.LeftHand.id.Contains("grappling_hook"))
		{
			if (hero.RightHand != null)
			{
				return hero.RightHand.id.Contains("grappling_hook");
			}
			return false;
		}
		return true;
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
		Destroy(animDescent0);
		Destroy(animDescent0b);
		Destroy(animDescent1);
		Destroy(animDescent2);
		Destroy(backgroundDescent1);
		Destroy(backgroundDescent2);
	}

	private void Destroy(AsciiAnimation anm)
	{
		if (anm != null)
		{
			Object.Destroy(anm.gameObject);
		}
	}

	private void Destroy(AsciiSprite sprite)
	{
		if (sprite != null)
		{
			Object.Destroy(sprite.gameObject);
		}
	}

	protected override void Start()
	{
		base.Start();
		animDescent0 = Object.Instantiate(animDescent0_prefab);
		animDescent0b = Object.Instantiate(animDescent0b_prefab);
		animDescent1 = Object.Instantiate(animDescent1_prefab);
		animDescent2 = Object.Instantiate(animDescent2_prefab);
		animDescent0.Sprite.Load();
		animDescent0b.Sprite.Load();
		animDescent1.Sprite.Load();
		animDescent2.Sprite.Load();
		backgroundDescent1 = Object.Instantiate(backgroundDescent1_prefab);
		backgroundDescent2 = Object.Instantiate(backgroundDescent2_prefab);
		backgroundDescent1.Load();
		backgroundDescent2.Load();
		SetState(State.Approach);
	}
}
