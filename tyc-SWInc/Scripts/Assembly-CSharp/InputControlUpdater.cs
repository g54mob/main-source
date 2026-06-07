using UnityEngine;

public class InputControlUpdater : MonoBehaviour
{
	private void LateUpdate()
	{
		InputController.UpdateKeyLocks();
	}
}
