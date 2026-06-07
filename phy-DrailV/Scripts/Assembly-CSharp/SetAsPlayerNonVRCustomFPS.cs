using UnityEngine;

public class SetAsPlayerNonVRCustomFPS : MonoBehaviour
{
	public Camera playerCamera;

	private void Awake()
	{
		if (!VRManager.IsVREnabled())
		{
			PlayerManager.SetPlayer(base.transform, playerCamera);
		}
		Object.Destroy(this);
	}
}
