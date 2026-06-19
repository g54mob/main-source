using Aggro.Core;

public class GrabbableHolderTrigger : EntityBehaviourBase
{
	public GrabbableHolder holder { get; private set; }

	protected override void OnInitializeBehaviour()
	{
		holder = GetComponentInParent<GrabbableHolder>();
	}
}
