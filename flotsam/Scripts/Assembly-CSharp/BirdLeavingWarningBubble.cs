public class BirdLeavingWarningBubble : WarningBubble
{
	protected override void Start()
	{
		base.Start();
		foreach (Bird bird in Community.PlayerCommunity.Birds)
		{
			UpdateBirdLeaving(bird);
		}
	}

	protected override void Subscribe()
	{
		GameEventDispatcher.AddListener(GameEventType.BirdAddedToCommunity, OnBirdEvent);
		GameEventDispatcher.AddListener(GameEventType.BirdRemovedFromCommunity, OnBirdEvent);
		GameEventDispatcher.AddListener(GameEventType.BirdVitalsUpdated, OnBirdEvent);
	}

	protected override void Unsubscribe()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BirdAddedToCommunity, OnBirdEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BirdRemovedFromCommunity, OnBirdEvent);
		GameEventDispatcher.RemoveListener(GameEventType.BirdVitalsUpdated, OnBirdEvent);
	}

	private void OnBirdEvent(GameEvent gameEvent)
	{
		BirdEvent birdEvent = gameEvent as BirdEvent;
		UpdateBirdLeaving(birdEvent.Bird);
	}

	private void UpdateBirdLeaving(Bird bird)
	{
		if (bird.IsInPlayerCommunity() && bird.IsLeaving)
		{
			AddBirdLeaving(bird);
		}
		else
		{
			RemoveBirdLeaving(bird);
		}
	}

	private void AddBirdLeaving(Bird bird)
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

	private void RemoveBirdLeaving(Bird bird)
	{
		RemoveObjectOfInterest(bird.gameObject);
	}
}
