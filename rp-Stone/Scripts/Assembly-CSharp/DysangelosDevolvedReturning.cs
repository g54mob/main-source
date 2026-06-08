using UnityEngine;

public class DysangelosDevolvedReturning : Decoration, IPostAsciiRendererEffect
{
	private enum State
	{
		WhiteFadeBack = 0,
		FallingToGround = 1,
		ExperienceDialog = 2,
		Completed = 3
	}

	private int heroApproachOffsetX = -19;

	private int elapsedStateTics;

	private bool doubleTreasure;

	private int DROP_OFFSET_X = 4;

	private int dropTravelTics = 30;

	private float dropTravelX = -0.48f;

	private float whiteScreenPercent;

	private State currentState { get; set; }

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.WhiteFadeBack:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			GameStates.Singleton.level.preventLevelComplete++;
			break;
		case State.FallingToGround:
			GetComponent<AsciiAnimation>().Play();
			break;
		case State.ExperienceDialog:
			GameStates.Singleton.level.XpEarned += 20;
			GameStates.Singleton.ScheduleXpDialog();
			break;
		case State.Completed:
			GameStates.Singleton.hero.RestoreAI();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			GameStates.Singleton.level.preventLevelComplete--;
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedStateTics++;
		if (currentState == State.WhiteFadeBack && elapsedStateTics >= 30)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.FallingToGround)
		{
			if (elapsedStateTics == 40)
			{
				DropTreasure(-1);
			}
			else if (elapsedStateTics == 45 && doubleTreasure)
			{
				DropTreasure(1);
			}
			else if (elapsedStateTics == 48)
			{
				AddKiReward();
			}
			else if (elapsedStateTics >= 75)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.ExperienceDialog && elapsedStateTics >= 5)
		{
			SetState(currentState + 1);
		}
	}

	private void AddKiReward()
	{
		InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, 20L);
		FloatingText floatingText = ShowFloatingText("+@20");
		if (floatingText != null)
		{
			floatingText.Message.color = Color.white;
		}
	}

	private void DropTreasure(int dropOffsetX)
	{
		string treasureId = ((level >= 6) ? "dysangelos_yellow" : ((level < 1) ? "dysangelos_5" : "dysangelos_cyan"));
		Data.Treasure treasureWithId = TreasureFactory.singleton.GetTreasureWithId(treasureId);
		if (treasureWithId != null)
		{
			CharacterTreasureSpawner treasureSpawnerForType = TreasureFactory.singleton.GetTreasureSpawnerForType(treasureWithId.type);
			treasureSpawnerForType.itemsInTreasure = treasureWithId.items;
			Character component = treasureSpawnerForType.GetComponent<Character>();
			component.PositionX = base.PositionX + DROP_OFFSET_X + dropOffsetX;
			component.PositionY = base.PositionY;
			component.PositionZ = base.PositionZ;
			AsciiAnimation component2 = component.GetComponent<AsciiAnimation>();
			if (component2 != null)
			{
				component2.Stop();
				component2.Play();
			}
			DecorationTravelComponent decorationTravelComponent = component.gameObject.AddComponent<DecorationTravelComponent>();
			decorationTravelComponent.durationTics = dropTravelTics;
			decorationTravelComponent.velocityX = dropTravelX;
			GameStates.Singleton.level.AddCharacter(component);
			BigHead.treasureTime = 2f;
			HamartiaEventController.singleton.ReportLocationVictory();
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (whiteScreenPercent <= 0f || GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			r.RemovePostEffect(this);
			return;
		}
		Color b = ColorConstants.offWhite;
		if (!AdditionalSettings.isScreenFlash)
		{
			b = Color.black;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetForeground();
				cell.SetForeground(Color.Lerp(foreground, b, whiteScreenPercent));
				Color background = cell.GetBackground();
				cell.SetBackground(Color.Lerp(background, b, whiteScreenPercent));
			}
		}
	}

	private void Update()
	{
		whiteScreenPercent -= Time.deltaTime * 1f;
	}

	private bool HasMoondial()
	{
		return Inventory.Singleton.HasItemById("moon_stone");
	}

	public override void Init()
	{
		base.Init();
		SetState(State.WhiteFadeBack);
		doubleTreasure = HasMoondial() && EventController.singleton.IsEventActiveAndStarted("summer");
	}
}
