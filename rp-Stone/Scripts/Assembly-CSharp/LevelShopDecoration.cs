public class LevelShopDecoration : Decoration
{
	private enum State
	{
		Waiting = 0,
		Approach = 1,
		Observing = 2,
		ApproachingDoor = 3,
		OpeningDoor = 4,
		DoorAnimation = 5,
		EnteringShop = 6,
		TransitionToShopScreen = 7,
		Done = 8
	}

	public AsciiAnimation door;

	public int approachDistance = 20;

	public int approachOffsetX;

	public int approachOffsetZ;

	public int observeDuration = 20;

	public int approachingDoorOffsetX = 1;

	public int approachingDoorOffsetZ = 1;

	public int doorOpeningDuration = 20;

	public int openingDoorOffsetX = 1;

	public int openingDoorOffsetZ;

	public int doorAnimationDuration = 30;

	public int animatingDoorOffsetX = 2;

	public int animatingDoorOffsetZ = 1;

	public int enterShopOffsetX;

	public int enterShopOffsetZ;

	public int exitShopOffsetZ;

	private State currentState;

	private int elapsedStateTics;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Approach:
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			GameStates.Singleton.HideMouse();
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + approachOffsetX, base.PositionZ + approachOffsetZ);
			break;
		case State.ApproachingDoor:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + approachingDoorOffsetX, base.PositionZ + approachingDoorOffsetZ);
			break;
		case State.OpeningDoor:
			GameStates.Singleton.hero.PositionX = base.PositionX + openingDoorOffsetX;
			GameStates.Singleton.hero.PositionZ = base.PositionZ + openingDoorOffsetZ;
			GameStates.Singleton.hero.RestoreAI();
			GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
			GameStates.Singleton.hero.SetState(Hero.State.Pulling);
			SfxController.singleton.Play("shop_door_open", ignoreDuplicateSfxInSameFrame: true, 0.15f);
			break;
		case State.DoorAnimation:
			if (door != null)
			{
				door.Play();
			}
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + animatingDoorOffsetX, base.PositionZ + animatingDoorOffsetZ);
			break;
		case State.EnteringShop:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + enterShopOffsetX, base.PositionZ + enterShopOffsetZ);
			SfxController.singleton.Play("shop_door_enter", ignoreDuplicateSfxInSameFrame: true, 0.3f);
			break;
		case State.TransitionToShopScreen:
			GameStates.Singleton.ShowShop(id);
			GameStates.Singleton.ShowMouse();
			break;
		case State.Done:
			GameStates.Singleton.hero.PositionZ = base.PositionZ + exitShopOffsetZ;
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedStateTics++;
		if (currentState == State.Waiting)
		{
			if (base.PositionX - GameStates.Singleton.hero.PositionX < approachDistance)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.Approach)
		{
			if (GameStates.Singleton.hero.PositionX == base.PositionX + approachOffsetX && GameStates.Singleton.hero.PositionZ == base.PositionZ + approachOffsetZ)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.Observing && elapsedStateTics >= observeDuration)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ApproachingDoor)
		{
			if (GameStates.Singleton.hero.PositionX == base.PositionX + approachingDoorOffsetX && GameStates.Singleton.hero.PositionZ == base.PositionZ + approachingDoorOffsetZ)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.OpeningDoor && elapsedStateTics >= doorOpeningDuration)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.DoorAnimation && elapsedStateTics >= doorAnimationDuration)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.EnteringShop && GameStates.Singleton.hero.PositionX == base.PositionX + enterShopOffsetX && GameStates.Singleton.hero.PositionZ == base.PositionZ + enterShopOffsetZ)
		{
			SetState(State.TransitionToShopScreen);
		}
	}

	private void Update()
	{
		if (currentState == State.TransitionToShopScreen && GameStates.Singleton.CurrentState == GameStates.State.GateShopScreen)
		{
			SetState(State.Done);
		}
	}
}
