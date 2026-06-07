using UnityEngine;

public abstract class AWorldMoverPlayerTracker : MonoBehaviour
{
	public abstract bool IsSynced();

	public abstract Transform GetTrackerTransform();

	public abstract Transform GetActualPlayer();

	public abstract void SetActualPlayer(Transform playerTransform);

	public abstract bool ShouldApplyOriginShift();

	public abstract void SetShouldApplyOriginShift(bool value);
}
