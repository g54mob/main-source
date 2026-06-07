using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/TechTree/Unlockable Group")]
public class UnlockableGroup : Unlockable
{
	[SerializeField]
	private Unlockable[] _unlockables;

	public override Types Type => Types.UnlockableGroup;

	public override void Unlock()
	{
		Unlockable[] unlockables = _unlockables;
		for (int i = 0; i < unlockables.Length; i++)
		{
			unlockables[i].Unlock();
		}
	}

	public override bool IsUnlocked()
	{
		return _unlockables.Find((Unlockable unlockable) => !unlockable.IsUnlocked()) == null;
	}

	public override bool Contains(Unlockable unlockable)
	{
		Unlockable[] unlockables = _unlockables;
		for (int i = 0; i < unlockables.Length; i++)
		{
			if (unlockables[i] == unlockable)
			{
				return true;
			}
		}
		return false;
	}
}
