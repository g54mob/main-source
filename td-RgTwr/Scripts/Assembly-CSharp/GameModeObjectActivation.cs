using UnityEngine;

public class GameModeObjectActivation : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToActivate;

	[SerializeField]
	private bool destroyOnFalse;

	private void Start()
	{
		if (CameraController.instance.firstPersonMode)
		{
			objectToActivate.SetActive(value: true);
		}
		else if (destroyOnFalse)
		{
			Object.Destroy(objectToActivate);
		}
		else
		{
			objectToActivate.SetActive(value: false);
		}
	}
}
