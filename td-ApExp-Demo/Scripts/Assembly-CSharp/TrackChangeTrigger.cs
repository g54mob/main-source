using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class TrackChangeTrigger : MonoBehaviour
{
	[SerializeField]
	protected bool isGoingUp;

	[SerializeField]
	protected bool isReturningToMainTrack;

	[SerializeField]
	private Track track;

	private bool isTrainHit;

	private ModuleClaw moduleClaw;

	protected void Start()
	{
		if (!(Train.Instance.GetClawModuleSlot() == null) && !(Train.Instance.GetClawModuleSlot().Module == null))
		{
			if (Train.Instance.GetClawModuleSlot().Module.TryGetComponent<ModuleClaw>(out var component))
			{
				moduleClaw = component;
			}
			track.OnTrackSet += delegate
			{
				isTrainHit = false;
			};
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
	}

	private void FixedUpdate()
	{
		if (!isTrainHit && Train.Instance.Wagons[0].pathFollower.IsTurning() && Train.Instance.Wagons[0].transform.position.x >= base.transform.position.x)
		{
			isTrainHit = true;
			OnTrigger();
		}
	}

	protected virtual void OnTrigger()
	{
		if (moduleClaw == null && (bool)Train.Instance.GetClawModuleSlot().Module && Train.Instance.GetClawModuleSlot().Module.TryGetComponent<ModuleClaw>(out var component))
		{
			moduleClaw = component;
		}
		if ((bool)moduleClaw)
		{
			moduleClaw = Train.Instance.GetClawModuleSlot().Module.GetComponent<ModuleClaw>();
			moduleClaw.CompensateTurn(isGoingUp);
		}
		isTrainHit = true;
		if (isReturningToMainTrack)
		{
			TrackManager.Instance.ReturnToStraightPath();
		}
		else
		{
			TrackManager.Instance.SwitchToOtherTrack();
		}
	}
}
