namespace DV
{
	public class CarVisitChecker
	{
		private const float RECENTLY_VISITED_TIME_THRESHOLD = 7200f;

		private const float COUNTDOWN_TIME_UNIT = 5f;

		private readonly TrainCar car;

		private readonly bool propagateToFront;

		private readonly bool propagateToRear;

		private bool playerIsInCar;

		private readonly CountdownTimer recentlyVisitedTimer = new CountdownTimer();

		public bool IsRecentlyVisited
		{
			get
			{
				if (!playerIsInCar)
				{
					return recentlyVisitedTimer.RemainingTime > 0f;
				}
				return true;
			}
		}

		public float RecentlyVisitedRemainingTime => recentlyVisitedTimer.RemainingTime;

		public CarVisitChecker(TrainCar car, bool propagateToFront = false, bool propagateToRear = false)
		{
			this.car = car;
			this.propagateToFront = propagateToFront;
			this.propagateToRear = propagateToRear;
		}

		public void Deinitialize()
		{
			SetupListeners(set: false);
			playerIsInCar = false;
			recentlyVisitedTimer.StopCountdown();
		}

		public void SetupListeners(bool set)
		{
			if (set)
			{
				PlayerManager.CarChanged += OnPlayerCarChanged;
			}
			else
			{
				PlayerManager.CarChanged -= OnPlayerCarChanged;
			}
		}

		private void OnPlayerCarChanged(TrainCar playerCar)
		{
			if (!playerIsInCar)
			{
				if (playerCar != null && playerCar == car)
				{
					playerIsInCar = true;
					recentlyVisitedTimer.StopCountdown();
				}
			}
			else if (playerCar != car)
			{
				playerIsInCar = false;
				recentlyVisitedTimer.StartCountdown(7200f, 5f);
				if (propagateToFront)
				{
					VisitConnectedCars(car.frontCoupler.coupledTo);
				}
				if (propagateToRear)
				{
					VisitConnectedCars(car.rearCoupler.coupledTo);
				}
			}
		}

		private void VisitConnectedCars(Coupler connectedCoupler)
		{
			if (connectedCoupler == null)
			{
				return;
			}
			CarVisitChecker visitChecker = connectedCoupler.train.visitChecker;
			if (visitChecker == null)
			{
				return;
			}
			if (connectedCoupler.isFrontCoupler)
			{
				if (visitChecker.propagateToFront)
				{
					visitChecker.recentlyVisitedTimer.StartCountdown(7200f, 5f);
				}
			}
			else if (visitChecker.propagateToRear)
			{
				visitChecker.recentlyVisitedTimer.StartCountdown(7200f, 5f);
			}
		}

		public void LoadData(float loadedRecentlyVisitedTimeLeft)
		{
			recentlyVisitedTimer.StartCountdown(loadedRecentlyVisitedTimeLeft, 5f);
		}
	}
}
