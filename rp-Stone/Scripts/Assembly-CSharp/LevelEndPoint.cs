public class LevelEndPoint : Character
{
	private enum State
	{
		NormalGame = 0,
		ApproachingPoint = 1,
		AtPoint = 2
	}

	public bool destroyIfPassedByHero = true;

	public bool completeLevel = true;

	private State currentState;

	private void SetState(State newState)
	{
		currentState = newState;
	}

	private void Update()
	{
		Level level = GameStates.Singleton.level;
		Hero hero = GameStates.Singleton.hero;
		if (currentState == State.NormalGame)
		{
			if (destroyIfPassedByHero && hero.PositionX > base.PositionX)
			{
				Die(DeathReason.DecorationCleanup);
			}
			else
			{
				if (level.Enemies.Count != 0 || level.Pickups.Count != 0)
				{
					return;
				}
				for (int i = 0; i < level.HarvestableResources.Count; i++)
				{
					HarvestableResource harvestableResource = level.HarvestableResources[i];
					if (Inventory.Singleton.IsToolToHarvestEquipped(harvestableResource.resourceType))
					{
						return;
					}
				}
				SetState(State.ApproachingPoint);
				hero.SetMoveDestination(base.PositionX, base.PositionZ);
			}
		}
		else
		{
			if (currentState != State.ApproachingPoint)
			{
				return;
			}
			if (hero.PositionX == base.PositionX && hero.PositionZ == base.PositionZ)
			{
				SetState(State.AtPoint);
				if (completeLevel)
				{
					GameStates.Singleton.CompleteQuest();
				}
				else
				{
					Die(DeathReason.DecorationCleanup);
				}
				return;
			}
			if (level.Enemies.Count != 0 || level.Pickups.Count != 0)
			{
				SetState(State.NormalGame);
				hero.RestoreAI();
				return;
			}
			for (int j = 0; j < level.HarvestableResources.Count; j++)
			{
				HarvestableResource harvestableResource2 = level.HarvestableResources[j];
				if (Inventory.Singleton.IsToolToHarvestEquipped(harvestableResource2.resourceType))
				{
					SetState(State.NormalGame);
					hero.RestoreAI();
					break;
				}
			}
		}
	}
}
