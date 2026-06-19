using Aggro.Core;

public class PlayerFloaterHandler : EntityBehaviourBase, IFloaterPopulator
{
	public void AddedFloater(FloaterUI floaterAdded)
	{
		floaterAdded.GetComponent<PlayerFloaterUI>().playerEntity = base.entity;
	}

	public void RemovedFloater()
	{
	}
}
