public abstract class WorldSettingsSubMenu : UIComponentMonoBehaviour
{
	public abstract void Activate(WorldInfo worldInfo);

	public virtual void Deactivate()
	{
	}

	public abstract void Reset();

	public virtual bool HasPendingChanges()
	{
		return false;
	}
}
