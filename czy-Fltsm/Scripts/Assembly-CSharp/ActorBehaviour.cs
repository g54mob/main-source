public abstract class ActorBehaviour : SceneBehaviour, IPanelContext
{
	public Community Community { get; set; }

	public abstract PanelID PanelID { get; }

	public abstract string Name { get; }

	public virtual void PrepareForRescue()
	{
	}

	public abstract void Rescue(Project project = null, Boat rescueBoat = null);

	public bool IsInPlayerCommunity()
	{
		if (Community != null)
		{
			return Community.IsPlayerCommunity();
		}
		return false;
	}
}
