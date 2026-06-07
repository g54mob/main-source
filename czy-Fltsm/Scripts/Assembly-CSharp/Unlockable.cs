using UnityEngine;

public abstract class Unlockable : PersistentProperties
{
	[SerializeField]
	[HideInInspector]
	private string _assetGuid;

	[SerializeField]
	private string _guid;

	public string Guid => _guid;

	public virtual void Unlock()
	{
		UnlockableManager.Unlock(this);
	}

	public virtual bool IsUnlocked()
	{
		return UnlockableManager.IsUnlocked(this);
	}

	public virtual bool Contains(Unlockable unlockable)
	{
		return unlockable == this;
	}
}
