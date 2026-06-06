public class HomelessBirdsWarningBubble : WarningBubble
{
	protected override void Start()
	{
		base.Start();
		foreach (Bird bird in Community.PlayerCommunity.Birds)
		{
			UpdateBirdHousing(bird);
		}
	}

	protected override void Subscribe()
	{
		GameEventDispatcher.AddListener(GameEventType.BirdAddedToCommunity, OnBirdEvent);
		GameEventDispatcher.AddListener(GameEventType.BirdRemovedFromCommunity, OnBirdEvent);
		GameEventDispatcher.AddListener(GameEventType.BirdHouseUpdated, OnBirdEvent);
	}

	protected override void Unsubscribe()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BirdAddedToCommunity, OnBirdEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BirdRemovedFromCommunity, OnBirdEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BirdHouseUpdated, OnBirdEvent);
	}

	private void OnBirdEvent(GameEvent gameEvent)
	{
		BirdEvent birdEvent = gameEvent as BirdEvent;
		UpdateBirdHousing(birdEvent.Bird);
	}

	private void UpdateBirdHousing(Bird bird)
	{
		if (bird.IsInPlayerCommunity() && bird.BirdHouse == null)
		{
			AddHomelessBird(bird);
		}
		else
		{
			RemoveHomelessBird(bird);
		}
	}

	private void AddHomelessBird(Bird bird)
	{
		if (AddObjectOfInterest(new DefaultObjectOfInterest(bird.gameObject, ObjectType.Bird)))
		{
			if (_objectOfInterestContainer.ObjectsOfInterest.Count == 1)
			{
				StartCoroutine(BounceOutTweenCoroutine(_background));
			}
			else if (_objectOfInterestContainer.ObjectsOfInterest.Count > 1)
			{
				StartCoroutine(BounceOutTweenCoroutine(_counter));
			}
		}
	}

	private void RemoveHomelessBird(Bird bird)
	{
		RemoveObjectOfInterest(bird.gameObject);
	}
}
