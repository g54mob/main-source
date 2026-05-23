using UnityEngine;

public class ResetLoadoutOnCancel : MonoBehaviour
{
	public LoadoutUIHelper loadoutHelper;

	private bool loadoutLockedIn;

	public void OnShow()
	{
		loadoutLockedIn = false;
	}

	public void OnDeactivate()
	{
		if (!loadoutLockedIn)
		{
			loadoutHelper.ResetToBufferedLoadout();
		}
	}

	public void LockInLoadout()
	{
		loadoutLockedIn = true;
	}
}
