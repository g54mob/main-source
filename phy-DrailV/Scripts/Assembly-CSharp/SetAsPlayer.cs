using UnityEngine;

public class SetAsPlayer : MonoBehaviour
{
	public Camera playerCamera;

	private void Awake()
	{
		PlayerManager.SetPlayer(base.transform, playerCamera);
	}
}
