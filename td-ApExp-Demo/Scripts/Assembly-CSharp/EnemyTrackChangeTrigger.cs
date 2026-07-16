using UnityEngine;

public class EnemyTrackChangeTrigger : TrackChangeTrigger
{
	protected new void Start()
	{
	}

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (!(other.gameObject.GetComponent<EnemyBase>() != null))
		{
			return;
		}
		EnemyBase component = other.gameObject.GetComponent<EnemyBase>();
		if (!component.IsBoss)
		{
			if (isReturningToMainTrack)
			{
				component.targetOffsetY = 0f;
			}
			else if ((isGoingUp && component.enemyPos == EnemyBase.EnemyPositionOnScreen.TopOfScreen) || (!isGoingUp && component.enemyPos == EnemyBase.EnemyPositionOnScreen.BottomOfScreen))
			{
				component.targetOffsetY = component.turnAvoidDistance;
				component.AvoidTurn();
			}
		}
	}

	protected override void OnTrigger()
	{
	}
}
