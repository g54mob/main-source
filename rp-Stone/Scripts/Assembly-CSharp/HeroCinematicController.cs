using System;

public class HeroCinematicController : HeroController
{
	public int ticsPerMoveH = 2;

	public int ticsPerMoveV = 4;

	private int elapsedTicsMoveH;

	private int elapsedTicsMoveV;

	private int destinationX;

	private int destinationZ;

	private Character.LookDirection lookDirectionOnArrival;

	private bool destinationReached;

	public event Action OnDestinationReached;

	public void SetDestination(int destinationX, int destinationZ, Character.LookDirection lookDirectionOnArrival)
	{
		this.destinationX = destinationX;
		this.destinationZ = destinationZ;
		destinationReached = false;
		this.lookDirectionOnArrival = lookDirectionOnArrival;
	}

	public override void UpdateTic()
	{
		if (base.hero.frozenTics > 0)
		{
			return;
		}
		base.UpdateTic();
		if (base.hero.PositionX != destinationX)
		{
			elapsedTicsMoveH++;
			if (elapsedTicsMoveH >= ticsPerMoveH)
			{
				elapsedTicsMoveH = 0;
				if (base.hero.PositionX < destinationX)
				{
					base.hero.PositionX++;
				}
				else
				{
					base.hero.PositionX--;
				}
			}
		}
		if (base.hero.PositionZ != destinationZ)
		{
			elapsedTicsMoveV++;
			if (elapsedTicsMoveV >= ticsPerMoveV)
			{
				elapsedTicsMoveV = 0;
				if (base.hero.PositionZ < destinationZ)
				{
					base.hero.PositionZ++;
				}
				else
				{
					base.hero.PositionZ--;
				}
			}
		}
		if (base.hero.PositionX != destinationX || base.hero.PositionZ != destinationZ)
		{
			base.hero.SetState(Hero.State.Walking);
			return;
		}
		base.hero.SetState(Hero.State.Idle);
		if (!destinationReached)
		{
			destinationReached = true;
			this.OnDestinationReached?.Invoke();
		}
		if (lookDirectionOnArrival != Character.LookDirection.None)
		{
			base.hero.lookDirection = lookDirectionOnArrival;
		}
	}

	public override void UpdateInput(float deltaTime)
	{
	}

	private void Start()
	{
	}
}
